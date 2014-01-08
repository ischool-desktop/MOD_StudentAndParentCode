using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FISCA.Presentation.Controls;
using System.Windows.Forms;
using System.ComponentModel;

namespace K12Code.Management.Module
{
    public static class RunCode
    {
        /// <summary>
        /// 產生學生代碼
        /// </summary>
        public static void Run_GenerateCode()
        {
            if (K12.Presentation.NLDPanels.Student.SelectedSource.Count > 0)
            {
                DialogResult dr = MsgBox.Show("批次產生學生代碼,將會覆蓋原有代碼\n您確認此操作?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    FISCA.Presentation.MotherForm.SetStatusBarMessage("開始產生學生代碼...");
                    BackgroundWorker BGW = new BackgroundWorker();
                    BGW.DoWork += delegate
                    {
                        List<string> idlist = K12.Presentation.NLDPanels.Student.SelectedSource;
                        string cmdtemplate = "update student set student_code='{0}' where id={1}";
                        StatTool.GenerateCode(idlist, cmdtemplate, 6, "student_code", "student");
                        LogDetail(idlist, "批次產生學生代碼", "產生");
                    };
                    BGW.RunWorkerAsync();
                    BGW.RunWorkerCompleted += delegate
                    {
                        FISCA.Presentation.MotherForm.SetStatusBarMessage("已完成產生學生代碼!!");
                    };
                }
                else
                {
                    MsgBox.Show("已中止操作!!");
                }
            }
            else
            {
                MsgBox.Show("請選擇學生!!");
            }
        }

        /// <summary>
        /// 清除學生代碼
        /// </summary>
        public static void Run_ClearCode()
        {
            if (K12.Presentation.NLDPanels.Student.SelectedSource.Count > 0)
            {
                DialogResult dr = MsgBox.Show("此操作會清除學生代碼\n您確認此操作?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    FISCA.Presentation.MotherForm.SetStatusBarMessage("開始清除學生代碼...");
                    BackgroundWorker BGW = new BackgroundWorker();
                    BGW.DoWork += delegate
                    {
                        List<string> idlist = K12.Presentation.NLDPanels.Student.SelectedSource;
                        string cmdtemplate = "update student set student_code=null where id={0}";
                        StatTool.ClearCode(idlist, cmdtemplate);

                        LogDetail(idlist, "批次清除學生代碼", "清除");
                    };
                    BGW.RunWorkerAsync();
                    BGW.RunWorkerCompleted += delegate
                    {
                        FISCA.Presentation.MotherForm.SetStatusBarMessage("已完成清除學生代碼!!");
                    };
                }
                else
                {
                    MsgBox.Show("已中止操作!!");
                }
            }
            else
            {
                MsgBox.Show("請選擇學生!!");
            }
        }

        /// <summary>
        /// 產生家長代碼
        /// </summary>
        public static void Run_GenerateCode2()
        {
            if (K12.Presentation.NLDPanels.Student.SelectedSource.Count > 0)
            {
                DialogResult dr = MsgBox.Show("批次產生家長代碼,將會覆蓋原有代碼\n您確認此操作?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    FISCA.Presentation.MotherForm.SetStatusBarMessage("開始產生家長代碼...");
                    BackgroundWorker BGW = new BackgroundWorker();
                    BGW.DoWork += delegate
                    {
                        List<string> idlist = K12.Presentation.NLDPanels.Student.SelectedSource;
                        string cmdtemplate = "update student set parent_code='{0}' where id={1}";
                        StatTool.GenerateCode(idlist, cmdtemplate, 6, "parent_code", "student");

                        LogDetail(idlist, "批次產生家長代碼", "產生");
                    };
                    BGW.RunWorkerAsync();
                    BGW.RunWorkerCompleted += delegate
                    {
                        FISCA.Presentation.MotherForm.SetStatusBarMessage("已完成產生家長代碼!!");
                    };
                }
                else
                {
                    MsgBox.Show("已中止操作!!");
                }
            }
            else
            {
                MsgBox.Show("請選擇學生!!");
            }
        }

