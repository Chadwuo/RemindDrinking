using CCWin;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RemindDrinking
{
    public partial class MainForm : CCSkinMain
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
            if (MessageBox.Show("连续按时喝水，你就可以瘦成一道闪电了！确认要退出 喝水提醒小助手 吗？", "退出小助手", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void SettingMenuItem_Click(object sender, EventArgs e)
        {
            GupTimeList.Visible = true;
            
            //遍历字典
            foreach (KeyValuePair<string, string> kvp in AppSetting.Set.TimeSet)
            {
                int index = this.DgvTime.Rows.Add();
                this.DgvTime.Rows[index].Cells[0].Value = kvp.Key+":00";
                this.DgvTime.Rows[index].Cells[1].Value = kvp.Value;
            }
            AppSetting.Set.Save();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            GupTimeList.Visible = false;
        }
    }
}
