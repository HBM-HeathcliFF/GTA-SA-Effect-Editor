
namespace GTA_SA_Effect_Editor
{
    partial class frmShowCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowCode));
            this.btnApply = new yt_DesignUI.yt_Button();
            this.btnCancel = new yt_DesignUI.yt_Button();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnApply.BackColor = System.Drawing.Color.DarkCyan;
            this.btnApply.BackColorAdditional = System.Drawing.Color.Gray;
            this.btnApply.BackColorGradientEnabled = false;
            this.btnApply.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.btnApply.BorderColor = System.Drawing.Color.Teal;
            this.btnApply.BorderColorEnabled = false;
            this.btnApply.BorderColorOnHover = System.Drawing.Color.Teal;
            this.btnApply.BorderColorOnHoverEnabled = false;
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(211, 254);
            this.btnApply.Name = "btnApply";
            this.btnApply.RippleColor = System.Drawing.Color.Black;
            this.btnApply.RoundingEnable = false;
            this.btnApply.Size = new System.Drawing.Size(83, 22);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Применить";
            this.btnApply.TextHover = null;
            this.btnApply.UseDownPressEffectOnClick = false;
            this.btnApply.UseRippleEffect = true;
            this.btnApply.UseZoomEffectOnHover = false;
            this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
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
            this.btnCancel.Location = new System.Drawing.Point(122, 254);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RippleColor = System.Drawing.Color.Black;
            this.btnCancel.RoundingEnable = false;
            this.btnCancel.Size = new System.Drawing.Size(83, 22);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.TextHover = null;
            this.btnCancel.UseDownPressEffectOnClick = false;
            this.btnCancel.UseRippleEffect = true;
            this.btnCancel.UseZoomEffectOnHover = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // tbCode
            // 
            this.tbCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCode.Location = new System.Drawing.Point(12, 12);
            this.tbCode.Multiline = true;
            this.tbCode.Name = "tbCode";
            this.tbCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCode.Size = new System.Drawing.Size(392, 234);
            this.tbCode.TabIndex = 6;
            // 
            // frmShowCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 286);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(432, 324);
            this.Name = "frmShowCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор кода";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private yt_DesignUI.yt_Button btnApply;
        private yt_DesignUI.yt_Button btnCancel;
        private System.Windows.Forms.TextBox tbCode;
    }
}