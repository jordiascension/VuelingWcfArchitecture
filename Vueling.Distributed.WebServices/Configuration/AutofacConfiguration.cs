using Autofac;
using Autofac.log4net;

using Vueling.Application.Services;
using Vueling.Application.Services.AutofacModules;
using Vueling.Application.Services.Contracts;
using Vueling.Distributed.WebServices.Contracts;
using Vueling.Domain.Entities;

namespace Vueling.Distributed.WebServices.Configuration
{
    public static class AutofacConfiguration
    {

        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new ApplicationModule());
            builder.RegisterModule<Log4NetModule>();
            // register types
            builder.RegisterType<StudentWebService>().As<IStudentWebService>().InstancePerDependency();
            builder.RegisterType<StudentAppService>().As<IStudentAppService<Student>>().InstancePerDependency();

            // build container
            return builder.Build();
        }
    }
}