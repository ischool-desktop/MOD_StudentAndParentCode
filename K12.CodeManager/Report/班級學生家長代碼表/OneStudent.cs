using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K12.Data;
using System.Data;

namespace K12Code.Management.Module
{
    /// <summary>
    /// 學生特設建構
    /// </summary>
    class OneStudent
    {
        public string 班級編號 { get; set; }

        public string 姓名 { get; set; }

        public string 座號 { get; set; }

        public string 學號 { get; set; }

        public string 學生代碼 { get; set; }

        public string 家長代碼 { get; set; }

        public OneStudent(DataRow row)
        {

            班級編號 = "" + row["class_id"];
            姓名 = "" + row["name"];
            座號 = "" + row["seat_no"];
            學號 = "" + row["student_number"];
            學生代碼 = "" + row["student_code"];
            家長代碼 = "" + row["parent_code"];
        }
    }
}
