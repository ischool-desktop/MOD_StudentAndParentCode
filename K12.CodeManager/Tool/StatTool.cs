using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.Presentation.Controls;
using FISCA;
using FISCA.Data;
using FISCA.UDT;
using System.Data;

namespace K12Code.Management.Module
{
    static class StatTool
    {
        private static QueryHelper _q;
        /// <summary>
        /// QueryHelper
        /// </summary>
        public static QueryHelper Q
        {
            get
            {
                if (_q == null)
                    _q = new QueryHelper();
                return _q;
            }
        }

        private static UpdateHelper _u;
        /// <summary>
        /// UpdateHelper
        /// </summary>
        public static UpdateHelper U
        {
            get
            {
                if (_u == null)
                    _u = new UpdateHelper();
                return _u;
            }
        }

        private static AccessHelper _a;
        /// <summary>
        /// AccessHelper
        /// </summary>
        public static AccessHelper A
        {
            get
            {
                if (_a == null)
                    _a = new AccessHelper();
                return _a;
            }
        }

        /// <summary>
        /// 批次儲存與產生Code
        /// </summary>
        public static void GenerateCode(string cmdTemplate)
        {
            try
            {
                U.Execute(cmdTemplate);
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                MsgBox.Show("儲存資料發生錯誤:\n" + ex.Message);
            }
        }

        public static void ClearRelationship(string cmdTemplate)
        {
            try
            {
                U.Execute(cmdTemplate);
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                MsgBox.Show("儲存資料發生錯誤:\n" + ex.Message);
            }
        }

        /// <summary>
        /// 批次儲存與產生Code
        /// </summary>
        public static void Ph_GenerateCode(List<string> idlist, string cmdTemplate, int codeLength)
        {
            List<string> cmds = new List<string>();

            foreach (string id in idlist)
            {
                string code = Guid.NewGuid().ToString().Substring(1, codeLength).ToUpper();
                string cmd = string.Format(cmdTemplate, code, id);
                cmds.Add(cmd);
            }

            try
            {
                U.Execute(cmds);
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                MsgBox.Show("儲存資料發生錯誤:\n" + ex.Message);
            }
        }

        /// <summary>
        /// 批次產生代碼
        /// </summary>
        public static void GenerateCode(List<string> idlist, string cmdTemplate, int codeLength, string codeType, string ant)
        {
            //取得所有教師代碼
            List<string> StringList = new List<string>();
            DataTable dt = Q.Select(string.Format("select {0} from {1} where {0} is not null", codeType, ant));
            foreach (DataRow row in dt.Rows)
            {
                string code = "" + row[codeType];
                if (!StringList.Contains(code))
                {
                    StringList.Add(code);
                }
            }

            List<string> cmds = new List<string>();
            foreach (string id in idlist)
            {
                bool a = false;

                for (int x = 1; x > 0; x++) //無限迴圈
                {
                    if (a)
                        break;
                    //如果是系統內已存代碼,就捨棄重新產生
                    string code = Guid.NewGuid().ToString().Substring(1, codeLength).ToUpper();

                    if (!StringList.Contains(code))
                    {
                        StringList.Add(code);
                        string cmd = string.Format(cmdTemplate, code, id);
                        cmds.Add(cmd);
                        a = true;
                    }
                }

            }

            try
            {
                U.Execute(cmds);
                MsgBox.Show("產生完成!");
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                MsgBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 批次更新代碼
        /// </summary>
        public static void GenerateCode_new(Dictionary<string, string> dic, string cmdTemplate)
        {
            List<string> cmds = new List<string>();

            foreach (string id in dic.Keys)
            {
                if (!string.IsNullOrEmpty(dic[id]))
                {
                    string cmd = string.Format(cmdTemplate, "'" + dic[id] + "'", id);
                    cmds.Add(cmd);
                }
                else
                {
                    string cmd = string.Format(cmdTemplate, "null", id);
                    cmds.Add(cmd);
                }

            }

            U.Execute(cmds);

        }

        /// <summary>
        /// 批次清除代碼
        /// </summary>
        public static void ClearCode(List<string> idList, string cmdTemplate)
        {
            List<string> cmds = new List<string>();

            foreach (string id in idList)
                cmds.Add(string.Format(cmdTemplate, id));

            try
            {
                U.Execute(cmds);
                MsgBox.Show("清除完成!");
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                MsgBox.Show(ex.Message);
            }
        }

        public static int sortStud(stud A1, stud B1)
        {
            string aa1 = A1.ClassName.PadLeft(10, '0');
            aa1 += A1.SeatNo.PadLeft(3, '0');
            aa1 += A1.Name.PadLeft(10, '0');

            string bb1 = B1.ClassName.PadLeft(10, '0');
            bb1 += B1.SeatNo.PadLeft(3, '0');
            bb1 += B1.Name.PadLeft(10, '0');

            return aa1.CompareTo(bb1);
        }
    }
}
