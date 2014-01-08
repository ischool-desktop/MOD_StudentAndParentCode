using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.DocumentValidator;

namespace K12Code.Management.Module
{
    class DataRepeatCheckValidator1 : IFieldValidator
    {
        List<string> list = new List<string>();

        public string Correct(string Value)
        {
            return Value;
        }

        public string ToString(string template)
        {
            return template;
        }

        public bool Validate(string Value)
        {
            if (string.IsNullOrEmpty(Value))
                return true;

            //檢查資料是否重覆過了
            if (!list.Contains(Value))
            {
                list.Add(Value);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
