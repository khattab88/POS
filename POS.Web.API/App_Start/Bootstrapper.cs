using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using POS.Data.Infrastructure;
using POS.Data.Repositories;
using POS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using POS.Web.API.Mappings;

namespace POS.Web.API.App_Start
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            //Configure AutoFac  
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);  

            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }

    }
}