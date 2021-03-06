﻿using Interact.Core.Entity;
using Interact.Core.IRespository;
using Interact.Infrastructure.Config;
using Interact.Infrastructure.Wexin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Application.Service
{
    /// <summary>
    /// 签到相关业务
    /// </summary>
    public class SignInService
    {
        private readonly ISigInRecordRespository _sigInRecordRespository;
        private readonly IActivityRespository _activityRespository;
        public SignInService(ISigInRecordRespository sigInRecordRespository,
                            IActivityRespository activityRespository
                            )
        {
            _sigInRecordRespository = sigInRecordRespository;
            _activityRespository = activityRespository;
        }
        /// <summary>
        /// 签到业务
        /// </summary>
        /// <param name="record"></param>
        /// <param name="notify"></param>
        /// <returns></returns>
        public bool SignIn(SignInRecord record, out string notify)
        {

            //1.判断是否超出报名限制
            var currentActivity = _activityRespository.Get(DbConfig.DbConnStr, record.ActivityId);
            if (currentActivity == null || currentActivity.Id <= 0)
            {
                notify = "不存在当前活动";
                return false;
            }
            if (currentActivity.Status == Core.Enum.ActivityStatusEnum.End)
            {
                notify = "活动已停止报名";
                return false;
            }
            if (currentActivity.SignInNumber >= currentActivity.LimitNumber)
            {
                notify = "报名已满";
                return false;
            }
            //2.判断是否签到
            if (_sigInRecordRespository.CheckSignIn(record.OpenId, record.ActivityId))
            {
                notify = "您已经签到过";
                return false;
            }
            //3.签到
            record.Id = Guid.NewGuid().ToString("N");
            record.CreateTime = DateTime.Now;
            bool result = _sigInRecordRespository.SignIn(record);
            if (!result)
            {
                notify = "签到失败";
                return true;
            }
            notify = "签到成功";
            return true;
        }
        /// <summary>
        /// 获取用户签到数据
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="weixinAuthUserInfoResult"></param>
        /// <returns></returns>
        public SignInRecord SignInRecord(int activityId, WeixinOAuth2UserInfoResult weixinAuthUserInfoResult)
        {
            //1.获取当前签到数据
            var record = _sigInRecordRespository.GetSignInRecordsByActivityIdAndOpenId(activityId, weixinAuthUserInfoResult.openid);
            if (record == null) return null;
            //2.对比签到数据微信用户信息是否与当前过去的信息一致，若不一致便更新记录里的微信用户信息(暂时不核对)
            //3.返回数据
            return record;
        }
    }
}
