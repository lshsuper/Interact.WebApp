using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Interact.WebApp.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterProfile()
        {
            var mappers = Assembly.Load("Interact.Application").GetTypes().Where(o => o.Name.EndsWith("Config")).ToList();
            Mapper.Initialize(cfg =>
            {
                mappers.ForEach(o =>
                {
                    cfg.AddProfile(o);
                });

            });
        }
    }
}