using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMtgSdkDotnet
{
    public partial class ListOfCards : Form
    {
        public ListOfCards()
        {
            InitializeComponent();
        }

        private List<CardInfo> _cardInfos;
        private List<CardInfo> _showCardInfos;

        private void ListOfCards_Load(object sender, EventArgs e)
        {
            SoleListView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            // リストビューはハイパーリンクを使用する
            SoleListView.UseHyperlinks = true;

            // リストビューはグループ化を使用しない
            SoleListView.ShowGroups = false;

            // リストビューの名前リスト
            List<string> nameList = new List<string>
            {
                "name",
                "japaneaseName",
                "colorsText",
                "text"
            };

            // リストビューの幅リスト
            List<int> widthList = new List<int>
            {
                120,
                120,
                80,
                800
            };

            // リストビューのColumnを設定する
            Util.InitColumns(nameList, widthList, SoleListView);

            // 名称はハイパーリンクとして表示する
            //Util.SetHyperlinkOfColumn(SoleListView, "name", true);

            SoleListView.HyperlinkClicked += SoleListView_HyperlinkClicked;



        }


        private void SoleListView_HyperlinkClicked(object sender, BrightIdeasSoftware.HyperlinkClickedEventArgs e)
        {
            CardInfo cardList = (CardInfo)e.Item.RowObject;

            List<CardInfo> cardInfos = new List<CardInfo>(){cardList};

            ((Form1)MdiParent).CallSelectCard(cardInfos);

            e.Handled = true;
        }

        public void UpdateCardInfo(List<CardInfo> cardInfos)
        {
            _cardInfos = cardInfos;

            MakeSoleList();
        }

        private void MakeSoleList()
        {
            if (_cardInfos == null)
            {
                // TODO: エラー処理
                return;
            }

            _showCardInfos = _cardInfos;

            // TODO: Windowsフォームによるフィルタ処理
            FilterByColor(ref _showCardInfos); // TODO: メンバ変数をパラメータ化する
            FilterByRarity(ref _showCardInfos);
            FilterByType(ref _showCardInfos);


            SoleListView.SetObjects(_showCardInfos);
        }

        private void FilterByType(ref List<CardInfo> cardInfos)
        {
            // 有効のチェックボックスが入っていなければ処理しない
            if (!TypeEnableCheckBox.Checked)
            {
                return;
            }

            // タイプのチェックボックスのリスト
            List<CheckBox> checkBoxList =
                new List<CheckBox>
                {
                    CreatureCheckBox,
                    PlaneswalkerCheckBox,
                    InstantCheckBox,
                    SorceryCheckBox,
                    EnchantmentCheckBox
                };

            // タイプの文字列のリスト
            List<string> typeStringList =
                new List<string>
                {
                    "Creature",
                    "Planeswalker",
                    "Instant",
                    "Sorcery",
                    "Enchantment"
                };

            // フィルタ対象の文字列のリスト
            List<string> targetTypeStringList = new List<string>();
            for (int i = 0; i < checkBoxList.Count; i++)
            {
                if (checkBoxList[i].Checked)
                {
                    targetTypeStringList.Add(typeStringList[i]);
                }
            }

            List<CardInfo> filterdCardInfos = new List<CardInfo>();
            foreach (var cardInfo in cardInfos)
            {
                bool isEnable = false;
                foreach (var targetTypeString in targetTypeStringList)
                {
                    if (cardInfo.types.Any(s => s == targetTypeString))
                    {
                        isEnable = true;
                        break;
                    }
                }

                if (isEnable)
                {
                    filterdCardInfos.Add(cardInfo);
                }
            }

            cardInfos = filterdCardInfos;
        }

        private void FilterByRarity(ref List<CardInfo> cardInfos)
        {
            // 有効のチェックボックスが入っていなければ処理しない
            if (!RarityEnableCheckBox.Checked)
            {
                return;
            }

            // 希少度のチェックボックスのリスト
            List<CheckBox> checkBoxList =
                new List<CheckBox>
                {
                    CommonCheckBox,
                    UncommonCheckBox,
                    RareCheckBox,
                    MythicRareCheckBox
                };

            // 希少度に対応する文字列のリスト
            List<string> rarityStringList =
                new List<string>
                {
                    "Common",
                    "Uncommon",
                    "Rare",
                    "Mythic Rare"
                };

            // フィルタ対象の文字列のリスト
            List<string> targetRarityStringList = new List<string>();
            for (int i = 0; i < checkBoxList.Count; i++)
            {
                if (checkBoxList[i].Checked)
                {
                    targetRarityStringList.Add(rarityStringList[i]);
                }
            }

            List<CardInfo> filterdCardInfos = new List<CardInfo>();
            foreach (var cardInfo in cardInfos)
            {
                bool isEnable = false;
                foreach (var targetRarityString in targetRarityStringList)
                {
                    if (cardInfo.rarity == targetRarityString)
                    {
                        isEnable = true;
                        break;
                    }
                }

                if (isEnable)
                {
                    filterdCardInfos.Add(cardInfo);
                }
            }

            cardInfos = filterdCardInfos;
        }

        private void FilterByColor(ref List<CardInfo> cardInfos)
        {
            // 有効のチェックが入っていなければ処理しない
            if (!ColorEnableCheckBox.Checked)
            {
                return;
            }

            // 色のチェックボックスのリスト
            List<CheckBox> checkBoxList =
                new List<CheckBox>
                {
                    WhiteCheckBox,
                    BlueCheckBox,
                    BlackCheckBox,
                    RedCheckBox,
                    GreenCheckBox,
                    ColorlessCheckBox
                };

            // 色のチェックボックスに対応するプロパティ名のリスト
            List<PropertyInfo> propertyNameList = new List<PropertyInfo>
            {
                typeof(CardInfo).GetProperty("isWhite"),
                typeof(CardInfo).GetProperty("isBlue"),
                typeof(CardInfo).GetProperty("isBlack"),
                typeof(CardInfo).GetProperty("isRed"),
                typeof(CardInfo).GetProperty("isGreen"),
                typeof(CardInfo).GetProperty("isColorless"),
            };

            // フィルタ対象の色のリスト
            List<PropertyInfo> searchPropertyInfoList = new List<PropertyInfo>();
            for (int i = 0; i < checkBoxList.Count; i++)
            {
                if (checkBoxList[i].Checked)
                {
                    searchPropertyInfoList.Add(propertyNameList[i]);
                }
            }

            List<CardInfo> filterdCardInfos = new List<CardInfo>();
            foreach (var cardInfo in cardInfos)
            {
                bool isEnable = true;

                // AND条件なら、指定されている色が1つでもなければ無効にする
                if (ColorAndRadioButton.Checked)
                {
                    isEnable = true;
                    foreach (var targetProperty in searchPropertyInfoList)
                    {
                        if (!(bool) targetProperty.GetValue(cardInfo))
                        {
                            isEnable = false;
                            break;
                        }
                    }
                }

                // OR条件なら、指定されている色が1つでもあれば有効にする
                if (ColorOrRadioButton.Checked)
                {
                    isEnable = false;
                    foreach (var targetProperty in searchPropertyInfoList)
                    {
                        if ((bool)targetProperty.GetValue(cardInfo))
                        {
                            isEnable = true;
                            break;
                        }
                    }
                }

                // 有効なデータならリストに加える
                if (isEnable)
                {
                    filterdCardInfos.Add(cardInfo);
                }
            }

            cardInfos = filterdCardInfos;
        }

        private void SoleListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: このブロック関数化
            List<CardInfo> selectedCardInfos = new List<CardInfo>();
            foreach (var item in SoleListView.SelectedObjects)
            {
                selectedCardInfos.Add((CardInfo) item);
            }

            ((Form1) MdiParent).CallSelectCard(selectedCardInfos);

        }

        private void OpenJapaneaseWikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: このブロック関数化
            List<CardInfo> selectedCardInfos = new List<CardInfo>();
            foreach (var item in SoleListView.SelectedObjects)
            {
                selectedCardInfos.Add((CardInfo)item);
            }

            string urlFormat = "http://mtgwiki.com/wiki/{0}/{1}";
            foreach (var cardInfo in selectedCardInfos)
            {
                string japaneaseCardName = cardInfo.japaneaseName;
                string cardName = cardInfo.name;
                cardName = cardName.Replace(" ", "_");

                System.Diagnostics.Process.Start(string.Format(urlFormat, japaneaseCardName, cardName));
            }
        }

        private void ColorFilter_CheckedChanged(object sender, EventArgs e)
        {
            MakeSoleList();
        }

        private void RarityFilter_CheckedChanged(object sender, EventArgs e)
        {
            MakeSoleList();
        }

        private void TypeFilter_CheckedChanged(object sender, EventArgs e)
        {
            MakeSoleList();
        }
    }
}
