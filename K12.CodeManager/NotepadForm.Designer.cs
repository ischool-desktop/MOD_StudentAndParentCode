namespace K12Code.Management.Module
{
    partial class NotepadForm
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
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // textBoxX1
            // 
            this.textBoxX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.Location = new System.Drawing.Point(12, 12);
            this.textBoxX1.Multiline = true;
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxX1.Size = new System.Drawing.Size(484, 430);
            this.textBoxX1.TabIndex = 0;
            this.textBoxX1.WordWrap = false;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX2.BackColor = System.Drawing.Color.Transparent;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(383, 448);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(113, 25);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 2;
            this.buttonX2.Text = "複製並離開";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            this.buttonX2.MouseLeave += new System.EventHandler(this.buttonX2_MouseLeave);
            this.buttonX2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonX2_MouseMove);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(149, 450);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(212, 20);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "<font color=\"#ED1C24\"><b>複製所有資料至剪貼簿,並關閉此畫面</b></font>";
            this.labelX1.Visible = false;
            // 
            // NotepadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 483);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.textBoxX1);
            this.MaximizeBox = true;
            this.Name = "NotepadForm";
            this.Text = "快速剪貼簿";
            this.Load += new System.EventHandler(this.NotepadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}