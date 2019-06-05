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
using BDK.XrmToolBox.UserAuditViewer.Model;
using DocumentFormat.OpenXml.Packaging;
using XrmToolBox.Extensibility.Interfaces;

namespace BDK.XrmToolBox.UserAuditViewer
{
    public partial class PluginControl : PluginControlBase, IGitHubPlugin, IPayPalPlugin
    {
        private int pageUserLogin = 1;
        private int pageUserTransaction = 1;

        private string pageCookieUserLogin = "";
        private string pageCookieUserTransaction = "";

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelWorker();
            MessageBox.Show("Cancelled");
        }

        private void btnLoadViews_Click(object sender, EventArgs e)
        {
            if (Service == null)
            {
                ExecuteMethod(WhoAmI);
                return;
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving user views...",
                Work = (w, ev) =>
                {
                    FetchExpression query = new FetchExpression(Settings.FetchXml_UserViews);

                    EntityCollection entitites = Service.RetrieveMultiple(query);
                    
                    ev.Result = entitites;
                },
                ProgressChanged = ev =>
                {
                    // If progress has to be notified to user, use the following method:
                    SetWorkingMessage("Message to display");
                },
                PostWorkCallBack = ev =>
                {
                    EntityCollection result = ev.Result as EntityCollection;
                    List<Tuple<Guid, string, string>> dataSource = new List<Tuple<Guid, string, string>>();
                    foreach (var item in result.Entities)
                    {
                        dataSource.Add(new Tuple<Guid, string, string>(item.Id, item.Attributes["name"].ToString(), item.Attributes["isdefault"].ToString()));
                    }

                    ddluserViews.DataSource = dataSource;

                    ddluserViews.DisplayMember = "Item2";
                    ddluserViews.ValueMember = "Item1";
                },
                AsyncArgument = null,
                IsCancelable = true,
                MessageWidth = 340,
                MessageHeight = 150
            });
        }

        private void listUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listUsers.SelectedItem == null)
                return;

            pageUserLogin = 1;
            pageUserTransaction = 1;
            pageCookieUserLogin = "";
            pageCookieUserTransaction = "";

            BuildUserLoginGrid();
            BuildUserTransactionGrid();
        }

        private void BuildUserTransactionGrid()
        {
            string selectedUserId = ((CRMUser)listUsers.SelectedItem).Id;
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving user transaction history...",
                Work = (w, ev) =>
                {
                    FetchExpression query = new FetchExpression(string.Format(Settings.FetchXml_UserTransactions, selectedUserId, pageUserTransaction, pageCookieUserTransaction));
                    EntityCollection entitites = Service.RetrieveMultiple(query);
                    ev.Result = entitites;
                    pageCookieUserTransaction = entitites.PagingCookie.Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "'");
                },
                ProgressChanged = ev =>
                {
                    // If progress has to be notified to user, use the following method:
                    SetWorkingMessage("Retrieving user transaction history...");
                },
                PostWorkCallBack = ev =>
                {
                    try
                    {
                        EntityCollection result = ev.Result as EntityCollection;
                        List<AuditTransaction> data = new List<Model.AuditTransaction>();
                        Parallel.ForEach(result.Entities, (item) =>
                        {

                            DateTime createdOn = (DateTime)item["createdon"];
                            data.Add(new Model.AuditTransaction()
                            {
                                Id = item.Id.ToString(),
                                Date = createdOn.ToString(),
                                EntityName = ((EntityReference)item["userid"]).Name,
                                Record = ((EntityReference)item["objectid"]).Name,
                                Operation = ((AuditAction)((OptionSetValue)item["action"]).Value).ToString()
                            });

                        });

                        gridUserTransactions.DataSource = data.OrderByDescending(x => (x.Date)).ToList();
                    }
                    catch { }
                },
                AsyncArgument = null,
                IsCancelable = true,
                MessageWidth = 340,
                MessageHeight = 150
            });
        }

        private void BuildUserLoginGrid()
        {
            string selectedUserId = ((CRMUser)listUsers.SelectedItem).Id;
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving user login history...",
                Work = (w, ev) =>
                {
                    FetchExpression query = new FetchExpression(string.Format(Settings.FetchXml_UserLogin, selectedUserId, pageUserLogin, pageCookieUserLogin));

                    EntityCollection entitites = Service.RetrieveMultiple(query);

                    ev.Result = entitites;
                    pageCookieUserLogin = entitites.PagingCookie.Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "'"); ;
                },
                ProgressChanged = ev =>
                {
                    // If progress has to be notified to user, use the following method:
                    SetWorkingMessage("Retrieving user login history...");
                },
                PostWorkCallBack = ev =>
                {
                    try
                    {
                        EntityCollection result = ev.Result as EntityCollection;
                        List<AuditUserLogin> data = new List<Model.AuditUserLogin>();
                        Parallel.ForEach(result.Entities, (item) =>
                        {

                            DateTime createdOn = (DateTime)item["createdon"];
                            data.Add(new Model.AuditUserLogin()
                            {
                                Id = item.Id.ToString(),
                                Name = ((EntityReference)item["objectid"]).Name,
                                LoginDateTime = createdOn,
                                LoginDate = createdOn.ToShortDateString(),
                                LoginTime = createdOn.ToShortTimeString()
                            });

                        });

                        gridLoginHistory.DataSource = data.OrderByDescending(x => (x.LoginDateTime)).ToList();
                    }
                    catch { }
                },
                AsyncArgument = null,
                IsCancelable = true,
                MessageWidth = 340,
                MessageHeight = 150
            });
        }

        private void ddluserViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid selectedView = ((Tuple<Guid, string, string>)ddluserViews.SelectedItem).Item1;
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving users...",
                Work = (w, ev) =>
                {
                    Entity viewEntity = Service.Retrieve("savedquery", selectedView, new ColumnSet("fetchxml"));
                    FetchExpression fetchQuery = new FetchExpression(viewEntity["fetchxml"].ToString());
                    EntityCollection result = Service.RetrieveMultiple(fetchQuery);

                    ev.Result = result;
                },
                ProgressChanged = ev =>
                {
                    // If progress has to be notified to user, use the following method:
                    SetWorkingMessage("Retrieving users...");
                },
                PostWorkCallBack = ev =>
                {
                    EntityCollection result = ev.Result as EntityCollection;
                    List<CRMUser> data = new List<Model.CRMUser>();
                    //Parallel.ForEach(result.Entities, (item) => {
                    //    data.Add(new Model.CRMUser()
                    //    {
                    //        Username = item.Attributes.ContainsKey("domainname") ? item.Attributes["domainname"].ToString() : string.Empty,
                    //        Name = item.Attributes.ContainsKey("fullname") ? item.Attributes["fullname"].ToString() : string.Empty,
                    //        Id = item.Id.ToString()
                    //    });
                    //});
                    foreach (var item in result.Entities)
                    {
                        data.Add(new Model.CRMUser()
                        {
                            Username = item.Attributes.ContainsKey("domainname") ? item.Attributes["domainname"].ToString() : string.Empty,
                            Name = item.Attributes.ContainsKey("fullname") ? item.Attributes["fullname"].ToString() : string.Empty,
                            Id = item.Id.ToString()
                        });
                    }

                    listUsers.DataSource = data;
                },
                AsyncArgument = null,
                IsCancelable = true,
                MessageWidth = 340,
                MessageHeight = 150
            });
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void loginHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Service == null)
            {
                ExecuteMethod(WhoAmI);
                return;
            }

            DataSet ds = GetDataset(gridLoginHistory);
            DialogResult dialogResult = saveFile.ShowDialog();
            if (dialogResult.ToString() == "OK")
            {
                ExportDataSet(ds, saveFile.FileName);
            }
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Service == null)
            {
                ExecuteMethod(WhoAmI);
                return;
            }

            DataSet ds = GetDataset(gridUserTransactions);
            DialogResult dialogResult = saveFile.ShowDialog();
            if (dialogResult.ToString() == "OK")
            {
                ExportDataSet(ds, saveFile.FileName);
            }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Username");
            dt.Columns.Add("Title");
            dt.Columns.Add("PrimaryEmail");
            dt.Columns.Add("BusinessUnit");
            dt.Columns.Add("LastLoggedIn");

            List<CRMUser> users = (List<CRMUser>)listUsers.DataSource;
            foreach (var item in users)
            {
                DataRow row = dt.NewRow();
                row.ItemArray = new object[] { item.Name, item.Username, item.Title, item.PrimaryEmail, item.BusinessUnit, item.LastLoggedIn };
                dt.Rows.Add(row);
            }

            ds.Tables.Add(dt);

            DialogResult dialogResult = saveFile.ShowDialog();
            if (dialogResult.ToString() == "OK")
            {
                ExportDataSet(ds, saveFile.FileName);
            }
        }

        private void ExportDataSet(DataSet ds, string destination)
        {
            using (var workbook = SpreadsheetDocument.Create(destination, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = workbook.AddWorkbookPart();

                workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();

                workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();

                foreach (System.Data.DataTable table in ds.Tables)
                {

                    var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                    var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
                    sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);

                    DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                    string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                    uint sheetId = 1;
                    if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                    {
                        sheetId =
                            sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                    }

                    DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = table.TableName };
                    sheets.Append(sheet);

                    DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                    List<String> columns = new List<string>();
                    foreach (System.Data.DataColumn column in table.Columns)
                    {
                        columns.Add(column.ColumnName);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);
                        headerRow.AppendChild(cell);
                    }


                    sheetData.AppendChild(headerRow);

                    foreach (System.Data.DataRow dsrow in table.Rows)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                        foreach (String col in columns)
                        {
                            DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString()); //
                            newRow.AppendChild(cell);
                        }

                        sheetData.AppendChild(newRow);
                    }

                }
            }
        }

        private DataSet GetDataset(DataGridView gridView)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            // add the columns to the datatable            
            if (gridView.Columns != null)
            {

                for (int i = 0; i < gridView.Columns.Count; i++)
                {
                    dt.Columns.Add(gridView.Columns[i].DataPropertyName);
                }
            }

            //  add each of the data rows to the table
            foreach (DataGridViewRow row in gridView.Rows)
            {
                DataRow dr;
                dr = dt.NewRow();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dr[i] = row.Cells[i].Value;
                }

                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);
            return ds;
        }

        private void menuInactiveUsers_Click(object sender, EventArgs e)
        {
            if (Service == null)
            {
                ExecuteMethod(WhoAmI);
                return;
            }
            InactiveUsers form = new InactiveUsers(this.Service);
            form.ShowDialog();
        }

        private void PluginControl_Load(object sender, EventArgs e)
        {
            ExecuteMethod(WhoAmI);
        }

        private void WhoAmI()
        {
            Service.Execute(new WhoAmIRequest());
        }

        private void btnNextUserLogin_Click(object sender, EventArgs e)
        {
            pageUserLogin++;
            BuildUserLoginGrid();
        }

        private void btnPrevUserLogin_Click(object sender, EventArgs e)
        {
            if (pageUserLogin > 1)
            {
                pageUserLogin--;
                BuildUserLoginGrid();
            }
        }

        private void btnPrevUserTran_Click(object sender, EventArgs e)
        {
            pageUserTransaction++;
            BuildUserTransactionGrid();
        }

        private void btnNextUserTran_Click(object sender, EventArgs e)
        {
            if (pageUserTransaction > 1)
            {
                pageUserTransaction--;
                BuildUserTransactionGrid();
            }
        }
    }
}
