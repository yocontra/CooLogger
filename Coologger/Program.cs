using System;
using Coologger.GUI;

[assembly: System.Runtime.CompilerServices.SuppressIldasm]

namespace Coologger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Check that the SuppressIldasmAttribute is still applied & the SNK hasn't been removed/tampered
            //Extra code is to mess w/ decompilers like to reflector (which doesn't handle this correctly & displays the wrong output)
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            string key = Main('\0');
            if (Attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(),
                typeof(System.Runtime.CompilerServices.SuppressIldasmAttribute)) == null || key != "c34aa792f5f7753c")
            {
                //goto Label_0; 
                try
                {
                    key = key.Substring(18).Replace("4", "3");
                    Global.Form = SMTPTab.Instance;
                    System.Windows.Forms.Application.Run(new SMTPTab());
                    if (key != "c34aa792f5f7753c")
                    {
                        goto Label_1;
                    }
                }
                catch
                {
                    Global.Form = RegisterForm.Instance;
                    System.Windows.Forms.Application.Run(new RegisterForm());
                    goto Label_3;
                }
            }
        Label_1: { key = key.Substring(13).Replace("4", "3"); goto Label_2; }
        Label_0:
            try
            {
                key = key.Substring(17).Replace("4", "3");
                Global.Form = SMTPTab.Instance;
                System.Windows.Forms.Application.Run(new SMTPTab());
                if (key == "c34aa792f5f7753c")
                {
                    goto Label_1;
                }
            }
            catch
            {
                Global.Form = RegisterForm.Instance;
                System.Windows.Forms.Application.Run(new RegisterForm());
                goto Label_3;
            }
        //Label_1: { key = key.Substring(16).Replace("4", "3"); goto Label_2; }
        Label_2:
            {
                key = key.Substring(1).Replace("4", "3");
                goto Label_0; return;
            }
        Label_3:
            return;
        }

        static string Main(char c)
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetCallingAssembly();
            string sb = null;
            int i = 0;
            byte[] pt = myAssembly.GetName().GetPublicKeyToken();
            for (i = 0; i <= (pt.Length - 1); i++)
            {
                sb += pt[i].ToString("x");
            }
            myAssembly = null;
            return sb;
        }
    }
}
