using AutoMapper;
using Hydro.BAL.DTO;
using Hydro.BAL.Interface;
using Hydro.DAL.Entities;
using HydrographicOffice.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using HydrographicOffice.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace HydrographicOffice.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userService;
        private readonly IMapper _mapper;
        private IHostingEnvironment _environment;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly CultureLocalizer _Localizer;
        public UserController(IUserRepository userService, CultureLocalizer Localizer, IMapper mapper, IHostingEnvironment environment, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userService = userService;
            _mapper = mapper;
            _environment = environment;
            _userManager = userManager;
            _signInManager = signInManager;
            _Localizer = Localizer;

        }

      
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginRegisterVm obj)
        {
            if (obj==null)
            {
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    //Password = obj.Password,
                    UserName = obj.Email,
                    FullName = obj.FullName,
                    OrgraizationName = obj.OrgraizationName,
                    Address = obj.Address,
                    Email = obj.Email,
                    PhoneNumber = obj.PhoneNumber,
                };

                var result = await _userManager.CreateAsync(user, obj.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(obj);
        }



        //public IActionResult UserLogin()
        //{

        //    return View();
        //}

       
        public async Task<JsonResult>UserLogin2(LoginViewModel model)
        {
           

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);

                    return Json( new { sates=true, erro="" });

                }

                ModelState.AddModelError(string.Empty, _Localizer.Text("LoginFaild"));

                return Json(new { sates = false, erro = _Localizer.Text("LoginFaild") });

            }
            else
            {
                if (string.IsNullOrEmpty(model.Email))
                {
                    return Json(new { sates = false, erro = _Localizer.Text("LoginFaild") });
                }
                if (string.IsNullOrEmpty(model.Password))
                {
                    return Json(new { sates = false, erro = _Localizer.Text("LoginFaild") });

                }

                return Json(new { sates = false, erro = _Localizer.Text("LoginFaild") });
            }

            //var controllerName = controllerActionDescriptor.ControllerName;
            //var actionName = controllerActionDescriptor.ActionName;
            //ViewBag.model = model;
            //return  View($"~/Views/{controllerName}/{actionName}.cshtml");

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RenderRegisterion()
        {
            LoginRegisterVm loginRegisterVm = new LoginRegisterVm();
            return PartialView("_RegisterPariatl", loginRegisterVm);
        }

    }
}
