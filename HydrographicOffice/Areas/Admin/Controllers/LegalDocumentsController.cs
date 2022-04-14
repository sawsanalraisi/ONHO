using AutoMapper;
using Hydro.BAL.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Controllers
{
    [Area("Admin")]

    public class LegalDocumentsController : Controller
    {
        private readonly ILegalDocumentRepository _legalDocumentRepository;
        private readonly IMapper _mapper;
        public LegalDocumentsController(ILegalDocumentRepository legalDocumentRepository,IMapper mapper)
        {
            _legalDocumentRepository = legalDocumentRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
