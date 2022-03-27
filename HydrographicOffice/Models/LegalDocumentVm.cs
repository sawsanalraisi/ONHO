using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Models
{
    public class LegalDocumentVm
    {
        public long Id { get; set; }
        public string LegalDocumentsType { get; set; }
        public string Path { get; set; }
        public bool Isdelete { set; get; } = false;

        public long NewSurveyId { get; set; }
        public NewSurvey NewSurvey { get; set; }


    }
}
