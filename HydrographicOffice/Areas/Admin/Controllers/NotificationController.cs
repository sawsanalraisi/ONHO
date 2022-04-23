using AutoMapper;
using Hydro.BAL.DTO;
using Hydro.BAL.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NotificationController : Controller
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        public NotificationController(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var list = _notificationRepository.GetLatestNotification("Admin");
            var MappedList = _mapper.Map<List<NotificationDTO>>(list);
            return View(MappedList);
        }
    }
}
