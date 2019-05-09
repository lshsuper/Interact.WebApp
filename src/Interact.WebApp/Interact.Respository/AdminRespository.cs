using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interact.Core.Entity;
using Interact.Core.IRespository;
using Interact.Infrastructure.Dapper.Respository;

namespace Interact.Respository
{
    /// <summary>
    /// 管理账户
    /// </summary>
   public class AdminRespository:Respository<Admin>,IAdminRespository
    {


    }
}
