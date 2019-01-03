namespace TestMtgSdkDotnet
{
    partial class ListOfCards
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
            this.SoleListView = new BrightIdeasSoftware.ObjectListView();
            this.CardListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenJapaneaseWikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WhiteCheckBox = new System.Windows.Forms.CheckBox();
            this.BlueCheckBox = new System.Windows.Forms.CheckBox();
            this.BlackCheckBox = new System.Windows.Forms.CheckBox();
            this.RedCheckBox = new System.Windows.Forms.CheckBox();
            this.GreenCheckBox = new System.Windows.Forms.CheckBox();
            this.ColorGroupBox = new System.Windows.Forms.GroupBox();
            this.ColorlessCheckBox = new System.Windows.Forms.CheckBox();
            this.ColorEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.ColorOrRadioButton = new System.Windows.Forms.RadioButton();
            this.ColorAndRadioButton = new System.Windows.Forms.RadioButton();
            this.RarityGroupBox = new System.Windows.Forms.GroupBox();
            this.MythicRareCheckBox = new System.Windows.Forms.CheckBox();
            this.RareCheckBox = new System.Windows.Forms.CheckBox();
            this.UncommonCheckBox = new System.Windows.Forms.CheckBox();
            this.CommonCheckBox = new System.Windows.Forms.CheckBox();
            this.RarityEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.TypeGroupBox = new System.Windows.Forms.GroupBox();
            this.TypeEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.EnchantmentCheckBox = new System.Windows.Forms.CheckBox();
            this.SorceryCheckBox = new System.Windows.Forms.CheckBox();
            this.InstantCheckBox = new System.Windows.Forms.CheckBox();
            this.PlaneswalkerCheckBox = new System.Windows.Forms.CheckBox();
            this.CreatureCheckBox = new System.Windows.Forms.CheckBox();
            this.ItemCountLabel = new System.Windows.Forms.Label();
            this.MultiCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.SoleListView)).BeginInit();
            this.CardListContextMenuStrip.SuspendLayout();
            this.ColorGroupBox.SuspendLayout();
            this.RarityGroupBox.SuspendLayout();
            this.TypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SoleListView
            // 
            this.SoleListView.CellEditUseWholeCell = false;
            this.SoleListView.ContextMenuStrip = this.CardListContextMenuStrip;
            this.SoleListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.SoleListView.Location = new System.Drawing.Point(12, 159);
            this.SoleListView.Name = "SoleListView";
            this.SoleListView.Size = new System.Drawing.Size(1116, 383);
            this.SoleListView.TabIndex = 0;
            this.SoleListView.UseCompatibleStateImageBehavior = false;
            this.SoleListView.View = System.Windows.Forms.View.Details;
            this.SoleListView.SelectedIndexChanged += new System.EventHandler(this.SoleListView_SelectedIndexChanged);
            // 
            // CardListContextMenuStrip
            // 
            this.CardListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenJapaneaseWikiToolStripMenuItem});
            this.CardListContextMenuStrip.Name = "CardListContextMenuStrip";
            this.CardListContextMenuStrip.Size = new System.Drawing.Size(165, 26);
            // 
            // OpenJapaneaseWikiToolStripMenuItem
            // 
            this.OpenJapaneaseWikiToolStripMenuItem.Name = "OpenJapaneaseWikiToolStripMenuItem";
            this.OpenJapaneaseWikiToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.OpenJapaneaseWikiToolStripMenuItem.Text = "日本語Wikiに飛ぶ";
            this.OpenJapaneaseWikiToolStripMenuItem.Click += new System.EventHandler(this.OpenJapaneaseWikiToolStripMenuItem_Click);
            // 
            // WhiteCheckBox
            // 
            this.WhiteCheckBox.AutoSize = true;
            this.WhiteCheckBox.Location = new System.Drawing.Point(6, 40);
            this.WhiteCheckBox.Name = "WhiteCheckBox";
            this.WhiteCheckBox.Size = new System.Drawing.Size(36, 16);
            this.WhiteCheckBox.TabIndex = 1;
            this.WhiteCheckBox.Text = "白";
            this.WhiteCheckBox.UseVisualStyleBackColor = true;
            this.WhiteCheckBox.CheckedChanged += new System.EventHandler(this.ColorFilter_CheckedChanged);
            // 
            // BlueCheckBox
            // 
            this.BlueCheckBox.AutoSize = true;
            this.BlueCheckBox.Location = new System.Drawing.Point(48, 40);
            this.BlueCheckBox.Name = "BlueCheckBox";
            this.BlueCheckBox.Size = new System.Drawing.Size(36, 16);
            this.BlueCheckBox.TabIndex = 2;
            this.BlueCheckBox.Text = "青";
            this.BlueCheckBox.UseVisualStyleBackColor = true;
            this.BlueCheckBox.CheckedChanged += new System.EventHandler(this.ColorFilter_CheckedChanged);
            // 
            // BlackCheckBox
            // 
            this.BlackCheckBox.AutoSize = true;
            this.BlackCheckBox.Location = new System.Drawing.Point(90, 40);
            this.BlackCheckBox.Name = "BlackCheckBox";
            this.BlackCheckBox.Size = new System.Drawing.Size(36, 16);
            this.BlackCheckBox.TabIndex = 3;
            this.BlackCheckBox.Text = "黒";
            this.BlackCheckBox.UseVisualStyleBackColor = true;
            this.BlackCheckBox.CheckedChanged += new System.EventHandler(this.ColorFilter_CheckedChanged);
            // 
            // RedCheckBox
            // 
            this.RedCheckBox.AutoSize = true;
            this.RedCheckBox.Location = new System.Drawing.Point(132, 40);
            this.RedCheckBox.Name = "RedCheckBox";
            this.RedCheckBox.Size = new System.Drawing.Size(36, 16);
            this.RedCheckBox.TabIndex = 4;
            this.RedCheckBox.Text = "赤";
            this.RedCheckBox.UseVisualStyleBackColor = true;
            this.RedCheckBox.CheckedChanged += new System.EventHandler(this.ColorFilter_CheckedChanged);
            // 
            // GreenCheckBox
            // 
            this.GreenCheckBox.AutoSize = true;
            this.GreenCheckBox.Location = new System.Drawing.Point(174, 40);
            this.GreenCheckBox.Name = "GreenCheckBox";
            this.GreenCheckBox.Size = new System.Drawing.Size(36, 16);
            this.GreenCheckBox.TabIndex = 5;
            this.GreenCheckBox.Text = "緑";
            this.GreenCheckBox.UseVisualStyleBackColor = true;
            this.GreenCheckBox.CheckedChanged += new System.EventHandler(this.ColorFilter_CheckedChanged);
            // 
            // ColorGroupBox
            // 
            this.ColorGroupBox.Controls.Add(this.MultiCheckBox);
            this.ColorGroupBox.Controls.Add(this.ColorlessCheckBox);
            this.ColorGroupBox.Controls.Add(this.ColorEnableCheckBox);
            this.ColorGroupBox.Controls.Add(this.ColorOrRadioButton);
            this.ColorGroupBox.Controls.Add(this.ColorAndRadioButton);
            this.ColorGroupBox.Controls.Add(this.WhiteCheckBox);
            this.ColorGroupBox.Controls.Add(this.GreenCheckBox);
            this.ColorGroupBox.Controls.Add(this.BlueCheckBox);
            this.ColorGroupBox.Controls.Add(this.RedCheckBox);
            this.ColorGroupBox.Controls.Add(this.BlackCheckBox);
            this.ColorGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ColorGroupBox.Name = "ColorGroupBox";
            this.ColorGroupBox.Size = new System.Drawing.Size(262, 67);
            this.ColorGroupBox.TabIndex = 6;
            this.ColorGroupBox.TabStop = false;
            this.ColorGroupBox.Text = "色でフィルタ";
            // 
            // ColorlessCheckBox
            // 
            this.ColorlessCheckBox.AutoSize = true;
            this.ColorlessCheckBox.Location = new System.Drawing.Point(216, 40);
            this.ColorlessCheckBox.Name = "ColorlessCheckBox";
            this.ColorlessCheckBox.Size = new System.Drawing.Size(36, 16);
            this.ColorlessCheckBox.TabIndex = 9;
            this.ColorlessCheckBox.Text = "無";
            this.ColorlessCheckBox.UseVisualStyleBackColor = true;
            this.ColorlessCheckBox.CheckedChanged += new System.EventHandler(this.ColorFilter_CheckedChanged);
            // 
            // ColorEnableCheckBox
            // 
            this.ColorEnableCheckBox.AutoSize = true;
            this.ColorEnableCheckBox.Location = new System.Drawing.Point(6, 18);
            this.ColorEnableCheckBox.Name = "ColorEnableCheckBox";
            this.ColorEnableCheckBox.Size = new System.Drawing.Size(48, 16);
            this.ColorEnableCheckBox.TabIndex = 8;
            this.ColorEnableCheckBox.Text = "有効";
            this.ColorEnableCheckBox.UseVisualStyleBackColor = true;
            this.ColorEnableCheckBox.CheckedChanged += new System.EventHandler(this.ColorFilter_CheckedChanged);
            // 
            // ColorOrRadioButton
            // 
            this.ColorOrRadioButton.AutoSize = true;
            this.ColorOrRadioButton.Checked = true;
            this.ColorOrRadioButton.Location = new System.Drawing.Point(113, 18);
            this.ColorOrRadioButton.Name = "ColorOrRadioButton";
            this.ColorOrRadioButton.Size = new System.Drawing.Size(39, 16);
            this.ColorOrRadioButton.TabIndex = 7;
            this.ColorOrRadioButton.TabStop = true;
            this.ColorOrRadioButton.Text = "OR";
            this.ColorOrRadioButton.UseVisualStyleBackColor = true;
            this.ColorOrRadioButton.CheckedChanged += new System.EventHandler(this.ColorFilter_CheckedChanged);
            // 
            // ColorAndRadioButton
            // 
            this.ColorAndRadioButton.AutoSize = true;
            this.ColorAndRadioButton.Location = new System.Drawing.Point(60, 18);
            this.ColorAndRadioButton.Name = "ColorAndRadioButton";
            this.ColorAndRadioButton.Size = new System.Drawing.Size(47, 16);
            this.ColorAndRadioButton.TabIndex = 6;
            this.ColorAndRadioButton.Text = "AND";
            this.ColorAndRadioButton.UseVisualStyleBackColor = true;
            this.ColorAndRadioButton.CheckedChanged += new System.EventHandler(this.ColorFilter_CheckedChanged);
            // 
            // RarityGroupBox
            // 
            this.RarityGroupBox.Controls.Add(this.MythicRareCheckBox);
            this.RarityGroupBox.Controls.Add(this.RareCheckBox);
            this.RarityGroupBox.Controls.Add(this.UncommonCheckBox);
            this.RarityGroupBox.Controls.Add(this.CommonCheckBox);
            this.RarityGroupBox.Controls.Add(this.RarityEnableCheckBox);
            this.RarityGroupBox.Location = new System.Drawing.Point(280, 12);
            this.RarityGroupBox.Name = "RarityGroupBox";
            this.RarityGroupBox.Size = new System.Drawing.Size(261, 67);
            this.RarityGroupBox.TabIndex = 7;
            this.RarityGroupBox.TabStop = false;
            this.RarityGroupBox.Text = "希少度でフィルタ";
            // 
            // MythicRareCheckBox
            // 
            this.MythicRareCheckBox.AutoSize = true;
            this.MythicRareCheckBox.Location = new System.Drawing.Point(184, 40);
            this.MythicRareCheckBox.Name = "MythicRareCheckBox";
            this.MythicRareCheckBox.Size = new System.Drawing.Size(66, 16);
            this.MythicRareCheckBox.TabIndex = 14;
            this.MythicRareCheckBox.Text = "神話レア";
            this.MythicRareCheckBox.UseVisualStyleBackColor = true;
            this.MythicRareCheckBox.CheckedChanged += new System.EventHandler(this.RarityFilter_CheckedChanged);
            // 
            // RareCheckBox
            // 
            this.RareCheckBox.AutoSize = true;
            this.RareCheckBox.Location = new System.Drawing.Point(136, 40);
            this.RareCheckBox.Name = "RareCheckBox";
            this.RareCheckBox.Size = new System.Drawing.Size(42, 16);
            this.RareCheckBox.TabIndex = 13;
            this.RareCheckBox.Text = "レア";
            this.RareCheckBox.UseVisualStyleBackColor = true;
            this.RareCheckBox.CheckedChanged += new System.EventHandler(this.RarityFilter_CheckedChanged);
            // 
            // UncommonCheckBox
            // 
            this.UncommonCheckBox.AutoSize = true;
            this.UncommonCheckBox.Location = new System.Drawing.Point(62, 40);
            this.UncommonCheckBox.Name = "UncommonCheckBox";
            this.UncommonCheckBox.Size = new System.Drawing.Size(68, 16);
            this.UncommonCheckBox.TabIndex = 12;
            this.UncommonCheckBox.Text = "アンコモン";
            this.UncommonCheckBox.UseVisualStyleBackColor = true;
            this.UncommonCheckBox.CheckedChanged += new System.EventHandler(this.RarityFilter_CheckedChanged);
            // 
            // CommonCheckBox
            // 
            this.CommonCheckBox.AutoSize = true;
            this.CommonCheckBox.Location = new System.Drawing.Point(6, 40);
            this.CommonCheckBox.Name = "CommonCheckBox";
            this.CommonCheckBox.Size = new System.Drawing.Size(50, 16);
            this.CommonCheckBox.TabIndex = 11;
            this.CommonCheckBox.Text = "コモン";
            this.CommonCheckBox.UseVisualStyleBackColor = true;
            this.CommonCheckBox.CheckedChanged += new System.EventHandler(this.RarityFilter_CheckedChanged);
            // 
            // RarityEnableCheckBox
            // 
            this.RarityEnableCheckBox.AutoSize = true;
            this.RarityEnableCheckBox.Location = new System.Drawing.Point(6, 18);
            this.RarityEnableCheckBox.Name = "RarityEnableCheckBox";
            this.RarityEnableCheckBox.Size = new System.Drawing.Size(48, 16);
            this.RarityEnableCheckBox.TabIndex = 10;
            this.RarityEnableCheckBox.Text = "有効";
            this.RarityEnableCheckBox.UseVisualStyleBackColor = true;
            this.RarityEnableCheckBox.CheckedChanged += new System.EventHandler(this.RarityFilter_CheckedChanged);
            // 
            // TypeGroupBox
            // 
            this.TypeGroupBox.Controls.Add(this.TypeEnableCheckBox);
            this.TypeGroupBox.Controls.Add(this.EnchantmentCheckBox);
            this.TypeGroupBox.Controls.Add(this.SorceryCheckBox);
            this.TypeGroupBox.Controls.Add(this.InstantCheckBox);
            this.TypeGroupBox.Controls.Add(this.PlaneswalkerCheckBox);
            this.TypeGroupBox.Controls.Add(this.CreatureCheckBox);
            this.TypeGroupBox.Location = new System.Drawing.Point(12, 85);
            this.TypeGroupBox.Name = "TypeGroupBox";
            this.TypeGroupBox.Size = new System.Drawing.Size(529, 68);
            this.TypeGroupBox.TabIndex = 8;
            this.TypeGroupBox.TabStop = false;
            this.TypeGroupBox.Text = "タイプでフィルタ";
            // 
            // TypeEnableCheckBox
            // 
            this.TypeEnableCheckBox.AutoSize = true;
            this.TypeEnableCheckBox.Location = new System.Drawing.Point(6, 18);
            this.TypeEnableCheckBox.Name = "TypeEnableCheckBox";
            this.TypeEnableCheckBox.Size = new System.Drawing.Size(48, 16);
            this.TypeEnableCheckBox.TabIndex = 10;
            this.TypeEnableCheckBox.Text = "有効";
            this.TypeEnableCheckBox.UseVisualStyleBackColor = true;
            this.TypeEnableCheckBox.CheckedChanged += new System.EventHandler(this.TypeFilter_CheckedChanged);
            // 
            // EnchantmentCheckBox
            // 
            this.EnchantmentCheckBox.AutoSize = true;
            this.EnchantmentCheckBox.Location = new System.Drawing.Point(368, 40);
            this.EnchantmentCheckBox.Name = "EnchantmentCheckBox";
            this.EnchantmentCheckBox.Size = new System.Drawing.Size(76, 16);
            this.EnchantmentCheckBox.TabIndex = 4;
            this.EnchantmentCheckBox.Text = "エンチャント";
            this.EnchantmentCheckBox.UseVisualStyleBackColor = true;
            this.EnchantmentCheckBox.CheckedChanged += new System.EventHandler(this.TypeFilter_CheckedChanged);
            // 
            // SorceryCheckBox
            // 
            this.SorceryCheckBox.AutoSize = true;
            this.SorceryCheckBox.Location = new System.Drawing.Point(292, 40);
            this.SorceryCheckBox.Name = "SorceryCheckBox";
            this.SorceryCheckBox.Size = new System.Drawing.Size(70, 16);
            this.SorceryCheckBox.TabIndex = 3;
            this.SorceryCheckBox.Text = "ソーサリー";
            this.SorceryCheckBox.UseVisualStyleBackColor = true;
            this.SorceryCheckBox.CheckedChanged += new System.EventHandler(this.TypeFilter_CheckedChanged);
            // 
            // InstantCheckBox
            // 
            this.InstantCheckBox.AutoSize = true;
            this.InstantCheckBox.Location = new System.Drawing.Point(210, 40);
            this.InstantCheckBox.Name = "InstantCheckBox";
            this.InstantCheckBox.Size = new System.Drawing.Size(76, 16);
            this.InstantCheckBox.TabIndex = 2;
            this.InstantCheckBox.Text = "インスタント";
            this.InstantCheckBox.UseVisualStyleBackColor = true;
            this.InstantCheckBox.CheckedChanged += new System.EventHandler(this.TypeFilter_CheckedChanged);
            // 
            // PlaneswalkerCheckBox
            // 
            this.PlaneswalkerCheckBox.AutoSize = true;
            this.PlaneswalkerCheckBox.Location = new System.Drawing.Point(88, 40);
            this.PlaneswalkerCheckBox.Name = "PlaneswalkerCheckBox";
            this.PlaneswalkerCheckBox.Size = new System.Drawing.Size(116, 16);
            this.PlaneswalkerCheckBox.TabIndex = 1;
            this.PlaneswalkerCheckBox.Text = "プレインズウォーカー";
            this.PlaneswalkerCheckBox.UseVisualStyleBackColor = true;
            this.PlaneswalkerCheckBox.CheckedChanged += new System.EventHandler(this.TypeFilter_CheckedChanged);
            // 
            // CreatureCheckBox
            // 
            this.CreatureCheckBox.AutoSize = true;
            this.CreatureCheckBox.Location = new System.Drawing.Point(6, 40);
            this.CreatureCheckBox.Name = "CreatureCheckBox";
            this.CreatureCheckBox.Size = new System.Drawing.Size(76, 16);
            this.CreatureCheckBox.TabIndex = 0;
            this.CreatureCheckBox.Text = "クリーチャー";
            this.CreatureCheckBox.UseVisualStyleBackColor = true;
            this.CreatureCheckBox.CheckedChanged += new System.EventHandler(this.TypeFilter_CheckedChanged);
            // 
            // ItemCountLabel
            // 
            this.ItemCountLabel.AutoSize = true;
            this.ItemCountLabel.Location = new System.Drawing.Point(547, 141);
            this.ItemCountLabel.Name = "ItemCountLabel";
            this.ItemCountLabel.Size = new System.Drawing.Size(41, 12);
            this.ItemCountLabel.TabIndex = 9;
            this.ItemCountLabel.Text = "項目数";
            // 
            // MultiCheckBox
            // 
            this.MultiCheckBox.AutoSize = true;
            this.MultiCheckBox.Location = new System.Drawing.Point(216, 18);
            this.MultiCheckBox.Name = "MultiCheckBox";
            this.MultiCheckBox.Size = new System.Drawing.Size(36, 16);
            this.MultiCheckBox.TabIndex = 10;
            this.MultiCheckBox.Text = "金";
            this.MultiCheckBox.UseVisualStyleBackColor = true;
            // 
            // ListOfCards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 554);
            this.Controls.Add(this.ItemCountLabel);
            this.Controls.Add(this.TypeGroupBox);
            this.Controls.Add(this.RarityGroupBox);
            this.Controls.Add(this.ColorGroupBox);
            this.Controls.Add(this.SoleListView);
            this.Name = "ListOfCards";
            this.Text = "ListOfCards";
            this.Load += new System.EventHandler(this.ListOfCards_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SoleListView)).EndInit();
            this.CardListContextMenuStrip.ResumeLayout(false);
            this.ColorGroupBox.ResumeLayout(false);
            this.ColorGroupBox.PerformLayout();
            this.RarityGroupBox.ResumeLayout(false);
            this.RarityGroupBox.PerformLayout();
            this.TypeGroupBox.ResumeLayout(false);
            this.TypeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView SoleListView;
        private System.Windows.Forms.ContextMenuStrip CardListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem OpenJapaneaseWikiToolStripMenuItem;
        private System.Windows.Forms.CheckBox WhiteCheckBox;
        private System.Windows.Forms.CheckBox BlueCheckBox;
        private System.Windows.Forms.CheckBox BlackCheckBox;
        private System.Windows.Forms.CheckBox RedCheckBox;
        private System.Windows.Forms.CheckBox GreenCheckBox;
        private System.Windows.Forms.GroupBox ColorGroupBox;
        private System.Windows.Forms.CheckBox ColorlessCheckBox;
        private System.Windows.Forms.CheckBox ColorEnableCheckBox;
        private System.Windows.Forms.RadioButton ColorOrRadioButton;
        private System.Windows.Forms.RadioButton ColorAndRadioButton;
        private System.Windows.Forms.GroupBox RarityGroupBox;
        private System.Windows.Forms.CheckBox MythicRareCheckBox;
        private System.Windows.Forms.CheckBox RareCheckBox;
        private System.Windows.Forms.CheckBox UncommonCheckBox;
        private System.Windows.Forms.CheckBox CommonCheckBox;
        private System.Windows.Forms.CheckBox RarityEnableCheckBox;
        private System.Windows.Forms.GroupBox TypeGroupBox;
        private System.Windows.Forms.CheckBox TypeEnableCheckBox;
        private System.Windows.Forms.CheckBox EnchantmentCheckBox;
        private System.Windows.Forms.CheckBox SorceryCheckBox;
        private System.Windows.Forms.CheckBox InstantCheckBox;
        private System.Windows.Forms.CheckBox PlaneswalkerCheckBox;
        private System.Windows.Forms.CheckBox CreatureCheckBox;
        private System.Windows.Forms.Label ItemCountLabel;
        private System.Windows.Forms.CheckBox MultiCheckBox;
    }
}