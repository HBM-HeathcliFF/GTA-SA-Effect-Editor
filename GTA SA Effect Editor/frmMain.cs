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

        #region Fields
        private BindingList<Effect> _effects = new BindingList<Effect>();
        private int _selectedPrim, _selectedInfo, _selectedInterp, _selectedKeyFloat;
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
                    GetEffectsFromFile(egtbPath.Text);
                    if (_effects.Count > 0)
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
                _effects.Clear();
            }
        }
        #endregion

        #region Buttons
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Title = "Укажите путь к файлу эффектов",
                InitialDirectory = GetLastDirectory(),
                Filter = "Текстовый файл (*.txt, *.fxp, *.fxs)|*.TXT;*.FXP;*.FXS;)"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ResetEffectView();
                GetEffectsFromFile(openFileDialog.FileName);
                if (_effects.Count > 0)
                {
                    egtbPath.Text = openFileDialog.FileName;
                    Registry.CurrentUser.CreateSubKey(@"Software\GTA SA Effect Editor").SetValue("path", openFileDialog.FileName);
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

            _effects.RemoveAt(index);
            LbEffects_SelectedIndexChanged(null, null);

            labelCount.Text = $"Effects count: {lbEffects.Items.Count}";

            WriteEffectsFile(egtbPath.Text, _effects);

            Enabled = true;
        }
        private void BtnImport_Click(object sender, EventArgs e)
        {
            Enabled = false;

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Title = "Укажите путь к файлу эффектов",
                InitialDirectory = GetLastDirectory(),
                Filter = "Текстовый файл (*.txt, *.fxp, *.fxs)|*.TXT;*.FXP;*.FXS;"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImportEffect(openFileDialog.FileName, _effects[lbEffects.SelectedIndex]);
            }

            Enabled = true;
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            Enabled = false;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Экспорт эффекта",
                InitialDirectory = GetLastDirectory(),
                Filter = "Эффект (*.fxs)|*.fxs|Контейнер эффектов (*.fxp)|*.fxp|Текстовый файл (*.txt)|*.txt",
                AddExtension = true,
                FileName = "Новый эффект"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.GetEncoding(1251)))
                    {
                        Effect effect = _effects[lbEffects.SelectedIndex];
                        foreach (var line in effect.GetLines())
                        {
                            streamWriter.WriteLine(line);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to export effect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Enabled = true;
        }//
        private void BtnNewEffect_Click(object sender, EventArgs e)
        {
            new frmCreateNewEffect().ShowDialog();
            
            if (Program.EffectName != "")
            {
                Effect effect = EffectParser.ParseEffect(FxsTemplates.Effect.ToList(), 0) as Effect;
                effect.Name = Program.EffectName;
                _effects.Add(effect);
                WriteEffectsFile(egtbPath.Text, _effects);
            }
        }
        private void BtnShowEffectCode_Click(object sender, EventArgs e)
        {
            Program.Code.Clear();
            PrintCode(_effects[lbEffects.SelectedIndex]);
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
                    RemoveNode(ref selectedNode, _effects[lbEffects.SelectedIndex]);
                    break;
                case "Delete INFO":
                    RemoveNode(ref selectedNode, _effects[lbEffects.SelectedIndex].Nodes.ToList()[_selectedPrim]);
                    break;
                case "Delete KEYFLOAT":
                    RemoveNode(ref selectedNode, _effects[lbEffects.SelectedIndex].Nodes.ToList()[_selectedPrim].Nodes.ToList()[_selectedInfo].Nodes.ToList()[_selectedInterp]);
                    break;
            }
            WriteEffectsFile(egtbPath.Text, _effects);
        }//
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            switch (btnAdd.Text)
            {
                case "Add PRIM":
                    var prim = EffectParser.ParsePrim(FxsTemplates.Prim.ToList(), 0);
                    _effects[lbEffects.SelectedIndex].Nodes.Add(prim);
                    treeView.Nodes.Add("PRIM");
                    break;
                case "Add INFO":
                    new frmSelectInfo().ShowDialog();
                    if (FxsTemplates.Infos.SelectedInfo != "")
                    {
                        var info = EffectParser.ParseInfo(FxsTemplates.Infos.SelectedInfo.CreateAccordingToTemplate().ToList(), 0);
                        _effects[lbEffects.SelectedIndex].Nodes.ToList()[_selectedPrim].Nodes.Add(info);
                        treeView.Nodes[_selectedPrim].Nodes.Add(info.Name);
                    }
                    break;
                case "Add KEYFLOAT":
                    var keyfloat = EffectParser.ParseKeyFloat(FxsTemplates.KeyFloat.ToList(), 0);
                    _effects[lbEffects.SelectedIndex].Nodes.ToList()[_selectedPrim].Nodes.ToList()[_selectedInfo].Nodes.ToList()[_selectedInterp].Nodes.Add(keyfloat);
                    treeView.Nodes[_selectedPrim].Nodes[_selectedInfo].Nodes[_selectedInterp].Nodes.Add("KEYFLOAT");
                    break;
            }
            WriteEffectsFile(egtbPath.Text, _effects);
        }//
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
                case FxsComponentType.PRIM:
                    btnDelTreeItem.Text = "Delete PRIM";
                    btnDelTreeItem.Visible = true;
                    btnAdd.Text = "Add INFO";
                    btnAdd.Visible = true;
                    break;
                case FxsComponentType.INFO:
                    btnDelTreeItem.Text = "Delete INFO";
                    btnDelTreeItem.Visible = true;
                    btnAdd.Visible = false;
                    break;
                case FxsComponentType.INTERP:
                    btnDelTreeItem.Visible = false;
                    btnAdd.Text = "Add KEYFLOAT";
                    btnAdd.Visible = true;
                    break;
                case FxsComponentType.KEYFLOAT:
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

            ConfigureToolTips();
            Animator.Start();
            TryOpenEffectFile();
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Registry.CurrentUser.CreateSubKey(@"Software\GTA SA Effect Editor").SetValue("path", egtbPath.Text);
        }
        private void ForbidMultipleLaunches()
        {
            Process current_process = Process.GetCurrentProcess();
            Process[] other_processes =
                Process.GetProcessesByName(current_process.ProcessName).Where(process => process.Id != current_process.Id).ToArray();

            foreach (var process in other_processes)
            {
                process.WaitForInputIdle(1000);

                IntPtr hWnd = process.MainWindowHandle;
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
        private void ConfigureToolTips()
        {
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            toolTip.SetToolTip(btnDelete, "Delete effect");
            toolTip.SetToolTip(btnImport, "Import effect in another effect(s) file");
            toolTip.SetToolTip(btnExport, "Create a new file with the selected effect");
            toolTip.SetToolTip(btnNewEffect, "Create a new effect");
            toolTip.SetToolTip(btnShowEffectCode, "Edit the code of the selected effect");
        }
        private void TryOpenEffectFile()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\GTA SA Effect Editor"))
                {
                    string path = key.GetValue("path").ToString();
                    GetEffectsFromFile(path);
                    if (File.Exists(path) && _effects.Count > 0)
                    {
                        egtbPath.Text = path;
                        FillListOfEffects();
                    }
                }
            }
            catch (Exception) { }
        }

        private void GetEffectsFromFile(string path)
        {
            _effects?.Clear();

            List<string> lines = ReadEffectsFile(path);

            if (lines != null)
            {
                _effects = EffectParser.Parse(lines);
            }
        }//
        private List<string> ReadEffectsFile(string path)
        {
            try
            {
                return File.ReadAllLines(path).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("File opening error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }//
        private void FillListOfEffects()
        {
            lbEffects.DataSource = _effects;
            lbEffects.DisplayMember = "Name";

            pnlButtons.Visible = true;
            labelCount.Text = $"Effects count: {lbEffects.Items.Count}";

            LbEffects_SelectedIndexChanged(null, null);
        }//
        private void UpdateTreeView()
        {
            treeView.Nodes.Clear();
            AddNodes((lbEffects.SelectedItem as Effect).Nodes, treeView.Nodes);
        }//
        private void Remove(IFxsComponent node)
        {
            switch (node.Type)
            {
                case FxsComponentType.PRIM:
                    RemoveBranch(
                        node,
                        _effects[lbEffects.SelectedIndex].Nodes,
                        treeView.Nodes[_selectedPrim]);
                    break;
                case FxsComponentType.INFO:
                    RemoveBranch(
                        node,
                        _effects[lbEffects.SelectedIndex].Nodes.ToList()[_selectedPrim].Nodes,
                        treeView.Nodes[_selectedPrim].Nodes[_selectedInfo]);
                    break;
                case FxsComponentType.INTERP:
                    RemoveBranch(
                        node,
                        _effects[lbEffects.SelectedIndex].Nodes.ToList()[_selectedPrim].Nodes.ToList()[_selectedInfo].Nodes,
                        treeView.Nodes[_selectedPrim].Nodes[_selectedInfo].Nodes[_selectedInterp]);
                    break;
                case FxsComponentType.KEYFLOAT:
                    RemoveBranch(
                        node,
                        _effects[lbEffects.SelectedIndex].Nodes.ToList()[_selectedPrim].Nodes.ToList()[_selectedInfo].Nodes.ToList()[_selectedInterp].Nodes,
                        treeView.Nodes[_selectedPrim].Nodes[_selectedInfo].Nodes[_selectedInterp].Nodes[_selectedKeyFloat]);
                    break;
            }
        }//
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
        }//
        private void UpdateBranch(IFxsComponent node)
        {
            switch (node.Type)
            {
                case FxsComponentType.EFFECT:
                    treeView.Nodes.Clear();
                    AddNodes(node.Nodes, treeView.Nodes);
                    break;
                case FxsComponentType.PRIM:
                    treeView.Nodes[_selectedPrim].Nodes.Clear();
                    AddNodes(node.Nodes, treeView.Nodes[_selectedPrim].Nodes);
                    break;
                case FxsComponentType.INFO:
                    treeView.Nodes[_selectedPrim].Nodes[_selectedInfo].Nodes.Clear();
                    AddNodes(node.Nodes, treeView.Nodes[_selectedPrim].Nodes[_selectedInfo].Nodes);
                    break;
                case FxsComponentType.INTERP:
                    treeView.Nodes[_selectedPrim].Nodes[_selectedInfo].Nodes[_selectedInterp].Nodes.Clear();
                    AddNodes(node.Nodes, treeView.Nodes[_selectedPrim].Nodes[_selectedInfo].Nodes[_selectedInterp].Nodes);
                    break;
            }
        }//
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
        }//
        private void FindEffects()
        {
            BindingList<Effect> foundEffects = new BindingList<Effect>();
            bool isFound = false;
            foreach (Effect effect in _effects)
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
        private void WriteEffectsFile(string path, BindingList<Effect> effectsList)
        {
            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Create);
                using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.GetEncoding(1251)))
                {
                    streamWriter.WriteLine("FX_PROJECT_DATA:");
                    streamWriter.WriteLine();

                    foreach (var effect in effectsList)
                    {
                        foreach (var line in effect.GetLines())
                        {
                            streamWriter.WriteLine(line);
                        }
                        streamWriter.WriteLine();
                    }

                    streamWriter.WriteLine("FX_PROJECT_DATA_END:");
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
                    _selectedPrim = i;
                    return _effects[lbEffects.SelectedIndex].Nodes.ToList()[i];
                }
                for (int j = 0; j < treeView.Nodes[i].Nodes.Count; j++)
                {
                    if (treeView.Nodes[i].Nodes[j] == treeView.SelectedNode)
                    {
                        _selectedPrim = i;
                        _selectedInfo = j;
                        return _effects[lbEffects.SelectedIndex].Nodes.ToList()[i].Nodes.ToList()[j];
                    }
                    for (int k = 0; k < treeView.Nodes[i].Nodes[j].Nodes.Count; k++)
                    {
                        if (treeView.Nodes[i].Nodes[j].Nodes[k] == treeView.SelectedNode)
                        {
                            _selectedPrim = i;
                            _selectedInfo = j;
                            _selectedInterp = k;
                            return _effects[lbEffects.SelectedIndex].Nodes.ToList()[i].Nodes.ToList()[j].Nodes.ToList()[k];
                        }
                        for (int m = 0; m < treeView.Nodes[i].Nodes[j].Nodes[k].Nodes.Count; m++)
                        {
                            if (treeView.Nodes[i].Nodes[j].Nodes[k].Nodes[m] == treeView.SelectedNode)
                            {
                                _selectedPrim = i;
                                _selectedInfo = j;
                                _selectedInterp = k;
                                _selectedKeyFloat = m;
                                return _effects[lbEffects.SelectedIndex].Nodes.ToList()[i].Nodes.ToList()[j].Nodes.ToList()[k].Nodes.ToList()[m];
                            }
                        }
                    }
                }
            }

            return null;
        }//
        private void RemoveNode(ref IFxsComponent node, IFxsComponent from)
        {
            from.Nodes.Remove(node);
            node.Dispose();
            node = null;

            treeView.SelectedNode.Remove();
        }//

        private void ImportEffect(string path, Effect effect)
        {
            BindingList<Effect> destinationEffects = EffectParser.Parse(ReadEffectsFile(path));

            destinationEffects.Remove(destinationEffects.FirstOrDefault(e => e.Name == effect.Name));
            destinationEffects.Add(effect);

            WriteEffectsFile(path, destinationEffects);
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
                if (Program.Code.Count > 0)
                {
                    fxsComponent.Copy(EffectParser.Parse(Program.Code, 0, fxsComponent.Type));
                    UpdateBranch(fxsComponent);
                }
                else
                {
                    Remove(fxsComponent);
                }

                WriteEffectsFile(egtbPath.Text, _effects);
            }
        }//

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