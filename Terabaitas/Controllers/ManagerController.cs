using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Terabaitas.Core.Services.Abstract;
using Terabaitas.Mappers;
using Terabaitas.Models;
using Terabaitas.ViewModels;

namespace Terabaitas.Controllers
{
    [Authorize]//(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IOrderHelper orderHelper;
        private readonly IShopItemService shopItemService;
        private readonly IUserService userService;

        public ManagerController(IOrderService order_service, IOrderHelper order_helper, IShopItemService shop_item_service, IUserService user_service)
        {
            orderService = order_service;
            orderHelper = order_helper;
            shopItemService = shop_item_service;
            userService = user_service;
        }

        public IActionResult Index()
        {
            var orders = new List<OrderModel>();
            var domains = orderService.GetAll();
            foreach (var item in domains)
            {
                orders.Add(item.ToModel());
            }
            return View((orders, orderHelper));
        }

        [HttpGet]
        public IActionResult Order(int order_id)
        {
            OrderModel order = orderService.Get(order_id).ToModel();
            return View((order, orderHelper));
        }

        [HttpPost]
        public IActionResult Order(int order_id, string btn)
        {
            if(btn == "atšaukti")
            {
                orderService.Remove(orderService.Get(order_id));
                return RedirectToAction("Index");
            }
            else if(btn == "pristatyti")
            {
                if (orderHelper.CanDeliver(order_id))
                {
                    orderHelper.FixProductQuantities(order_id);
                    orderService.Remove(orderService.Get(order_id));
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("error", "Šiuo metu nėra tam tikrų prekių");
                }
            }
            var order = orderService.Get(order_id).ToModel();
            return View((order, orderHelper));
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ManagerProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                ShopItemModel item = new ShopItemModel()
                {
                    Name = product.Name,
                    Description = product.Description,
                    Type = product.Type,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    DateCreated = DateTime.Now
                };

                shopItemService.Add(item.ToDomain());

                return RedirectToAction("Index", "Manager");
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            ShopItemModel item = shopItemService.Get(id).ToModel();

            return View(item);
        }

        [HttpPost]
        public IActionResult EditProduct(int id, ManagerProductViewModel product)
        {
            var item = shopItemService.Get(id);

            if (ModelState.IsValid)
            {
                item.Name = product.Name;
                item.Description = product.Description;
                item.Type = product.Type;
                item.Price = product.Price;
                item.Quantity = product.Quantity;


                shopItemService.Edit(item);

                return RedirectToAction("Product", "Home", new { id = item.Id });
            }
            return View(item.ToModel());
        }

        public IActionResult RemoveProduct(int id)
        {
            ShopItemModel item = shopItemService.Get(id).ToModel();

            if (item is null)
                return RedirectToAction("Product", "Home", new { id = id });

            shopItemService.Remove(item.ToDomain());

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(ManagerRegisterViewModel manager)
        {
            if(!ModelState.IsValid)
                return View();

            if (manager.SecretKey != "SecretKey123")
            {
                ModelState.AddModelError("key", "Neteisingas raktažodis");
                return View();
            }

            bool res = await userService.CreateUser(((UserModel)manager).ToDomain(), manager.Password, "Manager", ModelState);

            if(!res)
                return View();
            
            res = await userService.Login(manager.UserName, manager.Password);

            if(!res)
                return View();

            return RedirectToAction("Index", "User");
        }
    }
}
