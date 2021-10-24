using System;
using yt_DesignUI.Controls;

namespace GTA_SA_Effect_Editor
{
    public partial class frmShowCode : ShadowedForm
    {
        public frmShowCode()
        {
            InitializeComponent();
            Program.IsEdited = false;
            for (int i = 0; i < Program.Code.Count; i++)
            {
                tbCode.Text += Program.Code[i];
                if (i != Program.Code.Count - 1)
                    tbCode.Text += Environment.NewLine;
            }
        }

        private void BtnApply_Click(object sender, System.EventArgs e)
        {
            Program.Code.Clear();
            foreach (var line in tbCode.Lines)
            {
                Program.Code.Add(line);
            }
            Program.IsEdited = true;
            Close();
        }

        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
