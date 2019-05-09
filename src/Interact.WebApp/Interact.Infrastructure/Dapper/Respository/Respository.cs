using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions;
using Interact.Infrastructure.Helper;

namespace Interact.Infrastructure.Dapper.Respository
{
   public class Respository<T>:IRespository<T> where T:class,new()
    {
        
        public virtual IEnumerable<T> GetList(string connStr)
        {
            using (var conn =DapperHelper.Instance.GetConnection(connStr))
            {
                return conn.GetList<T>();
            }

        }

        public virtual T Get(string connStr,object id)
        {
            using (var conn = DapperHelper.Instance.GetConnection(connStr))
            {
                return conn.Get<T>(id);
            }
        }

        public virtual bool Update(string connStr,T t)
        {
            using (var conn = DapperHelper.Instance.GetConnection(connStr))
            {
                return conn.Update(t);
            }
        }

        public virtual T Insert(string connStr,T apply)
        {
            using (var conn = DapperHelper.Instance.GetConnection(connStr))
            {
                conn.Insert(apply);
                return apply;
            }
        }

        public virtual bool Delete(string connStr,T t)
        {
            using (var conn = DapperHelper.Instance.GetConnection(connStr))
            {
                return conn.Delete(t);
            }
        }

        public virtual IEnumerable<T> Find(string connStr,Expression<Func<T, object>> expression, Operator op, object param)
        {
            using (var conn = DapperHelper.Instance.GetConnection(connStr))
            {
                return conn.GetList<T>(Predicates.Field<T>(expression, op, param));
            }
        }

      
    }
}
