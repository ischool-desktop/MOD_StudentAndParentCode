using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using K12.Data;
using FISCA.UDT;
using FISCA;
using Campus.Windows;

namespace K12Code.Management.Module
{
    [FISCA.Permission.FeatureCode("K12Code.Management.Module.StudentExtendControls.StudentItem.cs", "代碼與親屬關係")]
    public partial class StudentItem : FISCA.Presentation.DetailContent
    {
        //背景模式
        private BackgroundWorker BGW = new BackgroundWorker();

        //背景忙碌
        private bool BkWBool = false;

        //UDT物件
        private AccessHelper _AccessHelper = new AccessHelper();

        private ChangeListener DataListener { get; set; }

        FromData data { get; set; }

        public StudentItem()
        {
            InitializeComponent();

            Group = "代碼與親屬關係";

            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);

            DataListener = new Campus.Windows.ChangeListener();
            //DataListener.Add(new Campus.Windows.TextBoxSource(tbStudentLoginID));
            DataListener.Add(new Campus.Windows.TextBoxSource(tbStudentCode));
            DataListener.Add(new Campus.Windows.TextBoxSource(tbParentCode));
            DataListener.Add(new Campus.Windows.DataGridViewSource(dataGridViewX1));
            DataListener.StatusChanged += new EventHandler<ChangeEventArgs>(DataListener_StatusChanged);
        }

        /// <summary>
        /// 背景模式
        /// </summary>
        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            //取得登入帳號
            StudentRecord stud = Student.SelectByID(this.PrimaryKey);
            data = new FromData(stud);

            GetStudentCodeAndParentCode();

            GetStudentAndParent();

            //取得Table裡的account是否在"campuslite.directory.profile"裡有相關資料
            string _profileUDT = "\"$campuslite.directory.profile\"";
            List<string> parentLIST = new List<string>();
            foreach (StudentAndParent each in data.parentList)
            {
                parentLIST.Add(each.Account);
            }
            string _parentname = string.Join("','", parentLIST);
            string query3 = string.Format("select login_name,name,gender from {0} where login_name in ('{1}')", _profileUDT.ToLower(), _parentname);
            DataTable dt3 = StatTool.Q.Select(query3);

