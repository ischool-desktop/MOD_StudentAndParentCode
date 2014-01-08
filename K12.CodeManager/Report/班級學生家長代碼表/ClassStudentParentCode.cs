using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using System.IO;
using Aspose.Words;
using System.Diagnostics;

namespace K12Code.Management.Module
{
    public partial class ClassStudentParentCode : BaseForm
    {
        BackgroundWorker Save_BGW = new BackgroundWorker();

        string StudentParentCode_Config = "K12Code.Management.Module.ClassStudentParentCode.cs";

        public ClassStudentParentCode()
        {
            InitializeComponent();

            Save_BGW.DoWork += new DoWorkEventHandler(Save_BGW_DoWork);
            Save_BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Save_BGW_RunWorkerCompleted);

            ////取得設定檔
            //Campus.Report.ReportConfiguration ConfigurationInCadre = new Campus.Report.ReportConfiguration(StudentParentCode_Config);
            ////如果沒有設定過樣板
            //if (ConfigurationInCadre.Template == null)
            //{
            //    //預設樣板 & 格式
            //    ConfigurationInCadre.Template = new Campus.Report.ReportTemplate(Properties.Resources.班級學生家長代碼表_範例, Campus.Report.TemplateType.Word);
            //    ConfigurationInCadre.Save();
            //}
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (K12.Presentation.NLDPanels.Class.SelectedSource.Count == 0)
            {
                MsgBox.Show("請選擇班級!!");
                return;
            }

            if (Save_BGW.IsBusy)
            {
                MsgBox.Show("忙碌中,稍後再試!!");
                return;
            }

            btnPrint.Enabled = false;
            Save_BGW.RunWorkerAsync();
        }

        void Save_BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            //取得選擇班級
            List<string> ClassIDList = K12.Presentation.NLDPanels.Class.SelectedSource;
            //取得班級資料
            List<OneClass> ClassSuperList = GetClass(ClassIDList);
            //取得學生資料
            List<OneStudent> StudentSuperList = GetStudent(ClassIDList);
            //判斷班級與學生關係
            Moge(ClassSuperList, StudentSuperList);

            Aspose.Words.Document doc = new Document();
            doc.Sections.Clear();

            Campus.Report.ReportConfiguration ConfigurationInCadre = new Campus.Report.ReportConfiguration(StudentParentCode_Config);
            Aspose.Words.Document Template;
            if (ConfigurationInCadre.Template == null)
            {
                //如果範本為空,則建立一個預設範本
                Campus.Report.ReportConfiguration ConfigurationInCadre_1 = new Campus.Report.ReportConfiguration(StudentParentCode_Config);
                ConfigurationInCadre_1.Template = new Campus.Report.ReportTemplate(Properties.Resources.家長說明, Campus.Report.TemplateType.Word);
                Template = ConfigurationInCadre_1.Template.ToDocument();
            }
            else
            {
                //如果已有範本,則取得樣板
                Template = ConfigurationInCadre.Template.ToDocument();
            }










            DataTable table = new DataTable();

            //合併欄位
            table.Columns.Add("班級");
            table.Columns.Add("教師");

            for (int x = 1; x < 80; x++)
            {
                table.Columns.Add("座號" + x);
                table.Columns.Add("姓名" + x);
                table.Columns.Add("學號" + x);
                table.Columns.Add("學生代碼" + x);
                table.Columns.Add("家長代碼" + x);
            }

            ClassSuperList.Sort(SortClass);
            foreach (OneClass cls in ClassSuperList)
            {
                cls.oneStudentList.Sort(SortStudent);
            }

            foreach (OneClass cls in ClassSuperList)
            {
                if (cls.oneStudentList.Count == 0)
                    continue;

                int y = 1;
                DataRow row = table.NewRow();
                //取得範本樣式

                row["班級"] = cls.班級名稱;
                row["教師"] = cls.老師姓名;

                foreach (OneStudent stud in cls.oneStudentList)
                {
                    row["座號" + y] = stud.座號;
                    row["姓名" + y] = stud.姓名;
                    row["學號" + y] = stud.學號;
                    row["學生代碼" + y] = stud.學生代碼;
                    row["家長代碼" + y] = stud.家長代碼;
                    y++;
                }
                table.Rows.Add(row);
                //doc.Sections.Add(doc.ImportNode(PageOne.FirstSection, true));
            }

