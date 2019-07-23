/*
MIT License

Copyright (c) 2019 Tech Quantum

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */

namespace BDK.XrmToolBox.RecycleBin.Model
{
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk.Metadata;
    using System;

    /// <summary>
    /// Instance of audit item entry
    /// </summary>
    internal class AuditItem
    {
        /// <summary>
        /// Gets or sets the audit identifier.
        /// </summary>
        /// <value>
        /// The audit identifier.
        /// </value>
        public Guid AuditId { get; set; }

        /// <summary>
        /// Gets or sets the record identifier.
        /// </summary>
        /// <value>
        /// The record identifier.
        /// </value>
        public Guid RecordId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public string Entity { get; set; }

        /// <summary>
        /// Gets or sets the metadata.
        /// </summary>
        /// <value>
        /// The metadata.
        /// </value>
        public EntityMetadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets the deletion date.
        /// </summary>
        /// <value>
        /// The deletion date.
        /// </value>
        public DateTime DeletionDate { get; set; }

        /// <summary>
        /// Gets or sets the deleted by date in string format.
        /// </summary>
        /// <value>
        /// The deleted by.
        /// </value>
        public string DeletedBy { get; set; }

        /// <summary>
        /// Gets or sets the audit detail.
        /// </summary>
        /// <value>
        /// The audit detail.
        /// </value>
        public AttributeAuditDetail AuditDetail { get; set; }
    }
}
