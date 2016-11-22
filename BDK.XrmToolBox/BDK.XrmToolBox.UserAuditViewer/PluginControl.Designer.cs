namespace BDK.XrmToolBox.UserAuditViewer
{
    partial class PluginControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLoadViews = new System.Windows.Forms.ToolStripButton();
            this.menuInactiveUsers = new System.Windows.Forms.ToolStripButton();
            this.menuExport = new System.Windows.Forms.ToolStripSplitButton();
            this.loginHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ddluserViews = new System.Windows.Forms.ComboBox();
            this.listUsers = new System.Windows.Forms.ListBox();
            this.cRMUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLoginHistory = new System.Windows.Forms.TabPage();
            this.gridLoginHistory = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auditUserLoginBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabTransactions = new System.Windows.Forms.TabPage();
            this.gridUserTransactions = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auditTransactionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cRMUserBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabLoginHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLoginHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.auditUserLoginBindingSource)).BeginInit();
            this.tabTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUserTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.auditTransactionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.toolStripSeparator1,
            this.btnLoadViews,
            this.menuInactiveUsers,
            this.menuExport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1199, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::BDK.XrmToolBox.UserAuditViewer.Properties.Resources.Delete;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 22);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnLoadViews
            // 
            this.btnLoadViews.Image = global::BDK.XrmToolBox.UserAuditViewer.Properties.Resources.AssemblySelected;
            this.btnLoadViews.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadViews.Name = "btnLoadViews";
            this.btnLoadViews.Size = new System.Drawing.Size(86, 22);
            this.btnLoadViews.Text = "Load Views";
            this.btnLoadViews.Click += new System.EventHandler(this.btnLoadViews_Click);
            // 
            // menuInactiveUsers
            // 
            this.menuInactiveUsers.Image = global::BDK.XrmToolBox.UserAuditViewer.Properties.Resources.Organization;
            this.menuInactiveUsers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuInactiveUsers.Name = "menuInactiveUsers";
            this.menuInactiveUsers.Size = new System.Drawing.Size(99, 22);
            this.menuInactiveUsers.Text = "Inactive Users";
            this.menuInactiveUsers.Click += new System.EventHandler(this.menuInactiveUsers_Click);
            // 
            // menuExport
            // 
            this.menuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginHistoryToolStripMenuItem,
            this.transactionToolStripMenuItem});
            this.menuExport.Image = global::BDK.XrmToolBox.UserAuditViewer.Properties.Resources.UninstallProfiler;
            this.menuExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuExport.Name = "menuExport";
            this.menuExport.Size = new System.Drawing.Size(72, 22);
            this.menuExport.Text = "Export";
            // 
            // loginHistoryToolStripMenuItem
            // 
            this.loginHistoryToolStripMenuItem.Name = "loginHistoryToolStripMenuItem";
            this.loginHistoryToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.loginHistoryToolStripMenuItem.Text = "Login History";
            this.loginHistoryToolStripMenuItem.Click += new System.EventHandler(this.loginHistoryToolStripMenuItem_Click);
            // 
            // transactionToolStripMenuItem
            // 
            this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
            this.transactionToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.transactionToolStripMenuItem.Text = "Transaction";
            this.transactionToolStripMenuItem.Click += new System.EventHandler(this.transactionToolStripMenuItem_Click);
            // 
            // ddluserViews
            // 
            this.ddluserViews.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddluserViews.FormattingEnabled = true;
            this.ddluserViews.Location = new System.Drawing.Point(3, 28);
            this.ddluserViews.Name = "ddluserViews";
            this.ddluserViews.Size = new System.Drawing.Size(245, 21);
            this.ddluserViews.TabIndex = 1;
            this.ddluserViews.SelectedIndexChanged += new System.EventHandler(this.ddluserViews_SelectedIndexChanged);
            // 
            // listUsers
            // 
            this.listUsers.DataSource = this.cRMUserBindingSource;
            this.listUsers.DisplayMember = "Name";
            this.listUsers.FormattingEnabled = true;
            this.listUsers.Location = new System.Drawing.Point(3, 68);
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(245, 420);
            this.listUsers.TabIndex = 2;
            this.listUsers.ValueMember = "Id";
            this.listUsers.SelectedIndexChanged += new System.EventHandler(this.listUsers_SelectedIndexChanged);
            // 
            // cRMUserBindingSource
            // 
            this.cRMUserBindingSource.DataSource = typeof(BDK.XrmToolBox.UserAuditViewer.Model.CRMUser);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabLoginHistory);
            this.tabControl1.Controls.Add(this.tabTransactions);
            this.tabControl1.Location = new System.Drawing.Point(295, 68);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(901, 420);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // tabLoginHistory
            // 
            this.tabLoginHistory.Controls.Add(this.gridLoginHistory);
            this.tabLoginHistory.Location = new System.Drawing.Point(4, 22);
            this.tabLoginHistory.Name = "tabLoginHistory";
            this.tabLoginHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabLoginHistory.Size = new System.Drawing.Size(893, 394);
            this.tabLoginHistory.TabIndex = 0;
            this.tabLoginHistory.Text = "Login History";
            this.tabLoginHistory.UseVisualStyleBackColor = true;
            // 
            // gridLoginHistory
            // 
            this.gridLoginHistory.AllowUserToAddRows = false;
            this.gridLoginHistory.AllowUserToDeleteRows = false;
            this.gridLoginHistory.AutoGenerateColumns = false;
            this.gridLoginHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridLoginHistory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gridLoginHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLoginHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.loginDateDataGridViewTextBoxColumn,
            this.loginTimeDataGridViewTextBoxColumn});
            this.gridLoginHistory.DataSource = this.auditUserLoginBindingSource;
            this.gridLoginHistory.Location = new System.Drawing.Point(3, 3);
            this.gridLoginHistory.Name = "gridLoginHistory";
            this.gridLoginHistory.ReadOnly = true;
            this.gridLoginHistory.Size = new System.Drawing.Size(884, 388);
            this.gridLoginHistory.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.idDataGridViewTextBoxColumn.HeaderText = "Name";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loginDateDataGridViewTextBoxColumn
            // 
            this.loginDateDataGridViewTextBoxColumn.DataPropertyName = "LoginDate";
            this.loginDateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.loginDateDataGridViewTextBoxColumn.Name = "loginDateDataGridViewTextBoxColumn";
            this.loginDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loginTimeDataGridViewTextBoxColumn
            // 
            this.loginTimeDataGridViewTextBoxColumn.DataPropertyName = "LoginTime";
            this.loginTimeDataGridViewTextBoxColumn.HeaderText = "Time";
            this.loginTimeDataGridViewTextBoxColumn.Name = "loginTimeDataGridViewTextBoxColumn";
            this.loginTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // auditUserLoginBindingSource
            // 
            this.auditUserLoginBindingSource.DataSource = typeof(BDK.XrmToolBox.UserAuditViewer.Model.AuditUserLogin);
            // 
            // tabTransactions
            // 
            this.tabTransactions.Controls.Add(this.gridUserTransactions);
            this.tabTransactions.Location = new System.Drawing.Point(4, 22);
            this.tabTransactions.Name = "tabTransactions";
            this.tabTransactions.Padding = new System.Windows.Forms.Padding(3);
            this.tabTransactions.Size = new System.Drawing.Size(893, 394);
            this.tabTransactions.TabIndex = 1;
            this.tabTransactions.Text = "Transactions";
            this.tabTransactions.UseVisualStyleBackColor = true;
            // 
            // gridUserTransactions
            // 
            this.gridUserTransactions.AllowUserToAddRows = false;
            this.gridUserTransactions.AllowUserToDeleteRows = false;
            this.gridUserTransactions.AutoGenerateColumns = false;
            this.gridUserTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridUserTransactions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gridUserTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUserTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.entityNameDataGridViewTextBoxColumn,
            this.recordDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.operationDataGridViewTextBoxColumn});
            this.gridUserTransactions.DataSource = this.auditTransactionBindingSource;
            this.gridUserTransactions.Location = new System.Drawing.Point(6, 3);
            this.gridUserTransactions.Name = "gridUserTransactions";
            this.gridUserTransactions.ReadOnly = true;
            this.gridUserTransactions.Size = new System.Drawing.Size(881, 385);
            this.gridUserTransactions.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // entityNameDataGridViewTextBoxColumn
            // 
            this.entityNameDataGridViewTextBoxColumn.DataPropertyName = "EntityName";
            this.entityNameDataGridViewTextBoxColumn.HeaderText = "Entity";
            this.entityNameDataGridViewTextBoxColumn.Name = "entityNameDataGridViewTextBoxColumn";
            this.entityNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // recordDataGridViewTextBoxColumn
            // 
            this.recordDataGridViewTextBoxColumn.DataPropertyName = "Record";
            this.recordDataGridViewTextBoxColumn.HeaderText = "Record";
            this.recordDataGridViewTextBoxColumn.Name = "recordDataGridViewTextBoxColumn";
            this.recordDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // operationDataGridViewTextBoxColumn
            // 
            this.operationDataGridViewTextBoxColumn.DataPropertyName = "Operation";
            this.operationDataGridViewTextBoxColumn.HeaderText = "Operation";
            this.operationDataGridViewTextBoxColumn.Name = "operationDataGridViewTextBoxColumn";
            this.operationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // auditTransactionBindingSource
            // 
            this.auditTransactionBindingSource.DataSource = typeof(BDK.XrmToolBox.UserAuditViewer.Model.AuditTransaction);
            // 
            // saveFile
            // 
            this.saveFile.Filter = "Excel files (*.xls)|*.xlsx";
            // 
            // PluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.listUsers);
            this.Controls.Add(this.ddluserViews);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PluginControl";
            this.Size = new System.Drawing.Size(1199, 588);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cRMUserBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabLoginHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLoginHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.auditUserLoginBindingSource)).EndInit();
            this.tabTransactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUserTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.auditTransactionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnLoadViews;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ComboBox ddluserViews;
        private System.Windows.Forms.ListBox listUsers;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLoginHistory;
        private System.Windows.Forms.DataGridView gridLoginHistory;
        private System.Windows.Forms.TabPage tabTransactions;
        private System.Windows.Forms.BindingSource cRMUserBindingSource;
        private System.Windows.Forms.BindingSource auditUserLoginBindingSource;
        private System.Windows.Forms.DataGridView gridUserTransactions;
        private System.Windows.Forms.BindingSource auditTransactionBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn entityNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn operationDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSplitButton menuExport;
        private System.Windows.Forms.ToolStripMenuItem loginHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton menuInactiveUsers;
    }
}
