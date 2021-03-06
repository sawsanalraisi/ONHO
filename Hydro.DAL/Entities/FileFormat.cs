using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hydro.DAL.Entities
{
  public  class FileFormat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string FileType { get; set; }
        public bool Isdelete { set; get; } = false;

    }
    public class SuveryFileFormat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string FileType { get; set; }
        public bool Isdelete { set; get; } = false;
    }
}
