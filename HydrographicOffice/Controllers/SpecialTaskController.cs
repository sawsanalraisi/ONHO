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


        public SpecialTaskController(ISpecialTaskRepository specialTaskRepository, IHostingEnvironment environment, IMapper mapper)
        {
            _specialTaskRepository = specialTaskRepository;
            _mapper = mapper;
            _environment = environment;
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
        public async Task<IActionResult> CreateAsync(SpecialTaskVm obj)
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
                            list.Add(new DocumentFile { Path = filenameadnex, Type = 3 });

                            //obj.UploadeFile = filenameadnex;
                        }

                    }
                }
                var mapper = _mapper.Map<SpecialTask>(obj);
                _specialTaskRepository.Add(mapper);
                _specialTaskRepository.Save();

                mapper.ListOfFiles = list;

                _specialTaskRepository.AddDocument(mapper.ListOfFiles, mapper.Id);
                return RedirectToAction("Index", "Home");
            }

            return View(obj);
        }
    }
}
