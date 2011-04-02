using System;
using Microsoft.VisualBasic;

namespace Coologger
{
    partial class MailSettingsForm
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
            Coologger.Pigment pigment16 = new Coologger.Pigment();
            Coologger.Pigment pigment17 = new Coologger.Pigment();
            Coologger.Pigment pigment18 = new Coologger.Pigment();
            Coologger.Pigment pigment19 = new Coologger.Pigment();
            Coologger.Pigment pigment20 = new Coologger.Pigment();
            Coologger.Pigment pigment21 = new Coologger.Pigment();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.NumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.CheckBox7 = new System.Windows.Forms.CheckBox();
            this.CheckBox6 = new System.Windows.Forms.CheckBox();
            this.CheckBox5 = new System.Windows.Forms.CheckBox();
            this.CheckBox3 = new System.Windows.Forms.CheckBox();
            this.CheckBox2 = new System.Windows.Forms.CheckBox();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.FButton1 = new Coologger.FButton();
            this.FButton4 = new Coologger.FButton();
            this.FButton5 = new Coologger.FButton();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboBox1
            // 
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Items.AddRange(new object[] {
            "@gmail.com",
            "@live.com",
            "@hotmail.com"});
            this.ComboBox1.Location = new System.Drawing.Point(161, 147);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(75, 21);
            this.ComboBox1.TabIndex = 14;
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(55, 173);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.PasswordChar = '*';
            this.TextBox2.Size = new System.Drawing.Size(100, 20);
            this.TextBox2.TabIndex = 12;
            this.TextBox2.Text = "Password";
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(55, 147);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(100, 20);
            this.TextBox1.TabIndex = 11;
            this.TextBox1.Text = "Enter email address";
            // 
            // NumericUpDown1
            // 
            this.NumericUpDown1.BackColor = System.Drawing.Color.Black;
            this.NumericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumericUpDown1.ForeColor = System.Drawing.Color.White;
            this.NumericUpDown1.Location = new System.Drawing.Point(204, 323);
            this.NumericUpDown1.Name = "NumericUpDown1";
            this.NumericUpDown1.Size = new System.Drawing.Size(43, 16);
            this.NumericUpDown1.TabIndex = 23;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(52, 322);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(150, 13);
            this.Label1.TabIndex = 22;
            this.Label1.Text = "Log Sending Interval (minutes)";
            // 
            // CheckBox7
            // 
            this.CheckBox7.AutoSize = true;
            this.CheckBox7.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox7.ForeColor = System.Drawing.Color.White;
            this.CheckBox7.Location = new System.Drawing.Point(67, 258);
            this.CheckBox7.Name = "CheckBox7";
            this.CheckBox7.Size = new System.Drawing.Size(83, 17);
            this.CheckBox7.TabIndex = 21;
            this.CheckBox7.Text = "Send SShot";
            this.CheckBox7.UseVisualStyleBackColor = false;
            // 
            // CheckBox6
            // 
            this.CheckBox6.AutoSize = true;
            this.CheckBox6.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox6.ForeColor = System.Drawing.Color.White;
            this.CheckBox6.Location = new System.Drawing.Point(174, 302);
            this.CheckBox6.Name = "CheckBox6";
            this.CheckBox6.Size = new System.Drawing.Size(60, 17);
            this.CheckBox6.TabIndex = 20;
            this.CheckBox6.Text = "Startup";
            this.CheckBox6.UseVisualStyleBackColor = false;
            // 
            // CheckBox5
            // 
            this.CheckBox5.AutoSize = true;
            this.CheckBox5.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox5.ForeColor = System.Drawing.Color.White;
            this.CheckBox5.Location = new System.Drawing.Point(174, 256);
            this.CheckBox5.Name = "CheckBox5";
            this.CheckBox5.Size = new System.Drawing.Size(46, 17);
            this.CheckBox5.TabIndex = 19;
            this.CheckBox5.Text = "Melt";
            this.CheckBox5.UseVisualStyleBackColor = false;
            // 
            // CheckBox3
            // 
            this.CheckBox3.AutoSize = true;
            this.CheckBox3.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox3.ForeColor = System.Drawing.Color.White;
            this.CheckBox3.Location = new System.Drawing.Point(67, 302);
            this.CheckBox3.Name = "CheckBox3";
            this.CheckBox3.Size = new System.Drawing.Size(106, 17);
            this.CheckBox3.TabIndex = 18;
            this.CheckBox3.Text = "Disable TaskMgr";
            this.CheckBox3.UseVisualStyleBackColor = false;
            // 
            // CheckBox2
            // 
            this.CheckBox2.AutoSize = true;
            this.CheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox2.ForeColor = System.Drawing.Color.White;
            this.CheckBox2.Location = new System.Drawing.Point(67, 279);
            this.CheckBox2.Name = "CheckBox2";
            this.CheckBox2.Size = new System.Drawing.Size(102, 17);
            this.CheckBox2.TabIndex = 17;
            this.CheckBox2.Text = "Disable RegEdit";
            this.CheckBox2.UseVisualStyleBackColor = false;
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox1.ForeColor = System.Drawing.Color.White;
            this.CheckBox1.Location = new System.Drawing.Point(174, 279);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(85, 17);
            this.CheckBox1.TabIndex = 16;
            this.CheckBox1.Text = "DisableCMD";
            this.CheckBox1.UseVisualStyleBackColor = false;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(109, 131);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(87, 13);
            this.Label2.TabIndex = 25;
            this.Label2.Text = "Email Settings";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(124, 235);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(50, 13);
            this.Label3.TabIndex = 26;
            this.Label3.Text = "Options";
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox1.Location = new System.Drawing.Point(-1, 3);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(260, 21);
            this.PictureBox1.TabIndex = 28;
            this.PictureBox1.TabStop = false;
            this.PictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Control);
            this.PictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoved_Control);
            // 
            // PictureBox2
            // 
            this.PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox2.Location = new System.Drawing.Point(264, 1);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(23, 21);
            this.PictureBox2.TabIndex = 29;
            this.PictureBox2.TabStop = false;
            this.PictureBox2.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // FButton1
            // 
            pigment1.Name = "Border";
            pigment1.Value = System.Drawing.Color.Black;
            pigment2.Name = "Backcolor";
            pigment2.Value = System.Drawing.Color.Black;
            pigment3.Name = "Highlight";
            pigment3.Value = System.Drawing.Color.Transparent;
            pigment4.Name = "Gradient1";
            pigment4.Value = System.Drawing.Color.LimeGreen;
            pigment5.Name = "Gradient2";
            pigment5.Value = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(88)))), ((int)(((byte)(0)))));
            pigment6.Name = "Text Color";
            pigment6.Value = System.Drawing.Color.White;
            pigment7.Name = "Text Shadow";
            pigment7.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FButton1.Colors = new Coologger.Pigment[] {
        pigment1,
        pigment2,
        pigment3,
        pigment4,
        pigment5,
        pigment6,
        pigment7};
            this.FButton1.Font = new System.Drawing.Font("Verdana", 8F);
            this.FButton1.Location = new System.Drawing.Point(112, 346);
            this.FButton1.Name = "FButton1";
            this.FButton1.Shadow = true;
            this.FButton1.Size = new System.Drawing.Size(75, 26);
            this.FButton1.TabIndex = 27;
            this.FButton1.Text = "Build";
            this.FButton1.Click += new System.EventHandler(this.FButton1_Click);
            // 
            // FButton4
            // 
            pigment8.Name = "Border";
            pigment8.Value = System.Drawing.Color.Black;
            pigment9.Name = "Backcolor";
            pigment9.Value = System.Drawing.Color.Black;
            pigment10.Name = "Highlight";
            pigment10.Value = System.Drawing.Color.Transparent;
            pigment11.Name = "Gradient1";
            pigment11.Value = System.Drawing.Color.LimeGreen;
            pigment12.Name = "Gradient2";
            pigment12.Value = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(88)))), ((int)(((byte)(0)))));
            pigment13.Name = "Text Color";
            pigment13.Value = System.Drawing.Color.White;
            pigment14.Name = "Text Shadow";
            pigment14.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FButton4.Colors = new Coologger.Pigment[] {
        pigment8,
        pigment9,
        pigment10,
        pigment11,
        pigment12,
        pigment13,
        pigment14};
            this.FButton4.Font = new System.Drawing.Font("Verdana", 8F);
            this.FButton4.Location = new System.Drawing.Point(112, 204);
            this.FButton4.Name = "FButton4";
            this.FButton4.Shadow = true;
            this.FButton4.Size = new System.Drawing.Size(75, 17);
            this.FButton4.TabIndex = 13;
            this.FButton4.Text = "Add SMTP";
            this.FButton4.Click += new System.EventHandler(this.FButton4_Click);
            // 
            // FButton5
            // 
            pigment15.Name = "Border";
            pigment15.Value = System.Drawing.Color.Black;
            pigment16.Name = "Backcolor";
            pigment16.Value = System.Drawing.Color.Black;
            pigment17.Name = "Highlight";
            pigment17.Value = System.Drawing.Color.Transparent;
            pigment18.Name = "Gradient1";
            pigment18.Value = System.Drawing.Color.LimeGreen;
            pigment19.Name = "Gradient2";
            pigment19.Value = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(88)))), ((int)(((byte)(0)))));
            pigment20.Name = "Text Color";
            pigment20.Value = System.Drawing.Color.White;
            pigment21.Name = "Text Shadow";
            pigment21.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FButton5.Colors = new Coologger.Pigment[] {
        pigment15,
        pigment16,
        pigment17,
        pigment18,
        pigment19,
        pigment20,
        pigment21};
            this.FButton5.Font = new System.Drawing.Font("Verdana", 8F);
            this.FButton5.Location = new System.Drawing.Point(161, 174);
            this.FButton5.Name = "FButton5";
            this.FButton5.Shadow = true;
            this.FButton5.Size = new System.Drawing.Size(75, 19);
            this.FButton5.TabIndex = 15;
            this.FButton5.Text = "Test Email";
            this.FButton5.Click += new System.EventHandler(this.FButton5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Coologger.Properties.Resources.Basic_Setup_Preview;
            this.ClientSize = new System.Drawing.Size(299, 408);
            this.Controls.Add(this.PictureBox2);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.FButton1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.NumericUpDown1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.CheckBox7);
            this.Controls.Add(this.CheckBox6);
            this.Controls.Add(this.CheckBox5);
            this.Controls.Add(this.CheckBox3);
            this.Controls.Add(this.CheckBox2);
            this.Controls.Add(this.CheckBox1);
            this.Controls.Add(this.FButton4);
            this.Controls.Add(this.FButton5);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Builder";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Control);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoved_Control);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal Coologger.FButton FButton4;
        internal Coologger.FButton FButton5;
        internal System.Windows.Forms.ComboBox ComboBox1;
        internal System.Windows.Forms.TextBox TextBox2;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.NumericUpDown NumericUpDown1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.CheckBox CheckBox7;
        internal System.Windows.Forms.CheckBox CheckBox6;
        internal System.Windows.Forms.CheckBox CheckBox5;
        internal System.Windows.Forms.CheckBox CheckBox3;
        internal System.Windows.Forms.CheckBox CheckBox2;
        internal System.Windows.Forms.CheckBox CheckBox1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal Coologger.FButton FButton1;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.PictureBox PictureBox2;


        #endregion
    }
}

