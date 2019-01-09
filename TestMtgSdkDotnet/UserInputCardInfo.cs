

// JSONの要素に対応させるので、命名規則のチェックを切る
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace TestMtgSdkDotnet
{
    public class UserInputCardInfo
    {
        public string id { get; set; }
        public string cardName { get; set; }
        public int draftPoint { get; set; }
        public string memo { get; set; }
    }
}
