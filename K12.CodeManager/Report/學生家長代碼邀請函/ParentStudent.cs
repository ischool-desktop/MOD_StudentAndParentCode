using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace K12Code.Management.Module
{
    public class ParentStudent
    {
        /// <summary>
        /// 學生ID
        /// </summary>
        public string StudentID { get; set; }
        /// <summary>
        /// 學生姓名
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// 家長代碼
        /// </summary>
        public string ParentCode { get; set; }
        /// <summary>
        /// 學生代碼
        /// </summary>
        public string StudentCode { get; set; }

        public string 戶籍地址 { get; set; }

        public string 連絡地址 { get; set; }

        public string 座號 { get; set; }

        public string 學號 { get; set; }

        public string 班級 { get; set; }

        public string 年級 { get; set; }

        public string 班級序號 { get; set; }

        public ParentStudent(DataRow row)
        {
            StudentID = "" + row["id"];
            StudentName = "" + row["name"];

            ParentCode = "" + row["parent_code"];
            StudentCode = "" + row["student_code"];

            座號 = "" + row["seat_no"];
            學號 = "" + row["student_number"];

            班級 = "" + row["class_name"];
            年級 = "" + row["grade_year"];

            班級序號 = "" + row["display_order"];
        }


    }
}
