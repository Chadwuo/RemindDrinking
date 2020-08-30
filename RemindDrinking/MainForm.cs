using CCWin;
using RemindDrinking.Config;
using RemindDrinking.Core.DataAccess;
using RemindDrinking.Core.HttpUtil;
using RemindDrinking.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RemindDrinking
{
    /// <summary>
    /// MainForm class
    /// </summary>
    public partial class MainForm : CCSkinMain
    {
        /// <summary>
        /// MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体关闭时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.ShowInTaskbar = false;
            notifyIcon1.ShowBalloonTip(5000, "喝水提醒小助手", "我在这里！", ToolTipIcon.Info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            daImageArchive daImage = new daImageArchive();

            // 从数据库中获取今日的图片
            ImageArchive imageToday = daImage.GetImageToday();
            if (imageToday != null)
            {
                this.BackgroundImage = Image.FromFile(imageToday.Fullpath);
                return;
            }

            // 从bing接口获取今日图片
            var bingImage = HttpUtil.GetResponse<BingImage>(ConfigDefault.BingImageUrl);
            foreach (var img in bingImage.Images)
            {
                string dowloadUrl = ConfigDefault.BingBaseUrl + img.Url;
                var imgPath = HttpDownUtil.HttpDownloadFile(dowloadUrl, string.Format(ConfigDefault.SavePath, AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyyMMdd")));

                ImageArchive imageArchive = new ImageArchive()
                {
                    Date = DateTime.Now.ToString("yyyyMMdd"),
                    Title = img.Title,
                    Copyright = img.Copyright,
                    Fullpath = imgPath
                };

                // 图片数据保存到数据库
                daImage.InsertImageArchive(imageArchive);

                this.BackgroundImage = Image.FromFile(imageArchive.Fullpath);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("喝水提醒小助手，已经正常启动。愿你有个美好的一天！\n源码地址：https://github.com/micahh28/RemindDrinking \n\t\t\t\twrite by micahh");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("连续按时喝水，你就可以瘦成一道闪电了！确认要退出 喝水提醒小助手 吗？", "退出小助手", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
