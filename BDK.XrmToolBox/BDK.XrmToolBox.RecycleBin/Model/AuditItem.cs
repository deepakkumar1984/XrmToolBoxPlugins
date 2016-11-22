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

        public DateTime DeletionDate { get; set; }

        public string DeletedBy { get; set; }
    }
}
