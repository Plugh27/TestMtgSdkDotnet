namespace TestMtgSdkDotnet
{
    partial class ViewUserInput
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
            this.CardNameLabel = new System.Windows.Forms.Label();
            this.DraftPointLabel = new System.Windows.Forms.Label();
            this.DraftPointNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.CardNameTextBox = new System.Windows.Forms.TextBox();
            this.MemoTextBox = new System.Windows.Forms.TextBox();
            this.MemoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DraftPointNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // CardNameLabel
            // 
            this.CardNameLabel.AutoSize = true;
            this.CardNameLabel.Location = new System.Drawing.Point(29, 9);
            this.CardNameLabel.Name = "CardNameLabel";
            this.CardNameLabel.Size = new System.Drawing.Size(45, 12);
            this.CardNameLabel.TabIndex = 0;
            this.CardNameLabel.Text = "カード名";
            // 
            // DraftPointLabel
            // 
            this.DraftPointLabel.AutoSize = true;
            this.DraftPointLabel.Location = new System.Drawing.Point(12, 37);
            this.DraftPointLabel.Name = "DraftPointLabel";
            this.DraftPointLabel.Size = new System.Drawing.Size(62, 12);
            this.DraftPointLabel.TabIndex = 1;
            this.DraftPointLabel.Text = "ドラフト点数";
            // 
            // DraftPointNumericUpDown
            // 
            this.DraftPointNumericUpDown.Location = new System.Drawing.Point(80, 35);
            this.DraftPointNumericUpDown.Name = "DraftPointNumericUpDown";
            this.DraftPointNumericUpDown.Size = new System.Drawing.Size(120, 19);
            this.DraftPointNumericUpDown.TabIndex = 1;
            this.DraftPointNumericUpDown.ValueChanged += new System.EventHandler(this.DraftPointNumericUpDown_ValueChanged);
            // 
            // CardNameTextBox
            // 
            this.CardNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CardNameTextBox.Location = new System.Drawing.Point(80, 6);
            this.CardNameTextBox.Name = "CardNameTextBox";
            this.CardNameTextBox.Size = new System.Drawing.Size(708, 19);
            this.CardNameTextBox.TabIndex = 0;
            // 
            // MemoTextBox
            // 
            this.MemoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MemoTextBox.Location = new System.Drawing.Point(80, 60);
            this.MemoTextBox.Multiline = true;
            this.MemoTextBox.Name = "MemoTextBox";
            this.MemoTextBox.Size = new System.Drawing.Size(708, 311);
            this.MemoTextBox.TabIndex = 2;
            this.MemoTextBox.TextChanged += new System.EventHandler(this.MemoTextBox_TextChanged);
            // 
            // MemoLabel
            // 
            this.MemoLabel.AutoSize = true;
            this.MemoLabel.Location = new System.Drawing.Point(52, 63);
            this.MemoLabel.Name = "MemoLabel";
            this.MemoLabel.Size = new System.Drawing.Size(22, 12);
            this.MemoLabel.TabIndex = 5;
            this.MemoLabel.Text = "メモ";
            // 
            // ViewUserInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 383);
            this.Controls.Add(this.MemoLabel);
            this.Controls.Add(this.MemoTextBox);
            this.Controls.Add(this.CardNameTextBox);
            this.Controls.Add(this.DraftPointNumericUpDown);
            this.Controls.Add(this.DraftPointLabel);
            this.Controls.Add(this.CardNameLabel);
            this.Name = "ViewUserInput";
            this.Text = "ViewUserInput";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ViewUserInput_FormClosed);
            this.Load += new System.EventHandler(this.ViewUserInput_Load);
            this.Leave += new System.EventHandler(this.ViewUserInput_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.DraftPointNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CardNameLabel;
        private System.Windows.Forms.Label DraftPointLabel;
        private System.Windows.Forms.NumericUpDown DraftPointNumericUpDown;
        private System.Windows.Forms.TextBox CardNameTextBox;
        private System.Windows.Forms.TextBox MemoTextBox;
        private System.Windows.Forms.Label MemoLabel;
    }
}