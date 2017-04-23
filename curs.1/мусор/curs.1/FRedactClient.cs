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
    public partial class FRedactClient : Form
    {

        string full_name;

        string phone_number;

        string company;

        string login;

        string password;

        DBDataContext db;

        ClientDB clientdb;

        public FRedactClient()
        {
            InitializeComponent();
        }

        public FRedactClient(DBDataContext db)
        {
            InitializeComponent();
            this.db = db;
            clientdb = new ClientDB(db);
        }

        public FRedactClient(Client client)
        {
            InitializeComponent();
            textBox1.Text = client.full_name;
            textBox2.Text = client.phone_number;
            textBox3.Text = client.company;
            textBox5.Visible = false;
            textBox6.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Visitor.user == null)
            {
                full_name = textBox1.Text;

                phone_number = textBox2.Text;

                company = textBox3.Text;

                login = textBox5.Text;

                password = textBox6.Text;

                clientdb.Insert(login, password, full_name, phone_number, company);

            }
            Close();
        }
    }
}
