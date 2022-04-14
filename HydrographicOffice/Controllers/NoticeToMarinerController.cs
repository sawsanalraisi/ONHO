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

    public class NoticeToMarinerController : Controller
    {
        private readonly INoticeToMarinerRepository _noticeToMarinerService;
        private readonly IMapper _mapper;
        private IHostingEnvironment _environment;

        public NoticeToMarinerController(INoticeToMarinerRepository noticeToMarinerService, IMapper mapper, IHostingEnvironment environment)
        {
            _noticeToMarinerService = noticeToMarinerService;
            _mapper = mapper;
            _environment = environment;
        }
        public IActionResult Index()
        {   
            var list = _noticeToMarinerService.GetAll().Where(c =>c.Isdelete==false).OrderByDescending(c =>c.NoticeDate);
            var MappedList = _mapper.Map<List<NoticeToMarinerDto>>(list);
            return View(MappedList);
        }
       
    }
}
