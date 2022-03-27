﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hydro.DAL.Entities
{
   public class User: IdentityUser
    {
        public string FullName { get; set; }
        public string OrgraizationName { get; set; }
        public string Address { get; set; }
        public bool Isdelete { set; get; } = false;


    }
}
