using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Web.API.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}