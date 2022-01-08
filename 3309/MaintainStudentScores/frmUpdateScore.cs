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
    public partial class frmUpdateScore : Form
    {
        public frmUpdateScore()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //  checking if the scores is within the range, 0 - 100
                if (Convert.ToInt32(txtScore.Text) >= 0 && Convert.ToInt32(txtScore.Text) <= 100)
                {
                    //  adding the input scores into temp list
                    frmUpdateStudentScores.tempScore.Values.ElementAt(frmStudentScores.selected)[frmUpdateStudentScores.selected] = Convert.ToInt32(txtScore.Text);
                    this.Close();
                }
                //  else, show error message
                else
                {
                    MessageBox.Show("Please enter a score between 0 and 100.", "Invalid Score");
                }
            }

            //  catch any exception
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid score.", "Invalid Entry");
            }
        }

        private void frmUpdateScore_Load(object sender, EventArgs e)
        {

        }
    }
}
