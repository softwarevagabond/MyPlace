﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPlace.Web.Models
{
    public class AccountLoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}