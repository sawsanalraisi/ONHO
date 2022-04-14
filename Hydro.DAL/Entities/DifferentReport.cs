using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hydro.DAL.Entities
{
    public class DifferentReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }

  
        public string Email { set; get; }

        public string Phone { set; get; }

      
        public string Organization { set; get; }

        [Required]
        [Display(Name = "Report Type")]
        public int ReportType { set; get; }

        public string Position { set; get; }

    
        public DateTime DifferentRepDate { set; get; }

        public string Region { set; get; }


        public string Character { set; get; }

        public string Purpose { set; get; }

        public string Description { set; get; }
        public bool Isdelete { set; get; } = false;
        public string UploadFiles { get; set; }
        public int Status { get; set; }

        [NotMapped]
        public List<DocumentFile> ListOfFiles { get; set; }
    }
}
