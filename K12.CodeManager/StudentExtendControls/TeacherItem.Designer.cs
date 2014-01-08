namespace K12Code.Management.Module
{
    partial class TeacherItem
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
            this.tbTeacherCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnGenerateStudentCode = new DevComponents.DotNetBar.ButtonX();
            this.txtStudentCode = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // tbTeacherCode
            // 
            // 
            // 
            // 
            this.tbTeacherCode.Border.Class = "TextBoxBorder";
            this.tbTeacherCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbTeacherCode.Location = new System.Drawing.Point(109, 13);
            this.tbTeacherCode.Name = "tbTeacherCode";
            this.tbTeacherCode.Size = new System.Drawing.Size(138, 25);
            this.tbTeacherCode.TabIndex = 8;
            // 
            // btnGenerateStudentCode
            // 
            this.btnGenerateStudentCode.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGenerateStudentCode.AutoSize = true;
            this.btnGenerateStudentCode.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGenerateStudentCode.Location = new System.Drawing.Point(284, 13);
            this.btnGenerateStudentCode.Name = "btnGenerateStudentCode";
            this.btnGenerateStudentCode.Size = new System.Drawing.Size(76, 25);
            this.btnGenerateStudentCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGenerateStudentCode.TabIndex = 9;
            this.btnGenerateStudentCode.Text = "產生";
            this.btnGenerateStudentCode.Click += new System.EventHandler(this.btnGenerateStudentCode_Click);
            // 
            // txtStudentCode
            // 
            this.txtStudentCode.AutoSize = true;
            // 
            // 
            // 
            this.txtStudentCode.BackgroundStyle.Class = "";
            this.txtStudentCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStudentCode.Location = new System.Drawing.Point(33, 15);
            this.txtStudentCode.Name = "txtStudentCode";
            this.txtStudentCode.Size = new System.Drawing.Size(60, 21);
            this.txtStudentCode.TabIndex = 7;
            this.txtStudentCode.Text = "教師代碼";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(33, 47);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(333, 21);
            this.labelX1.TabIndex = 10;
            this.labelX1.Text = "說明：教師代碼於教師WEB登入認證後,將會自動清空。";
            // 
            // TeacherItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.tbTeacherCode);
            this.Controls.Add(this.btnGenerateStudentCode);
            this.Controls.Add(this.txtStudentCode);
            this.Name = "TeacherItem";
            this.Size = new System.Drawing.Size(550, 80);
            this.Load += new System.EventHandler(this.TeacherItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX tbTeacherCode;
        private DevComponents.DotNetBar.ButtonX btnGenerateStudentCode;
        private DevComponents.DotNetBar.LabelX txtStudentCode;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}