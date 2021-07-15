using Autofac;
using Autofac.Integration.Wcf;

using System;

using Vueling.Distributed.WebServices.Configuration;
namespace Vueling.Distributed.WebServices
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            IContainer container = AutofacConfiguration.Configure();
            AutofacHostFactory.Container = container;
        }

    }
}