using POS.Data.Infrastructure;
using POS.Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories
{
    public interface ICustomerRepository : IRepository<Customer, int> 
    {
    }

    public class CustomerRepository : RepositoryBase<Customer,int>, ICustomerRepository
    {
        public CustomerRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
