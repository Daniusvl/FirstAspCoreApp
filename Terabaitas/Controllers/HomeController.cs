using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Terabaitas.Core;
using Terabaitas.Models;

namespace Terabaitas.Controllers
{
    public class HomeController : Controller
    {
        private IDbAccess<ShopItem> shop_item_manager;
        private Cart cart;

        private RoleManager role_manager;
        private IAccountManager<User> acc_manager;

        public HomeController(IDbAccess<ShopItem> iManager, RoleManager rManager, Cart c, IAccountManager<User> aManager)
        {
            shop_item_manager = iManager;
            cart = c;
            role_manager = rManager;
            acc_manager = aManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ShopItem> items = shop_item_manager.GetAll();

            if (items.Count > 20)
                items.RemoveRange(0, items.Count - 20);

            return View((items, await acc_manager.IsManager(User)));
        }

        [HttpPost]
        public async Task<IActionResult> Index(string product_type)
        {
            List<ShopItem> items = shop_item_manager.GetAll();

            if (product_type == "Nauji")
            {
                if (items.Count > 20)
                    items.RemoveRange(0, items.Count - 20);
            }
            else
            {
                items = items.Where(item => item.Type == product_type).ToList();
            }

            return View((items, await acc_manager.IsManager(User)));
        }

        [HttpGet]
        [ActionName("Product")]
        public async Task<IActionResult> ProductGet(int? id)
        {
            if (id is null || id < 0)
                return RedirectToAction("Index");

            ShopItem item = shop_item_manager.Get((int)id);

            if(item is null)
                return RedirectToAction("Index");

            return View((item, await acc_manager.IsManager(User)));
        }

        [HttpPost]
        [ActionName("Product")]
        public async Task<IActionResult> ProductPost(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "User");

            if (id is null || id < 0)
                return RedirectToAction("Index");

            ShopItem item = shop_item_manager.Get((int)id);

            if (item is null)
                return RedirectToAction("Index");

            cart.AddToCart(HttpContext.Session, item);

            return View((item, await acc_manager.IsManager(User)));
        }


        public IActionResult InitiateDb()
        {
            role_manager.Add("User");
            role_manager.Add("Manager");

            return RedirectToAction("Index");
        }
    }
}
