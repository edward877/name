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
    
    public partial class FClient : Form
    {
        DBDataContext db;

        FRedactClient f_red;

         int id_client;

        string full_name;

         string phone_number;

         string company;

        string login;

        string password;

        ClientDB clientdb;


        public FClient(DBDataContext db)
        {
            InitializeComponent();
            this.db = db;
            clientdb = new ClientDB(db);
            showbd();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                f_red = new FRedactClient();

                FillFields();

                login = f_red.textBox5.Text;

                password = f_red.textBox6.Text;
                
                clientdb.Insert(login, password, full_name, phone_number, company);
                
                showbd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                id_client = (listBox1.SelectedItem as Client).id_client;
                clientdb.Delete(id_client);
                showbd();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                Client client = (listBox1.SelectedItem as Client);

                f_red = new FRedactClient(client);

                FillFields();

                clientdb.Update(client.id_client, full_name, phone_number, company);

                showbd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        void showbd()
        {
            try
            {
                listBox1.Items.Clear();
                foreach ( var v in clientdb.Show() )
                {
                    listBox1.Items.Add(v);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void FillFields()
        {
            f_red.ShowDialog();

            full_name = f_red.textBox1.Text;

            phone_number = f_red.textBox2.Text;

            company = f_red.textBox3.Text;
        }

    }
}
