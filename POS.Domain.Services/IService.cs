using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Services
{
    public interface IService<T,TId>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Where(Expression<Func<T, bool>> where);
        T GetById(TId id);
        T Get(Expression<Func<T, bool>> where);
        void Create(T entity);
        void Update(T entity);
        void Delete(TId id);
        void Save();
    }
}
