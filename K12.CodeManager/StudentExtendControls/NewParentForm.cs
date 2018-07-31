using FISCA.Presentation.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace K12Code.Management.Module
{
    public partial class NewParentForm : BaseForm
    {
        FromData _data { get; set; }
        public NewParentForm(FromData data)
        {
            _data = data;

            InitializeComponent();
        }

        private void NewParentForm_Load(object sender, EventArgs e)
        {



        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string Messsage = Check();
            if (Messsage == "")
            {

                //檢查是否已經有這個身份
                StringBuilder sb_select = new StringBuilder();
                sb_select.Append("select * from student_parent ");
                sb_select.Append(string.Format("where account='{0}' and ref_student_id='{1}'", tbTxt3.Text, _data.sr.ID));
                DataTable dt = tool._Q.Select(sb_select.ToString());
                if (dt.Rows.Count > 0)
                {
                    MsgBox.Show("已有相同家長帳號!!");
                    return;
                }

                //新增身份
                StringBuilder sb_sql = new StringBuilder();
                sb_sql.Append("INSERT INTO student_parent (ref_student_id , account , relationship , last_name , first_name , uuid)");
                sb_sql.Append(string.Format(" VALUES ('{0}','{1}','{2}','','','')", _data.sr.ID, tbTxt3.Text, cbTextView01.SelectedItem.ToString()));

                tool._U.Execute(sb_sql.ToString());

                FISCA.LogAgent.ApplicationLog.Log("親屬關係", "新增", String.Format("新增學生「{0}」家長登入帳號「{1}」稱謂「{2}」", _data.sr.Name, tbTxt3.Text, cbTextView01.SelectedItem.ToString()));


                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                MsgBox.Show(Messsage);
            }
        }

        private string Check()
        {
            string check = "";

            if (!IsValidEmail(tbTxt3.Text))
            {
                check = "請輸入正確的Email";
            }

            if (cbTextView01.SelectedIndex == -1)
            {
                check = "請選擇稱謂";
            }

            return check;
        }

        bool IsValidEmail(string strIn)
        {
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
