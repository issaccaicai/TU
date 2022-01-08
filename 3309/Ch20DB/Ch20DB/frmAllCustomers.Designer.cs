namespace Ch20DB
{
    partial class frmAllCustomers
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
            this.cbxInvoices = new System.Windows.Forms.ComboBox();
            this.lstAllCustomers = new System.Windows.Forms.ListBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnGetAllCustomers = new System.Windows.Forms.Button();
            this.lstLineItems = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cbxInvoices
            // 
            this.cbxInvoices.FormattingEnabled = true;
            this.cbxInvoices.Location = new System.Drawing.Point(12, 139);
            this.cbxInvoices.Name = "cbxInvoices";
            this.cbxInvoices.Size = new System.Drawing.Size(705, 21);
            this.cbxInvoices.TabIndex = 7;
            this.cbxInvoices.Text = "Select an Invoice";
            this.cbxInvoices.SelectedIndexChanged += new System.EventHandler(this.cbxInvoices_SelectedIndexChanged);
            // 
            // lstAllCustomers
            // 
            this.lstAllCustomers.FormattingEnabled = true;
            this.lstAllCustomers.Location = new System.Drawing.Point(12, 12);
            this.lstAllCustomers.Name = "lstAllCustomers";
            this.lstAllCustomers.Size = new System.Drawing.Size(705, 121);
            this.lstAllCustomers.TabIndex = 6;
            this.lstAllCustomers.SelectedIndexChanged += new System.EventHandler(this.lstAllCustomers_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(642, 425);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnGetAllCustomers
            // 
            this.btnGetAllCustomers.Location = new System.Drawing.Point(12, 425);
            this.btnGetAllCustomers.Name = "btnGetAllCustomers";
            this.btnGetAllCustomers.Size = new System.Drawing.Size(119, 23);
            this.btnGetAllCustomers.TabIndex = 4;
            this.btnGetAllCustomers.Text = "Get All Customers";
            this.btnGetAllCustomers.UseVisualStyleBackColor = true;
            this.btnGetAllCustomers.Click += new System.EventHandler(this.btnGetAllCustomers_Click);
            // 
            // lstLineItems
            // 
            this.lstLineItems.FormattingEnabled = true;
            this.lstLineItems.Location = new System.Drawing.Point(11, 166);
            this.lstLineItems.Name = "lstLineItems";
            this.lstLineItems.Size = new System.Drawing.Size(706, 238);
            this.lstLineItems.TabIndex = 8;
            this.lstLineItems.SelectedIndexChanged += new System.EventHandler(this.lstLineItems_SelectedIndexChanged);
            // 
            // frmAllCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 458);
            this.Controls.Add(this.lstLineItems);
            this.Controls.Add(this.cbxInvoices);
            this.Controls.Add(this.lstAllCustomers);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnGetAllCustomers);
            this.Name = "frmAllCustomers";
            this.Text = "frmAllCustomers";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxInvoices;
        private System.Windows.Forms.ListBox lstAllCustomers;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnGetAllCustomers;
        private System.Windows.Forms.ListBox lstLineItems;
    }
}