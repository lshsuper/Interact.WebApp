using Interact.Infrastructure.Helper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Core.Dto
{
  public  class ScreenAuthDto:JwtPaylod
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public int ActivityId { get; set; }
    }
}
