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
    [Area("Admin")]

    public class SpecialTasksController : Controller
    {
        private readonly ISpecialTaskRepository _specialTaskRepository;
        private readonly IMapper _mapper;
        private IHostingEnvironment _environment;
        private readonly INotificationRepository _NotificationRepository;


        public SpecialTasksController(ISpecialTaskRepository specialTaskRepository, INotificationRepository NotificationRepository, IHostingEnvironment environment, IMapper mapper)
        {
            _specialTaskRepository = specialTaskRepository;
            _mapper = mapper;
            _environment = environment;
            _NotificationRepository = NotificationRepository;

    }
    public IActionResult Index()
        {
            var list = _specialTaskRepository.GetAll();
            var mapper = _mapper.Map<List<SpecialTaskDto>>(list);
            return View(mapper);
        }

        public async Task<IActionResult> Detailstest(long id)
        {

            //if (_in.getbyrefid(id,notfactionname)!=null && _in.getbyrefid(id, notfactionname).id>0)
            //{
            //    _in.update();
            //}
            //var notfiy = _NotificationRepository.GetNotificationByID(id);
            //if (notfiy != null && notfiy.Id > 0)
            //{
            //    notfiy.isRead = true;
            //    _NotificationRepository.AddNotification(notfiy);
            //}
   
            if (id == null)
            {
                return NotFound();
            }

            var specialTask = _specialTaskRepository.GetById(id);
            var map = _mapper.Map<SpecialTaskVm>(specialTask);
            if (map == null)
            {
                return NotFound();
            }

            return View(map);
        }

        public async Task<IActionResult> Details(long id, string notName)
        {

            var notfiy = _NotificationRepository.GetNotificationByIDAndNotName(id,notName);
            if (notfiy != null && notfiy.Id>0)
            {
                notfiy.isRead = true;
                _NotificationRepository.Update(notfiy);
            }
            var specialTask = _specialTaskRepository.GetById(id);
            var map = _mapper.Map<SpecialTaskVm>(specialTask);
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

            var check = _specialTaskRepository.GetById(id);

            check.Status = stauts;

            _specialTaskRepository.Update(check);
            _specialTaskRepository.Save();
            return RedirectToAction(nameof(Index));


        }

        public ActionResult patrialDetails(long Id)
        {
            var specialtask = _specialTaskRepository.GetById(Id);
            var map = _mapper.Map<SpecialTaskDto>(specialtask);
            return PartialView("_fileslist", map);
        }

    }
}
