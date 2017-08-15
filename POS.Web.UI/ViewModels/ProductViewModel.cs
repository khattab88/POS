using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POS.Domain.Model.Models;
using System.ComponentModel.DataAnnotations;

namespace POS.Web.UI.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Code { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name="Category")]
        public int CategoryId { get; set; }
    }
}