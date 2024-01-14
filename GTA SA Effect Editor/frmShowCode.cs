using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using yt_DesignUI.Controls;

namespace GTA_SA_Effect_Editor
{
    public partial class frmShowCode : ShadowedForm
    {
        public static DateTime lastChange { get; set; }
        bool isAlreadyEdited = true;
        int selectionStart = 0;

        #region Controls

        private void RtbCode_TextChanged(object sender, EventArgs e)
        {
            isAlreadyEdited = false;
            lastChange = DateTime.Now;
            ThreadPool.QueueUserWorkItem(ThreadProc);
        }

        #region Buttons
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
        #endregion

        #endregion

        public frmShowCode()
        {
            InitializeComponent();
            Program.IsEdited = false;
            rtbCode.Lines = Program.Code.ToArray();
            HighlightSyntax();
            rtbCode.TextChanged += RtbCode_TextChanged;
        }

        private void SetColor(string[] keyWords, Color color)
        {
            foreach (string keyWord in keyWords)
            {
                int index = rtbCode.Text.IndexOf(keyWord);
                while (index != -1)
                {
                    string line = keyWord;
                    if (index > 0)
                    {
                        line = rtbCode.Text[index - 1] + line;
                    }
                    if (index + keyWord.Length < rtbCode.TextLength)
                    {
                        line += rtbCode.Text[index + keyWord.Length];
                    }
                    if (new Regex($@"^([^\S]|\s){Regex.Escape(keyWord)}\s|\:").IsMatch(line))
                    {
                        rtbCode.SelectionStart = index;
                        rtbCode.SelectionLength = keyWord.Length;
                        rtbCode.SelectionColor = color;
                    }
                    index += keyWord.Length;
                    index = rtbCode.Text.IndexOf(keyWord, index);
                }
            }
        }
        private void HighlightSyntax()
        {
            rtbCode.Enabled = false;
            selectionStart = rtbCode.SelectionStart;
            rtbCode.BeginUpdate();

            rtbCode.SelectionStart = 0;
            rtbCode.SelectionLength = rtbCode.TextLength;
            rtbCode.SelectionColor = Color.White;

            SetColor(Autocomplete.NavyBlue, Color.DodgerBlue);
            SetColor(Autocomplete.Yellow, Color.Gold);
            SetColor(Autocomplete.Green, Color.MediumSpringGreen);
            SetColor(Autocomplete.Blue, Color.Turquoise);

            rtbCode.EndUpdate();
            rtbCode.SelectionStart = selectionStart;
            rtbCode.SelectionLength = 0;
            rtbCode.SelectionColor = Color.White;
            rtbCode.Enabled = true;
        }
        private void ThreadProc(Object stateInfo)
        {
            Thread.Sleep(1200);

            if ((DateTime.Now - lastChange).TotalMilliseconds >= 1200 && !isAlreadyEdited)
            {
                Invoke((MethodInvoker)(() =>
                {
                    HighlightSyntax();
                    isAlreadyEdited = true;
                }));
            }
        }
    }
}