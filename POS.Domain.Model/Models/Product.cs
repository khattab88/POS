using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Model.Models
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        public string ImageUrl { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }
    }
}
