using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var conn = new SqlConnection("Data Source=.;Initial Catalog=Interact;User Id=sa;Password=1308956271");
          var obj= conn.Query("select * from Activity ");
        }
    }
}
