using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Web.UI.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public OrderViewModel Order { get; set; }

        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
    }
}