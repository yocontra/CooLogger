using System;
using System.Windows.Forms;

namespace Coologger.GUI
{
    public partial class ProcessSelector : Form
    {
        public ProcessSelector()
        {
            InitializeComponent();
        }

        #region Singleton
        static ProcessSelector _Instance = null;
        static readonly object PadLock = new object();

        public static ProcessSelector Instance
        {
            get
            {
                lock (PadLock)
                {
                    return _Instance ?? (_Instance = new ProcessSelector());
                }
            }
        }
        #endregion

        private void Button1_Click(object sender, EventArgs e)
        {
            AdvancedForm.Instance.Process = TextBox1.Text;
            this.Hide();
        }
    }
}
