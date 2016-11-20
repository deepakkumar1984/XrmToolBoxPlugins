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
        }

        private void menuClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void menuRefresh_Click(object sender, EventArgs e)
        {
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
    }
}
