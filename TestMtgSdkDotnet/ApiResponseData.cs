using System.Collections.Generic;
using System.Linq;
using System.Text;

// JSONの要素に対応させるので、命名規則のチェックを切る
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace TestMtgSdkDotnet
{
    public class ForeignNames
    {
        public string name { get; set; }
        public string language { get; set; }
        public int multiverseid { get; set; }
    }

    public class CardInfo
    {
        public const string Japanease = "Japanese";

        public string name { get; set; }
        public List<string> names { get; set; }
        public string manaCost { get; set; }
        public int cmc;
        public List<string> colors { get; set; }
        public List<string> types { get; set; }
        public string rarity { get; set; }
        public string set { get; set; }
        public string text { get; set; }
        public int multiverseid { get; set; }
        public string imageUrl { get; set; }

        public List<ForeignNames> foreignNames { get; set; }

        public string id { get; set; }

        // TODO: 5色の定数化

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

        public int japaneaseMultiverseId
        {
            get
            {
                if (foreignNames == null)
                {
                    return 0;
                }

                foreach (var foreignName in foreignNames)
                {
                    if (foreignName.language == Japanease)
                    {
                        return foreignName.multiverseid;
                    }
                }

                return 0;
            }
        }

        public string japaneaseName
        {
            get
            {
                if (foreignNames == null)
                {
                    return "";
                }

                foreach (var foreignName in foreignNames)
                {
                    if (foreignName.language == Japanease)
                    {
                        return foreignName.name;
                    }
                }

                return "";
            }
        }

        // ユーザー入力情報とリンクしたとき使用する
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
