using Interact.Infrastructure.Helper;
using Interact.Infrastructure.Helper.Model;
using System;
using System.Web;

namespace Interact.Application.Dto
{
    public class AdminDto: JwtPaylod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }

      
    }
}
