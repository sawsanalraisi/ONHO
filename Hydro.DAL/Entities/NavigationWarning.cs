using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hydro.DAL.Entities
{
    public class NavigationWarning
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }
        public string NavWarnDesc { set; get; }
        public string NavFileName { set; get; }
        public string WarnNumber { set; get; }
        public DateTime WaringDate { set; get; }

        public int Status { set; get; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public string UploadeFile { get; set; }
        public bool Isdelete { set; get; } = false;

    }
}
