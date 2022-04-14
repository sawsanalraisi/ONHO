using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Hydro.BAL.DTO
{
    public class NotificationDTO
    {
        public long Id { get; set; }

        public DateTime CreateDate { get; set; }
        [JsonIgnore]
        public string CreateBy { get; set; }
        [JsonIgnore]
        public bool isRead { get; set; }
        public string AssignTo { get; set; }
        public int status { get; set; }

    }
}
