using yt_DesignUI;
using yt_DesignUI.Controls;

namespace GTA_SA_Effect_Editor
{
    public partial class frmMessage : ShadowedForm
    {
        public frmMessage()
        {
            InitializeComponent();
            Animator.Start();
        }

        private void BtnOk_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
