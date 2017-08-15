using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Web.API.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string EmployeeId { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}