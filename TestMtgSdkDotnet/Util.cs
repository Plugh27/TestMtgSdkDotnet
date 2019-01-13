using System.Collections.Generic;
using BrightIdeasSoftware;

namespace TestMtgSdkDotnet
{
    internal class Util
    {
        /// <summary>
        /// ObjectListViewのColumnの初期設定を行う。
        /// </summary>
        /// <param name="nameList">名称のリスト</param>
        /// <param name="widthList">幅のリスト</param>
        /// <param name="objectListView">処理対象のObjectListView</param>
        public static void InitColumns(List<string> nameList, List<int> widthList, ObjectListView objectListView)
        {
            for (var i = 0; i < nameList.Count; i++)
            {
                // ReSharper disable once UseObjectOrCollectionInitializer
                var columnHeader = new OLVColumn();
                columnHeader.Text = nameList[i];
                columnHeader.AspectName = nameList[i];
                columnHeader.Width = widthList[i];
                objectListView.AllColumns.Add(columnHeader);
                objectListView.Columns.Add(columnHeader);
            }
        }

        public static string MtgwikiUrl(CardInfo cardInfo)
        {
            const string urlFormat = "http://mtgwiki.com/wiki/{0}/{1}";

            var japaneseCardName = cardInfo.japaneseName;
            var cardName = cardInfo.name;
            cardName = cardName.Replace(" ", "_");

            return string.Format(urlFormat, japaneseCardName, cardName);
        }

        public static ScryfallCardInfo FindEqualingJapaneseScryfallCardInfo(CardInfo cardInfo, List<ScryfallCardInfo> scryfallCardInfos)
        {
            var scryfallCardInfo =
                scryfallCardInfos.Find(s => s.multiverse_ids.Contains(cardInfo.japaneseMultiverseId));

            return scryfallCardInfo;
        }

        public static ScryfallCardInfo FindEqualingEnglishScryfallCardInfo(CardInfo cardInfo,
            List<ScryfallCardInfo> scryfallCardInfos)
        {
            var scryfallCardInfo =
                scryfallCardInfos.Find(s => s.multiverse_ids.Contains(cardInfo.multiverseid));

            return scryfallCardInfo;
        }
    }
}
