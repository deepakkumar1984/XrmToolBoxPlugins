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
using XrmToolBox.Extensibility.Interfaces;

namespace BDK.XrmToolBox.StorageCleaner
{
    public partial class PluginControl : PluginControlBase, IGitHubPlugin, IPayPalPlugin
    {
        private bool readyToDelete = false;

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
            menuBulkDelete.Enabled = false;
        }

        private void menuClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void menuRefresh_Click(object sender, EventArgs e)
        {
            menuBulkDelete.Enabled = false;
            int olderThan = 0;

            if (ddlFilter.SelectedIndex == 0)
            {
                olderThan = 1;
            }
            else if (ddlFilter.SelectedIndex == 1)
            {
                olderThan = 3;
            }
            else if (ddlFilter.SelectedIndex == 2)
            {
                olderThan = 6;
            }
            else if (ddlFilter.SelectedIndex == 3)
            {
                olderThan = 12;
            }
            else if (ddlFilter.SelectedIndex == 4)
            {
                olderThan = 36;
            }
            else
            {
                MessageBox.Show("Please select data older than to continue");
                return;
            }

            int fileSize = 0;
            if (!string.IsNullOrWhiteSpace(txtAttachmentSize.Text))
            {
                if (!Int32.TryParse(txtAttachmentSize.Text.Trim(), out fileSize))
                {
                    MessageBox.Show("Enter valid attachment size in KB");
                    return;
                }

                fileSize = fileSize * 1024;
            }

            if(chkBulkEmailWorkflow.Checked)
                InvokeCount(olderThan, Settings.FetchXml_BulkEmailAndWorkflow, "Counting bulk email and workflow....", lblBulkEmailWorkflow);

            if (chkSuspendedJobs.Checked)
                InvokeCount(olderThan, Settings.FetchXml_SuspendedWorkflow, "Counting suspended workflows....", lblSuspendedWf);

            if (chkEmailAtachments.Checked)
                InvokeCount(olderThan, Settings.FetchXml_EmailWithAttachements, "Counting emails with attachment....", lblEmailAttachment, fileSize);

            if (chkNotesAttachments.Checked)
                InvokeCount(olderThan, Settings.FetchXml_NotesWithAttachments, "Counting notes with attachment....", lblNotesWithAttachments, fileSize);

            if (chkBulkImportJobs.Checked)
                InvokeCount(olderThan, Settings.FetchXml_BulkImport, "Counting bulk import jobs....", lblBulkImports);

            if (chkBulkDeleteLogs.Checked)
                InvokeCount(olderThan, Settings.FetchXml_BulkDelete, "Counting bulk delete jobs....", lblBulkDeletes);

            if (chkAuditLogs.Checked)
                InvokeCount(olderThan, Settings.FetchXml_Audit, "Counting audit logs....", lblAuditLogs);

            menuBulkDelete.Enabled = true;
        }

