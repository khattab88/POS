namespace POS.Data.Migrations
{
    using POS.Domain.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<POS.Data.POSEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "POS.Data.POSEntities";
        }

        protected override void Seed(POS.Data.POSEntities database)
        {
            //  This method will be called after migrating to the latest version.

            //database.Products.AddOrUpdate(
            //    p => p.Id,
            //    GetProducts().ToArray());           
        }

        static List<Product> GetProducts()
        {
            return new List<Product>() 
            {
                new Product()
                { 
                    Name = "IPhone 6",
                    Price = 8000,
                    Code = "Apple-6-plus",
                    Description = "Apple iPhone 6 Plus",
                    ReleaseDate = new DateTime(2016, 9, 1),
                    Rating = 4.8,
                    ImageUrl = "http://cdn2.gsmarena.com/vv/pics/apple/apple-iphone-6-plus-1.jpg"
                },
                new Product()
                { 
                    Name = "Sony Xperia",
                    Price = 6000,
                    Code = "Sony-X-z3",
                    Description = "Sony Xperia Z3",
                    ReleaseDate = new DateTime(2014, 10, 1),
                    Rating = 4.1,
                    ImageUrl = "http://cdn2.gsmarena.com/vv/pics/sony/sony-xperia-z3-01.jpg"
                },
                new Product()
                { 
                    Name = "Samsung Galaxy",
                    Price = 4000,
                    Code = "Samsung-G-s6",
                    Description = "Samsung Galaxy S6",
                    ReleaseDate = new DateTime(2015, 4, 1),
                    Rating = 3.8,
                    ImageUrl = "http://cdn2.gsmarena.com/vv/pics/samsung/samsung-galaxy-s6-1.jpg"
                },
                new Product()
                { 
                    Name = "LG G4",
                    Price = 3500,
                    Code = "LG-G4",
                    Description = "LG G4",
                    ReleaseDate = new DateTime(2013, 12, 1),
                    Rating = 3.9,
                    ImageUrl = "http://cdn2.gsmarena.com/vv/pics/lg/lg-g4-1.jpg"
                },
                new Product()
                { 
                    Name = "Huawei Nexus",
                    Price = 5500,
                    Code = "Huawei-N-6p",
                    Description = "Huawei Nexus 6P",
                    ReleaseDate = new DateTime(2014, 11, 1),
                    Rating = 4.1,
                    ImageUrl = "http://cdn2.gsmarena.com/vv/pics/huawei/huawei-nexus-6p-1.jpg"
                },
                new Product()
                { 
                    Name = "HTC 10",
                    Price = 6500,
                    Code = "HTC 10",
                    Description = "HTC 10",
                    ReleaseDate = new DateTime(2016, 1, 1),
                    Rating = 4.3,
                    ImageUrl = "http://cdn2.gsmarena.com/vv/pics/htc/htc-10-5.jpg"
                },
            };
        }
    }
}
