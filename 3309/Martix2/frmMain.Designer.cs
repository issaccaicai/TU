namespace Martix2
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
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
            this.btnClearMatrices = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lbCols = new System.Windows.Forms.Label();
            this.lbRows = new System.Windows.Forms.Label();
            this.gbSelectOperation = new System.Windows.Forms.GroupBox();
            this.rbnAisB = new System.Windows.Forms.RadioButton();
            this.rbnSubtract = new System.Windows.Forms.RadioButton();
            this.rbnAdd = new System.Windows.Forms.RadioButton();
            this.rbnMultiply = new System.Windows.Forms.RadioButton();
            this.btnMakeBIdentity = new System.Windows.Forms.Button();
            this.txtColsB = new System.Windows.Forms.TextBox();
            this.txtColsA = new System.Windows.Forms.TextBox();
            this.txtRowsB = new System.Windows.Forms.TextBox();
            this.txtRowsA = new System.Windows.Forms.TextBox();
            this.btnMakeMatrixB = new System.Windows.Forms.Button();
            this.btnMakeMatrixA = new System.Windows.Forms.Button();
            this.lbMatrixC = new System.Windows.Forms.Label();
            this.lbMatrixB = new System.Windows.Forms.Label();
            this.txtMatrixC = new System.Windows.Forms.TextBox();
            this.txtMatrixB = new System.Windows.Forms.TextBox();
            this.lbMatrixA = new System.Windows.Forms.Label();
            this.txtMatrixA = new System.Windows.Forms.TextBox();
            this.btnMakeBCopyA = new System.Windows.Forms.Button();
            this.gbSelectOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClearMatrices
            // 
            this.btnClearMatrices.Location = new System.Drawing.Point(311, 361);
            this.btnClearMatrices.Name = "btnClearMatrices";
            this.btnClearMatrices.Size = new System.Drawing.Size(99, 23);
            this.btnClearMatrices.TabIndex = 37;
            this.btnClearMatrices.Text = "Clear Matrices";
            this.btnClearMatrices.UseVisualStyleBackColor = true;
            this.btnClearMatrices.Click += new System.EventHandler(this.btnClearMatrices_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(432, 361);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 36;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(12, 361);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(91, 23);
            this.btnCalculate.TabIndex = 35;
            this.btnCalculate.Text = "&Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lbCols
            // 
            this.lbCols.AutoSize = true;
            this.lbCols.Location = new System.Drawing.Point(272, 204);
            this.lbCols.Name = "lbCols";
            this.lbCols.Size = new System.Drawing.Size(27, 13);
            this.lbCols.TabIndex = 34;
            this.lbCols.Text = "Cols";
            // 
            // lbRows
            // 
            this.lbRows.AutoSize = true;
            this.lbRows.Location = new System.Drawing.Point(155, 204);
            this.lbRows.Name = "lbRows";
            this.lbRows.Size = new System.Drawing.Size(34, 13);
            this.lbRows.TabIndex = 33;
            this.lbRows.Text = "Rows";
            // 
            // gbSelectOperation
            // 
            this.gbSelectOperation.Controls.Add(this.rbnAisB);
            this.gbSelectOperation.Controls.Add(this.rbnSubtract);
            this.gbSelectOperation.Controls.Add(this.rbnAdd);
            this.gbSelectOperation.Controls.Add(this.rbnMultiply);
            this.gbSelectOperation.Location = new System.Drawing.Point(13, 292);
            this.gbSelectOperation.Name = "gbSelectOperation";
            this.gbSelectOperation.Size = new System.Drawing.Size(336, 51);
            this.gbSelectOperation.TabIndex = 32;
            this.gbSelectOperation.TabStop = false;
            this.gbSelectOperation.Text = "Select Operation";
            // 
            // rbnAisB
            // 
            this.rbnAisB.AutoSize = true;
            this.rbnAisB.Location = new System.Drawing.Point(251, 24);
            this.rbnAisB.Name = "rbnAisB";
            this.rbnAisB.Size = new System.Drawing.Size(51, 17);
            this.rbnAisB.TabIndex = 3;
            this.rbnAisB.TabStop = true;
            this.rbnAisB.Text = "A==B";
            this.rbnAisB.UseVisualStyleBackColor = true;
            // 
            // rbnSubtract
            // 
            this.rbnSubtract.AutoSize = true;
            this.rbnSubtract.Location = new System.Drawing.Point(160, 24);
            this.rbnSubtract.Name = "rbnSubtract";
            this.rbnSubtract.Size = new System.Drawing.Size(65, 17);
            this.rbnSubtract.TabIndex = 2;
            this.rbnSubtract.TabStop = true;
            this.rbnSubtract.Text = "Subtract";
            this.rbnSubtract.UseVisualStyleBackColor = true;
            // 
            // rbnAdd
            // 
            this.rbnAdd.AutoSize = true;
            this.rbnAdd.Location = new System.Drawing.Point(91, 24);
            this.rbnAdd.Name = "rbnAdd";
            this.rbnAdd.Size = new System.Drawing.Size(44, 17);
            this.rbnAdd.TabIndex = 1;
            this.rbnAdd.TabStop = true;
            this.rbnAdd.Text = "Add";
            this.rbnAdd.UseVisualStyleBackColor = true;
            // 
            // rbnMultiply
            // 
            this.rbnMultiply.AutoSize = true;
            this.rbnMultiply.Location = new System.Drawing.Point(6, 24);
            this.rbnMultiply.Name = "rbnMultiply";
            this.rbnMultiply.Size = new System.Drawing.Size(60, 17);
            this.rbnMultiply.TabIndex = 0;
            this.rbnMultiply.TabStop = true;
            this.rbnMultiply.Text = "Multiply";
            this.rbnMultiply.UseVisualStyleBackColor = true;
            // 
            // btnMakeBIdentity
            // 
            this.btnMakeBIdentity.Location = new System.Drawing.Point(386, 252);
            this.btnMakeBIdentity.Name = "btnMakeBIdentity";
            this.btnMakeBIdentity.Size = new System.Drawing.Size(121, 23);
            this.btnMakeBIdentity.TabIndex = 31;
            this.btnMakeBIdentity.Text = "Make B Identity";
            this.btnMakeBIdentity.UseVisualStyleBackColor = true;
            this.btnMakeBIdentity.Click += new System.EventHandler(this.btnMakeBIdentity_Click);
            // 
            // txtColsB
            // 
            this.txtColsB.Location = new System.Drawing.Point(264, 254);
            this.txtColsB.Name = "txtColsB";
            this.txtColsB.Size = new System.Drawing.Size(118, 20);
            this.txtColsB.TabIndex = 30;
            // 
            // txtColsA
            // 
            this.txtColsA.Location = new System.Drawing.Point(264, 222);
            this.txtColsA.Name = "txtColsA";
            this.txtColsA.Size = new System.Drawing.Size(118, 20);
            this.txtColsA.TabIndex = 29;
            // 
            // txtRowsB
            // 
            this.txtRowsB.Location = new System.Drawing.Point(146, 256);
            this.txtRowsB.Name = "txtRowsB";
            this.txtRowsB.Size = new System.Drawing.Size(112, 20);
            this.txtRowsB.TabIndex = 28;
            // 
            // txtRowsA
            // 
            this.txtRowsA.Location = new System.Drawing.Point(146, 222);
            this.txtRowsA.Name = "txtRowsA";
            this.txtRowsA.Size = new System.Drawing.Size(112, 20);
            this.txtRowsA.TabIndex = 27;
            // 
            // btnMakeMatrixB
            // 
            this.btnMakeMatrixB.Location = new System.Drawing.Point(13, 254);
            this.btnMakeMatrixB.Name = "btnMakeMatrixB";
            this.btnMakeMatrixB.Size = new System.Drawing.Size(124, 23);
            this.btnMakeMatrixB.TabIndex = 26;
            this.btnMakeMatrixB.Text = "Make Matrix B";
            this.btnMakeMatrixB.UseVisualStyleBackColor = true;
            this.btnMakeMatrixB.Click += new System.EventHandler(this.btnMakeMatrixB_Click);
            // 
            // btnMakeMatrixA
            // 
            this.btnMakeMatrixA.Location = new System.Drawing.Point(12, 219);
            this.btnMakeMatrixA.Name = "btnMakeMatrixA";
            this.btnMakeMatrixA.Size = new System.Drawing.Size(124, 23);
            this.btnMakeMatrixA.TabIndex = 25;
            this.btnMakeMatrixA.Text = "Make Matrix A";
            this.btnMakeMatrixA.UseVisualStyleBackColor = true;
            this.btnMakeMatrixA.Click += new System.EventHandler(this.btnMakeMatrixA_Click);
            // 
            // lbMatrixC
            // 
            this.lbMatrixC.AutoSize = true;
            this.lbMatrixC.Location = new System.Drawing.Point(365, 9);
            this.lbMatrixC.Name = "lbMatrixC";
            this.lbMatrixC.Size = new System.Drawing.Size(45, 13);
            this.lbMatrixC.TabIndex = 24;
            this.lbMatrixC.Text = "Matrix C";
            // 
            // lbMatrixB
            // 
            this.lbMatrixB.AutoSize = true;
            this.lbMatrixB.Location = new System.Drawing.Point(193, 9);
            this.lbMatrixB.Name = "lbMatrixB";
            this.lbMatrixB.Size = new System.Drawing.Size(45, 13);
            this.lbMatrixB.TabIndex = 23;
            this.lbMatrixB.Text = "Matrix B";
            // 
            // txtMatrixC
            // 
            this.txtMatrixC.Location = new System.Drawing.Point(355, 37);
            this.txtMatrixC.Multiline = true;
            this.txtMatrixC.Name = "txtMatrixC";
            this.txtMatrixC.ReadOnly = true;
            this.txtMatrixC.Size = new System.Drawing.Size(152, 135);
            this.txtMatrixC.TabIndex = 22;
            // 
            // txtMatrixB
            // 
            this.txtMatrixB.Location = new System.Drawing.Point(183, 37);
            this.txtMatrixB.Multiline = true;
            this.txtMatrixB.Name = "txtMatrixB";
            this.txtMatrixB.ReadOnly = true;
            this.txtMatrixB.Size = new System.Drawing.Size(166, 135);
            this.txtMatrixB.TabIndex = 21;
            // 
            // lbMatrixA
            // 
            this.lbMatrixA.AutoSize = true;
            this.lbMatrixA.Location = new System.Drawing.Point(25, 9);
            this.lbMatrixA.Name = "lbMatrixA";
            this.lbMatrixA.Size = new System.Drawing.Size(45, 13);
            this.lbMatrixA.TabIndex = 20;
            this.lbMatrixA.Text = "Matrix A";
            // 
            // txtMatrixA
            // 
            this.txtMatrixA.Location = new System.Drawing.Point(13, 37);
            this.txtMatrixA.Multiline = true;
            this.txtMatrixA.Name = "txtMatrixA";
            this.txtMatrixA.ReadOnly = true;
            this.txtMatrixA.Size = new System.Drawing.Size(164, 135);
            this.txtMatrixA.TabIndex = 19;
            // 
            // btnMakeBCopyA
            // 
            this.btnMakeBCopyA.Location = new System.Drawing.Point(388, 219);
            this.btnMakeBCopyA.Name = "btnMakeBCopyA";
            this.btnMakeBCopyA.Size = new System.Drawing.Size(121, 23);
            this.btnMakeBCopyA.TabIndex = 38;
            this.btnMakeBCopyA.Text = "Make B Copy of A";
            this.btnMakeBCopyA.UseVisualStyleBackColor = true;
            this.btnMakeBCopyA.Click += new System.EventHandler(this.btnMakeBCopyA_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 403);
            this.Controls.Add(this.btnMakeBCopyA);
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
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matrix Ops with Objects";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbSelectOperation.ResumeLayout(false);
            this.gbSelectOperation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClearMatrices;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lbCols;
        private System.Windows.Forms.Label lbRows;
        private System.Windows.Forms.GroupBox gbSelectOperation;
        private System.Windows.Forms.RadioButton rbnAisB;
        private System.Windows.Forms.RadioButton rbnSubtract;
        private System.Windows.Forms.RadioButton rbnAdd;
        private System.Windows.Forms.RadioButton rbnMultiply;
        private System.Windows.Forms.Button btnMakeBIdentity;
        private System.Windows.Forms.TextBox txtColsB;
        private System.Windows.Forms.TextBox txtColsA;
        private System.Windows.Forms.TextBox txtRowsB;
        private System.Windows.Forms.TextBox txtRowsA;
        private System.Windows.Forms.Button btnMakeMatrixB;
        private System.Windows.Forms.Button btnMakeMatrixA;
        private System.Windows.Forms.Label lbMatrixC;
        private System.Windows.Forms.Label lbMatrixB;
        private System.Windows.Forms.TextBox txtMatrixC;
        private System.Windows.Forms.TextBox txtMatrixB;
        private System.Windows.Forms.Label lbMatrixA;
        private System.Windows.Forms.TextBox txtMatrixA;
        private System.Windows.Forms.Button btnMakeBCopyA;
    }
}

