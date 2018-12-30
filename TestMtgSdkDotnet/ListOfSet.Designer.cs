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
            this.SoleListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // SoleListBox
            // 
            this.SoleListBox.FormattingEnabled = true;
            this.SoleListBox.ItemHeight = 12;
            this.SoleListBox.Location = new System.Drawing.Point(12, 13);
            this.SoleListBox.Name = "SoleListBox";
            this.SoleListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.SoleListBox.Size = new System.Drawing.Size(776, 424);
            this.SoleListBox.TabIndex = 0;
            this.SoleListBox.SelectedIndexChanged += new System.EventHandler(this.SoleListBox_SelectedIndexChanged);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox SoleListBox;
    }
}