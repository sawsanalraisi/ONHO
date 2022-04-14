using AutoMapper;
using Hydro.BAL.DTO;
using Hydro.BAL.Interface;
using Hydro.BAL.Service;
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
    public class DifferentReportController : Controller
    {
        private readonly IDifferentReportsRepository _differentReportsRepository;
        private readonly IMapper _mapper;
        private IHostingEnvironment _environment;
        private readonly INotificationRepository _NotificationRepository;


        public DifferentReportController(IDifferentReportsRepository differentReportsRepository, INotificationRepository NotificationRepository, IMapper mapper, IHostingEnvironment environment)
        {
            _differentReportsRepository = differentReportsRepository;
            _mapper = mapper;
            _environment = environment;
            _NotificationRepository = NotificationRepository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DifferentReVm obj)
        {

            var list = new List<DocumentFile>();
            var notificationName = "Different Report";
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
                            list.Add(new DocumentFile { Path = filenameadnex, Type = 1 });

                            //obj.UploadeFile = filenameadnex;
                        }

                    }
                }
               
                var mapper = _mapper.Map<DifferentReport>(obj);
                mapper.Status = 1;
                _differentReportsRepository.Add(mapper);
                _differentReportsRepository.Save();
                mapper.ListOfFiles = list;
                _differentReportsRepository.AddDocument(mapper.ListOfFiles, mapper.Id);
                _NotificationRepository.AddNotification(new Notification() { AssignTo = "Admin", isRead = false, CreateDate = DateTime.Now, Status = 0, RefId = mapper.Id, NotificationName = notificationName });
                _NotificationRepository.Save();

                return RedirectToAction("Index", "Home");             
            }

            return View(obj);
        }

        //public IActionResult Edit(long id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var NoticeDetails = _differentReportsRepository.GetById(id);
        //    if (NoticeDetails == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(NoticeDetails);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id, DifferentReport differentReport)
        //{
        //    if (id != differentReport.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        _differentReportsRepository.Update(differentReport);
        //        _differentReportsRepository.Save();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(differentReport);
        //}

    }
}
