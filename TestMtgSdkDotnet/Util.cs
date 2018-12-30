using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace TestMtgSdkDotnet
{
    class Util
    {
        private static string _officialCardImageFileNameFormat;

        /// <summary>
        /// ObjectListViewのColumnの初期設定を行う。
        /// </summary>
        /// <param name="nameList">名称のリスト</param>
        /// <param name="widthList">幅のリスト</param>
        /// <param name="objectListView">処理対象のObjectListView</param>
        public static void InitColumns(List<string> nameList, List<int> widthList, ObjectListView objectListView)
        {
            for (int i = 0; i < nameList.Count; i++)
            {
                // ReSharper disable once UseObjectOrCollectionInitializer
                OLVColumn columnHeader = new OLVColumn();
                columnHeader.Text = nameList[i];
                columnHeader.AspectName = nameList[i];
                columnHeader.Width = widthList[i];
                objectListView.AllColumns.Add(columnHeader);
                objectListView.Columns.Add(columnHeader);
            }
        }

        /// <summary>
        /// AspectNameを元にHyperLinkの設定を行う
        /// </summary>
        /// <param name="objectListView">処理対象のObjectListView</param>
        /// <param name="aspectName">設定対象のカラムのAspectName</param>
        /// <param name="isHyperLink">設定するHyperLinkのブール値</param>
        public static void SetHyperlinkOfColumn(ObjectListView objectListView, string aspectName, bool isHyperLink)
        {
            var column = objectListView.AllColumns.FirstOrDefault(s => s.AspectName.Equals(aspectName));
            if (column == null)
            {
                //Log.Error($"SetHyperlinkOfColumn カラムが見つからない。aspectName: {aspectName}");
            }
            else
            {
                column.Hyperlink = isHyperLink;
            }
        }

        public static void DownloadCardImage(List<CardInfo> cardInfos)
        {
            string officialCardImageFormat = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid={0}&type=card";
            _officialCardImageFileNameFormat = "Image{0}.jfif";

            foreach (var cardInfo in cardInfos)
            {
                // TODO: 日本のmultivaeridnisuru
                int multiverseId = cardInfo.japaneaseMultiverseId;

                string filePath = string.Format(_officialCardImageFileNameFormat, multiverseId);

                // ファイルが存在しなければ、ダウンロードしてファイルを作る
                bool isExists = File.Exists(filePath);
                if (isExists == false)
                {
                    string url = string.Format(officialCardImageFormat, multiverseId);
                    DownloadCardImage(url, filePath);
                }
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
                string filePath = string.Format(_officialCardImageFileNameFormat, cardInfo.japaneaseMultiverseId);
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

        public static void UpdatePictureBoxByMultiverseId(int multiverseId, PictureBox targetPictureBox)
        {
            string officialCardImageFormat = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid={0}&type=card";
            string officialCardImageFileNameFormat = "Image{0}.jfif";

            string filePath = string.Format(officialCardImageFileNameFormat, multiverseId);

            // ファイルが存在しなければ、ダウンロードしてファイルを作る
            bool isExists = System.IO.File.Exists(filePath);
            if (isExists == false)
            {
                string url = string.Format(officialCardImageFormat, multiverseId);
                DownloadCardImage(url, filePath);
            }

            Image webImage = Image.FromFile(filePath);
            targetPictureBox.Height = webImage.Height;
            targetPictureBox.Width = webImage.Width;
            targetPictureBox.Image = webImage;
        }

        public static void DownloadCardImage(string targetUrl, string filePath)
        {
            // TODO: 非同期に対応するバージョンも作る
            // TODO: なんか後処理いらないのか確認する
            WebRequest requestPic = WebRequest.Create(targetUrl);
            WebResponse responsePic = requestPic.GetResponse();
            Image webImage = Image.FromStream(responsePic.GetResponseStream() ?? throw new InvalidOperationException());

            webImage.Save(filePath, ImageFormat.Png);

        }

        public static void UpdatePictureBoxByUrl(string targetUrl, PictureBox targetPictureBox)
        {
            // PassiveなどではNULLで来る
            if (targetUrl == null)
            {
                return;
            }



            // TODO: 非同期に対応するバージョンも作る
            // TODO: なんか後処理いらないのか確認する
            WebRequest requestPic = WebRequest.Create(targetUrl);
            WebResponse responsePic = requestPic.GetResponse();
            Image webImage = Image.FromStream(responsePic.GetResponseStream() ?? throw new InvalidOperationException());

            targetPictureBox.Height = webImage.Height;
            targetPictureBox.Width = webImage.Width;
            targetPictureBox.Image = webImage;
        }


    }
}
