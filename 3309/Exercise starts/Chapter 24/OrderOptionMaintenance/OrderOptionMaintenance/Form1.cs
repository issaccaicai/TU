using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderOptionMaintenance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                try
                {
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private bool IsValidData()
        {
            return Validator.IsPresent(txtSalesTaxRate) &&
                   Validator.IsPresent(txtFirstBookShipping) &&
                   Validator.IsPresent(txtAdditionalBookShipping) &&
                   Validator.IsDecimal(txtSalesTaxRate) &&
                   Validator.IsDecimal(txtFirstBookShipping) &&
                   Validator.IsDecimal(txtAdditionalBookShipping) &&
                   Validator.IsWithinRange(txtSalesTaxRate, 0, .15m) &
                   Validator.IsWithinRange(txtFirstBookShipping, 2, 10) &&
                   Validator.IsWithinRange(txtAdditionalBookShipping, 1, 7.5m);
        }
    }
}
