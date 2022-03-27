using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.DAL.Entities
{
    public class BeforProces
    {
        public long Id { get; set; }
        public string TrackId { get; set; }
        public long OperationId { get; set; }
        public int Type { get; set; }
        public long OrderId { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }

    }
}
