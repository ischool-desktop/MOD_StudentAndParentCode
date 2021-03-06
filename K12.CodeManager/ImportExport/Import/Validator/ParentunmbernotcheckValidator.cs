﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.DocumentValidator;
using System.Data;

namespace K12Code.Management.Module
{
    class ParentunmbernotcheckValidator : IFieldValidator
    {
        List<string> _StudentDic { get; set; }

        /// <summary>
        /// 家長代碼重覆檢查
        /// </summary>
        public ParentunmbernotcheckValidator()
        {
            _StudentDic = GetStudent();
        }

        private List<string> GetStudent()
        {
            FISCA.Data.QueryHelper _queryHelper = new FISCA.Data.QueryHelper();
            List<string> list = new List<string>();

            DataTable dt = StatTool.Q.Select("select parent_code from student where parent_code is not null");
            foreach (DataRow row in dt.Rows)
            {
                string parent_code = "" + row["parent_code"];
                if (!list.Contains(parent_code))
                {
                    list.Add(parent_code);
                }

            }
            return list;
        }

        public bool Validate(string Value)
        {
            if (string.IsNullOrEmpty(Value))
                return true;

            if (_StudentDic.Contains(Value)) //包含此值
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string Correct(string Value)
        {
            return Value;
        }

        public string ToString(string template)
        {
            return template;
        }
    }
}
