
namespace GTA_SA_Effect_Editor
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.egoldsFormStyle1 = new yt_DesignUI.Components.EgoldsFormStyle(this.components);
            this.egtbPath = new yt_DesignUI.EgoldsGoogleTextBox();
            this.btnBrowse = new yt_DesignUI.yt_Button();
            this.gbEffects = new System.Windows.Forms.GroupBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnImport = new yt_DesignUI.yt_Button();
            this.btnExport = new yt_DesignUI.yt_Button();
            this.btnDelete = new yt_DesignUI.yt_Button();
            this.labelCount = new System.Windows.Forms.Label();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.btnFind = new yt_DesignUI.yt_Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbEffects = new System.Windows.Forms.ListBox();
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
            this.egtbPath.TextPreview = "Путь к файлу эффектов";
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
            this.btnBrowse.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(488, 14);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.RippleColor = System.Drawing.Color.Black;
            this.btnBrowse.RoundingEnable = true;
            this.btnBrowse.Size = new System.Drawing.Size(99, 34);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Обзор";
            this.btnBrowse.TextHover = null;
            this.btnBrowse.UseDownPressEffectOnClick = false;
            this.btnBrowse.UseRippleEffect = true;
            this.btnBrowse.UseZoomEffectOnHover = false;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // gbEffects
            // 
            this.gbEffects.Controls.Add(this.pnlButtons);
            this.gbEffects.Controls.Add(this.labelCount);
            this.gbEffects.Controls.Add(this.tbFind);
            this.gbEffects.Controls.Add(this.btnFind);
            this.gbEffects.Controls.Add(this.label1);
            this.gbEffects.Controls.Add(this.lbEffects);
            this.gbEffects.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbEffects.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbEffects.Location = new System.Drawing.Point(10, 54);
            this.gbEffects.Name = "gbEffects";
            this.gbEffects.Size = new System.Drawing.Size(577, 316);
            this.gbEffects.TabIndex = 2;
            this.gbEffects.TabStop = false;
            this.gbEffects.Text = "Эффекты";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnImport);
            this.pnlButtons.Controls.Add(this.btnExport);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Location = new System.Drawing.Point(204, 269);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(368, 41);
            this.pnlButtons.TabIndex = 12;
            this.pnlButtons.Visible = false;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.DarkCyan;
            this.btnImport.BackColorAdditional = System.Drawing.Color.Gray;
            this.btnImport.BackColorGradientEnabled = false;
            this.btnImport.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.btnImport.BorderColor = System.Drawing.Color.Teal;
            this.btnImport.BorderColorEnabled = false;
            this.btnImport.BorderColorOnHover = System.Drawing.Color.Teal;
            this.btnImport.BorderColorOnHoverEnabled = false;
            this.btnImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImport.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(84, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.RippleColor = System.Drawing.Color.Black;
            this.btnImport.RoundingEnable = true;
            this.btnImport.Size = new System.Drawing.Size(155, 34);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Импортировать в ...";
            this.btnImport.TextHover = null;
            this.btnImport.UseDownPressEffectOnClick = false;
            this.btnImport.UseRippleEffect = true;
            this.btnImport.UseZoomEffectOnHover = false;
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.DarkCyan;
            this.btnExport.BackColorAdditional = System.Drawing.Color.Gray;
            this.btnExport.BackColorGradientEnabled = false;
            this.btnExport.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.btnExport.BorderColor = System.Drawing.Color.Teal;
            this.btnExport.BorderColorEnabled = false;
            this.btnExport.BorderColorOnHover = System.Drawing.Color.Teal;
            this.btnExport.BorderColorOnHoverEnabled = false;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(245, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.RippleColor = System.Drawing.Color.Black;
            this.btnExport.RoundingEnable = true;
            this.btnExport.Size = new System.Drawing.Size(123, 34);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Экспортировать";
            this.btnExport.TextHover = null;
            this.btnExport.UseDownPressEffectOnClick = false;
            this.btnExport.UseRippleEffect = true;
            this.btnExport.UseZoomEffectOnHover = false;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkCyan;
            this.btnDelete.BackColorAdditional = System.Drawing.Color.Gray;
            this.btnDelete.BackColorGradientEnabled = false;
            this.btnDelete.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.btnDelete.BorderColor = System.Drawing.Color.Teal;
            this.btnDelete.BorderColorEnabled = false;
            this.btnDelete.BorderColorOnHover = System.Drawing.Color.Teal;
            this.btnDelete.BorderColorOnHoverEnabled = false;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(0, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RippleColor = System.Drawing.Color.Black;
            this.btnDelete.RoundingEnable = true;
            this.btnDelete.Size = new System.Drawing.Size(78, 34);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.TextHover = null;
            this.btnDelete.UseDownPressEffectOnClick = false;
            this.btnDelete.UseRippleEffect = true;
            this.btnDelete.UseZoomEffectOnHover = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelCount.Location = new System.Drawing.Point(3, 292);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(0, 16);
            this.labelCount.TabIndex = 6;
            // 
            // tbFind
            // 
            this.tbFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFind.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbFind.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbFind.Location = new System.Drawing.Point(6, 19);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(121, 22);
            this.tbFind.TabIndex = 3;
            this.tbFind.Text = "Название текстуры";
            this.tbFind.Click += new System.EventHandler(this.TbFind_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.DarkCyan;
            this.btnFind.BackColorAdditional = System.Drawing.Color.Gray;
            this.btnFind.BackColorGradientEnabled = false;
            this.btnFind.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.btnFind.BorderColor = System.Drawing.Color.Teal;
            this.btnFind.BorderColorEnabled = false;
            this.btnFind.BorderColorOnHover = System.Drawing.Color.Teal;
            this.btnFind.BorderColorOnHoverEnabled = false;
            this.btnFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFind.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.Location = new System.Drawing.Point(133, 19);
            this.btnFind.Name = "btnFind";
            this.btnFind.RippleColor = System.Drawing.Color.Black;
            this.btnFind.RoundingEnable = false;
            this.btnFind.Size = new System.Drawing.Size(64, 22);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Поиск";
            this.btnFind.TextHover = null;
            this.btnFind.UseDownPressEffectOnClick = false;
            this.btnFind.UseRippleEffect = true;
            this.btnFind.UseZoomEffectOnHover = false;
            this.btnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Текстуры";
            // 
            // lbEffects
            // 
            this.lbEffects.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbEffects.FormattingEnabled = true;
            this.lbEffects.ItemHeight = 15;
            this.lbEffects.Location = new System.Drawing.Point(6, 45);
            this.lbEffects.Name = "lbEffects";
            this.lbEffects.Size = new System.Drawing.Size(191, 244);
            this.lbEffects.TabIndex = 0;
            this.lbEffects.SelectedIndexChanged += new System.EventHandler(this.LbEffects_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 379);
            this.Controls.Add(this.gbEffects);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.egtbPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(597, 417);
            this.MinimumSize = new System.Drawing.Size(597, 417);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор эффектов GTA SA";
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
        private yt_DesignUI.yt_Button btnImport;
        private yt_DesignUI.yt_Button btnDelete;
        private System.Windows.Forms.TextBox tbFind;
        private yt_DesignUI.yt_Button btnFind;
        private System.Windows.Forms.Label labelCount;
        private yt_DesignUI.yt_Button btnExport;
        private System.Windows.Forms.Panel pnlButtons;
    }
}

