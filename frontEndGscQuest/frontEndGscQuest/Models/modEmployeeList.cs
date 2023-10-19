using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace frontEndGscQuest.Models
{
    public class modEmployeeList
    {
        public string imp_id { get; set; }
        public string imp_firstName { get; set; }
        public string imp_lastName { get; set; }
        public string imp_username { get; set; }
        public string imp_password { get; set; }
        public string imp_account_status { get; set; }
    }

    public class HomeModel
    {
        public IEnumerable<modEmployeeList> EmployeeList { get; set; }
    }

}