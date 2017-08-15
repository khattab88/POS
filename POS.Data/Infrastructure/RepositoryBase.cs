using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Infrastructure
{
    public class RepositoryBase<T, TId> where T : class
    {
        #region Properties

        private POSEntities dataContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory { get; private set; }

        protected POSEntities DataContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }

        #endregion

        public RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DataContext.Set<T>();
        }

        #region Implementation

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetById(TId id)
        {
            return dbSet.Find(id);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        /// <summary>
        /// Return a paged list of entities
        /// </summary>
        /// <typeparam name="TOrder"></typeparam>
        /// <param name="page">Which page to retrieve</param>
        /// <param name="where">Where clause to apply</param>
        /// <param name="order">Order by to apply</param>
        /// <returns></returns>
        //public virtual IPagedList<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order)
        //{
        //    var results = dbSet.OrderBy(order).Where(where).GetPage(page).ToList();
        //    var total = dbSet.Count(where);
        //    return new StaticPagedList<T>(results, page.PageNumber, page.PageSize, total);
        //}

        #endregion

    }
}
