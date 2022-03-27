using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.DTO
{
   public class NewSurveyDto
    {
        public long Id { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public string Position { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Purpose { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreateBy { get; set; }
        public bool Isdelete { set; get; } = false;

        public long FileFormatId { get; set; }
        public FileFormat FileFormat { get; set; }

        public LegalDocument ListOLegalDocuments { get; set; }
        public List<LegalDocument> ListOLegalDocument { get; set; }

        public ICollection<LegalDocument> ListOLegalDocumentss { get; set; } = new List<LegalDocument>();
    }
}
