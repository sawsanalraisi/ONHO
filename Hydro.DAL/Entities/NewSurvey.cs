using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hydro.DAL.Entities
{
   public class NewSurvey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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


        [ForeignKey("FileFormatId")]
        public long FileFormatId { get; set; }
        public FileFormat FileFormat { get; set; }

        
        public List<LegalDocument> ListOLegalDocument { get; set; }




    }
}
