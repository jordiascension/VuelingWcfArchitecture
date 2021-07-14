
using Autofac;
using Autofac.Core;

namespace Vueling.Infrastructure.Repository.Integration.Tests.Implementations
{
    public class IoCSupportedTest<TModule> where TModule :
        IModule, new()
    {
        private readonly IContainer container;

        public IoCSupportedTest()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new TModule());

            container = builder.Build();
        }

        protected TEntity Resolve<TEntity>()
        {
            return container.Resolve<TEntity>();
        }

        protected void ShutdownIoC()
        {
            container.Dispose();
        }
    }
}
