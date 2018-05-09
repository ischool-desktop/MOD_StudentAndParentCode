using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K12Code.Management.Module
{
    public class Stud
    {
        public Stud(DataRow row)
        {
            student_id = "" + row["student_id"];
            student_name = "" + row["student_name"];
            student_number = "" + row["student_number"];
            seat_no = "" + row["seat_no"];
            class_name = "" + row["class_name"];
            grade_year = "" + row["grade_year"];
            parent_account = "" + row["parent_account"];
            relationship = "" + row["relationship"];

            student_account = "" + row["sa_login_name"];
            father_name = "" + row["father_name"];
            mother_name = "" + row["mother_name"];
            student_code = "" + row["student_code"];
            parent_code = "" + row["parent_code"];

            custodian_name = "" + row["custodian_name"];

        }

        public void Save()
        {
            //將本筆資料進行儲存動作






        }




        public string student_id { get; set; }
        public string student_name { get; set; }
        public string student_number { get; set; }
        public string seat_no { get; set; }
        public string student_code { get; set; }
        public string parent_code { get; set; }
        public string student_account { get; set; }
        public string custodian_name { get; set; }

        public string father_name { get; set; }
        public string mother_name { get; set; }

        public string class_name { get; set; }
        public string grade_year { get; set; }
        public string parent_account { get; set; }
        public string relationship { get; set; }


    }
}
