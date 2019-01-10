namespace TestMtgSdkDotnet
{
    partial class ListOfSet
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
            this.components = new System.ComponentModel.Container();
            this.SoleListBox = new System.Windows.Forms.ListBox();
            this.SetListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ReloadSetInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetListContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SoleListBox
            // 
            this.SoleListBox.ContextMenuStrip = this.SetListContextMenuStrip;
            this.SoleListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SoleListBox.FormattingEnabled = true;
            this.SoleListBox.ItemHeight = 12;
            this.SoleListBox.Location = new System.Drawing.Point(0, 0);
            this.SoleListBox.Name = "SoleListBox";
            this.SoleListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.SoleListBox.Size = new System.Drawing.Size(800, 450);
            this.SoleListBox.TabIndex = 0;
            this.SoleListBox.SelectedIndexChanged += new System.EventHandler(this.SoleListBox_SelectedIndexChanged);
            // 
            // SetListContextMenuStrip
            // 
            this.SetListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReloadSetInfoToolStripMenuItem});
            this.SetListContextMenuStrip.Name = "SetListContextMenuStrip";
            this.SetListContextMenuStrip.Size = new System.Drawing.Size(130, 26);
            // 
            // ReloadSetInfoToolStripMenuItem
            // 
            this.ReloadSetInfoToolStripMenuItem.Name = "ReloadSetInfoToolStripMenuItem";
            this.ReloadSetInfoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ReloadSetInfoToolStripMenuItem.Text = "再取得する";
            this.ReloadSetInfoToolStripMenuItem.Click += new System.EventHandler(this.ReloadSetInfoToolStripMenuItem_Click);
            // 
            // ListOfSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SoleListBox);
            this.Name = "ListOfSet";
            this.Text = "ListOfSet";
            this.Load += new System.EventHandler(this.ListOfSet_Load);
            this.SetListContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox SoleListBox;
        private System.Windows.Forms.ContextMenuStrip SetListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ReloadSetInfoToolStripMenuItem;
    }
}