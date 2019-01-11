using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TestMtgSdkDotnet
{
    public partial class ViewText : Form
    {
        public ViewText()
        {
            InitializeComponent();
        }

        private List<ScryfallCardInfo> _scryfallCardInfos;

        private void ViewText_Load(object sender, EventArgs e)
        {
            // 右上のボタンを消す
            ControlBox = false;
        }

        // カード情報が更新された時の処理
        public void UpdateCardInfo(List<CardInfo> cardInfos, List<ScryfallCardInfo> scryfallCardInfos)
        {
            _scryfallCardInfos = scryfallCardInfos;
        }

        // カード情報が選択された時の処理
        public void SelectCardInfo(List<CardInfo> cardInfos)
        {
            if (_scryfallCardInfos == null)
            {
                // TODO: エラー処理
                return;
            }

            if (cardInfos.Count == 0)
            {
                return;
            }

            CardInfo cardInfo = cardInfos.First();

            ScryfallCardInfo scryfallCardInfo = Util.FindEqualingJapaneseScryfallCardInfo(cardInfo, _scryfallCardInfos);
            if (scryfallCardInfo == null)
            {
                SoleTextBox.Text = @"取得失敗（同名のカードが複数ある場合などに発生します）";
            }
            else
            {
                if (scryfallCardInfo.printed_text == null)
                {
                    SoleTextBox.Text = @"取得失敗（同名のカードが複数ある場合などに発生します）";
                }
                else
                {
                    SoleTextBox.Text = scryfallCardInfo.printed_text.Replace("\n", Environment.NewLine);
                }
            }
        }
    }
}
