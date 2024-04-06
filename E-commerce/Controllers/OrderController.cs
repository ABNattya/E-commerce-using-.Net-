using E_commerce.Data.Cart;
using E_commerce.Data.Services;
using E_commerce.Data.Static;
using E_commerce.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_commerce.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderService _orderservice;


        public OrderController(ShoppingCart shoppingCart, IMovieService movieService, IOrderService orederservice)
        {
            _movieService = movieService;
            _shoppingCart = shoppingCart;
            _orderservice = orederservice;
            
        }  

        public async Task< IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string role = User.FindFirstValue(ClaimTypes.Role);
            var orders = await _orderservice.GetAllOrdersByUserIdAndRole(userId, role);
            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
            var items=_shoppingCart.GetShoppingCartItems();
            _shoppingCart.Items=items;

            var respons = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                total = _shoppingCart.GetShoppingCartTotal()
            };
            return View(respons);
        }

        public async Task< RedirectToActionResult> AddToShoppingCart(int id)
        {
            var item = await _movieService.GetMovieByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.AddItemsToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<RedirectToActionResult> RemoveToShoppingCart(int id)
        {
            var item = await _movieService.GetMovieByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.RemoveItemsToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); ;
            string Email = User.FindFirstValue(ClaimTypes.Email);

            await _orderservice.StoreOrderAsync(items, userId, Email);
            await _shoppingCart.ClearCart();

            return View("OrderCompleted");
        }
    }
}
