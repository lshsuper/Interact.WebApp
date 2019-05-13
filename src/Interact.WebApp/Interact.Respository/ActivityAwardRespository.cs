using Interact.Core.Entity;
using Interact.Core.Enum;
using Interact.Core.IRespository;
using Interact.Infrastructure.Config;
using Interact.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Respository
{
    public class ActivityAwardRespository : IActivityAwardRespository
    {
        public ActivityAward GetActivityAwardByActivityIdAndWinnerLevel(int activityId, int activityAwardId)
        {
            string sql = "select * from ActivityAward where ActivityId=@activityId and AwardActivityId=@activityAwardId";
            return DapperHelper.Instance.QueryFirst<ActivityAward>(DbConfig.DbConnStr,sql,new { activityId, activityAwardId });
        }

        public List<ActivityAward> GetActivityAwardsByActivityId(int activityId)
        {
            string sql = "select * from ActivityAward where ActivityId=@activityId";
            return DapperHelper.Instance.Query<ActivityAward>(DbConfig.DbConnStr,sql,new { activityId });
        }
    }
}
