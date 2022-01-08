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
    public partial class frmAddScore : Form
    {
        public frmAddScore()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //  checking if the scores is within the range, 0 - 100
                if (Convert.ToInt32(txtScore.Text) >= 0 && Convert.ToInt32(txtScore.Text) <= 100)
                {
                    //  add the input scores into temp list
                    frmUpdateStudentScores.tempScore.Values.ElementAt(frmStudentScores.selected).Add(Convert.ToInt32(txtScore.Text));
                    this.Close();
                }
                //  else, show error message
                else
                {
                    MessageBox.Show("Please enter a student score between 0 and 100.", "Invalid Score");
                }
            }
            //  catch any exception
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid score.", "Invalid Entry");
            }
        }

    }
}
