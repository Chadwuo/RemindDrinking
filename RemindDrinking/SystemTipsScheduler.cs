using FluentScheduler;
using RemindDrinking.Core.DataAccess;
using System;
using System.Collections.Generic;

namespace RemindDrinking
{
    // 一个开源任务调度框架  附上git地址
    // https://github.com/fluentscheduler/FluentScheduler
    public class SystemTipsScheduler : Registry
    {
        public SystemTipsScheduler()
        {
            daSchedulerConfig daScheduler = new daSchedulerConfig();
            var schedulerList = daScheduler.GetSchedulerConfig();

            foreach (var scheduler in schedulerList)
            {
                //DateTime.TryParse(scheduler.Date, out DateTime date);
                DateTime date = DateTime.ParseExact(scheduler.Date, "HH:mm", System.Globalization.CultureInfo.CurrentCulture);
            }

            //遍历字典
            foreach (KeyValuePair<string, string> kvp in AppSetting.Set.TimeSet)
            {
                Schedule(() => new ShowTipsMsgJob(kvp.Value)).ToRunEvery(1).Days().At(Convert.ToInt32(kvp.Key), 00);
            }

            //遍历key
            //foreach (string key in set.TimeSet.Keys)
            //{
            //    Schedule(() => new ShowTipsMsgJob()).ToRunEvery(1).Days().At(Convert.ToInt32(key), 00);
            //}

            ////Schedule a simple job to run at a specific time
            //Schedule(() => new ShowTipsMsgJob(1)).ToRunEvery(1).Days().At(9, 00);
            //Schedule(() => new ShowTipsMsgJob(2)).ToRunEvery(1).Days().At(10, 00);
            //Schedule(() => new ShowTipsMsgJob(3)).ToRunEvery(1).Days().At(11, 00);
            //Schedule(() => new ShowTipsMsgJob(4)).ToRunEvery(1).Days().At(12, 00);
            //Schedule(() => new ShowTipsMsgJob(5)).ToRunEvery(1).Days().At(14, 00);
            //Schedule(() => new ShowTipsMsgJob(6)).ToRunEvery(1).Days().At(15, 00);
            //Schedule(() => new ShowTipsMsgJob(7)).ToRunEvery(1).Days().At(16, 00);
            //Schedule(() => new ShowTipsMsgJob(8)).ToRunEvery(1).Days().At(18, 57);
        }

    }

    class ShowTipsMsgJob : IJob
    {
        /// <summary>
        /// 提示文字消息
        /// </summary>
        private string msg;

        public ShowTipsMsgJob(string msg)
        {
            this.msg = msg;
        }

        public void Execute()
        {
            TipsForm tips = new TipsForm(msg);
            tips.ShowDialog();
        }
    }
}
