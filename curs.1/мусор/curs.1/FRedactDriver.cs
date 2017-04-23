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

        public FRedactDriver()
        {
            InitializeComponent();
        }

        public FRedactDriver(Driver driver)
        {
            InitializeComponent();

             textBox1.Text= driver.full_name;

            textBox2.Text = driver.phone_number;

            textBox3.Text = driver.date_of_birth.ToString();

            textBox4.Text = driver.passport_number;

            textBox5.Text = driver.adress;

            checkBox1.Checked = driver.status;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
