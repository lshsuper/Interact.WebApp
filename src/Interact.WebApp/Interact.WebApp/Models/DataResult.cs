using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interact.WebApp.Models
{
    public class DataResult
    {
        public bool Status { get; set; }
        public object Data { get; set; }
        public string Notify { get; set; }
    }
}