using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Midterm_review
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            Student a = new Student("1234", "Bob", "Smith", "Undergraduate", "IST");
            Staff b = new Staff("2345", "Mary", "Jones", "Payroll", 20.00);
            Faculty c = new Faculty("3456", "Pat", "Wallace", "CIS", 62000.00);


            PersonList pl = new PersonList();
            pl.Add(a);
            pl.Add(b);
            pl.Add(c);

            txtOutput.Text = pl.ToString();

            MessageBox.Show(c.ToString());

        }
    }
}
