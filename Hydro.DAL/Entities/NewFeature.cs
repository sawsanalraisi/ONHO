using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hydro.DAL.Entities
{
    public class NewFeature
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Organization { set; get; }
        public string Position { set; get; }
        public DateTime NewFeatureDate { set; get; }
        public string Region { set; get; }
        public string Character { set; get; }
        public int Status { set; get; }
        public string Purpose { set; get; }
        public string Description { set; get; }

        public bool Isdelete { set; get; } = false;

        [NotMapped]
        public List<DocumentFile> ListOfFiles { get; set; }
    }
}
