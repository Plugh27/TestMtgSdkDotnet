using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

// JSONの要素に対応させるので、命名規則のチェックを切る
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace TestMtgSdkDotnet
{
    public class ForeignNames
    {
        public string name { get; set; }
        public string language { get; set; }
        public int? multiverseid { get; set; }
    }

    public class CardInfo
    {
        public const string Japanese = "Japanese";

        public string name { get; set; }
        public List<string> names { get; set; }
        public string manaCost { get; set; }
        public string cmc { get; set; }
        public List<string> colors { get; set; }
        public List<string> types { get; set; }
        public string rarity { get; set; }
        public string set { get; set; }
        public string text { get; set; }
        public int multiverseid { get; set; }
        public string imageUrl { get; set; }

        public List<ForeignNames> foreignNames { get; set; }

        public string id { get; set; }

        [JsonIgnore]
        public bool isLand
        {
            get
            {
                if (types == null)
                {
                    return false;
                }

                if (types.Contains("Land"))
                {
                    return true;
                }

                return false;
            }
        }

        [JsonIgnore]
        public bool isWhite
        {
            get
            {
                if (colors == null)
                {
                    return false;
                }

                return colors.Any(s => s == "White");
            }
        }

        [JsonIgnore]
        public bool isBlue
        {
            get
            {
                if (colors == null)
                {
                    return false;
                }

                return colors.Any(s => s == "Blue");
            }
        }

        [JsonIgnore]
        public bool isBlack
        {
            get
            {
                if (colors == null)
                {
                    return false;
                }

                return colors.Any(s => s == "Black");
            }
        }

        [JsonIgnore]
        public bool isRed
        {
            get
            {
                if (colors == null)
                {
                    return false;
                }

                return colors.Any(s => s == "Red");
            }
        }

        [JsonIgnore]
        public bool isGreen
        {
            get
            {
                if (colors == null)
                {
                    return false;
                }

                return colors.Any(s => s == "Green");
            }
        }

        [JsonIgnore]
        public bool isColorless
        {
            get
            {
                if (colors == null)
                {
                    return true;
                }

                return false;
            }
        }

        [JsonIgnore]
        public bool isMultiColor
        {
            get
            {
                if (colors == null)
                {
                    return false;
                }

                if (colors.Count > 1)
                {
                    return true;
                }

                return false;
            }
        }

        [JsonIgnore]
        public string colorsText
        {
            get
            {
                if (colors == null)
                {
                    return "";
                }

                StringBuilder sb = new StringBuilder();
                foreach (var color in colors)
                {
                    sb.Append(color);
                }

                return sb.ToString();
            }
        }

        // TODO: ↓2つの処理、LINQでまとめる

        [JsonIgnore]
        public int japaneseMultiverseId
        {
            get
            {
                if (foreignNames == null)
                {
                    return 0;
                }

                foreach (var foreignName in foreignNames)
                {
                    if (foreignName.language == Japanese)
                    {
                        if (foreignName.multiverseid == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return (int)foreignName.multiverseid;
                        }
                    }
                }

                return 0;
            }
        }

        [JsonIgnore]
        public string japaneseName
        {
            get
            {
                if (foreignNames == null)
                {
                    return "";
                }

                foreach (var foreignName in foreignNames)
                {
                    if (foreignName.language == Japanese)
                    {
                        return foreignName.name;
                    }
                }

                return "";
            }
        }

        // ユーザー入力情報とリンクしたとき使用する
        [JsonIgnore]
        public int draftPoint { get; set; }
    }

    public class ApiResponseData
    {
        public List<CardInfo> cards { get; set; }
    }

    public class SetInfo
    {
        public string code { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int mkm_id { get; set; }
        public string mkm_name { get; set; }
        public string releaseDate { get; set; }
        public string magicCardsInfoCode { get; set; }
        public string block { get; set; }
    }

    public class DataOfGetAllSets
    {
        public List<SetInfo> sets { get; set; }
    }
}
