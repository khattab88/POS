using POS.Data.Infrastructure;
using POS.Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order, int> 
    {
    }

    public class OrderRepository : RepositoryBase<Order,int>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
