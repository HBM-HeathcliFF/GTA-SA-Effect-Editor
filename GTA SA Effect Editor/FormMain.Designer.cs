
namespace GTA_SA_Effect_Editor
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.egoldsFormStyle1 = new yt_DesignUI.Components.EgoldsFormStyle(this.components);
            this.egtbPath = new yt_DesignUI.EgoldsGoogleTextBox();
            this.btnBrowse = new yt_DesignUI.yt_Button();
            this.gbEffects = new System.Windows.Forms.GroupBox();
            this.btnAdd = new yt_DesignUI.yt_Button();
            this.btnDelTreeItem = new yt_DesignUI.yt_Button();
            this.btnShowCode = new yt_DesignUI.yt_Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.labelCount = new System.Windows.Forms.Label();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.btnSearch = new yt_DesignUI.yt_Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbEffects = new System.Windows.Forms.ListBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnShowEffectCode = new System.Windows.Forms.Button();
            this.btnNewEffect = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.gbEffects.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // egoldsFormStyle1
            // 
            this.egoldsFormStyle1.AllowUserResize = false;
            this.egoldsFormStyle1.BackColor = System.Drawing.Color.White;
            this.egoldsFormStyle1.ContextMenuForm = null;
            this.egoldsFormStyle1.ControlBoxButtonsWidth = 20;
            this.egoldsFormStyle1.EnableControlBoxIconsLight = false;
            this.egoldsFormStyle1.EnableControlBoxMouseLight = false;
            this.egoldsFormStyle1.Form = this;
            this.egoldsFormStyle1.FormStyle = yt_DesignUI.Components.EgoldsFormStyle.fStyle.SimpleDark;
            this.egoldsFormStyle1.HeaderColor = System.Drawing.Color.DarkCyan;
            this.egoldsFormStyle1.HeaderColorAdditional = System.Drawing.Color.Teal;
            this.egoldsFormStyle1.HeaderColorGradientEnable = true;
            this.egoldsFormStyle1.HeaderColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.egoldsFormStyle1.HeaderHeight = 38;
            this.egoldsFormStyle1.HeaderImage = null;
            this.egoldsFormStyle1.HeaderTextColor = System.Drawing.Color.White;
            this.egoldsFormStyle1.HeaderTextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            // 
            // egtbPath
            // 
            this.egtbPath.BackColor = System.Drawing.Color.White;
            this.egtbPath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.egtbPath.BorderColorNotActive = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.egtbPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.egtbPath.Font = new System.Drawing.Font("Arial", 11.25F);
            this.egtbPath.FontTextPreview = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.egtbPath.ForeColor = System.Drawing.Color.Black;
            this.egtbPath.Location = new System.Drawing.Point(10, 8);
            this.egtbPath.Name = "egtbPath";
            this.egtbPath.SelectionStart = 0;
            this.egtbPath.Size = new System.Drawing.Size(472, 40);
            this.egtbPath.TabIndex = 0;
            this.egtbPath.TextInput = "";
            this.egtbPath.TextPreview = "Path to the effects file";
            this.egtbPath.UseSystemPasswordChar = false;
            this.egtbPath.TextChanged += new System.EventHandler(this.EgtbPath_TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.DarkCyan;
            this.btnBrowse.BackColorAdditional = System.Drawing.Color.Gray;
            this.btnBrowse.BackColorGradientEnabled = false;
            this.btnBrowse.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.btnBrowse.BorderColor = System.Drawing.Color.Teal;
            this.btnBrowse.BorderColorEnabled = false;
            this.btnBrowse.BorderColorOnHover = System.Drawing.Color.Teal;
            this.btnBrowse.BorderColorOnHoverEnabled = false;
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(488, 14);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.RippleColor = System.Drawing.Color.Black;
            this.btnBrowse.RoundingEnable = true;
            this.btnBrowse.Size = new System.Drawing.Size(99, 34);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.TextHover = null;
            this.btnBrowse.UseDownPressEffectOnClick = false;
            this.btnBrowse.UseRippleEffect = true;
            this.btnBrowse.UseZoomEffectOnHover = false;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // gbEffects
            // 
            this.gbEffects.Controls.Add(this.btnAdd);
            this.gbEffects.Controls.Add(this.btnDelTreeItem);
            this.gbEffects.Controls.Add(this.btnShowCode);
            this.gbEffects.Controls.Add(this.treeView);
            this.gbEffects.Controls.Add(this.pnlButtons);
            this.gbEffects.Controls.Add(this.labelCount);
            this.gbEffects.Controls.Add(this.tbFind);
            this.gbEffects.Controls.Add(this.btnSearch);
            this.gbEffects.Controls.Add(this.label1);
            this.gbEffects.Controls.Add(this.lbEffects);
            this.gbEffects.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbEffects.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbEffects.Location = new System.Drawing.Point(10, 54);
            this.gbEffects.Name = "gbEffects";
            this.gbEffects.Size = new System.Drawing.Size(577, 441);
            this.gbEffects.TabIndex = 2;
            this.gbEffects.TabStop = false;
            this.gbEffects.Text = "Effects";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkCyan;
            this.btnAdd.BackColorAdditional = System.Drawing.Color.Gray;
            this.btnAdd.BackColorGradientEnabled = false;
            this.btnAdd.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.btnAdd.BorderColor = System.Drawing.Color.Teal;
            this.btnAdd.BorderColorEnabled = false;
            this.btnAdd.BorderColorOnHover = System.Drawing.Color.Teal;
            this.btnAdd.BorderColorOnHoverEnabled = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(444, 392);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RippleColor = System.Drawing.Color.Black;
            this.btnAdd.RoundingEnable = true;
            this.btnAdd.Size = new System.Drawing.Size(124, 36);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add PRIM";
            this.btnAdd.TextHover = null;
            this.btnAdd.UseDownPressEffectOnClick = false;
            this.btnAdd.UseRippleEffect = true;
            this.btnAdd.UseZoomEffectOnHover = false;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnDelTreeItem
            // 
            this.btnDelTreeItem.BackColor = System.Drawing.Color.DarkCyan;
            this.btnDelTreeItem.BackColorAdditional = System.Drawing.Color.Gray;
            this.btnDelTreeItem.BackColorGradientEnabled = false;
            this.btnDelTreeItem.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.btnDelTreeItem.BorderColor = System.Drawing.Color.Teal;
            this.btnDelTreeItem.BorderColorEnabled = false;
            this.btnDelTreeItem.BorderColorOnHover = System.Drawing.Color.Teal;
            this.btnDelTreeItem.BorderColorOnHoverEnabled = false;
            this.btnDelTreeItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelTreeItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelTreeItem.ForeColor = System.Drawing.Color.White;
            this.btnDelTreeItem.Location = new System.Drawing.Point(204, 392);
            this.btnDelTreeItem.Name = "btnDelTreeItem";
            this.btnDelTreeItem.RippleColor = System.Drawing.Color.Black;
            this.btnDelTreeItem.RoundingEnable = true;
            this.btnDelTreeItem.Size = new System.Drawing.Size(124, 36);
            this.btnDelTreeItem.TabIndex = 15;
            this.btnDelTreeItem.Text = "Delete";
            this.btnDelTreeItem.TextHover = null;
            this.btnDelTreeItem.UseDownPressEffectOnClick = false;
            this.btnDelTreeItem.UseRippleEffect = true;
            this.btnDelTreeItem.UseZoomEffectOnHover = false;
            this.btnDelTreeItem.Visible = false;
            this.btnDelTreeItem.Click += new System.EventHandler(this.BtnDelTreeItem_Click);
            // 
            // btnShowCode
            // 
            this.btnShowCode.BackColor = System.Drawing.Color.DarkCyan;
            this.btnShowCode.BackColorAdditional = System.Drawing.Color.Gray;
            this.btnShowCode.BackColorGradientEnabled = false;
            this.btnShowCode.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.btnShowCode.BorderColor = System.Drawing.Color.Teal;
            this.btnShowCode.BorderColorEnabled = false;
            this.btnShowCode.BorderColorOnHover = System.Drawing.Color.Teal;
            this.btnShowCode.BorderColorOnHoverEnabled = false;
            this.btnShowCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnShowCode.ForeColor = System.Drawing.Color.White;
            this.btnShowCode.Location = new System.Drawing.Point(334, 392);
            this.btnShowCode.Name = "btnShowCode";
            this.btnShowCode.RippleColor = System.Drawing.Color.Black;
            this.btnShowCode.RoundingEnable = true;
            this.btnShowCode.Size = new System.Drawing.Size(104, 36);
            this.btnShowCode.TabIndex = 14;
            this.btnShowCode.Text = "Show code";
            this.btnShowCode.TextHover = null;
            this.btnShowCode.UseDownPressEffectOnClick = false;
            this.btnShowCode.UseRippleEffect = true;
            this.btnShowCode.UseZoomEffectOnHover = false;
            this.btnShowCode.Visible = false;
            this.btnShowCode.Click += new System.EventHandler(this.BtnShowCode_Click);
            // 
            // treeView
            // 
            this.treeView.HideSelection = false;
            this.treeView.Location = new System.Drawing.Point(202, 19);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(368, 360);
            this.treeView.TabIndex = 13;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnShowEffectCode);
            this.pnlButtons.Controls.Add(this.btnNewEffect);
            this.pnlButtons.Controls.Add(this.btnExport);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnImport);
            this.pnlButtons.Location = new System.Drawing.Point(3, 405);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(198, 30);
            this.pnlButtons.TabIndex = 12;
            this.pnlButtons.Visible = false;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelCount.Location = new System.Drawing.Point(4, 385);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(0, 15);
            this.labelCount.TabIndex = 6;
            // 
            // tbFind
            // 
            this.tbFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbFind.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbFind.Location = new System.Drawing.Point(6, 19);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(121, 22);
            this.tbFind.TabIndex = 3;
            this.tbFind.Text = "Texture name";
            this.tbFind.Click += new System.EventHandler(this.TbFind_Click);
            this.tbFind.Leave += new System.EventHandler(this.TbFind_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSearch.BackColorAdditional = System.Drawing.Color.Gray;
            this.btnSearch.BackColorGradientEnabled = false;
            this.btnSearch.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.btnSearch.BorderColor = System.Drawing.Color.Teal;
            this.btnSearch.BorderColorEnabled = false;
            this.btnSearch.BorderColorOnHover = System.Drawing.Color.Teal;
            this.btnSearch.BorderColorOnHoverEnabled = false;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(133, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.RippleColor = System.Drawing.Color.Black;
            this.btnSearch.RoundingEnable = false;
            this.btnSearch.Size = new System.Drawing.Size(64, 22);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextHover = null;
            this.btnSearch.UseDownPressEffectOnClick = false;
            this.btnSearch.UseRippleEffect = true;
            this.btnSearch.UseZoomEffectOnHover = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Struct";
            // 
            // lbEffects
            // 
            this.lbEffects.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbEffects.FormattingEnabled = true;
            this.lbEffects.ItemHeight = 15;
            this.lbEffects.Location = new System.Drawing.Point(6, 45);
            this.lbEffects.Name = "lbEffects";
            this.lbEffects.Size = new System.Drawing.Size(191, 334);
            this.lbEffects.TabIndex = 0;
            this.lbEffects.SelectedIndexChanged += new System.EventHandler(this.LbEffects_SelectedIndexChanged);
            // 
            // btnShowEffectCode
            // 
            this.btnShowEffectCode.BackColor = System.Drawing.Color.DarkCyan;
            this.btnShowEffectCode.BackgroundImage = global::GTA_SA_Effect_Editor.Properties.Resources.editCode;
            this.btnShowEffectCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShowEffectCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowEffectCode.Location = new System.Drawing.Point(162, 4);
            this.btnShowEffectCode.Name = "btnShowEffectCode";
            this.btnShowEffectCode.Size = new System.Drawing.Size(32, 23);
            this.btnShowEffectCode.TabIndex = 19;
            this.btnShowEffectCode.UseVisualStyleBackColor = false;
            this.btnShowEffectCode.Click += new System.EventHandler(this.BtnShowEffectCode_Click);
            // 
            // btnNewEffect
            // 
            this.btnNewEffect.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNewEffect.BackgroundImage = global::GTA_SA_Effect_Editor.Properties.Resources.newEffect;
            this.btnNewEffect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNewEffect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNewEffect.Location = new System.Drawing.Point(122, 4);
            this.btnNewEffect.Name = "btnNewEffect";
            this.btnNewEffect.Size = new System.Drawing.Size(33, 23);
            this.btnNewEffect.TabIndex = 18;
            this.btnNewEffect.UseVisualStyleBackColor = false;
            this.btnNewEffect.Click += new System.EventHandler(this.BtnNewEffect_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.DarkCyan;
            this.btnExport.BackgroundImage = global::GTA_SA_Effect_Editor.Properties.Resources.export;
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Location = new System.Drawing.Point(83, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(33, 23);
            this.btnExport.TabIndex = 17;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkCyan;
            this.btnDelete.BackgroundImage = global::GTA_SA_Effect_Editor.Properties.Resources.delete;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Location = new System.Drawing.Point(4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(33, 23);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.DarkCyan;
            this.btnImport.BackgroundImage = global::GTA_SA_Effect_Editor.Properties.Resources.import;
            this.btnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImport.Location = new System.Drawing.Point(44, 4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(33, 23);
            this.btnImport.TabIndex = 16;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 504);
            this.Controls.Add(this.gbEffects);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.egtbPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(597, 543);
            this.MinimumSize = new System.Drawing.Size(597, 543);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GTA SA Effect editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.gbEffects.ResumeLayout(false);
            this.gbEffects.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private yt_DesignUI.Components.EgoldsFormStyle egoldsFormStyle1;
        private yt_DesignUI.yt_Button btnBrowse;
        private yt_DesignUI.EgoldsGoogleTextBox egtbPath;
        private System.Windows.Forms.GroupBox gbEffects;
        private System.Windows.Forms.ListBox lbEffects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFind;
        private yt_DesignUI.yt_Button btnSearch;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.TreeView treeView;
        private yt_DesignUI.yt_Button btnShowCode;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnDelete;
        private yt_DesignUI.yt_Button btnAdd;
        private yt_DesignUI.yt_Button btnDelTreeItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnShowEffectCode;
        private System.Windows.Forms.Button btnNewEffect;
    }
}

