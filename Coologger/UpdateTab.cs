using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Coologger
{
    public partial class UpdateTab : Form
    {
        public UpdateTab()
        {
            InitializeComponent();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FButton1_Click(object sender, EventArgs e)
        {
            try
            {
                new WebClient().DownloadFile("http://coologger.no-ip.org/coologger/5764387532-453-0/CooLogger.rar",
                                             TextBox1.Text);
                MessageBox.Show("COOLogger Downloaded " + TextBox1.Text);
                this.Hide();
                RegisterForm.Instance.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void FButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dl = new SaveFileDialog();
            dl.Filter = "Rar Archive *.rar|*.rar";
            dl.ShowDialog();
            TextBox1.Text = dl.FileName;
        }
    }
}
