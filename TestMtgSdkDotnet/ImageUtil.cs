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
        /// <summary>
        /// ローカルに保存するカードの画像ファイル名。パラメータはmultiverseId
        /// </summary>
        private static readonly string OfficialCardImageFileNameFormat = "Image{0}.jfif";

        /// <summary>
        /// ローカルに保存するScryfallの画像ファイル名。パラメータはScryfallのidと画像タイプ
        /// （例） Scryfall_0503c55d-74bb-4165-9273-127c01bb2214_border_crop.jpg
        /// </summary>
        private static readonly string ScryfallCardImageFileNameFormat = "Scryfall_{0}_{1}.jpg";

        private static string CardImageFileName(int multiverseId)
        {
            // TODO: 文字が混じるIDがあり得るのでstring型に変更したい
            return string.Format(OfficialCardImageFileNameFormat, multiverseId);
        }

        private static string ScryfallCardImageBorderCropFileName(ScryfallCardInfo scryfallCardInfo)
        {
            return string.Format(ScryfallCardImageFileNameFormat, scryfallCardInfo.id, "border-crop");
        }

        private static string OfficialCardImageUriFormat = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid={0}&type=card";

        private static string OfficialCardImageUri(string multiverseId)
        {
            return string.Format(OfficialCardImageUriFormat, multiverseId);
        }

        public static void CheckEnglishCardImage(CardInfo cardInfo)
        {
            string uri = cardInfo.imageUrl;
            string filePath = CardImageFileName(cardInfo.multiverseid);

            CheckCardImage(uri, filePath);
        }

        public static void CheckJapaneseCardImage(CardInfo cardInfo)
        {
            string uri = cardInfo.imageUrl;
            string filePath = CardImageFileName(cardInfo.japaneseMultiverseId);

            CheckCardImage(uri, filePath);
        }

        public static void CheckScryfallBorderCropCardImage(ScryfallCardInfo scryfallCardInfo)
        {
            string uri = scryfallCardInfo.image_uris.border_crop;
            string filePath = ScryfallCardImageBorderCropFileName(scryfallCardInfo);

            CheckCardImage(uri, filePath);
        }

        public static Image ImageEnglishCard(CardInfo cardInfo)
        {
            string filePath = CardImageFileName(cardInfo.multiverseid);
            return Image.FromFile(filePath);
        }

        public static Image ImageJapaneseCard(CardInfo cardInfo)
        {
            string filePath = CardImageFileName(cardInfo.japaneseMultiverseId);
            return Image.FromFile(filePath);
        }

        public static Image ImageScryfallBorderCropCard(ScryfallCardInfo scryfallCardInfo)
        {
            string filePath = ScryfallCardImageBorderCropFileName(scryfallCardInfo);
            return Image.FromFile(filePath);
        }

        private static void CheckCardImage(string uri, string fileName)
        {
            if (!File.Exists(fileName))
            {
                DownloadCardImage(uri, fileName);
            }
        }

        // TODO: この関数だけForm処理関連で浮いているので移動を検討する
        public static void ShowCardImage(List<CardInfo> cardInfos, PictureBox pictureBox)
        {
            // 指定されたカードの画像データを集める。既にローカルファイルになっている前提で処理する。
            List<Image> images = new List<Image>(); // TODO: 解放の手順検討する
            int totalWidth = 0;
            int height = 0;
            foreach (var cardInfo in cardInfos)
            {
                Image image = Image.FromFile(CardImageFileName(cardInfo.japaneseMultiverseId));
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

        private static void DownloadCardImage(string targetUrl, string filePath)
        {
            // TODO: なんか後処理いらないのか確認する
            WebRequest requestPic = WebRequest.Create(targetUrl);
            WebResponse responsePic = requestPic.GetResponse();
            Image webImage = Image.FromStream(responsePic.GetResponseStream() ?? throw new InvalidOperationException());

            webImage.Save(filePath, ImageFormat.Png);
        }
    }
}
