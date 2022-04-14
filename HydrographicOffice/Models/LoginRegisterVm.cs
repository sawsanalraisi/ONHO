using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Models
{
    public class LoginRegisterVm
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "EmailRequired")]
        [EmailAddress(ErrorMessage = "Emaile Error")]
        public string Email { get; set; }
       
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
        [Required]
        [Display(Name ="User Name Should Be Your Email Address")]
        public string UserName { get; set; }
        [MinLength(20)]
        [Display(Name = "FullName Please")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Your Occupation")]

        public string OrgraizationName { get; set; }
        [Required]
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
