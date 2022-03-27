using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.DTO
{
   public class NavigationWarningDto
    {
        public long Id { set; get; }
        public string NavWarnDesc { set; get; }
        public string NavFileName { set; get; }
        public string WarnNumber { set; get; }
        public DateTime WaringDate { set; get; }
        public string UploadeFile { get; set; }

        public int Status { set; get; }
        public bool Isdelete { set; get; } = false;
    }
}
