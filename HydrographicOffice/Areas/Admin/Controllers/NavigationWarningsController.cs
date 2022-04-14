using AutoMapper;
using Hydro.BAL.DTO;
using Hydro.BAL.Interface;
using Hydro.DAL.Entities;
using HydrographicOffice.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Controllers
{
    [Area("Admin")]

    public class NavigationWarningsController : Controller
    {
        private readonly INavigationWRepository _navigationWRepository;
        private readonly IMapper _mapper;
        private IHostingEnvironment _environment;
        private readonly IUserRepository _userRepository;

        public NavigationWarningsController(INavigationWRepository navigationWRepository, IUserRepository userRepository, IHostingEnvironment environment, IMapper mapper)
        {
            _navigationWRepository = navigationWRepository;
            _mapper = mapper;
            _environment = environment;
        }
        public IActionResult Index()
        {
            var list = _navigationWRepository.GetAll().Where(c => c.Isdelete == false).OrderByDescending(x=>x.WaringDate);
            var MappedList = _mapper.Map<List<NavigationWarningDto>>(list);
            return View(MappedList);
        }

        [HttpGet]
        public async Task <IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NavigationWVm obj)
        {
            var userLogin = HttpContext.User.Identity.Name;
            var UserDetailsLogin = UserDetails(userLogin);

            if (ModelState.IsValid)
            {
                if (obj.File.Length > 0)
                {

                    var filename = obj.File.FileName.Replace("\"", string.Empty);
                    var NewfileName = "";
                    var filenameadnex = "";
                    if (filename.Contains('.'))
                    {
                        var arrExtentions = filename.Split('.');
                        var lenExtention = arrExtentions.Length;
                        var extention = arrExtentions[lenExtention - 1];
                        filenameadnex = DateTime.Now.Ticks.ToString() + "." + extention;
                        NewfileName = "UploadedFiles/" + filenameadnex;
                    }
                    using (var stream = new FileStream(_environment.WebRootPath + "/" + NewfileName, FileMode.Create))
                    {
                        await obj.File.CopyToAsync(stream);
                        obj.UploadeFile = filenameadnex;
                    }

                }

                var mapper = _mapper.Map<NavigationWarning>(obj);
                mapper.CreateAt = DateTime.Now;
                mapper.CreateBy = userLogin;
                _navigationWRepository.Add(mapper);
                _navigationWRepository.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }
        public User UserDetails(string userLogin)
        {
            User user = _userRepository.GetByUserName(userLogin);
            return user;
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var warningeDetails = _navigationWRepository.GetById(id);
            var updateDetails = _mapper.Map<NavigationWVm>(warningeDetails);
            if (updateDetails == null)
            {
                return NotFound();
            }
            return View(updateDetails);
        }

        [HttpPost]
        public IActionResult Edit(long id ,NavigationWVm obj)
        {
            var userLogin = HttpContext.User.Identity.Name;

            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var mapper = _mapper.Map<NavigationWarning>(obj);
                mapper.UpdateAt = DateTime.Now;
                mapper.UpdateBy = userLogin;
                _navigationWRepository.Update(mapper);
                _navigationWRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var nwarning = _navigationWRepository.GetById(id);
            var nwarningDelete = _mapper.Map<NavigationWVm>(nwarning);

            if (nwarningDelete == null)
            {
                return NotFound();
            }

            return View(nwarningDelete);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var delete = _navigationWRepository.GetById(id);
            _navigationWRepository.Delete(id);
            _navigationWRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
