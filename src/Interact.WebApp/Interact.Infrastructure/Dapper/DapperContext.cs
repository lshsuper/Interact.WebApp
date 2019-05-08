using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace Interact.Infrastructure.Dapper
{
    /// <summary>
    /// dapper context
    /// </summary>
    public class DapperContext
    {
        public IDbConnection GetConnection(string connStr)
        {
            return new SqlConnection(connStr);
        }
        /// <summary>
        /// update/insert/delete
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool Excute(string connStr,string sql,object param=null)
        {
            using (var conn=GetConnection(connStr))
            {
                return conn.Execute(sql,param)>0;
            }
        }
        /// <summary>
        /// select row
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connStr"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public T QueryFirst<T>(string connStr,string sql)
        {
            using (var conn = GetConnection(connStr))
            {
                return conn.QueryFirst<T>(sql);
            }
        }
        /// <summary>
        /// select list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connStr"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<T>Query<T>(string connStr,string sql)
        {
            using (var conn = GetConnection(connStr))
            {
                return conn.Query<T>(sql).ToList();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connStr"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public T ExcuteScaler<T>(string connStr,string sql)
        {
            using (var conn = GetConnection(connStr))
            {
                return conn.ExecuteScalar<T>(connStr,sql);
            }
        }
    }
}
