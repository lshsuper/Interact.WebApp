using Interact.Application.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
namespace Interact.Test
{
    /// <summary>
    /// 抽奖相关测试
    /// </summary>
    [TestClass]
    public class LotteryDrawTest : BaseTest
    {
        private readonly LotteryDrawService _lotteryDrawService;
        public LotteryDrawTest()
        {
            _lotteryDrawService = _container.Resolve<LotteryDrawService>();
        }
        /// <summary>
        /// 抽奖测试
        /// </summary>
        [TestMethod]
        public void LotteryDraw()
        {
            string notify;
            bool result = _lotteryDrawService.LotteryDraw(new List<Core.Entity.WinnerMenu>() {
                   new Core.Entity.WinnerMenu()
                   {
                       SiginInRecoredId=Guid.NewGuid().ToString("N"),
                       ActivityId=1,
                       WinnerLevel=Core.Enum.WinnerLevelEnum.Level_One
                   }
            }, out notify);

        }

    }
}
