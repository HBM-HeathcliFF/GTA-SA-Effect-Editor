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
                    labelCount.Text = "";
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
                Title = "Укажите путь к файлу эффектов",
                InitialDirectory = lastDirectory,
                Filter = "Текстовый файл (*.txt, *.fxp, *.fxs)|*.TXT;*.FXP;*.FXS"
            };
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
                    pnlTextures.Visible = false;
                    HideEditBlock();
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

                    labelCount.Text = $"Всего эффектов: {foundEffects.Count}";
                    btnFind.Text = "Сброс";
                }
            }
            else
            {
                pnlTextures.Visible = false;
                HideEditBlock();
                ResetSearchBlock();
                lbEffects.Items.Clear();
                lbEffects.Items.Clear();
                foreach (var effect in effects)
                {
                    lbEffects.Items.Add(effect.Name);
                }
                labelCount.Text = $"Всего эффектов: {effects.Count}";
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Enabled = false;

            pnlTextures.Visible = false;
            HideEditBlock();

            int index = lbEffects.SelectedIndex;
            lbEffects.Items.RemoveAt(index);
            Effect effect = DefineEffect(index);
            DeleteEffect(effect.ID);
            if (index == lbEffects.Items.Count)
            {
                if (index != 0)
                    lbEffects.SelectedIndex = index - 1;
            }
            else
                lbEffects.SelectedIndex = index;

            labelCount.Text = $"Всего эффектов: {effects.Count}";

            FileStream fs = new FileStream(effectsPath, FileMode.Create);
            using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
            {
                sw.WriteLine("FX_PROJECT_DATA:");
                sw.WriteLine();
                foreach (var efct in effects)
                {
                    foreach (var line in efct.Lines)
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
                Title = "Укажите путь к файлу эффектов",
                InitialDirectory = lastDirectory,
                Filter = "Текстовый файл (*.txt, *.fxp, *.fxs)|*.TXT;*.FXP;*.FXS"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                lastDirectory = ofd.FileName;
                string otherEffectsPath = ofd.FileName;

                List<string> otherEffectsFile = ReadEffectsFile(otherEffectsPath);

                // Поиск эффекта в другом файле
                int startLine = 0, endLine = 0, selectedIndex = lbEffects.SelectedIndex;
                Effect effect = DefineEffect(selectedIndex);

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
                        if (name == effect.Name)
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
                                foreach (var line in effect.Lines)
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
                                foreach (var line in effect.Lines)
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
                            foreach (var line in effect.Lines)
                            {
                                sw.WriteLine(line);
                            }
                        }
                    }
                }
            }

            Enabled = true;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            Enabled = false;

            if (lastDirectory == "")
                lastDirectory = @"C:\";
            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Экспорт эффекта",
                InitialDirectory = lastDirectory,
                Filter = "Эффект (*.fxs)|*.fxs|Контейнер эффектов (*.fxp)|*.fxp|Текстовый файл (*.txt)|*.txt",
                AddExtension = true,
                FileName = "Новый эффект"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                lastDirectory = sfd.FileName;
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
                {
                    Effect effect = DefineEffect(lbEffects.SelectedIndex);
                    foreach (var line in effect.Lines)
                    {
                        sw.WriteLine(line);
                    }
                }
            }

            Enabled = true;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (tbEdit.Text != "")
            {
                Effect effect = DefineEffect(lbEffects.SelectedIndex);
                lbTextures.Items[lbTextures.SelectedIndex] = $"{labelTexture.Text} {tbEdit.Text}";

                int textureIndex = 0, selectedIndex = lbTextures.SelectedIndex;
                for (int j = 0; j < effect.Lines.Count; j++)
                {
                    if (effect.Textures[textureIndex] == effect.Lines[j])
                    {
                        effect.Lines[j] = lbTextures.Items[textureIndex].ToString();
                        textureIndex++;
                        if (textureIndex == effect.Textures.Count)
                            break;
                    }
                }
                effect.Textures[selectedIndex] = $"{labelTexture.Text} {tbEdit.Text}";

                WriteEffectsFile(effectsPath);
            }
        }
        #endregion

        #region ListBoxes
        private void LbEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbTextures.Items.Clear();
            if (lbEffects.SelectedIndex == -1)
            {
                pnlTextures.Visible = false;
            }
            else
            {
                lbTextures.Items.Clear();
                pnlTextures.Visible = true;

                if (btnFind.Text == "Поиск")
                {
                    foreach (var texture in effects[lbEffects.SelectedIndex].Textures)
                    {
                        lbTextures.Items.Add(texture);
                    }
                }
                else
                {
                    foreach (var texture in foundEffects[lbEffects.SelectedIndex].Textures)
                    {
                        lbTextures.Items.Add(texture);
                    }
                }
            }
        }

        private void LbTextures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTextures.SelectedIndex != -1)
            {
                labelTexture.Text = lbTextures.Items[lbTextures.SelectedIndex].ToString().Split(' ')[0];
                tbEdit.Text = lbTextures.SelectedItem.ToString().Split(' ')[1];

                labelTexture.Visible = true;
                tbEdit.Visible = true;
                btnEdit.Visible = true;
            }
        }
        #endregion

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
            labelCount.Text = $"Всего эффектов: {effects.Count}";
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
        private void HideEditBlock()
        {
            labelTexture.Visible = false;
            tbEdit.Visible = false;
            btnEdit.Visible = false;
            //h
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
        private void WriteEffectsFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
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
        }
        private void DeleteEffect(int id)
        {
            foundEffects.Remove(effects.First(x => x.ID == id));
            effects.Remove(effects.First(x => x.ID == id));
        }
        private Effect DefineEffect(int selectedIndex)
        {
            Effect effect = new Effect();
            if (btnFind.Text == "Поиск")
                effect = effects[selectedIndex];
            else
                effect = foundEffects[selectedIndex];
            return effect;
        }
    }
}