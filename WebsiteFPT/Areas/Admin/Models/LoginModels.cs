﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteFPT.Areas.Admin.Models
{
    public class LoginModels
    {
        [Required(ErrorMessage = "Please input your account")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}