﻿using Interact.Core.Entity;
using Interact.Core.Enum;
using Interact.Infrastructure.Dapper.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Core.IRespository
{
    /// <summary>
    /// 中奖名单仓储
    /// </summary>
   public interface IWinnerMenuRespository:IRespository<WinnerMenu>
    {
        /// <summary>
        ///添加中奖记录
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        bool Add(List<WinnerMenu>lst);
        /// <summary>
        /// 移除某活动下的中奖名单(真删)
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        bool RemoveAllByActivity(int activityId);
    }
}