        /// <summary>
        /// 清除家長代碼
        /// </summary>
        public static void Run_ClearCode2()
        {
            if (K12.Presentation.NLDPanels.Student.SelectedSource.Count > 0)
            {
                DialogResult dr = MsgBox.Show("此操作會清除家長代碼\n您確認此操作?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    FISCA.Presentation.MotherForm.SetStatusBarMessage("開始清除家長代碼...");
                    BackgroundWorker BGW = new BackgroundWorker();
                    BGW.DoWork += delegate
                    {
                        List<string> idlist = K12.Presentation.NLDPanels.Student.SelectedSource;
                        string cmdtemplate = "update student set parent_code=null where id={0}";
                        StatTool.ClearCode(idlist, cmdtemplate);

                        LogDetail(idlist, "批次清除家長代碼", "清除");
                    };
                    BGW.RunWorkerAsync();
                    BGW.RunWorkerCompleted += delegate
                    {
                        FISCA.Presentation.MotherForm.SetStatusBarMessage("已完成清除家長代碼!!");
                    };
                }
                else
                {
                    MsgBox.Show("已中止操作!!");
                }
            }
            else
            {
                MsgBox.Show("請選擇學生!!");
            }
        }

        /// <summary>
        /// 產生教師代碼
        /// </summary>
        internal static void Run_GenerateCode3()
        {
            if (K12.Presentation.NLDPanels.Teacher.SelectedSource.Count > 0)
            {
                DialogResult dr = MsgBox.Show("批次產生教師代碼,將會覆蓋原有代碼\n您確認此操作?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    FISCA.Presentation.MotherForm.SetStatusBarMessage("開始產生教師代碼...");
                    BackgroundWorker BGW = new BackgroundWorker();
                    BGW.DoWork += delegate
                    {
                        List<string> idlist = K12.Presentation.NLDPanels.Teacher.SelectedSource;
                        string cmdtemplate = "update teacher set teacher_code='{0}' where id={1}";
                        StatTool.GenerateCode(idlist, cmdtemplate, 6, "teacher_code", "teacher");
                    };
                    BGW.RunWorkerAsync();
                    BGW.RunWorkerCompleted += delegate
                    {
                        FISCA.Presentation.MotherForm.SetStatusBarMessage("已完成產生教師代碼!!");
                    };
                }
                else
                {
                    MsgBox.Show("已中止操作!!");
                }
            }
            else
            {
                MsgBox.Show("請選擇教師!!");
            }
        }

        /// <summary>
        /// 清除教師代碼
        /// </summary>
        public static void Run_ClearCode3()
        {
            if (K12.Presentation.NLDPanels.Teacher.SelectedSource.Count > 0)
            {
                DialogResult dr = MsgBox.Show("此操作會清除教師代碼\n您確認此操作?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    FISCA.Presentation.MotherForm.SetStatusBarMessage("開始清除教師代碼...");
                    BackgroundWorker BGW = new BackgroundWorker();
                    BGW.DoWork += delegate
                    {
                        List<string> idlist = K12.Presentation.NLDPanels.Teacher.SelectedSource;
                        string cmdtemplate = "update teacher set teacher_code=null where id={0}";
                        StatTool.ClearCode(idlist, cmdtemplate);
                    };
                    BGW.RunWorkerAsync();
                    BGW.RunWorkerCompleted += delegate
                    {
                        FISCA.Presentation.MotherForm.SetStatusBarMessage("已完成清除教師代碼!!");
                    };
                }
                else
                {
                    MsgBox.Show("已中止操作!!");
                }
            }
            else
            {
                MsgBox.Show("請選擇教師!!");
            }
        }

