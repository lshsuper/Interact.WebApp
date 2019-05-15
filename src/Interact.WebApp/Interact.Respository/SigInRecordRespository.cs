using Interact.Core.Entity;
using Interact.Core.IRespository;
using Interact.Infrastructure.Config;
using Interact.Infrastructure.Dapper.Respository;
using Interact.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Interact.Core.Enum;
using Interact.Core.Option;
using Interact.Infrastructure.Helper.Model;
using Interact.Core.Dto;

namespace Interact.Respository
{
    public class SigInRecordRespository : Respository<SignInRecord>,ISigInRecordRespository
    {
        public bool CheckSignIn(string openId, int activityId)
        {
            string sql = "select count(1) from SignInRecord where OpenId=@openId and ActivityId=@activityId";
            return DapperHelper.Instance.ExcuteScaler<int>(DbConfig.DbConnStr,sql,new {activityId,openId })>0;
        }

        public List<string> GetSignInHeadImages(int activityId,int top)
        {
            string sql = $"select top({top}) HeadImage from SignInRecord where ActivityId=@activityId";
            return DapperHelper.Instance.Query<string>(DbConfig.DbConnStr,sql,new { activityId });
        }

        public bool SignIn(SignInRecord record)
        {
            using (var conn=DapperHelper.Instance.GetConnection(DbConfig.DbConnStr))
            {
                conn.Open();
                var tran = conn.BeginTransaction();
                try
                {
                    string sql = "update Activity set SignInNumber=SignInNumber+1 where SignInNumber+1<=LimitNumber and Id=@id";
                    bool result = conn.Execute(sql,new { id=record.ActivityId}, tran) >0;
                    if (!result)
                    {
                        tran.Rollback();
                        return false;
                    }
                    sql = $@"insert into SignInRecord(
                                         Id,
                                         OpenId,
                                         NickName,
                                         ActivityId,HeadImage,
                                         CreateTime) values(
                                         @Id,
                                         @OpenId,
                                         @NickName,
                                         @ActivityId,@HeadImage,
                                         @CreateTime)";
                    result = conn.Execute(sql,record,tran)>0;
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
                    //可记日志
                    tran.Rollback();
                    return false;
                  
                }
            }
        }

        public List<SignInRecord> GetSignInRecordsWithoutAwards(int top,int activityId)
        {
            string sql = $@"select top({top}) * 
                            from SignInRecord sr 
                            where activityId=@activityId and  not exists (select * from WinnerMenu wm where wm.SiginInRecoredId=sr.Id)";
            return DapperHelper.Instance.Query<SignInRecord>(DbConfig.DbConnStr, sql,new { activityId});
        }
        public List<SignInRecord> GetSignInRecordsByActivityIdAndActivityAwardId(int activityId, int activityAwardId)
        {
            string sql =$@"select * from SignInRecord sr
                           inner join WinnerMenu wm on sr.Id=wm.SiginInRecoredId
                           where sr.ActivityId=@activityId and wm.ActivityAwardId=@activityAwardId";
            return DapperHelper.Instance.Query<SignInRecord>(DbConfig.DbConnStr, sql, new { activityId, activityAwardId });
        }

        public PageInfo<List<SignInRecord>> QuerySignInRecordByPage(SignInRecordPageOption option)
        {
            string sqlFilter = option.GetFilterStr;
            sqlFilter = string.IsNullOrEmpty(sqlFilter) ? "" : " where " + sqlFilter;
            string dataSql = $@"select *
                                from(
                                     select *,
                                            row_number() over({option.BuildOrderByStr()}) num 
                                     from SignInRecord {sqlFilter}
                                ) as tbc where {option.BuildRangeStr("num")}";

            string countSql = $"select count(*) from SignInRecord {sqlFilter}";
            var data = DapperHelper.Instance.Page<SignInRecord>(DbConfig.DbConnStr, $"{dataSql};{countSql}");
            return new PageInfo<List<SignInRecord>>()
            {
                Total = data.Total,
                Rows = data.Data.ToList(),
                PageIndex = option.PageIndex,
                PageSize = option.PageSize
            };
        }

        public SignInRecord GetSignInRecordsByActivityIdAndOpenId(int activityId, string openId)
        {
            string sql = $@"select * from SignInRecord where ActivityId=@activityId and OpenId=@openId";
            return DapperHelper.Instance.QueryFirst<SignInRecord>(DbConfig.DbConnStr,sql,new { activityId, openId });
        }

        public List<SignInRecordDto> GetSignInRecordsByActivityId(int activityId)
        {
            string sql = "select *,row_number() over(order by CreateTime) as Sort from SignInRecord where ActivityId=@activityId";
            return DapperHelper.Instance.Query<SignInRecordDto>(DbConfig.DbConnStr,sql,new { activityId });
        }

        public int TotalCount(int activityId)
        {
            string sql = $"select count(1) from SignInRecord where ActivityId=@activityId";
            return DapperHelper.Instance.ExcuteScaler<int>(DbConfig.DbConnStr,sql,new { activityId});
        }

        public int TotalCountWithoutWinner(int activityId)
        {
            string sql = $@"select count (1) 
                            from SignInRecord sr
                            where  not exists (select * from WinnerMenu wm where wm.SiginInRecoredId=sr.Id)";
            return DapperHelper.Instance.ExcuteScaler<int>(DbConfig.DbConnStr, sql, new { activityId });
        }
    }
}
