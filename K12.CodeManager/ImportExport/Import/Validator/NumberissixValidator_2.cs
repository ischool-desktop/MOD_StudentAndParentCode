using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.DocumentValidator;
using System.Text.RegularExpressions;

namespace K12Code.Management.Module
{
    class NumberissixValidator_2 : IFieldValidator
    {

        public bool Validate(string Value)
        {
            if (string.IsNullOrEmpty(Value))
                return true;

            //必須大於等於六碼

            if (Value.Length >= 6)
            {
                return true;
            }
            else
            {
                return false;
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