            foreach (DataRow row in dt3.Rows)
            {
                CampusLiteOBJ obj = new CampusLiteOBJ(row);
                data.CheckNow(obj);
            }

        }

        /// <summary>
        /// 取得學生Code
        /// 取得家長Code
        /// </summary>
        private void GetStudentCodeAndParentCode()
        {
            string query1 = string.Format("select id,student_code,parent_code from student where id='{0}'", this.PrimaryKey);
            //string querya = string.Format("select * from student where id='{0}'", this.PrimaryKey);
            DataTable dt1 = StatTool.Q.Select(query1);
            foreach (DataRow row in dt1.Rows)
            {
                data.StudentCode = "" + row["student_code"]; //學生Code
                data.ParentCode = "" + row["parent_code"]; //家長Code
            }
        }

        /// <summary>
        /// 取得學生ID在student_parent Table裡是否有資料
        /// </summary>
        private void GetStudentAndParent()
        {
            string query2 = string.Format("select * from student_parent where ref_student_id='{0}'", this.PrimaryKey);
            DataTable dt2 = StatTool.Q.Select(query2);

            foreach (DataRow row in dt2.Rows)
            {
                StudentAndParent sap = new StudentAndParent(row);
                data.parentList.Add(sap);
            }
        }

        /// <summary>
        /// 背景模式完成
        /// </summary>
        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (BkWBool) //如果有其他的更新事件
            {
                BkWBool = false;
                BGW.RunWorkerAsync();
                return;
            }

            BindData();

            DataListener.Reset();
            DataListener.ResumeListen();
            SaveButtonVisible = false;
            CancelButtonVisible = false;
            this.Loading = false;
        }

        private void BindData()
        {
            tbParentCode.Text = data.ParentCode;
            tbStudentCode.Text = data.StudentCode;
            //tbStudentLoginID.Text = data.SaLoginName;

            dataGridViewX1.AutoGenerateColumns = false;
            dataGridViewX1.DataSource = data.parentList;
        }

        /// <summary>
        /// KEY值切換時(PrimaryKey更新)
        /// </summary>
        protected override void OnPrimaryKeyChanged(EventArgs e)
        {
            Changed();
        }

        void Changed()
        {
            #region 更新時
            if (this.PrimaryKey != "")
            {
                this.Loading = true;

                if (BGW.IsBusy)
                {
                    BkWBool = true;
                }
                else
                {
                    BGW.RunWorkerAsync();
                }
            }
            #endregion
        }

        /// <summary>
        /// 按下儲存時
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSaveButtonClick(EventArgs e)
        {
            #region 儲存學生代碼

            //Query 描述
            if (!string.IsNullOrEmpty(tbStudentCode.Text.Trim()))
            {
                string q1 = "update student set student_code='{0}' where id={1}";
                string cmdStudent = string.Format(q1, tbStudentCode.Text.Trim(), this.PrimaryKey);
                StatTool.GenerateCode(cmdStudent);
            }
            else
            {
                string q1 = "update student set student_code=null where id={0}";
                string cmdStudent = string.Format(q1, this.PrimaryKey);
                StatTool.GenerateCode(cmdStudent);
            }

            #endregion

            #region 儲存家長代碼

            //Query 描述
            if (!string.IsNullOrEmpty(tbParentCode.Text.Trim()))
            {
                string q2 = "update student set parent_code='{0}' where id={1}";
                string cmdParent = string.Format(q2, tbParentCode.Text.Trim(), this.PrimaryKey);
                StatTool.GenerateCode(cmdParent);
            }
            else
            {
                string q2 = "update student set parent_code=null where id={0}";
                string cmdParent = string.Format(q2, this.PrimaryKey);
                StatTool.GenerateCode(cmdParent);
            }

            #endregion

            #region 檢查親屬關係是否被修改


            #endregion

            #region 新增親屬關係




            #endregion

            #region 刪除親屬關係

            if (data.DeleteParentList.Count > 0)
            {
                List<string> list = new List<string>();

                StringBuilder sb_log = new StringBuilder();
                sb_log.AppendLine(string.Format("刪除學生「{0}」家長登入帳號：", data.sr.Name));
                foreach (StudentAndParent sap in data.DeleteParentList)
                {
                    list.Add(sap.id);

                    sb_log.AppendLine(String.Format("帳號「{0}」稱謂「{1}」", sap.Account, sap.Relationship));

                }
                string q3 = "delete from student_parent where ref_student_id in ('{0}') and id in ('{1}');";
                string cmddeleteRelationship = string.Format(q3, this.PrimaryKey, string.Join("','", list));

                StatTool.ClearRelationship(cmddeleteRelationship);

                FISCA.LogAgent.ApplicationLog.Log("親屬關係", "刪除", sb_log.ToString());

            }

            #endregion

            this.SaveButtonVisible = false;
            this.CancelButtonVisible = false;

            Changed();
        }

        /// <summary>
        /// 取消儲存時
        /// </summary>
        protected override void OnCancelButtonClick(EventArgs e)
        {
            this.SaveButtonVisible = false;
            this.CancelButtonVisible = false;

            DataListener.SuspendListen(); //終止變更判斷
            Changed();
        }

        /// <summary>
        /// 產生學生Code
        /// </summary>
        private void btnGenerateStudentCode_Click(object sender, EventArgs e)
        {
            string code = Guid.NewGuid().ToString().Substring(1, 6).ToUpper();
            tbStudentCode.Text = code;
        }

        /// <summary>
        /// 產生家長Code
        /// </summary>
        private void btnGenerateParentCode_Click(object sender, EventArgs e)
        {
            string code = Guid.NewGuid().ToString().Substring(1, 6).ToUpper();
            tbParentCode.Text = code;
        }

        void DataListener_StatusChanged(object sender, ChangeEventArgs e)
        {
            this.SaveButtonVisible = (e.Status == Campus.Windows.ValueStatus.Dirty);
            this.CancelButtonVisible = (e.Status == Campus.Windows.ValueStatus.Dirty);
        }

        private void 刪除關係ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
                {
                    //將繫結物件,取得並準備刪除
                    StudentAndParent asp = (StudentAndParent)row.DataBoundItem;
                    data.DeleteParentList.Add(asp);
                }
                dataGridViewX1.DataSource = null;
                foreach (StudentAndParent each in data.DeleteParentList)
                {
                    if (data.parentList.Contains(each))
                    {
                        data.parentList.Remove(each);
                    }
                }

                dataGridViewX1.DataSource = data.parentList;

                this.SaveButtonVisible = true;
                this.CancelButtonVisible = true;
            }
        }

        private void 新增家長ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewParentForm npForm = new NewParentForm(data);
            DialogResult dr = npForm.ShowDialog();
            if (dr == DialogResult.Yes)
            {
                Changed();
            }
        }
    }
}
