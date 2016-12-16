using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Iskatel.DataAccess.ArangoServices;
using Iskatel.DataAccess.SQLServices;
using Iskatel.DataAccess.Intefaces;
using System.Web.Mvc;
using System.Web.Http;

namespace Iskatel.Web
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterType<MainService>().As<IMainService>();
            builder.RegisterType<ClassService>().As<IClassService>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}