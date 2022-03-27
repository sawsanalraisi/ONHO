using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hydro.DAL.Entities
{
   public class EmailConfigur
    {
        [Key]
        public int Id { get; set; }
        public string SmtpClient { get; set; }
        public string NetworkCredential { get; set; }
        public int Port { get; set; }
        public string Passowrd { get; set; }
    }
}
