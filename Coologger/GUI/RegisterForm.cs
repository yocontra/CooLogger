#region Imports

using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Coologger.Check;
using Microsoft.Win32;

#endregion

namespace Coologger.GUI
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        #region Singleton

        private static RegisterForm _instance;
        private static readonly object PadLock = new object();

        public static RegisterForm Instance
        {
            get
            {
                lock (PadLock)
                {
                    return _instance ?? (_instance = new RegisterForm());
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
                Global.HID = hid;
                string ret = RemoteSettings.GrabSetting("getSource.php");
                if (string.IsNullOrEmpty(ret))
                {
                    return false;
                }
                Global.Source = Encoding.Default.GetString(Convert.FromBase64String(ret));
                return true;
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
            catch (Exception)
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
            Global.BeatThread = new Thread(new HeartBeat().Beat);
            Global.BeatThread.Start();

            HIDTextBox.Text = GetHID();
            Global.HID = HIDTextBox.Text;
            HostChecker chk = new HostChecker(true);
            if (!chk.IsValid())
            {
                CrackerCheck.FlagCracker();    
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