        private void InvokeCount(int olderThan, string fetchXml, string message, System.Windows.Forms.Label lbl, int attachmentSize = -1)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = message,
                Work = (w, ev) =>
                {
                    int recordCount = 0;
                    int page = 1;
                    bool moreRecord = true;
                    string pageInfo = string.Empty;

                    while (moreRecord)
                    {
                        FetchExpression query = null;
                        if(attachmentSize == -1)
                            query = new FetchExpression(string.Format(fetchXml, olderThan, pageInfo));
                        else
                            query = new FetchExpression(string.Format(fetchXml, olderThan, attachmentSize, pageInfo));

                        EntityCollection queryResult = Service.RetrieveMultiple(query);
                        page++;
                        pageInfo = string.Format("page=\"{0}\" paging-cookie=\"{1}\"", page, queryResult.PagingCookie.Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;"));
                        moreRecord = queryResult.MoreRecords;
                        recordCount += queryResult.Entities.Count;
                    }

                    ev.Result = recordCount;
                },
                ProgressChanged = ev =>
                {
                    // If progress has to be notified to user, use the following method:
                    SetWorkingMessage(message);
                },
                PostWorkCallBack = ev =>
                {
                    lbl.Text = ev.Result.ToString() + " records";
                },
                AsyncArgument = null,
                IsCancelable = true,
                MessageWidth = 340,
                MessageHeight = 150
            });
        }

        private QueryExpression GetQueryExpression(string type)
        {
            QueryExpression query = new QueryExpression();

            int olderThan = 0;
            if (ddlFilter.SelectedIndex == 0)
            {
                olderThan = 1;
            }
            else if (ddlFilter.SelectedIndex == 1)
            {
                olderThan = 3;
            }
            else if (ddlFilter.SelectedIndex == 2)
            {
                olderThan = 6;
            }
            else if (ddlFilter.SelectedIndex == 3)
            {
                olderThan = 12;
            }
            else if (ddlFilter.SelectedIndex == 4)
            {
                olderThan = 36;
            }
            else
            {
                MessageBox.Show("Please select data older than to continue");
                return null;
            }

            int fileSize = 0;
            if (!string.IsNullOrWhiteSpace(txtAttachmentSize.Text))
            {
                if (!Int32.TryParse(txtAttachmentSize.Text.Trim(), out fileSize))
                {
                    MessageBox.Show("Enter valid attachment size in KB");
                    return null;
                }

                fileSize = fileSize * 1024;
            }

            switch (type)
            {
                case "BULKEMAILWORKFLOW":
                    query.EntityName = "asyncoperation";
                    query.Criteria = new FilterExpression(LogicalOperator.And);
                    query.Criteria.AddCondition("operationtype", ConditionOperator.In, 2, 10);
                    query.Criteria.AddCondition("statuscode", ConditionOperator.Equal, 30);
                    query.Criteria.AddCondition("completedon", ConditionOperator.OlderThanXMonths, olderThan);
                    break;
                case "SUSPENDEDJOBS":
                    query.EntityName = "asyncoperation";
                    query.Criteria = new FilterExpression(LogicalOperator.And);
                    query.Criteria.AddCondition("operationtype", ConditionOperator.Equal, 10);
                    query.Criteria.AddCondition("statuscode", ConditionOperator.Equal, 10);
                    query.Criteria.AddCondition("completedon", ConditionOperator.OlderThanXMonths, olderThan);
                    break;
                case "EMAILS":
                    query.EntityName = "email";
                    query.Criteria = new FilterExpression(LogicalOperator.And);
                    query.Criteria.AddCondition("createdon", ConditionOperator.OlderThanXMonths, olderThan);
                    query.AddLink("activitymimeattachment", "activityid", "objectid");
                    query.LinkEntities[0].LinkCriteria = new FilterExpression(LogicalOperator.And);
                    query.LinkEntities[0].LinkCriteria.AddCondition("filesize", ConditionOperator.GreaterThan, fileSize);
                    break;
                case "NOTES":
                    query.EntityName = "annotation";
                    query.Criteria = new FilterExpression(LogicalOperator.And);
                    query.Criteria.AddCondition("createdon", ConditionOperator.OlderThanXMonths, olderThan);
                    query.Criteria.AddCondition("filesize", ConditionOperator.GreaterThan, fileSize);
                    break;
                case "BULKIMPORT":
                    query.EntityName = "asyncoperation";
                    query.Criteria = new FilterExpression(LogicalOperator.And);
                    query.Criteria.AddCondition("operationtype", ConditionOperator.Equal, 5);
                    query.Criteria.AddCondition("statuscode", ConditionOperator.Equal, 30);
                    query.Criteria.AddCondition("completedon", ConditionOperator.OlderThanXMonths, olderThan);
                    break;
                case "BULKDELETE":
                    query.EntityName = "asyncoperation";
                    query.Criteria = new FilterExpression(LogicalOperator.And);
                    query.Criteria.AddCondition("operationtype", ConditionOperator.Equal, 13);
                    query.Criteria.AddCondition("statuscode", ConditionOperator.Equal, 30);
                    query.Criteria.AddCondition("completedon", ConditionOperator.OlderThanXMonths, olderThan);
                    break;
                case "AUDIT":
                    break;
                default:
                    break;
            }

            return query;
        }

        private void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            menuBulkDelete.Enabled = false;
        }

        private void txtAttachmentSize_TextChanged(object sender, EventArgs e)
        {
            menuBulkDelete.Enabled = false;
        }

        private void menuBulkDelete_Click(object sender, EventArgs e)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Initiating bulk delete jobs in CRM..",
                Work = (w, ev) =>
                {
                    try
                    {
                        if (chkBulkEmailWorkflow.Checked)
                            CreateBulkDelete(GetQueryExpression("BULKEMAILWORKFLOW"), string.Format("Delete bulk email and workflow - {0}", DateTime.Now));

                        if (chkSuspendedJobs.Checked)
                            CreateBulkDelete(GetQueryExpression("SUSPENDEDJOBS"), string.Format("Delete suspended jobs - {0}", DateTime.Now));

                        if (chkEmailAtachments.Checked)
                            CreateBulkDelete(GetQueryExpression("EMAILS"), string.Format("Delete emails with attachment - {0}", DateTime.Now));

                        if (chkNotesAttachments.Checked)
                            CreateBulkDelete(GetQueryExpression("NOTES"), string.Format("Delete notes with attachment - {0}", DateTime.Now));

                        if (chkBulkImportJobs.Checked)
                            CreateBulkDelete(GetQueryExpression("BULKIMPORT"), string.Format("Delete bulk import jobs - {0}", DateTime.Now));

                        if (chkBulkDeleteLogs.Checked)
                            CreateBulkDelete(GetQueryExpression("BULKDELETE"), string.Format("Delete bulk delete jobs - {0}", DateTime.Now));

                        if (chkAuditLogs.Checked)
                            CreateBulkDelete(GetQueryExpression("AUDIT"), string.Format("Delete audit logs - {0}", DateTime.Now));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                },
                ProgressChanged = ev =>
                {
                    // If progress has to be notified to user, use the following method:
                    SetWorkingMessage("Initiating bulk delete jobs in CRM..");
                },
                PostWorkCallBack = ev =>
                {
                    MessageBox.Show("Bulk delete jobs initiated. Please check in CRM for the status!");
                },
                AsyncArgument = null,
                IsCancelable = true,
                MessageWidth = 340,
                MessageHeight = 150
            });

            
        }

        private void CreateBulkDelete(QueryExpression query, string jobName)
        {
            if (query == null)
                return;

            // Create the bulk delete request.
            var bulkDeleteRequest = new BulkDeleteRequest
            {
                JobName = jobName,

                QuerySet = new[] { query },
                StartDateTime = DateTime.Now.AddMinutes(2),
                SendEmailNotification = false,
                ToRecipients = new Guid[] { },
                CCRecipients = new Guid[] { },
                RecurrencePattern = String.Empty
            };

            var bulkDeleteResponse =
                (BulkDeleteResponse)Service.Execute(bulkDeleteRequest);
        }
    }
}
