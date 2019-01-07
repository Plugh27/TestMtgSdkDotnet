using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TestMtgSdkDotnet
{
    // カードセットの情報が更新された時の処理
    delegate void UpdateSetInfo(List<SetInfo> sets);

    // カードセットが選択された時の処理
    delegate void SelectSetInfo(List<SetInfo> sets);

    // カード情報が更新された時の処理
    delegate void UpdateCardInfo(List<CardInfo> cardInfos);

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

        private List<Form> _childForms;
        private List<string> _childFormPropertyNames;

        private UpdateSetInfo _updateSetInfo;
        private SelectSetInfo _selectSetInfo;
        private UpdateCardInfo _updateCardInfo;
        private SelectCardInfo _selectCardInfo;
        private UpdateUserInput _updateUserInput;

        private List<CardInfo> _cardInfos;
        private List<UserInputCardInfo> _userInputCardInfos;

        private string officialSetInfoFileName = "OfficialSetInfo.json";
        private string officialCardInfoFileNameFormat = "OfficialCardInfo_{0}.json";
        private string UserInputFileName = "UserInputCardInfo.json";

        // "https://api.scryfall.com/cards/search?order=set&q=e%3Agrn&unique=prints&include_multilingual=true"
        private string ScryfallSetFormat = "https://api.scryfall.com/cards/search?order=set&q=e%3A{0}&unique=prints&include_multilingual=true";

        private void Form1_Load(object sender, EventArgs e)
        {
            // 子フォームの生成、表示
            _listOfSet = new ListOfSet();
            _listOfCards = new ListOfCards();
            _listOfImages = new ListOfImages();
            _viewUserInput = new ViewUserInput();
            _viewImage = new ViewImage();

            _childForms = new List<Form>()
            {
                _listOfSet,
                _listOfCards,
                _listOfImages,
                _viewUserInput,
                _viewImage
            };

            _childFormPropertyNames = new List<string>()
            {
                "ListOfSet",
                "ListOfCards",
                "ListOfImages",
                "ViewUserInput",
                "ViewImage"
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
            _selectCardInfo += _listOfImages.SelectCard;
            _selectCardInfo += _viewUserInput.SelectCardInfo;
            _selectCardInfo += _viewImage.SelectCardInfo;
            _updateUserInput += _viewUserInput.UpdateUserInput;
            _updateUserInput += _listOfCards.UpdateUserInput;

            // 子フォームのLocation, Sizeを復元する
            for (int i = 0; i < _childForms.Count; i++)
            {
                _childForms[i].Location = (Point)Properties.Settings.Default[_childFormPropertyNames[i] + "Location"];
                _childForms[i].Size = (Size)Properties.Settings.Default[_childFormPropertyNames[i] + "Size"];
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

        public void SaveUserInfo()
        {
            // ユーザー入力情報をディスクに保存する
            string jsonUserInputCardInfos = JsonConvert.SerializeObject(_userInputCardInfos, Formatting.Indented);
            File.WriteAllText(UserInputFileName, jsonUserInputCardInfos);
        }

        private void SelectSet(List<SetInfo> sets)
        {
            _cardInfos = new List<CardInfo>();
            foreach (var setInfo in sets)
            {
                // ディスクにデータがあるかチェックして、なければネットから取得する
                string oneSetCardInfosFileName = string.Format(officialCardInfoFileNameFormat, setInfo.code);
                if (!File.Exists(oneSetCardInfosFileName))
                {
                    List<CardInfo> oneSetCardInfos = new List<CardInfo>();
                    for (int page = 1; page < 10; page++)
                    {
                        string jsonCardInfo = GetCardInfo(page, setInfo.code);
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

                // ディスクのデータをドットネットのデータ型に変換する
                _cardInfos.AddRange(
                    JsonConvert.DeserializeObject<List<CardInfo>>(File.ReadAllText(oneSetCardInfosFileName)));

            }

            // イベント発生させる
            _updateCardInfo(_cardInfos);
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

        public static string GetSetInfo()
        {
            string url = "https://api.magicthegathering.io/v1/sets";

            WebClient wc = new WebClient();

            Stream st = wc.OpenRead(url);
            StreamReader sr = new StreamReader(st ?? throw new InvalidOperationException());

            string jsonCardSetInfo = sr.ReadToEnd();

            sr.Close();
            st.Close();

            return jsonCardSetInfo;
        }

        public static string GetCardInfo(int page, string setName)
        {
            // TODO: GetSetInfoと合わせて定数値にする
            string url = "https://api.magicthegathering.io/v1/cards?page=" + page + "&set=" + setName;

            WebClient wc = new WebClient();

            Stream st = wc.OpenRead(url);
            StreamReader sr = new StreamReader(st ?? throw new InvalidOperationException());

            string jsonCardInfo = sr.ReadToEnd();

            sr.Close();
            st.Close();

            return jsonCardInfo;
        }

        private void InitializeData()
        {
            // セット情報のJSONデータがディスクになければWebから取得してファイルに書き出す
            if (!File.Exists(officialSetInfoFileName))
            {
                string json = GetSetInfo();
                DataOfGetAllSets tempObject = JsonConvert.DeserializeObject<DataOfGetAllSets>(json);

                string serializedJson = JsonConvert.SerializeObject(tempObject, Formatting.Indented);
                File.WriteAllText(officialSetInfoFileName, serializedJson);
            }

            // セット情報をディスクから取得する
            DataOfGetAllSets dataOfGetAllSets;
            string jsonOfGetAllSets = File.ReadAllText(officialSetInfoFileName);
            dataOfGetAllSets = JsonConvert.DeserializeObject<DataOfGetAllSets>(jsonOfGetAllSets);

            // セット情報をリリース順に並べる
            dataOfGetAllSets.sets = dataOfGetAllSets.sets.OrderByDescending(s => s.releaseDate).ToList();

            // イベント発生させる
            _updateSetInfo(dataOfGetAllSets.sets);

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

            // イベント発生させる
            _updateUserInput(_userInputCardInfos);

        }
    }
}
