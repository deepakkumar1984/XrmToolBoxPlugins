using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDK.XrmToolBox.UserManagement.Model
{
    public class CRMUser
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Title { get; set; }

        public string PrimaryEmail { get; set; }

        public string BusinessUnit { get; set; }

        public DateTime LastLoggedIn { get; set; }
    }
}
