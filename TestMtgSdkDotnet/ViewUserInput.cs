using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMtgSdkDotnet
{
    public partial class ViewUserInput : Form
    {
        public ViewUserInput()
        {
            InitializeComponent();
        }


        private CardInfo _targetCardInfo;

        private List<UserInputCardInfo> _userInputCardInfos;


        private void ViewUserInput_Load(object sender, EventArgs e)
        {
        }

        private void ViewUserInput_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveUserInput();

        }

        private void ViewUserInput_Leave(object sender, EventArgs e)
        {
            SaveUserInput();

        }

        private void SaveUserInput()
        {
            if(_targetCardInfo == null)
            {
                return;
            }

            if (_userInputCardInfos == null)
            {
                return;
            }

            // ディスクに保存するデータの集合に、編集中のカードが無ければ追加する
            if (!_userInputCardInfos.Any(s => s.id == _targetCardInfo.id))
            {
                UserInputCardInfo userInputCardInfo = new UserInputCardInfo();
                userInputCardInfo.id = _targetCardInfo.id;
                userInputCardInfo.cardName = _targetCardInfo.japaneaseName + "／" + _targetCardInfo.name;
                _userInputCardInfos.Add(userInputCardInfo);
            }

            // フォームに表示中の内容を、ディスクに保存するデータに反映する
            UserInputCardInfo temp = _userInputCardInfos.First(s => s.id == _targetCardInfo.id);
            temp.draftPoint = (int)DraftPointNumericUpDown.Value;
            temp.memo = MemoTextBox.Text;

            // ユーザー入力情報をディスクに保存する
            // TODO: エラー処理必要かも
            ((Form1)ParentForm).SaveUserInfo();
        }

        public void SelectCardInfo(List<CardInfo> cardInfos)
        {
            if(cardInfos.Count == 0)
            {
                return;
            }

            // 処理対象のカード情報をメンバ変数で記憶する
            _targetCardInfo = cardInfos.First();

            RefreshFormByMemberValue();
        }

        public void UpdateUserInput(List<UserInputCardInfo> userInputCardInfos)
        {
            _userInputCardInfos = userInputCardInfos;

            // TODO: フォーム更新する
            RefreshFormByMemberValue();
        }

        public void RefreshFormByMemberValue()
        {
            if (_userInputCardInfos == null)
            {
                return;
            }

            if (_targetCardInfo == null)
            {
                return;
            }

            // カード名を設定する
            CardNameTextBox.Text = _targetCardInfo.japaneaseName + "／" + _targetCardInfo.name;

            // 処理対象のユーザー入力情報があればフォームに反映する
            if (_userInputCardInfos.Any(s => s.id == _targetCardInfo.id))
            {
                UserInputCardInfo temp = _userInputCardInfos.First(s => s.id == _targetCardInfo.id);
                DraftPointNumericUpDown.Value = temp.draftPoint;
                MemoTextBox.Text = temp.memo;
            }
            else
            {
                // 入力情報がなければ適当な初期値を設定する
                DraftPointNumericUpDown.Value = 5;
                MemoTextBox.Text = "";
            }

        }
    }
}
