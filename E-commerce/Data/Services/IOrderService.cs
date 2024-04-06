using E_commerce.Models;

namespace E_commerce.Data.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersByUserIdAndRole(string userId,string role);
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail);
    }
}
