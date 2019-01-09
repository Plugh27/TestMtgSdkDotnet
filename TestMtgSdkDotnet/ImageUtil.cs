using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace TestMtgSdkDotnet
{
    class ImageUtil
    {
        public static readonly string OfficialCardImageFileNameFormat = "Image{0}.jfif";

        public static string CardImageFileName(int multiverseId)
        {
            return string.Format(OfficialCardImageFileNameFormat, multiverseId);
        }

        public static void CheckEnglishCardImage(List<CardInfo> cardInfos)
        {
            foreach (var cardInfo in cardInfos)
            {
                string uri = cardInfo.imageUrl;
                string filePath = string.Format(OfficialCardImageFileNameFormat, cardInfo.multiverseid);

                CheckCardImage(uri, filePath);
            }
        }

        public static void DownloadCardImage(List<CardInfo> cardInfos)
        {
            string officialCardImageFormat = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid={0}&type=card";

            foreach (var cardInfo in cardInfos)
            {
                // TODO: 日本のmultivaeridnisuru
                int multiverseId = cardInfo.japaneseMultiverseId;

                string filePath = CardImageFileName(multiverseId);
                string url = string.Format(officialCardImageFormat, multiverseId);

                CheckCardImage(url, filePath);
            }
        }

        public static void CheckCardImage(string uri, string fileName)
        {
            // ファイルが存在しなければ、ダウンロードしてファイルを作る
            if (!File.Exists(fileName))
            {
                DownloadCardImage(uri, fileName);
            }
        }

        public static void ShowCardImage(List<CardInfo> cardInfos, PictureBox pictureBox)
        {
            // 指定されたカードの画像データを集める。既にローカルファイルになっている前提で処理する。
            List<Image> images = new List<Image>(); // TODO: 解放の手順検討する
            int totalWidth = 0;
            int height = 0;
            foreach (var cardInfo in cardInfos)
            {
                string filePath = string.Format(OfficialCardImageFileNameFormat, cardInfo.japaneseMultiverseId);
                Image image = Image.FromFile(filePath);
                images.Add(image);
                totalWidth += image.Width;
                height = image.Height;
            }

            // 
            var bitmap = new Bitmap(totalWidth, height);

            using (var canvas = Graphics.FromImage(bitmap))
            {
                canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                int horizontalPosition = 0;
                foreach (var image in images)
                {
                    canvas.DrawImage(image, new Point(horizontalPosition, 0));
                    horizontalPosition += image.Width;
                }
            }

            pictureBox.Height = bitmap.Height;
            pictureBox.Width = bitmap.Width;
            pictureBox.Image = bitmap;

        }

        public static void DownloadCardImage(string targetUrl, string filePath)
        {
            // TODO: なんか後処理いらないのか確認する
            WebRequest requestPic = WebRequest.Create(targetUrl);
            WebResponse responsePic = requestPic.GetResponse();
            Image webImage = Image.FromStream(responsePic.GetResponseStream() ?? throw new InvalidOperationException());

            webImage.Save(filePath, ImageFormat.Png);
        }
    }
}
