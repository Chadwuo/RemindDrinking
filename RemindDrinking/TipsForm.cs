using RemindDrinking.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RemindDrinking
{
    public partial class TipsForm : Form
    {
        // 图片的所在目录
        private String exePath = Application.StartupPath + @"\image\";
        
        private string msgText;//显示文字
        private int index = Settings.Default.backHomeTime; //关闭提示窗体计数器
        public TipsForm( string msg)
        {
            InitializeComponent();
            this.msgText = msg;
        }

        /// <summary>
        /// TipsForm_Load
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void TipsForm_Load(object sender, EventArgs e)
        {
            // 定时关闭提示窗体任务 启动
            TmrBackHome.Start();

            Random rd = new Random();

            // 文字提示的随机坐标
            int LabXPoint = rd.Next(10, 80);
            int LabYPoint = rd.Next(10, 400);
            this.LabMsg.Location = new Point(LabXPoint, LabYPoint);

            // 获取 image文件夹下的文件名列表
            List<string> imgFile = GetBcakImage();
            // 随机拿到一个图片
            string imgName = imgFile[rd.Next(imgFile.Count)];
            this.BackgroundImage = Image.FromFile(exePath + imgName);
            this.BackgroundImageLayout = ImageLayout.Stretch;

            LabMsg.Text = msgText;

            //switch (showMod)
            //{
            //    case 1:
            //        LabMsg.Text = "9:00  用最美的心情来迎接朝阳和第一杯水！";
            //        break;
            //    case 2:
            //        LabMsg.Text = "10:00  小公主~ 要记得喝水哦！";
            //        break;
            //    case 3:
            //        LabMsg.Text = "11:00  科学研究表明，此时喝水有助于瘦身！";
            //        break;
            //    case 4:
            //        LabMsg.Text = "12:00  吃完饭，喝杯水，休息一会！";
            //        break;
            //    case 5:
            //        LabMsg.Text = "14:00  喝最大杯的水，做最靓的仔！";
            //        break;
            //    case 6:
            //        LabMsg.Text = "15:00  娘娘，喝水的时间到了！";
            //        break;
            //    case 7:
            //        LabMsg.Text = "16:00  菇凉，喝口水吧！";
            //        break;
            //    case 8:
            //        LabMsg.Text = "17:00  注意，再喝一杯水，马上要下班了！";
            //        break;
            //    default:
            //        break;
            //}
        }

        /// <summary>
        /// 获取image目录下文件名集合
        /// </summary>
        /// <returns>string</returns>
        private List<string> GetBcakImage()
        {
            //相对路径，和程序exe同目录下
            DirectoryInfo dir = new DirectoryInfo(exePath);

            FileInfo[] fileInfo = dir.GetFiles();
            List<string> fileNames = new List<string>();
            foreach (FileInfo item in fileInfo)
            {
                fileNames.Add(item.Name);
            }
            return fileNames;
        }

        /// <summary>
        /// 关闭窗体任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrBackHome_Tick(object sender, EventArgs e)
        {
            index--;
            if (index == 0)
            {
                this.Close();
            }
        }
    }
}
