using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.DTO
{
    public class SpecialTaskDto
    {
        public long Id { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Organization { set; get; }
        public int SpecialTaskType { set; get; }
        public DateTime SpecialTaskDate { set; get; }
        public string Purpose { set; get; }
        public string Description { set; get; }
        public bool Isdelete { set; get; } = false;
        public string DescForOther { get; set; }
        public int Status { get; set; }

        public List<DocumentFile> ListOfFiles { get; set; }
    }
}
