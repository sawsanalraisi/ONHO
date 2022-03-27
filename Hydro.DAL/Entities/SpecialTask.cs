using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hydro.DAL.Entities
{
   public class SpecialTask
    { 

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

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
        [NotMapped]
        public List<DocumentFile> ListOfFiles { get; set; }
    }
}
