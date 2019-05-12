using Interact.Infrastructure.Helper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Core.Dto
{
   public class SignInAuthDto:JwtPaylod
    {
        public string RefrashToken { get; set; }

    }
}
