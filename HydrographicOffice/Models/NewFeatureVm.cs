using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Models
{
    public class NewFeatureVm
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
        [Display(Name = "Position")]
        public string Position { set; get; }

        [Required]
        [Display(Name = "Date")]
        public DateTime NewFeatureDate { set; get; }

        [Required]
        [Display(Name = "Region")]
        public string Region { set; get; }

        [Required]
        [Display(Name = "Character")]
        public string Character { set; get; }

        [Required]
        [Display(Name = "status")]
        public int Status { set; get; }

        [Required]
        [Display(Name = "Purpose")]
        public string Purpose { set; get; }

        [Required]
        [Display(Name = "Description")]
        public string Description { set; get; }

        public bool Isdelete { set; get; } = false;
        public List<IFormFile> Files { get; set; }

    }
}
