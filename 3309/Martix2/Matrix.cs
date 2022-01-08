using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martix2
{
    class Matrix
    {
        // generate double array
        private double[,] matrix;

        public Matrix(int x, int y)
        {
            this.matrix = new double[x, y];
        }
        public double this[int i, int j]
        {
            //get and set value, the matrix
            get
            {
                return this.matrix[i, j];
            }
            set
            {
                this.matrix[i, j] = value;
            }
        }

        // get value from the matrix rows
        public int Rows
        {
            get
            {
                return this.matrix.GetLength(0);
            }
        }

        //get value from matrix columns
        public int Cols
        {
            get
            {
                return this.matrix.GetLength(1);
            }
        }

        // method populateRand() populate the random value for the matrix
        public void populateRand()
        {
            Random random = new Random();
            for (int index1 = 0; index1 < this.Rows; index1++)
            {
                for (int index2 = 0; index2 < this.Cols; index2++)
                    this.matrix[index1, index2] = random.NextDouble() * 10.0;
            }
        }

        // method populateOrd() of populate the order 
        public void populateOrd()
        {
            double num = 1.0;
            for (int index1 = 0; index1 < this.Rows; index1++)
            {
                for (int index2 = 0; index2 < this.Cols; index2++)
                {
                    this.matrix[index1, index2] = num;
                    num++;
                }
            }
        }
        
        // check equality for every row from Matrix A and B
        public bool rowsEqual(Matrix m)
        {
            return m.Rows == this.Rows;
        }
        // check equality for every column from Matrix A and B
        public bool colsEqual(Matrix m)
        {
            return m.Cols == this.Cols;
        }
        // check equality for dimension from Matrix A and B
        public bool dimsEqual(Matrix m)
        {
            return m.Rows == this.Rows || m.Cols == this.Cols;
        }

        // override Equals method
        public override bool Equals(object o)
        {
            if (o == null)
                return false;
            Matrix m = (Matrix)o;
            if (!this.rowsEqual(m) || !this.colsEqual(m))
                return false;
            for (int index1 = 0; index1 < this.Rows; index1++)
            {
                for (int index2 = 0; index2 < this.Cols; index2++)
                {
                    if (m[index1, index2] != this.matrix[index1, index2])
                        return false;
                }
            }
            return true;
        }

        // override
        public override int GetHashCode()
        {
            return this.sum().GetHashCode();
        }

        // sum() method
        public double sum()
        {
            double number = 0.0;
            for (int index1 = 0; index1 < this.Rows; index1++)
            {
                for (int index2 = 0; index2 < this.Cols; index2++)
                    number += this.matrix[index1, index2];
            }
            return number;
        }

        // addtion method for Matrix A and B
        public Matrix add(Matrix m)
        {
            if (object.Equals((object) m, (object) null))
                throw new ArgumentNullException("Matrix is null");
            if (!this.dimsEqual(m))
                throw new ArgumentException("Dimensions error");

            Matrix matrix = new Matrix(this.Rows, this.Cols);

            for (int index1 = 0; index1 < this.Rows; index1++)
            {
                for (int index2 = 0; index2 < this.Cols; index2++)
                    matrix[index1, index2] = this[index1, index2] + m[index1, index2];
            }
            return matrix;
        }

        // substract method for Matrix A and B
        public Matrix subtract(Matrix m)
        {
            if (object.Equals((object) m, (object) null))
                throw new ArgumentNullException("The Matrix is null");
            if (!this.dimsEqual(m))
                throw new ArgumentException("Dimensions error");

            Matrix matrix = new Matrix(this.Rows, this.Cols);

            for (int index1 = 0; index1 < this.Rows; ++index1)
            {
                for (int index2 = 0; index2 < this.Cols; ++index2)
                    matrix[index1, index2] = this[index1, index2] - m[index1, index2];
            }
            return matrix;
        }

        // multiplication method for Matrix A and B
        public Matrix multiply(Matrix m)
        {
            if (object.Equals((object) m, (object) null))
                throw new ArgumentNullException("The Matrix is null");
            if (!this.dimsEqual(m))
                throw new ArgumentException("Dimensions error");

            Matrix matrix = new Matrix(this.Rows, this.Cols);

            for (int index1 = 0; index1 < this.Rows; index1++)
            {
                for (int index2 = 0; index2 < this.Cols; index2++)
                {
                    for (int index3 = 0; index3 < this.Rows; index3++)
                    {
                        Matrix matrix2 = matrix;
                        int index4 = index1;
                        int index5 = index2;
                        matrix2[index4, index5] = matrix2[index4, index5] + this[index1, index3] * m[index3, index2];
                    }
                }
            }
            return matrix;
        }


        // check matrix A equals matrix B
        public static bool operator ==(Matrix m1, Matrix m2)
        {
            if (!object.Equals((object) m1, (object) null))
                return m1.Equals((object) m2);
            return object.Equals((object) m2, (object) null);
        }


        // check matrix A is not equal to matrix B
        public static bool operator !=(Matrix m1, Matrix m2)
        {
            return !(m1 == m2);
        }


        // multiplication
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (object.Equals((object) m1, (object) null) || object.Equals((object) m2, (object) null))
                throw new ArgumentNullException("One or both vectors are null");
            if (m1.Rows != m2.Cols || m1.Cols != m2.Rows)
                throw new ArgumentException("Dinensions error");
            return m1.multiply(m2);
        }

        // adding
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (object.Equals((object) m1, (object) null) || object.Equals((object) m2, (object) null))
                throw new ArgumentNullException("One or both vectors are null");
            if (!m1.dimsEqual(m2))
                throw new ArgumentException("Dinensions error");
            return m1.add(m2);
        }


        // substract
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (object.Equals((object) m1, (object) null) || object.Equals((object) m2, (object) null))
                throw new ArgumentNullException("One or both vectors are null");
            if (!m1.dimsEqual(m2))
                throw new ArgumentException("Dinensions error");
            return m1.subtract(m2);
        }


        // Matrix clone
        public Matrix clone()
        {
            Matrix matrix = new Matrix(this.Rows, this.Cols);
            for (int index1 = 0; index1 < this.Rows; index1++)
            {
                for (int index2 = 0; index2 < this.Cols; index2++)
                    matrix[index1, index2] = this.matrix[index1, index2];
            }
            return matrix;
        }

        // clone
        public void clone(Matrix m)
        {
            for (int index1 = 0; index1 < this.Rows; index1++)
            {
                for (int index2 = 0; index2 < this.Cols; index2++)
                    this.matrix[index1, index2] = m[index1, index2];
            }
        }

        // override ToString method
        public override string ToString()
        {
            string str = "";
            for (int index1 = 0; index1 < this.Rows; index1++)
            {
                for (int index2 = 0; index2 < this.Cols; index2++)
                    str = str + this.matrix[index1, index2].ToString("F1") + "\t";
                str += "\r\n";
            }
            return str;
        }

        // matrix Identity
        public static Matrix makeID(int n)
        {
            Matrix matrix = new Matrix(n, n);
            for (int index1 = 0; index1 < matrix.Rows; index1++)
            {
                for (int index2 = 0; index2 < matrix.Cols; index2++)
                    matrix[index1, index2] = index1 != index2 ? 0.0 : 1.0;
            }
            return matrix;
        }
    }
}