﻿using System;
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
    public partial class ViewImage : Form
    {
        public ViewImage()
        {
            InitializeComponent();
        }

        public void SelectCardInfo(List<CardInfo> cardInfos)
        {
            // TODO: 実装
            if (cardInfos.Count == 0)
            {
                return;
            }

            // 先頭のカードのみ表示する
            List<CardInfo> targetCardInfos = new List<CardInfo> { cardInfos.First() };
            CardInfo targetCard = targetCardInfos.First();

            Util.DownloadCardImage(targetCardInfos);

            // 
            string filePath = string.Format(Util._officialCardImageFileNameFormat, targetCard.japaneaseMultiverseId);
            Image baseImage = Image.FromFile(filePath);

            Size baseSize = baseImage.Size;
            int resizeWidth = ClientSize.Width;
            int resizeHeight = (int)(baseSize.Height * (double)resizeWidth / baseSize.Width);

            Bitmap resizeBmp = new Bitmap(resizeWidth, resizeHeight);
            Graphics g = Graphics.FromImage(resizeBmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(baseImage, 0, 0, resizeWidth, resizeHeight);

            SolePictureBox.Width = resizeBmp.Width;
            SolePictureBox.Height = resizeBmp.Height;
            SolePictureBox.Image = resizeBmp;
        }

        private void ViewImage_Load(object sender, EventArgs e)
        {

        }
    }
}