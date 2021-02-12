using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Terabaitas.Core;
using Terabaitas.Models;

namespace Terabaitas.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private IAccountManager<User> acc_manager;
        private Cart cart;
        private IDbAccess<Order> order_manager;
        private IDbAccess<ShopItem> shop_manager;

        public CartController(IAccountManager<User> aManager, Cart c, IDbAccess<Order> oManager, IDbAccess<ShopItem> sManager)
        {
            acc_manager = aManager;
            cart = c;
            order_manager = oManager;
            shop_manager = sManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var _cart = cart.GetCart(HttpContext.Session);
            return View(_cart);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string add_remove, int? id)
        {
            var _cart = cart.GetCart(HttpContext.Session);

            if (add_remove != null && id != null)
            {
                if (add_remove == "+")
                {
                    CartAddProductQuantity((int)id);
                    _cart = cart.GetCart(HttpContext.Session);
                    return View(_cart);
                }
                else if (add_remove == "-")
                {
                    CartRemoveProductQuantity((int)id);
                    _cart = cart.GetCart(HttpContext.Session);
                    return View(_cart);
                }

            }

            User user = await acc_manager.GetCurrentUser(User);

            if (user is null)
                return View(_cart);

            string user_id = user.Id;

            if (user_id is null || user_id == string.Empty)
                return View(_cart);

            Order order = new Order()
            {
                UsersId = user_id,
                OrderedProducts = cart.GetCartStr(HttpContext.Session),
            };

            return Payment(order);
        }

        public IActionResult Payment(Order order)
        {
            if (order is null)
                return RedirectToAction("Index", "Home");

            // payment logic...

            // if payment successful
            order_manager.Add(order);
            cart.SetCart(HttpContext.Session, new List<(ShopItem, int)>());

            return RedirectToAction("Index", "Home");
        }

        [NonAction]
        private bool CartRemoveProductQuantity(int id)
        {
            if (id < 0)
                return false;

            var item =  shop_manager.Get(id);

            if (item is null)
                return false;

            cart.RemoveFromCart(HttpContext.Session, item);

            return true;
        }

        [NonAction]
        private bool CartAddProductQuantity(int id)
        {
            if (id < 0)
                return false;

            var item = shop_manager.Get(id);

            if (item is null)
                return false;

            cart.AddToCart(HttpContext.Session, item);

            return true;
        }
    }
}
