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
                    pnlButtons.Visible = false;
                    lbEffects.Items.Clear();
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

                    labelCount.Text = $"Всего эффектов: {foundEffects.Count}";
                    btnFind.Text = "Сброс";
                }
            }
            else
            {
                pnlButtons.Visible = false;
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

            labelCount.Text = $"Всего эффектов: {effects.Count}";

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
                        effect.Prims[i] = RewritePrim(effect.Prims[i]);
                    break;
                }
                for (int j = 0; j < treeView.Nodes[i].Nodes.Count; j++)
                {
                    if (treeView.Nodes[i].Nodes[j] == treeView.SelectedNode)
                    {
                        OpenCodeEditor(effect.Prims[i].Infos[j].Lines);
                        isFound = true;
                        if (Program.IsEdited)
                        {
                            effect.Prims[i].Infos[j].Lines.Clear();
                            foreach (var line in Program.Code)
                            {
                                effect.Prims[i].Infos[j].Lines.Add(line);
                            }
                        }
                        break;
                    }
                }
                if (isFound)
                    break;
            }

            if (Program.IsEdited)
                WriteEffectsFile();
        }
        #endregion

        #region ListBoxes
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
                        string info = effect.Prims[i].Infos[j].Lines[0];
                        treeView.Nodes[i].Nodes.Add(info.Substring(0, info.Length - 1));
                    }
                }
            }
        }
        #endregion

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnShowCode.Visible = true;
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
            List<string> ssEffects = new List<string>();
            List<string> esEffects = new List<string>();
            List<string> ssPrims = new List<string>();
            List<string> esPrims = new List<string>();
            List<Prim> prims = new List<Prim>();
            List<Info> infos = new List<Info>();
            List<string> lines = new List<string>();
            List<string> textures = new List<string>();

            string name = "";
            int startEffect = 0, startPrim = 0, startInfo = -1, count = 1;
            for (int i = 0; i < effectsFile.Count; i++)
            {
                if (effectsFile[i].Contains("FX_SYSTEM_DATA"))
                    startEffect = i;

                if (effectsFile[i].Contains("FILENAME"))
                {
                    int startIndex = effectsFile[i].LastIndexOf('/') + 1;
                    int endIndex = effectsFile[i].IndexOf('.');
                    name = effectsFile[i].Substring(startIndex, endIndex - startIndex);
                }

                if (effectsFile[i].Contains("NUM_PRIMS"))
                {
                    for (int j = startEffect; j <= i; j++)
                    {
                        ssEffects.Add(effectsFile[j]);
                    }
                }

                if (effectsFile[i].Contains("FX_PRIM_EMITTER_DATA"))
                    startPrim = i;

                if (effectsFile[i].Contains("NUM_INFOS"))
                {
                    for (int j = startPrim; j <= i; j++)
                    {
                        ssPrims.Add(effectsFile[j]);
                        if (effectsFile[j].StartsWith("TEXTURE"))
                            textures.Add(effectsFile[j]);
                    }
                }

                if (effectsFile[i].Contains("FX_INFO_"))
                    startInfo = i;

                if (startInfo != -1)
                {
                    if (effectsFile[i + 2].Contains("FX_INFO_") || effectsFile[i + 2].Contains("LODSTART"))
                    {
                        for (int j = startInfo; j <= i; j++)
                        {
                            lines.Add(effectsFile[j]);
                        }
                        infos.Add(new Info(lines));

                        lines.Clear();

                        startInfo = -1;
                    }
                }

                if (effectsFile[i].Contains("LODEND"))
                {
                    esPrims.Add(effectsFile[i - 1]);
                    esPrims.Add(effectsFile[i]);
                    prims.Add(new Prim(ssPrims, esPrims, infos, textures));

                    ssPrims.Clear();
                    infos.Clear();
                    esPrims.Clear();
                    textures.Clear();
                }

                if (effectsFile[i].Contains("TXDNAME: NOTXDSET"))
                {
                    esEffects.Add(effectsFile[i - 1]);
                    esEffects.Add(effectsFile[i]);
                    effects.Add(new Effect(name, prims, ssEffects, esEffects));
                    lbEffects.Items.Add(name);

                    count++;
                    ssEffects.Clear();
                    prims.Clear();
                    esEffects.Clear();
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
            FileStream fs = new FileStream(effectsPath, FileMode.Create);
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
            if (btnFind.Text == "Поиск")
                effect = effects[selectedIndex];
            else
                effect = foundEffects[selectedIndex];
            return effect;
        }
        private Prim RewritePrim(Prim prim)
        {
            List<string> ssPrims = new List<string>();
            List<string> esPrims = new List<string>();
            List<Info> infos = new List<Info>();
            List<string> lines = new List<string>();
            List<string> textures = new List<string>();

            int startInfo = -1;

            for (int i = 0; i < Program.Code.Count; i++)
            {
                if (Program.Code[i].Contains("NUM_INFOS"))
                {
                    for (int j = 0; j <= i; j++)
                    {
                        ssPrims.Add(Program.Code[j]);
                        if (Program.Code[j].StartsWith("TEXTURE"))
                            textures.Add(Program.Code[j]);
                    }
                }

                if (Program.Code[i].Contains("FX_INFO_"))
                    startInfo = i;

                if (startInfo != -1)
                {
                    if (Program.Code[i + 2].Contains("FX_INFO_") || Program.Code[i + 2].Contains("LODSTART"))
                    {
                        for (int j = startInfo; j <= i; j++)
                        {
                            lines.Add(Program.Code[j]);
                        }
                        infos.Add(new Info(lines));

                        lines.Clear();

                        startInfo = -1;
                    }
                }

                if (Program.Code[i].Contains("LODEND"))
                {
                    esPrims.Add(Program.Code[i - 1]);
                    esPrims.Add(Program.Code[i]);

                    prim = new Prim(ssPrims, esPrims, infos, textures);

                    ssPrims.Clear();
                    infos.Clear();
                    esPrims.Clear();
                    textures.Clear();
                }
            }

            return prim;
        }
    }
}