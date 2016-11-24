namespace BDK.XrmToolBox.RecycleBin
{
    partial class ShowDeletedInfo
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GridDetails = new System.Windows.Forms.DataGridView();
            this.fieldNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletedFieldBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GridDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deletedFieldBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.GridDetails.Location = new System.Drawing.Point(13, 13);
            this.GridDetails.Name = "GridDetails";
            this.GridDetails.ReadOnly = true;
            this.GridDetails.Size = new System.Drawing.Size(598, 520);
            this.GridDetails.TabIndex = 0;
            // 
            // fieldNameDataGridViewTextBoxColumn
            // 
            this.fieldNameDataGridViewTextBoxColumn.DataPropertyName = "FieldName";
            this.fieldNameDataGridViewTextBoxColumn.FillWeight = 76.14214F;
            this.fieldNameDataGridViewTextBoxColumn.HeaderText = "Field";
            this.fieldNameDataGridViewTextBoxColumn.Name = "fieldNameDataGridViewTextBoxColumn";
            this.fieldNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.FillWeight = 123.8579F;
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deletedFieldBindingSource
            // 
            this.deletedFieldBindingSource.DataSource = typeof(BDK.XrmToolBox.RecycleBin.Model.DeletedField);
            // 
            // ShowDeletedInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 545);
            this.Controls.Add(this.GridDetails);
            this.Name = "ShowDeletedInfo";
            this.Text = "Show Deleted Info";
            ((System.ComponentModel.ISupportInitialize)(this.GridDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deletedFieldBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource deletedFieldBindingSource;
    }
}