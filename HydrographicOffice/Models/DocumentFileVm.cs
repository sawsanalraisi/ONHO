using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Models
{
    public class DocumentFileVm
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int ParentId { get; set; }
        public int Path { get; set; }
    }
}
