using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.DAL.Entities
{
    public class News
    {
        public long Id { get; set; }
        public string TitleArbic { get; set; }
        public string TitleEnglish { get; set; }
        public string DescArbic { get; set; }
        public string DescEnglish { get; set; }
        public DateTime DateCreated { get; set; }
        public string  CreateBy { get; set; }   
        public DateTime CreateAt { get; set; }
        public string CoverImage { get; set; }

        public ICollection<ImageNews> ImageNews { get; set; }
        = new List<ImageNews>();

    }
}
