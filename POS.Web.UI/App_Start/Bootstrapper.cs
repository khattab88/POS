using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Integration.Mvc;
using POS.Data.Infrastructure;
using System.Reflection;
using POS.Data.Repositories;
using POS.Domain.Services;
using Microsoft.AspNet.Identity;
using POS.Domain.Model.Models;
using POS.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using POS.Web.UI.Mappings;
using POS.Application;
using POS.Infrastructure.Timing;

namespace POS.Web.UI.App_Start
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();

            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(EmployeeRepository).Assembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerRequest();

            // Domain Services
            builder.RegisterAssemblyTypes(typeof(EmployeeService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            // Infrastructure Services
            builder.RegisterAssemblyTypes(typeof(DateTimeService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            // App Controllers
            builder.RegisterAssemblyTypes(typeof(OrderingAppController).Assembly)
                .Where(t => t.Name.EndsWith("AppController"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Authentication
            //   builder.RegisterAssemblyTypes(typeof(DefaultFormsAuthentication).Assembly)
            //.Where(t => t.Name.EndsWith("Authentication"))
            //.AsImplementedInterfaces().InstancePerHttpRequest();

            builder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new POSEntities())))
                .As<UserManager<ApplicationUser>>().InstancePerRequest();


            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));            

        }
    }
}