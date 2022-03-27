using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.DTO
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string OrgraizationName { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool Isdelete { set; get; } = false;

    }
}
