using Interact.Core.Entity;
using Interact.Core.IRespository;
using Interact.Infrastructure.Config;
using Interact.Infrastructure.Dapper.Respository;
using Interact.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Respository
{
    public class ActivityRespository : Respository<Activity>, IActivityRespository
    {
        public bool EditActivity(Activity activity)
        {
            string sql = $@"update Activity set 
                                   Name=@Name,
                                   LimitNumber=@LimitNumber,
                                   PlayBillUrl=@PlayBillUrl,
                             where Id=@Id and SignInNumber<=@LimitNumber";
            return DapperHelper.Instance.Excute(DbConfig.DbConnStr,sql,activity);
        }
    }
}
