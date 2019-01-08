﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestMtgSdkDotnet
{
    class RestUtil
    {
        private static string officialSetInfoUrl = "https://api.magicthegathering.io/v1/sets";

        private static string officialSetInfoFileName = "OfficialSetInfo.json";

        private static string officialCardInfoFileNameFormat = "OfficialCardInfo_{0}.json";

        private static string scryfallCardInfoFileNameFormat = "ScryfallCardInfo_{0}.json";

        public static DataOfGetAllSets CheckOfficialSetData()
        {
            // セット情報がディスクになければ、Webから取得してディスクに保存する
            if (!File.Exists(officialSetInfoFileName))
            {
                string tempJson = GetHttpData(officialSetInfoUrl);
                DataOfGetAllSets tempObject = JsonConvert.DeserializeObject<DataOfGetAllSets>(tempJson);

                string serializedJson = JsonConvert.SerializeObject(tempObject, Formatting.Indented);
                File.WriteAllText(officialSetInfoFileName, serializedJson);
            }

            // セット情報をディスクから取得して返す
            string jsonOfGetAllSets = File.ReadAllText(officialSetInfoFileName);
            return JsonConvert.DeserializeObject<DataOfGetAllSets>(jsonOfGetAllSets);
        }


        public static List<CardInfo> CheckOfficialData(string set)
        {
            string oneSetCardInfosFileName = String.Format(officialCardInfoFileNameFormat, set);

            // ディスクにデータがあるかチェックして、なければネットから取得する
            if (!File.Exists(oneSetCardInfosFileName))
            {
                List<CardInfo> oneSetCardInfos = new List<CardInfo>();
                for (int page = 1; page < 10; page++)
                {
                    string jsonCardInfo = GetCardInfo(page, set);
                    ApiResponseData apiResponseData = JsonConvert.DeserializeObject<ApiResponseData>(jsonCardInfo);
                    if (apiResponseData.cards.Count == 0)
                    {
                        break;
                    }

                    oneSetCardInfos.AddRange(apiResponseData.cards);
                }

                // 取得したデータをディスクに保存する
                string jsonOneSetCardInfos = JsonConvert.SerializeObject(oneSetCardInfos, Formatting.Indented);
                File.WriteAllText(oneSetCardInfosFileName, jsonOneSetCardInfos);
            }

            // ディスクからデータを読み込んで返す
            return JsonConvert.DeserializeObject<List<CardInfo>>(File.ReadAllText(oneSetCardInfosFileName));
        }


        public static List<ScryfallCardInfo> CheckScryfallData(string set)
        {
            string scryfallFileName = String.Format(scryfallCardInfoFileNameFormat, set);

            // ディスクにデータがあるかチェックして、なければネットから取得してディスクに書き出す
            if (!File.Exists(scryfallFileName))
            {
                GetScryfallCardInfo(set, out var scryfallCardInfos);
                File.WriteAllText(scryfallFileName, JsonConvert.SerializeObject(scryfallCardInfos, Formatting.Indented));
            }

            // ディスクからデータを読み込んで返す
            return JsonConvert.DeserializeObject<List<ScryfallCardInfo>>(File.ReadAllText(scryfallFileName));
        }

        public static string GetCardInfo(int page, string setName)
        {
            string url = "https://api.magicthegathering.io/v1/cards?page=" + page + "&set=" + setName;

            return GetHttpData(url);
        }


        private static void GetScryfallCardInfo(string set, out List<ScryfallCardInfo> scryfallCardInfos)
        {
            string ScryfallSetFormat = "https://api.scryfall.com/cards/search?order=set&q=e%3A{0}&unique=prints&include_multilingual=true";

            scryfallCardInfos = new List<ScryfallCardInfo>();

            ScryfallResponseData scryfallResponseData = new ScryfallResponseData();
            scryfallResponseData.has_more = true;
            scryfallResponseData.next_page = String.Format(ScryfallSetFormat, set);
            while (scryfallResponseData.has_more == true)
            {
                // APIからJSONを取得して、ドットネット型に変換する
                string scryfallResponse = GetHttpData(Regex.Unescape(scryfallResponseData.next_page));
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
            WebClient wc = new WebClient();

            Stream st = wc.OpenRead(uri);
            StreamReader sr = new StreamReader(st ?? throw new InvalidOperationException());

            string httpData = sr.ReadToEnd();

            sr.Close();
            st.Close();

            return httpData;
        }
    }
}
