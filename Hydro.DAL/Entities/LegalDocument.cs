using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hydro.DAL.Entities
{
   public class LegalDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string LegalDocumentsType { get; set; }
        public string Path { get; set; }
        public bool Isdelete { set; get; } = false;

        [ForeignKey("NewSurveyId")]
        public long NewSurveyId { get; set; }
        public NewSurvey NewSurvey { get; set; }

    }
}
