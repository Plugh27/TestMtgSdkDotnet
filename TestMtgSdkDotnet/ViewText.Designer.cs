﻿namespace TestMtgSdkDotnet
{
    partial class ViewText
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
            this.SoleTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SoleTextBox
            // 
            this.SoleTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SoleTextBox.Location = new System.Drawing.Point(0, 0);
            this.SoleTextBox.Multiline = true;
            this.SoleTextBox.Name = "SoleTextBox";
            this.SoleTextBox.Size = new System.Drawing.Size(800, 450);
            this.SoleTextBox.TabIndex = 0;
            // 
            // ViewText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SoleTextBox);
            this.Name = "ViewText";
            this.Text = "カードテキスト";
            this.Load += new System.EventHandler(this.ViewText_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SoleTextBox;
    }
}