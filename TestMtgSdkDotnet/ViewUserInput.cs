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

        private string UserInputFileName = "UserInputCardInfo.json";

        private List<UserInputCardInfo> _userInputCardInfos;
        private CardInfo _targetCardInfo;


        private void ViewUserInput_Load(object sender, EventArgs e)
        {
            // ディスクからユーザー入力情報を取得する
            if (File.Exists(UserInputFileName))
            {
                string jsonUserInputCardInfos = File.ReadAllText(UserInputFileName);
                _userInputCardInfos = JsonConvert.DeserializeObject<List<UserInputCardInfo>>(jsonUserInputCardInfos);
            }
            else
            {
                _userInputCardInfos = new List<UserInputCardInfo>();
            }
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
            string jsonUserInputCardInfos = JsonConvert.SerializeObject(_userInputCardInfos, Formatting.Indented);
            File.WriteAllText(UserInputFileName, jsonUserInputCardInfos);

        }

        public void SelectCardInfo(List<CardInfo> cardInfos)
        {
            if(cardInfos.Count == 0)
            {
                return;
            }

            // 処理対象のカード情報をメンバ変数で記憶する
            _targetCardInfo = cardInfos.First();

            // カード名を設定する
            CardNameTextBox.Text = _targetCardInfo.japaneaseName + "／" + _targetCardInfo.name;

            // 処理対象のユーザー入力情報があればフォームに反映する
            if(_userInputCardInfos.Any(s => s.id == _targetCardInfo.id))
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
