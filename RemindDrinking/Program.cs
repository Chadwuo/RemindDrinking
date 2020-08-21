using FluentScheduler;
using System;
using System.Windows.Forms;

namespace RemindDrinking
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            _ = new System.Threading.Mutex(true, "RemindDrinking", out bool isRuned);
            if (isRuned)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // 注册定时任务
                JobManager.Initialize(new SystemTipsScheduler());
                Application.Run(new MainForm());
            }
            else
            {
                MessageBox.Show("小助手正在运行中!", "喝水提醒小助手", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
