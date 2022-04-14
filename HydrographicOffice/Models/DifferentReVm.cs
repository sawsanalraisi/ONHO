using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Models
{
    public class DifferentReVm
    {
        public long Id { set; get; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { set; get; }

        [Required]
        [Display(Name = "Phone")]
        [MinLength(10)]
        public string Phone { set; get; }

        [Required]
        [Display(Name = "Organization")]
        public string Organization { set; get; }

        [Required]
        [Display(Name = "Report Type")]
        public int ReportType { set; get; }

        [Required]
        [Display(Name = "Position")]
        public string Position { set; get; }

        [Required]
        [Display(Name = "Date")]
        public DateTime DifferentRepDate { set; get; }

        [Required]
        [Display(Name = "Region")]
        public string Region { set; get; }

        [Required]
        [Display(Name = "Character")]
        public string Character { set; get; }

        [Required]
        [Display(Name = "Purpose")]
        public string Purpose { set; get; }

        [Required]
        [Display(Name = "Description")]
        [MaxLength(200, ErrorMessage = "maximum {1} characters allowed")]
        public string Description { set; get; }

        public List<IFormFile>Files { get; set; }

    }
}
