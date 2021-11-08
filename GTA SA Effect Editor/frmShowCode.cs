using System;
using System.Drawing;
using yt_DesignUI.Controls;

namespace GTA_SA_Effect_Editor
{
    public partial class frmShowCode : ShadowedForm
    {
        public frmShowCode()
        {
            InitializeComponent();
            Program.IsEdited = false;
            rtbCode.Lines = Program.Code.ToArray();
            HighlightSyntax(Autocomplete.NavyBlue, Color.DodgerBlue);
            HighlightSyntax(Autocomplete.Yellow, Color.Gold);
            HighlightSyntax(Autocomplete.Green, Color.MediumSpringGreen);
            HighlightSyntax(Autocomplete.Blue, Color.Turquoise);
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            Program.Code.Clear();
            foreach (var line in rtbCode.Lines)
            {
                Program.Code.Add(line);
            }
            Program.IsEdited = true;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HighlightSyntax(string[] keyWords, Color color)
        {
            int crutch = 0;
            bool isFirstInterp = true;
            foreach (string keyWord in keyWords)
            {
                for (int i = 0; i < rtbCode.Lines.Length; i++)
                {
                    if (rtbCode.Lines[i].Contains(keyWord))
                    {
                        crutch = i;
                        break;
                    }
                }

                int index = rtbCode.Text.IndexOf(keyWord);
                while (index != -1)
                {
                    if (isFirstInterp)
                    {
                        if (keyWord == "FX_INTERP_DATA")
                            index -= crutch;
                        isFirstInterp = false;
                    }

                    rtbCode.SelectionStart = index;
                    rtbCode.SelectionLength = keyWord.Length;
                    rtbCode.SelectionColor = color;
                    index = rtbCode.Text.IndexOf(keyWord, index + 1);
                }
            }
        }
    }
}