        /// <summary>
        /// 檢視代碼
        /// </summary>
        public static void Run_ViewCode()
        {
            if (K12.Presentation.NLDPanels.Student.SelectedSource.Count > 0)
            {
                StringBuilder data = new StringBuilder();
                BackgroundWorker BGW = new BackgroundWorker();
                BGW.DoWork += delegate
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select student.id,student.seat_no,student.gender,student.student_number,student.name,student.student_code,student.parent_code,class.class_name ");
                    sb.Append("from student left join class on student.ref_class_id=class.id where student.id in ");
                    sb.Append("('" + string.Join("','", K12.Presentation.NLDPanels.Student.SelectedSource) + "') ");
                    sb.Append("order by class.grade_year,class.display_order,class.class_name,student.seat_no,student.name");

                    DataTable dt = StatTool.Q.Select(sb.ToString());
                    data.Append("班級\t座號\t姓名\t學號\t學生代碼\t家長代碼\r\n");
                    foreach (DataRow row in dt.Rows)
                    {
                        data.Append(row["class_name"] + "\t" + row["seat_no"] + "\t" + row["name"] + "\t" + row["student_number"] + "\t" + row["student_code"] + "\t" + row["parent_code"] + "\r\n");
                    }
                };

                BGW.RunWorkerAsync();

                BGW.RunWorkerCompleted += delegate
                {
                    NotepadForm nf = new NotepadForm(data.ToString());
                    nf.ShowDialog();
                };

            }
            else
            {
                MsgBox.Show("請選擇學生!!");
            }
        }

        /// <summary>
        /// 檢視教師代碼
        /// </summary>
        public static void Run_ViewCode3()
        {
            if (K12.Presentation.NLDPanels.Teacher.SelectedSource.Count > 0)
            {
                StringBuilder data = new StringBuilder();
                BackgroundWorker BGW = new BackgroundWorker();
                BGW.DoWork += delegate
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select teacher.id,teacher.teacher_name,teacher.gender,teacher.nickname,teacher.teacher_code ");
                    sb.Append("from teacher where teacher.id in ");
                    sb.Append("('" + string.Join("','", K12.Presentation.NLDPanels.Teacher.SelectedSource) + "') ");
                    sb.Append("order by teacher_name,teacher.nickname");

                    DataTable dt = StatTool.Q.Select(sb.ToString());
                    data.Append("教師姓名\t暱稱\t性別\t教師代碼\r\n");
                    foreach (DataRow row in dt.Rows)
                    {
                        string gender = "";
                        if ("" + row["gender"] == "1")
                        {
                            gender = "男";
                        }
                        else if ("" + row["gender"] == "0")
                        {
                            gender = "女";
                        }
                        data.Append(row["teacher_name"] + "\t" + row["nickname"] + "\t" + gender + "\t" + row["teacher_code"] + "\r\n");
                    }
                };

                BGW.RunWorkerAsync();

                BGW.RunWorkerCompleted += delegate
                {
                    NotepadForm nf = new NotepadForm(data.ToString());
                    nf.ShowDialog();
                };

            }
            else
            {
                MsgBox.Show("請選擇教師!!");
            }
        }

        public static void LogDetail(List<string> idlist, string p, string o)
        {
            StringBuilder sb2 = new StringBuilder();
            sb2.Append("select student.id,student.name,student.seat_no,student.student_number,class.class_name ");
            sb2.Append("from student left join class on student.ref_class_id=class.id ");
            sb2.Append("where student.id in ('" + string.Join("','", idlist) + "')");
            DataTable dt = StatTool.Q.Select(sb2.ToString());
            List<stud> list = new List<stud>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new stud(row));
            }
            list.Sort(StatTool.sortStud);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(p);
            foreach (stud each in list)
            {
                sb.Append("班級「" + each.ClassName + "」");
                sb.Append("座號「" + each.SeatNo + "」");
                sb.Append("學生「" + each.Name + "」");
                sb.AppendLine("學號「" + each.StudentNumber + "」");
            }

            FISCA.LogAgent.ApplicationLog.Log(p, o, sb.ToString());
        }
    }
}
