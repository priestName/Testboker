using System.Linq;
using Autofac;
using Testboker;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace Testboker.admin
{
    public class AutofacConfig
    {
        public static void RegisterDenpendency()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            var service = Assembly.Load("Testboker.BLL");
            var repositoty = Assembly.Load("Testboker.DAL");

            var iservice = Assembly.Load("Testboker.IBLL");
            var irepositoty = Assembly.Load("Testboker.IDAL");

            builder.RegisterAssemblyTypes(service, iservice).Where(r => r.Name.EndsWith("BLL")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(repositoty, irepositoty).Where(r => r.Name.EndsWith("DAL")).AsImplementedInterfaces();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
