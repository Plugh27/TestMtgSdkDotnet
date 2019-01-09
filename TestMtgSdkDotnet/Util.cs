using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace TestMtgSdkDotnet
{
    class Util
    {
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

        public static string MtgwikiUrl(CardInfo cardInfo)
        {
            string urlFormat = "http://mtgwiki.com/wiki/{0}/{1}";

            string japaneaseCardName = cardInfo.japaneseName;
            string cardName = cardInfo.name;
            cardName = cardName.Replace(" ", "_");

            return string.Format(urlFormat, japaneaseCardName, cardName);
        }
    }
}
