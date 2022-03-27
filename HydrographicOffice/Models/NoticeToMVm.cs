using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Models
{
    public class NoticeToMVm
    {
      
        public long Id { get; set; }

        [Required]
        [Display(Name = "Notice Type")]
        public int NoticeType { get; set; }

        [Required]
        [Display(Name = "Notiec Description")]
        public string NotiecDesc { get; set; }

        [Required]
        [Display(Name = "Notice File Name")]
        public string NoticeFileName { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime NoticeDate { get; set; }

        [Required]
        [Display(Name = "Notice Edition")]
        public int NoticeEdition { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public string UploadeFile { get; set; }
        public bool Isdelete { set; get; } = false;

        public IFormFile File { get; set; }
    }
}
