using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Models
{
    public class OmanbookMVm
    {

        public long Id { get; set; }

        [Required]
        [Display(Name = "Year")]
        public int Year { get; set; }
        public string UploadeFile { get; set; }
        public bool Isdelete { set; get; } = false;
        public IFormFile File { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }

    }
}
