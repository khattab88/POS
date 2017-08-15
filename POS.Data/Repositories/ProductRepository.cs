using POS.Data.Infrastructure;
using POS.Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories
{
    public interface IProductRepository : IRepository<Product, int> 
    {
    }

    public class ProductRepository : RepositoryBase<Product,int>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
