using Interact.Core.Entity;
using Interact.Core.Option;
using Interact.Infrastructure.Dapper.Respository;
using Interact.Infrastructure.Helper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Core.IRespository
{
    public interface IActivityRespository:IRespository<Activity>
    {
        /// <summary>
        /// 编辑活动
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="activityAwards"></param>
        /// <returns></returns>
        bool EditActivity(Activity activity, List<ActivityAward> activityAwards);

        /// <summary>
        /// 添加活动
        /// </summary>
        /// <returns></returns>
        bool AddActivity(Activity activity, List<ActivityAward> activityAwards);
     
        /// <summary>
        /// 活动分页列表数据
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        PageInfo<List<Activity>> QueryActivityByPage(ActivityPageOption option);
        /// <summary>
        /// 根据活动id+授权码获取活动信息
        /// </summary>
        /// <param name="authCode"></param>
        /// <param name="activityId"></param>
        /// <returns></returns>
        Activity GetActivityByAuthCodeAndActivityId(string authCode,int activityId);
    }
}
