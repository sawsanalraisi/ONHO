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
    [Area("Admin")]

    public class DifferentReportsController : Controller
    {
        private readonly IDifferentReportsRepository _differentReportsRepository;
        private readonly IMapper _mapper;
        private IHostingEnvironment _environment;


        public DifferentReportsController(IDifferentReportsRepository differentReportsRepository,IMapper mapper, IHostingEnvironment environment)
        {
            _differentReportsRepository = differentReportsRepository;
            _mapper = mapper;
            _environment = environment;
        }
        public IActionResult Index()
        {
            var list = _differentReportsRepository.GetAll();
            var MappedList = _mapper.Map<List<DifferentRepDto>>(list);
            return View(MappedList);
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
                _differentReportsRepository.Add(mapper);
                _differentReportsRepository.Save();
                mapper.ListOfFiles = list;

                _differentReportsRepository.AddDocument(mapper.ListOfFiles, mapper.Id);
                return RedirectToAction("Index", "Home");
                
            }

            return View(obj);
        }

        public async Task<IActionResult> Details(long id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diffReport = _differentReportsRepository.GetById(id);
            var map = _mapper.Map<DifferentReVm>(diffReport);
            if (map == null)
            {
                return NotFound();
            }

            return View(map);
        }

        public IActionResult UpdateRequest(int stauts, long id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var check = _differentReportsRepository.GetById(id);

            check.Status = stauts;

            _differentReportsRepository.Update(check);
            _differentReportsRepository.Save();
            return RedirectToAction(nameof(Index));


        }

    }
}
