namespace MaintainStudentScores
{
    partial class frmStudentScores
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
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lbStudents = new System.Windows.Forms.Label();
            this.lbScoreTotal = new System.Windows.Forms.Label();
            this.lbScoreCount = new System.Windows.Forms.Label();
            this.lbAverage = new System.Windows.Forms.Label();
            this.txtScoreTotal = new System.Windows.Forms.TextBox();
            this.txtScoreCount = new System.Windows.Forms.TextBox();
            this.txtAverage = new System.Windows.Forms.TextBox();
            this.lbxStudent = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(299, 41);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 0;
            this.btnAddNew.Text = "&Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(299, 79);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(299, 118);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(299, 230);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lbStudents
            // 
            this.lbStudents.AutoSize = true;
            this.lbStudents.Location = new System.Drawing.Point(9, 9);
            this.lbStudents.Name = "lbStudents";
            this.lbStudents.Size = new System.Drawing.Size(52, 13);
            this.lbStudents.TabIndex = 4;
            this.lbStudents.Text = "Students:";
            // 
            // lbScoreTotal
            // 
            this.lbScoreTotal.AutoSize = true;
            this.lbScoreTotal.Location = new System.Drawing.Point(144, 184);
            this.lbScoreTotal.Name = "lbScoreTotal";
            this.lbScoreTotal.Size = new System.Drawing.Size(65, 13);
            this.lbScoreTotal.TabIndex = 5;
            this.lbScoreTotal.Text = "Score Total:";
            // 
            // lbScoreCount
            // 
            this.lbScoreCount.AutoSize = true;
            this.lbScoreCount.Location = new System.Drawing.Point(140, 210);
            this.lbScoreCount.Name = "lbScoreCount";
            this.lbScoreCount.Size = new System.Drawing.Size(69, 13);
            this.lbScoreCount.TabIndex = 6;
            this.lbScoreCount.Text = "Score Count:";
            // 
            // lbAverage
            // 
            this.lbAverage.AutoSize = true;
            this.lbAverage.Location = new System.Drawing.Point(159, 236);
            this.lbAverage.Name = "lbAverage";
            this.lbAverage.Size = new System.Drawing.Size(50, 13);
            this.lbAverage.TabIndex = 7;
            this.lbAverage.Text = "Average:";
            // 
            // txtScoreTotal
            // 
            this.txtScoreTotal.Location = new System.Drawing.Point(215, 181);
            this.txtScoreTotal.Name = "txtScoreTotal";
            this.txtScoreTotal.ReadOnly = true;
            this.txtScoreTotal.Size = new System.Drawing.Size(78, 20);
            this.txtScoreTotal.TabIndex = 8;
            // 
            // txtScoreCount
            // 
            this.txtScoreCount.Location = new System.Drawing.Point(215, 207);
            this.txtScoreCount.Name = "txtScoreCount";
            this.txtScoreCount.ReadOnly = true;
            this.txtScoreCount.Size = new System.Drawing.Size(78, 20);
            this.txtScoreCount.TabIndex = 9;
            // 
            // txtAverage
            // 
            this.txtAverage.Location = new System.Drawing.Point(215, 233);
            this.txtAverage.Name = "txtAverage";
            this.txtAverage.ReadOnly = true;
            this.txtAverage.Size = new System.Drawing.Size(78, 20);
            this.txtAverage.TabIndex = 10;
            // 
            // lbxStudent
            // 
            this.lbxStudent.FormattingEnabled = true;
            this.lbxStudent.Location = new System.Drawing.Point(12, 41);
            this.lbxStudent.Name = "lbxStudent";
            this.lbxStudent.Size = new System.Drawing.Size(281, 134);
            this.lbxStudent.TabIndex = 11;
            this.lbxStudent.SelectedIndexChanged += new System.EventHandler(this.lbxStudent_SelectedIndexChanged);
            // 
            // frmStudentScores
            // 
            this.AcceptButton = this.btnAddNew;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(393, 274);
            this.Controls.Add(this.lbxStudent);
            this.Controls.Add(this.txtAverage);
            this.Controls.Add(this.txtScoreCount);
            this.Controls.Add(this.txtScoreTotal);
            this.Controls.Add(this.lbAverage);
            this.Controls.Add(this.lbScoreCount);
            this.Controls.Add(this.lbScoreTotal);
            this.Controls.Add(this.lbStudents);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAddNew);
            this.Name = "frmStudentScores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Scores";
            this.Load += new System.EventHandler(this.frmStudentScores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lbStudents;
        private System.Windows.Forms.Label lbScoreTotal;
        private System.Windows.Forms.Label lbScoreCount;
        private System.Windows.Forms.Label lbAverage;
        private System.Windows.Forms.TextBox txtScoreTotal;
        private System.Windows.Forms.TextBox txtScoreCount;
        private System.Windows.Forms.TextBox txtAverage;
        private System.Windows.Forms.ListBox lbxStudent;
    }
}

