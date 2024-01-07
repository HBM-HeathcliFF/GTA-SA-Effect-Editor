using System;
using yt_DesignUI.Controls;

namespace GTA_SA_Effect_Editor
{
    public partial class frmCreateNewEffect : ShadowedForm
    {
        public frmCreateNewEffect()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            Program.EffectName = tbName.Text;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Program.EffectName = "";
            this.Close();
        }
    }
}