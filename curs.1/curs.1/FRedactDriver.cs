using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class FRedactDriver : Form
    {

        public FRedactDriver(DriverDB db)
        {
            driverdb = db;
            InitializeComponent();
        }
        DriverDB driverdb;
        int id;
        bool red=false;
        public FRedactDriver(int i,DriverDB db)
        {
            id = i;
            InitializeComponent();
            driverdb = db;
            textBox1.Text = driverdb.Show(id).full_name;

            textBox2.Text = driverdb.Show(id).phone_number;

            textBox3.Text = driverdb.Show(id).date_of_birth.ToString();

            textBox4.Text = driverdb.Show(id).passport_number;

            textBox5.Text = driverdb.Show(id).adress;

            checkBox1.Checked = driverdb.Show(id).status;
            red = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {try {
                if (red)
          driverdb.Update(id, textBox1.Text, textBox2.Text, Convert.ToDateTime(textBox3.Text), textBox4.Text, textBox5.Text, checkBox1.Checked);
        else
            driverdb.Insert(textBox1.Text, textBox2.Text, Convert.ToDateTime(textBox3.Text), textBox4.Text, textBox5.Text, checkBox1.Checked);
            Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FRedactDriver_Load(object sender, EventArgs e)
        {
           
        }
    }
}
