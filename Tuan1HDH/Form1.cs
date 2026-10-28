using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tuan1HDH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //TEST
            DisplayProcess();
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog(); 
            DialogResult ret = dlg.ShowDialog();
            if (ret == DialogResult.OK) tbFilePath.Text = dlg.FileName;
        }
        private void DisplayProcess()
        {
            lbProcess.Items.Clear();
            Process[] listProc = Process.GetProcesses();
            foreach(Process proc in listProc)
            {
                lbProcess.Items.Add(proc.Id + ", " + proc.ProcessName);
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            Process myproc = new Process();
            try
            {
                myproc.StartInfo.FileName = tbFilePath.Text;
                myproc.Start();
                DisplayProcess();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayProcess();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            string[] list = lbProcess.SelectedItem.ToString().Split(',');
            Process proc = Process.GetProcessById(Int32.Parse(list[0]));
            proc.Kill();
        }
    }
}
