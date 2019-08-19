using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.DocumentValidator;
using System.Data;

namespace K12Code.Management.Module
{
    class FieldValidatorFactoryCode : IFieldValidatorFactory
    {
        #region IFieldValidatorFactory 成員

        public IFieldValidator CreateFieldValidator(string typeName, System.Xml.XmlElement validatorDescription)
        {

            switch (typeName.ToUpper())
            {
                //學號必須存在系統(2019/8/19 - Dylan名稱調整,避免無法迴避256/16)
                case "STUDENTNUMBEREXISTENCECODE":
                    return new StudentNumberExistenceValidator();
                case "STUDENTNUMBERREPEATCODE": //學號不可重覆
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
