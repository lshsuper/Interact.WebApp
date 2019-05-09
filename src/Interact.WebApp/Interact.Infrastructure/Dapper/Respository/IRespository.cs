using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Infrastructure.Dapper.Respository
{
    public interface IRespository<T>
    {

        IEnumerable<T> GetList(string connStr);

        T Get(string connStr,object id);

        bool Update(string connStr,T t);

        T Insert(string connStr,T apply);

        bool Delete(string connStr,T t);

        IEnumerable<T> Find(string connStr,Expression<Func<T, object>> expression,Operator op, object param);


    }
}
