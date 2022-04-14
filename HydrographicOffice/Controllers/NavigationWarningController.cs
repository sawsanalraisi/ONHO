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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Controllers
{
    public class NavigationWarningController : Controller
    {
        private readonly INavigationWRepository _navigationWRepository;
        private readonly IMapper _mapper;
        private IHostingEnvironment _environment;
        public NavigationWarningController(INavigationWRepository navigationWRepository, IHostingEnvironment environment, IMapper mapper)
        {
            _navigationWRepository = navigationWRepository;
            _mapper = mapper;
            _environment = environment;
        }
        public IActionResult Index()
        {
            var list = _navigationWRepository.GetAll().Where(c => c.Isdelete == false).OrderByDescending(x=>x.WaringDate);
            var MappedList = _mapper.Map<List<NavigationWarningDto>>(list);
            return View(MappedList);
        }


    }
}
