using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Infrastructure.Helper
{
   public class NlogHelper
    {
        private static NLog.ILogger _logger = LogManager.GetCurrentClassLogger();

        public enum LogLevel
        {
            Debug,
            Info,
            Error,
            Fatal,
            Warn,

        }
        #region 
        public static void LogWrite(LogLevel level)
        {
            try
            {
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
