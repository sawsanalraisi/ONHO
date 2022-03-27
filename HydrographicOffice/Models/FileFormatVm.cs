using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Models
{
    public class FileFormatVm
    {

        public long ld { get; set; }

        [Required]
        [Display(Name = "File Type")]
        public string Type { get; set; }
        public bool Isdelete { set; get; } = false;

    }
}
