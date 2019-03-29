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
            this.menuClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuLoadEntities = new System.Windows.Forms.ToolStripButton();
            this.menuRestore = new System.Windows.Forms.ToolStripButton();
            this.ddlEntities = new System.Windows.Forms.ComboBox();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnShowRecords = new System.Windows.Forms.Button();
            this.GridDeletedRecords = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.entityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auditItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.ddlUsers = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.GridDetails = new System.Windows.Forms.DataGridView();
            this.fieldNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletedFieldBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDeletedRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.auditItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deletedFieldBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClose,
            this.toolStripSeparator1,
            this.menuLoadEntities,
            this.menuRestore});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MaximumSize = new System.Drawing.Size(0, 21);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1203, 21);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // menuClose
            // 
            this.menuClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuClose.Image = global::BDK.XrmToolBox.RecycleBin.Properties.Resources.Delete;
            this.menuClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuClose.Name = "menuClose";
            this.menuClose.Size = new System.Drawing.Size(23, 18);
            this.menuClose.Text = "toolStripButton1";
            this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 21);
            // 
            // menuLoadEntities
            // 
            this.menuLoadEntities.Image = global::BDK.XrmToolBox.RecycleBin.Properties.Resources.Refresh;
            this.menuLoadEntities.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuLoadEntities.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuLoadEntities.Name = "menuLoadEntities";
            this.menuLoadEntities.Size = new System.Drawing.Size(145, 18);
            this.menuLoadEntities.Text = "Load Entities and Users";
            this.menuLoadEntities.Click += new System.EventHandler(this.menuLoadEntities_Click);
            // 
            // menuRestore
            // 
            this.menuRestore.Image = global::BDK.XrmToolBox.RecycleBin.Properties.Resources.StepEnabled;
            this.menuRestore.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuRestore.Name = "menuRestore";
            this.menuRestore.Size = new System.Drawing.Size(118, 18);
            this.menuRestore.Text = "Restore Record(s)";
            this.menuRestore.Click += new System.EventHandler(this.menuRestore_Click);
            // 
            // ddlEntities
            // 
            this.ddlEntities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlEntities.FormattingEnabled = true;
            this.ddlEntities.Location = new System.Drawing.Point(90, 17);
            this.ddlEntities.Name = "ddlEntities";
            this.ddlEntities.Size = new System.Drawing.Size(185, 21);
            this.ddlEntities.TabIndex = 2;
            // 
            // dateFrom
            // 
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(4, 23);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(93, 20);
            this.dateFrom.TabIndex = 3;
            // 
            // dateTo
            // 
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTo.Location = new System.Drawing.Point(156, 23);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(93, 20);
            this.dateTo.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "to";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select Entity";
            // 
            // btnShowRecords
            // 
            this.btnShowRecords.Location = new System.Drawing.Point(4, 63);
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
            this.GridDeletedRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridDeletedRecords.Location = new System.Drawing.Point(0, 0);
            this.GridDeletedRecords.Name = "GridDeletedRecords";
            this.GridDeletedRecords.ReadOnly = true;
            this.GridDeletedRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GridDeletedRecords.Size = new System.Drawing.Size(500, 467);
            this.GridDeletedRecords.TabIndex = 9;
            this.GridDeletedRecords.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDeletedRecords_CellClick);
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
            // auditItemBindingSource
            // 
            this.auditItemBindingSource.DataSource = typeof(BDK.XrmToolBox.RecycleBin.Model.AuditItem);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Select User";
            // 
            // ddlUsers
            // 
            this.ddlUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlUsers.FormattingEnabled = true;
            this.ddlUsers.Location = new System.Drawing.Point(90, 56);
            this.ddlUsers.Name = "ddlUsers";
            this.ddlUsers.Size = new System.Drawing.Size(185, 21);
            this.ddlUsers.TabIndex = 10;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 21);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1203, 566);
            this.splitContainer1.SplitterDistance = 97;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateFrom);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnShowRecords);
            this.groupBox2.Controls.Add(this.dateTo);
            this.groupBox2.Location = new System.Drawing.Point(530, 6);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox2.Size = new System.Drawing.Size(672, 91);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date Range";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ddlEntities);
            this.groupBox1.Controls.Add(this.ddlUsers);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox1.Size = new System.Drawing.Size(527, 96);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.GridDeletedRecords);
            this.splitContainer2.Panel1MinSize = 500;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.GridDetails);
            this.splitContainer2.Size = new System.Drawing.Size(1203, 467);
            this.splitContainer2.SplitterDistance = 500;
            this.splitContainer2.SplitterWidth = 2;
            this.splitContainer2.TabIndex = 10;
            // 
            // GridDetails
            // 
            this.GridDetails.AllowUserToAddRows = false;
            this.GridDetails.AllowUserToDeleteRows = false;
            this.GridDetails.AutoGenerateColumns = false;
            this.GridDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fieldNameDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.GridDetails.DataSource = this.deletedFieldBindingSource;
            this.GridDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridDetails.Location = new System.Drawing.Point(0, 0);
            this.GridDetails.Name = "GridDetails";
            this.GridDetails.ReadOnly = true;
            this.GridDetails.Size = new System.Drawing.Size(701, 467);
            this.GridDetails.TabIndex = 1;
            // 
            // fieldNameDataGridViewTextBoxColumn
            // 
            this.fieldNameDataGridViewTextBoxColumn.DataPropertyName = "FieldName";
            this.fieldNameDataGridViewTextBoxColumn.HeaderText = "Field";
            this.fieldNameDataGridViewTextBoxColumn.Name = "fieldNameDataGridViewTextBoxColumn";
            this.fieldNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deletedFieldBindingSource
            // 
            this.deletedFieldBindingSource.DataSource = typeof(BDK.XrmToolBox.RecycleBin.Model.DeletedField);
            // 
            // PluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PluginControl";
            this.Size = new System.Drawing.Size(1203, 587);
            this.Load += new System.EventHandler(this.PluginControl_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDeletedRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.auditItemBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deletedFieldBindingSource)).EndInit();
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView GridDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource deletedFieldBindingSource;
    }
}
