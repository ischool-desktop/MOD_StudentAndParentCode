using System.Collections.Generic;
using K12.Data;
using SmartSchool.API.PlugIn;
using System;
using FISCA.UDT;
using System.Text;
using FISCA.LogAgent;
using System.Data;

namespace K12Code.Management.Module
{
    class ExportStudentAndParent : SmartSchool.API.PlugIn.Export.Exporter
    {
        //建構子
        public ExportStudentAndParent()
        {
            this.Image = null;
            this.Text = "匯出學生家長代碼";
        }

        public override void InitializeExport(SmartSchool.API.PlugIn.Export.ExportWizard wizard)
        {
            wizard.ExportableFields.AddRange("性別", "戶籍電話", "聯絡電話", "戶籍地址", "聯絡地址", "學生代碼", "家長代碼","登入帳號");

            wizard.ExportPackage += delegate(object sender, SmartSchool.API.PlugIn.Export.ExportPackageEventArgs e)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select student.id,student.seat_no,student.permanent_phone,student.contact_phone,student.gender,student.name,student.student_code,student.parent_code,class.grade_year,class.class_name,class.display_order,student_parent.account ");
                sb.Append("from student left join class on student.ref_class_id=class.id left join student_parent on student.id=student_parent.ref_student_id where student.id in ");
                sb.Append("('" + string.Join("','", e.List) + "') ");
                sb.Append("order by grade_year,display_order,class_name,seat_no,name");
                //地址
                Dictionary<string, AddressRecord> AddressDic = new Dictionary<string, AddressRecord>();
                List<AddressRecord> AddressList = K12.Data.Address.SelectByStudentIDs(e.List);
                foreach (AddressRecord each in AddressList)
                {
                    if (!AddressDic.ContainsKey(each.RefStudentID))
                    {
                        AddressDic.Add(each.RefStudentID, each);
                    }
                }

                DataTable dt = StatTool.Q.Select(sb.ToString());

                foreach (DataRow dRow in dt.Rows)
                {
                    string ref_student_id = "" + dRow["id"];
                    string PermanentAddress = "";
                    string MailingAddress = "";
                    string gender = "";
                    if ("" + dRow["gender"] == "1")
                    {
                        gender = "男";
                    }
                    else if ("" + dRow["gender"] == "0")
                    {
                        gender = "女";
                    }
                    if (AddressDic.ContainsKey(ref_student_id))
                    {
                        PermanentAddress = AddressDic[ref_student_id].PermanentAddress;
                        MailingAddress = AddressDic[ref_student_id].MailingAddress;
                    }

                    RowData row = new RowData();
                    row.ID = ref_student_id;
                    foreach (string field in e.ExportFields)
                    {
                        if (wizard.ExportableFields.Contains(field))
                        {
                            switch (field)
                            {
                                case "性別": row.Add(field, gender); break;
                                case "戶籍電話": row.Add(field, "" + dRow["permanent_phone"]); break;
                                case "聯絡電話": row.Add(field, "" + dRow["contact_phone"]); break;
                                case "戶籍地址": row.Add(field, PermanentAddress); break;
                                case "聯絡地址": row.Add(field, MailingAddress); break;
                                case "學生代碼": row.Add(field, "" + dRow["student_code"]); break;
                                case "家長代碼": row.Add(field, "" + dRow["parent_code"]); break;
                                case "登入帳號": row.Add(field, "" + dRow["account"]); break;
                            }
                        }
                    }
                    e.Items.Add(row);
                }
            };
        }
    }
}
