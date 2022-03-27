using Hydro.DAL.Entities;
using HydrographicOffice.Models;
using HydrographicOffice.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _User;
        private readonly RoleManager<IdentityRole> _Role;
        private readonly CultureLocalizer _Localizer;
        public AccountController(SignInManager<User> signInManager, UserManager<User> User, RoleManager<IdentityRole> role, CultureLocalizer Localizer)
        {
            _signInManager = signInManager;
            _User = User;
            _Localizer = Localizer;
            _Role = role;
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admins", new { Area = "Admin" });
            }
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    var user = await _User.FindByEmailAsync(model.Email);
                    var Roles = await _User.GetRolesAsync(user);
                    var admis = _Role.Roles.ToList();
                    if (Roles.Any(x => admis.Any(y => y.Name == x)))
                    {
                        var userPrincipal = await _signInManager.CreateUserPrincipalAsync(user);
                        var identity = userPrincipal.Identity;
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);

                        //var url = Url.RouteUrl("areas", );
                        //return Redirect("/Admin/AdminHome/Index");
                        return RedirectToAction("Index", "Admins", new { Area = "Admin" });
                    }
                }

                ModelState.AddModelError(string.Empty, _Localizer.Text("LoginFaild"));
            }
            return View(model);
        }


      
        public IActionResult AccessDenied()
        {

            return View();
        }


        [HttpGet]
        public IActionResult ChangePasswordForAdmin()
        {

            return View();
        }




        [HttpPost]
        public async Task<IActionResult> ChangePasswordForAdmin(ChangePasswordViewModel model)
        {
            try
            {
                string UserID = _User.GetUserId(User);
                if (!ModelState.IsValid || string.IsNullOrEmpty(UserID))
                {

                    //ModelState.AddModelError("", "file not selected");
                    return View(model);
                }

                var userdataobj = await _User.FindByIdAsync(UserID);

                var result = await _User.ChangePasswordAsync(userdataobj, model.OldPassword, model.NewPassword);

                if (result != null && result.Succeeded)
                {
                    return RedirectToAction("Logout");
                }
                else
                {
                    return View(model);
                }

            }
            catch (Exception ex)
            {
                return View(model);

            }

        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
