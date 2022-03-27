using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hydro.DAL.Entities
{
   public class Order
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
        public int PaymentStatus { get; set; }
        public string  TrackId { get; set; }
        public long OperationId { get; set; }
        public int Type { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
