using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Coologger
{
    public partial class SupportForm : Form
    {
        public SupportForm()
        {
            InitializeComponent();
        }

        #region Singleton
        static SupportForm _Instance = null;
        static readonly object PadLock = new object();

        public static SupportForm Instance
        {
            get
            {
                lock (PadLock)
                {
                    return _Instance ?? (_Instance = new SupportForm());
                }
            }
        }
        #endregion

        private void FButton1_Click(object sender, EventArgs e)
        {
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.Navigate("http://coologger.no-ip.org/coologger/question.php?question=" + RichTextBox1.Text);
            MessageBox.Show("Thank you for your support of Coologger.");
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #region MouseControls
        Point lastClick;
        private void MouseMoved_Control(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastClick.X;
                this.Top += e.Y - lastClick.Y;
            }
        }

        private void MouseDown_Control(object sender, MouseEventArgs e)
        {
            lastClick = new Point(e.X, e.Y);
        }
        #endregion
    }
}
