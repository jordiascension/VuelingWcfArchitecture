using Autofac;

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

            base.Load(builder);
        }
    }
}
