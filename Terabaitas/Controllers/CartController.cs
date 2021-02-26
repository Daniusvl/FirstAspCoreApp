using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Terabaitas.Core.Domain;
using Terabaitas.Core.Services.Abstract;
using Terabaitas.Mappers;
using Terabaitas.Models;

namespace Terabaitas.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUserService userService;
        private readonly IOrderService orderService;
        private readonly IShopItemService shopItemService;
        private readonly ICartHelper cartHelper;

        public CartController(IUserService user_service, IOrderService order_service, IShopItemService shop_item_service, ICartHelper cart_helper)
        {
            userService = user_service;
            orderService = order_service;
            shopItemService = shop_item_service;
            cartHelper = cart_helper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var _cart = cartHelper.GetCart(HttpContext.Session);
            return View(_cart.ToModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string add_remove, int? id)
        {
            var _cart = cartHelper.GetCart(HttpContext.Session);

            if (add_remove != null && id != null)
            {
                if (add_remove == "+")
                {
                    CartAddProductQuantity((int)id);
                    _cart = cartHelper.GetCart(HttpContext.Session);
                    return View(_cart.ToModel());
                }
                else if (add_remove == "-")
                {
                    CartRemoveProductQuantity((int)id);
                    _cart = cartHelper.GetCart(HttpContext.Session);
                    return View(_cart.ToModel());
                }

            }

            UserModel user = (await userService.GetCurrentUser(User)).ToModel();

            if (user is null)
                return View(_cart.ToModel());

            string user_id = user.Id;

            if (user_id is null || user_id == string.Empty)
                return View(_cart.ToModel());

            OrderModel order = new OrderModel()
            {
                UsersId = user_id,
                OrderedProducts = cartHelper.GetCartStr(HttpContext.Session),
                DateCreated = DateTime.Now
            };

            return Payment(order);
        }

        public IActionResult Payment(OrderModel order)
        {
            if (order is null)
                return RedirectToAction("Index", "Home");

            // payment logic...

            // if payment successful
            orderService.Add(order.ToDomain());
            cartHelper.SetCart(HttpContext.Session, new List<(ShopItem, int)>());

            return RedirectToAction("Index", "Home");
        }

        [NonAction]
        private bool CartRemoveProductQuantity(int id)
        {
            if (id < 0)
                return false;

            var item = shopItemService.Get(id);

            if (item is null)
                return false;

            cartHelper.RemoveFromCart(HttpContext.Session, item);

            return true;
        }

        [NonAction]
        private bool CartAddProductQuantity(int id)
        {
            if (id < 0)
                return false;

            var item = shopItemService.Get(id);

            if (item is null)
                return false;

            cartHelper.AddToCart(HttpContext.Session, item);

            return true;
        }
    }
}
