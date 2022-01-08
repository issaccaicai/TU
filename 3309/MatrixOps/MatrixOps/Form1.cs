/* Two matrices with random number values calculator.
 * Users input the number of the rows and columns for matrix A and B.
 * Users can apply on of the operations, which are multipicaion, addition, and subtraction.
 * to calculate the results.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixOps
{
    public partial class Form1 : Form
    {
        //declaring MatrixA, MatrixB, and MatrixC
        double[,] MatrixA;
        double[,] MatrixB;
        double[,] MatrixC;

        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            //initializing the default rows and cols to 3
            txtColsA.Text = "3";
            txtColsB.Text = "3";
            txtRowsA.Text = "3";
            txtRowsB.Text = "3";
        }


        //Button click method to get matrix A
        private void btnMakeMatrixA_Click(object sender, EventArgs e)
        {
            // To check the validation of input values from the textbox
            if (IsValidData())
            {
                // try-Catch to convert the text property into an Int32
                try
                {
                    int rowsA = Convert.ToInt32(txtRowsA.Text);
                    int colsA = Convert.ToInt32(txtColsA.Text);

                    //To get random MatrixA from generateMatrix method
                    MatrixA = generateMatrix(rowsA, colsA);

                    //To convert MatrixA to a String so it can be displayed in textbox
                    txtMatrixA.Text = ConvertMatrixToString(rowsA, colsA, MatrixA);
                }
                //catch any invalid inputs
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }


        //Button click method to get matrix B
        private void btnMakeMatrixB_Click(object sender, EventArgs e)
        {
            // To check the validation of input values from the textbox
            if (IsValidData())
            {
                // try-Catch to convert the text property into an Int32
                try
                {
                    int rowsB = Convert.ToInt32(txtRowsB.Text);
                    int colsB = Convert.ToInt32(txtColsB.Text);

                    //To get random MatrixA from generateMatrix method
                    MatrixB = generateMatrix(rowsB, colsB);

                    //To convert MatrixA to a String so it can be displayed in textbox
                    txtMatrixB.Text = ConvertMatrixToString(rowsB, colsB, MatrixB);
                }
                //catch any invalid inputs
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }


        //Button Click to get a identity matrix B
        private void btnMakeBIdentity_Click(object sender, EventArgs e)
        {
            // To check the validation of input values from the textbox
            if (IsValidData())
            {
                // try-Catch to convert the text property into an Int32
                try
                {
                    int rowsB = Convert.ToInt32(txtRowsB.Text);
                    int colsB = Convert.ToInt32(txtColsB.Text);
                    
                    // if statement checking identity
                    if (rowsB == colsB)
                    {
                        //To get identity MatrixB from generateBIdentity method
                        MatrixB = generateBIdentity(rowsB, colsB);
                        //To convert identity MatrixB to a String and can display in txtMatrixB textbox
                        txtMatrixB.Text = ConvertMatrixToString(rowsB, colsB, MatrixB);
                    }
                    //else print out error message
                    else
                    {
                        MessageBox.Show("Identity MatrixB Error");
                    }
                }
                //catch any invalid inputs
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }


        //a method that generates matrix
        private double[,] generateMatrix(int row, int col)
        {
            double[,] matrix = new double[row, col];

            //Declare random numbers
            Random autoRand = new Random();

            // for loop to generate matrix
            for (int i = 0; i < row; i++)//numbers of row 
            {
                for (int j = 0; j < col; j++)//numbers of col
                {
                    //  round up one decimal value
                    matrix[i, j] = Math.Round(autoRand.NextDouble() * 10.0, 1);
                }
            }
            return matrix;
        }


        //  method converts matrix into String so it can be displayed on matrix textboxs
        private string ConvertMatrixToString(int row, int col, double[,] matrix)
        {
            //  using stringBulider class to store
            StringBuilder stringBulider = new StringBuilder();
            string s;

            //  for loop to generate matrix
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    //  matrixs displaying format with one decimal value
                    s = String.Format("{0:F1}", matrix[i, j]);

                    //  adding the matrixs and space
                    stringBulider.Append(s + "    ");
                }
                //  adding next line for rows
                stringBulider.Append(Environment.NewLine);
            }
            return stringBulider.ToString();
        }

        

        //  method that generate an Identity matrix B
        private double[,] generateBIdentity(int row, int col)
        {
            double[,] matrix = new double[row, col];

            //for loop to create matrix
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    //if rows = cols, display 1.0
                    if (i == j)
                        matrix[i, j] = 1.0;

                    //else, display 0.0
                    else
                        matrix[i, j] = 0.0;
                }
            }
            return matrix;
        }

       
       
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //  To check the validation of inputs
            if (IsValidData() && IsMatrix())
            {
                // Converting to Int32
                int row = Convert.ToInt32(txtRowsA.Text);
                int col = Convert.ToInt32(txtColsA.Text);

                //  generate the result of matrix A and B which is matrix C
                MatrixC = new double[row, col];

                //if the users click on the multiply check box, the multipicaton applied
                if (rbMultiply.Checked == true)
                {
                    try
                    {
                        if (MatrixA.GetLength(1) == MatrixB.GetLength(0))
                        {
                            //  generate Matrix C, its number of rows = the rows of Matrix A, and number of columns = the columns of Matrix B
                            MatrixC = new double[MatrixA.GetLength(0), MatrixB.GetLength(1)];

                            //for loop that generates the numbers of the rows
                            for (int i = 0; i < MatrixC.GetLength(0); i++)
                            {
                                //for loop that generates the numbers of the columns
                                for (int j = 0; j < MatrixC.GetLength(1); j++)
                                {
                                    for (int k = 0; k < MatrixA.GetLength(1); k++)
                                    {
                                        // multiplication of matrix A and B
                                        MatrixC[i, j] = MatrixC[i, j] + MatrixA[i, k] * MatrixB[k, j];
                                    }
                                }
                            }
                            //To convert MatrixC to a String that can display in textbox.
                            txtMatrixC.Text = ConvertMatrixToString(MatrixA.GetLength(0), MatrixB.GetLength(1), MatrixC);
                        }
                        //else, will be error
                        else
                        {
                            MessageBox.Show("Multiplication Error", "Entery Error");
                            txtMatrixC.Clear();
                        }
                    }
                    //catch any invalid inputs
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n" + ex.StackTrace, "Error");
                    }
                }


                //if the users click on the add check box
                else if (rbAdd.Checked == true)
                {
                    try
                    {
                        //matrices addition
                        if (MatrixA.GetLength(1) == MatrixB.GetLength(1) && MatrixA.GetLength(0) == MatrixB.GetLength(0))
                        {
                            //for loop that generate the numbers of the rows
                            for (int i = 0; i < row; i++)
                            {
                                //for loop that generates the numbers of the columns
                                for (int j = 0; j < col; j++)
                                {
                                    //matrices addition
                                    MatrixC[i, j] = MatrixA[i, j] + MatrixB[i, j];
                                }
                            }
                            //To convert MatrixC to a String that can display in txtMatrixC textbox.
                            txtMatrixC.Text = ConvertMatrixToString(row, col, MatrixC);
                        }
                        //else will be an error
                        else
                        {
                            MessageBox.Show("Adding Error", "Entery Error");
                        }
                    }
                    //catch any invalid inputs
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n" + ex.StackTrace, "Exception");
                    }
                }


                //if the users click on the Subtract check box
                else if (rbSubtract.Checked == true)
                {
                    try
                    {
                        //matrices Subtract
                        if (MatrixA.GetLength(1) == MatrixB.GetLength(1) && MatrixA.GetLength(0) == MatrixB.GetLength(0))
                        {
                            //for loop that generates the numbers of the rows
                            for (int i = 0; i < row; i++)
                            {
                                //for loop that generates the numbers of the columns
                                for (int j = 0; j < col; j++)
                                {
                                    //matrices Subtraction
                                    MatrixC[i, j] = MatrixA[i, j] - MatrixB[i, j];
                                }
                            }
                            //To convert MatrixC to a String that can display in txtMatrixC textbox.
                            txtMatrixC.Text = ConvertMatrixToString(row, col, MatrixC);
                        }
                        //else will be an error
                        else
                        {
                            MessageBox.Show("Subtraction Error", "Entery Error");
                            txtMatrixC.Clear();
                        }
                    }
                    //catch any invalid inputs
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n" + ex.StackTrace, "Entery Error");
                    }
                }

                //checking users click on one of operations
                else
                {
                    MessageBox.Show("Please, select one of the operations!", "Entery Error");
                }
            }
        }


        // method that checking users input values
        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is required field.", "Entery Error");
                textBox.Focus();
                return false;
            }
            return true;
        }


        //  method that checking input integer values
        public static bool IsInt32(TextBox textBox, string name)
        {//
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be an integer.", "Invalid Integer Number");
                textBox.Clear();
                textBox.Focus();
                return false;
            }
        }


        // method that check inputs within the range
        public bool isWithinRange(TextBox textBox, string name, int min, int max)
        {
            //convert textbox string input to int
            int number = Convert.ToInt32(textBox.Text);

            //if the input values are not within range
            if (number < min || number > max)
            {
                MessageBox.Show(name + " must between " + min.ToString() + " and " + max.ToString() + ".", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        //  method cheching all validation of inputs
        public bool IsValidData()
        {
            if (!IsPresent(txtRowsA, "The input value of the  Rows of Matrix A"))
                //check txtRowsA textbox
            {
                return false;
            }
            if (!IsPresent(txtColsA, "The input value of the Cols of Matrix B"))
                //check txtColsA textbox
            {
                return false;
            }
            if (!IsPresent(txtRowsB, "The input value of the Rows of Matrix B"))
                //check txtRowsB textbox
            {
                return false;
            }
            if (!IsPresent(txtColsB, "The input value of the Cols of Matrix B"))
                //check txtColsB textbox
            {
                return false;
            }

            //Check input value wheter in the textbox
            if (!IsInt32(txtRowsA, "The input value of the Rows of Matrix A"))
                //check txtRowsA textbox
            {
                return false;
            }
            if (!IsInt32(txtRowsB, "The input value of the Rows of Matrix B"))
                //check txtRowsB textbox
            {
                return false;
            }
            if (!IsInt32(txtColsA, "The input value of the Cols of Matrix A"))
                //check txtColsA textbox
            {
                return false;
            }
            if (!IsInt32(txtColsB, "The input value of the Cols of Matrix B"))
                //check txtColsB textbox
            {
                return false;
            }

            //check out of range inputs
            if (!isWithinRange(txtRowsA, "The input value of the Rows of Matrix A", 0, 10))
                //check txtRowsA textbox
            {
                return false;
            }
            if (!isWithinRange(txtRowsB, "The input value of the Rows of Matrix B", 0, 10))
                //check txtRowsB textbox
            {
                return false;
            }
            if (!isWithinRange(txtColsA, "The input value of the Cols of Matrix A", 0, 10))
                //check txtColsA textbox
            {
                return false;
            }
            if (!isWithinRange(txtColsB, "The input value of the Cols of Matrix B", 0, 10))
                //check txtColsB textbox
            {
                return false;
            }
            return true;
        }


        //  method checking Matrix A and B exist or not
        public bool IsMatrix()
        {
            if (!IsPresent(txtMatrixA, "Matrix A"))
            {
                return false;
            }
            if (!IsPresent(txtMatrixB, "Matrix B"))
            {
                return false;
            }
            return true;
        }


        //  clear matrix method 
        private void btnClearMatrices_Click(object sender, EventArgs e)
        {
            txtMatrixA.Clear();
            txtMatrixB.Clear();
            txtMatrixC.Clear();
            txtColsA.Clear();
            txtRowsA.Clear();
            txtColsB.Clear();
            txtRowsB.Clear();

            // reset the rows and cols to 3 
            txtRowsA.Text = "3";
            txtColsA.Text = "3";
            txtRowsB.Text = "3";
            txtColsB.Text = "3";
        }

        //close the project
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
