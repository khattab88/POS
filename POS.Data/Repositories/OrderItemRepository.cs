using POS.Data.Infrastructure;
using POS.Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories
{
    public interface IOrderItemRepository : IRepository<OrderItem, int> 
    {
    }

    public class OrderItemRepository : RepositoryBase<OrderItem,int>, IOrderItemRepository
    {
        public OrderItemRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
