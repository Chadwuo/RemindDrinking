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
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LabExplain.Text = "我是你的“提醒喝水小助手-超超”\n我将会在接下来的日子里，每天守护在你身边提醒你喝水。\n希望你在看到提示消息的时候可以按照提示，喝一杯水！";
        }
    }
}
