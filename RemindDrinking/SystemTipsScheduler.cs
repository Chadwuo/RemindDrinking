using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindDrinking
{
    //一个开源任务调度框架  附上git地址
    //https://github.com/fluentscheduler/FluentScheduler
    public class SystemTipsScheduler : Registry
    {
        public SystemTipsScheduler()
        {
            //Schedule a simple job to run at a specific time
            Schedule(() => new ShowTipsMsgJob(1)).ToRunEvery(1).Days().At(9, 00);
            Schedule(() => new ShowTipsMsgJob(2)).ToRunEvery(1).Days().At(10, 00);
            Schedule(() => new ShowTipsMsgJob(3)).ToRunEvery(1).Days().At(11, 00);
            Schedule(() => new ShowTipsMsgJob(4)).ToRunEvery(1).Days().At(12, 00);
            Schedule(() => new ShowTipsMsgJob(5)).ToRunEvery(1).Days().At(14, 00);
            Schedule(() => new ShowTipsMsgJob(6)).ToRunEvery(1).Days().At(15, 00);
            Schedule(() => new ShowTipsMsgJob(7)).ToRunEvery(1).Days().At(16, 00);
            Schedule(() => new ShowTipsMsgJob(8)).ToRunEvery(1).Days().At(17, 00);
        }
        
    }
    
    class ShowTipsMsgJob : IJob
    {
        /// <summary>
        /// 模式：用于区分任务，以显示不同的背景
        /// </summary>
        private int mod;

        public ShowTipsMsgJob(int mod)
        {
            this.mod = mod;
        }

        public void Execute()
        {
            TipsForm tips = new TipsForm(mod);
            tips.ShowDialog();
        }
    }
}
