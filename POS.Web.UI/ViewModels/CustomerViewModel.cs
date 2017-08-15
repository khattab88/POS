using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Web.UI.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName 
        { 
            get 
            {
                return string.Format("{0} {1}", FirstName ,LastName);
            } 
        }
    }
}