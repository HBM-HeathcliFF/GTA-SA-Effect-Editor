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
        string effectsPath = "", lastDirectory = "";
        List<string> effectsFile = new List<string>();
        List<Effect> effects = new List<Effect>();
        List<Effect> foundEffects = new List<Effect>();
        #endregion

        #region Controls

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
            if (effectsPath.EndsWith(".txt") || effectsPath.EndsWith(".fxp") || effectsPath.EndsWith(".fxs"))
            {
                if (File.Exists(effectsPath))
                {
                    UpdatePath();
                    UpdateEffectList();
                }
                else
                {
                    effectsPath = "";
                    effects.Clear();
                    lbEffects.Items.Clear();
                    lblCount.Text = "";
                    ResetSearchBlock();
                }
            }
        }
        #endregion

        #region Buttons
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            if (lastDirectory == "")
                lastDirectory = @"C:\";
            OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = false,
                Title = "Укажите путь к эффектам",
                InitialDirectory = lastDirectory
            };
            ofd.Filter = "Текстовый файл(*.TXT;*.FXP;*.FXS)|*.TXT;*.FXP;*.FXS";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                lastDirectory = ofd.FileName;
                egtbPath.Text = ofd.FileName;

                UpdatePath();
                UpdateEffectList();
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
                ResetSearchBlock();
                lblDescription.Text = "";
                lbEffects.Items.Clear();
                foreach (var effect in effects)
                {
                    lbEffects.Items.Add(effect.Name);
                }
                lblCount.Text = $"Всего эффектов: {effects.Count}";
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Enabled = false;

            lblDescription.Text = "";

            int index = lbEffects.SelectedIndex;
            lbEffects.Items.RemoveAt(index);
            effects.RemoveAt(index);
            if (index == lbEffects.Items.Count)
            {
                if (index != 0)
                    lbEffects.SelectedIndex = index - 1;
            }
            else
                lbEffects.SelectedIndex = index;

            lblCount.Text = $"Всего эффектов: {effects.Count}";

            FileStream fs = new FileStream(effectsPath, FileMode.Create);
            using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
            {
                sw.WriteLine("FX_PROJECT_DATA:");
                sw.WriteLine();
                foreach (var effect in effects)
                {
                    foreach (var line in effect.Lines)
                    {
                        sw.WriteLine(line);
                    }
                    sw.WriteLine();
                }
                sw.WriteLine("FX_PROJECT_DATA_END:");
            }

            Enabled = true;
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            Enabled = false;

            if (lastDirectory == "")
                lastDirectory = @"C:\";
            OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = false,
                Title = "Укажите путь к эффектам",
                InitialDirectory = lastDirectory
            };
            ofd.Filter = "Текстовый файл(*.TXT;*.FXP;*.FXS)|*.TXT;*.FXP;*.FXS";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                lastDirectory = ofd.FileName;
                string otherEffectsPath = ofd.FileName;

                List<string> otherEffectsFile = ReadEffectsFile(otherEffectsPath);

                // Поиск эффекта в другом файле
                int startLine = 0, endLine = 0, selectedIndex = lbEffects.SelectedIndex;
                bool isFound = false;
                for (int i = otherEffectsFile.Count - 1; i >= 0; i--)
                {
                    if (otherEffectsFile[i].Contains("TXDNAME: NOTXDSET"))
                        endLine = i;
                    if (otherEffectsFile[i].Contains("FILENAME"))
                    {
                        int startIndex = otherEffectsFile[i].LastIndexOf('/') + 1;
                        int endIndex = otherEffectsFile[i].IndexOf('.');
                        string name = otherEffectsFile[i].Substring(startIndex, endIndex - startIndex);
                        if (name == effects[selectedIndex].Name)
                            isFound = true;
                    }
                    if (otherEffectsFile[i].Contains("FX_SYSTEM_DATA"))
                    {
                        if (isFound)
                        {
                            startLine = i;
                            break;
                        }
                    }
                }

                // Если он есть, то заменяем его
                if (isFound)
                {
                    isFound = false;
                    FileStream fs = new FileStream(otherEffectsPath, FileMode.Create);
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
                    {
                        if (startLine == 0)
                            isFound = true;
                        for (int i = 0; i < otherEffectsFile.Count; i++)
                        {
                            if (!isFound)
                            {
                                sw.WriteLine(otherEffectsFile[i]);
                                if (i == startLine - 1)
                                    isFound = true;
                            }
                            else
                            {
                                foreach (var line in effects[selectedIndex].Lines)
                                {
                                    sw.WriteLine(line);
                                }
                                i = endLine;
                                isFound = false;
                            }
                        }
                    }
                }

                // Если нет, то вставляем эффект в конец файла перед FX_PROJECT_DATA_END:
                else
                {
                    FileStream fs = new FileStream(otherEffectsPath, FileMode.Create);
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
                    {
                        for (int i = 0; i < otherEffectsFile.Count; i++)
                        {
                            if (otherEffectsFile[i].Contains("FX_PROJECT_DATA_END"))
                            {
                                foreach (var line in effects[selectedIndex].Lines)
                                {
                                    sw.WriteLine(line);
                                }
                                sw.WriteLine();
                                sw.WriteLine("FX_PROJECT_DATA_END:");
                                isFound = true;
                                break;
                            }
                            else
                                sw.WriteLine(otherEffectsFile[i]);
                        }

                        // Если нет FX_PROJECT_DATA_END:, то вписываем эффект в конец файла
                        if (!isFound)
                        {
                            sw.WriteLine();
                            foreach (var line in effects[selectedIndex].Lines)
                            {
                                sw.WriteLine(line);
                            }
                        }
                    }
                }
            }

            Enabled = true;
        }
        #endregion

        private void LbEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDescription.Text = "";
            if (lbEffects.SelectedIndex == -1)
            {
                btnDelete.Visible = false;
                btnImport.Visible = false;
            }
            else
            {
                btnDelete.Visible = true;
                btnImport.Visible = true;

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
        }

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
                    egtbPath.Text = key.GetValue("path").ToString();
                    effectsPath = egtbPath.Text;
                    UpdateEffectList();
                }
            }
            catch (Exception) { }
        }

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
        private void UpdateEffectList()
        {
            effectsFile = ReadEffectsFile(effectsPath);

            effects.Clear();
            lbEffects.Items.Clear();
            List<string> textures = new List<string>();

            string name = "";
            int startLine = 0, count = 1;
            for (int i = 0; i < effectsFile.Count; i++)
            {
                if (effectsFile[i].Contains("FX_SYSTEM_DATA"))
                    startLine = i;
                if (effectsFile[i].Contains("FILENAME"))
                {
                    int startIndex = effectsFile[i].LastIndexOf('/') + 1;
                    int endIndex = effectsFile[i].IndexOf('.');
                    name = effectsFile[i].Substring(startIndex, endIndex - startIndex);
                }
                if (effectsFile[i].StartsWith("TEXTURE"))
                    textures.Add(effectsFile[i]);
                if (effectsFile[i].Contains("TXDNAME: NOTXDSET"))
                {
                    effects.Add(new Effect(name, startLine, i, textures, effectsFile));
                    lbEffects.Items.Add(name);
                    count++;
                    textures.Clear();
                }
            }
            lblCount.Text = $"Всего эффектов: {effects.Count}";
        }
        private void UpdatePath()
        {
            effectsPath = egtbPath.Text;
            Registry.CurrentUser.CreateSubKey(@"Software\GTA SA Effect Editor").SetValue("path", effectsPath);
        }
        private void ResetSearchBlock()
        {
            tbFind.Text = "Название текстуры";
            tbFind.ForeColor = SystemColors.ControlDark;
            btnFind.Text = "Поиск";
        }
        private List<string> ReadEffectsFile(string path)
        {
            List<string> effects_fxp = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    effects_fxp.Add(sr.ReadLine());
                }
            }
            return effects_fxp;
        }
    }
}