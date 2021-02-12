using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Terabaitas.Core;
using Terabaitas.Models;
using Terabaitas.ViewModels;

namespace Terabaitas.Controllers
{
    [Authorize]//(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private IDbAccess<Order> order_manager;
        private IDbAccess<ShopItem> shop_item_manager;
        private OrderHelper order_helper;
        private IAccountManager<User> acc_manager;

        public ManagerController(IDbAccess<Order> oManager, IDbAccess<ShopItem> sManager, OrderHelper oHelper, IAccountManager<User> aManager)
        {
            order_manager = oManager;
            shop_item_manager = sManager;
            order_helper = oHelper;
            acc_manager = aManager;
        }

        public IActionResult Index()
        {
            var orders = order_manager.GetAll();
            return View((orders, order_helper));
        }

        [HttpGet]
        public IActionResult Order(int order_id)
        {
            var order = order_manager.Get(order_id);
            return View((order, order_helper));
        }

        [HttpPost]
        public IActionResult Order(int order_id, string btn)
        {
            if(btn == "atšaukti")
            {
                order_manager.Remove(order_manager.Get(order_id));
                return RedirectToAction("Index");
            }
            else if(btn == "pristatyti")
            {
                if (order_helper.CanDeliver(order_id))
                {
                    order_helper.FixProductQuantities(order_id);
                    order_manager.Remove(order_manager.Get(order_id));
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("error", "Šiuo metu nėra tam tikrų prekių");
                }
            }
            var order = order_manager.Get(order_id);
            return View((order, order_helper));
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
                ShopItem item = new ShopItem()
                {
                    Name = product.Name,
                    Description = product.Description,
                    Type = product.Type,
                    Price = product.Price,
                    Quantity = product.Quantity
                };

                shop_item_manager.Add(item);

                return RedirectToAction("Index", "Manager");
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            ShopItem item = shop_item_manager.Get(id);

            return View(item);
        }

        [HttpPost]
        public IActionResult EditProduct(int id, ManagerProductViewModel product)
        {
            ShopItem item = shop_item_manager.Get(id);

            if (ModelState.IsValid)
            {
                item.Name = product.Name;
                item.Description = product.Description;
                item.Type = product.Type;
                item.Price = product.Price;
                item.Quantity = product.Quantity;
                

                shop_item_manager.Edit(item);

                return RedirectToAction("Product", "Home", new { id = item.Id });
            }
            return View(item);
        }

        public IActionResult RemoveProduct(int id)
        {
            ShopItem item = shop_item_manager.Get(id);

            if (item is null)
                return RedirectToAction("Product", "Home", new { id = id });

            shop_item_manager.Remove(item);

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

            bool res = await acc_manager.CreateUser(manager, manager.Password, "Manager", ModelState);

            if(!res)
                return View();
            
            res = await acc_manager.Login(manager.UserName, manager.Password);

            if(!res)
                return View();

            return RedirectToAction("Index", "User");
        }
    }
}
