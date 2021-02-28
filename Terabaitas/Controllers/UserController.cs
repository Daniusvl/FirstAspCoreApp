using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Terabaitas.Core.Services.Abstract;
using Terabaitas.Models;
using Terabaitas.UI.Mappers;
using Terabaitas.ViewModels;

namespace Terabaitas.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService user_service)
        {
            userService = user_service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            UserModel user = (await userService.GetCurrentUser(User)).ToModel();
            return View((user, await userService.IsManager(User)));
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserIndexLivingPlaceViewModel living_place)
        {
            var user = (await userService.GetCurrentUser(User));

            if (!ModelState.IsValid)
                return View((user.ToModel(), userService.IsManager(User)));

            user.City = living_place.City;
            user.Address = living_place.Address;
            user.ZipCode = living_place.ZipCode;

            await userService.Edit(user);

            return View((user.ToModel(), await userService.IsManager(User)));
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

            bool result = await userService.CreateUser(((UserModel)user).ToDomain(), user.Password, "User", ModelState);

            if (!result)
                return View();

            result = await userService.Login(user.UserName, user.Password);

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

            bool result = await userService.Login(user.UserName, user.Password);

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
            await userService.Logout(User);
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
            var result = await userService.ChangePassword(change_password.OldPassword, change_password.NewPassword, ModelState, User);
            
            if (!result)
                return View();

            return RedirectToAction("Index", "User");
        }
    }
}
