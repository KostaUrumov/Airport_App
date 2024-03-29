﻿using Aiport_App_Structure.Models;
using Airport_App_Core.Contracts;
using Airport_App_Core.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Airport_App.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly SignInManager<User> signInManager;




        public UserController(
            IUserService _userService,
            SignInManager<User> _signInManager
            )
        {
            userService = _userService;
            signInManager = _signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            AddNewUserModel user = new AddNewUserModel();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Register(AddNewUserModel user)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Register));
            }

            var newUser = await userService.RegisterNewUser(user);
            await userService.AddUserToRole(newUser);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            LogInViewModel model = new LogInViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LogInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            var loggedIn = userService.LogInAsync(model);
            if (loggedIn.Result == false)
            {
                return RedirectToAction(nameof(Login));
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ChangePass()
        {
            ChangePasswordModel model = new ChangePasswordModel();
            return View(model);
        }

        [HttpPost]
        public async Task <IActionResult> ChangePass(ChangePasswordModel model)
        {
            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            model.UserId = userId;
            await userService.ChangePass(model);
            return RedirectToAction("Index", "Home");
        }

    }
}
