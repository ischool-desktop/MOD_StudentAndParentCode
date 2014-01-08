using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace K12Code.Management.Module
{
    class stud
    {
        public string ClassName { get; set; }
        public string SeatNo { get; set; }
        public string Name { get; set; }
        public string StudentNumber { get; set; }

        public stud(DataRow row)
        {
            ClassName = "" + row["class_name"];
            SeatNo = "" + row["seat_no"];
            Name = "" + row["name"];
            StudentNumber = "" + row["student_number"];
        }
    }
}
