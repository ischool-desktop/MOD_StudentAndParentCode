using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.Import;
using System.Xml;
using K12.Data;
using FISCA.DSAUtil;
using K12.Data;
using Campus.DocumentValidator;
using FISCA.Presentation.Controls;
using FISCA.LogAgent;
using FISCA.UDT;
using System.Data;

namespace K12Code.Management.Module
{
    class ImportStudentAndParent : ImportWizard
    {
        //設定檔
        private ImportOption mOption;
        //Log內容
        private StringBuilder mstrLog = new StringBuilder();

        public List<string> InsertListID = new List<string>();

        Dictionary<string, string> StudentNumberByID { get; set; }

        Dictionary<string, string> StudentNumberByName { get; set; }
        /// <summary>
        /// 準備動作
        /// </summary>
        public override void Prepare(ImportOption Option)
        {
            mOption = Option;
            //取得學生學號對比系統編號
            StudentNumberByID = GetStudent();

            StudentNumberByName = GetStudentName();
        }

        private Dictionary<string, string> GetStudentName()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            //取得比對序

            DataTable dt = StatTool.Q.Select("select student_number,name from student where status not in ('256','16')");
            foreach (DataRow row in dt.Rows)
            {
                string student_number = "" + row[0];
                string name = "" + row[1];

                if (string.IsNullOrEmpty(student_number))
                    continue;

                if (!dic.ContainsKey(student_number))
                {
                    dic.Add(student_number, name);
                }
            }

            return dic;
        }

        private Dictionary<string, string> GetStudent()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            //取得比對序

            DataTable dt = StatTool.Q.Select("select id,student_number,name from student where status not in ('256','16')");
            foreach (DataRow row in dt.Rows)
            {
                string StudentID = "" + row[0];
                string Student_Number = "" + row[1];

                if (string.IsNullOrEmpty(Student_Number))
                    continue;

                if (!dic.ContainsKey(Student_Number))
                {
                    dic.Add(Student_Number, StudentID);
                }
            }

            return dic;
        }

        /// <summary>
        /// 每1000筆資料,分批執行匯入
        /// Return是Log資訊
        /// </summary>
        public override string Import(List<Campus.DocumentValidator.IRowStream> Rows)
        {
            Dictionary<string, string> Student_dic = new Dictionary<string, string>();
            Dictionary<string, string> Parent_dic = new Dictionary<string, string>();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("匯入學生/家長代碼：");

            foreach (IRowStream each in Rows)
            {
                string Student_Number = each.GetValue("學號");
                string RefStudentID = "";
                if (StudentNumberByID.ContainsKey(Student_Number))
                {
                    RefStudentID = StudentNumberByID[Student_Number]; //學生ID
                }
                else
                {
                    MsgBox.Show("學號不存在(或畢業離校刪除):" + Student_Number);
                }

                string Name = "";
                if (StudentNumberByName.ContainsKey(Student_Number))
                {
                    Name = StudentNumberByName[Student_Number]; //學生姓名
                }
                else
                {
                    MsgBox.Show("學號不存在(或畢業離校刪除):" + Student_Number);
                }

                string Student_Code = "" + each.GetValue("學生代碼");
                string Parent_Code = "" + each.GetValue("家長代碼");

                if (mOption.SelectedFields.Contains("學生代碼"))
                {
                    if (!Student_dic.ContainsKey(RefStudentID))
                    {
                        Student_dic.Add(RefStudentID, Student_Code);
                    }
                }

                if (mOption.SelectedFields.Contains("家長代碼"))
                {
                    if (!Parent_dic.ContainsKey(RefStudentID))
                    {
                        Parent_dic.Add(RefStudentID, Parent_Code);
                    }
                }


                if (mOption.SelectedFields.Contains("學生代碼") == true && mOption.SelectedFields.Contains("學生代碼") == true)
                {
                    sb.AppendLine("學生「" + Name + "」學號「" + Student_Number + "」學生代碼「" + Student_Code + "」家長代碼「" + Parent_Code + "」");
                }
                else if (mOption.SelectedFields.Contains("學生代碼") == true && mOption.SelectedFields.Contains("學生代碼") == false)
                {
                    sb.AppendLine("學生「" + Name + "」學號「" + Student_Number + "」學生代碼「" + Student_Code + "」");
                }
                else if (mOption.SelectedFields.Contains("學生代碼") == false && mOption.SelectedFields.Contains("學生代碼") == true)
                {
                    sb.AppendLine("學生「" + Name + "」學號「" + Student_Number + "」家長代碼「" + Parent_Code + "」");
                }
            }

            if (Student_dic.Count > 0)
            {
                string StudentCmdtemplate = "update student set student_code={0} where id={1}";
                StatTool.GenerateCode_new(Student_dic, StudentCmdtemplate);
            }

            if (Parent_dic.Count > 0)
            {
                string ParentCmdtemplate = "update student set parent_code={0} where id={1}";
                StatTool.GenerateCode_new(Parent_dic, ParentCmdtemplate);
            }

            ApplicationLog.Log("匯入學生家長代碼", "匯入", sb.ToString());

            return "";
        }

        /// <summary>
        /// 取得驗證規則(動態建置XML內容)
        /// </summary>
        public override string GetValidateRule()
        {
            //動態建立XmlRule
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(Properties.Resources.ImportCodeManagement);
            return xmlDoc.InnerXml;
        }

        /// <summary>
        /// 設定匯入功能,所提供的匯入動作
        /// </summary>
        public override ImportAction GetSupportActions()
        {
            //新增(不可更新)
            return ImportAction.Update;
        }
    }
}
