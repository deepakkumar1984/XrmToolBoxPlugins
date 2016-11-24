namespace BDK.XrmToolBox.RecycleBin
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ddlEntities = new System.Windows.Forms.ComboBox();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnShowRecords = new System.Windows.Forms.Button();
            this.GridDeletedRecords = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlUsers = new System.Windows.Forms.ComboBox();
            this.menuClose = new System.Windows.Forms.ToolStripButton();
            this.menuLoadEntities = new System.Windows.Forms.ToolStripButton();
            this.menuRestore = new System.Windows.Forms.ToolStripButton();
            this.auditItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.entityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDeletedRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.auditItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClose,
            this.toolStripSeparator1,
            this.menuLoadEntities,
            this.menuRestore});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1203, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ddlEntities
            // 
            this.ddlEntities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlEntities.FormattingEnabled = true;
            this.ddlEntities.Location = new System.Drawing.Point(85, 33);
            this.ddlEntities.Name = "ddlEntities";
            this.ddlEntities.Size = new System.Drawing.Size(185, 21);
            this.ddlEntities.TabIndex = 2;
            // 
            // dateFrom
            // 
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(741, 35);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(93, 20);
            this.dateFrom.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(624, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Date Range Filter";
            // 
            // dateTo
            // 
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTo.Location = new System.Drawing.Point(887, 35);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(93, 20);
            this.dateTo.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(852, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "to";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select Entity";
            // 
            // btnShowRecords
            // 
            this.btnShowRecords.Location = new System.Drawing.Point(1021, 31);
            this.btnShowRecords.Name = "btnShowRecords";
            this.btnShowRecords.Size = new System.Drawing.Size(125, 23);
            this.btnShowRecords.TabIndex = 8;
            this.btnShowRecords.Text = "Show Deleted Records";
            this.btnShowRecords.UseVisualStyleBackColor = true;
            this.btnShowRecords.Click += new System.EventHandler(this.btnShowRecords_Click);
            // 
            // GridDeletedRecords
            // 
            this.GridDeletedRecords.AllowUserToAddRows = false;
            this.GridDeletedRecords.AllowUserToDeleteRows = false;
            this.GridDeletedRecords.AutoGenerateColumns = false;
            this.GridDeletedRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridDeletedRecords.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.GridDeletedRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDeletedRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.nameDataGridViewTextBoxColumn,
            this.entityDataGridViewTextBoxColumn,
            this.deletionDateDataGridViewTextBoxColumn,
            this.deletedByDataGridViewTextBoxColumn});
            this.GridDeletedRecords.DataSource = this.auditItemBindingSource;
            this.GridDeletedRecords.Location = new System.Drawing.Point(16, 80);
            this.GridDeletedRecords.Name = "GridDeletedRecords";
            this.GridDeletedRecords.ReadOnly = true;
            this.GridDeletedRecords.Size = new System.Drawing.Size(1184, 396);
            this.GridDeletedRecords.TabIndex = 9;
            this.GridDeletedRecords.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDeletedRecords_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(316, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Select User";
            // 
            // ddlUsers
            // 
            this.ddlUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlUsers.FormattingEnabled = true;
            this.ddlUsers.Location = new System.Drawing.Point(384, 32);
            this.ddlUsers.Name = "ddlUsers";
            this.ddlUsers.Size = new System.Drawing.Size(185, 21);
            this.ddlUsers.TabIndex = 10;
            // 
            // menuClose
            // 
            this.menuClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuClose.Image = global::BDK.XrmToolBox.RecycleBin.Properties.Resources.Delete;
            this.menuClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuClose.Name = "menuClose";
            this.menuClose.Size = new System.Drawing.Size(23, 22);
            this.menuClose.Text = "toolStripButton1";
            this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
            // 
            // menuLoadEntities
            // 
            this.menuLoadEntities.Image = global::BDK.XrmToolBox.RecycleBin.Properties.Resources.Refresh;
            this.menuLoadEntities.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuLoadEntities.Name = "menuLoadEntities";
            this.menuLoadEntities.Size = new System.Drawing.Size(148, 22);
            this.menuLoadEntities.Text = "Load Entities and Users";
            this.menuLoadEntities.Click += new System.EventHandler(this.menuLoadEntities_Click);
            // 
            // menuRestore
            // 
            this.menuRestore.Image = global::BDK.XrmToolBox.RecycleBin.Properties.Resources.StepEnabled;
            this.menuRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuRestore.Name = "menuRestore";
            this.menuRestore.Size = new System.Drawing.Size(119, 22);
            this.menuRestore.Text = "Restore Record(s)";
            this.menuRestore.Click += new System.EventHandler(this.menuRestore_Click);
            // 
            // auditItemBindingSource
            // 
            this.auditItemBindingSource.DataSource = typeof(BDK.XrmToolBox.RecycleBin.Model.AuditItem);
            // 
            // Select
            // 
            this.Select.FillWeight = 25.38071F;
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.FillWeight = 204.7849F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Record";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // entityDataGridViewTextBoxColumn
            // 
            this.entityDataGridViewTextBoxColumn.DataPropertyName = "Entity";
            this.entityDataGridViewTextBoxColumn.FillWeight = 89.94477F;
            this.entityDataGridViewTextBoxColumn.HeaderText = "Entity";
            this.entityDataGridViewTextBoxColumn.Name = "entityDataGridViewTextBoxColumn";
            this.entityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deletionDateDataGridViewTextBoxColumn
            // 
            this.deletionDateDataGridViewTextBoxColumn.DataPropertyName = "DeletionDate";
            this.deletionDateDataGridViewTextBoxColumn.FillWeight = 89.94477F;
            this.deletionDateDataGridViewTextBoxColumn.HeaderText = "Deleted Date";
            this.deletionDateDataGridViewTextBoxColumn.Name = "deletionDateDataGridViewTextBoxColumn";
            this.deletionDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deletedByDataGridViewTextBoxColumn
            // 
            this.deletedByDataGridViewTextBoxColumn.DataPropertyName = "DeletedBy";
            this.deletedByDataGridViewTextBoxColumn.FillWeight = 89.94477F;
            this.deletedByDataGridViewTextBoxColumn.HeaderText = "Deleted By";
            this.deletedByDataGridViewTextBoxColumn.Name = "deletedByDataGridViewTextBoxColumn";
            this.deletedByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // PluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ddlUsers);
            this.Controls.Add(this.GridDeletedRecords);
            this.Controls.Add(this.btnShowRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.ddlEntities);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PluginControl";
            this.Size = new System.Drawing.Size(1203, 587);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDeletedRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.auditItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton menuClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton menuLoadEntities;
        private System.Windows.Forms.ComboBox ddlEntities;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnShowRecords;
        private System.Windows.Forms.DataGridView GridDeletedRecords;
        private System.Windows.Forms.BindingSource auditItemBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlUsers;
        private System.Windows.Forms.ToolStripButton menuRestore;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewLinkColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deletionDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deletedByDataGridViewTextBoxColumn;
    }
}
