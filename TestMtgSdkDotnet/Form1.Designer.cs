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
            this.StartInitializeSetInfoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartInitializeSetInfoButton
            // 
            this.StartInitializeSetInfoButton.Location = new System.Drawing.Point(12, 12);
            this.StartInitializeSetInfoButton.Name = "StartInitializeSetInfoButton";
            this.StartInitializeSetInfoButton.Size = new System.Drawing.Size(111, 23);
            this.StartInitializeSetInfoButton.TabIndex = 5;
            this.StartInitializeSetInfoButton.Text = "セット情報取得";
            this.StartInitializeSetInfoButton.UseVisualStyleBackColor = true;
            this.StartInitializeSetInfoButton.Click += new System.EventHandler(this.StartInitializeSetInfoButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 755);
            this.Controls.Add(this.StartInitializeSetInfoButton);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button StartInitializeSetInfoButton;
    }
}

