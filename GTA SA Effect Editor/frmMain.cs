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
        enum Component
        {
            PRIM,
            INFO,
            INTERP,
            KEYFLOAT
        }

        string lastDirectory = "";
        List<string> effectsFile = new List<string>();
        List<Effect> effects = new List<Effect>();
        List<Effect> foundEffects = new List<Effect>();
        int selectedPrim = -1, selectedInfo = -1, selectedInterp = -1, selectedKeyFloat = -1;
        #endregion

        #region Controls

        #region TextBoxes
        private void TbFind_Click(object sender, EventArgs e)
        {
            if (tbFind.Text == "Texture name")
            {
                tbFind.Text = "";
                tbFind.ForeColor = SystemColors.WindowText;
            }
        }
        private void TbFind_Leave(object sender, EventArgs e)
        {
            if (tbFind.Text == "")
            {
                tbFind.ForeColor = SystemColors.ControlDark;
                tbFind.Text = "Texture name";
            }
        }
        private void EgtbPath_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(egtbPath.Text))
            {
                if (egtbPath.Text.EndsWith(".txt") || egtbPath.Text.EndsWith(".fxp") || egtbPath.Text.EndsWith(".fxs"))
                {
                    UpdateEffectList();
                }
            }
            else
            {
                labelCount.Text = "";
                effects.Clear();
                ClearEffects();
                HideLBSelButtons();
                HideTVSelButtons();
                ResetSearchBlock();
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
                egtbPath.Text = ofd.FileName;
                lastDirectory = ofd.FileName;
                UpdateEffectList();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text == "Search")
            {
                if (tbFind.Text != "Texture name" && tbFind.Text != "" && lbEffects.Items.Count > 0)
                {
                    ClearEffects();
                    HideLBSelButtons();
                    HideTVSelButtons();
                    foundEffects.Clear();

                    bool isFound = false;
                    foreach (var effect in effects)
                    {
                        foreach (var prim in effect.Prims)
                        {
                            foreach (var texture in prim.Textures)
                            {
                                if (texture.Contains(tbFind.Text))
                                {
                                    foundEffects.Add(effect);
                                    lbEffects.Items.Add(effect.Name);
                                    isFound = true;
                                    break;
                                }
                            }
                            if (isFound)
                                break;
                        }
                        isFound = false;
                    }

                    labelCount.Text = $"Effects count: {foundEffects.Count}";
                    btnSearch.Text = "Reset";
                }
            }
            else
            {
                ClearEffects();
                HideLBSelButtons();
                HideTVSelButtons();
                ResetSearchBlock();
                foreach (var effect in effects)
                {
                    lbEffects.Items.Add(effect.Name);
                }
                labelCount.Text = $"Effects count: {effects.Count}";
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Enabled = false;

            pnlButtons.Visible = false;

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

            labelCount.Text = $"Effects count: {effects.Count}";

            WriteEffectsFile();

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
                                foreach (var line in effect.GetLines())
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
                                foreach (var line in effect.GetLines())
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
                            foreach (var line in effect.GetLines())
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
                    foreach (var line in effect.GetLines())
                    {
                        sw.WriteLine(line);
                    }
                }
            }

            Enabled = true;
        }

        private void BtnShowCode_Click(object sender, EventArgs e)
        {
            bool isFound = false;
            Program.Code.Clear();
            Effect effect = DefineEffect(lbEffects.SelectedIndex);
            for (int i = 0; i < treeView.Nodes.Count; i++)
            {
                if (treeView.Nodes[i] == treeView.SelectedNode)
                {
                    OpenCodeEditor(effect.Prims[i].GetLines());
                    if (Program.IsEdited)
                    {
                        EffectReader er = new EffectReader();
                        effect.Prims[i] = er.ReadPrim(Program.Code, 0);
                    }
                    break;
                }
                for (int j = 0; j < treeView.Nodes[i].Nodes.Count; j++)
                {
                    if (treeView.Nodes[i].Nodes[j] == treeView.SelectedNode)
                    {
                        OpenCodeEditor(effect.Prims[i].Infos[j].GetLines());
                        isFound = true;
                        if (Program.IsEdited)
                        {
                            EffectReader er = new EffectReader();
                            effect.Prims[i].Infos[j] = er.ReadInfo(Program.Code, 0);
                        }
                        break;
                    }
                    for (int k = 0; k < treeView.Nodes[i].Nodes[j].Nodes.Count; k++)
                    {
                        if (treeView.Nodes[i].Nodes[j].Nodes[k] == treeView.SelectedNode)
                        {
                            OpenCodeEditor(effect.Prims[i].Infos[j].Interps[k].GetLines());
                            isFound = true;
                            if (Program.IsEdited)
                            {
                                EffectReader er = new EffectReader();
                                effect.Prims[i].Infos[j].Interps[k] = er.ReadInterp(Program.Code, 0);
                            }
                            break;
                        }
                        for (int m = 0; m < treeView.Nodes[i].Nodes[j].Nodes[k].Nodes.Count; m++)
                        {
                            if (treeView.Nodes[i].Nodes[j].Nodes[k].Nodes[m] == treeView.SelectedNode)
                            {
                                OpenCodeEditor(effect.Prims[i].Infos[j].Interps[k].KeyFloats[m].GetLines());
                                isFound = true;
                                if (Program.IsEdited)
                                {
                                    EffectReader er = new EffectReader();
                                    effect.Prims[i].Infos[j].Interps[k].KeyFloats[m] = er.ReadKeyFloat(Program.Code, 0);
                                }
                                break;
                            }
                        }
                    }
                }
                if (isFound)
                    break;
            }

            if (Program.IsEdited)
                WriteEffectsFile();
        }

        private void BtnDelTreeItem_Click(object sender, EventArgs e)
        {
            switch (btnDelTreeItem.Text)
            {
                case "Delete PRIM":
                    effects[lbEffects.SelectedIndex].Prims.RemoveAt(selectedPrim);
                    effects[lbEffects.SelectedIndex].NUM_PRIMS = $"NUM_PRIMS: {effects[lbEffects.SelectedIndex].Prims.Count}";
                    treeView.SelectedNode.Remove();
                    break;
                case "Delete INFO":
                    effects[lbEffects.SelectedIndex].Prims[selectedPrim].Infos.RemoveAt(selectedInfo);
                    effects[lbEffects.SelectedIndex].Prims[selectedPrim].NUM_INFOS = $"NUM_INFOS: {effects[lbEffects.SelectedIndex].Prims[selectedPrim].Infos.Count}";
                    treeView.SelectedNode.Remove();
                    break;
                case "Delete INTERP":
                    effects[lbEffects.SelectedIndex].Prims[selectedPrim].Infos[selectedInfo].Interps.RemoveAt(selectedInterp);
                    treeView.SelectedNode.Remove();
                    break;
                case "Delete KEYFLOAT":
                    effects[lbEffects.SelectedIndex].Prims[selectedPrim].Infos[selectedInfo].Interps[selectedInterp].KeyFloats.RemoveAt(selectedKeyFloat);
                    effects[lbEffects.SelectedIndex].Prims[selectedPrim].Infos[selectedInfo].Interps[selectedInterp].NUM_KEYS = $"NUM_KEYS: {effects[lbEffects.SelectedIndex].Prims[selectedPrim].Infos[selectedInfo].Interps[selectedInterp].KeyFloats.Count}";
                    treeView.SelectedNode.Remove();
                    break;
            }
            WriteEffectsFile();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //
        }
        #endregion

        private void LbEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbEffects.SelectedIndex != -1)
            {
                pnlButtons.Visible = true;
                btnShowCode.Visible = false;
                treeView.Nodes.Clear();

                Effect effect = DefineEffect(lbEffects.SelectedIndex);
                for (int i = 0; i < effect.Prims.Count; i++)
                {
                    treeView.Nodes.Add($"PRIM{i + 1}");
                    for (int j = 0; j < effect.Prims[i].Infos.Count; j++)
                    {
                        treeView.Nodes[i].Nodes.Add(effect.Prims[i].Infos[j].Name);
                        for (int k = 0; k < effect.Prims[i].Infos[j].Interps.Count; k++)
                        {
                            treeView.Nodes[i].Nodes[j].Nodes.Add(effect.Prims[i].Infos[j].Interps[k].Name);
                            for (int m = 0; m < effect.Prims[i].Infos[j].Interps[k].KeyFloats.Count; m++)
                            {
                                treeView.Nodes[i].Nodes[j].Nodes[k].Nodes.Add($"KEYFLOAT{m + 1}");
                            }
                        }
                    }
                }

                btnAdd.Text = "Add PRIM";
                btnAdd.Visible = true;
                btnDelTreeItem.Visible = false;
            }
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnShowCode.Visible = true;
            bool isFound = false;
            for (int i = 0; i < treeView.Nodes.Count; i++)
            {
                if (treeView.Nodes[i] == treeView.SelectedNode)
                {
                    btnDelTreeItem.Text = "Delete PRIM";
                    btnDelTreeItem.Visible = true;
                    btnAdd.Text = "Add INFO";
                    btnAdd.Visible = true;

                    selectedPrim = i;
                    selectedInfo = -1;

                    break;
                }
                for (int j = 0; j < treeView.Nodes[i].Nodes.Count; j++)
                {
                    if (treeView.Nodes[i].Nodes[j] == treeView.SelectedNode)
                    {
                        btnDelTreeItem.Text = "Delete INFO";
                        btnDelTreeItem.Visible = true;
                        btnAdd.Text = "Add INTERP";
                        btnAdd.Visible = true;

                        selectedPrim = i;
                        selectedInfo = j;
                        selectedInterp = -1;

                        isFound = true;
                        break;
                    }
                    for (int k = 0; k < treeView.Nodes[i].Nodes[j].Nodes.Count; k++)
                    {
                        if (treeView.Nodes[i].Nodes[j].Nodes[k] == treeView.SelectedNode)
                        {
                            btnDelTreeItem.Text = "Delete INTERP";
                            btnDelTreeItem.Visible = true;
                            btnAdd.Text = "Add KEYFLOAT";
                            btnAdd.Visible = true;

                            selectedPrim = i;
                            selectedInfo = j;
                            selectedInterp = k;

                            isFound = true;
                            break;
                        }
                        for (int m = 0; m < treeView.Nodes[i].Nodes[j].Nodes[m].Nodes.Count; m++)
                        {
                            if (treeView.Nodes[i].Nodes[j].Nodes[k].Nodes[m] == treeView.SelectedNode)
                            {
                                btnDelTreeItem.Text = "Delete KEYFLOAT";
                                btnDelTreeItem.Visible = true;
                                btnAdd.Visible = false;

                                selectedPrim = i;
                                selectedInfo = j;
                                selectedInterp = k;
                                selectedKeyFloat = m;

                                isFound = true;
                                break;
                            }
                        }
                    }
                }
                if (isFound)
                    break;
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
                    lastDirectory = egtbPath.Text;
                    UpdateEffectList();
                }
            }
            catch (Exception) { }
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Registry.CurrentUser.CreateSubKey(@"Software\GTA SA Effect Editor").SetValue("path", egtbPath.Text);
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
            effectsFile = ReadEffectsFile(egtbPath.Text);

            effects.Clear();
            ClearEffects();
            HideLBSelButtons();
            HideTVSelButtons();

            EffectReader er = new EffectReader();
            er.Read(effectsFile, ref effects);

            foreach (var effect in effects)
            {
                lbEffects.Items.Add(effect.Name);
            }

            labelCount.Text = $"Effects count: {effects.Count}";
        }
        private void ClearEffects()
        {
            lbEffects.Items.Clear();
            treeView.Nodes.Clear();
        }
        private void HideLBSelButtons()
        {
            pnlButtons.Visible = false;
            btnAdd.Visible = false;
        }
        private void HideTVSelButtons()
        {
            btnShowCode.Visible = false;
            btnDelTreeItem.Visible = false;
            if (btnAdd.Text == "Add INFO")
                btnAdd.Visible = false;
        }
        private void ResetSearchBlock()
        {
            tbFind.Text = "Texture name";
            tbFind.ForeColor = SystemColors.ControlDark;
            btnSearch.Text = "Search";
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
        private void WriteEffectsFile()
        {
            FileStream fs = new FileStream(egtbPath.Text, FileMode.Create);
            using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
            {
                if (effectsFile[0].Contains("FX_PROJECT_DATA"))
                {
                    sw.WriteLine("FX_PROJECT_DATA:");
                    sw.WriteLine();
                }

                foreach (var efct in effects)
                {
                    foreach (var line in efct.GetLines())
                    {
                        sw.WriteLine(line);
                    }
                    sw.WriteLine();
                }

                if (effectsFile[0].Contains("FX_PROJECT_DATA"))
                    sw.WriteLine("FX_PROJECT_DATA_END:");
            }
        }
        private void OpenCodeEditor(List<string> lines)
        {
            foreach (var line in lines)
            {
                Program.Code.Add(line);
            }

            new frmShowCode().ShowDialog();
        }
        private void DeleteEffect(int id)
        {
            foundEffects.Remove(effects.First(x => x.ID == id));
            effects.Remove(effects.First(x => x.ID == id));
        }
        private Effect DefineEffect(int selectedIndex)
        {
            Effect effect = new Effect();
            if (btnSearch.Text == "Search")
                effect = effects[selectedIndex];
            else
                effect = foundEffects[selectedIndex];
            return effect;
        }
    }
}