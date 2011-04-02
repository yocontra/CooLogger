using System;
using Microsoft.VisualBasic;

namespace Coologger
{
    partial class SupportForm
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
            this.PictureBox3 = new System.Windows.Forms.PictureBox();
            this.RichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.FButton1 = new Coologger.FButton();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox3
            // 
            this.PictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox3.Location = new System.Drawing.Point(251, 8);
            this.PictureBox3.Name = "PictureBox3";
            this.PictureBox3.Size = new System.Drawing.Size(15, 15);
            this.PictureBox3.TabIndex = 28;
            this.PictureBox3.TabStop = false;
            // 
            // RichTextBox1
            // 
            this.RichTextBox1.BackColor = System.Drawing.Color.Black;
            this.RichTextBox1.ForeColor = System.Drawing.Color.White;
            this.RichTextBox1.Location = new System.Drawing.Point(29, 132);
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.Size = new System.Drawing.Size(225, 94);
            this.RichTextBox1.TabIndex = 29;
            this.RichTextBox1.Text = "When submitting a support ticket please leave the following\n- Problem and/or sugg" +
                "estion\n- Paypal Email\n- Email (If you would like to be contacted)\n";
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(246, 23);
            this.PictureBox1.TabIndex = 31;
            this.PictureBox1.TabStop = false;
            // 
            // PictureBox2
            // 
            this.PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox2.Location = new System.Drawing.Point(244, 0);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(26, 23);
            this.PictureBox2.TabIndex = 32;
            this.PictureBox2.TabStop = false;
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
            pigment5.Value = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(68)))), ((int)(((byte)(0)))));
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
            this.FButton1.Location = new System.Drawing.Point(106, 233);
            this.FButton1.Name = "FButton1";
            this.FButton1.Shadow = true;
            this.FButton1.Size = new System.Drawing.Size(81, 19);
            this.FButton1.TabIndex = 30;
            this.FButton1.Text = "Submit";
            // 
            // Support
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Coologger.Properties.Resources.HIDPreview;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.PictureBox2);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.FButton1);
            this.Controls.Add(this.RichTextBox1);
            this.Controls.Add(this.PictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Support";
            this.Text = "Support";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Control);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoved_Control);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.PictureBox PictureBox3;
        internal System.Windows.Forms.RichTextBox RichTextBox1;
        internal Coologger.FButton FButton1;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.PictureBox PictureBox2;



        #endregion
    }
}