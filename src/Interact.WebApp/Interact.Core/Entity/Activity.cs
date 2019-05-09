using Interact.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Core.Entity
{
  public  class Activity
    {
        /// <summary>
        /// 活动id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 活动名称
        /// </summary>
        public string Nanme { get; set; }
        /// <summary>
        /// 报名限制
        /// </summary>
        public int LimitNumber { get; set; }
        /// <summary>
        /// 签到数
        /// </summary>
        public int SignInNumber { get; set; }
        /// <summary>
        /// 海报地址
        /// </summary>
        public string PlayBillUrl { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 活动状态
        /// </summary>
        public ActivityStatusEnum Status { get; set; }
    }
}
