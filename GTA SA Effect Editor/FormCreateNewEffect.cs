﻿using System;
using yt_DesignUI.Controls;

namespace GTA_SA_Effect_Editor
{
    public partial class FormCreateNewEffect : ShadowedForm
    {
        public FormCreateNewEffect()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            Program.EffectName = tbName.Text;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Program.EffectName = "";
            Close();
        }
    }
}