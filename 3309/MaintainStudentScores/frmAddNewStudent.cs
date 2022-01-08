using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaintainStudentScores
{
    public partial class frmAddNewStudent : Form
    {
        //  create doctionary that contain strings and lists
        Dictionary<string, List<int>> newStudent = new Dictionary<string, List<int>>();
        List<int> scores = new List<int>();

        public frmAddNewStudent()
        {
            InitializeComponent();
        }


        // button adding scores method
        private void btnAddScore_Click(object sender, EventArgs e)
        {
            try
            {
                //  checking if the scores value is within the range, 0 - 100
                if (Convert.ToInt32(txtScore.Text) >= 0 && Convert.ToInt32(txtScore.Text) <= 100)
                {
                    //  if true add input values into scores list
                    scores.Add(Convert.ToInt32(txtScore.Text));
                }
                //  else, show error message
                else
                {
                    MessageBox.Show("Invalid, please enter a score between 0 and 100", "Invalid Entry");
                }
            }

            //  catch any exception
            catch (FormatException)
            {
                MessageBox.Show("You enter invalid input", "Invalid Entry");
            }
            //  adding comma between scores
            txtScores.Text = String.Join(" , ", scores);

            //  clear the score textbox after adding a score
            txtScore.Text = "";                        
            txtScore.Focus();
        }


        //  button clear method to clear this form
        private void btnClearScores_Click(object sender, EventArgs e)
        {
            scores.Clear();
            txtScore.Text = "";
            txtScores.Text = "";
            txtScore.Focus();
        }

        //  button Ok to make changes to frmStudenScores
        private void btnOK_Click(object sender, EventArgs e)
        {
            //  adding students' name and scores to the listbox
            if (txtName.Text != "")
            {
                frmStudentScores.studentList.Add(txtName.Text, scores);
                this.Close();
            }
            //  else, show error message.
            else
            {
                MessageBox.Show("Please enter a student name", "Invalid Entry");
                txtName.Focus();
            }
        }

    }
}
