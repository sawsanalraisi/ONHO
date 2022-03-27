using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Models
{
    public class ServiceVm
    {
    
        public long Id { get; set; }
        [Required]
        [Display(Name = "Years")]
        public DateTime Years { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Postion")]
        public string Postion { get; set; }
        [Required]
        [Display(Name = "Purpose")]
        public string Purpose { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public string Region { get; set; }

        public string UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreateAt { get; set; }
        [Display(Name = "Create By")]
        public string CreateBy { get; set; }
        public long CategoryId { get; set; }
        public long FileFormatId { get; set; }
        public int Status { get; set; }

        public FileFormat FileFormat { get; set; }
        public Category Categories { get; set; }



    }
}
