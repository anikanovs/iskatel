using Autofac;
using Autofac.Integration.Mvc;
using Iskatel.DataAccess.ArangoServices;
using Iskatel.DataAccess.Intefaces;
using System.Web.Mvc;

namespace Iskatel.Web
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<MainService>().As<IMainService>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}