using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.DocumentValidator;
using System.Text.RegularExpressions;

namespace K12Code.Management.Module
{
    class NumberissixValidator : IFieldValidator
    {

        public bool Validate(string Value)
        {
            //必須是英數
            if (string.IsNullOrEmpty(Value))
                return true;

            if (Regex.IsMatch(Value, @"[^a-zA-Z_0-9]"))
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
