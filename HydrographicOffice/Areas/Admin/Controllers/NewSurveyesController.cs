using AutoMapper;
using Hydro.BAL.DTO;
using Hydro.BAL.Interface;
using Hydro.DAL;
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
    [Area("Admin")]

    public class NewSurveyesController : Controller
    {
        private readonly INewSurveyRepository _newSurveyRepository;
        private readonly IMapper _mapper;
        private IHostingEnvironment _environment;
        private readonly IFileFormatRepository _fileFormatRepository;
        private readonly INotificationRepository _NotificationRepository;
        private readonly HydroDBContext _context;


        public NewSurveyesController(INewSurveyRepository newSurveyRepository, HydroDBContext context ,INotificationRepository NotificationRepository, IHostingEnvironment environment, IFileFormatRepository fileFormatRepository, IMapper mapper)
        {
            _newSurveyRepository = newSurveyRepository;
            _mapper = mapper;
            _environment = environment;
            _fileFormatRepository = fileFormatRepository;
            _newSurveyRepository = newSurveyRepository;
            _context = context;
            _NotificationRepository = NotificationRepository;
        }
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]

        public IActionResult Index()
        {
            var list = _newSurveyRepository.GetAll();
            var MappedList = _mapper.Map<List<NewSurveyDto>>(list);
            return View(MappedList);
        }

        public async Task<IActionResult> Details(long id, string notName)
        {
            
                var x = _context.Notifications.Where(c => c.RefId == id && c.NotificationName == notName).FirstOrDefault();
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

            var newSurvet = _newSurveyRepository.GetById(id);
            var map = _mapper.Map<NewSurveyVm>(newSurvet);
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
            var check = _newSurveyRepository.GetById(id);
            check.Status = stauts;
                     _newSurveyRepository.Update(check);
                     _newSurveyRepository.Save();
                     return RedirectToAction(nameof(Index));
            
        }


        public ActionResult patrialDetails(long Id)
        {
            var newSurvey = _newSurveyRepository.GetById(Id);
            var map = _mapper.Map<NewSurveyDto>(newSurvey);
            return PartialView("_fileslist", map);
        }


    }
}
