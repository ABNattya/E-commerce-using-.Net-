using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace E_commerce.Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrdersByUserIdAndRole(string userId,string role)
        {
            var orders =await _context.Order.Include(n=>n.Items).ThenInclude(n=>n.Movie).Include(n=>n.user).ToListAsync();

            if (role!="Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail)
        {
           var order=new Order()
           {
                UserId = userId,
                Email = userEmail
           };
            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.quantity,
                    movieId = item.movie.Id,
                    orderId = item.Id,
                    price = item.movie.price

                };
                
                await _context.SaveChangesAsync();
            }
        }
    }
}
