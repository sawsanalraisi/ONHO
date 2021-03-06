using AutoMapper;
using Hydro.BAL.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;
        public RequestController(IRequestRepository requestRepository,IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
