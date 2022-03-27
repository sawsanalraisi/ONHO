using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hydro.DAL.Entities
{
  public  class ServiceRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductType { get; set; }
        public int CopyType { get; set; }
        public DateTime Years { get; set; }
        public int Quantity { get; set; }
        public string Postion { get; set; }
        public string  Purpose { get; set; }
        public string Description { get; set; }
        public int DataType { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public bool Isdelete { set; get; } = false;
    }
}
