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

namespace BDK.XrmToolBox.StorageCleaner
{
    using System;
    using System.Windows.Forms;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using global::XrmToolBox.Extensibility;
    using global::XrmToolBox.Extensibility.Interfaces;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PluginControlBase" />
    /// <seealso cref="IGitHubPlugin" />
    /// <seealso cref="IPayPalPlugin" />
    public partial class PluginControl : PluginControlBase, IGitHubPlugin, IPayPalPlugin
    {
        #region Public Properties
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
            menuBulkDelete.Enabled = false;
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
        /// Handles the Click event of the menuRefresh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void menuRefresh_Click(object sender, EventArgs e)
        {
            if (Service == null)
            {
                ExecuteMethod(WhoAmI);
                return;
            }

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

            menuBulkDelete.Enabled = true;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ddlFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            menuBulkDelete.Enabled = false;
        }

        /// <summary>
        /// Handles the TextChanged event of the txtAttachmentSize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtAttachmentSize_TextChanged(object sender, EventArgs e)
        {
            menuBulkDelete.Enabled = false;
        }

        /// <summary>
        /// Handles the Click event of the menuBulkDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void menuBulkDelete_Click(object sender, EventArgs e)
        {
            if (Service == null)
            {
                ExecuteMethod(WhoAmI);
                return;
            }

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

        /// <summary>
        /// Creates the bulk delete.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="jobName">Name of the job.</param>
        private void CreateBulkDelete(QueryExpression query, string jobName)
        {
            if (Service == null)
            {
                ExecuteMethod(WhoAmI);
                return;
            }

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

        /// <summary>
        /// Handles the Load event of the PluginControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PluginControl_Load(object sender, EventArgs e)
        {
            ExecuteMethod(WhoAmI);
        }
        #endregion

        #region Private method
        /// <summary>
        /// Invokes the count.
        /// </summary>
        /// <param name="olderThan">The older than.</param>
        /// <param name="fetchXml">The fetch XML.</param>
        /// <param name="message">The message.</param>
        /// <param name="lbl">The label.</param>
        /// <param name="attachmentSize">Size of the attachment.</param>
        private void InvokeCount(int olderThan, string fetchXml, string message, System.Windows.Forms.Label lbl, int attachmentSize = -1)
        {
            if (Service == null)
            {
                ExecuteMethod(WhoAmI);
                return;
            }

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

        /// <summary>
        /// Gets the query expression.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
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
                default:
                    break;
            }

            return query;
        }

        /// <summary>
        /// Check the CRM Connection
        /// </summary>
        private void WhoAmI()
        {
            Service.Execute(new WhoAmIRequest());
        }
        #endregion
    }
}
