using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Infrastructure.Dapper
{
  public class PageModel<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
