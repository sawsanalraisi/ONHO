using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.DTO
{
   public class FileFormatDto
    {
        public long Id { get; set; }
        public string FileType { get; set; }
        public bool Isdelete { set; get; } = false;
    }
}
