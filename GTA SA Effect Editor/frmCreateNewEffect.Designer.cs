namespace GTA_SA_Effect_Editor
{
    partial class frmCreateNewEffect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateNewEffect));
            this.tbName = new yt_DesignUI.EgoldsGoogleTextBox();
            this.egoldsFormStyle1 = new yt_DesignUI.Components.EgoldsFormStyle(this.components);
            this.btnCreate = new yt_DesignUI.yt_Button();
            this.btnCancel = new yt_DesignUI.yt_Button();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.White;
            this.tbName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.tbName.BorderColorNotActive = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.tbName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbName.Font = new System.Drawing.Font("Arial", 11.25F);
            this.tbName.FontTextPreview = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.tbName.ForeColor = System.Drawing.Color.Black;
            this.tbName.Location = new System.Drawing.Point(12, 12);
            this.tbName.Name = "tbName";
            this.tbName.SelectionStart = 0;
            this.tbName.Size = new System.Drawing.Size(364, 40);
            this.tbName.TabIndex = 0;
            this.tbName.TextInput = "Name";
            this.tbName.TextPreview = "Input name";
            this.tbName.UseSystemPasswordChar = false;
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
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.DarkCyan;
            this.btnCreate.BackColorAdditional = System.Drawing.Color.Gray;
            this.btnCreate.BackColorGradientEnabled = false;
            this.btnCreate.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.btnCreate.BorderColor = System.Drawing.Color.Teal;
            this.btnCreate.BorderColorEnabled = false;
            this.btnCreate.BorderColorOnHover = System.Drawing.Color.Teal;
            this.btnCreate.BorderColorOnHoverEnabled = false;
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(94, 65);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.RippleColor = System.Drawing.Color.Black;
            this.btnCreate.RoundingEnable = false;
            this.btnCreate.Size = new System.Drawing.Size(98, 30);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create";
            this.btnCreate.TextHover = null;
            this.btnCreate.UseDownPressEffectOnClick = false;
            this.btnCreate.UseRippleEffect = true;
            this.btnCreate.UseZoomEffectOnHover = false;
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
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
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(198, 65);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RippleColor = System.Drawing.Color.Black;
            this.btnCancel.RoundingEnable = false;
            this.btnCancel.Size = new System.Drawing.Size(98, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextHover = null;
            this.btnCancel.UseDownPressEffectOnClick = false;
            this.btnCancel.UseRippleEffect = true;
            this.btnCancel.UseZoomEffectOnHover = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // frmCreateNewEffect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 109);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.tbName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(404, 148);
            this.MinimumSize = new System.Drawing.Size(404, 148);
            this.Name = "frmCreateNewEffect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create a new effect";
            this.ResumeLayout(false);

        }

        #endregion

        private yt_DesignUI.EgoldsGoogleTextBox tbName;
        private yt_DesignUI.Components.EgoldsFormStyle egoldsFormStyle1;
        private yt_DesignUI.yt_Button btnCreate;
        private yt_DesignUI.yt_Button btnCancel;
    }
}