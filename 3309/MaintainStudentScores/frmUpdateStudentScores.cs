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
    public partial class frmUpdateStudentScores : Form
    {
        //  create a temp doctionary that contain strings and lists 
        public static Dictionary<string, List<int>> tempScore;

        //BindingSource class to the default property values
        BindingSource bs = new BindingSource(); 

        public static int selected;
        
        public frmUpdateStudentScores()
        {
            InitializeComponent();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //   create add score from
            Form addScore = new frmAddScore();
            //   display add score from
            addScore.ShowDialog();
            bs.ResetBindings(false);
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //  update a score from the score listbox
            selected = lbxScores.SelectedIndex;

            //  create update score from
            Form updateScore = new frmUpdateScore();

            //  display update score from
            updateScore.ShowDialog();
            
            bs.ResetBindings(false);
        }
        
        // button remove mothod
        private void btnRemove_Click(object sender, EventArgs e)
        {
            tempScore.Values.ElementAt(frmStudentScores.selected).RemoveAt(lbxScores.SelectedIndex);
            bs.ResetBindings(false);               
        }

        // button clear method delete all the values in temp list
        private void btnClearScores_Click(object sender, EventArgs e)
        {
            tempScore.Values.ElementAt(frmStudentScores.selected).RemoveRange(0, tempScore.Values.ElementAt(frmStudentScores.selected).Count);
            bs.ResetBindings(false);
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            frmStudentScores.studentList = tempScore;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        //  displaying default setting
        private void frmUpdateStudentScores_Load(object sender, EventArgs e)
        {
            tempScore = frmStudentScores.studentList.ToDictionary(p => p.Key, p => p.Value.ToList());
            txtName.Text = tempScore.Keys.ElementAt(frmStudentScores.selected);
            bs.DataSource = tempScore.Values.ElementAt(frmStudentScores.selected);
            lbxScores.DataSource = bs;                                            
        }

    }
}