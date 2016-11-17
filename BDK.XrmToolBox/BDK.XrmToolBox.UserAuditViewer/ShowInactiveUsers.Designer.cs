namespace BDK.XrmToolBox.UserAuditViewer
{
    partial class ShowInactiveUsers
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
            this.GridUsers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlFilter = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.cRMUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primaryEmailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.businessUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastLoggedInDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cRMUserBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // GridUsers
            // 
            this.GridUsers.AllowUserToAddRows = false;
            this.GridUsers.AllowUserToDeleteRows = false;
            this.GridUsers.AutoGenerateColumns = false;
            this.GridUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridUsers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.GridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.usernameDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.primaryEmailDataGridViewTextBoxColumn,
            this.businessUnitDataGridViewTextBoxColumn,
            this.lastLoggedInDataGridViewTextBoxColumn});
            this.GridUsers.DataSource = this.cRMUserBindingSource;
            this.GridUsers.Location = new System.Drawing.Point(59, 88);
            this.GridUsers.Name = "GridUsers";
            this.GridUsers.ReadOnly = true;
            this.GridUsers.Size = new System.Drawing.Size(728, 360);
            this.GridUsers.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Show users inactive from:";
            // 
            // ddlFilter
            // 
            this.ddlFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFilter.FormattingEnabled = true;
            this.ddlFilter.Items.AddRange(new object[] {
            "Past 1 month",
            "Past 3 months",
            "Past 6 months",
            "Past 12 months"});
            this.ddlFilter.Location = new System.Drawing.Point(233, 40);
            this.ddlFilter.Name = "ddlFilter";
            this.ddlFilter.Size = new System.Drawing.Size(267, 21);
            this.ddlFilter.TabIndex = 3;
            this.ddlFilter.SelectedIndexChanged += new System.EventHandler(this.ddlFilter_SelectedIndexChanged);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::BDK.XrmToolBox.UserAuditViewer.Properties.Resources.UninstallProfiler;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(671, 38);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(116, 23);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // saveFile
            // 
            this.saveFile.Filter = "Excel files (*.xls)|*.xlsx";
            // 
            // cRMUserBindingSource
            // 
            this.cRMUserBindingSource.DataSource = typeof(BDK.XrmToolBox.UserAuditViewer.Model.CRMUser);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            this.usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
            this.usernameDataGridViewTextBoxColumn.HeaderText = "Username";
            this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            this.usernameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // primaryEmailDataGridViewTextBoxColumn
            // 
            this.primaryEmailDataGridViewTextBoxColumn.DataPropertyName = "PrimaryEmail";
            this.primaryEmailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.primaryEmailDataGridViewTextBoxColumn.Name = "primaryEmailDataGridViewTextBoxColumn";
            this.primaryEmailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // businessUnitDataGridViewTextBoxColumn
            // 
            this.businessUnitDataGridViewTextBoxColumn.DataPropertyName = "BusinessUnit";
            this.businessUnitDataGridViewTextBoxColumn.HeaderText = "Business Unit";
            this.businessUnitDataGridViewTextBoxColumn.Name = "businessUnitDataGridViewTextBoxColumn";
            this.businessUnitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastLoggedInDataGridViewTextBoxColumn
            // 
            this.lastLoggedInDataGridViewTextBoxColumn.DataPropertyName = "LastLoggedIn";
            this.lastLoggedInDataGridViewTextBoxColumn.HeaderText = "Last Log In";
            this.lastLoggedInDataGridViewTextBoxColumn.Name = "lastLoggedInDataGridViewTextBoxColumn";
            this.lastLoggedInDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ShowInactiveUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.GridUsers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlFilter);
            this.Name = "ShowInactiveUsers";
            this.Size = new System.Drawing.Size(846, 493);
            ((System.ComponentModel.ISupportInitialize)(this.GridUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cRMUserBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridUsers;
        private System.Windows.Forms.BindingSource cRMUserBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlFilter;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn primaryEmailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn businessUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastLoggedInDataGridViewTextBoxColumn;
    }
}
