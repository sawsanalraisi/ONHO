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
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Email Error")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Faild Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Faild Required")]
        public List<string> Roles { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "passwordReqired")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }


}
