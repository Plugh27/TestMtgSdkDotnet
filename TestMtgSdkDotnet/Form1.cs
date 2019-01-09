using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TestMtgSdkDotnet
{
    // カードセットの情報が更新された時の処理
    delegate void UpdateSetInfo(List<SetInfo> sets);

    // カードセットが選択された時の処理
    delegate void SelectSetInfo(List<SetInfo> sets);

    // カード情報が更新された時の処理
    delegate void UpdateCardInfo(List<CardInfo> cardInfos, List<ScryfallCardInfo> scryfallCardInfos);

    // カード情報が選択された時の処理
    delegate void SelectCardInfo(List<CardInfo> cardInfos);

    // ユーザ入力情報が選択された時の処理
    delegate void UpdateUserInput(List<UserInputCardInfo> userInputCardInfos);

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ListOfSet _listOfSet;
        private ListOfCards _listOfCards;
        private ListOfImages _listOfImages;
        private ViewUserInput _viewUserInput;
        private ViewImage _viewImage;
        private ViewText _viewText;
        private ViewMtgwiki _viewMtgwiki;

        private List<Form> _childForms;
        private List<string> _childFormPropertyNames;

        private UpdateSetInfo _updateSetInfo;
        private SelectSetInfo _selectSetInfo;
        private UpdateCardInfo _updateCardInfo;
        private SelectCardInfo _selectCardInfo;
        private UpdateUserInput _updateUserInput;

        private List<CardInfo> _cardInfos;
        private List<ScryfallCardInfo> _scryfallCardInfos;
        private List<UserInputCardInfo> _userInputCardInfos;

        private void Form1_Load(object sender, EventArgs e)
        {
            // 子フォームの生成、表示
            _listOfSet = new ListOfSet();
            _listOfCards = new ListOfCards();
            _listOfImages = new ListOfImages();
            _viewUserInput = new ViewUserInput();
            _viewImage = new ViewImage();
            _viewText = new ViewText();
            _viewMtgwiki = new ViewMtgwiki();

            _childForms = new List<Form>()
            {
                _listOfSet,
                _listOfCards,
                _listOfImages,
                _viewUserInput,
                _viewImage,
                _viewText,
                _viewMtgwiki
            };

            _childFormPropertyNames = new List<string>()
            {
                "ListOfSet",
                "ListOfCards",
                "ListOfImages",
                "ViewUserInput",
                "ViewImage",
                "ViewText",
                "ViewMtgwiki"
            };

            // 子フォームを表示する
            foreach (var childForm in _childForms)
            {
                childForm.MdiParent = this;
                childForm.Show();
            }

            // 本クラスが持つデリゲートの設定
            _updateSetInfo += _listOfSet.UpdateSet;

            _selectSetInfo += SelectSet;

            _updateCardInfo += _listOfCards.UpdateCardInfo;
            _updateCardInfo += _viewText.UpdateCardInfo;

            _selectCardInfo += _listOfImages.SelectCard;
            _selectCardInfo += _viewUserInput.SelectCardInfo;
            _selectCardInfo += _viewImage.SelectCardInfo;
            _selectCardInfo += _viewText.SelectCardInfo;
            _selectCardInfo += _viewMtgwiki.SelectCardInfo;

            _updateUserInput += _viewUserInput.UpdateUserInput;
            _updateUserInput += _listOfCards.UpdateUserInput;

            // 子フォームのLocation, Sizeを復元する
            for (int i = 0; i < _childForms.Count; i++)
            {
                _childForms[i].Location = (Point) Properties.Settings.Default[_childFormPropertyNames[i] + "Location"];
                _childForms[i].Size = (Size) Properties.Settings.Default[_childFormPropertyNames[i] + "Size"];
            }

            InitializeData();
        }

        public void CallSelectSet(List<SetInfo> sets)
        {
            _selectSetInfo(sets);
        }

        public void CallSelectCard(List<CardInfo> cardInfos)
        {
            _selectCardInfo(cardInfos);
        }

        public void SaveUserInputInfo(string set)
        {
            List<UserInputCardInfo> targetUserInputCardInfos = _userInputCardInfos.FindAll(s => s.set == set);

            string json = JsonConvert.SerializeObject(targetUserInputCardInfos, Formatting.Indented);
            File.WriteAllText(UserInputCardInfoFileName(set), json);
        }

        private void SelectSet(List<SetInfo> sets)
        {
            // オフィシャルとScryfallから、選択されているセットのカード情報を取得する
            _cardInfos = new List<CardInfo>();
            _scryfallCardInfos = new List<ScryfallCardInfo>();
            foreach (var setInfo in sets)
            {
                _cardInfos.AddRange(RestUtil.CheckOfficialData(setInfo.code));

                _scryfallCardInfos.AddRange(RestUtil.CheckScryfallData(setInfo.code));
            }

            // 取得したカード情報をもとに、ユーザー入力情報のsetプロパティを設定する
            // （古いユーザー入力情報にはsetプロパティがなかったため）
            foreach (var cardInfo in _cardInfos)
            {
                if (_userInputCardInfos.Any(s => s.id == cardInfo.id))
                {
                    _userInputCardInfos.First(s => s.id == cardInfo.id).set = cardInfo.set;
                }
            }

            // イベント発生させる
            _updateCardInfo(_cardInfos, _scryfallCardInfos);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 子フォームのLocation, Sizeを保存する
            for (int i = 0; i < _childForms.Count; i++)
            {
                Properties.Settings.Default[_childFormPropertyNames[i] + "Location"] = _childForms[i].Location;
                Properties.Settings.Default[_childFormPropertyNames[i] + "Size"] = _childForms[i].Size;
            }

            Properties.Settings.Default.Save();
        }

        private void InitializeData()
        {
            DataOfGetAllSets dataOfGetAllSets = RestUtil.CheckOfficialSetData();

            // セット情報をリリース順に並べる
            dataOfGetAllSets.sets = dataOfGetAllSets.sets.OrderByDescending(s => s.releaseDate).ToList();

            // ディスクからユーザー入力情報を取得して一元化する
            _userInputCardInfos = new List<UserInputCardInfo>();
            foreach (var setInfo in dataOfGetAllSets.sets)
            {
                _userInputCardInfos.AddRange(CheckUserInputData(setInfo.code));
            }

            // イベント発生させる
            _updateSetInfo(dataOfGetAllSets.sets);

            // イベント発生させる
            _updateUserInput(_userInputCardInfos);
        }

        private string UserInputCardInfoFileName(string set)
        {
            string userInputCardInfoFileNameFormat = "UserInputCardInfo_{0}.json";
            return string.Format(userInputCardInfoFileNameFormat, set);
        }

        private List<UserInputCardInfo> CheckUserInputData(string set)
        {
            string fileName = UserInputCardInfoFileName(set);

            // セット情報がディスクになければ空のデータを返す
            if (!File.Exists(fileName))
            {
                return new List<UserInputCardInfo>();
            }

            // セット情報をディスクから読み込んで返す
            string json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<List<UserInputCardInfo>>(json);
        }
    }
}
