using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Models
{
    public class CategoryVm
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Service Type")]
        public int EnumServiceType { get; set; }
        public string ItemName { get; set; }



    }
}
