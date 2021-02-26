using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Terabaitas.Core.Services.Abstract;
using Terabaitas.Mappers;
using Terabaitas.Models;

namespace Terabaitas.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShopItemService shopItemService;
        private readonly ICartHelper cartHelper;
        private readonly IRoleService roleService;
        private readonly IUserService userService;

        public HomeController(IShopItemService shop_item_service, ICartHelper cart_helper, IRoleService role_service, IUserService user_service)
        {
            shopItemService = shop_item_service;
            cartHelper = cart_helper;
            roleService = role_service;
            userService = user_service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ShopItemModel> items = new List<ShopItemModel>();
            var domains = shopItemService.GetAll();
            foreach (var item in domains)
            {
                items.Add(item.ToModel());
            }

            if (items.Count > 20)
                items.RemoveRange(0, items.Count - 20);

            return View((items, await userService.IsManager(User)));
        }

        [HttpPost]
        public async Task<IActionResult> Index(string product_type)
        {
            List<ShopItemModel> items = new List<ShopItemModel>();
            var domains = shopItemService.GetAll();
            foreach (var item in domains)
            {
                items.Add(item.ToModel());
            }

            if (product_type == "Nauji")
            {
                if (items.Count > 20)
                    items.RemoveRange(0, items.Count - 20);
            }
            else
            {
                items = items.Where(item => item.Type == product_type).ToList();
            }

            return View((items, await userService.IsManager(User)));
        }

        [HttpGet]
        [ActionName("Product")]
        public async Task<IActionResult> ProductGet(int? id)
        {
            if (id is null || id < 0)
                return RedirectToAction("Index");

            ShopItemModel item = shopItemService.Get((int)id).ToModel();

            if(item is null)
                return RedirectToAction("Index");

            return View((item, await userService.IsManager(User)));
        }

        [HttpPost]
        [ActionName("Product")]
        public async Task<IActionResult> ProductPost(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "User");

            if (id is null || id < 0)
                return RedirectToAction("Index");

            ShopItemModel item = shopItemService.Get((int)id).ToModel();

            if (item is null)
                return RedirectToAction("Index");

            cartHelper.AddToCart(HttpContext.Session, item.ToDomain());

            return View((item, await userService.IsManager(User)));
        }


        public IActionResult InitiateDb()
        {
            roleService.Add("User");
            roleService.Add("Manager");

            return RedirectToAction("Index");
        }
    }
}
