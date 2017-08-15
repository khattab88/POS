using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Model.Models
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public string EmployeeId { get; set; }
        public virtual ApplicationUser Employee { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }

        public Order()
        {
            Items = new HashSet<OrderItem>();
        }
    }
}
