using AutoMapper;
using Interact.Application.Dto;
using Interact.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Application.Config
{
   public class AdminConfig:Profile
    {
          public AdminConfig()
        {
            CreateMap<Admin, AdminDto>();
        }
    }
}
