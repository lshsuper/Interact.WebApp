﻿using Interact.Core.Entity;
using Interact.Core.Enum;
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
                                        ActivityAwardId)values(
                                        @Id,
                                        @SiginInRecoredId,
                                        @ActivityId,
                                        @CreateTime,
                                        @ActivityAwardId)";
            return DapperHelper.Instance.Excute(DbConfig.DbConnStr,sql,lst);
        }
       
        public bool RemoveAllByActivity(int activityId)
        {
            string sql = $"delete from WinnerMenu where ActivityId=@activityId";
            return DapperHelper.Instance.Excute(DbConfig.DbConnStr,sql,new {activityId});
        }
    }
}
