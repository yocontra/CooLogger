﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Coologger
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        #region Singleton
        static MenuForm _Instance = null;
        static readonly object PadLock = new object();

        public static MenuForm Instance
        {
            get
            {
                lock (PadLock)
                {
                    return _Instance ?? (_Instance = new MenuForm());
                }
            }
        }
        #endregion

        private void Form3_Load(object sender, EventArgs e)
        {
            /*string input =
                System.IO.File.ReadAllText(
                    @"C:\Users\Admin\Documents\Visual Studio 2010\Projects\Coologger\Coologger\bin\Debug\source.txt");
            System.IO.File.WriteAllText(
                @"C:\Users\Admin\Documents\Visual Studio 2010\Projects\Coologger\Coologger\bin\Debug\source2.txt",
                Convert.ToBase64String(Encoding.Default.GetBytes(input)));*/
            try
            {
                WebClient client = new WebClient();
                Label1.Text = client.DownloadString("http://coologger.no-ip.org/coologger/news.txt");
                if (!client.DownloadString("http://coologger.no-ip.org/coologger/version.txt")
                    .Contains(Application.ProductVersion))
                {

                }
                client.Dispose();
            }
            catch
            {
            }
        }

        //Handles all button click events on this form
        private void FBtn_Handler(object sender, EventArgs e)
        {
            switch (Int32.Parse(((FButton)sender).Name.Split('n')[1]))
            {
                case 1:
                    AdvancedForm.Instance.Show();
                    break;
                case 2:
                    ToolForm.Instance.Show();
                    break;
                case 3:
                    SupportForm.Instance.Show();
                    break;
                case 4:
                    ResaleForm.Instance.Show();
                    break;
                case 5:
                    MailSettingsForm.Instance.Show();
                    break;
                case 6:
                    MessageBox.Show("Coded by Meth, graphics by WhyFish");
                    break;
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
