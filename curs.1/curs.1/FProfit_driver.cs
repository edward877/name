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
using Report;

namespace View
{
    public partial class FProfit_driver : Form
    {
        DBDataContext db;

        Profit_driverDB profit_driverdb;
        public FProfit_driver(DBDataContext db)
        {
            InitializeComponent();
            this.db = db;
            profit_driverdb = new Profit_driverDB(db);
            showbd();
        }

        void showbd()
        {
            ReportProfitController report = new ReportProfitController(db);
            try
            {
                listBox1.Items.Clear();
                foreach (var v in report.Money())
                {
                    listBox1.Items.Add(v);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
