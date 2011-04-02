#region Imports

using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Win32;

#endregion

namespace Coologger
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        #region Singleton

        private static RegisterForm _Instance;
        private static readonly object PadLock = new object();

        public static RegisterForm Instance
        {
            get
            {
                lock (PadLock)
                {
                    return _Instance ?? (_Instance = new RegisterForm());
                }
            }
        }

        #endregion

        private void FButton1Click(object sender, EventArgs e)
        {
            Clipboard.SetText(HIDTextBox.Text);
            MessageBox.Show("Copied HID to Clipboard");
        }

        private void FButton4Click(object sender, EventArgs e)
        {
            if (Global.Form == Instance &
                (IsValidEmail(PaypalTextBox.Text) || IsValidEmail(SupportEmailTextBox.Text)))
            {
                try
                {
                    if (Register(PaypalTextBox.Text, SupportEmailTextBox.Text, HIDTextBox.Text))
                    {
                        MessageBox.Show("Thank you for registering CooLogger!");
                        MenuForm.Instance.Show();
                        Visible = false;
                        ShowInTaskbar = false;
                        Hide();
                    }
                    MessageBox.Show(
                        "Invalid paypal email or already in use. " +
                        "(Email is case sensitive enter it exactly as registered on paypal)");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        public string GetHID()
        {
            RegistryKey guid = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Cryptography", false);
            return guid != null ? guid.GetValue("MachineGUID").ToString().ToUpper() : "Error Grabbing HID";
        }

        public bool Login(string hid)
        {
            if (Global.Form == Instance)
            {
                try
                {
                    string lcUrl = "http://coologger.no-ip.org/coologger/" + hid + ".txt";
                    var loHttp = (HttpWebRequest) WebRequest.Create(lcUrl);
                    loHttp.Timeout = 10000;
                    loHttp.UserAgent = "Check";
                    var loWebResponse = (HttpWebResponse) loHttp.GetResponse();
                    Encoding enc = Encoding.GetEncoding(1252);
                    var loResponseStream = new StreamReader(loWebResponse.GetResponseStream(), enc);
                    string lcHtml = loResponseStream.ReadToEnd();
                    loWebResponse.Close();
                    loResponseStream.Close();
                    return lcHtml.Contains(hid);
                }
                catch
                {
                }
            }
            return false;
        }

        public bool Register(string paypalemail, string supportemail, string hid)
        {
            try
            {
                string lcUrl = "http://coologger.no-ip.org/coologger/check.php?id=" + paypalemail + "+support=" +
                               supportemail + "+hwid=" + hid;
                var loHttp = (HttpWebRequest) WebRequest.Create(lcUrl);
                loHttp.Timeout = 10000;
                loHttp.UserAgent = "Check";
                var loWebResponse = (HttpWebResponse) loHttp.GetResponse();
                Encoding enc = Encoding.GetEncoding(1252);
                var loResponseStream = new StreamReader(loWebResponse.GetResponseStream(), enc);
                string lcHtml = loResponseStream.ReadToEnd();
                return !lcHtml.Contains("Invalid");
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool IsValidEmail(string email)
        {
            const string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|" +
                                   @"0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z]" +
                                   @"[a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
            Match match =
                Regex.Match(email.Trim(), pattern,
                            RegexOptions.IgnoreCase);

            return match.Success;
        }

        private void Form4Load(object sender, EventArgs e)
        {
            HIDTextBox.Text = GetHID();
            Global.HID = HIDTextBox.Text;
            if (File.Exists(Environment.SystemDirectory + @"\drivers\etc\hosts"))
                if (File.ReadAllText(
                    Environment.SystemDirectory + @"\drivers\etc\hosts")
                    .Contains("coologger.no-ip.org"))
                {
                    MessageBox.Show("Host redirection detected");
                    Hide();
                }
            if (!Login(HIDTextBox.Text)) return;
            Global.HID = HIDTextBox.Text;
            MenuForm.Instance.Show();
            Visible = false;
            ShowInTaskbar = false;
            Hide();
        }

        private void PictureBox2Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region MouseControls

        private Point _lastClick;

        private void MouseMovedControl(object sender, MouseEventArgs e)
        {
        }

        private void MouseDownControl(object sender, MouseEventArgs e)
        {
            _lastClick = new Point(e.X, e.Y);
        }

        #endregion
    }
}