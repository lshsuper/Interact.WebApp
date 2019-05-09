using Interact.Core.Entity;
using Interact.Core.IRespository;
using Interact.Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Application.Service
{
  public  class SignInService
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
        public bool SignIn(SignInRecord record,out string notify)
        {
            //1.判断是否超出报名限制
            var currentActivity = _activityRespository.Get(DbConfig.DbConnStr,record.Id);
            if (currentActivity == null || currentActivity.Id <= 0)
            {
                notify = "不存在当前活动";
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
    }
}
