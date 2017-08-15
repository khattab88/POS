using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Web.API.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public string ProductCode { get; set; }
        public string Description { get; set; }
        public double StarRating { get; set; }
        public string ImageUrl { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}