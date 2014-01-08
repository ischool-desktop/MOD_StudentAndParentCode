using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.UDT;
using K12.Data;
using FISCA.LogAgent;

namespace K12Code.Management.Module
{
    [FISCA.Permission.FeatureCode("K12Code.Management.Module.TeacherItem.cs", "教師代碼")]
    public partial class TeacherItem : FISCA.Presentation.DetailContent
    {
        //背景模式
        private BackgroundWorker BGW = new BackgroundWorker();

        //背景忙碌
        private bool BkWBool = false;

        //UDT物件
        private AccessHelper _AccessHelper = new AccessHelper();

        private Campus.Windows.ChangeListener DataListener { get; set; }

        TeacherRecord tr { get; set; }

        List<string> TeacherCodeList { get; set; }

        string TeacherCode { get; set; }

        public TeacherItem()
        {
            InitializeComponent();

            Group = "教師代碼";
        }

        private void TeacherItem_Load(object sender, EventArgs e)
        {
            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);

            DataListener = new Campus.Windows.ChangeListener();
            DataListener.Add(new Campus.Windows.TextBoxSource(tbTeacherCode));
            DataListener.StatusChanged += new EventHandler<Campus.Windows.ChangeEventArgs>(DataListener_StatusChanged);
        }

        void DataListener_StatusChanged(object sender, Campus.Windows.ChangeEventArgs e)
        {
            this.SaveButtonVisible = (e.Status == Campus.Windows.ValueStatus.Dirty);
            this.CancelButtonVisible = (e.Status == Campus.Windows.ValueStatus.Dirty);
        }

        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            tr = Teacher.SelectByID(this.PrimaryKey);
            DataTable dt = StatTool.Q.Select(string.Format("select id,teacher_name,teacher_code from teacher where id='{0}'", this.PrimaryKey));
            foreach (DataRow row in dt.Rows)
            {
                TeacherCode = "" + row["teacher_code"];
            }

        }

        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (BkWBool) //如果有其他的更新事件
            {
                BkWBool = false;
                BGW.RunWorkerAsync();
                return;
            }

            tbTeacherCode.Text = TeacherCode;

            DataListener.Reset();
            DataListener.ResumeListen();

            SaveButtonVisible = false;
            CancelButtonVisible = false;
            this.Loading = false;
        }


        /// <summary>
        /// 按下儲存時
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSaveButtonClick(EventArgs e)
        {
            string New_Code = tbTeacherCode.Text.Trim();
            TeacherCodeList = new List<string>();
            //取得teacher code不為空的清單(用來比較)
            if (!string.IsNullOrEmpty(New_Code))
            {
                DataTable dt = StatTool.Q.Select("select teacher_code from teacher where teacher_code is not null and teacher_code<>'" + TeacherCode + "'");
                //DataTable dt = StatTool.Q.Select("select id,teacher_name,teacher_code from teacher where teacher_code is not null");
                foreach (DataRow row in dt.Rows)
                {
                    if (!TeacherCodeList.Contains("" + row["teacher_code"]))
                    {
                        TeacherCodeList.Add("" + row["teacher_code"]);
                    }
                }
            }

            if (!TeacherCodeList.Contains(New_Code))
            {
                if (!string.IsNullOrEmpty(New_Code))
                {
                    string q1 = "update teacher set teacher_code='{0}' where id={1}";
                    string cmdTeacher = string.Format(q1, New_Code, this.PrimaryKey);
                    StatTool.GenerateCode(cmdTeacher);
                }
                else
                {
                    string q1 = "update teacher set teacher_code=null where id={0}";
                    string cmdTeacher = string.Format(q1, this.PrimaryKey);
                    StatTool.GenerateCode(cmdTeacher);
                }

                this.SaveButtonVisible = false;
                this.CancelButtonVisible = false;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("已修改教師「{0}」的代碼：", tr.Name));
                sb.AppendLine(string.Format("由「{0}」修改為「{1}」", TeacherCode, New_Code));
                ApplicationLog.Log("修改教師代碼", "修改", "teacher", this.PrimaryKey, sb.ToString());

                Changed();
            }
            else
            {
                MsgBox.Show("教師代碼不可重覆!!");
            }


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

        private void btnGenerateStudentCode_Click(object sender, EventArgs e)
        {
            for (int x = 1; x > 0; x++)
            {
                string code = Guid.NewGuid().ToString().Substring(1, 6).ToUpper();
                DataTable dt = StatTool.Q.Select(string.Format("select teacher_code from teacher where teacher_code='{0}'", code));
                if (dt.Rows.Count == 0)
                {
                    tbTeacherCode.Text = code;
                    break;
                }
            }
        }

    }
}
