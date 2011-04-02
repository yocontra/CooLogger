using System;

namespace Coologger
{
    partial class SMTPTab
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Coologger.Pigment pigment1 = new Coologger.Pigment();
            Coologger.Pigment pigment2 = new Coologger.Pigment();
            Coologger.Pigment pigment3 = new Coologger.Pigment();
            Coologger.Pigment pigment4 = new Coologger.Pigment();
            Coologger.Pigment pigment5 = new Coologger.Pigment();
            Coologger.Pigment pigment6 = new Coologger.Pigment();
            Coologger.Pigment pigment7 = new Coologger.Pigment();
            Coologger.Pigment pigment8 = new Coologger.Pigment();
            Coologger.Pigment pigment9 = new Coologger.Pigment();
            Coologger.Pigment pigment10 = new Coologger.Pigment();
            Coologger.Pigment pigment11 = new Coologger.Pigment();
            Coologger.Pigment pigment12 = new Coologger.Pigment();
            Coologger.Pigment pigment13 = new Coologger.Pigment();
            Coologger.Pigment pigment14 = new Coologger.Pigment();
            Coologger.Pigment pigment15 = new Coologger.Pigment();
            this.FTheme1 = new Coologger.FTheme();
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.FButton4 = new Coologger.FButton();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.FTheme1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FTheme1
            // 
            pigment1.Name = "Border";
            pigment1.Value = System.Drawing.Color.Black;
            pigment2.Name = "Frame";
            pigment2.Value = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(50)))));
            pigment3.Name = "Border Highlight";
            pigment3.Value = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            pigment4.Name = "Side Highlight";
            pigment4.Value = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            pigment5.Name = "Shine";
            pigment5.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            pigment6.Name = "Shadow";
            pigment6.Value = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(40)))));
            pigment7.Name = "Backcolor";
            pigment7.Value = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            pigment8.Name = "Transparency";
            pigment8.Value = System.Drawing.Color.Fuchsia;
            this.FTheme1.Colors = new Coologger.Pigment[] {
        pigment1,
        pigment2,
        pigment3,
        pigment4,
        pigment5,
        pigment6,
        pigment7,
        pigment8};
            this.FTheme1.Controls.Add(this.Label1);
            this.FTheme1.Controls.Add(this.TextBox3);
            this.FTheme1.Controls.Add(this.FButton4);
            this.FTheme1.Controls.Add(this.TextBox2);
            this.FTheme1.Controls.Add(this.TextBox1);
            this.FTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FTheme1.Location = new System.Drawing.Point(0, 0);
            this.FTheme1.Name = "FTheme1";
            this.FTheme1.Resizeable = true;
            this.FTheme1.Size = new System.Drawing.Size(301, 150);
            this.FTheme1.TabIndex = 0;
            this.FTheme1.Text = "FTheme1";
            this.FTheme1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Control);
            this.FTheme1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoved_Control);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(102, 48);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(96, 13);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Add custom SMTP";
            // 
            // TextBox3
            // 
            this.TextBox3.Location = new System.Drawing.Point(100, 89);
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Size = new System.Drawing.Size(100, 20);
            this.TextBox3.TabIndex = 10;
            this.TextBox3.Text = "@providerhere";
            // 
            // FButton4
            // 
            pigment9.Name = "Border";
            pigment9.Value = System.Drawing.Color.Black;
            pigment10.Name = "Backcolor";
            pigment10.Value = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            pigment11.Name = "Highlight";
            pigment11.Value = System.Drawing.Color.Transparent;
            pigment12.Name = "Gradient1";
            pigment12.Value = System.Drawing.Color.DeepSkyBlue;
            pigment13.Name = "Gradient2";
            pigment13.Value = System.Drawing.Color.DodgerBlue;
            pigment14.Name = "Text Color";
            pigment14.Value = System.Drawing.Color.White;
            pigment15.Name = "Text Shadow";
            pigment15.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FButton4.Colors = new Coologger.Pigment[] {
        pigment9,
        pigment10,
        pigment11,
        pigment12,
        pigment13,
        pigment14,
        pigment15};
            this.FButton4.Font = new System.Drawing.Font("Verdana", 8F);
            this.FButton4.Location = new System.Drawing.Point(110, 115);
            this.FButton4.Name = "FButton4";
            this.FButton4.Shadow = true;
            this.FButton4.Size = new System.Drawing.Size(75, 17);
            this.FButton4.TabIndex = 9;
            this.FButton4.Text = "Add ";
            this.FButton4.Click += new System.EventHandler(this.FButton4_Click);
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(161, 64);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(100, 20);
            this.TextBox2.TabIndex = 8;
            this.TextBox2.Text = "Port";
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(40, 64);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(100, 20);
            this.TextBox1.TabIndex = 7;
            this.TextBox1.Text = "SMTP Server";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 150);
            this.Controls.Add(this.FTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "COOLogger";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FTheme1.ResumeLayout(false);
            this.FTheme1.PerformLayout();
            this.ResumeLayout(false);

        }
        internal Coologger.FTheme FTheme1;
        internal System.Windows.Forms.TextBox TextBox2;
        internal System.Windows.Forms.TextBox TextBox3;
        internal Coologger.FButton FButton4;
        internal System.Windows.Forms.Label Label1;


        #endregion
        internal System.Windows.Forms.TextBox TextBox1;

    }
}