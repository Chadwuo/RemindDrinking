using RemindDrinking.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindDrinking
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.ShowInTaskbar = false;
            notifyIcon1.ShowBalloonTip(5000, "喝水提醒小助手", "我在这里！", ToolTipIcon.Info);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("喝水提醒小助手，已经正常启动。愿你有个美好的一天！\n源码地址：https://github.com/micahh28/RemindDrinking \n\t\t\t\twrite by micahh");
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("连续按时喝水两个星期，你就可以瘦成一道闪电了！确认要退出 喝水提醒小助手 吗？", "退出小助手", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
