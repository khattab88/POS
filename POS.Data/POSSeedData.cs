using POS.Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public class POSSeedData : DropCreateDatabaseIfModelChanges<POSEntities>
    {
        protected override void Seed(POSEntities database)
        {
            //base.Seed(database);

            //database.Customers.Add(new Customer() 
            //{
            //    FirstName = "Ali",
            //    LastName = "Omar",
            //});

            //database.Products.AddRange(GetProducts());

            //database.Commit();
        }

        static List<Product> GetProducts() 
        {
            return new List<Product>() 
            {
                new Product()
                { 
                    Name = "IPhone",
                    Price = 8000,
                    Code = "Apple",
                    Description = "Apple IPhone 6",
                    ReleaseDate = new DateTime(2105, 4, 5),
                    Rating = 4.5,
                    ImageUrl = "kdkdkdkdk"
                },
                new Product()
                { 
                    Name = "Sony",
                    Price = 6000,
                    Code = "Apple",
                    Description = "Sony Xperia X",
                    ReleaseDate = new DateTime(2105, 4, 5),
                    Rating = 4.1,
                    ImageUrl = "kdkdkdkdk"
                },
                new Product()
                { 
                    Name = "Samsung",
                    Price = 4000,
                    Code = "Apple",
                    Description = "Samsung Galaxy y",
                    ReleaseDate = new DateTime(2105, 4, 5),
                    Rating = 4.5,
                    ImageUrl = "kdkdkdkdk"
                },
            };
        }
    }
}
