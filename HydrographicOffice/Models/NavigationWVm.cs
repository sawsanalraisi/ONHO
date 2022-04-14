using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Models
{
    public class NavigationWVm
    {
        public long Id { set; get; }

        [Required]
        [Display(Name = "Navigational Warning Description")]
        [MaxLength(200, ErrorMessage = "maximum {1} characters allowed")]
        public string NavWarnDesc { set; get; }

        [Required]
        [Display(Name = "Navigational File Name")]
        public string NavFileName { set; get; }

        [Required]
        [Display(Name = "Warning Number")]
        public string WarnNumber { set; get; }

        [Required]
        [Display(Name = "Date")]
        public DateTime WaringDate { set; get; }

        [Required]
        [Display(Name = "Status")]
        public int Status { set; get; }

        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public string UploadeFile { get; set; }
        public IFormFile File { get; set; }

    }
}
