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
    }
}
