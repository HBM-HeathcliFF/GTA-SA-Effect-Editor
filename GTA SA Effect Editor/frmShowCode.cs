using System;
using System.Drawing;
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
                    rtbCode.SelectionStart = index;
                    rtbCode.SelectionLength = keyWord.Length;
                    rtbCode.SelectionColor = color;
                    index += keyWord.Length;
                    index = rtbCode.Text.IndexOf(keyWord, index);
                }
            }
        }
        private void HighlightSyntax()
        {
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
        }
        private void ThreadProc(Object stateInfo)
        {
            Thread.Sleep(750);

            if ((DateTime.Now - lastChange).TotalMilliseconds >= 750 && !isAlreadyEdited)
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