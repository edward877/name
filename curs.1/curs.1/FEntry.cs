using System;
using System.Windows.Forms;
using Model;
using Controller;

namespace View
{
    public partial class FEntry : Form
    {
        ConnectDB cdb = new ConnectDB();
        DBDataContext db;
        Visitor visitordb;
        bool exit = true;

        public FEntry(DBDataContext db)
        {
            InitializeComponent();
            this.db = db;
            visitordb = new Visitor(db);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password  = textBox2.Text;
            
            if(visitordb.Log_in(login, password))
            {
                exit = false;
                Close();
            }
            else
            {
                MessageBox.Show("wrong");
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            FRedactClient fcl = new FRedactClient(db);
            Hide();
            fcl.ShowDialog();
            Show();
        }

        private void FEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                Application.Exit();
            }
            else
            {
                if (Visitor.user.role == "client")
                {
                    Hide();
                    FOrder fo = new FOrder(db);
                    fo.ShowDialog();
                    exit = true;
                    if (fo.exit)
                    {
                        Close();
                    }else (new FEntry(db)).ShowDialog();

                }
            }
        }

        private void FEntry_Load(object sender, EventArgs e)
        {

        }
    }
}
