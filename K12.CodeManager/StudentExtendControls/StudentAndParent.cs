using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace K12Code.Management.Module
{
    class StudentAndParent
    {
        /// <summary>
        /// 編號
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 學生ID
        /// </summary>
        public string StudentID { get; set; }

        /// <summary>
        /// 家長登入帳號
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 關係名稱
        /// </summary>
        public string Relationship { get; set; }

        /// <summary>
        /// 家長名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 親屬關係ID
        /// </summary>
        public string ParentID { get; set; }

        private string _gender { get; set; }

        public string Gender
        {
            get
            {
                if (_gender == "1")
                {
                    return "男";
                }
                else if (_gender == "0")
                {
                    return "女";
                }
                else
                {
                    return "";
                }
            }
            set
            {
                _gender = value;
            }
        }

        public StudentAndParent(DataRow row)
        {
            id = "" + row["id"];
            StudentID = "" + row["ref_student_id"];
            Account = "" + row["account"];
            Relationship = "" + row["relationship"];
        }
    }
}
