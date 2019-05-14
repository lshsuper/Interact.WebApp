using Autofac;
using Autofac.Integration.Mvc;
using Interact.Application.Utils;

using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Interact.WebApp.App_Start
{
    public class AutofacConfig
    {
        public  static IContainer _container;
        public static void RegisterIoc()
        {
            //1.构造autofac容器
            var builder = new ContainerBuilder();
            //2.注入controller+过滤器
            var webapp = Assembly.Load("Interact.WebApp");
            builder.RegisterControllers(webapp);
            //builder.RegisterFilterProvider();
            //3.注入respository
            var respository = Assembly.Load("Interact.Respository");
            builder.RegisterTypes(respository.GetTypes().Where(o=>o.Name.EndsWith("Respository")).ToArray()).AsImplementedInterfaces().InstancePerDependency();
            //4.注入service
            var service = Assembly.Load("Interact.Application");
            builder.RegisterTypes(service.GetTypes().Where(o=>o.Name.EndsWith("Service")).ToArray()).AsSelf().InstancePerDependency();
            //5.注入其它
            //builder.RegisterType(typeof(AppUtil)).AsSelf().InstancePerDependency();
            //6.修改mvc默认解析器
             _container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
        }
        
    }
}