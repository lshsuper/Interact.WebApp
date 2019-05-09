using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Core.Enum
{
    public enum WinnerLevelEnum
    {
        /// <summary>
        /// 一等奖
        /// </summary>
        [Description("一等奖")]
        Level_One=1,
        /// <summary>
        /// 二等奖
        /// </summary>
        [Description("二等奖")]
        Level_Two=2,
        /// <summary>
        /// 三等奖
        /// </summary>
        [Description("三等奖")]
        Level_Three=3
    }
}
