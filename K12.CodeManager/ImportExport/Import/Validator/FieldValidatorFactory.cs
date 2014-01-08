using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.DocumentValidator;
using System.Data;

namespace K12Code.Management.Module
{
    class FieldValidatorFactory : IFieldValidatorFactory
    {
        #region IFieldValidatorFactory 成員

        public IFieldValidator CreateFieldValidator(string typeName, System.Xml.XmlElement validatorDescription)
        {

            switch (typeName.ToUpper())
            {
                case "STUDENTNUMBEREXISTENCE": //學號必須尋在系統
                    return new StudentNumberExistenceValidator();
                case "STUDENTNUMBERREPEAT": //學號不可重覆
                    return new StudentNumberRepeatValidator();
                case "STUDENTNUMBERNOTCHECK": //學生代碼不可重覆
                    return new StudentnumbernotcheckValidator();
                case "PARENTNUMBERNOTCHECK": //家長代碼不可重覆
                    return new ParentunmbernotcheckValidator();
                case "NUMBERISSIX1": //建議是6碼英文數字
                    return new NumberissixValidator();
                case "NUMBERISSIX2": //建議是6碼英文數字
                    return new NumberissixValidator_2();
                case "DATAREPEATCHECK1": //建議資料是否重覆過了1
                    return new DataRepeatCheckValidator1();
                case "DATAREPEATCHECK2": //建議資料是否重覆過了2
                    return new DataRepeatCheckValidator2();
                default:
                    return null;
            }
        }
        #endregion
    }
}
