using BDK.XrmToolBox.RecycleBin.Model;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDK.XrmToolBox.RecycleBin
{
    public partial class ShowDeletedInfo : Form
    {

        public ShowDeletedInfo()
        {
            InitializeComponent();
        }

        public void ShowData(AttributeAuditDetail auditDetail, EntityMetadata metadata)
        {
            List<DeletedField> result = new List<Model.DeletedField>();

            foreach (var item in auditDetail.OldValue.Attributes)
            {
                var metadataAttrib = metadata.Attributes.Where(x => (x.SchemaName.ToLower() == item.Key.ToLower())).ToList();
                if (metadataAttrib.Count > 0)
                {
                    result.Add(new DeletedField()
                    {
                        FieldName = metadataAttrib[0].DisplayName.UserLocalizedLabel.Label,
                        Value = GetFormattedValue(item.Value)
                    });
                }
            }

            GridDetails.DataSource = result;
        }

        public object GetFormattedValue(object input)
        {
            object result = input;

            if (input != null)
            {
                if (input.GetType() == typeof(EntityReference))
                {
                    result = ((EntityReference)input).Name;
                }
                else if (input.GetType() == typeof(OptionSetValue))
                {
                    result = ((OptionSetValue)input).Value;
                }
            }

            return result;
        }
    }
}
