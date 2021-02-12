using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Terabaitas.Core;
using Terabaitas.Models;
using Terabaitas.ViewModels;

namespace Terabaitas.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IAccountManager<User> acc_manager;

        public UserController(IAccountManager<User> aManager)
        {
            acc_manager = aManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            User user = await acc_manager.GetCurrentUser(User);
            return View((user, acc_manager.IsManager(User)));
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserIndexLivingPlaceViewModel living_place)
        {
            User user = await acc_manager.GetCurrentUser(User);

            if (!ModelState.IsValid)
                return View((user, acc_manager.IsManager(User)));

            user.City = living_place.City;
            user.Address = living_place.Address;
            user.ZipCode = living_place.ZipCode;

            acc_manager.Edit(user);

            return View((user, acc_manager.IsManager(User)));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel user)
        {
            if(!ModelState.IsValid)
                return View();

            bool result = await acc_manager.CreateUser(user, user.Password, "User", ModelState);

            if (!result)
                return View();

            result = await acc_manager.Login(user.UserName, user.Password);

            if (result)
                return RedirectToAction("Index");

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel user, string ReturnUrl)
        {
            if (!ModelState.IsValid)
                return View();

            bool result = await acc_manager.Login(user.UserName, user.Password);

            if (!result)
            {
                ModelState.AddModelError("UserName", "Username or password is incorrect.");

                return View();
            }

            if (ReturnUrl != null)
                return Redirect(ReturnUrl);

            return RedirectToAction("Index", "Home");
            
        }

        public async Task<IActionResult> Logout()
        {
            await acc_manager.Logout(User);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserChangePasswordViewModel change_password)
        {
            var result = await acc_manager.ChangePassword(change_password.OldPassword, change_password.NewPassword, ModelState, User);
            
            if (!result)
                return View();

            return RedirectToAction("Index", "User");
        }
    }
}
