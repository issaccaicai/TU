namespace OrderOptionMaintenance
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSalesTaxRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstBookShipping = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAdditionalBookShipping = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sales Tax Rate:";
            // 
            // txtSalesTaxRate
            // 
            this.txtSalesTaxRate.Location = new System.Drawing.Point(170, 20);
            this.txtSalesTaxRate.Name = "txtSalesTaxRate";
            this.txtSalesTaxRate.Size = new System.Drawing.Size(100, 20);
            this.txtSalesTaxRate.TabIndex = 1;
            this.txtSalesTaxRate.Tag = "Sales Tax Rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "First Book Ship Charge:";
            // 
            // txtFirstBookShipping
            // 
            this.txtFirstBookShipping.Location = new System.Drawing.Point(170, 46);
            this.txtFirstBookShipping.Name = "txtFirstBookShipping";
            this.txtFirstBookShipping.Size = new System.Drawing.Size(100, 20);
            this.txtFirstBookShipping.TabIndex = 3;
            this.txtFirstBookShipping.Tag = "First Book Ship Charge";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Additional Book Ship Charge:";
            // 
            // txtAdditionalBookShipping
            // 
            this.txtAdditionalBookShipping.Location = new System.Drawing.Point(170, 72);
            this.txtAdditionalBookShipping.Name = "txtAdditionalBookShipping";
            this.txtAdditionalBookShipping.Size = new System.Drawing.Size(100, 20);
            this.txtAdditionalBookShipping.TabIndex = 5;
            this.txtAdditionalBookShipping.Tag = "Additional Book Ship Charge";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(114, 109);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(195, 109);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(294, 150);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAdditionalBookShipping);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFirstBookShipping);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSalesTaxRate);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maintain Order Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSalesTaxRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFirstBookShipping;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAdditionalBookShipping;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
    }
}

