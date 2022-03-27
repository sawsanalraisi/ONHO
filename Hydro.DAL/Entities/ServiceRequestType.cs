using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hydro.DAL.Entities
{
   public  class ServiceRequestType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int Status { get; set; }
        public DateTime Years { get; set; }
        public int Quantity { get; set; }
        public string Postion { get; set; }
        public string Purpose { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool Isdelete { set; get; } = false;
        public string Region { get; set; }

        [ForeignKey("CategoryId")]
        public long CategoryId { get; set; }
        public Category Categories { get; set; }

        [ForeignKey("FileFormatId")]
        public long FileFormatId { get; set; }
        public FileFormat FileFormat { get; set; }
    }
}
