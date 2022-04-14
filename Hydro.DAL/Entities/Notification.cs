using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.DAL.Entities
{
   public class Notification
    {
        public long Id { get; set; }

        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public bool isRead { get; set; }
        public string AssignTo { get; set; }
        public int Status { get; set; }

        public long RefId { get; set; }

        public int Type { get; set; }
        public string NotificationName { get; set; }
    }
}
