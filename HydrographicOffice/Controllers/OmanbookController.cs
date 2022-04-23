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

    namespace HydrographicOffice.Controllers
    {
        public class OmanbookController : Controller
        {
            private readonly IOmanbookRepository _OmanbookService;
            private readonly IMapper _mapper;
            private IHostingEnvironment _environment;

            public OmanbookController(IOmanbookRepository omanbookService, IMapper mapper, IHostingEnvironment environment)
            {
                _OmanbookService = omanbookService;
                _mapper = mapper;
                _environment = environment;

            }
            public IActionResult Index()
            {
                var list = _OmanbookService.GetAll().Where(c => c.Isdelete == false).OrderByDescending(c => c.Year);
                var MappedList = _mapper.Map<List<OmanbookDto>>(list);
                return View(MappedList);
            }

        }
    }
}