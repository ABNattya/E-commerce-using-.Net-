using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace E_commerce.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string shoppingCartID { get; set; }

        public List<ShoppingCartItem> Items { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        // this function to solve DependencyInjection order controler and shopping cart 

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>() ?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { shoppingCartID = cartId };
        }

        public void AddItemsToCart(Movie movie)
        {
            var item = _context.ShoppingCartItem.FirstOrDefault(n => n.movie.Id == movie.Id && n.ShoppingCartId == shoppingCartID);
            if (item == null)
            {
                item = new ShoppingCartItem()
                {
                    ShoppingCartId = shoppingCartID,
                    movie = movie,
                    quantity = 1
                };
                _context.ShoppingCartItem.Add(item);
            }
            else
                item.quantity++;
            _context.SaveChanges();
        }

        public void RemoveItemsToCart(Movie movie)
        {
            var item = _context.ShoppingCartItem.FirstOrDefault(n => n.movie.Id == movie.Id && n.ShoppingCartId == shoppingCartID);
            if (item != null)
            {
               if(item.quantity > 1)
                
                    item.quantity--;
                
               else
                    _context.ShoppingCartItem.Remove(item);
                
            }
                
            _context.SaveChanges();
        }



        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return Items ?? (Items = _context.ShoppingCartItem.Where(n=>n.ShoppingCartId==shoppingCartID).Include(n=>n.movie).ToList());
        }

        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItem.Where(n=>n.ShoppingCartId==shoppingCartID).Select(n=>n.movie.price*n.quantity).Sum();
            return total;
        }

        public async Task ClearCart()
        {
            var items = await _context.ShoppingCartItem.Where(n => n.ShoppingCartId == shoppingCartID).ToListAsync();
            _context.ShoppingCartItem.RemoveRange(items);
            await _context.SaveChangesAsync();
        }

    }
}
