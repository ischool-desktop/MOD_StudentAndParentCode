using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K12.Data;
using System.Data;

namespace K12Code.Management.Module
{
    class OneClass
    {

        public string 班級編號 { get; set; }

        public string 班級名稱 { get; set; }

        /// <summary>
        /// 班級序號
        /// </summary>
        public string 班級排列序號 { get; set; }

        /// <summary>
        /// 老師
        /// </summary>
        public string 老師姓名 { get; set; }

        /// <summary>
        /// 年級
        /// </summary>
        public string 年級 { get; set; }

        /// <summary>
        /// 學生基本資料
        /// </summary>
        public List<OneStudent> oneStudentList { get; set; }

        public OneClass(DataRow row)
        {
            oneStudentList = new List<OneStudent>();
            班級編號 = "" + row["id"];
            班級名稱 = "" + row["class_name"];
            班級排列序號 = "" + row["display_order"];
            老師姓名 = "" + row["teacher_name"];
            年級 = "" + row["grade_year"];

        }

        public bool IsMe(OneStudent os)
        {
            if (班級編號 == os.班級編號)
            {
                oneStudentList.Add(os);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
