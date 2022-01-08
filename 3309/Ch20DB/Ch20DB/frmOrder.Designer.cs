namespace Ch20DB
{
    partial class frmOrder
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
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.lstCart = new System.Windows.Forms.ListBox();
            this.lblCart = new System.Windows.Forms.Label();
            this.lblChoose = new System.Windows.Forms.Label();
            this.cbxChoose = new System.Windows.Forms.ComboBox();
            this.btnFindMe = new System.Windows.Forms.Button();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnBuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Location = new System.Drawing.Point(469, 60);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(75, 23);
            this.btnAddToCart.TabIndex = 19;
            this.btnAddToCart.Text = "Add to cart";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // lstCart
            // 
            this.lstCart.FormattingEnabled = true;
            this.lstCart.Location = new System.Drawing.Point(113, 104);
            this.lstCart.Name = "lstCart";
            this.lstCart.Size = new System.Drawing.Size(350, 186);
            this.lstCart.TabIndex = 18;
            // 
            // lblCart
            // 
            this.lblCart.AutoSize = true;
            this.lblCart.Location = new System.Drawing.Point(16, 104);
            this.lblCart.Name = "lblCart";
            this.lblCart.Size = new System.Drawing.Size(26, 13);
            this.lblCart.TabIndex = 17;
            this.lblCart.Text = "Cart";
            // 
            // lblChoose
            // 
            this.lblChoose.AutoSize = true;
            this.lblChoose.Location = new System.Drawing.Point(13, 65);
            this.lblChoose.Name = "lblChoose";
            this.lblChoose.Size = new System.Drawing.Size(91, 13);
            this.lblChoose.TabIndex = 16;
            this.lblChoose.Text = "Choose a product";
            // 
            // cbxChoose
            // 
            this.cbxChoose.FormattingEnabled = true;
            this.cbxChoose.Location = new System.Drawing.Point(113, 62);
            this.cbxChoose.Name = "cbxChoose";
            this.cbxChoose.Size = new System.Drawing.Size(350, 21);
            this.cbxChoose.TabIndex = 15;
            this.cbxChoose.Text = "Choose a product";
            // 
            // btnFindMe
            // 
            this.btnFindMe.Location = new System.Drawing.Point(196, 13);
            this.btnFindMe.Name = "btnFindMe";
            this.btnFindMe.Size = new System.Drawing.Size(75, 23);
            this.btnFindMe.TabIndex = 14;
            this.btnFindMe.Text = "Find Me";
            this.btnFindMe.UseVisualStyleBackColor = true;
            this.btnFindMe.Click += new System.EventHandler(this.btnFindMe_Click);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(90, 15);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerID.TabIndex = 13;
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Location = new System.Drawing.Point(13, 18);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(65, 13);
            this.lblCustomerID.TabIndex = 12;
            this.lblCustomerID.Text = "Customer ID";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(469, 352);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(16, 352);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 23);
            this.btnBuy.TabIndex = 10;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 386);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.lstCart);
            this.Controls.Add(this.lblCart);
            this.Controls.Add(this.lblChoose);
            this.Controls.Add(this.cbxChoose);
            this.Controls.Add(this.btnFindMe);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.lblCustomerID);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnBuy);
            this.Name = "frmOrder";
            this.Text = "frmOrder";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.ListBox lstCart;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.Label lblChoose;
        private System.Windows.Forms.ComboBox cbxChoose;
        private System.Windows.Forms.Button btnFindMe;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnBuy;
    }
}