using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseControl
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void billsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.billsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.expensesDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'expensesDataSet.Bills' table. You can move, or remove it, as needed.
            this.billsTableAdapter.Fill(this.expensesDataSet.Bills);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                billsDataGridView1.DataSource = billsTableAdapter.GetDataByCategory(textBox1.Text, dateTimePicker1.Value.Date);
            }
            else
            {
                billsDataGridView1.DataSource = billsTableAdapter.GetDataByValue(Convert.ToDecimal(textBox1.Text), dateTimePicker1.Value.Date);
            }
        }
    }
}
