using E_commerce.Data.Cart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Data.ViewComponents
{
    public class ShoppingCartSummeryVC:ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummeryVC(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var item = _shoppingCart.GetShoppingCartItems();
            return View(item.Count);
        }
    }
}
