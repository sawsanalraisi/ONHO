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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Controllers
{
   [Area("Admin")]
  //  [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]

    public class OmanbookController : Controller
    {
        private readonly IOmanbookRepository _OmanbookService;
        private readonly IMapper _mapper;
        private IHostingEnvironment _environment;
       // private readonly INotificationRepository _NotificationRepository;
      private readonly IUserRepository _userRepository;

//INotificationRepository NotificationRepository,
        public OmanbookController(IOmanbookRepository omanbookService, IUserRepository userRepository, IMapper mapper, IHostingEnvironment environment)
        {
            _OmanbookService = omanbookService;
            _mapper = mapper;
            _environment = environment;
            _userRepository = userRepository;
          //_NotificationRepository = NotificationRepository;
            
        }
        [HttpGet]
        public IActionResult Index()
        {

            var list = _OmanbookService.GetAll().Where(c => c.Isdelete == false).OrderByDescending(c => c.Year);
            var MappedList = _mapper.Map<List<OmanbookDto>>(list);
            return View(MappedList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OmanbookMVm obj)
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
                
                var mapper = _mapper.Map<Omanbook>(obj);
                mapper.CreateAt = DateTime.Now;
               // mapper.CreateBy = UserDetailsLogin.UserName;
                mapper.CreateBy = "sawsan";
                _OmanbookService.Add(mapper);
                _OmanbookService.Save();
                TempData["success"] = "The Data is saved successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }
        public User UserDetails(string userLogin)
        {
            User user = _userRepository.GetByUserName(userLogin);
            return user;
        }
        public IActionResult Edit(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var OmanbookDetails = _OmanbookService.GetById(id);
            var updateDetails= _mapper.Map<OmanbookMVm>(OmanbookDetails);
            if (updateDetails == null)
            {
                return NotFound();
            }
            return View(updateDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long Id, [Bind("Id,Year,NoticeFileName")] OmanbookMVm omanbook)
        {
            if (Id != omanbook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var mapper = _mapper.Map<Omanbook>(omanbook);
                _OmanbookService.Update(mapper);
                _OmanbookService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(omanbook);
        }

        public async Task<IActionResult> Delete(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var OmanbookDetails = _OmanbookService.GetById(id);
            var updateViewModel = _mapper.Map<OmanbookMVm>(OmanbookDetails);

            if (updateViewModel == null)
            {
                return NotFound();
            }

            return View(updateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var delete = _OmanbookService.GetById(id);
            _OmanbookService.Delete(id);
            _OmanbookService.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}
