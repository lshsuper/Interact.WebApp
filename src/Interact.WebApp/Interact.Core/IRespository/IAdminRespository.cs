using Interact.Core.Entity;
using Interact.Infrastructure.Dapper.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Core.IRespository
{
    public interface IAdminRespository:IRespository<Admin>
    {
        /// <summary>
        /// 根据用户名和密码获取用户信息
        /// </summary>
        /// <param name="login"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        Admin FindByLoginAndPwd(string login,string pwd);
    }
}
