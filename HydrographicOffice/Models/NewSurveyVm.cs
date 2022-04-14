using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Models
{
    public class NewSurveyVm
    {

        public long Id { get; set; }

        [Display(Name = "Survey Type")]
        public int Type { get; set; }
        public int Status { get; set; }

        [Required]
        [Display(Name = "Position")]
        public string Position { get; set; }

        public long FileFormatId { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Description")]
        [MaxLength(200, ErrorMessage = "maximum {1} characters allowed")]

        public string Description { get; set; }

        [Required]
        [Display(Name = "Purpose")]
        public string Purpose { get; set; }

        
        public DateTime CreatedDate { get; set; }


        public string CreateBy { get; set; }

        public string UploadFiles { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
