using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace TestMtgSdkDotnet
{
    internal class RestUtil
    {
        /// <summary>
        /// 公式APIのセット全体を取得するURL
        /// </summary>
        public static readonly string OfficialSetInfoUrl = "https://api.magicthegathering.io/v1/sets";

        /// <summary>
        /// 公式APIで取得したセット情報を保存しているファイル名
        /// </summary>
        public static readonly string OfficialSetInfoFileName = "OfficialSetInfo.json";

        /// <summary>
        /// 公式APIで取得したカード情報を保存しているファイル名、パラメータはセットのコード（ドミナリアならDOMなど）
        /// </summary>
        private const string OfficialCardInfoFileNameFormat = "OfficialCardInfo_{0}.json";

        /// <summary>
        /// ScryfallのAPIで取得したカード情報を保存しているファイル名。パラメータはセットのコード（ドミナリアならDOMなど）
        /// </summary>
        private const string ScryfallCardInfoFileNameFormat = "ScryfallCardInfo_{0}.json";

        public static DataOfGetAllSets CheckOfficialSetData()
        {
            // セット情報がディスクになければ、Webから取得してディスクに保存する
            if (!File.Exists(OfficialSetInfoFileName))
            {
                var tempJson = GetHttpData(OfficialSetInfoUrl);
                var tempObject = JsonConvert.DeserializeObject<DataOfGetAllSets>(tempJson);

                var serializedJson = JsonConvert.SerializeObject(tempObject, Formatting.Indented);
                File.WriteAllText(OfficialSetInfoFileName, serializedJson);
            }

            // セット情報をディスクから取得して返す
            var jsonOfGetAllSets = File.ReadAllText(OfficialSetInfoFileName);
            var dataOfGetAllSets = JsonConvert.DeserializeObject<DataOfGetAllSets>(jsonOfGetAllSets);

            // セット情報をリリース順に並べる
            dataOfGetAllSets.sets = dataOfGetAllSets.sets.OrderByDescending(s => s.releaseDate).ToList();

            return dataOfGetAllSets;
        }

        public static string CardInfosFileName(string set)
        {
            return string.Format(OfficialCardInfoFileNameFormat, set);
        }

        public static List<CardInfo> CheckOfficialData(string set)
        {
            var oneSetCardInfosFileName = CardInfosFileName(set);

            // ディスクにデータがあるかチェックして、なければネットから取得する
            if (File.Exists(oneSetCardInfosFileName))
            {
                return JsonConvert.DeserializeObject<List<CardInfo>>(File.ReadAllText(oneSetCardInfosFileName));
            }

            var oneSetCardInfos = new List<CardInfo>();
            for (var page = 1; page < 10; page++)
            {
                var jsonCardInfo = GetCardInfo(page, set);
                var apiResponseData = JsonConvert.DeserializeObject<ApiResponseData>(jsonCardInfo);
                if (apiResponseData.cards.Count == 0)
                {
                    break;
                }

                oneSetCardInfos.AddRange(apiResponseData.cards);
            }

            // 取得したデータをディスクに保存する
            var jsonOneSetCardInfos = JsonConvert.SerializeObject(oneSetCardInfos, Formatting.Indented);
            File.WriteAllText(oneSetCardInfosFileName, jsonOneSetCardInfos);

            return JsonConvert.DeserializeObject<List<CardInfo>>(File.ReadAllText(oneSetCardInfosFileName));
        }

        public static string ScryfallCardInfosFileName(string set)
        {
            return string.Format(ScryfallCardInfoFileNameFormat, set);
        }

        public static List<ScryfallCardInfo> CheckScryfallData(string set)
        {
            var scryfallFileName = ScryfallCardInfosFileName(set);

            // ディスクにデータがあるかチェックして、なければネットから取得してディスクに書き出す
            if (File.Exists(scryfallFileName))
            {
                return JsonConvert.DeserializeObject<List<ScryfallCardInfo>>(File.ReadAllText(scryfallFileName));
            }

            GetScryfallCardInfo(set, out var scryfallCardInfos);
            File.WriteAllText(scryfallFileName, JsonConvert.SerializeObject(scryfallCardInfos, Formatting.Indented));

            return JsonConvert.DeserializeObject<List<ScryfallCardInfo>>(File.ReadAllText(scryfallFileName));
        }

        public static string GetCardInfo(int page, string setName)
        {
            var url = "https://api.magicthegathering.io/v1/cards?page=" + page + "&set=" + setName;

            return GetHttpData(url);
        }

        private static void GetScryfallCardInfo(string set, out List<ScryfallCardInfo> scryfallCardInfos)
        {
            const string scryfallSetFormat = "https://api.scryfall.com/cards/search?order=set&q=e%3A{0}&unique=prints&include_multilingual=true";

            scryfallCardInfos = new List<ScryfallCardInfo>();

            var scryfallResponseData = new ScryfallResponseData
            {
                has_more = true,
                next_page = string.Format(scryfallSetFormat, set)
            };
            while (scryfallResponseData.has_more)
            {
                // APIからJSONを取得して、ドットネット型に変換する
                var scryfallResponse = GetHttpData(Regex.Unescape(scryfallResponseData.next_page));
                scryfallResponseData = JsonConvert.DeserializeObject<ScryfallResponseData>(scryfallResponse);

                // 取得したデータから、日本語と英語のデータのみ抽出する
                foreach (var scryfallCardInfo in scryfallResponseData.data)
                {
                    if (scryfallCardInfo.lang == "ja" || scryfallCardInfo.lang == "en")
                    {
                        scryfallCardInfos.Add(scryfallCardInfo);
                    }
                }
            }
        }

        private static string GetHttpData(string uri)
        {
            var wc = new WebClient();

            var st = wc.OpenRead(uri);
            var sr = new StreamReader(st ?? throw new InvalidOperationException());

            var httpData = sr.ReadToEnd();

            sr.Close();
            st.Close();

            return httpData;
        }
    }
}
