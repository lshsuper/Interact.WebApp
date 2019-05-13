using Interact.Core.Entity;
using Interact.Core.Enum;
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
        /// 抽奖(策略1)
        /// </summary>
        /// <param name="winner"></param>
        /// <param name="notify"></param>
        /// <returns></returns>
        public bool LotteryDraw(List<WinnerMenu> winner, out string notify)
        {

            //1.校验活动(暂时不做检验)
            //2.校验签到记录(暂时不做检验)
            //3.抽奖
            winner.ForEach(o =>
            {
                o.Id = Guid.NewGuid().ToString("N");
                o.CreateTime = DateTime.Now;
            });
            bool result = _winnerMenuRespository.Add(winner);
            notify = result ? "操作成功" : "操作失败";
            return result;
        }
        /// <summary>
        /// 抽奖（策略2）
        /// </summary>
        /// <param name="winner"></param>
        /// <param name="notify"></param>
        /// <returns></returns>
        public bool LotteryDraw(int activityId,
                                int number,
                                int activityAwardId,
                                out string notify, out List<SignInRecord> signInRecords)
        {
            //1.随机获取
            var lst = _sigInRecordRespository.GetSignInRecordsWithoutAwards(number, activityId);
            if (lst.Count <= 0)
            {
                notify = "待抽奖人数不够";
                signInRecords = null;
                return false;
            }
               
            List<WinnerMenu> winnerMenus = new List<WinnerMenu>();
            lst.ForEach(ele =>
            {
                winnerMenus.Add(new WinnerMenu()
                {
                    ActivityId = ele.ActivityId,
                    SiginInRecoredId = ele.Id,
                    CreateTime = DateTime.Now,
                    ActivityAwardId = activityAwardId,
                    Id = Guid.NewGuid().ToString("N")
                });
            });
            //2.抽奖
            bool result = _winnerMenuRespository.Add(winnerMenus);
            if (!result)
            {
                notify = "抽取失败";
                signInRecords = null;
                return false;
            }
            notify = "抽取成功";
            signInRecords = lst;
            return result;
        }
    }
}
