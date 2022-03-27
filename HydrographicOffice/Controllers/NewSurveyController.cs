using AutoMapper;
using Hydro.BAL.DTO;
using Hydro.BAL.Interface;
using Hydro.DAL.Entities;
using HydrographicOffice.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Controllers
{
    public class NewSurveyController : Controller
    {
        private readonly INewSurveyRepository _newSurveyRepository;
        private readonly IMapper _mapper;
        private IHostingEnvironment _environment;
        private readonly IFileFormatRepository _fileFormatRepository;


        public NewSurveyController(INewSurveyRepository newSurveyRepository, IHostingEnvironment environment, IFileFormatRepository fileFormatRepository, IMapper mapper)
        {
            _newSurveyRepository = newSurveyRepository;
            _mapper = mapper;
            _environment = environment;
            _fileFormatRepository = fileFormatRepository;
        }
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]

        public IActionResult Index()
        {
            var list = _newSurveyRepository.GetAll();
            var MappedList = _mapper.Map<List<NewSurveyDto>>(list);
            return View(MappedList);
        }

        [HttpGet]

        public IActionResult Create()
        {
          ViewBag.FileFormatId = new SelectList(_fileFormatRepository.GetAll(), "Id", "FileType");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync( NewSurveyVm obj)
        {
            var list = new List<LegalDocument>();
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
                            list.Add(new LegalDocument { Path = filenameadnex });

                            //obj.UploadeFile = filenameadnex;
                        }

                    }
                }
                try
                {
                    var mapper = _mapper.Map<NewSurvey>(obj);
                    mapper.Status = 1;
                    _newSurveyRepository.Add(mapper);
                    _newSurveyRepository.Save();

                    mapper.ListOLegalDocument = list;

                    _newSurveyRepository.AddLegalDocument(mapper.ListOLegalDocument, mapper.Id);
                    _newSurveyRepository.Save();
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {

                    throw ex;
                }
          
            }

            return View(obj);
        }

        public IActionResult UpdateRequest(int stauts, long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var check = _newSurveyRepository.GetById(id);
            check.Status = stauts;
            var mapper = _mapper.Map<NewSurvey>(check);
                     _newSurveyRepository.Update(mapper);
                     _newSurveyRepository.Save();
                     return RedirectToAction(nameof(Index));
            
        }
    }
}
