using POS.Data.Infrastructure;
using POS.Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category,int>
    {
    }

    public class CategoryRepository : RepositoryBase<Category,int>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
