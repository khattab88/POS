using POS.Data;
using POS.Web.API.App_Start;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace POS.Web.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new POSSeedData());

            GlobalConfiguration.Configure(WebApiConfig.Register);

            Bootstrapper.Run();
        }
    }
}
