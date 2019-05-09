using Interact.Core.Entity;
using Interact.Infrastructure.Dapper.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Core.IRespository
{
   public interface ISigInRecordRespository:IRespository<SignInRecord>
    {
        /// <summary>
        /// 校验签到记录
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="activityId"></param>
        /// <returns></returns>
        bool CheckSignIn(string openId,int activityId);
        /// <summary>
        /// 签到
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        bool SignIn(SignInRecord record);
        /// <summary>
        /// 获取当前活动下签到人的头像
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name=""></param>
        /// <returns></returns>
        List<string> GetSignInHeadImages(int activityId);
        /// <summary>
        /// 获取未领过奖的签到数据列表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="activityId"></param>
        /// <returns></returns>
        List<SignInRecord> GetSignInRecordsWithoutAwards(int top, int activityId);
    }
}
