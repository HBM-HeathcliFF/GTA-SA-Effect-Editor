using GTA_SA_Effect_Editor.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        BindingList<Effect> effects = new BindingList<Effect>();
        int selectedPrim, selectedInfo, selectedInterp, selectedKeyFloat;
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
                    ResetEffectView();
                    if (ReadEffects(egtbPath.Text))
                    {
                        FillListOfEffects();
                    }
                }
            }
            else
            {
                labelCount.Text = "";
                ResetEffectView();
                ResetSearchBlock();
                effects.Clear();
            }
        }
        #endregion

        #region Buttons
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = false,
                Title = "Укажите путь к файлу эффектов",
                InitialDirectory = GetLastDirectory(),
                Filter = "Текстовый файл (*.txt, *.fxp, *.fxs)|*.TXT;*.FXP;*.FXS;)"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ResetEffectView();
                if (ReadEffects(ofd.FileName))
                {
                    egtbPath.Text = ofd.FileName;
                    Registry.CurrentUser.CreateSubKey(@"Software\GTA SA Effect Editor").SetValue("path", ofd.FileName);
                    FillListOfEffects();
                }
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text == "Search")
            {
                if (tbFind.Text != "Texture name" && tbFind.Text != "" && lbEffects.Items.Count > 0)
                {
                    ResetEffectView();

                    FindEffects();

                    labelCount.Text = $"Effects count: {lbEffects.Items.Count}";
                    btnSearch.Text = "Reset";
                }
            }
            else
            {
                ResetEffectView();
                ResetSearchBlock();
                FillListOfEffects();
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Enabled = false;

            pnlButtons.Visible = false;

            int index = lbEffects.SelectedIndex;

            effects.RemoveAt(index);
            LbEffects_SelectedIndexChanged(null, null);

            labelCount.Text = $"Effects count: {lbEffects.Items.Count}";

            WriteEffectsFile();

            Enabled = true;
        }
        private void BtnImport_Click(object sender, EventArgs e)
        {
            Enabled = false;

            OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = false,
                Title = "Укажите путь к файлу эффектов",
                InitialDirectory = GetLastDirectory(),
                Filter = "Текстовый файл (*.txt, *.fxp, *.fxs)|*.TXT;*.FXP;*.FXS;"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string otherEffectsPath = ofd.FileName;
                List<string> otherEffectsFile = ReadEffectsFile(otherEffectsPath);
                if (otherEffectsFile != null)
                {
                    ImportEffect(otherEffectsPath, otherEffectsFile);
                }
            }

            Enabled = true;
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            Enabled = false;

            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Экспорт эффекта",
                InitialDirectory = GetLastDirectory(),
                Filter = "Эффект (*.fxs)|*.fxs|Контейнер эффектов (*.fxp)|*.fxp|Текстовый файл (*.txt)|*.txt",
                AddExtension = true,
                FileName = "Новый эффект"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
                    {
                        Effect effect = effects[lbEffects.SelectedIndex];
                        foreach (var line in effect.GetLines())
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to export effect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Enabled = true;
        }
        private void BtnNewEffect_Click(object sender, EventArgs e)
        {
            new frmCreateNewEffect().ShowDialog();
            
            if (Program.EffectName != "")
            {
                EffectParser ep = new EffectParser();
                Effect effect = ep.ParseEffect(FxsTemplates.Effect.ToList(), 0) as Effect;
                effect.Name = Program.EffectName;
                effects.Add(effect);
                WriteEffectsFile();
            }
        }
        private void BtnShowEffectCode_Click(object sender, EventArgs e)
        {
            Program.Code.Clear();
            PrintCode(effects[lbEffects.SelectedIndex]);
        }
        private void BtnShowCode_Click(object sender, EventArgs e)
        {
            Program.Code.Clear();
            var node = GetSelectedNode();
            PrintCode(node);
        }
        private void BtnDelTreeItem_Click(object sender, EventArgs e)
        {
            IFxsComponent selectedNode = GetSelectedNode();

            switch (btnDelTreeItem.Text)
            {
                case "Delete PRIM":
                    RemoveNode(ref selectedNode, effects[lbEffects.SelectedIndex]);
                    break;
                case "Delete INFO":
                    RemoveNode(ref selectedNode, effects[lbEffects.SelectedIndex].Nodes.ToList()[selectedPrim]);
                    break;
                case "Delete KEYFLOAT":
                    RemoveNode(ref selectedNode, effects[lbEffects.SelectedIndex].Nodes.ToList()[selectedPrim].Nodes.ToList()[selectedInfo].Nodes.ToList()[selectedInterp]);
                    break;
            }
            WriteEffectsFile();
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            EffectParser ep = new EffectParser();
            switch (btnAdd.Text)
            {
                case "Add PRIM":
                    var prim = ep.ParsePrim(FxsTemplates.Prim.ToList(), 0);
                    effects[lbEffects.SelectedIndex].Nodes.Add(prim);
                    treeView.Nodes.Add("PRIM");
                    break;
                case "Add INFO":
                    new frmSelectInfo().ShowDialog();
                    if (FxsTemplates.Infos.SelectedInfo != "")
                    {
                        var info = ep.ParseInfo(FxsTemplates.Infos.SelectedInfo.CreateAccordingToTemplate().ToList(), 0);
                        effects[lbEffects.SelectedIndex].Nodes.ToList()[selectedPrim].Nodes.Add(info);
                        treeView.Nodes[selectedPrim].Nodes.Add(info.Name);
                    }
                    break;
                case "Add KEYFLOAT":
                    var keyfloat = ep.ParseKeyFloat(FxsTemplates.KeyFloat.ToList(), 0);
                    effects[lbEffects.SelectedIndex].Nodes.ToList()[selectedPrim].Nodes.ToList()[selectedInfo].Nodes.ToList()[selectedInterp].Nodes.Add(keyfloat);
                    treeView.Nodes[selectedPrim].Nodes[selectedInfo].Nodes[selectedInterp].Nodes.Add("KEYFLOAT");
                    break;
            }
            WriteEffectsFile();
        }
        #endregion

        private void LbEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbEffects.SelectedIndex != -1)
            {
                pnlButtons.Visible = true;
                btnShowCode.Visible = false;

                UpdateTreeView();

                btnAdd.Text = "Add PRIM";
                btnAdd.Visible = true;
                btnDelTreeItem.Visible = false;
            }
        }
        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnShowCode.Visible = true;

            IFxsComponent selectedNode = GetSelectedNode();
            switch (selectedNode.Type)
            {
                case CodeBlockType.PRIM:
                    btnDelTreeItem.Text = "Delete PRIM";
                    btnDelTreeItem.Visible = true;
                    btnAdd.Text = "Add INFO";
                    btnAdd.Visible = true;
                    break;
                case CodeBlockType.INFO:
                    btnDelTreeItem.Text = "Delete INFO";
                    btnDelTreeItem.Visible = true;
                    btnAdd.Visible = false;
                    break;
                case CodeBlockType.INTERP:
                    btnDelTreeItem.Visible = false;
                    btnAdd.Text = "Add KEYFLOAT";
                    btnAdd.Visible = true;
                    break;
                case CodeBlockType.KEYFLOAT:
                    btnDelTreeItem.Text = "Delete KEYFLOAT";
                    btnDelTreeItem.Visible = true;
                    btnAdd.Visible = false;
                    break;
            }
        }

        #endregion

        public frmMain()
        {
            ForbidMultipleLaunches();
            InitializeComponent();

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            toolTip.SetToolTip(btnDelete, "Delete effect");
            toolTip.SetToolTip(btnImport, "Import effect in another effect(s) file");
            toolTip.SetToolTip(btnExport, "Create a new file with the selected effect");
            toolTip.SetToolTip(btnNewEffect, "Create a new effect");
            toolTip.SetToolTip(btnShowEffectCode, "Edit the code of the selected effect");

            Animator.Start();
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\GTA SA Effect Editor"))
                {
                    string path = key.GetValue("path").ToString();
                    if (File.Exists(path) && ReadEffects(path))
                    {
                        egtbPath.Text = path;
                        FillListOfEffects();
                    }
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
        private string GetLastDirectory()
        {
            if (egtbPath.Text != "")
                return egtbPath.Text;
            else
                return @"C:\";
        }

        private bool ReadEffects(string path)
        {
            if (effects != null)
            {
                effects.Clear();
            }

            List<string> lines = ReadEffectsFile(path);

            if (lines != null)
            {
                new EffectParser().Parse(lines, ref effects);
                return true;
            }
            return false;
        }
        private List<string> ReadEffectsFile(string path)
        {
            List<string> effects_fxp = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        effects_fxp.Add(sr.ReadLine());
                    }
                }
                return effects_fxp;
            }
            catch (Exception)
            {
                MessageBox.Show("File opening error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void FillListOfEffects()
        {
            lbEffects.DataSource = effects;
            lbEffects.DisplayMember = "Name";

            pnlButtons.Visible = true;
            labelCount.Text = $"Effects count: {lbEffects.Items.Count}";

            LbEffects_SelectedIndexChanged(null, null);
        }
        private void UpdateTreeView()
        {
            treeView.Nodes.Clear();
            AddNodes((lbEffects.SelectedItem as Effect).Nodes, treeView.Nodes);
        }
        private void Remove(IFxsComponent node)
        {
            switch (node.Type)
            {
                case CodeBlockType.PRIM:
                    RemoveBranch(
                        node,
                        effects[lbEffects.SelectedIndex].Nodes,
                        treeView.Nodes[selectedPrim]);
                    break;
                case CodeBlockType.INFO:
                    RemoveBranch(
                        node,
                        effects[lbEffects.SelectedIndex].Nodes.ToList()[selectedPrim].Nodes,
                        treeView.Nodes[selectedPrim].Nodes[selectedInfo]);
                    break;
                case CodeBlockType.INTERP:
                    RemoveBranch(
                        node,
                        effects[lbEffects.SelectedIndex].Nodes.ToList()[selectedPrim].Nodes.ToList()[selectedInfo].Nodes,
                        treeView.Nodes[selectedPrim].Nodes[selectedInfo].Nodes[selectedInterp]);
                    break;
                case CodeBlockType.KEYFLOAT:
                    RemoveBranch(
                        node,
                        effects[lbEffects.SelectedIndex].Nodes.ToList()[selectedPrim].Nodes.ToList()[selectedInfo].Nodes.ToList()[selectedInterp].Nodes,
                        treeView.Nodes[selectedPrim].Nodes[selectedInfo].Nodes[selectedInterp].Nodes[selectedKeyFloat]);
                    break;
            }
        }
        private void RemoveBranch(IFxsComponent node, ICollection<IFxsComponent> from1, TreeNode from2)
        {
            if (from1.Remove(node))
            {
                from2.Remove();
            }
            else
            {
                MessageBox.Show("Failed to remove this item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateBranch(IFxsComponent node)
        {
            switch (node.Type)
            {
                case CodeBlockType.EFFECT:
                    treeView.Nodes.Clear();
                    AddNodes(node.Nodes, treeView.Nodes);
                    break;
                case CodeBlockType.PRIM:
                    treeView.Nodes[selectedPrim].Nodes.Clear();
                    AddNodes(node.Nodes, treeView.Nodes[selectedPrim].Nodes);
                    break;
                case CodeBlockType.INFO:
                    treeView.Nodes[selectedPrim].Nodes[selectedInfo].Nodes.Clear();
                    AddNodes(node.Nodes, treeView.Nodes[selectedPrim].Nodes[selectedInfo].Nodes);
                    break;
                case CodeBlockType.INTERP:
                    treeView.Nodes[selectedPrim].Nodes[selectedInfo].Nodes[selectedInterp].Nodes.Clear();
                    AddNodes(node.Nodes, treeView.Nodes[selectedPrim].Nodes[selectedInfo].Nodes[selectedInterp].Nodes);
                    break;
            }
        }
        private void AddNodes(IEnumerable<IFxsComponent> fxsComponents, TreeNodeCollection nodes)
        {
            foreach (var component in fxsComponents)
            {
                var node = nodes.Add(component.Name);
                if (component.Nodes != null)
                {
                    AddNodes(component.Nodes, node.Nodes);
                }
            }
        }
        private void FindEffects()
        {
            BindingList<Effect> foundEffects = new BindingList<Effect>();
            bool isFound = false;
            foreach (Effect effect in effects)
            {
                foreach (Prim prim in effect.Nodes)
                {
                    foreach (string texture in prim.Textures)
                    {
                        if (texture.IndexOf(tbFind.Text, StringComparison.OrdinalIgnoreCase) != -1)
                        {
                            foundEffects.Add(effect);
                            isFound = true;
                            break;
                        }
                    }
                    if (isFound)
                        break;
                }
                isFound = false;
            }
            lbEffects.DataSource = foundEffects;
        }
        private void WriteEffectsFile()
        {
            try
            {
                FileStream fs = new FileStream(egtbPath.Text, FileMode.Create);
                using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
                {
                    sw.WriteLine("FX_PROJECT_DATA:");
                    sw.WriteLine();

                    foreach (var effect in effects)
                    {
                        foreach (var line in effect.GetLines())
                        {
                            sw.WriteLine(line);
                        }
                        sw.WriteLine();
                    }

                    sw.WriteLine("FX_PROJECT_DATA_END:");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to overwrite effects file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private IFxsComponent GetSelectedNode()
        {
            for (int i = 0; i < treeView.Nodes.Count; i++)
            {
                if (treeView.Nodes[i] == treeView.SelectedNode)
                {
                    selectedPrim = i;
                    return effects[lbEffects.SelectedIndex].Nodes.ToList()[i];
                }
                for (int j = 0; j < treeView.Nodes[i].Nodes.Count; j++)
                {
                    if (treeView.Nodes[i].Nodes[j] == treeView.SelectedNode)
                    {
                        selectedPrim = i;
                        selectedInfo = j;
                        return effects[lbEffects.SelectedIndex].Nodes.ToList()[i].Nodes.ToList()[j];
                    }
                    for (int k = 0; k < treeView.Nodes[i].Nodes[j].Nodes.Count; k++)
                    {
                        if (treeView.Nodes[i].Nodes[j].Nodes[k] == treeView.SelectedNode)
                        {
                            selectedPrim = i;
                            selectedInfo = j;
                            selectedInterp = k;
                            return effects[lbEffects.SelectedIndex].Nodes.ToList()[i].Nodes.ToList()[j].Nodes.ToList()[k];
                        }
                        for (int m = 0; m < treeView.Nodes[i].Nodes[j].Nodes[k].Nodes.Count; m++)
                        {
                            if (treeView.Nodes[i].Nodes[j].Nodes[k].Nodes[m] == treeView.SelectedNode)
                            {
                                selectedPrim = i;
                                selectedInfo = j;
                                selectedInterp = k;
                                selectedKeyFloat = m;
                                return effects[lbEffects.SelectedIndex].Nodes.ToList()[i].Nodes.ToList()[j].Nodes.ToList()[k].Nodes.ToList()[m];
                            }
                        }
                    }
                }
            }

            return null;
        }
        private void RemoveNode(ref IFxsComponent node, IFxsComponent from)
        {
            from.Nodes.Remove(node);
            node.Dispose();
            node = null;

            treeView.SelectedNode.Remove();
        }

        private void ImportEffect(string path, List<string> lines)
        {
            int startLine = 0, endLine = 0;
            Effect effect = effects[lbEffects.SelectedIndex];

            bool isEffectExist = FindExistEffect(lines, effect, ref startLine, ref endLine);

            using (FileStream fs = new FileStream(path, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
            {
                bool isNeedToInsertTheEffect = true;
                if (isEffectExist)
                {
                    if (startLine != 0)
                    {
                        isNeedToInsertTheEffect = false;
                    }
                    for (int i = 0; i < lines.Count; i++)
                    {
                        if (isNeedToInsertTheEffect)
                        {
                            foreach (var line in effect.GetLines())
                            {
                                sw.WriteLine(line);
                            }
                            i = endLine;
                            isNeedToInsertTheEffect = false;
                        }
                        else
                        {
                            sw.WriteLine(lines[i]);
                            if (i == startLine - 1)
                            {
                                isNeedToInsertTheEffect = true;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < lines.Count; i++)
                    {
                        if (lines[i].Contains("FX_PROJECT_DATA_END"))
                        {
                            foreach (var line in effect.GetLines())
                            {
                                sw.WriteLine(line);
                            }
                            sw.WriteLine();
                            sw.WriteLine("FX_PROJECT_DATA_END:");
                            isNeedToInsertTheEffect = false;
                            break;
                        }
                        else
                        {
                            sw.WriteLine(lines[i]);
                        }
                    }

                    if (isNeedToInsertTheEffect)
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
        private bool FindExistEffect(List<string> lines, Effect effect, ref int startLine, ref int endLine)
        {
            bool isEffectExist = false;
            for (int i = lines.Count - 1; i >= 0; i--)
            {
                if (lines[i].Contains("TXDNAME: NOTXDSET"))
                {
                    endLine = i;
                }
                if (lines[i].Contains("FILENAME"))
                {
                    int startIndex = lines[i].LastIndexOf('/') + 1;
                    int endIndex = lines[i].IndexOf('.');
                    string name = lines[i].Substring(startIndex, endIndex - startIndex);
                    if (name == effect.Name)
                    {
                        isEffectExist = true;
                    }
                }
                if (lines[i].Contains("FX_SYSTEM_DATA"))
                {
                    if (isEffectExist)
                    {
                        startLine = i;
                        break;
                    }
                }
            }
            return isEffectExist;
        }

        private void OpenCodeEditor(List<string> lines)
        {
            foreach (var line in lines)
            {
                Program.Code.Add(line);
            }

            new frmShowCode().ShowDialog();
        }
        private void PrintCode(IFxsComponent fxsComponent)
        {
            OpenCodeEditor(fxsComponent.GetLines());
            if (Program.IsEdited)
            {
                EffectParser ep = new EffectParser();

                if (Program.Code.Count > 0)
                {
                    fxsComponent.Copy(ep.Parse(Program.Code, 0, fxsComponent.Type));
                    UpdateBranch(fxsComponent);
                }
                else
                {
                    Remove(fxsComponent);
                }

                WriteEffectsFile();
            }
        }

        private void ResetEffectView()
        {
            treeView.Nodes.Clear();

            btnAdd.Visible = false;
            btnShowCode.Visible = false;
            btnDelTreeItem.Visible = false;
            pnlButtons.Visible = false;
            labelCount.Text = "";

            this.Update();
        }
        private void ResetSearchBlock()
        {
            tbFind.Text = "Texture name";
            tbFind.ForeColor = SystemColors.ControlDark;
            btnSearch.Text = "Search";
        }
    }
}