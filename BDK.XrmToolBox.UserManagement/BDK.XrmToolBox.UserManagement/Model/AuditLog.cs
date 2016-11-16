using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDK.XrmToolBox.UserManagement.Model
{
    public class AuditUserLogin
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string LoginDate { get; set; }

        public string LoginTime { get; set; }
    }

    public class AuditTransaction
    {
        public string Id { get; set; }

        public string EntityName { get; set; }

        public string Record { get; set; }

        public string Date { get; set; }

        public string Operation { get; set; }
    }
}
