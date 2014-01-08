using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using Aspose.Words;
using System.Diagnostics;
using K12.Data;
using System.IO;

namespace K12Code.Management.Module
{
    public partial class ParentInvitations : BaseForm
    {
        string StudentParentCode_Config = "K12Code.Management.Module.ParentInvitations.cs";

        BackgroundWorker Save_BGW = new BackgroundWorker();

        public ParentInvitations()
        {
            InitializeComponent();
        }

        private void ParentInvitations_Load(object sender, EventArgs e)
        {
            Save_BGW.DoWork += new DoWorkEventHandler(Save_BGW_DoWork);
            Save_BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Save_BGW_RunWorkerCompleted);

            ////取得設定檔
            //Campus.Report.ReportConfiguration ConfigurationInCadre = new Campus.Report.ReportConfiguration(StudentParentCode_Config);
            ////如果沒有設定過樣板
            //if (ConfigurationInCadre.Template == null)
            //{

            //    //預設樣板 & 格式
            //    ConfigurationInCadre.Template = new Campus.Report.ReportTemplate(Properties.Resources.家長說明, Campus.Report.TemplateType.Word);
            //    ConfigurationInCadre.Save();
            //}
            //else
            //{
            //    //預設樣板 & 格式
            //    ConfigurationInCadre.Template = null;
            //    ConfigurationInCadre.Save();
            //}
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (K12.Presentation.NLDPanels.Student.SelectedSource.Count == 0)
            {
                MsgBox.Show("請選擇學生!!");
                return;
            }

            if (K12.Presentation.NLDPanels.Student.SelectedSource.Count > 300)
            {
                DialogResult dr = MsgBox.Show("您選擇的學生超過300名\n若列印張數過多\n可能會產生無法預期的狀況\n您確定要繼續列印嗎?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                if (dr == System.Windows.Forms.DialogResult.No)
                {
                    MsgBox.Show("已取消列印!!");
                    return;
                }
            }

            if (Save_BGW.IsBusy)
            {
                MsgBox.Show("忙碌中,稍後再試!!");
                return;
            }

            btnPrint.Enabled = false;
            Save_BGW.RunWorkerAsync();
        }

        private int SortStudent(ParentStudent p1, ParentStudent p2)
        {
            string s1 = p1.年級.PadLeft(1, '0');
            s1 += p1.班級序號.PadLeft(3, '0');
            s1 += p1.班級.PadLeft(10, '0');
            s1 += p1.座號.PadLeft(3, '0');
            s1 += p1.StudentName.PadLeft(10, '0');

            string s2 = p2.年級.PadLeft(1, '0');
            s2 += p2.班級序號.PadLeft(3, '0');
            s2 += p2.班級.PadLeft(10, '0');
            s2 += p2.座號.PadLeft(3, '0');
            s2 += p2.StudentName.PadLeft(10, '0');

            return s1.CompareTo(s2);
        }

        void Save_BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> StudentIDList = K12.Presentation.NLDPanels.Student.SelectedSource;

            List<ParentStudent> SuperList = GetStudent(StudentIDList);
            SuperList.Sort(SortStudent);
            GetAddress(SuperList, StudentIDList);
            Aspose.Words.Document doc = new Document();
            doc.Sections.Clear();


            #region 取得樣版

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

            #endregion




            DataTable table = new DataTable();

            table.Columns.Add("連結學校");
            table.Columns.Add("家長代碼");
            table.Columns.Add("學生代碼");
            table.Columns.Add("戶籍地址");
            table.Columns.Add("連絡地址");

            table.Columns.Add("學生姓名");
            table.Columns.Add("座號");
            table.Columns.Add("學號");
            table.Columns.Add("班級");

            foreach (ParentStudent each in SuperList)
            {
                //合併欄位
                DataRow row = table.NewRow();

                row["連結學校"] = FISCA.Authentication.DSAServices.AccessPoint;
                row["家長代碼"] = each.ParentCode;
                row["學生代碼"] = each.StudentCode;
                row["戶籍地址"] = each.戶籍地址;
                row["連絡地址"] = each.連絡地址;

                row["學生姓名"] = each.StudentName;
                row["座號"] = each.座號;
                row["學號"] = each.學號;
                row["班級"] = each.班級;

                table.Rows.Add(row);
            }

            Document PageOne = (Document)Template.Clone(true);
            PageOne.MailMerge.Execute(table);
            e.Result = PageOne;
        }

        private void GetAddress(List<ParentStudent> SuperList, List<string> list)
        {
            List<AddressRecord> AddressList = Address.SelectByStudentIDs(list);

            foreach (AddressRecord each in AddressList)
            {
                foreach (ParentStudent stud in SuperList)
                {
                    if (each.RefStudentID == stud.StudentID)
                    {
                        stud.戶籍地址 = each.PermanentAddress;
                        stud.連絡地址 = each.MailingAddress;
                        break;
                    }
                }
            }


        }

        private List<ParentStudent> GetStudent(List<string> StudentIDList)
        {
            List<ParentStudent> StudentList = new List<ParentStudent>();
            //取得學生資料
            StringBuilder sb = new StringBuilder();
            sb.Append("select student.id,student.name,student.seat_no,student.student_number,student.student_code,student.parent_code,class.class_name,class.grade_year,class.display_order ");
            sb.Append("from student join class on student.ref_class_id=class.id ");
            sb.Append(string.Format("where student.id in('{0}')", string.Join("','", StudentIDList)));

            DataTable dt = StatTool.Q.Select(sb.ToString());
            foreach (DataRow row in dt.Rows)
            {
                ParentStudent oc = new ParentStudent(row);
                StudentList.Add(oc);


            }
            return StudentList;
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
                        SaveFileDialog1.FileName = "學生家長代碼邀請函";

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
            Campus.Report.TemplateSettingForm TemplateForm;
            //畫面內容(範本內容,預設樣式
            if (ConfigurationInCadre.Template != null)
            {
                TemplateForm = new Campus.Report.TemplateSettingForm(ConfigurationInCadre.Template, new Campus.Report.ReportTemplate(Properties.Resources.家長說明, Campus.Report.TemplateType.Word));
            }
            else
            {
                ConfigurationInCadre.Template = new Campus.Report.ReportTemplate(Properties.Resources.家長說明, Campus.Report.TemplateType.Word);
                TemplateForm = new Campus.Report.TemplateSettingForm(ConfigurationInCadre.Template, new Campus.Report.ReportTemplate(Properties.Resources.家長說明, Campus.Report.TemplateType.Word));
            }
            //預設名稱

            TemplateForm.DefaultFileName = "學生家長代碼邀請函(樣版)";
            //如果回傳為OK
            if (TemplateForm.ShowDialog() == DialogResult.OK)
            {
                //設定後樣試,回傳
                ConfigurationInCadre.Template = TemplateForm.Template;
                //儲存
                ConfigurationInCadre.Save();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "另存新檔";
            sfd.FileName = "合併欄位總表.doc";
            sfd.Filter = "Word檔案 (*.doc)|*.doc|所有檔案 (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                    fs.Write(Properties.Resources.合併欄位總表, 0, Properties.Resources.合併欄位總表.Length);
                    fs.Close();
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
                catch
                {
                    FISCA.Presentation.Controls.MsgBox.Show("指定路徑無法存取。", "另存檔案失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
