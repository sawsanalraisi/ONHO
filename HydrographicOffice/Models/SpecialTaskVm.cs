using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Models
{
    public class SpecialTaskVm
    {
        public long Id { set; get; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { set; get; }

        [Required]
        [Display(Name = "Phone")]
        [MinLength(10)]
        public string Phone { set; get; }

        [Required]
        [Display(Name = "Organization")]
        public string Organization { set; get; }

        [Required]
        [Display(Name = "Types")]
        public int SpecialTaskType { set; get; }

        [Required]
        [Display(Name = "Date")]
        public DateTime SpecialTaskDate { set; get; }

        [Required]
        [Display(Name = "Purpose")]
        public string Purpose { set; get; }

        [Required]
        [Display(Name = "Description")]
        [MaxLength(200, ErrorMessage = "maximum {1} characters allowed")]

        public string Description { set; get; }
        public string DescForOther { get; set; }

        public string UploadFiles { get; set; }

        //public IFormFile File { get; set; }
        public List<IFormFile> Files { get; set; }
        public string key { set; get; }


    }
}
