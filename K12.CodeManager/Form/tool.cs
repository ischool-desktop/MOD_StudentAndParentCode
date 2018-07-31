using FISCA.Data;
using FISCA.UDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K12Code.Management.Module
{
    static public class tool
    {
        static public AccessHelper _A = new AccessHelper();
        static public QueryHelper _Q = new QueryHelper();
        static public K12.Data.UpdateHelper _U = new K12.Data.UpdateHelper();
    }
}
