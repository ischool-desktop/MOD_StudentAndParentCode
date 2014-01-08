namespace K12Code.Management.Module
{
    partial class StudentItem
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtStudentCode = new DevComponents.DotNetBar.LabelX();
            this.txtParentCode = new DevComponents.DotNetBar.LabelX();
            this.tbStudentCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbParentCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnGenerateStudentCode = new DevComponents.DotNetBar.ButtonX();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.刪除關係ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btnGenerateParentCode = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStudentCode
            // 
            this.txtStudentCode.AutoSize = true;
            // 
            // 
            // 
            this.txtStudentCode.BackgroundStyle.Class = "";
            this.txtStudentCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStudentCode.Location = new System.Drawing.Point(11, 128);
            this.txtStudentCode.Name = "txtStudentCode";
            this.txtStudentCode.Size = new System.Drawing.Size(60, 21);
            this.txtStudentCode.TabIndex = 2;
            this.txtStudentCode.Text = "學生代碼";
            // 
            // txtParentCode
            // 
            this.txtParentCode.AutoSize = true;
            // 
            // 
            // 
            this.txtParentCode.BackgroundStyle.Class = "";
            this.txtParentCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtParentCode.Location = new System.Drawing.Point(278, 128);
            this.txtParentCode.Name = "txtParentCode";
            this.txtParentCode.Size = new System.Drawing.Size(60, 21);
            this.txtParentCode.TabIndex = 3;
            this.txtParentCode.Text = "家長代碼";
            // 
            // tbStudentCode
            // 
            // 
            // 
            // 
            this.tbStudentCode.Border.Class = "TextBoxBorder";
            this.tbStudentCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbStudentCode.Location = new System.Drawing.Point(78, 126);
            this.tbStudentCode.Name = "tbStudentCode";
            this.tbStudentCode.Size = new System.Drawing.Size(136, 25);
            this.tbStudentCode.TabIndex = 4;
            // 
            // tbParentCode
            // 
            // 
            // 
            // 
            this.tbParentCode.Border.Class = "TextBoxBorder";
            this.tbParentCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbParentCode.Location = new System.Drawing.Point(345, 126);
            this.tbParentCode.Name = "tbParentCode";
            this.tbParentCode.Size = new System.Drawing.Size(136, 25);
            this.tbParentCode.TabIndex = 5;
            // 
            // btnGenerateStudentCode
            // 
            this.btnGenerateStudentCode.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGenerateStudentCode.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGenerateStudentCode.Location = new System.Drawing.Point(221, 127);
            this.btnGenerateStudentCode.Name = "btnGenerateStudentCode";
            this.btnGenerateStudentCode.Size = new System.Drawing.Size(50, 23);
            this.btnGenerateStudentCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGenerateStudentCode.TabIndex = 6;
            this.btnGenerateStudentCode.Text = "產生";
            this.btnGenerateStudentCode.Click += new System.EventHandler(this.btnGenerateStudentCode_Click);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToResizeRows = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewX1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column4});
            this.dataGridViewX1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(77, 15);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowHeadersVisible = false;
            this.dataGridViewX1.RowTemplate.Height = 24;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(463, 101);
            this.dataGridViewX1.TabIndex = 10;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刪除關係ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // 刪除關係ToolStripMenuItem
            // 
            this.刪除關係ToolStripMenuItem.Name = "刪除關係ToolStripMenuItem";
            this.刪除關係ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.刪除關係ToolStripMenuItem.Text = "刪除關係";
            this.刪除關係ToolStripMenuItem.Click += new System.EventHandler(this.刪除關係ToolStripMenuItem_Click);
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(11, 15);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(60, 21);
            this.labelX4.TabIndex = 11;
            this.labelX4.Text = "親屬資料\r\n";
            // 
            // btnGenerateParentCode
            // 
            this.btnGenerateParentCode.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGenerateParentCode.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGenerateParentCode.Location = new System.Drawing.Point(488, 127);
            this.btnGenerateParentCode.Name = "btnGenerateParentCode";
            this.btnGenerateParentCode.Size = new System.Drawing.Size(50, 23);
            this.btnGenerateParentCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGenerateParentCode.TabIndex = 8;
            this.btnGenerateParentCode.Text = "產生";
            this.btnGenerateParentCode.Click += new System.EventHandler(this.btnGenerateParentCode_Click);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(11, 157);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(541, 21);
            this.labelX1.TabIndex = 12;
            this.labelX1.Text = "說明：　(a)家長若已認證代碼,將會自動帶入姓名與性別　(b)親屬資料畫面,右鍵可刪除關係";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Account";
            this.Column1.HeaderText = "登入帳號";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 180;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Relationship";
            this.Column3.HeaderText = "稱謂";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 80;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Name";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.HeaderText = "姓名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 90;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Gender";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCyan;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "性別";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // StudentItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.tbStudentCode);
            this.Controls.Add(this.btnGenerateParentCode);
            this.Controls.Add(this.tbParentCode);
            this.Controls.Add(this.btnGenerateStudentCode);
            this.Controls.Add(this.txtParentCode);
            this.Controls.Add(this.txtStudentCode);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.labelX4);
            this.Name = "StudentItem";
            this.Size = new System.Drawing.Size(550, 185);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX txtStudentCode;
        private DevComponents.DotNetBar.LabelX txtParentCode;
        private DevComponents.DotNetBar.Controls.TextBoxX tbStudentCode;
        private DevComponents.DotNetBar.Controls.TextBoxX tbParentCode;
        private DevComponents.DotNetBar.ButtonX btnGenerateStudentCode;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX btnGenerateParentCode;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 刪除關係ToolStripMenuItem;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}
