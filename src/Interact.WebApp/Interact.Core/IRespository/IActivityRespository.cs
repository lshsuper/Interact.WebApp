using Interact.Core.Entity;
using Interact.Infrastructure.Dapper.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Core.IRespository
{
    public interface IActivityRespository:IRespository<Activity>
    {
        /// <summary>
        /// 编辑活动（部分字段）
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        bool EditActivity(Activity activity);
    }
}
