using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Web.UI.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public EmployeeViewModel Employee { get; set; }
        public CustomerViewModel Customer { get; set; }

        public List<OrderItemViewModel> Items { get; set; }
    }
}