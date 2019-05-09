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
namespace Interact.Respository
{
    public class SigInRecordRespository : Respository<SignInRecord>, ISigInRecordRespository
    {
        public bool CheckSignIn(string openId, int activityId)
        {
            string sql = "select count(1) from SignInRecord where OpendId=@opendId and ActivityId=@activityId";
            return DapperHelper.Instance.ExcuteScaler<int>(DbConfig.DbConnStr,sql)>0;
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
                                         ActivityId,
                                         CreateTime) values(
                                         @Id,
                                         @OpenId,
                                         @NickName,
                                         @ActivityId,
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
    }
}
