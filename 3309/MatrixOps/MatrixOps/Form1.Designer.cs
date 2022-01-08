namespace MatrixOps
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
            this.txtMatrixA = new System.Windows.Forms.TextBox();
            this.lbMatrixA = new System.Windows.Forms.Label();
            this.txtMatrixB = new System.Windows.Forms.TextBox();
            this.txtMatrixC = new System.Windows.Forms.TextBox();
            this.lbMatrixB = new System.Windows.Forms.Label();
            this.lbMatrixC = new System.Windows.Forms.Label();
            this.btnMakeMatrixA = new System.Windows.Forms.Button();
            this.btnMakeMatrixB = new System.Windows.Forms.Button();
            this.txtRowsA = new System.Windows.Forms.TextBox();
            this.txtRowsB = new System.Windows.Forms.TextBox();
            this.txtColsA = new System.Windows.Forms.TextBox();
            this.txtColsB = new System.Windows.Forms.TextBox();
            this.btnMakeBIdentity = new System.Windows.Forms.Button();
            this.gbSelectOperation = new System.Windows.Forms.GroupBox();
            this.rbSubtract = new System.Windows.Forms.RadioButton();
            this.rbAdd = new System.Windows.Forms.RadioButton();
            this.rbMultiply = new System.Windows.Forms.RadioButton();
            this.lbRows = new System.Windows.Forms.Label();
            this.lbCols = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClearMatrices = new System.Windows.Forms.Button();
            this.gbSelectOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMatrixA
            // 
            this.txtMatrixA.Location = new System.Drawing.Point(12, 36);
            this.txtMatrixA.Multiline = true;
            this.txtMatrixA.Name = "txtMatrixA";
            this.txtMatrixA.ReadOnly = true;
            this.txtMatrixA.Size = new System.Drawing.Size(159, 139);
            this.txtMatrixA.TabIndex = 111;
            // 
            // lbMatrixA
            // 
            this.lbMatrixA.AutoSize = true;
            this.lbMatrixA.Location = new System.Drawing.Point(12, 13);
            this.lbMatrixA.Name = "lbMatrixA";
            this.lbMatrixA.Size = new System.Drawing.Size(45, 13);
            this.lbMatrixA.TabIndex = 1;
            this.lbMatrixA.Text = "Matrix A";
            // 
            // txtMatrixB
            // 
            this.txtMatrixB.Location = new System.Drawing.Point(177, 36);
            this.txtMatrixB.Multiline = true;
            this.txtMatrixB.Name = "txtMatrixB";
            this.txtMatrixB.ReadOnly = true;
            this.txtMatrixB.Size = new System.Drawing.Size(172, 139);
            this.txtMatrixB.TabIndex = 112;
            // 
            // txtMatrixC
            // 
            this.txtMatrixC.Location = new System.Drawing.Point(355, 36);
            this.txtMatrixC.Multiline = true;
            this.txtMatrixC.Name = "txtMatrixC";
            this.txtMatrixC.ReadOnly = true;
            this.txtMatrixC.Size = new System.Drawing.Size(164, 139);
            this.txtMatrixC.TabIndex = 113;
            // 
            // lbMatrixB
            // 
            this.lbMatrixB.AutoSize = true;
            this.lbMatrixB.Location = new System.Drawing.Point(174, 13);
            this.lbMatrixB.Name = "lbMatrixB";
            this.lbMatrixB.Size = new System.Drawing.Size(45, 13);
            this.lbMatrixB.TabIndex = 4;
            this.lbMatrixB.Text = "Matrix B";
            // 
            // lbMatrixC
            // 
            this.lbMatrixC.AutoSize = true;
            this.lbMatrixC.Location = new System.Drawing.Point(352, 13);
            this.lbMatrixC.Name = "lbMatrixC";
            this.lbMatrixC.Size = new System.Drawing.Size(45, 13);
            this.lbMatrixC.TabIndex = 5;
            this.lbMatrixC.Text = "Matrix C";
            // 
            // btnMakeMatrixA
            // 
            this.btnMakeMatrixA.Location = new System.Drawing.Point(15, 225);
            this.btnMakeMatrixA.Name = "btnMakeMatrixA";
            this.btnMakeMatrixA.Size = new System.Drawing.Size(124, 23);
            this.btnMakeMatrixA.TabIndex = 6;
            this.btnMakeMatrixA.Text = "Make Matrix A";
            this.btnMakeMatrixA.UseVisualStyleBackColor = true;
            this.btnMakeMatrixA.Click += new System.EventHandler(this.btnMakeMatrixA_Click);
            // 
            // btnMakeMatrixB
            // 
            this.btnMakeMatrixB.Location = new System.Drawing.Point(15, 255);
            this.btnMakeMatrixB.Name = "btnMakeMatrixB";
            this.btnMakeMatrixB.Size = new System.Drawing.Size(124, 23);
            this.btnMakeMatrixB.TabIndex = 7;
            this.btnMakeMatrixB.Text = "Make Matrix B";
            this.btnMakeMatrixB.UseVisualStyleBackColor = true;
            this.btnMakeMatrixB.Click += new System.EventHandler(this.btnMakeMatrixB_Click);
            // 
            // txtRowsA
            // 
            this.txtRowsA.Location = new System.Drawing.Point(154, 228);
            this.txtRowsA.Name = "txtRowsA";
            this.txtRowsA.Size = new System.Drawing.Size(100, 20);
            this.txtRowsA.TabIndex = 8;
            // 
            // txtRowsB
            // 
            this.txtRowsB.Location = new System.Drawing.Point(154, 254);
            this.txtRowsB.Name = "txtRowsB";
            this.txtRowsB.Size = new System.Drawing.Size(100, 20);
            this.txtRowsB.TabIndex = 10;
            // 
            // txtColsA
            // 
            this.txtColsA.Location = new System.Drawing.Point(272, 228);
            this.txtColsA.Name = "txtColsA";
            this.txtColsA.Size = new System.Drawing.Size(100, 20);
            this.txtColsA.TabIndex = 9;
            // 
            // txtColsB
            // 
            this.txtColsB.Location = new System.Drawing.Point(272, 254);
            this.txtColsB.Name = "txtColsB";
            this.txtColsB.Size = new System.Drawing.Size(100, 20);
            this.txtColsB.TabIndex = 11;
            // 
            // btnMakeBIdentity
            // 
            this.btnMakeBIdentity.Location = new System.Drawing.Point(395, 251);
            this.btnMakeBIdentity.Name = "btnMakeBIdentity";
            this.btnMakeBIdentity.Size = new System.Drawing.Size(105, 23);
            this.btnMakeBIdentity.TabIndex = 12;
            this.btnMakeBIdentity.Text = "Make B Identity";
            this.btnMakeBIdentity.UseVisualStyleBackColor = true;
            this.btnMakeBIdentity.Click += new System.EventHandler(this.btnMakeBIdentity_Click);
            // 
            // gbSelectOperation
            // 
            this.gbSelectOperation.Controls.Add(this.rbSubtract);
            this.gbSelectOperation.Controls.Add(this.rbAdd);
            this.gbSelectOperation.Controls.Add(this.rbMultiply);
            this.gbSelectOperation.Location = new System.Drawing.Point(24, 299);
            this.gbSelectOperation.Name = "gbSelectOperation";
            this.gbSelectOperation.Size = new System.Drawing.Size(230, 51);
            this.gbSelectOperation.TabIndex = 13;
            this.gbSelectOperation.TabStop = false;
            this.gbSelectOperation.Text = "Select Operation";
            // 
            // rbSubtract
            // 
            this.rbSubtract.AutoSize = true;
            this.rbSubtract.Location = new System.Drawing.Point(142, 24);
            this.rbSubtract.Name = "rbSubtract";
            this.rbSubtract.Size = new System.Drawing.Size(65, 17);
            this.rbSubtract.TabIndex = 2;
            this.rbSubtract.TabStop = true;
            this.rbSubtract.Text = "Subtract";
            this.rbSubtract.UseVisualStyleBackColor = true;
            // 
            // rbAdd
            // 
            this.rbAdd.AutoSize = true;
            this.rbAdd.Location = new System.Drawing.Point(80, 24);
            this.rbAdd.Name = "rbAdd";
            this.rbAdd.Size = new System.Drawing.Size(44, 17);
            this.rbAdd.TabIndex = 1;
            this.rbAdd.TabStop = true;
            this.rbAdd.Text = "Add";
            this.rbAdd.UseVisualStyleBackColor = true;
            // 
            // rbMultiply
            // 
            this.rbMultiply.AutoSize = true;
            this.rbMultiply.Location = new System.Drawing.Point(6, 24);
            this.rbMultiply.Name = "rbMultiply";
            this.rbMultiply.Size = new System.Drawing.Size(60, 17);
            this.rbMultiply.TabIndex = 0;
            this.rbMultiply.TabStop = true;
            this.rbMultiply.Text = "Multiply";
            this.rbMultiply.UseVisualStyleBackColor = true;
            // 
            // lbRows
            // 
            this.lbRows.AutoSize = true;
            this.lbRows.Location = new System.Drawing.Point(151, 212);
            this.lbRows.Name = "lbRows";
            this.lbRows.Size = new System.Drawing.Size(34, 13);
            this.lbRows.TabIndex = 14;
            this.lbRows.Text = "Rows";
            // 
            // lbCols
            // 
            this.lbCols.AutoSize = true;
            this.lbCols.Location = new System.Drawing.Point(269, 212);
            this.lbCols.Name = "lbCols";
            this.lbCols.Size = new System.Drawing.Size(27, 13);
            this.lbCols.TabIndex = 15;
            this.lbCols.Text = "Cols";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(24, 356);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(91, 23);
            this.btnCalculate.TabIndex = 14;
            this.btnCalculate.Text = "&Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(444, 356);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClearMatrices
            // 
            this.btnClearMatrices.Location = new System.Drawing.Point(313, 356);
            this.btnClearMatrices.Name = "btnClearMatrices";
            this.btnClearMatrices.Size = new System.Drawing.Size(99, 23);
            this.btnClearMatrices.TabIndex = 15;
            this.btnClearMatrices.Text = "Clear &Matrices";
            this.btnClearMatrices.UseVisualStyleBackColor = true;
            this.btnClearMatrices.Click += new System.EventHandler(this.btnClearMatrices_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(540, 420);
            this.Controls.Add(this.btnClearMatrices);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lbCols);
            this.Controls.Add(this.lbRows);
            this.Controls.Add(this.gbSelectOperation);
            this.Controls.Add(this.btnMakeBIdentity);
            this.Controls.Add(this.txtColsB);
            this.Controls.Add(this.txtColsA);
            this.Controls.Add(this.txtRowsB);
            this.Controls.Add(this.txtRowsA);
            this.Controls.Add(this.btnMakeMatrixB);
            this.Controls.Add(this.btnMakeMatrixA);
            this.Controls.Add(this.lbMatrixC);
            this.Controls.Add(this.lbMatrixB);
            this.Controls.Add(this.txtMatrixC);
            this.Controls.Add(this.txtMatrixB);
            this.Controls.Add(this.lbMatrixA);
            this.Controls.Add(this.txtMatrixA);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matrix Ops";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbSelectOperation.ResumeLayout(false);
            this.gbSelectOperation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMatrixA;
        private System.Windows.Forms.Label lbMatrixA;
        private System.Windows.Forms.TextBox txtMatrixB;
        private System.Windows.Forms.TextBox txtMatrixC;
        private System.Windows.Forms.Label lbMatrixB;
        private System.Windows.Forms.Label lbMatrixC;
        private System.Windows.Forms.Button btnMakeMatrixA;
        private System.Windows.Forms.Button btnMakeMatrixB;
        private System.Windows.Forms.TextBox txtRowsA;
        private System.Windows.Forms.TextBox txtRowsB;
        private System.Windows.Forms.TextBox txtColsA;
        private System.Windows.Forms.TextBox txtColsB;
        private System.Windows.Forms.Button btnMakeBIdentity;
        private System.Windows.Forms.GroupBox gbSelectOperation;
        private System.Windows.Forms.RadioButton rbSubtract;
        private System.Windows.Forms.RadioButton rbAdd;
        private System.Windows.Forms.RadioButton rbMultiply;
        private System.Windows.Forms.Label lbRows;
        private System.Windows.Forms.Label lbCols;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClearMatrices;
    }
}

