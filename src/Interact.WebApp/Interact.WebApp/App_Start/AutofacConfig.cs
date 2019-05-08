using Autofac;
using Autofac.Integration.Mvc;
using Interact.Application.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Interact.WebApp.App_Start
{
    public class AutofacConfig
    {
       
        public static void RegisterIoc()
        {
            //1.构造autofac容器
            var builder = new ContainerBuilder();
            //2.
            var controller = Assembly.Load("Interact.WebApp");
            builder.RegisterControllers(controller);
            //3.注入respository
            var respository = Assembly.Load("Interact.Respository");
            builder.RegisterTypes(respository.GetTypes().Where(o=>o.Name.EndsWith("Respository")).ToArray()).AsImplementedInterfaces().InstancePerDependency();
            //4.注入service
            var service = Assembly.Load("Interact.Application");
            builder.RegisterTypes(service.GetTypes().Where(o=>o.Name.EndsWith("Service")).ToArray()).AsSelf().InstancePerDependency();
            //5.注入其它
            //6.修改mvc默认解析器
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
        
    }
}