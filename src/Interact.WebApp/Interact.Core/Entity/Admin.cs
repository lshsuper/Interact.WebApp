using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Core.Entity
{
   public class Admin
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Pwd { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
