using Interact.Core.Entity;
using Interact.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Core.IRespository
{
    public interface IActivityAwardRespository
    {
        /// <summary>
        /// 获取指定活动的奖励
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        List<ActivityAward> GetActivityAwardsByActivityId(int activityId);
        /// <summary>
        /// 根据奖品等级与活动id获取奖品
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="activityAwardId"></param>
        /// <returns></returns>
        ActivityAward GetActivityAwardByActivityIdAndWinnerLevel(int activityId, int activityAwardId);

       
    }
}
