using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestMtgSdkDotnet
{
    public partial class ListOfImages : Form
    {
        public ListOfImages()
        {
            InitializeComponent();
        }

        public void SelectCardInfo(List<CardInfo> cardInfos)
        {
            if (cardInfos.Count == 0)
            {
                return;
            }

            foreach (var cardInfo in cardInfos)
            {
                ImageUtil.CheckJapaneseCardImage(cardInfo);
            }

            ImageUtil.ShowCardImage(cardInfos, SolePictureBox);
        }

        private void ListOfImages_Load(object sender, EventArgs e)
        {
            // 右上のボタンを消す
            ControlBox = false;
        }

        private void CopyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(SolePictureBox.Image);
        }
    }
}
