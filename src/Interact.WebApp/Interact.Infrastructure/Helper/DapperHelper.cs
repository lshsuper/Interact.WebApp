using Interact.Infrastructure.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Infrastructure.Helper
{
    /// <summary>
    /// 数据库帮助类
    /// </summary>
    public class DapperHelper
    {
        private static DapperContext _context;
        private static object _lockDbContext = new object();
        public static DapperContext Instance
        {
            get
            {
                if (_context != null)
                    return _context;
                lock (_lockDbContext)
                {
                    if (_context != null)
                        return _context;

                    _context = new DapperContext();
                }
                return _context;
            }
        }
    }
}
