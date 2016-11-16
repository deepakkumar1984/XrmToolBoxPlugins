namespace BDK.XrmToolBox.UserManagement
{
    partial class InactiveUsers
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
            this.showInactiveUsers1 = new BDK.XrmToolBox.UserManagement.ShowInactiveUsers();
            this.SuspendLayout();
            // 
            // showInactiveUsers1
            // 
            this.showInactiveUsers1.ConnectionDetail = null;
            this.showInactiveUsers1.Location = new System.Drawing.Point(2, 9);
            this.showInactiveUsers1.Name = "showInactiveUsers1";
            this.showInactiveUsers1.OrgService = null;
            this.showInactiveUsers1.Size = new System.Drawing.Size(846, 493);
            this.showInactiveUsers1.TabIndex = 0;
            // 
            // InactiveUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 510);
            this.Controls.Add(this.showInactiveUsers1);
            this.Name = "InactiveUsers";
            this.Text = "Show In-Active Users";
            this.ResumeLayout(false);

        }

        #endregion

        private ShowInactiveUsers showInactiveUsers1;
    }
}