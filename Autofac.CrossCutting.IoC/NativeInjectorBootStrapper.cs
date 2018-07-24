using Application.Services;
using Infrastructure;
using Infrastructure.Factorys;
using Infrastructure.Repositorys;
using Infrastructure.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autofac.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {

        public static IContainer Registers()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();
            builder.RegisterType<DatabaseContextFactory>().As<IDatabaseContextFactory>().InstancePerLifetimeScope();
            builder.RegisterType<DatabaseContext>().As<IDatabaseContext>().InstancePerLifetimeScope();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(CustomerRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            // Services
            builder.RegisterAssemblyTypes(typeof(CustomerService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerLifetimeScope();

            return builder.Build();
        }

    }
}
