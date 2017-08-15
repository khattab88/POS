using POS.Data.Infrastructure;
using POS.Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories
{
    public interface IEmployeeRepository : IRepository<ApplicationUser, string> 
    {
    }

    public class EmployeeRepository : RepositoryBase<ApplicationUser, string>, IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
