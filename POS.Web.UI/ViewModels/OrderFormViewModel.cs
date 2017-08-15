using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Web.UI.ViewModels
{
    public class OrderFormViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string EmployeeId { get; set; }
        public IEnumerable<OrderItemViewModel> Items { get; set; }

        public IEnumerable<CustomerViewModel> CustomerList { get; set; }
        public IEnumerable<ProductViewModel> ProductList { get; set; }
    }
}