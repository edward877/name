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
    public partial class ClientInfoF : Form
    {
        int id;
        ClientDB clientdb;
        public ClientInfoF(ClientDB d, int id)
        {
            InitializeComponent();
            clientdb = d;
            this.id = id;
            dataGridView1.Columns.Clear();
            DataGridViewTextBoxColumn firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Индекс";
            dataGridView1.Columns.Add(firstColumn);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "ФИО";
            dataGridView1.Columns.Add(firstColumn);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Номер телефона";
            dataGridView1.Columns.Add(firstColumn);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Компания";
            dataGridView1.Columns.Add(firstColumn);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Эл. почта";
            dataGridView1.Columns.Add(firstColumn);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Постоянный клиент";
            dataGridView1.Columns.Add(firstColumn);
            showbdClients();

           
        }
        void showbdClients()
        {
            try
            {
                int i = 0;
                //lbValues.Items.Clear();
                dataGridView1.Rows.Clear();
                foreach (var v in clientdb.Show())
                {
                    if (v.id_client == id)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = v.id_client;
                        dataGridView1.Rows[i].Cells[1].Value = v.full_name;
                        dataGridView1.Rows[i].Cells[2].Value = v.phone_number;
                        dataGridView1.Rows[i].Cells[3].Value = v.company;
                        dataGridView1.Rows[i].Cells[4].Value = v.e_mail;
                        dataGridView1.Rows[i].Cells[5].Value = v.Order.Count >= 3 ? "+" : "-";
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
