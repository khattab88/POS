﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Model.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName 
        {
            get { return FirstName + " " + LastName; }
        }

        //public string Email { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }
    }
}
