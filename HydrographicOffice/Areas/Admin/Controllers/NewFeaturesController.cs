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
using System.Net;
using System.Threading.Tasks;

namespace HydrographicOffice.Controllers
{
    [Area("Admin")]

    public class NewFeaturesController : Controller
    {
        private readonly INewFeatureRepository _newFeatureRepository;
        private readonly IMapper _mapper;
        private IHostingEnvironment _environment;

        private readonly INotificationRepository _NotificationRepository;

        public NewFeaturesController(INewFeatureRepository newFeatureRepository, INotificationRepository NotificationRepository, IMapper mapper, IHostingEnvironment environment)
        {
            _newFeatureRepository = newFeatureRepository;
            _mapper = mapper;
            _environment = environment;
            _NotificationRepository = NotificationRepository;
        }

        public IActionResult Index()
        {
            var list = _newFeatureRepository.GetAll();
            var MappedList = _mapper.Map<List<NewFeaturesDto>>(list);
            return View(MappedList);
        }

        public async Task<IActionResult> Details(long id, string notName)
        {
            var notfiy = _NotificationRepository.GetNotificationByIDAndNotName(id, notName);
            if (notfiy != null && notfiy.Id > 0)
            {
                notfiy.isRead = true;
                _NotificationRepository.Update(notfiy);
            }
            if (id == null)
            {
                return NotFound();
            }

            var newFeature = _newFeatureRepository.GetById(id);
            var map = _mapper.Map<NewFeatureVm>(newFeature);
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

            var check = _newFeatureRepository.GetById(id);

            check.RequestStatus = stauts;

            _newFeatureRepository.Update(check);
            _newFeatureRepository.Save();
            return RedirectToAction(nameof(Index));


        }

        public ActionResult patrialDetails(long Id)
        {
            var newFeature = _newFeatureRepository.GetById(Id);
            var map = _mapper.Map<NewFeaturesDto>(newFeature);
            return PartialView("_fileslist", map);
        }



    }
}
