using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POS.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new POSEntities()) 
            {
                var categories = db.Categories.ToList();

                foreach (var c in categories)
                {
                    Console.WriteLine(c.Name);

                    foreach (var p in c.Products)
                    {
                        Console.WriteLine("\t{0}", p.Name);
                    }
                }
            }


            Console.ReadLine();
        }
    }
}
