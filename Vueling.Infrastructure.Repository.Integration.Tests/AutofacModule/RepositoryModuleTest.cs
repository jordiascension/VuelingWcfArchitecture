using Autofac;

using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository.Contracts;

namespace Vueling.Infrastructure.Repository.Integration.Tests.AutofacModule
{
    public class RepositoryModuleTest : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<StudentRepository>()
                .As<IStudentRepository<Student>>();


            base.Load(builder);
        }
    }
}
