using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Models
{
    public class RequestServiceVm
    {

        public long ld { get; set; }

     

        [Required]
        [Display(Name = "Request Type")]
        public int RequestType { get; set; }

        public int States { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }

    }
}
