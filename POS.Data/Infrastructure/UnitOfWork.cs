using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private POSEntities dataContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        protected POSEntities DataContext
        {
            get
            {
                return dataContext ?? (dataContext = dbFactory.Init());
            }
        }

        public void Commit()
        {
            DataContext.Commit();
        }
    }
}
