using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.DAL.Entities
{
   public class ImageNews
    {
        public long ID { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public long IdNews { get; set; }
        public News News { get; set; }


    }
}
