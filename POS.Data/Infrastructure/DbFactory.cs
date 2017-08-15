using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private POSEntities dataContext;

        public POSEntities Init()
        {
            return dataContext ?? (dataContext = new POSEntities());
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }

    }
}
