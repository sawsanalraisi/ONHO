using AutoMapper;
using Hydro.BAL.DTO;
using Hydro.BAL.Interface;
using Hydro.DAL;
using Hydro.DAL.Entities;
using HydrographicOffice.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Controllers
{
    [Area("Admin")]

    public class ServiceRequestTypesController : Controller
    {
        private readonly IServiceRequestRepository _serviceRequestRepository;
        private readonly IFileFormatRepository _fileFormatRepository;
        private readonly ICategoryRepository  _serviceTypeRepository;
        private readonly IContactUsRepository _ContactUsRepository;
        private readonly IUserRepository _userRepository;
        private readonly HydroDBContext _context;
        private readonly INotificationRepository _NotificationRepository;


        private readonly IMapper _mapper;

        public ServiceRequestTypesController(IServiceRequestRepository serviceRequestRepository, HydroDBContext context, IUserRepository userRepository,
            IFileFormatRepository fileFormatRepository , INotificationRepository NotificationRepository,IMapper mapper, ICategoryRepository serviceTypeRepository, IContactUsRepository ContactUsRepository)
        {
            _serviceRequestRepository = serviceRequestRepository;
            _fileFormatRepository = fileFormatRepository;
            _serviceTypeRepository = serviceTypeRepository;
            _ContactUsRepository = ContactUsRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _context = context;
            _NotificationRepository = NotificationRepository;
        }
        //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,AdsAdmin")]

        public IActionResult Index()
        {
            var list = _serviceRequestRepository.GetAll();
            var MappedList = _mapper.Map<List<ServiceRequestTypeDto>>(list);
            return View(MappedList);
        }

        public IActionResult UpdateRequest(int stauts,long id)
        {
            if (id == null)
            {
                return NotFound();
            }

              var check = _serviceRequestRepository.GetById(id);

               check.Status = stauts;

                //var mapper = _mapper.Map<ServiceRequestType>(check);
                _serviceRequestRepository.Update(check);
                _serviceRequestRepository.Save();
                return RedirectToAction(nameof(Index));
            
           
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

            var request = _serviceRequestRepository.GetById(id);
            var map = _mapper.Map<ServiceVm>(request);
            if (map == null)
            {
                return NotFound();
            }

            return View(map);
        }



    }
}
