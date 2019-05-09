using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Core.Entity
{
    /// <summary>
    /// 签到记录
    /// </summary>
  public  class SignInRecord
    {
        /// <summary>
        /// 记录id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 微信用户openid
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 微信用户昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 所属活动id
        /// </summary>
        public int ActivityId { get; set; }
        /// <summary>
        /// 签到时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }
}
