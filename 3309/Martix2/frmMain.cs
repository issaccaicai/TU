using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Martix2
{
    public partial class frmMain : Form
    {
        private Matrix A;
        private Matrix B;
        private Matrix C;

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rbnMultiply.Checked = true;
            txtRowsA.Text = "3";
            txtColsA.Text = "3";
            txtRowsB.Text = "3";
            txtColsB.Text = "3";
        }


        // matrixA
        private void btnMakeMatrixA_Click(object sender, EventArgs e)
        {
            try
            {
                this.A = new Matrix(int.Parse(this.txtRowsA.Text), int.Parse(this.txtColsA.Text));
                this.A.populateRand();
                this.txtMatrixA.Text = this.A.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \r\n" + ex.ToString());
            }

        }


        // matrixB 
        private void btnMakeMatrixB_Click(object sender, EventArgs e)
        {

            try
            {
                this.B = new Matrix(int.Parse(this.txtRowsB.Text), int.Parse(this.txtColsB.Text));
                this.B.populateRand();
                this.txtMatrixB.Text = this.B.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \r\n" + ex.ToString());
            }
        }


        // generate matrix
        private double[,] CreateMatrix(int row, int col)
        {
            double[,] matrix = new double[row, col];
            Random autoRand = new Random();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = Math.Round(autoRand.NextDouble() * 10.0, 1);
                }
            }
            return matrix;
        }


        // matrix B copy of Matrix A
        private void btnMakeBCopyA_Click(object sender, EventArgs e)
        {
            if (!object.Equals((object)this.A, (object)null))
            {
                this.B = this.A.clone();
                this.txtMatrixB.Text = this.B.ToString();
            }
            else
            {
                MessageBox.Show("Matrix A is null");
            }
        }

        // method makes identity matrix B
        private void btnMakeBIdentity_Click(object sender, EventArgs e)
        {
            int n = 0;
            try
            {
                if (this.txtRowsB.Text == this.txtColsB.Text && this.txtColsB.Text != "")
                    n = int.Parse(this.txtColsB.Text);
                this.B = Matrix.makeID(n);
                this.txtMatrixB.Text = this.B.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dimensions do not match for identity.\r\n" + ex.ToString());
            }
        }

        // calculation methods: multiply, addtion,subtract and A and B euqality checking
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbnMultiply.Checked)
                {
                    this.C = this.A * this.B;
                    this.txtMatrixC.Text = this.C.ToString();
                }
                else if (this.rbnAdd.Checked)
                {
                    this.C = this.A + this.B;
                    this.txtMatrixC.Text = this.C.ToString();
                }
                else if (this.rbnSubtract.Checked)
                {
                    this.C = this.A - this.B;
                    this.txtMatrixC.Text = this.C.ToString();
                }
                else
                {
                    if (!this.rbnAisB.Checked)
                        return;
                    this.txtMatrixC.Text = "";
                    if (this.A == this.B)
                        this.txtMatrixC.Text = "A is equal to B";
                    else
                        this.txtMatrixC.Text = "A is not equal to B";
                }
            }
            catch (Exception ex)
            {
                int num = (int )MessageBox.Show("Calculation error: \r\n" + ex.ToString());
            }
        }
        
        // clear all the contents
        private void btnClearMatrices_Click(object sender, EventArgs e)
        {
            this.A = (Matrix)null;
            this.B = (Matrix)null;
            this.C = (Matrix)null;
            this.txtMatrixA.Text = "";
            this.txtMatrixB.Text = "";
            this.txtMatrixC.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
