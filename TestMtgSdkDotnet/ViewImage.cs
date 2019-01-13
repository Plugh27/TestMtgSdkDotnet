using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TestMtgSdkDotnet
{
    public partial class ViewImage : Form
    {
        public ViewImage()
        {
            InitializeComponent();
        }

        private enum ImageType
        {
            Japanese,
            English,
            JapaneseScryfallBorderCrop,
            EnglishScryfallBorderCrop
        }

        private ImageType _imageType;

        private List<CardInfo> _selectedCardInfos;
        private List<ScryfallCardInfo> _scryfallCardInfos;

        // カード情報が更新された時の処理
        public void UpdateCardInfo(List<CardInfo> cardInfos, List<ScryfallCardInfo> scryfallCardInfos)
        {
            _scryfallCardInfos = scryfallCardInfos;
        }

        public void SelectCardInfo(List<CardInfo> cardInfos)
        {
            _selectedCardInfos = cardInfos;
            MakeSoleImage();
        }

        private void MakeSoleImage()
        {
            if (_selectedCardInfos.Count == 0)
            {
                return;
            }

            // 先頭のカードのみ表示する
            var targetCardInfos = new List<CardInfo> { _selectedCardInfos.First() };
            var targetCard = targetCardInfos.First();

            Image baseImage;
            switch (_imageType)
            {
                case ImageType.English:
                    ImageUtil.CheckEnglishCardImage(targetCard);
                    baseImage = ImageUtil.ImageEnglishCard(targetCard);
                    break;
                case ImageType.Japanese:
                    ImageUtil.CheckJapaneseCardImage(targetCard);
                    baseImage = ImageUtil.ImageJapaneseCard(targetCard);
                    break;
                case ImageType.JapaneseScryfallBorderCrop:
                {
                    var targetScryfallCardInfo = Util.FindEqualingJapaneseScryfallCardInfo(targetCard, _scryfallCardInfos);
                    if (targetScryfallCardInfo == null)
                    {
                        return;
                    }

                    ImageUtil.CheckScryfallBorderCropCardImage(targetScryfallCardInfo);
                    baseImage = ImageUtil.ImageScryfallBorderCropCard(targetScryfallCardInfo);
                    break;
                }
                case ImageType.EnglishScryfallBorderCrop:
                {
                    var targetScryfallCardInfo =
                        Util.FindEqualingEnglishScryfallCardInfo(targetCard, _scryfallCardInfos);
                    if (targetScryfallCardInfo == null)
                    {
                        return;
                    }

                    ImageUtil.CheckScryfallBorderCropCardImage(targetScryfallCardInfo);
                    baseImage = ImageUtil.ImageScryfallBorderCropCard(targetScryfallCardInfo);
                    break;
                }
                default:
                    // TODO: エラー処理

                    baseImage = ImageUtil.ImageEnglishCard(targetCard);
                    break;
            }

            // フォームの幅に合わせて画像を伸縮する
            // 伸縮後の幅と高さを計算
            var baseSize = baseImage.Size;
            var resizeWidth = ClientSize.Width;
            var resizeHeight = (int)(baseSize.Height * (double)resizeWidth / baseSize.Width);

            // 伸縮後の画像を作成
            var resizeBmp = new Bitmap(resizeWidth, resizeHeight);
            var g = Graphics.FromImage(resizeBmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(baseImage, 0, 0, resizeWidth, resizeHeight);

            // 画像コントロールのサイズを調整
            SolePictureBox.Width = resizeBmp.Width;
            SolePictureBox.Height = resizeBmp.Height;
            SolePictureBox.Image = resizeBmp;
        }

        private void ViewImage_Load(object sender, EventArgs e)
        {
            // 右上のボタンを消す
            ControlBox = false;

            _selectedCardInfos = new List<CardInfo>();
            _scryfallCardInfos = new List<ScryfallCardInfo>();
            _imageType = ImageType.EnglishScryfallBorderCrop;
        }

        private void JapaneseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageType = ImageType.Japanese;
            MakeSoleImage();
        }

        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageType = ImageType.English;
            MakeSoleImage();
        }

        private void ScryfallJapaneseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageType = ImageType.JapaneseScryfallBorderCrop;
            MakeSoleImage();
        }

        private void ScryfallEnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageType = ImageType.EnglishScryfallBorderCrop;
            MakeSoleImage();
        }

        private void ViewImage_SizeChanged(object sender, EventArgs e)
        {
            MakeSoleImage();
        }

        private void CopyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(SolePictureBox.Image);
        }
    }
}