            Document PageOne = (Document)Template.Clone(true);
            PageOne.MailMerge.Execute(table);
            e.Result = PageOne;
        }

        private int SortStudent(OneStudent sa, OneStudent sb)
        {
            string st_a = sa.座號.PadLeft(3, '0');
            st_a += sa.姓名.PadLeft(10, '0');

            string st_b = sb.座號.PadLeft(3, '0');
            st_b += sb.姓名.PadLeft(10, '0');

            return st_a.CompareTo(st_b);
        }

        private int SortClass(OneClass ca, OneClass cb)
        {
            string gt_a = ca.年級.PadLeft(1, '0');
            gt_a += ca.班級排列序號.PadLeft(2, '0');
            gt_a += ca.班級名稱.PadLeft(10, '0');

            string gt_b = cb.年級.PadLeft(1, '0');
            gt_b += cb.班級排列序號.PadLeft(2, '0');
            gt_b += cb.班級名稱.PadLeft(10, '0');

            return gt_a.CompareTo(gt_b);
        }

        private void Moge(List<OneClass> ClassSuperList, List<OneStudent> StudentSuperList)
        {
            foreach (OneStudent stud in StudentSuperList)
            {
                foreach (OneClass Cls in ClassSuperList)
                {
                    if (Cls.IsMe(stud))
                        break;
                    else
                        continue;
                }
            }
        }

        private List<OneStudent> GetStudent(List<string> ClassIDList)
        {
            List<OneStudent> list = new List<OneStudent>();
            //取得學生資料
            string QuValue = string.Format("select class.id as class_id,student.id,student.name,student.seat_no,student.student_number,student.student_code,student.parent_code from class join student on student.ref_class_id=class.id where class.id in('{0}') and (student.status=1 or student.status=2)", string.Join("','", ClassIDList));
            DataTable dt = StatTool.Q.Select(QuValue);
            foreach (DataRow row in dt.Rows)
            {
                OneStudent oc = new OneStudent(row);
                list.Add(oc);
            }
            return list;
        }

        private List<OneClass> GetClass(List<string> ClassIDList)
        {
            List<OneClass> list = new List<OneClass>();
            //取得班級基本資料
            string QuValue = string.Format("select class.id,class.class_name,class.display_order,teacher.teacher_name,class.grade_year from class join teacher on class.ref_teacher_id=teacher.id where class.id in('{0}')", string.Join("','", ClassIDList));

            //取得班級Record
            DataTable dt = StatTool.Q.Select(QuValue);
            foreach (DataRow row in dt.Rows)
            {
                OneClass oc = new OneClass(row);
                list.Add(oc);
            }
            return list;
        }

        void Save_BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnPrint.Enabled = true;

            if (e.Cancelled)
            {
                MsgBox.Show("作業已被中止!!");
            }
            else
            {
                if (e.Error == null)
                {
                    Document inResult = (Document)e.Result;

                    try
                    {
                        SaveFileDialog SaveFileDialog1 = new SaveFileDialog();

                        SaveFileDialog1.Filter = "Word (*.doc)|*.doc|所有檔案 (*.*)|*.*";
                        SaveFileDialog1.FileName = "班級學生家長代碼表";

                        if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            inResult.Save(SaveFileDialog1.FileName);
                            Process.Start(SaveFileDialog1.FileName);
                        }
                        else
                        {
                            FISCA.Presentation.Controls.MsgBox.Show("檔案未儲存");
                            return;
                        }
                    }
                    catch
                    {
                        FISCA.Presentation.Controls.MsgBox.Show("檔案儲存錯誤,請檢查檔案是否開啟中!!");
                        return;
                    }

                    this.Close();
                }
                else
                {
                    MsgBox.Show("列印資料發生錯誤\n" + e.Error.Message);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //取得設定檔
            Campus.Report.ReportConfiguration ConfigurationInCadre = new Campus.Report.ReportConfiguration(StudentParentCode_Config);
            //畫面內容(範本內容,預設樣式
            Campus.Report.TemplateSettingForm TemplateForm = new Campus.Report.TemplateSettingForm(ConfigurationInCadre.Template, new Campus.Report.ReportTemplate(Properties.Resources.班級學生家長代碼表_範例, Campus.Report.TemplateType.Word));
            //預設名稱
            TemplateForm.DefaultFileName = "班級學生家長代碼表(樣版)";
            //如果回傳為OK
            if (TemplateForm.ShowDialog() == DialogResult.OK)
            {
                //設定後樣試,回傳
                ConfigurationInCadre.Template = TemplateForm.Template;
                //儲存
                ConfigurationInCadre.Save();
            }
        }
    }
}
