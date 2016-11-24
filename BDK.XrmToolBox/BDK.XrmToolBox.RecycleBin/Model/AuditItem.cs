using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDK.XrmToolBox.RecycleBin.Model
{
    internal class AuditItem
    {
        public Guid AuditId { get; set; }

        public Guid RecordId { get; set; }

        public string Name { get; set; }

        public string Entity { get; set; }

        public EntityMetadata Metadata { get; set; }

        public DateTime DeletionDate { get; set; }

        public string DeletedBy { get; set; }

        public AttributeAuditDetail AuditDetail { get; set; }
    }
}
