using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
namespace Interact.Test
{
    /// <summary>
    /// 测试基类（所有测试集成它，便可完成依赖注入）
    /// </summary>
   public class BaseTest
    {
        protected IContainer _container;
        public BaseTest()
        {
            var builder = new ContainerBuilder();
            //3.注入respository
            var respository = Assembly.Load("Interact.Respository");
            builder.RegisterTypes(respository.GetTypes().Where(o => o.Name.EndsWith("Respository")).ToArray()).AsImplementedInterfaces().InstancePerDependency();
            //4.注入service
            var service = Assembly.Load("Interact.Application");
            builder.RegisterTypes(service.GetTypes().Where(o => o.Name.EndsWith("Service")).ToArray()).AsSelf().InstancePerDependency();
            _container = builder.Build();
        }
    }
}
