using Interact.Core.Entity;
using Interact.Core.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Interact.Application.Service
{
    /// <summary>
    /// 抽奖相关业务
    /// </summary>
   public class LotteryDrawService
    {
        private readonly IWinnerMenuRespository _winnerMenuRespository;
        private readonly ISigInRecordRespository _sigInRecordRespository;
        private readonly IActivityRespository _activityRespository;
        /// <summary>
        /// 抽奖
        /// </summary>
        public LotteryDrawService(IWinnerMenuRespository winnerMenuRespository,
                                 ISigInRecordRespository sigInRecordRespository,
                                 IActivityRespository activityRespository)
        {
            _winnerMenuRespository = winnerMenuRespository;
            _sigInRecordRespository = sigInRecordRespository;
            _activityRespository = activityRespository;
        }
        /// <summary>
        /// 抽奖
        /// </summary>
        /// <param name="winner"></param>
        /// <param name="notify"></param>
        /// <returns></returns>
      public bool LotteryDraw(List<WinnerMenu> winner,out string notify)
        {

            //1.校验活动(暂时不做检验)
            //2.校验签到记录(暂时不做检验)
            //3.抽奖
            winner.ForEach(o=> {
                o.Id = Guid.NewGuid().ToString("N");
                o.CreateTime = DateTime.Now;
            });
            bool result = _winnerMenuRespository.Add(winner);
            notify = result ? "操作成功" : "操作失败";
            return result;
        }
    }
}
