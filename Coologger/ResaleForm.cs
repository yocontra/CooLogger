using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Coologger
{
    public partial class ResaleForm : Form
    {
        public ResaleForm()
        {
            InitializeComponent();
        }

        #region Singleton
        static ResaleForm _Instance = null;
        static readonly object PadLock = new object();

        public static ResaleForm Instance
        {
            get
            {
                lock (PadLock)
                {
                    return _Instance ?? (_Instance = new ResaleForm());
                }
            }
        }
        #endregion

        public bool resell(string newhid)
        {
            try
            {
                string lcUrl = "http://coologger.no-ip.org/coologger/" + Global.HID + ".txt";
                HttpWebRequest loHttp = (HttpWebRequest)WebRequest.Create(lcUrl);
                loHttp.Timeout = 10000;
                loHttp.UserAgent = "Check";
                HttpWebResponse loWebResponse = (HttpWebResponse)loHttp.GetResponse();
                Encoding enc = Encoding.GetEncoding(1252);
                StreamReader loResponseStream = new StreamReader(loWebResponse.GetResponseStream(), enc);
                string lcHtml = loResponseStream.ReadToEnd();
                if (lcHtml.Contains(newhid))
                {
                    return false;
                }
                else
                {
                    try
                    {
                        string lcUrl2 = "http://coologger.no-ip.org/coologger/hid.php?oldhid=" + Global.HID + "&newhid=" + newhid;
                        HttpWebRequest loHttp2 = (HttpWebRequest)WebRequest.Create(lcUrl2);
                        loHttp2.Timeout = 10000;
                        loHttp2.UserAgent = "Check";
                        HttpWebResponse loWebResponse2 = (HttpWebResponse)loHttp2.GetResponse();
                        Encoding enc2 = Encoding.GetEncoding(1252);
                        StreamReader loResponseStream2 = new StreamReader(loWebResponse2.GetResponseStream(), enc2);
                        string lcHtml2 = loResponseStream2.ReadToEnd();
                        return !lcHtml2.Contains("Invalid");
                    }
                    catch
                    {
                        return false;
                    }
                }

            }
            catch
            {
                return false;
            }
        }

        private void FButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to transfer your license?",
                "HID Change",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                if (resell(TextBox1.Text))
                {
                    MessageBox.Show("License successfully transferred");
                    Application.Exit();
                }
                MessageBox.Show("License transfer failed");
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FButton2_Click_1(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(Global.HID);
            }
            catch
            {
                MessageBox.Show("Unable to copy HID to clipboard");
            }
        }
    }
}
