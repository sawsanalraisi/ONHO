using AutoMapper;
using Hydro.BAL.DTO;
using Hydro.BAL.Interface;
using Hydro.DAL.Entities;
using HydrographicOffice.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Controllers
{
    public class ServiceTypeController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public ServiceTypeController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]
        public IActionResult Index()
        {
            var list = _categoryRepository.GetAll().Where(c =>c.Isdelete==false);
            var mapper = _mapper.Map<List<CategoryDto>>(list);
            return View(mapper);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]

        public async Task<IActionResult> Create(CategoryVm obj)
        {
            if (ModelState.IsValid)
            {
                var mapper = _mapper.Map<Category>(obj);
                _categoryRepository.Add(mapper);
                _categoryRepository.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(obj);
        }
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]

        public IActionResult Edit(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var details = _categoryRepository.GetById(id);
            if (details == null)
            {
                return NotFound();
            }
            return View(details);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]

        public async Task<IActionResult> Edit(long id, Category obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _categoryRepository.Update(obj);
                _categoryRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]

        public async Task<IActionResult> Delete(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Details = _categoryRepository.GetById(id);
            var update = _mapper.Map<CategoryVm>(Details);

            if (update == null)
            {
                return NotFound();
            }

            return View(update);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]

        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var delete = _categoryRepository.GetById(id);
            _categoryRepository.Delete(id);
            _categoryRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
