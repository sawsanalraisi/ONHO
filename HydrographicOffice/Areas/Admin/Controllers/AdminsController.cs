using Hydro.BAL.Interface;
using Hydro.DAL.Entities;
using HydrographicOffice.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminsController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _User;
        private readonly RoleManager<IdentityRole> _Role;
        private readonly ISupportRepository _SupportRepository;
        public AdminsController(SignInManager<User> signInManager, UserManager<User> user, RoleManager<IdentityRole> role, ISupportRepository ISupportRepository)
        {
            _signInManager = signInManager;
            _User = user;
            _Role = role;
            _SupportRepository = ISupportRepository;
        }
        public IActionResult Index()
        {
            List<UserViewModel> UserList = new List<UserViewModel>();
            foreach (var item in _User.Users.ToList())
            {
                if (true)
                {

                }
                UserList.Add(new UserViewModel { Email = item.Email, IsActive = ((item.LockoutEnd != null && item.LockoutEnd > DateTime.Now) ? false : true), Name = item.FullName, Id = item.Id, Roles = _User.GetRolesAsync(item).Result.ToList() });
            }

            return View(UserList.Except(UserList.Where(x => x.Roles.Contains("Admin")).ToList()));
        }

        public IActionResult New()
        {
            ViewBag.roles = _Role.Roles.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(UserViewModel obj)
        {
            ViewBag.roles = _Role.Roles.ToList();
            if (ModelState.IsValid)
            {
                if (obj.Roles != null && obj.Roles.Count() > 0)
                {

                }
                else
                {
                    ModelState.AddModelError(string.Empty, (System.Globalization.CultureInfo.CurrentCulture.DisplayName.Contains("English") ? "Please Select Roles for User" : "من فضلك اختر صلاحيات للمستخدم"));
                    return View(obj);
                }
                var userdataobj = await _User.FindByEmailAsync(obj.Email);

                if (userdataobj != null)
                {
                    ModelState.AddModelError(string.Empty, (System.Globalization.CultureInfo.CurrentCulture.DisplayName.Contains("English") ? "Email Already Used" : " تم استخدام هذا البريد الالكترونى من قبل"));
                    return View(obj);
                }

                User OBJ = new User
                {
                    FullName = obj.Name,
                    Email = obj.Email,
                    UserName = obj.Email,


                };
                var result = await _User.CreateAsync(OBJ, obj.Password);
                if (result.Succeeded)
                {
                    var result2 = await _User.AddToRolesAsync(OBJ, obj.Roles);
                    if (result2.Succeeded)
                    {
                        ViewBag.Done = (System.Globalization.CultureInfo.CurrentCulture.DisplayName.Contains("English") ? "User added correctly" : "تمت إضافة المستخدم بشكل صحيح");
                        _SupportRepository.AddLog(new Logs { Table = "Users", Action = "New", UserName = User.Identity.Name, CreatdDate = DateTime.Now });
                        ModelState.Clear();
                        return View(new UserViewModel());

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, (System.Globalization.CultureInfo.CurrentCulture.DisplayName.Contains("English") ? "Error Try Again" : " حدث خطأ"));
                        return View(obj);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, (System.Globalization.CultureInfo.CurrentCulture.DisplayName.Contains("English") ? "Error Try Again" : " حدث خطأ"));
                    return View(obj);
                }
            }

            return View(obj);
        }



        public async Task<IActionResult> Update(string ID)
        {
            var userdataobj = await _User.FindByIdAsync(ID);
            UserViewModel OBJ = new UserViewModel();
            OBJ.Name = userdataobj.FullName;
            OBJ.Id = userdataobj.Id;
            OBJ.Email = userdataobj.Email;
            OBJ.Roles = _User.GetRolesAsync(userdataobj).Result.ToList();
            ViewBag.roles = _Role.Roles.ToList();
            return View(OBJ);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserViewModel obj)
        {
            ViewBag.roles = _Role.Roles.ToList();
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                if (obj.Roles != null && obj.Roles.Count() > 0)
                {

                }
                else
                {
                    ModelState.AddModelError(string.Empty, (System.Globalization.CultureInfo.CurrentCulture.DisplayName.Contains("English") ? "Please Select Roles for User" : "من فضلك اختر صلاحيات للمستخدم"));
                    return View(obj);
                }
                var userdataobj = await _User.FindByEmailAsync(obj.Email);

                if (userdataobj != null && userdataobj.Id != obj.Id)
                {
                    ModelState.AddModelError(string.Empty, (System.Globalization.CultureInfo.CurrentCulture.DisplayName.Contains("English") ? "Email Already Used" : " تم استخدام هذا البريد الالكترونى من قبل"));
                    return View(obj);
                }
                var OBJ = await _User.FindByIdAsync(obj.Id);
                OBJ.Email = obj.Email;
                OBJ.UserName = obj.Email;
                OBJ.FullName = obj.Name;
                var result = await _User.UpdateAsync(OBJ);
                if (result.Succeeded)
                {
                    var oldRols = _User.GetRolesAsync(OBJ).Result.ToList();
                    var result3 = await _User.RemoveFromRolesAsync(OBJ, oldRols);
                    if (result3.Succeeded)
                    {
                        var result2 = await _User.AddToRolesAsync(OBJ, obj.Roles);
                        if (result2.Succeeded)
                        {
                            ViewBag.Done = (System.Globalization.CultureInfo.CurrentCulture.DisplayName.Contains("English") ? "User Updated correctly" : "تمت تعديل المستخدم بشكل صحيح");
                            _SupportRepository.AddLog(new Logs { Table = "Users", Action = "Update", UserName = User.Identity.Name, CreatdDate = DateTime.Now });
                            UserViewModel OBJ2 = new UserViewModel();
                            OBJ2.Name = OBJ.FullName ;
                            OBJ2.Id = OBJ.Id;
                            OBJ2.Email = OBJ.Email;
                            OBJ2.Roles = _User.GetRolesAsync(OBJ).Result.ToList();

                            return View(OBJ2);

                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, (System.Globalization.CultureInfo.CurrentCulture.DisplayName.Contains("English") ? "Error Try Again" : " حدث خطأ"));
                            return View(obj);
                        }

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, (System.Globalization.CultureInfo.CurrentCulture.DisplayName.Contains("English") ? "Error Try Again" : " حدث خطأ"));
                        return View(obj);
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, (System.Globalization.CultureInfo.CurrentCulture.DisplayName.Contains("English") ? "Error Try Again" : " حدث خطأ"));
                    return View(obj);
                }
            }

            return View(obj);
        }


        [HttpGet]
        public IActionResult ChangePassword(string ID)
        {
            ViewBag.ID = ID;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                var userdataobj = await _User.FindByIdAsync(model.OldPassword);

                if (!ModelState.IsValid && userdataobj != null)
                {

                    //ModelState.AddModelError("", "file not selected");
                    return View(model);
                }

                ViewBag.ID = userdataobj.Id;


                var remove = await _User.RemovePasswordAsync(userdataobj);
                if (remove.Succeeded)
                {

                    var add = await _User.AddPasswordAsync(userdataobj, model.NewPassword);
                    if (add.Succeeded)
                    {
                        _SupportRepository.AddLog(new Logs { Table = "Users", Action = "ChangePassword", UserName = User.Identity.Name, CreatdDate = DateTime.Now });
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, (System.Globalization.CultureInfo.CurrentCulture.DisplayName.Contains("English") ? "Error Try Again" : " حدث خطأ"));
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, (System.Globalization.CultureInfo.CurrentCulture.DisplayName.Contains("English") ? "Error Try Again" : " حدث خطأ"));
                    return View(model);
                }


            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, (System.Globalization.CultureInfo.CurrentCulture.DisplayName.Contains("English") ? "Error Try Again" : " حدث خطأ"));
                return View(model);

            }

        }
        public async Task<JsonResult> setlockout(string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var user = await _User.FindByIdAsync(Id);
                if (user.LockoutEnd != null && user.LockoutEnd > DateTime.Now)
                {
                    var x = await _User.SetLockoutEndDateAsync(user, (DateTime?)null);
                    if (x.Succeeded)
                    {
                        _SupportRepository.AddLog(new Logs { Table = "Users", Action = "Lockout", UserName = User.Identity.Name, CreatdDate = DateTime.Now });
                        return Json(1);
                    }
                    else
                    {
                        return Json(0);
                    }
                }
                else
                {
                    var x = await _User.SetLockoutEndDateAsync(user, DateTime.Now.AddYears(2));

                    if (x.Succeeded)
                    {
                        return Json(1);
                    }
                    else
                    {
                        return Json(0);
                    }
                }


            }


            return Json(1);
        }


        public async Task<JsonResult> Delete(string ID)
        {
            var result = 0;
            var user = await _User.FindByIdAsync(ID);
            var x = await _User.DeleteAsync(user);
            if (x.Succeeded)
            {
                _SupportRepository.AddLog(new Logs { Table = "Users", Action = "Delete", UserName = User.Identity.Name, CreatdDate = DateTime.Now });
                result = 1;
            }
            else
            {

            }
            return Json(result);
        }
    }
}
