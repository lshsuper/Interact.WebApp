using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interact.Core.Entity;
using Interact.Core.IRespository;
using Interact.Infrastructure.Config;
using Interact.Infrastructure.Dapper.Respository;
using Interact.Infrastructure.Helper;

namespace Interact.Respository
{
    /// <summary>
    /// 管理账户
    /// </summary>
    public class AdminRespository : Respository<Admin>, IAdminRespository
    {
        public Admin FindByLoginAndPwd(string login, string pwd)
        {
            string sql = "select * from Admin where Login=@login and Pwd=@pwd";
            return DapperHelper.Instance.QueryFirst<Admin>(DbConfig.DbConnStr,sql,new { login=login,pwd=pwd});
        }
    }
}
