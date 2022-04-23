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
using System.Threading.Tasks;

namespace HydrographicOffice.Controllers
{
    public class SpecialTaskController : Controller
    {
        private readonly ISpecialTaskRepository _specialTaskRepository;
        private readonly IMapper _mapper;
        private IHostingEnvironment _environment;
        private readonly INotificationRepository _NotificationRepository;
        public SpecialTaskController(ISpecialTaskRepository specialTaskRepository, INotificationRepository NotificationRepository, IHostingEnvironment environment, IMapper mapper)
        {
            _specialTaskRepository = specialTaskRepository;
            _NotificationRepository = NotificationRepository;
            _mapper = mapper;
            _environment = environment;
        }
   

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpecialTaskVm obj)
        {
            var list = new List<DocumentFile>();
            var notificationName = "Special Task";

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
                            list.Add(new DocumentFile { Path = filenameadnex, Type = 3 });

                            //obj.UploadeFile = filenameadnex;
                        }

                    }
                }
                var mapper = _mapper.Map<SpecialTask>(obj);
                mapper.Status = 1;
                _specialTaskRepository.Add(mapper);
                _specialTaskRepository.Save();
                 _NotificationRepository.AddNotification(new Notification(){ AssignTo="Admin",isRead=false,CreateDate=DateTime.Now,Status=0,RefId=mapper.Id, NotificationName = notificationName });
                _NotificationRepository.Save();
                mapper.ListOfFiles = list;

                _specialTaskRepository.AddDocument(mapper.ListOfFiles, mapper.Id);
                TempData["Success"] = (System.Globalization.CultureInfo.CurrentCulture.DisplayName.Contains("English") ? "Done.. Your Request Success" : "تم إرسال طلبك");
                TempData.Keep("Success");

                return RedirectToAction("Index", "Home");
            }

            return View(obj);
        }
    }
}
