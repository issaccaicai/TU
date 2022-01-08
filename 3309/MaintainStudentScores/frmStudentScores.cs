//  This is a maintain students scores program
 
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
    public partial class frmStudentScores : Form
    {
        //  doctionary contains strings and lists
        public static Dictionary<string, List<int>> studentList = new Dictionary<string, List<int>>();
        public static int selected;
        
        public frmStudentScores()
        {
            InitializeComponent();
        }


        // Button Click adding will open new form window called frmAddNewStudent that allows users to add new students
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            // displaying my form addNewStudent
            Form addNewStudent = new frmAddNewStudent();
            addNewStudent.ShowDialog();

            // clear method to clear the students
            lbxStudent.Items.Clear();

            // addToListBox method to add students
            addToListBox();
        }


        // Button Click update method will open new form window called frmUpdateStudentScores allows users to update students
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Form updateScores = new frmUpdateStudentScores();
           
            //by selecting the listbox to update
            selected = lbxStudent.SelectedIndex;

            //if student listbox has one student, window pop up
            if (lbxStudent.Items.Count > 0)
            {
                updateScores.ShowDialog();
            }
            //else, show error message
            else
            {
                MessageBox.Show("Sorry, no students found!.", "Error");
            }
            // clear method to clear the students 
            lbxStudent.Items.Clear();

            //  call addToListBox method to add students
            addToListBox();
        }


        // Button Click delete method to delete students from the student listbox by selecting
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // removing a studedent by selecting
            studentList.Remove(studentList.Keys.ElementAt(lbxStudent.SelectedIndex));

            //  clear method to clear the students in the student listbox
            lbxStudent.Items.Clear();

            //  addToListBox method to add new students to student listbox.
            addToListBox();

            //if the listbox is empty
            if (studentList.Count == 0)
            {
                txtScoreTotal.Text = "";
                txtScoreCount.Text = "";
                txtAverage.Text = "";
            }
        }
        

        // method to add student to a listbox
        private void addToListBox()
        {
            // for each loop to add each student StringBuilder
            foreach (var student in studentList)
            {
                StringBuilder sb = new StringBuilder();// create a StringBuilder
                sb.Append(student.Key.ToString());     // adding student to StringBuilder
                sb.Append("  | ");                    // format

                // for loop to add student scores for each student 
                for (int i = 0; i < student.Value.Count; i++)
                {
                    sb.Append(student.Value[i]);       // adding student scores to StringBuilder
                    if (i != student.Value.Count - 1)  // adding a space bewteet two scores
                    {
                        sb.Append(" | ");
                    }
                }
                lbxStudent.Items.Add(sb);         // adding to student listBox from StringBuilder.
                lbxStudent.SetSelected(0, true);  
                Display();                            // method display() to display student
            }
        }


        //  display the values of the score total, count, and average
        private void Display()
        {
            try
            {
                // string values to each textbox
                txtScoreTotal.Text = studentList.Values.ElementAt(lbxStudent.SelectedIndex).Sum().ToString();
                txtScoreCount.Text = studentList.Values.ElementAt(lbxStudent.SelectedIndex).Count().ToString();
                txtAverage.Text = Math.Round(studentList.Values.ElementAt(lbxStudent.SelectedIndex).Average()).ToString();
            }

            //  catch any exception and then clear textboxes
            catch (Exception)
            {
                txtScoreTotal.Text = "";
                txtScoreCount.Text = "";
                txtAverage.Text = "";
            }
        }


        //  default setting
        private void frmStudentScores_Load(object sender, EventArgs e)
        {
            studentList.Add("Joel Murach", new List<int> { 97, 71, 83 });
            studentList.Add("Doug Lowel", new List<int> { 99, 93, 97 });
            studentList.Add("Anne Boehml", new List<int> { 100, 100, 100 });
            addToListBox();
        }


        //  displaying the values of the score total, count, and average
        private void lbxStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            // display method
            Display();
        }
        
        // exit the program
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}