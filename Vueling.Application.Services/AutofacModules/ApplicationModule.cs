using Autofac;
using Autofac.log4net;

using System;

using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository;
using Vueling.Infrastructure.Repository.Contracts;
using Vueling.Infrastructure.Repository.Implementations;

namespace Vueling.Application.Services.AutofacModules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<StudentRepository>()
                .As<IStudentRepository<Student>>().InstancePerDependency();


            builder.RegisterType<SqlStudentRepository>()
                 .As<IRepository>().Keyed<IRepository>(DatabaseEnum.Sql);

            builder.RegisterType<StudentRepository>()
                .As<IRepository>().Keyed<IRepository>(DatabaseEnum.StoredProcedure);

            builder.Register<Func<DatabaseEnum, IRepository>>(c =>
            {
                var componentContext = c.Resolve<IComponentContext>();
                return (databaseEnum) =>
                {
                    var dataService = componentContext.ResolveKeyed<IRepository>(databaseEnum);
                    return dataService;
                };
            });

            builder.RegisterModule<Log4NetModule>();

            base.Load(builder);
        }
    }
}
