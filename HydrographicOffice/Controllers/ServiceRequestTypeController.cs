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
    public class ServiceRequestTypeController : Controller
    {
        private readonly IServiceRequestRepository _serviceRequestRepository;
        private readonly IFileFormatRepository _fileFormatRepository;
        private readonly ICategoryRepository  _serviceTypeRepository;
        private readonly IContactUsRepository _ContactUsRepository;
        private readonly IUserRepository _userRepository;
        private readonly HydroDBContext _context;
        private readonly INotificationRepository _NotificationRepository;

        private readonly IMapper _mapper;

        public ServiceRequestTypeController(IServiceRequestRepository serviceRequestRepository, HydroDBContext context, IUserRepository userRepository,
            IFileFormatRepository fileFormatRepository ,IMapper mapper, INotificationRepository NotificationRepository, ICategoryRepository serviceTypeRepository, IContactUsRepository ContactUsRepository)
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

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_serviceTypeRepository.GetAll().Where(x => x.EnumServiceType == 1).ToList(), "Id", "ItemName");
            ViewBag.FileFormatId = new SelectList(_fileFormatRepository.GetAll(), "Id", "FileType");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ServiceVm obj)
        {
            var userLogin = HttpContext.User.Identity.Name;
            var userDetail = UserDetails(userLogin);
            var emailAddress = $"Dear {userDetail.Email}";
            var notificationName = "New Servcie Request";

            if (ModelState.IsValid)
                {
                    var mapper = _mapper.Map<ServiceRequestType>(obj);
                    var category = _context.Categories.Where(c => c.Id == obj.CategoryId).FirstOrDefault();
                     mapper.Status = 1;
                     var statusRequest = "Pendding";
                mapper.CreateAt = DateTime.Now;
                mapper.CreateBy = userDetail.UserName;
                    _serviceRequestRepository.Add(mapper);
                    _serviceRequestRepository.Save();

                _NotificationRepository.AddNotification(new Notification() { AssignTo = "Admin", isRead = false, CreateDate = DateTime.Now, Status = 0, RefId = mapper.Id, NotificationName = notificationName });
                _NotificationRepository.Save();

                _ContactUsRepository.AddContactUs(new ContactUs() 
                { Email = emailAddress ,
                    Title= "Oman National Hydrographic Office <br>",Message = $" Order Name: {category.ItemName }<br> { $" Quantity : {mapper.Quantity}" }<br> { $"Your Status is: {statusRequest}" }"});
                _ContactUsRepository.Save();
                return RedirectToAction("Index", "Home");
                }

            return View(obj);
        }

        public User UserDetails(string userLogin)
        {
            User user = _userRepository.GetByUserName(userLogin);
            return user;
        }



        public JsonResult Getlist(long type)
        {
            var result = _serviceTypeRepository.GetAll().Where(x=>x.EnumServiceType== type).ToList();
            
            return Json(result);
        }



        //public IActionResult Edit(long id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Details = _serviceRequestRepository.GetById(id);
        //    ViewBag.CategoryId = new SelectList(_serviceTypeRepository.GetAll().Where(x => x.EnumServiceType == Details.CategoryId).ToList(), "Id", "ItemName");
        //    ViewBag.FileFormatId = new SelectList(_fileFormatRepository.GetAll(), "Id", "FileType");
        //    if (Details == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(Details);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> Edit(long id, ServiceVm obj)
        //{
        //    if (id != obj.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        var mapper = _mapper.Map<ServiceRequestType>(obj);
        //        _serviceRequestRepository.Update(mapper);
        //        _serviceRequestRepository.Save();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View();
        //}

    }
}
