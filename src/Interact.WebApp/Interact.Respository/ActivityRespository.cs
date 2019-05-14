using Interact.Core.Entity;
using Interact.Core.IRespository;
using Interact.Core.Option;
using Interact.Infrastructure.Config;
using Interact.Infrastructure.Dapper.Respository;
using Interact.Infrastructure.Helper;
using Interact.Infrastructure.Helper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interact.Infrastructure.Dapper;
using Interact.Infrastructure.Util;
using Dapper;
namespace Interact.Respository
{
    public class ActivityRespository : Respository<Activity>, IActivityRespository
    {
        
        public bool EditActivity(Activity activity, List<ActivityAward> activityAwards)
        {
            using (var conn = DapperHelper.Instance.GetConnection(DbConfig.DbConnStr))
            {
                conn.Open();
                var tran = conn.BeginTransaction();
                try
                {
                    string sql = $@"update Activity
                                                set
                                                Name=@Name,
                                                LimitNumber=@LimitNumber,
                                                PlayBillUrl=PlayBillUrl
                                     where Id=@Id";
                    bool result = conn.Execute(sql, activity) > 0;
                    if (!result)
                    {
                        tran.Rollback();
                        return false;
                    }
                      
                    sql = $@"update ActivityAward    
                                              set
                                                 Name=@Name,
                                                 AwardImage=@AwardImage
                                  where Id=@id";
                    result = conn.Execute(sql, activityAwards) > 0;
                    if (!result)
                    {
                        tran.Rollback();
                        return false;
                    }
                    tran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return false;
                }
            }
        }
        /// <summary>
        /// 添加活动
        /// </summary>
        /// <returns></returns>
        public bool AddActivity(Activity activity,List<ActivityAward>activityAwards)
        {
            activity.AuthCode=Tool.UUID(8);
            activity.CreateTime = DateTime.Now;
            using (var conn = DapperHelper.Instance.GetConnection(DbConfig.DbConnStr))
            {
                conn.Open();
                var tran = conn.BeginTransaction();
                try
                {
                    string sql = $@"insert into Activity (Name,
                                                LimitNumber,
                                                PlayBillUrl,
                                                AuthCode)values(
                                                @Name,
                                                @LimitNumber,
                                                @PlayBillUrl,
                                                @AuthCode);select SCOPE_IDENTITY()";
                    int id = conn.ExecuteScalar<int>(sql, activity,tran);
                    if (id<=0)
                    {
                        tran.Rollback();
                        return false;
                    }
               
                    sql = $@"insert into ActivityAward(Name,
                                                      ActivityId,
                                                      AwardImage)values(
                                                      @Name,
                                                      @ActivityId,
                                                      @AwardImage)";
                    activityAwards.ForEach(o=> {
                        o.ActivityId = id;
                    });
                    bool result = conn.Execute(sql, activityAwards,tran) > 0;
                    if (!result)
                    {
                        tran.Rollback();
                        return false;
                    }
                    tran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return false;
                }
            }

        }
        public PageInfo<List<Activity>> QueryActivityByPage(ActivityPageOption option)
        {
            string sqlFilter = option.GetFilterStr;
            sqlFilter = string.IsNullOrEmpty(sqlFilter) ? "" : " where " + sqlFilter;
            string dataSql = $@"select *
                                from(
                                     select *,
                                            row_number() over({option.BuildOrderByStr()}) num 
                                     from Activity {sqlFilter}
                                ) as tb where {option.BuildRangeStr("num")}";

            string countSql = $"select count(*) from Activity {sqlFilter}";
            var data = DapperHelper.Instance.Page<Activity>(DbConfig.DbConnStr, $"{dataSql};{countSql}");
            return new PageInfo<List<Activity>>()
            {
                Total = data.Total,
                Rows = data.Data.ToList(),
                PageIndex = option.PageIndex,
                PageSize = option.PageSize
            };
        }

        public Activity GetActivityByAuthCodeAndActivityId(string authCode, int activityId)
        {
            string sql = $"select * from Activity where Id=@activityId and AuthCode=@authCode";
            return DapperHelper.Instance.QueryFirst<Activity>(DbConfig.DbConnStr,sql,new {authCode,activityId });
        }
    }
}
