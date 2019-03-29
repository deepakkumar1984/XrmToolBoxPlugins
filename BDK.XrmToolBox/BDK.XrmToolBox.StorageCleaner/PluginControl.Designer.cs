namespace BDK.XrmToolBox.StorageCleaner
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRefresh = new System.Windows.Forms.ToolStripButton();
            this.menuBulkDelete = new System.Windows.Forms.ToolStripButton();
            this.ddlFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.txtAttachmentSize = new System.Windows.Forms.TextBox();
            this.lblEmailWithAttachments = new System.Windows.Forms.GroupBox();
            this.lblAuditLogs = new System.Windows.Forms.Label();
            this.chkAuditLogs = new System.Windows.Forms.CheckBox();
            this.lblBulkDeletes = new System.Windows.Forms.Label();
            this.chkBulkDeleteLogs = new System.Windows.Forms.CheckBox();
            this.lblBulkImports = new System.Windows.Forms.Label();
            this.chkBulkImportJobs = new System.Windows.Forms.CheckBox();
            this.lblNotesWithAttachments = new System.Windows.Forms.Label();
            this.chkNotesAttachments = new System.Windows.Forms.CheckBox();
            this.lblEmailAttachment = new System.Windows.Forms.Label();
            this.chkEmailAtachments = new System.Windows.Forms.CheckBox();
            this.lblSuspendedWf = new System.Windows.Forms.Label();
            this.chkSuspendedJobs = new System.Windows.Forms.CheckBox();
            this.lblBulkEmailWorkflow = new System.Windows.Forms.Label();
            this.chkBulkEmailWorkflow = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.lblEmailWithAttachments.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClose,
            this.toolStripSeparator1,
            this.menuRefresh,
            this.menuBulkDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(677, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // menuClose
            // 
            this.menuClose.Image = global::BDK.XrmToolBox.StorageCleaner.Properties.Resources.Delete;
            this.menuClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuClose.Name = "menuClose";
            this.menuClose.Size = new System.Drawing.Size(56, 22);
            this.menuClose.Text = "Close";
            this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // menuRefresh
            // 
            this.menuRefresh.Image = global::BDK.XrmToolBox.StorageCleaner.Properties.Resources.Refresh;
            this.menuRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuRefresh.Name = "menuRefresh";
            this.menuRefresh.Size = new System.Drawing.Size(121, 22);
            this.menuRefresh.Text = "Calculate Records";
            this.menuRefresh.Click += new System.EventHandler(this.menuRefresh_Click);
            // 
            // menuBulkDelete
            // 
            this.menuBulkDelete.Image = global::BDK.XrmToolBox.StorageCleaner.Properties.Resources.PluginProfile;
            this.menuBulkDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuBulkDelete.Name = "menuBulkDelete";
            this.menuBulkDelete.Size = new System.Drawing.Size(125, 22);
            this.menuBulkDelete.Text = "Initiate Bulk Delete";
            this.menuBulkDelete.Click += new System.EventHandler(this.menuBulkDelete_Click);
            // 
            // ddlFilter
            // 
            this.ddlFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFilter.FormattingEnabled = true;
            this.ddlFilter.Items.AddRange(new object[] {
            "Older than 1 month",
            "Older than 3 month",
            "Older than 6 month",
            "Older than 1 year",
            "Older than 3 year"});
            this.ddlFilter.Location = new System.Drawing.Point(100, 33);
            this.ddlFilter.Name = "ddlFilter";
            this.ddlFilter.Size = new System.Drawing.Size(193, 21);
            this.ddlFilter.TabIndex = 1;
            this.ddlFilter.SelectedIndexChanged += new System.EventHandler(this.ddlFilter_SelectedIndexChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(14, 36);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(80, 13);
            this.lblFilter.TabIndex = 2;
            this.lblFilter.Text = "Data older than";
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(353, 36);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(154, 13);
            this.lblFileSize.TabIndex = 3;
            this.lblFileSize.Text = "Attachment file size filter (in KB)";
            // 
            // txtAttachmentSize
            // 
            this.txtAttachmentSize.Location = new System.Drawing.Point(519, 33);
            this.txtAttachmentSize.Name = "txtAttachmentSize";
            this.txtAttachmentSize.Size = new System.Drawing.Size(100, 20);
            this.txtAttachmentSize.TabIndex = 4;
            this.txtAttachmentSize.Text = "20480";
            this.txtAttachmentSize.TextChanged += new System.EventHandler(this.txtAttachmentSize_TextChanged);
            // 
            // lblEmailWithAttachments
            // 
            this.lblEmailWithAttachments.Controls.Add(this.lblAuditLogs);
            this.lblEmailWithAttachments.Controls.Add(this.chkAuditLogs);
            this.lblEmailWithAttachments.Controls.Add(this.lblBulkDeletes);
            this.lblEmailWithAttachments.Controls.Add(this.chkBulkDeleteLogs);
            this.lblEmailWithAttachments.Controls.Add(this.lblBulkImports);
            this.lblEmailWithAttachments.Controls.Add(this.chkBulkImportJobs);
            this.lblEmailWithAttachments.Controls.Add(this.lblNotesWithAttachments);
            this.lblEmailWithAttachments.Controls.Add(this.chkNotesAttachments);
            this.lblEmailWithAttachments.Controls.Add(this.lblEmailAttachment);
            this.lblEmailWithAttachments.Controls.Add(this.chkEmailAtachments);
            this.lblEmailWithAttachments.Controls.Add(this.lblSuspendedWf);
            this.lblEmailWithAttachments.Controls.Add(this.chkSuspendedJobs);
            this.lblEmailWithAttachments.Controls.Add(this.lblBulkEmailWorkflow);
            this.lblEmailWithAttachments.Controls.Add(this.chkBulkEmailWorkflow);
            this.lblEmailWithAttachments.Location = new System.Drawing.Point(17, 105);
            this.lblEmailWithAttachments.Name = "lblEmailWithAttachments";
            this.lblEmailWithAttachments.Size = new System.Drawing.Size(602, 384);
            this.lblEmailWithAttachments.TabIndex = 5;
            this.lblEmailWithAttachments.TabStop = false;
            this.lblEmailWithAttachments.Text = "Usage information";
            // 
            // lblAuditLogs
            // 
            this.lblAuditLogs.AutoSize = true;
            this.lblAuditLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuditLogs.Location = new System.Drawing.Point(318, 327);
            this.lblAuditLogs.Name = "lblAuditLogs";
            this.lblAuditLogs.Size = new System.Drawing.Size(77, 17);
            this.lblAuditLogs.TabIndex = 13;
            this.lblAuditLogs.Text = "0 records";
            // 
            // chkAuditLogs
            // 
            this.chkAuditLogs.AutoSize = true;
            this.chkAuditLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAuditLogs.Location = new System.Drawing.Point(83, 327);
            this.chkAuditLogs.Name = "chkAuditLogs";
            this.chkAuditLogs.Size = new System.Drawing.Size(94, 21);
            this.chkAuditLogs.TabIndex = 12;
            this.chkAuditLogs.Text = "Audit Logs";
            this.chkAuditLogs.UseVisualStyleBackColor = true;
            // 
            // lblBulkDeletes
            // 
            this.lblBulkDeletes.AutoSize = true;
            this.lblBulkDeletes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBulkDeletes.Location = new System.Drawing.Point(318, 278);
            this.lblBulkDeletes.Name = "lblBulkDeletes";
            this.lblBulkDeletes.Size = new System.Drawing.Size(77, 17);
            this.lblBulkDeletes.TabIndex = 11;
            this.lblBulkDeletes.Text = "0 records";
            // 
            // chkBulkDeleteLogs
            // 
            this.chkBulkDeleteLogs.AutoSize = true;
            this.chkBulkDeleteLogs.Checked = true;
            this.chkBulkDeleteLogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBulkDeleteLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBulkDeleteLogs.Location = new System.Drawing.Point(83, 278);
            this.chkBulkDeleteLogs.Name = "chkBulkDeleteLogs";
            this.chkBulkDeleteLogs.Size = new System.Drawing.Size(134, 21);
            this.chkBulkDeleteLogs.TabIndex = 10;
            this.chkBulkDeleteLogs.Text = "Bulk Delete Logs";
            this.chkBulkDeleteLogs.UseVisualStyleBackColor = true;
            // 
            // lblBulkImports
            // 
            this.lblBulkImports.AutoSize = true;
            this.lblBulkImports.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBulkImports.Location = new System.Drawing.Point(318, 229);
            this.lblBulkImports.Name = "lblBulkImports";
            this.lblBulkImports.Size = new System.Drawing.Size(77, 17);
            this.lblBulkImports.TabIndex = 9;
            this.lblBulkImports.Text = "0 records";
            // 
            // chkBulkImportJobs
            // 
            this.chkBulkImportJobs.AutoSize = true;
            this.chkBulkImportJobs.Checked = true;
            this.chkBulkImportJobs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBulkImportJobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBulkImportJobs.Location = new System.Drawing.Point(83, 229);
            this.chkBulkImportJobs.Name = "chkBulkImportJobs";
            this.chkBulkImportJobs.Size = new System.Drawing.Size(131, 21);
            this.chkBulkImportJobs.TabIndex = 8;
            this.chkBulkImportJobs.Text = "Bulk Import Jobs";
            this.chkBulkImportJobs.UseVisualStyleBackColor = true;
            // 
            // lblNotesWithAttachments
            // 
            this.lblNotesWithAttachments.AutoSize = true;
            this.lblNotesWithAttachments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotesWithAttachments.Location = new System.Drawing.Point(318, 178);
            this.lblNotesWithAttachments.Name = "lblNotesWithAttachments";
            this.lblNotesWithAttachments.Size = new System.Drawing.Size(77, 17);
            this.lblNotesWithAttachments.TabIndex = 7;
            this.lblNotesWithAttachments.Text = "0 records";
            // 
            // chkNotesAttachments
            // 
            this.chkNotesAttachments.AutoSize = true;
            this.chkNotesAttachments.Checked = true;
            this.chkNotesAttachments.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNotesAttachments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNotesAttachments.Location = new System.Drawing.Point(83, 178);
            this.chkNotesAttachments.Name = "chkNotesAttachments";
            this.chkNotesAttachments.Size = new System.Drawing.Size(174, 21);
            this.chkNotesAttachments.TabIndex = 6;
            this.chkNotesAttachments.Text = "Notes with Attachments";
            this.chkNotesAttachments.UseVisualStyleBackColor = true;
            // 
            // lblEmailAttachment
            // 
            this.lblEmailAttachment.AutoSize = true;
            this.lblEmailAttachment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailAttachment.Location = new System.Drawing.Point(318, 127);
            this.lblEmailAttachment.Name = "lblEmailAttachment";
            this.lblEmailAttachment.Size = new System.Drawing.Size(77, 17);
            this.lblEmailAttachment.TabIndex = 5;
            this.lblEmailAttachment.Text = "0 records";
            // 
            // chkEmailAtachments
            // 
            this.chkEmailAtachments.AutoSize = true;
            this.chkEmailAtachments.Checked = true;
            this.chkEmailAtachments.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEmailAtachments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEmailAtachments.Location = new System.Drawing.Point(83, 127);
            this.chkEmailAtachments.Name = "chkEmailAtachments";
            this.chkEmailAtachments.Size = new System.Drawing.Size(171, 21);
            this.chkEmailAtachments.TabIndex = 4;
            this.chkEmailAtachments.Text = "Email with Attachments";
            this.chkEmailAtachments.UseVisualStyleBackColor = true;
            // 
            // lblSuspendedWf
            // 
            this.lblSuspendedWf.AutoSize = true;
            this.lblSuspendedWf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuspendedWf.Location = new System.Drawing.Point(318, 82);
            this.lblSuspendedWf.Name = "lblSuspendedWf";
            this.lblSuspendedWf.Size = new System.Drawing.Size(77, 17);
            this.lblSuspendedWf.TabIndex = 3;
            this.lblSuspendedWf.Text = "0 records";
            // 
            // chkSuspendedJobs
            // 
            this.chkSuspendedJobs.AutoSize = true;
            this.chkSuspendedJobs.Checked = true;
            this.chkSuspendedJobs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSuspendedJobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSuspendedJobs.Location = new System.Drawing.Point(83, 82);
            this.chkSuspendedJobs.Name = "chkSuspendedJobs";
            this.chkSuspendedJobs.Size = new System.Drawing.Size(133, 21);
            this.chkSuspendedJobs.TabIndex = 2;
            this.chkSuspendedJobs.Text = "Suspended Jobs";
            this.chkSuspendedJobs.UseVisualStyleBackColor = true;
            // 
            // lblBulkEmailWorkflow
            // 
            this.lblBulkEmailWorkflow.AutoSize = true;
            this.lblBulkEmailWorkflow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBulkEmailWorkflow.Location = new System.Drawing.Point(318, 32);
            this.lblBulkEmailWorkflow.Name = "lblBulkEmailWorkflow";
            this.lblBulkEmailWorkflow.Size = new System.Drawing.Size(77, 17);
            this.lblBulkEmailWorkflow.TabIndex = 1;
            this.lblBulkEmailWorkflow.Text = "0 records";
            // 
            // chkBulkEmailWorkflow
            // 
            this.chkBulkEmailWorkflow.AutoSize = true;
            this.chkBulkEmailWorkflow.Checked = true;
            this.chkBulkEmailWorkflow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBulkEmailWorkflow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBulkEmailWorkflow.Location = new System.Drawing.Point(83, 32);
            this.chkBulkEmailWorkflow.Name = "chkBulkEmailWorkflow";
            this.chkBulkEmailWorkflow.Size = new System.Drawing.Size(181, 21);
            this.chkBulkEmailWorkflow.TabIndex = 0;
            this.chkBulkEmailWorkflow.Text = "Bulk Email and Workflow";
            this.chkBulkEmailWorkflow.UseVisualStyleBackColor = true;
            // 
            // PluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblEmailWithAttachments);
            this.Controls.Add(this.txtAttachmentSize);
            this.Controls.Add(this.lblFileSize);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.ddlFilter);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PluginControl";
            this.Size = new System.Drawing.Size(677, 577);
            this.Load += new System.EventHandler(this.PluginControl_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.lblEmailWithAttachments.ResumeLayout(false);
            this.lblEmailWithAttachments.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton menuClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton menuRefresh;
        private System.Windows.Forms.ComboBox ddlFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.TextBox txtAttachmentSize;
        private System.Windows.Forms.GroupBox lblEmailWithAttachments;
        private System.Windows.Forms.CheckBox chkBulkEmailWorkflow;
        private System.Windows.Forms.Label lblBulkEmailWorkflow;
        private System.Windows.Forms.Label lblBulkDeletes;
        private System.Windows.Forms.CheckBox chkBulkDeleteLogs;
        private System.Windows.Forms.Label lblBulkImports;
        private System.Windows.Forms.CheckBox chkBulkImportJobs;
        private System.Windows.Forms.Label lblNotesWithAttachments;
        private System.Windows.Forms.CheckBox chkNotesAttachments;
        private System.Windows.Forms.Label lblEmailAttachment;
        private System.Windows.Forms.CheckBox chkEmailAtachments;
        private System.Windows.Forms.Label lblSuspendedWf;
        private System.Windows.Forms.CheckBox chkSuspendedJobs;
        private System.Windows.Forms.Label lblAuditLogs;
        private System.Windows.Forms.CheckBox chkAuditLogs;
        private System.Windows.Forms.ToolStripButton menuBulkDelete;
    }
}
