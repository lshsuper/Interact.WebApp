using System.ComponentModel;

namespace Interact.Core.Enum
{
    /// <summary>
    /// 活动状态
    /// </summary>
    public enum ActivityStatusEnum
    {
        /// <summary>
        /// 开始
        /// </summary>
        [Description("开始报名")]
        Start = 0,
        /// <summary>
        /// 结束
        /// </summary>
        [Description("停止报名")]
        End = 1
    }
}