namespace TestMtgSdkDotnet
{
    partial class ViewImage
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
            this.SolePictureBox = new System.Windows.Forms.PictureBox();
            this.ImageContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.JapaneseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnglishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScryfallJapaneseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScryfallEnglishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.SolePictureBox)).BeginInit();
            this.ImageContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SolePictureBox
            // 
            this.SolePictureBox.ContextMenuStrip = this.ImageContextMenuStrip;
            this.SolePictureBox.Location = new System.Drawing.Point(0, 0);
            this.SolePictureBox.Name = "SolePictureBox";
            this.SolePictureBox.Size = new System.Drawing.Size(405, 277);
            this.SolePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SolePictureBox.TabIndex = 0;
            this.SolePictureBox.TabStop = false;
            // 
            // ImageContextMenuStrip
            // 
            this.ImageContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyToClipboardToolStripMenuItem,
            this.JapaneseToolStripMenuItem,
            this.EnglishToolStripMenuItem,
            this.ScryfallJapaneseToolStripMenuItem,
            this.ScryfallEnglishToolStripMenuItem});
            this.ImageContextMenuStrip.Name = "ImageContextMenuStrip";
            this.ImageContextMenuStrip.Size = new System.Drawing.Size(181, 136);
            // 
            // JapaneseToolStripMenuItem
            // 
            this.JapaneseToolStripMenuItem.Name = "JapaneseToolStripMenuItem";
            this.JapaneseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.JapaneseToolStripMenuItem.Text = "日本語";
            this.JapaneseToolStripMenuItem.Click += new System.EventHandler(this.JapaneseToolStripMenuItem_Click);
            // 
            // EnglishToolStripMenuItem
            // 
            this.EnglishToolStripMenuItem.Name = "EnglishToolStripMenuItem";
            this.EnglishToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.EnglishToolStripMenuItem.Text = "英語";
            this.EnglishToolStripMenuItem.Click += new System.EventHandler(this.EnglishToolStripMenuItem_Click);
            // 
            // ScryfallJapaneseToolStripMenuItem
            // 
            this.ScryfallJapaneseToolStripMenuItem.Name = "ScryfallJapaneseToolStripMenuItem";
            this.ScryfallJapaneseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ScryfallJapaneseToolStripMenuItem.Text = "Scryfall（日本語）";
            this.ScryfallJapaneseToolStripMenuItem.Click += new System.EventHandler(this.ScryfallJapaneseToolStripMenuItem_Click);
            // 
            // ScryfallEnglishToolStripMenuItem
            // 
            this.ScryfallEnglishToolStripMenuItem.Name = "ScryfallEnglishToolStripMenuItem";
            this.ScryfallEnglishToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ScryfallEnglishToolStripMenuItem.Text = "Scryfall（英語）";
            this.ScryfallEnglishToolStripMenuItem.Click += new System.EventHandler(this.ScryfallEnglishToolStripMenuItem_Click);
            // 
            // CopyToClipboardToolStripMenuItem
            // 
            this.CopyToClipboardToolStripMenuItem.Name = "CopyToClipboardToolStripMenuItem";
            this.CopyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CopyToClipboardToolStripMenuItem.Text = "クリップボードにコピー";
            this.CopyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.CopyToClipboardToolStripMenuItem_Click);
            // 
            // ViewImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 289);
            this.Controls.Add(this.SolePictureBox);
            this.Name = "ViewImage";
            this.Text = "カード画像";
            this.Load += new System.EventHandler(this.ViewImage_Load);
            this.SizeChanged += new System.EventHandler(this.ViewImage_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.SolePictureBox)).EndInit();
            this.ImageContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SolePictureBox;
        private System.Windows.Forms.ContextMenuStrip ImageContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem JapaneseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EnglishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScryfallJapaneseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScryfallEnglishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyToClipboardToolStripMenuItem;
    }
}