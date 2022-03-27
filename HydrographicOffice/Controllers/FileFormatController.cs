using AutoMapper;
using Hydro.BAL.DTO;
using Hydro.BAL.Interface;
using Hydro.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Controllers
{
    public class FileFormatController : Controller
    {
        private readonly IFileFormatRepository _fileFormatRepository;
        private readonly IMapper _mapper;
        public FileFormatController(IFileFormatRepository fileFormatRepository, IMapper mapper)
        {
            _fileFormatRepository = fileFormatRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var list = _fileFormatRepository.GetAll();
            var MappedList = _mapper.Map<List<FileFormatDto>>(list);
            return View(MappedList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FileFormat obj)
        {
            if (ModelState.IsValid)
            {
                
                _fileFormatRepository.Add(obj);
                _fileFormatRepository.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        public IActionResult Edit(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var NoticeDetails = _fileFormatRepository.GetById(id);
            if (NoticeDetails == null)
            {
                return NotFound();
            }
            return View(NoticeDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, FileFormat fileFormat)
        {
            if (id != fileFormat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _fileFormatRepository.Update(fileFormat);
                _fileFormatRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(fileFormat);
        }
    }
}
