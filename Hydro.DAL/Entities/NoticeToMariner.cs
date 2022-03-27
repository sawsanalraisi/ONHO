using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hydro.DAL.Entities
{
    public class NoticeToMariner
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int NoticeType { get; set; }
        public string NotiecDesc { get; set; }
        public string NoticeFileName { get; set; }
        public DateTime NoticeDate { get; set; }
        public int NoticeEdition { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public string UploadeFile { get; set; }

        public bool Isdelete { set; get; } = false;

    }
}
