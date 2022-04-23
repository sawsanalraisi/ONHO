using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hydro.BAL.DTO
{
   public class OmanbookDto
    {

        public long Id { get; set; }
        public int Year { get; set; }
        public string UploadeFile { get; set; }

        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }


       
    }
}
