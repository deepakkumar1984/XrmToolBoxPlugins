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

namespace BDK.XrmToolBox.RecycleBin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using Microsoft.Xrm.Sdk.Messages;
    using Microsoft.Xrm.Sdk.Metadata;
    using BDK.XrmToolBox.RecycleBin.Model;
    using McTools.Xrm.Connection;
    using global::XrmToolBox.Extensibility;
    using global::XrmToolBox.Extensibility.Interfaces;

    public partial class PluginControl : PluginControlBase, IGitHubPlugin, IPayPalPlugin
    {
        #region Private fields
        /// <summary>
        /// The entity metadata list
        /// </summary>
        private List<EntityMetadata> entityMetadataList;
        #endregion

        #region Public properties
        /// <summary>
        /// Gets the name of the repository.
        /// </summary>
        /// <value>
        /// The name of the repository.
        /// </value>
        public string RepositoryName
        {
            get
            {
                return "XrmToolBoxPlugins";
            }
        }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName
        {
            get
            {
                return "tech-quantum";
            }
        }

        /// <summary>
        /// Gets the donation description.
        /// </summary>
        /// <value>
        /// The donation description.
        /// </value>
        public string DonationDescription
        {
            get
            {
                return "Please help us improve this tool!";
            }
        }

        /// <summary>
        /// Gets the email account.
        /// </summary>
        /// <value>
        /// The email account.
        /// </value>
        public string EmailAccount
        {
            get
            {
                return "deepak.battini@siadroid.com";
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PluginControl"/> class.
        /// </summary>
        public PluginControl()
        {
            InitializeComponent();
            dateFrom.Value = DateTime.Now.AddMonths(-1);
            dateTo.Value = DateTime.Now;
            entityMetadataList = new List<EntityMetadata>();
        }
        #endregion

        #region Event Handling
                /// <summary>
        /// Handles the Click event of the menuClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void menuClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        /// <summary>
        /// Handles the Click event of the btnShowRecords control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnShowRecords_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Loading deleted records...",
                    Work = (w, ev) =>
                    {
                        Guid selectedUser = (Guid)ddlUsers.SelectedValue;
                        List<AuditItem> data = new List<Model.AuditItem>();
                        FetchExpression query = null;
                        Tuple<int, string, string> selectedEntity = (Tuple<int, string, string>)ddlEntities.SelectedItem;
                        string auditFetchXml;
                        if (selectedUser == Guid.Empty)
                        {
                            auditFetchXml = string.Format(ConnectionDetail.OrganizationMajorVersion < 8 ? 
                                FetchXml.DeletedAuditLogs.Replace("regardingobject", "object") : 
                                FetchXml.DeletedAuditLogs, 
                                dateFrom.Value.ToString("yyyy-MM-dd"), 
                                dateTo.Value.AddDays(1).ToString("yyyy-MM-dd"), 
                                ddlEntities.SelectedValue);
                        }
                        else
                        {
                            auditFetchXml = string.Format(ConnectionDetail.OrganizationMajorVersion < 8 ?
                                FetchXml.DeleteAuditLogsByUser.Replace("regardingobject", "object") :
                                FetchXml.DeleteAuditLogsByUser, 
                                dateFrom.Value.ToString("yyyy-MM-dd"),
                                dateTo.Value.AddDays(1).ToString("yyyy-MM-dd"),
                                ddlEntities.SelectedValue,
                                selectedUser);
                        }
                        query = new FetchExpression(auditFetchXml);                        
                        var queryResult = Service.RetrieveMultiple(query);
                        foreach (Entity item in queryResult.Entities)
                        {
                            RetrieveAuditDetailsRequest auditDetailRequest = new RetrieveAuditDetailsRequest();
                            auditDetailRequest.AuditId = item.Id;
                            RetrieveAuditDetailsResponse response = (RetrieveAuditDetailsResponse)Service.Execute(auditDetailRequest);

                            var detailType = response.AuditDetail.GetType();
                            if (detailType == typeof(AttributeAuditDetail))
                            {
                                AttributeAuditDetail attributeDetail = (AttributeAuditDetail)response.AuditDetail;
                                EntityMetadata metadata = entityMetadataList.FirstOrDefault(x => (x.ObjectTypeCode == selectedEntity.Item1));
                                AuditItem auditItem = new Model.AuditItem()
                                {
                                    AuditId = item.Id,
                                    DeletedBy = ((EntityReference)item["userid"]).Name,
                                    DeletionDate = (DateTime)item["createdon"],
                                    Entity = ((EntityReference)item["objectid"]).LogicalName,
                                    RecordId = ((EntityReference)item["objectid"]).Id,
                                    AuditDetail = attributeDetail,
                                    Metadata = metadata
                                };

                                if (selectedEntity.Item3 != null && attributeDetail.OldValue.Contains(selectedEntity.Item3))
                                {
                                    auditItem.Name = attributeDetail.OldValue[selectedEntity.Item3].ToString();
                                }

                                data.Add(auditItem);

                            }
                        }

                        ev.Result = data.OrderByDescending(x => x.DeletionDate).ToList();
                    },
                    ProgressChanged = ev =>
                    {
                        // If progress has to be notified to user, use the following method:
                        SetWorkingMessage("Loading entities with auditing enabled...");
                    },
                    PostWorkCallBack = ev =>
                    {
                        GridDeletedRecords.DataSource = ev.Result;
                    },
                    AsyncArgument = null,
                    IsCancelable = true,
                    MessageWidth = 340,
                    MessageHeight = 150
                });

            }
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        private bool IsValid()
        {
            bool result = true;

            if (ddlEntities.SelectedIndex == -1)
            {
                result = false;
                MessageBox.Show("Select entity from the list");
            }

            if (ddlUsers.SelectedIndex == -1)
            {
                result = false;
                MessageBox.Show("Select user from the list");
            }

            if (dateFrom.Value > dateTo.Value)
            {
                result = false;
                MessageBox.Show("From date should be less than to date");
            }

            return result;
        }

        /// <summary>
        /// Handles the Click event of the menuLoadEntities control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void menuLoadEntities_Click(object sender, EventArgs e)
        {
            List<Tuple<int, string, string>> data = new List<Tuple<int, string, string>>();

            ExecuteMethod(WhoAmI);

            if (Service==null)
            {
                return;
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading entities with auditing enabled...",
                Work = (w, ev) =>
                {
                    RetrieveAllEntitiesRequest metaDataRequest = new RetrieveAllEntitiesRequest();
                    metaDataRequest.EntityFilters = EntityFilters.Attributes;

                    var metaDataResponse = (RetrieveAllEntitiesResponse)Service.Execute(metaDataRequest);

                    var entities = metaDataResponse.EntityMetadata;
                    foreach (var item in entities)
                    {
                        if (item.IsAuditEnabled.Value)
                        {
                            data.Add(new Tuple<int, string, string>(item.ObjectTypeCode.Value, item.DisplayName.UserLocalizedLabel.Label, item.PrimaryNameAttribute));
                            entityMetadataList.Add(item);
                        }
                    }

                    ev.Result = data.OrderBy(x=>(x.Item2)).ToList();
                },
                ProgressChanged = ev =>
                {
                    // If progress has to be notified to user, use the following method:
                    SetWorkingMessage("Loading entities with auditing enabled...");
                },
                PostWorkCallBack = ev =>
                {
                    ddlEntities.DataSource = ev.Result;
                    ddlEntities.DisplayMember = "Item2";
                    ddlEntities.ValueMember = "Item1";
                },
                AsyncArgument = null,
                IsCancelable = true,
                MessageWidth = 340,
                MessageHeight = 150
            });

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading users...",
                Work = (w, ev) =>
                {
                    List<KeyValuePair<Guid, string>> users = new List<KeyValuePair<Guid, string>>();

                    FetchExpression query = new FetchExpression(FetchXml.LicencedUsers);
                    var queryResult = Service.RetrieveMultiple(query);
                    users.Add(new KeyValuePair<Guid, string>(Guid.Empty, "All Users"));
                    foreach (var item in queryResult.Entities)
                    {
                        users.Add(new KeyValuePair<Guid, string>(item.Id, item.Attributes["fullname"] != null ? item.Attributes["fullname"].ToString() : string.Empty));
                    }

                    ev.Result = users;
                },
                ProgressChanged = ev =>
                {
                    // If progress has to be notified to user, use the following method:
                    SetWorkingMessage("Loading users...");
                },
                PostWorkCallBack = ev =>
                {
                    ddlUsers.DataSource = (List<KeyValuePair<Guid, string>>)ev.Result;
                    ddlUsers.DisplayMember = "Value";
                    ddlUsers.ValueMember = "Key";
                },
                AsyncArgument = null,
                IsCancelable = true,
                MessageWidth = 340,
                MessageHeight = 150
            });
        }

        /// <summary>
        /// Handles the CellClick event of the GridDeletedRecords control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void GridDeletedRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                AuditItem audit = (AuditItem)GridDeletedRecords.Rows[e.RowIndex].DataBoundItem;
                ShowData(audit.AuditDetail, audit.Metadata);
            }
            else if (e.ColumnIndex == 0)
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)GridDeletedRecords.Rows[e.RowIndex].Cells[0];
                if (checkBoxCell.Value == null)
                {
                    checkBoxCell.Value = true;
                }
                else
                {
                    checkBoxCell.Value = !((bool)checkBoxCell.Value);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the menuRestore control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void menuRestore_Click(object sender, EventArgs e)
        {
            DialogResult diag = MessageBox.Show("Are you sure would like to restore these deleted records?", "Confirmation", MessageBoxButtons.YesNo);
            bool recordsSelected = false;
            string errorMessage = string.Empty;
            if (diag.ToString().ToUpperInvariant() == "YES")
            {
                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Restoring data...",
                    Work = (w, ev) =>
                    {
                        try
                        {
                            for (int i = 0; i < GridDeletedRecords.Rows.Count; i++)
                            {
                                DataGridViewRow row = GridDeletedRecords.Rows[i];
                                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)row.Cells[0];
                                if (checkBoxCell.Value != null && (bool)checkBoxCell.Value)
                                {
                                    recordsSelected = true;
                                    AuditItem audit = (AuditItem)row.DataBoundItem;
                                    Entity entity = audit.AuditDetail.OldValue;
                                    entity.Attributes.Remove("statecode");
                                    entity.Attributes.Remove("statuscode");
                                    Service.Create(entity);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            errorMessage = ex.Message;
                        }
                    },
                    ProgressChanged = ev =>
                    {
                        // If progress has to be notified to user, use the following method:
                        SetWorkingMessage("Restoring data...");
                    },
                    PostWorkCallBack = ev =>
                    {
                        if (string.IsNullOrWhiteSpace(errorMessage))
                        {
                            if (recordsSelected)
                                MessageBox.Show("Restored the deleted records successfully!");
                            else
                                MessageBox.Show("Please select records to restore!");
                        }
                        else
                        {
                            MessageBox.Show(errorMessage);
                        }
                    },
                    AsyncArgument = null,
                    IsCancelable = true,
                    MessageWidth = 340,
                    MessageHeight = 150
                });
            }

            
        }

        /// <summary>
        /// Handles the Load event of the PluginControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PluginControl_Load(object sender, EventArgs e)
        {
            if (Service == null)
            {
                ExecuteMethod(WhoAmI);
            }
        }

        /// <summary>
        /// Updates the connection.
        /// </summary>
        /// <param name="newService">The new service.</param>
        /// <param name="detail">The detail.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="parameter">The parameter.</param>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Shows the data.
        /// </summary>
        /// <param name="auditDetail">The audit detail.</param>
        /// <param name="metadata">The metadata.</param>
        private void ShowData(AttributeAuditDetail auditDetail, EntityMetadata metadata)
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

        private object GetFormattedValue(object input)
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

        /// <summary>
        /// Check the CRM connection
        /// </summary>
        private void WhoAmI()
        {
            Service.Execute(new WhoAmIRequest());
        }
        #endregion

    }
}
