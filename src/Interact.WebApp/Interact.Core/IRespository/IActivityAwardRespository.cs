using Interact.Core.Entity;
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

       
    }
}
