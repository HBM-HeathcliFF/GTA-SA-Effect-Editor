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
            HighlightSyntax();
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

        private void SetColor(string[] keyWords, Color color)
        {
            int crutch = 0;
            bool isFirst = true;
            foreach (string keyWord in keyWords)
            {
                if (keyWord == "FX_INTERP_DATA")
                {
                    for (int i = 0; i < rtbCode.Lines.Length; i++)
                    {
                        if (rtbCode.Lines[i].Contains(keyWord))
                        {
                            crutch = i;
                            break;
                        }
                    }
                }

                int index = rtbCode.Text.IndexOf(keyWord);
                while (index != -1)
                {
                    if (isFirst)
                    {
                        if (keyWord == "FX_INTERP_DATA")
                            index -= crutch;
                        isFirst = false;
                    }
                    
                    rtbCode.SelectionStart = index;
                    rtbCode.SelectionLength = keyWord.Length;
                    rtbCode.SelectionColor = color;
                    index = rtbCode.Text.IndexOf(keyWord, index + 1);
                }
            }
        }
        
        private void HighlightSyntax()
        {
            SetColor(Autocomplete.NavyBlue, Color.DodgerBlue);
            SetColor(Autocomplete.Yellow, Color.Gold);
            SetColor(Autocomplete.Green, Color.MediumSpringGreen);
            SetColor(Autocomplete.Blue, Color.Turquoise);
        }
    }
}