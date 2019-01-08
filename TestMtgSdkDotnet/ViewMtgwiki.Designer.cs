namespace TestMtgSdkDotnet
{
    partial class ViewMtgwiki
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
            this.SoleWebBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // SoleWebBrowser
            // 
            this.SoleWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SoleWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.SoleWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.SoleWebBrowser.Name = "SoleWebBrowser";
            this.SoleWebBrowser.Size = new System.Drawing.Size(800, 450);
            this.SoleWebBrowser.TabIndex = 0;
            // 
            // ViewMtgwiki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SoleWebBrowser);
            this.Name = "ViewMtgwiki";
            this.Text = "ViewMtgwiki";
            this.Load += new System.EventHandler(this.ViewMtgwiki_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser SoleWebBrowser;
    }
}