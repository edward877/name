using Model;
using Controller;
using System;
using System.Windows.Forms;


namespace View
{
    public partial class FMain : Form
    {
       

        DBDataContext db;
        public FMain()
        {
            
            ConnectDB cdb = new ConnectDB();
            this.db = cdb.DB;
            FEntry fe = new FEntry(db);
            fe.ShowDialog();
            InitializeComponent();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FCar fc = new FCar(db);
            fc.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FClient fc = new FClient(db);
            fc.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FDriver fd = new FDriver(db);
            fd.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FOrder fd = new FOrder(db);
            fd.ShowDialog();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            FProfit_driver fpd = new FProfit_driver(db);
            fpd.ShowDialog();
        }

        private void FMain_Load(object sender, EventArgs e)
        {

        }

        private void FMain_Load_1(object sender, EventArgs e)
        {

        }
    }
}
