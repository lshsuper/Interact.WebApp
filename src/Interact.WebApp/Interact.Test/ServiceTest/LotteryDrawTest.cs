using Interact.Application.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Interact.Core.Enum;
using Interact.Core.Entity;

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
        /// 抽奖测试01
        /// </summary>
        [TestMethod]
        public void LotteryDraw01()
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
        /// <summary>
        /// 抽奖测试02
        /// </summary>
        [TestMethod]
        public void LotteryDraw02()
        {
            string notify;
            List<SignInRecord> signInRecords;
            bool result = _lotteryDrawService.LotteryDraw(1,
                                                          5,WinnerLevelEnum.Level_One,
                                                          out notify,
                                                          out signInRecords);

        }

    }
}
