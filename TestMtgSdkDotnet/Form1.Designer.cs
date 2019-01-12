namespace TestMtgSdkDotnet
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.SoleMenuStrip = new System.Windows.Forms.MenuStrip();
            this.WindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SoleMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SoleMenuStrip
            // 
            this.SoleMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WindowToolStripMenuItem});
            this.SoleMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.SoleMenuStrip.MdiWindowListItem = this.WindowToolStripMenuItem;
            this.SoleMenuStrip.Name = "SoleMenuStrip";
            this.SoleMenuStrip.Size = new System.Drawing.Size(1323, 24);
            this.SoleMenuStrip.TabIndex = 1;
            this.SoleMenuStrip.Text = "menuStrip1";
            // 
            // WindowToolStripMenuItem
            // 
            this.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem";
            this.WindowToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.WindowToolStripMenuItem.Text = "ウィンドウ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 755);
            this.Controls.Add(this.SoleMenuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.SoleMenuStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SoleMenuStrip.ResumeLayout(false);
            this.SoleMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip SoleMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem WindowToolStripMenuItem;
    }
}

