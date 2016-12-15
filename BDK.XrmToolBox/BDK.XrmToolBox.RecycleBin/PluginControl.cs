using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using XrmToolBox.Extensibility.Interfaces;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using BDK.XrmToolBox.RecycleBin.Model;

namespace BDK.XrmToolBox.RecycleBin
{
    public partial class PluginControl : PluginControlBase, IGitHubPlugin, IPayPalPlugin
    {
        private List<EntityMetadata> entityMetadataList;

        public string RepositoryName
        {
            get
            {
                return "XrmToolBoxPlugins";
            }
        }

        public string UserName
        {
            get
            {
                return "deepakkumar1984";
            }
        }

        public string DonationDescription
        {
            get
            {
                return "Please help us improve this tool!";
            }
        }

        public string EmailAccount
        {
            get
            {
                return "support@appshap.com";
            }
        }

        public PluginControl()
        {
            InitializeComponent();
            dateFrom.Value = DateTime.Now.AddMonths(-1);
            dateTo.Value = DateTime.Now;
            entityMetadataList = new List<EntityMetadata>();
        }

        private void menuClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

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

                            if (selectedEntity.Item3!=null && attributeDetail.OldValue.Contains(selectedEntity.Item3))
                            {
                                auditItem.Name = attributeDetail.OldValue[selectedEntity.Item3].ToString();
                            }

                            data.Add(auditItem);
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

        private void menuLoadEntities_Click(object sender, EventArgs e)
        {
            List<Tuple<int, string, string>> data = new List<Tuple<int, string, string>>();
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
    }
}
