using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "EmailReqired")]
        [EmailAddress(ErrorMessage = "Emailerror")]
        public string Email { get; set; }
        [Required(ErrorMessage = "faildreqired")]
        public string Name { get; set; }
        [Required(ErrorMessage = "faildreqired")]
        public List<string> Roles { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "passwordReqired")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }


}
