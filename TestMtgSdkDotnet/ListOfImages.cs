using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMtgSdkDotnet
{
    public partial class ListOfImages : Form
    {
        public ListOfImages()
        {
            InitializeComponent();
        }

        public void SelectCard(List<CardInfo> cardInfos)
        {
            if (cardInfos.Count == 0)
            {
                return;
            }

            Util.DownloadCardImage(cardInfos);

            Util.ShowCardImage(cardInfos, SolePictureBox);
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
