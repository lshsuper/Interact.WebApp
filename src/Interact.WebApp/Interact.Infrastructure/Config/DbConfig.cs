using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Infrastructure.Config
{
    /// <summary>
    /// 数据库配置
    /// </summary>
    public class DbConfig
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        public static string DbConnStr =>ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
    }
}
