﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestMtgSdkDotnet
{
    public partial class ListOfSet : Form
    {
        public ListOfSet()
        {
            InitializeComponent();
        }

        private List<SetInfo> _showSetInfos;

        private void ListOfSet_Load(object sender, EventArgs e)
        {
            // 右上のボタンを消す
            ControlBox = false;

            SoleListBox.DisplayMember = "Name";
            SoleListBox.ValueMember = "Code";
        }

        public void UpdateSet(List<SetInfo> sets)
        {
            _showSetInfos = new List<SetInfo>();
            foreach (var setInfo in sets)
            {
                if (setInfo.type == "core" || setInfo.type == "expansion")
                {
                    _showSetInfos.Add(setInfo);
                }
            }

            //// 特定のセットを先頭に移動させる
            //List<string> codes = new List<string>() { "XLN", "RIX", "DOM", "M19", "GRN" };
            //foreach (var code in codes)
            //{
            //    int i = sets.FindIndex(0, s => s.code == code);
            //    SetInfo set = sets[i];
            //    sets.RemoveAt(i);
            //    sets.Insert(0, set);
            //}

            SoleListBox.DataSource = _showSetInfos;
        }

        private void SoleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<SetInfo> sets = new List<SetInfo>();
            foreach (var item in SoleListBox.SelectedItems)
            {
                sets.Add((SetInfo) item);
            }

            // TODO: エラー処理必要かも
            ((Form1) ParentForm).CallSelectSet(sets);
        }
    }
}
