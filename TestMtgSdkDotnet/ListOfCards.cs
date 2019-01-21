using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        private List<UserInputCardInfo> _userInputCardInfos;

        private void ListOfCards_Load(object sender, EventArgs e)
        {
            // 右上のボタンを消す
            ControlBox = false;

            // リストビューを四辺に連動させる
            SoleListView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            // リストビューはハイパーリンクを使用する
            SoleListView.UseHyperlinks = true;

            // リストビューはグループ化を使用しない
            SoleListView.ShowGroups = false;

            // リストビューの名前リスト
            var nameList = new List<string>
            {
                "name",
                "japaneseName",
                "draftPoint",
                "colorsText",
                "text"
            };

            // リストビューの幅リスト
            var widthList = new List<int>
            {
                140,
                120,
                40,
                80,
                800
            };

            // リストビューのColumnを設定する
            Util.InitColumns(nameList, widthList, SoleListView);

            SoleListView.HyperlinkClicked += SoleListView_HyperlinkClicked;
        }

        private void SoleListView_HyperlinkClicked(object sender, BrightIdeasSoftware.HyperlinkClickedEventArgs e)
        {
            var cardList = (CardInfo)e.Item.RowObject;

            var cardInfos = new List<CardInfo> {cardList};

            ((Form1)MdiParent).CallSelectCard(cardInfos);

            e.Handled = true;
        }

        public void UpdateCardInfo(List<CardInfo> cardInfos, List<ScryfallCardInfo> scryfallCardInfos)
        {
            _cardInfos = cardInfos;

            MakeSoleList();
        }

        public void UpdateUserInput(List<UserInputCardInfo> userInputCardInfos)
        {
            _userInputCardInfos = userInputCardInfos;

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

            // ユーザー入力情報があれば、表示するデータにコピーする
            if (_userInputCardInfos != null)
            {
                foreach (var cardInfo in _showCardInfos)
                {
                    var userInputCardInfo = _userInputCardInfos.FirstOrDefault(
                        s => s.id == cardInfo.id);
                    if (userInputCardInfo != null)
                    {
                        cardInfo.draftPoint = userInputCardInfo.draftPoint;
                    }
                }
            }

            // Windowsフォームによるフィルタ処理
            FilterByColor(ref _showCardInfos);
            FilterByRarity(ref _showCardInfos);
            FilterByType(ref _showCardInfos);
            FilterByCardName(ref _showCardInfos);

            // 表示するアイテムの数を表示する
            ItemCountLabel.Text = _showCardInfos.Count + @"/" + _cardInfos.Count;

            SoleListView.SetObjects(_showCardInfos);
        }

        private void FilterByCardName(ref List<CardInfo> cardInfos)
        {
            // テキストボックスが空なら処理しない
            if (CardNameTextBox.Text == "")
            {
                return;
            }

            // 文字が入力されていたら、一致する部分があるCardInfoのみ残す
            var filteredCardInfos = new List<CardInfo>();
            foreach (var cardInfo in cardInfos)
            {
                var isMatchEnglish = cardInfo.name.IndexOf(CardNameTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                var isMatchJapanese = cardInfo.japaneseName.IndexOf(CardNameTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0;

                // 英語または日本語のどちらかに一致していたら表示するデータに含める
                if (isMatchEnglish || isMatchJapanese)
                {
                    filteredCardInfos.Add(cardInfo);
                }
            }

            cardInfos = filteredCardInfos;
        }

        private void FilterByType(ref List<CardInfo> cardInfos)
        {
            // 有効のチェックボックスが入っていなければ処理しない
            if (!TypeEnableCheckBox.Checked)
            {
                return;
            }

            // タイプのチェックボックスのリスト
            var checkBoxList =
                new List<CheckBox>
                {
                    CreatureCheckBox,
                    PlaneswalkerCheckBox,
                    InstantCheckBox,
                    SorceryCheckBox,
                    EnchantmentCheckBox
                };

            // タイプの文字列のリスト
            var typeStringList =
                new List<string>
                {
                    "Creature",
                    "Planeswalker",
                    "Instant",
                    "Sorcery",
                    "Enchantment"
                };

            // フィルタ対象の文字列のリスト
            var targetTypeStringList = new List<string>();
            for (var i = 0; i < checkBoxList.Count; i++)
            {
                if (checkBoxList[i].Checked)
                {
                    targetTypeStringList.Add(typeStringList[i]);
                }
            }

            var filteredCardInfos = new List<CardInfo>();
            foreach (var cardInfo in cardInfos)
            {
                var isEnable = false;
                foreach (var targetTypeString in targetTypeStringList)
                {
                    if (cardInfo.types.All(s => s != targetTypeString)) continue;
                    isEnable = true;
                    break;
                }

                if (isEnable)
                {
                    filteredCardInfos.Add(cardInfo);
                }
            }

            cardInfos = filteredCardInfos;
        }

        private void FilterByRarity(ref List<CardInfo> cardInfos)
        {
            // 有効のチェックボックスが入っていなければ処理しない
            if (!RarityEnableCheckBox.Checked)
            {
                return;
            }

            // 希少度のチェックボックスのリスト
            var checkBoxList =
                new List<CheckBox>
                {
                    CommonCheckBox,
                    UncommonCheckBox,
                    RareCheckBox,
                    MythicRareCheckBox
                };

            // 希少度に対応する文字列のリスト
            var rarityStringList =
                new List<string>
                {
                    "Common",
                    "Uncommon",
                    "Rare",
                    "Mythic Rare"
                };

            // フィルタ対象の文字列のリスト
            var targetRarityStringList = new List<string>();
            for (var i = 0; i < checkBoxList.Count; i++)
            {
                if (checkBoxList[i].Checked)
                {
                    targetRarityStringList.Add(rarityStringList[i]);
                }
            }

            var filteredCardInfos = new List<CardInfo>();
            foreach (var cardInfo in cardInfos)
            {
                var isEnable = false;
                foreach (var targetRarityString in targetRarityStringList)
                {
                    if (cardInfo.rarity != targetRarityString) continue;
                    isEnable = true;
                    break;
                }

                if (isEnable)
                {
                    filteredCardInfos.Add(cardInfo);
                }
            }

            cardInfos = filteredCardInfos;
        }

        private void FilterByColor(ref List<CardInfo> cardInfos)
        {
            // 有効のチェックが入っていなければ処理しない
            if (!ColorEnableCheckBox.Checked)
            {
                return;
            }

            // 色のチェックボックスのリスト
            var checkBoxList =
                new List<CheckBox>
                {
                    WhiteCheckBox,
                    BlueCheckBox,
                    BlackCheckBox,
                    RedCheckBox,
                    GreenCheckBox,
                    ColorlessCheckBox,
                    MultiCheckBox,
                    LandCheckBox
                };

            // 色のチェックボックスに対応するプロパティ名のリスト
            var propertyNameList = new List<PropertyInfo>
            {
                typeof(CardInfo).GetProperty("isWhite"),
                typeof(CardInfo).GetProperty("isBlue"),
                typeof(CardInfo).GetProperty("isBlack"),
                typeof(CardInfo).GetProperty("isRed"),
                typeof(CardInfo).GetProperty("isGreen"),
                typeof(CardInfo).GetProperty("isColorless"),
                typeof(CardInfo).GetProperty("isMultiColor"),
                typeof(CardInfo).GetProperty("isLand")
            };

            // フィルタ対象の色のリスト
            var searchPropertyInfoList = new List<PropertyInfo>();
            for (var i = 0; i < checkBoxList.Count; i++)
            {
                if (checkBoxList[i].Checked)
                {
                    searchPropertyInfoList.Add(propertyNameList[i]);
                }
            }

            var filteredCardInfos = new List<CardInfo>();
            foreach (var cardInfo in cardInfos)
            {

                // AND条件なら、指定されている色が1つでもなければ無効にする
                var isEnable = true;
                if (ColorAndRadioButton.Checked)
                {
                    foreach (var targetProperty in searchPropertyInfoList)
                    {
                        if ((bool) targetProperty.GetValue(cardInfo)) continue;
                        isEnable = false;
                        break;
                    }
                }
                else if (ColorOrRadioButton.Checked)
                {
                    // OR条件なら、指定されている色が1つでもあれば有効にする
                    isEnable = false;
                    foreach (var targetProperty in searchPropertyInfoList)
                    {
                        if (!(bool) targetProperty.GetValue(cardInfo)) continue;
                        isEnable = true;
                        break;
                    }
                }

                // 有効なデータならリストに加える
                if (isEnable)
                {
                    filteredCardInfos.Add(cardInfo);
                }
            }

            cardInfos = filteredCardInfos;
        }

        private List<CardInfo> CardInfosFromSelectedObjects()
        {
            return SoleListView.SelectedObjects.Cast<CardInfo>().ToList();
        }

        private void SoleListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCardInfos = CardInfosFromSelectedObjects();

            ((Form1) MdiParent).CallSelectCard(selectedCardInfos);
        }

        private void OpenJapaneseWikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedCardInfos = CardInfosFromSelectedObjects();

            foreach (var cardInfo in selectedCardInfos)
            {
                System.Diagnostics.Process.Start(Util.MtgwikiUrl(cardInfo));
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

        private void CardNameTextBox_TextChanged(object sender, EventArgs e)
        {
            MakeSoleList();
        }

        private void ClearCardNameButton_Click(object sender, EventArgs e)
        {
            CardNameTextBox.Text = "";
            MakeSoleList();
        }

        private void CopyHtmlLinkToWikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedCardInfos = CardInfosFromSelectedObjects();
            if (selectedCardInfos.Count != 1)
            {
                MessageBox.Show(@"複数選択時のリンク作成は未実装");
                return;
            }

            var selectedCardInfo = selectedCardInfos.First();
            string hyperlinkReference = Util.MtgwikiUrl(selectedCardInfo);
            string bodyFormat = "&#060;&#060;{0}/{1}&#062;&#062;";
            string doby = string.Format(bodyFormat, selectedCardInfo.japaneseName, selectedCardInfo.name);
            string imageUrl = ImageUtil.OfficialCardImageUrl(selectedCardInfo.japaneseMultiverseId.ToString());

            string allHtml = $@"<a href=""{hyperlinkReference}"" class=""showthumb"">
{doby} <span class=""dummy2"">
<img src=""{imageUrl}"" />
</span>
</a>";
            try
            {
                Clipboard.SetText(allHtml);
            }
            catch
            {
                // ignored
            }
        }
    }
}
