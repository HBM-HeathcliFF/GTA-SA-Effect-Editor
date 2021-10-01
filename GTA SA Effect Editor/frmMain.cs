using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using yt_DesignUI;
using yt_DesignUI.Controls;

namespace GTA_SA_Effect_Editor
{
    public partial class frmMain : ShadowedForm
    {
        #region WinAPI
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int ShowWindow_Restore = 9;
        #endregion

        #region Variables
        string effectsPath = "";
        List<string> effectsFXP = new List<string>();
        List<Effect> effects = new List<Effect>();
        List<Effect> foundEffects = new List<Effect>();
        #endregion

        public frmMain()
        {
            ForbidMultipleLaunches();
            InitializeComponent();

            Animator.Start();

            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\GTA SA Effect Editor"))
                {
                    effectsPath = key.GetValue("path").ToString();
                    UpdateList();
                }
                egtbPath.Text = effectsPath;
                ReadEffectsFXP(effectsFXP);
            }
            catch (Exception) { }
        }

        #region TextBoxes
        private void TbFind_Click(object sender, EventArgs e)
        {
            if (tbFind.Text == "Название текстуры")
            {
                tbFind.Text = "";
                tbFind.ForeColor = SystemColors.WindowText;
            }
        }

        private void EgtbPath_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(effectsPath))
            {
                effectsPath = egtbPath.Text;
                UpdateList();
            }
            else
            {
                effectsPath = "";
                effects.Clear();
                lbEffects.Items.Clear();
                lblCount.Text = "";
                ResetFindField();
            }
        }
        #endregion

        #region Buttons
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = false,
                Title = "Укажите путь к effects.fxp",
                InitialDirectory = @"C:\"
            };
            ofd.Filter = "effects.fxp|effects.fxp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                egtbPath.Text = ofd.FileName;
                effectsPath = egtbPath.Text;
                UpdateList();
            }
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            if (btnFind.Text == "Поиск")
            {
                if (tbFind.Text != "Название текстуры" && tbFind.Text != "" && lbEffects.Items.Count > 0)
                {
                    lbEffects.Items.Clear();
                    foundEffects.Clear();

                    foreach (var effect in effects)
                    {
                        foreach (var texture in effect.Textures)
                        {
                            if (texture.Contains(tbFind.Text))
                            {
                                foundEffects.Add(effect);
                                lbEffects.Items.Add(effect.Name);
                                break;
                            }
                        }
                    }

                    lblCount.Text = $"Всего эффектов: {foundEffects.Count}";
                    btnFind.Text = "Сброс";
                }
            }
            else
            {
                lbEffects.Items.Clear();
                foreach (var effect in effects)
                {
                    lbEffects.Items.Add(effect.Name);
                }

                ResetFindField();
                UpdateList();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int startLine = effects[lbEffects.SelectedIndex].StartLine;
            int endLine = effects[lbEffects.SelectedIndex].EndLine;

            string line = "";
            FileStream fs = new FileStream(effectsPath, FileMode.Create);
            using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
            {
                for (int i = 0; i < effectsFXP.Count; i++)
                {
                    if (i == startLine)
                        i = endLine + 1;
                    else
                    {
                        line = effectsFXP[i];
                        sw.WriteLine(line);
                    }
                }
            }

            effectsFXP.Clear();
            UpdateList();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = false,
                Title = "Укажите путь к effects.fxp",
                InitialDirectory = @"C:\"
            };
            ofd.Filter = "effects.fxp|effects.fxp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                effectsPath = ofd.FileName;
            }

            int selectedIndex = lbEffects.SelectedIndex;

            List<string> otherEffectsFXP = new List<string>();
            ReadEffectsFXP(otherEffectsFXP);

            int startLine = 0, endLine = 0;
            bool isFound = false;
            for (int i = 0; i < otherEffectsFXP.Count; i++)
            {
                if (otherEffectsFXP[i].Contains("FX_SYSTEM_DATA"))
                    startLine = i;
                if (otherEffectsFXP[i].Contains("FILENAME"))
                {
                    int startIndex = otherEffectsFXP[i].LastIndexOf('/') + 1;
                    int endIndex = otherEffectsFXP[i].IndexOf('.');
                    string name = otherEffectsFXP[i].Substring(startIndex, endIndex - startIndex);
                    if (name == effects[selectedIndex].Name)
                        isFound = true;
                }
                if (otherEffectsFXP[i].Contains("TXDNAME: NOTXDSET"))
                {
                    if (isFound)
                    {
                        endLine = i;
                        break;
                    }
                }
            }

            isFound = false;
            string line = "";
            FileStream fs = new FileStream(effectsPath, FileMode.Create);
            using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
            {
                for (int i = 0; i < otherEffectsFXP.Count; i++)
                {
                    if (!isFound)
                    {
                        if (i == startLine - 1)
                        {
                            line = otherEffectsFXP[i];
                            sw.WriteLine(line);
                            isFound = true;
                        }
                        else
                        {
                            line = otherEffectsFXP[i];
                            sw.WriteLine(line);
                        }
                    }
                    else
                    {
                        for (int j = effects[selectedIndex].StartLine; j < effects[selectedIndex].EndLine + 1; j++)
                        {
                            line = effectsFXP[j];
                            sw.WriteLine(line);
                        }
                        i = endLine;
                        isFound = false;
                    }
                }
            }
        }
        #endregion

        private void LbEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Visible = true;
            btnImport.Visible = true;

            lblDescription.Text = "";
            if (btnFind.Text == "Поиск")
            {
                foreach (var texture in effects[lbEffects.SelectedIndex].Textures)
                {
                    lblDescription.Text += texture + '\n';
                }
            }
            else
            {
                foreach (var texture in foundEffects[lbEffects.SelectedIndex].Textures)
                {
                    lblDescription.Text += texture + '\n';
                }
            }
        }

        /// <summary>Protection against restarting the application with the subsequent activation of an existing window</summary>
        private void ForbidMultipleLaunches()
        {
            Process this_process = Process.GetCurrentProcess();
            Process[] other_processes =
                Process.GetProcessesByName(this_process.ProcessName).Where(pr => pr.Id != this_process.Id).ToArray();

            foreach (var pr in other_processes)
            {
                pr.WaitForInputIdle(1000);

                IntPtr hWnd = pr.MainWindowHandle;
                if (hWnd == IntPtr.Zero) continue;

                ShowWindow(hWnd, ShowWindow_Restore);
                SetForegroundWindow(hWnd);
                Environment.Exit(0);
            }
        }
        /// <summary>Update path and re-read effects.fxp</summary>
        private void UpdateList()
        {
            ReadEffectsFXP(effectsFXP);
            Registry.CurrentUser.CreateSubKey(@"Software\GTA SA Effect Editor").SetValue("path", effectsPath);

            string name = "";
            int startLine = 0;
            List<string> textures = new List<string>();
            effects.Clear();
            lbEffects.Items.Clear();
            int count = 1;
            for (int i = 0; i < effectsFXP.Count; i++)
            {
                if (effectsFXP[i].Contains("FX_SYSTEM_DATA"))
                    startLine = i;
                if (effectsFXP[i].Contains("FILENAME"))
                {
                    int startIndex = effectsFXP[i].LastIndexOf('/') + 1;
                    int endIndex = effectsFXP[i].IndexOf('.');
                    name = effectsFXP[i].Substring(startIndex, endIndex - startIndex);
                }
                if (effectsFXP[i].StartsWith("TEXTURE"))
                    textures.Add(effectsFXP[i]);
                if (effectsFXP[i].Contains("TXDNAME: NOTXDSET"))
                {
                    effects.Add(new Effect(name, startLine, i, textures));
                    lbEffects.Items.Add($"{count}. {name}");
                    count++;
                    textures.Clear();
                }
            }
            lblCount.Text = $"Всего эффектов: {effects.Count}";
        }

        private void ResetFindField()
        {
            tbFind.Text = "Название текстуры";
            tbFind.ForeColor = SystemColors.ControlDark;
            btnFind.Text = "Поиск";
        }

        private void ReadEffectsFXP(List<string> effects_fxp)
        {
            effects_fxp.Clear();
            using (StreamReader sr = new StreamReader(effectsPath))
            {
                while (!sr.EndOfStream)
                {
                    effects_fxp.Add(sr.ReadLine());
                }
            }
        }
    }
}