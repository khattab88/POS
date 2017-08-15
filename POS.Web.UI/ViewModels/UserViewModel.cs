﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Web.UI.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}