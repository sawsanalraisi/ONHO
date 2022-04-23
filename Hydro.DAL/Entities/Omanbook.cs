using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hydro.DAL.Entities
{
    public class Omanbook
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int Year { get; set; }
        public string UploadeFile { get; set; }
        public bool Isdelete { set; get; } = false;

        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }


    }
}
