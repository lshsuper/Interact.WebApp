using Interact.Core.Entity;
using Interact.Core.IRespository;
using Interact.Infrastructure.Config;
using Interact.Infrastructure.Dapper.Respository;
using Interact.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Respository
{
    public class WinnerMenuRespository : Respository<WinnerMenu>, IWinnerMenuRespository
    {
        public bool Add(List<WinnerMenu> lst)
        {
            string sql = $@"insert into WinnerMenu(
                                        Id,
                                        SiginInRecoredId,
                                        ActivityId,
                                        CreateTime,
                                        WinnerLevel)values(
                                        @Id,
                                        @SiginInRecoredId,
                                        @ActivityId,
                                        @CreateTime,
                                        @WinnerLevel)";
            return DapperHelper.Instance.Excute(DbConfig.DbConnStr,sql,lst);
        }
    }
}
