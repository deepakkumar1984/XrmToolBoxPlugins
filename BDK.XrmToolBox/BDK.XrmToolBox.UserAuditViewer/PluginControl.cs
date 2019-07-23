

namespace BDK.XrmToolBox.UserAuditViewer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using BDK.XrmToolBox.UserAuditViewer.Model;
    using DocumentFormat.OpenXml.Packaging;
    using global::XrmToolBox.Extensibility;
    using global::XrmToolBox.Extensibility.Interfaces;

    public partial class PluginControl : PluginControlBase, IGitHubPlugin, IPayPalPlugin
    {
        #region Private members
        /// <summary>
        /// The page user login
        /// </summary>
        private int pageUserLogin = 1;
        /// <summary>
        /// The page user transaction
        /// </summary>
        private int pageUserTransaction = 1;

        /// <summary>
        /// The page cookie user login
        /// </summary>
        private string pageCookieUserLogin = "";
        /// <summary>
        /// The page cookie user transaction
        /// </summary>
        private string pageCookieUserTransaction = "";
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
        }
        #endregion

        #region Event handling
        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelWorker();
            MessageBox.Show("Cancelled");
        }

        /// <summary>
        /// Handles the Click event of the btnLoadViews control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the SelectedIndexChanged event of the listUsers control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ddluserViews control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the loginHistoryToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the transactionToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the usersToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the menuInactiveUsers control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Load event of the PluginControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PluginControl_Load(object sender, EventArgs e)
        {
            ExecuteMethod(WhoAmI);
        }

        /// <summary>
        /// Handles the Click event of the btnNextUserLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnNextUserLogin_Click(object sender, EventArgs e)
        {
            pageUserLogin++;
            BuildUserLoginGrid();
        }

        /// <summary>
        /// Handles the Click event of the btnPrevUserLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnPrevUserLogin_Click(object sender, EventArgs e)
        {
            if (pageUserLogin > 1)
            {
                pageUserLogin--;
                BuildUserLoginGrid();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnPrevUserTran control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnPrevUserTran_Click(object sender, EventArgs e)
        {
            pageUserTransaction++;
            BuildUserTransactionGrid();
        }

        /// <summary>
        /// Handles the Click event of the btnNextUserTran control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnNextUserTran_Click(object sender, EventArgs e)
        {
            if (pageUserTransaction > 1)
            {
                pageUserTransaction--;
                BuildUserTransactionGrid();
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Builds the user transaction grid.
        /// </summary>
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

        /// <summary>
        /// Builds the user login grid.
        /// </summary>
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
                        foreach (var item in result.Entities)
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
                        }

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

        /// <summary>
        /// Exports the data set.
        /// </summary>
        /// <param name="ds">The ds.</param>
        /// <param name="destination">The destination.</param>
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

        /// <summary>
        /// Gets the dataset.
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Whoes the am i.
        /// </summary>
        private void WhoAmI()
        {
            Service.Execute(new WhoAmIRequest());
        }

        #endregion
    }
}
