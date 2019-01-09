using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TestMtgSdkDotnet
{
    public partial class ViewMtgwiki : Form
    {
        public ViewMtgwiki()
        {
            InitializeComponent();
        }

        private void ViewMtgwiki_Load(object sender, EventArgs e)
        {
            SoleWebBrowser.ScriptErrorsSuppressed = true;
        }

        public void SelectCardInfo(List<CardInfo> cardInfos)
        {
            if (cardInfos == null || cardInfos.Count == 0)
            {
                return;
            }

            CardInfo cardInfo = cardInfos.First();
            SoleWebBrowser.Url = new Uri(Util.MtgwikiUrl(cardInfo));
        }
    }
}
