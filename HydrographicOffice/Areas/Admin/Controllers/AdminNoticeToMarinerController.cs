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

    public class AdminNoticeToMarinerController : Controller
    {
        private readonly INoticeToMarinerRepository _noticeToMarinerService;
        private readonly IMapper _mapper;
        private IHostingEnvironment _environment;

        public AdminNoticeToMarinerController(INoticeToMarinerRepository noticeToMarinerService, IMapper mapper, IHostingEnvironment environment)
        {
            _noticeToMarinerService = noticeToMarinerService;
            _mapper = mapper;
            _environment = environment;
        }
        [HttpGet]
        public IActionResult IndexAdmin()
        {
            var list = _noticeToMarinerService.GetAll().Where(c => c.Isdelete == false).OrderByDescending(c => c.NoticeDate);
            var MappedList = _mapper.Map<List<NoticeToMarinerDto>>(list);
            return View(MappedList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NoticeToMVm obj)
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
                
                var mapper = _mapper.Map<NoticeToMariner>(obj);
            
                _noticeToMarinerService.Add(mapper);
                _noticeToMarinerService.Save();
                TempData["success"] = "The Data is saved successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }
        //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]

        public IActionResult Edit(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var NoticeDetails = _noticeToMarinerService.GetById(id);
            var updateDetails= _mapper.Map<NoticeToMVm>(NoticeDetails);
            if (updateDetails == null)
            {
                return NotFound();
            }
            return View(updateDetails);
        }
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]
        public async Task<IActionResult> Edit(long Id, [Bind("Id,NoticeType,NotiecDesc,NoticeFileName,NoticeDate,NoticeEdition")] NoticeToMVm noticeToMariner)
        {
            if (Id != noticeToMariner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var mapper = _mapper.Map<NoticeToMariner>(noticeToMariner);
                _noticeToMarinerService.Update(mapper);
                _noticeToMarinerService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(noticeToMariner);
        }

        //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]
        public async Task<IActionResult> Delete(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var noticeDetails =  _noticeToMarinerService.GetById(id);
            var updateViewModel = _mapper.Map<NoticeToMVm>(noticeDetails);

            if (updateViewModel == null)
            {
                return NotFound();
            }

            return View(updateViewModel);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var delete = _noticeToMarinerService.GetById(id);
              _noticeToMarinerService.Delete(id);
            _noticeToMarinerService.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}
