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
    public class NewSurveyController : Controller
    {
        private readonly INewSurveyRepository _newSurveyRepository;
        private readonly IMapper _mapper;
        private IHostingEnvironment _environment;
        private readonly IFileFormatRepository _fileFormatRepository;
        private readonly INotificationRepository _NotificationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IContactUsRepository _ContactUsRepository;
        private readonly HydroDBContext _context;


        public NewSurveyController(INewSurveyRepository newSurveyRepository, HydroDBContext context ,IContactUsRepository ContactUsRepository, IUserRepository userRepository, INotificationRepository NotificationRepository, IHostingEnvironment environment, IFileFormatRepository fileFormatRepository, IMapper mapper)
        {
            _newSurveyRepository = newSurveyRepository;
            _mapper = mapper;
            _environment = environment;
            _fileFormatRepository = fileFormatRepository;
            _NotificationRepository = NotificationRepository;
            _userRepository = userRepository;
            _ContactUsRepository = ContactUsRepository;
            _context = context;
        }

        [HttpGet]

        public IActionResult Create()
        {
          ViewBag.FileFormatId = new SelectList(_fileFormatRepository.GetAll(), "Id", "FileType");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create( NewSurveyVm obj)
        {
            var userLogin = HttpContext.User.Identity.Name;
            var userDetail = UserDetails(userLogin);
            var emailAddress = $"Dear {userDetail.Email}";
            var list = new List<LegalDocument>();
            var notificationName = "New Survey";
            var statusRequest = "Pendding";

            if (ModelState.IsValid)
            {

                foreach (var item in obj.Files)
                {
                    if (item.Length > 0)
                    {

                        var filename = item.FileName.Replace("\"", string.Empty);
                        var NewfileName = "";
                        var filenameadnex = "";
                        if (filename.Contains('.'))
                        {
                            var arrExtentions = filename.Split('.');
                            var lenExtention = arrExtentions.Length;
                            var extention = arrExtentions[lenExtention - 1];
                            filenameadnex = DateTime.Now.Ticks.ToString() + "." + extention;
                            NewfileName = "UploadedFiles/" + filenameadnex;
                        }
                        using (var stream = new FileStream(_environment.WebRootPath + "/" + NewfileName, FileMode.Create))
                        {
                            await item.CopyToAsync(stream);
                            list.Add(new LegalDocument { Path = filenameadnex });

                            //obj.UploadeFile = filenameadnex;
                        }

                    }
                }
               
                    var mapper = _mapper.Map<NewSurvey>(obj);
                
                    //mapper.Type = (int)EnumCommon.SurveyType.;
               
                    
                    
                    mapper.Status = 1;
                    mapper.CreateBy = userDetail.Email;
                    mapper.CreatedDate = DateTime.Now;
                    _newSurveyRepository.Add(mapper);
                    _newSurveyRepository.Save();

                    mapper.ListOLegalDocument = list;
                    _newSurveyRepository.AddLegalDocument(mapper.ListOLegalDocument, mapper.Id);
                    _newSurveyRepository.Save();
                    var enumDisplayType = ((EnumCommon.SurveyType)mapper.Type).ToString();

             
                  
                    _ContactUsRepository.AddContactUs(new ContactUs()
                    {
                        Email = emailAddress,
                        Title = "Oman National Hydrographic Office <br>",
                        Message = $" Order Item Name: {enumDisplayType }<br> { $"Your Status is: {statusRequest}" }"
                    });
                    _ContactUsRepository.Save();
               

                    _NotificationRepository.AddNotification(new Notification() { AssignTo = "Admin", isRead = false, CreateDate = DateTime.Now, Status = 0, RefId = mapper.Id, NotificationName = notificationName });
                    _NotificationRepository.Save();
                    return RedirectToAction("Index", "Home");
                
               
          
            }

            return View(obj);
        }
        public User UserDetails(string userLogin)
        {
            User user = _userRepository.GetByUserName(userLogin);
            return user;
        }

    }
}
