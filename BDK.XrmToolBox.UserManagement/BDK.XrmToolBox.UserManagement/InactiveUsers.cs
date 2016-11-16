using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using BDK.XrmToolBox.UserManagement.Model;
using DocumentFormat.OpenXml.Packaging;

namespace BDK.XrmToolBox.UserManagement
{
    public partial class InactiveUsers : Form
    {
        public InactiveUsers()
        {
            InitializeComponent();
        }

        public InactiveUsers(IOrganizationService service)
        {
            InitializeComponent();
            this.showInactiveUsers1.OrgService = service;
        }
    }
}
