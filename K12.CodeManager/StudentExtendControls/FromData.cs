using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K12.Data;

namespace K12Code.Management.Module
{
    class FromData
    {
        /// <summary>
        /// 學生
        /// </summary>
        StudentRecord sr { get; set; }

        /// <summary>
        /// 學生登入帳號
        /// </summary>
        public string SaLoginName
        {
            get
            {
                if (sr != null)
                    return sr.SALoginName;
                else
                    return "";
            }
        }

        /// <summary>
        /// 學生代碼
        /// </summary>
        public string StudentCode { get; set; }

        /// <summary>
        /// 家長代碼
        /// </summary>
        public string ParentCode { get; set; }

        /// <summary>
        /// 學生親屬關係
        /// </summary>
        public List<StudentAndParent> parentList { get; set; }

        /// <summary>
        /// 學生親屬關係
        /// </summary>
        public List<StudentAndParent> DeleteParentList { get; set; }

        public FromData(StudentRecord stud)
        {
            parentList = new List<StudentAndParent>();
            DeleteParentList = new List<StudentAndParent>();
            sr = stud;
        }

        /// <summary>
        /// 檢查是親屬關係
        /// </summary>
        public bool CheckNow(CampusLiteOBJ obj)
        {
            foreach (StudentAndParent each in parentList)
            {
                if (obj.login_name == each.Account)
                {
                    each.Name = obj.name;
                    each.Gender = obj.gender;
                    return true;
                }
            }
            return false;
        }
    }
}
