using Interact.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Core.Entity
{
   public class ActivityAward
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActivityId { get; set; }
        public string AwardImage { get; set; }
        public WinnerLevelEnum WinnerLevel { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
