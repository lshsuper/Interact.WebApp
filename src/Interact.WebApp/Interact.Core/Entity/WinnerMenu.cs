using Interact.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Core.Entity
{
    /// <summary>
    /// 中奖人名单
    /// </summary>
   public class WinnerMenu
    {
        /// <summary>
        /// 记录id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 对应签到记录id
        /// </summary>
        public string SiginInRecoredId { get; set; }
        /// <summary>
        /// 活动id
        /// </summary>
        public int ActivityId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
      
        public int  ActivityAwardId { get; set; }

    }
}
