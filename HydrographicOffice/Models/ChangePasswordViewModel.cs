using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Models
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "FaildReqired")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "FaildReqired")]
        public string NewPassword { get; set; }
    }
}
