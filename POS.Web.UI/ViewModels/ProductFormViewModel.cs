using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POS.Domain.Model.Models;

namespace POS.Web.UI.ViewModels
{
    public class ProductFormViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public ProductViewModel Product { get; set; }
    }
}