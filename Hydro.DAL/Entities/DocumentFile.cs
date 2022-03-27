using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hydro.DAL.Entities
{
 public   class DocumentFile
    {
      
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public long Id { get; set; }
            public int Type { get; set; }
            public long ParentId { get; set; }
            public string Path { get; set; }
        }
    
}
