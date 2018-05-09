using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K12Code.Management.Module
{
    class Permissions
    {
        //權限代碼
        public static string 帳號與親子關係 { get { return "K12Code.Management.Module.StudentExtendControls.StudentItem.cs"; } }

        public static bool 帳號與親子關係權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[帳號與親子關係].Executable;
            }
        }

        public static string 班級學生家長代碼表 { get { return "K12Code.Management.Module.StudentExtendControls.ClassStudentParentCode.cs"; } }

        public static bool 班級學生家長代碼表權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[班級學生家長代碼表].Executable;
            }
        }

        public static string 批次產生學生代碼 { get { return "K12Code.Management.Module.Batch.Generate.Student.Code"; } }

        public static bool 批次產生學生代碼權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[批次產生學生代碼].Executable;
            }
        }

        public static string 批次清除學生代碼 { get { return "K12Code.Management.Module.Batch.Generate.Student.Code.Remove"; } }

        public static bool 批次清除學生代碼權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[批次清除學生代碼].Executable;
            }
        }

        public static string 批次產生家長代碼 { get { return "K12Code.Management.Module.Batch.Generate.Parent.Code"; } }

        public static bool 批次產生家長代碼權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[批次產生家長代碼].Executable;
            }
        }

        public static string 批次清除家長代碼 { get { return "K12Code.Management.Module.Batch.Generate.Parent.Code.Remove"; } }

        public static bool 批次清除家長代碼權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[批次清除家長代碼].Executable;
            }
        }

        public static string 匯出學生家長代碼 { get { return "K12Code.Management.Module.ExportStudentAndParent.cs"; } }

        public static bool 匯出學生家長代碼權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[匯出學生家長代碼].Executable;
            }
        }

        public static string 匯入學生家長代碼 { get { return "K12Code.Management.Module.ImportStudentAndParent.cs"; } }

        public static bool 匯入學生家長代碼權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[匯入學生家長代碼].Executable;
            }
        }

        public static string 學生家長代碼邀請函 { get { return "K12Code.Management.Module.ParentInvitations.cs"; } }

        public static bool 學生家長代碼邀請函碼權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[學生家長代碼邀請函].Executable;
            }
        }

        public static string 快速檢視代碼清單 { get { return "K12Code.Management.Module.NotepadForm.cs"; } }

        public static bool 快速檢視代碼清單權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[快速檢視代碼清單].Executable;
            }
        }

        //教師
        public static string 批次產生教師代碼 { get { return "K12Code.Management.Module.Batch.Generate.Teacher.Code"; } }

        public static bool 批次產生教師代碼權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[批次產生教師代碼].Executable;
            }
        }

        public static string 批次清除教師代碼 { get { return "K12Code.Management.Module.Batch.Generate.Teacher.Code.Remove"; } }

        public static bool 批次清除教師代碼權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[批次清除教師代碼].Executable;
            }
        }

        public static string 快速檢視教師代碼清單 { get { return "K12Code.Management.Module.NotepadForm.cs.teacher"; } }

        public static bool 快速檢視教師代碼清單權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[快速檢視教師代碼清單].Executable;
            }
        }

        //權限代碼
        public static string 教師代碼 { get { return "K12Code.Management.Module.TeacherItem.cs"; } }

        public static bool 教師代碼權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[教師代碼].Executable;
            }
        }

        //權限代碼
        public static string 家長帳號查詢 { get { return "K12Code.Management.Module.Form.ParentSeachForm.cs"; } }

        public static bool 家長帳號查詢權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[家長帳號查詢].Executable;
            }
        }
    }
}
