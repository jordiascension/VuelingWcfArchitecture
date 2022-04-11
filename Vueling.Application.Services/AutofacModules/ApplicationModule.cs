using Autofac;
using Autofac.log4net;

using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository;
using Vueling.Infrastructure.Repository.Contracts;

namespace Vueling.Application.Services.AutofacModules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<StudentRepository>()
                .As<IStudentRepository<Student>>().InstancePerDependency();
            
            builder.RegisterModule<Log4NetModule>();

            base.Load(builder);
        }
    }
}
