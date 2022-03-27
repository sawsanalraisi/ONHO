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
    public class NavigationWarningController : Controller
    {
        private readonly INavigationWRepository _navigationWRepository;
        private readonly IMapper _mapper;
        private IHostingEnvironment _environment;
        public NavigationWarningController(INavigationWRepository navigationWRepository, IHostingEnvironment environment, IMapper mapper)
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
        //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]
        public async Task <IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]
        public async Task<IActionResult> Create(NavigationWVm obj)
        {
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
                _navigationWRepository.Add(mapper);
                _navigationWRepository.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]
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
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]
        public IActionResult Edit(long id ,NavigationWVm obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var mapper = _mapper.Map<NavigationWarning>(obj);
                _navigationWRepository.Update(mapper);
                _navigationWRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }
    }
}
