using AutoMapper;
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
using System.Net;
using System.Threading.Tasks;

namespace HydrographicOffice.Controllers
{
    public class NewFeatureController : Controller
    {
        private readonly INewFeatureRepository _newFeatureRepository;
        private readonly IMapper _mapper;
        private IHostingEnvironment _environment;
        private readonly INotificationRepository _NotificationRepository;


        public NewFeatureController(INewFeatureRepository newFeatureRepository, INotificationRepository NotificationRepository, IMapper mapper, IHostingEnvironment environment)
        {
            _newFeatureRepository = newFeatureRepository;
            _mapper = mapper;
            _environment = environment;
            _NotificationRepository = NotificationRepository;

        }
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewFeatureVm obj)
        {
            var list = new List<DocumentFile>();

            var notificationName = "New Feature";
            if (ModelState.IsValid)
            {
                foreach (var item in obj.Files)
                {
                    if (item.Length > 0)
                    {

                        var filename = item.FileName.Replace("\"", string.Empty);
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
                            await item.CopyToAsync(stream);
                            list.Add(new DocumentFile { Path = filenameadnex, Type = 2 });

                            //obj.UploadeFile = filenameadnex;
                        }

                    }
                }
                var mapper = _mapper.Map<NewFeature>(obj);
                mapper.RequestStatus = 1;
                _newFeatureRepository.Add(mapper);
                _newFeatureRepository.Save();

                mapper.ListOfFiles = list;
                _NotificationRepository.AddNotification(new Notification() { AssignTo = "Admin", isRead = false, CreateDate = DateTime.Now, Status = 0, RefId = mapper.Id, NotificationName = notificationName });

                _NotificationRepository.Save();
                _newFeatureRepository.AddDocument(mapper.ListOfFiles, mapper.Id);
                TempData["Success"] = (System.Globalization.CultureInfo.CurrentCulture.DisplayName.Contains("English") ? "Done.. Your Request Success" : "تم إرسال طلبك");
                TempData.Keep("Success");
                return RedirectToAction("Index","Home");
            }
            return View(obj);
        }


        public IActionResult Edit(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var NewFeature =  _newFeatureRepository.GetById(id);
            if (NewFeature == null)
            {
                return NotFound();
            }
            return View(NewFeature);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Phone,Organization,Position,NewFeatureDate,Region,Character,status,Purpose,Description")] NewFeature newFeature)
        {
            if (id != newFeature.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               _newFeatureRepository.Update(newFeature);
               _newFeatureRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(newFeature);
        }

        public async Task<IActionResult> Delete(long id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var NewFeDetails = _newFeatureRepository.GetById(id);
            if (NewFeDetails == null)
            {
                return NotFound();
            }

            return View(NewFeDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return View();
        }
    }
}
