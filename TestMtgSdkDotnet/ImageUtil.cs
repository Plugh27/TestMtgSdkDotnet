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
    internal class ImageUtil
    {
        /// <summary>
        /// ローカルに保存するカードの画像ファイル名。パラメータはmultiverseId
        /// </summary>
        private const string OfficialCardImageFileNameFormat = "Image{0}.jfif";

        /// <summary>
        /// ローカルに保存するScryfallの画像ファイル名。パラメータはScryfallのidと画像タイプ
        /// （例） Scryfall_0503c55d-74bb-4165-9273-127c01bb2214_border_crop.jpg
        /// </summary>
        private const string ScryfallCardImageFileNameFormat = "Scryfall_{0}_{1}.jpg";

        private static string CardImageFileName(int multiverseId)
        {
            // TODO: 文字が混じるIDがあり得るのでstring型に変更したい
            return string.Format(OfficialCardImageFileNameFormat, multiverseId);
        }

        private static string ScryfallCardImageBorderCropFileName(ScryfallCardInfo scryfallCardInfo)
        {
            return string.Format(ScryfallCardImageFileNameFormat, scryfallCardInfo.id, "border-crop");
        }

        public static void CheckEnglishCardImage(CardInfo cardInfo)
        {
            var uri = cardInfo.imageUrl;
            var filePath = CardImageFileName(cardInfo.multiverseid);

            CheckCardImage(uri, filePath);
        }

        public static void CheckJapaneseCardImage(CardInfo cardInfo)
        {
            var uri = cardInfo.imageUrl;
            var filePath = CardImageFileName(cardInfo.japaneseMultiverseId);

            CheckCardImage(uri, filePath);
        }

        public static void CheckScryfallBorderCropCardImage(ScryfallCardInfo scryfallCardInfo)
        {
            // TODO: 定数化、各カードタイプへの対応（特に両面のカード画像表示など）
            string uri;
            switch (scryfallCardInfo.layout)
            {
                case "transform":
                    uri = scryfallCardInfo.card_faces[0].image_uris.border_crop;
                    break;
                case "split":
                    uri = scryfallCardInfo.image_uris.border_crop;
                    break;
                default:
                    uri = scryfallCardInfo.image_uris.border_crop;
                    break;
            }

            var filePath = ScryfallCardImageBorderCropFileName(scryfallCardInfo);

            CheckCardImage(uri, filePath);
        }

        public static Image ImageEnglishCard(CardInfo cardInfo)
        {
            var filePath = CardImageFileName(cardInfo.multiverseid);
            return Image.FromFile(filePath);
        }

        public static Image ImageJapaneseCard(CardInfo cardInfo)
        {
            var filePath = CardImageFileName(cardInfo.japaneseMultiverseId);
            return Image.FromFile(filePath);
        }

        public static Image ImageScryfallBorderCropCard(ScryfallCardInfo scryfallCardInfo)
        {
            var filePath = ScryfallCardImageBorderCropFileName(scryfallCardInfo);
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
            var images = new List<Image>(); // TODO: 解放の手順検討する
            var totalWidth = 0;
            var height = 0;
            foreach (var cardInfo in cardInfos)
            {
                var image = Image.FromFile(CardImageFileName(cardInfo.japaneseMultiverseId));
                images.Add(image);
                totalWidth += image.Width;
                height = image.Height;
            }

            // 
            var bitmap = new Bitmap(totalWidth, height);

            using (var canvas = Graphics.FromImage(bitmap))
            {
                canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var horizontalPosition = 0;
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
            var requestPic = WebRequest.Create(targetUrl);
            var responsePic = requestPic.GetResponse();
            var webImage = Image.FromStream(responsePic.GetResponseStream() ?? throw new InvalidOperationException());

            webImage.Save(filePath, ImageFormat.Png);
        }
    }
}
