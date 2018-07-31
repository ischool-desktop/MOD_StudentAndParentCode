using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace K12Code.Management.Module
{
    public class CampusLiteOBJ
    {
        /// <summary>
        /// 登入帳號
        /// </summary>
        public string login_name { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        public string gender { get; set; }

        public CampusLiteOBJ(DataRow row)
        {
            login_name = "" + row["login_name"];
            name = "" + row["name"];
            gender = "" + row["gender"];
        }
    }
}
