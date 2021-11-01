
namespace GTA_SA_Effect_Editor
{
    partial class frmSelectInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectInfo));
            this.lbInfos = new System.Windows.Forms.ListBox();
            this.btnCancel = new yt_DesignUI.yt_Button();
            this.btnSelect = new yt_DesignUI.yt_Button();
            this.egoldsFormStyle1 = new yt_DesignUI.Components.EgoldsFormStyle(this.components);
            this.SuspendLayout();
            // 
            // lbInfos
            // 
            this.lbInfos.FormattingEnabled = true;
            this.lbInfos.Items.AddRange(new object[] {
            "ANIMTEX",
            "ATTRACTPT",
            "COLOUR",
            "COLOURBRIGHT",
            "DIR",
            "EMANGLE",
            "EMDIR",
            "EMLIFE",
            "EMPOS",
            "EMRATE",
            "EMROTATION",
            "EMSIZE",
            "EMSPEED",
            "EMWEATHER",
            "FLAT",
            "FLOAT",
            "FORCE",
            "FRICTION",
            "GROUNDCOLLIDE",
            "HEATHAZE",
            "JITTER",
            "NOISE",
            "ROTSPEED",
            "SELFLIT",
            "SIZE",
            "SPRITERECT",
            "TRAIL",
            "UNDERWATER",
            "WIND"});
            this.lbInfos.Location = new System.Drawing.Point(0, 1);
            this.lbInfos.Name = "lbInfos";
            this.lbInfos.Size = new System.Drawing.Size(216, 225);
            this.lbInfos.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DarkCyan;
            this.btnCancel.BackColorAdditional = System.Drawing.Color.Gray;
            this.btnCancel.BackColorGradientEnabled = false;
            this.btnCancel.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.btnCancel.BorderColor = System.Drawing.Color.Teal;
            this.btnCancel.BorderColorEnabled = false;
            this.btnCancel.BorderColorOnHover = System.Drawing.Color.Teal;
            this.btnCancel.BorderColorOnHoverEnabled = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(42, 231);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RippleColor = System.Drawing.Color.Black;
            this.btnCancel.RoundingEnable = false;
            this.btnCancel.Size = new System.Drawing.Size(64, 22);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextHover = null;
            this.btnCancel.UseDownPressEffectOnClick = false;
            this.btnCancel.UseRippleEffect = true;
            this.btnCancel.UseZoomEffectOnHover = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSelect.BackColorAdditional = System.Drawing.Color.Gray;
            this.btnSelect.BackColorGradientEnabled = false;
            this.btnSelect.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.btnSelect.BorderColor = System.Drawing.Color.Teal;
            this.btnSelect.BorderColorEnabled = false;
            this.btnSelect.BorderColorOnHover = System.Drawing.Color.Teal;
            this.btnSelect.BorderColorOnHoverEnabled = false;
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.Location = new System.Drawing.Point(112, 231);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.RippleColor = System.Drawing.Color.Black;
            this.btnSelect.RoundingEnable = false;
            this.btnSelect.Size = new System.Drawing.Size(64, 22);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "Select";
            this.btnSelect.TextHover = null;
            this.btnSelect.UseDownPressEffectOnClick = false;
            this.btnSelect.UseRippleEffect = true;
            this.btnSelect.UseZoomEffectOnHover = false;
            this.btnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
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
            // frmSelectInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 258);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lbInfos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(216, 296);
            this.MinimumSize = new System.Drawing.Size(216, 296);
            this.Name = "frmSelectInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select INFO";
            this.ResumeLayout(false);

        }

        #endregion

        private yt_DesignUI.Components.EgoldsFormStyle egoldsFormStyle1;
        private System.Windows.Forms.ListBox lbInfos;
        private yt_DesignUI.yt_Button btnCancel;
        private yt_DesignUI.yt_Button btnSelect;
    }
}