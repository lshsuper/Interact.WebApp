using Interact.Core.Dto;
using Interact.Core.Entity;
using Interact.Core.Enum;
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
        /// <param name="top"></param>
        /// <returns></returns>
        List<string> GetSignInHeadImages(int activityId,int top=100);
        /// <summary>
        /// 获取未领过奖的签到数据列表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="activityId"></param>
        /// <returns></returns>
        List<SignInRecord> GetSignInRecordsWithoutAwards(int top, int activityId);
        /// <summary>
        /// 根据活动id+奖品等级获取中奖人签到信息
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="activityAwardId"></param>
        /// <returns></returns>
        List<SignInRecord> GetSignInRecordsByActivityIdAndActivityAwardId(int activityId, int  activityAwardId);
        /// <summary>
        /// 获取分页签到数据
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        PageInfo<List<SignInRecord>> QuerySignInRecordByPage(SignInRecordPageOption option);
        /// <summary>
        /// 根据活动id和openid获取签到记录
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="openId"></param>
        /// <returns></returns>
        SignInRecord GetSignInRecordsByActivityIdAndOpenId(int activityId,string openId);
        /// <summary>
        /// 根据活动id获取签到数据
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        List<SignInRecordDto> GetSignInRecordsByActivityId(int activityId);
        /// <summary>
        /// 签到总数据
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        int TotalCount(int activityId);
        /// <summary>
        /// 未中奖人数
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        int TotalCountWithoutWinner(int activityId);
    }
}
