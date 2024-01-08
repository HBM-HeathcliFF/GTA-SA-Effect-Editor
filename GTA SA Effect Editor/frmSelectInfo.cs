using System;
using System.Windows.Forms;

namespace GTA_SA_Effect_Editor
{
    public partial class frmSelectInfo : Form
    {
        public frmSelectInfo()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FxsTemplates.Infos.SelectedInfo = "";
            Close();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (lbInfos.SelectedIndex != -1)
            {
                FxsTemplates.Infos.SelectedInfo = lbInfos.SelectedItem.ToString();
                Close();
            }
        }
    }
}
