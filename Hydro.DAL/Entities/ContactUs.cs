using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hydro.DAL.Entities
{
  public  class ContactUs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public DateTime CreatdDate { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelated { get; set; } = false;
    }
}
