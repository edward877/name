using Controller;
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
    public partial class FilterF : Form
    {
        int panel;
        Delegate sd;
        Object db;
        public FilterF(int p,Delegate d,Object o)
        {
            InitializeComponent();
            panel = p;
            sd = d;
            db = o;
        }

        private void FilterF_Load(object sender, EventArgs e)
        {
            switch (panel)
            {
                case 1:
                         groupBoxCar.Visible = !groupBoxCar.Visible;
                        comboBox2.SelectedIndex = 0;
                    break;
                case 2:
                    groupBoxDriver.Visible = !groupBoxDriver.Visible;
                    comboBox1.SelectedIndex = 0;
                    //   if (!btnProfitDriver.Enabled)
                    //   {

                    //  }
                    //else
                    //{
                    //         groupBoxDriver.Visible = !groupBoxDriver.Visible;
                    //          comboBox1.SelectedIndex = 0;
                    //}
                    break;
                case 3:
                    
                    groupBoxProfit.Visible = !groupBoxProfit.Visible;
                    break;
                case 4:
                       groupBoxClient.Visible = !groupBoxClient.Visible;
                      comboBox3.SelectedIndex = 0;
                    break;
                case 5:
                       groupBoxOrder.Visible = !groupBoxOrder.Visible;
                    break;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            decimal cost = 0;
            decimal paid = 0;
            try
            {
                if (textBox11.Text != "")
                {
                    cost = Convert.ToDecimal(textBox11.Text);
                }
                if (textBox15.Text != "")
                {
                    paid = Convert.ToDecimal(textBox15.Text);
                }
                (sd as showorderdel)((db as OrderDB).Query(textBox14.Text, textBox13.Text, textBox12.Text, cost, paid));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
      (sd as showorderdel)((db as OrderDB).Query(textBox14.Text, textBox13.Text, textBox12.Text, cost, paid));

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                (sd as showclientdel)((db as ClientDB).Query(textBox9.Text, textBox8.Text, textBox7.Text, textBox10.Text));
            }
            else
            {
                (sd as showclientdel)((db as ClientDB).Query(textBox9.Text, textBox8.Text, textBox7.Text, textBox10.Text, (comboBox3.SelectedIndex == 1)));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            decimal cap = 0;
            try
            {
                if (textBox3.Text != "")
                {
                    cap = Convert.ToDecimal(textBox3.Text);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (comboBox2.SelectedIndex == 0)
            {
                (sd as showcardel)((db as CarDB).Query(textBox6.Text, textBox5.Text, cap));
            }
            else
            {
                (sd as showcardel)((db as CarDB).QueryStatus(textBox6.Text, textBox5.Text, cap, (comboBox2.SelectedIndex == 1)));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                (sd as showdriverinfodel)((db as DriverDB).Query(textBox1.Text, textBox2.Text, textBox4.Text));
            }
            else
            {
                (sd as showdriverinfodel)((db as DriverDB).QueryStatus(textBox1.Text, textBox2.Text, textBox4.Text, (comboBox1.SelectedIndex == 1)));
                //     showbdDrivers(driverdb.QueryStatus(textBox1.Text, textBox2.Text, textBox4.Text, (comboBox1.SelectedIndex == 1)));
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            (sd as showdriverpaydel)((db as Profit_driverDB).Query(textBox18.Text));
        }
    }
}
