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
    public partial class ClientOrdF : Form
    {
        int id;
        OrderDB orderdb;
        public ClientOrdF(OrderDB d, int id)
        {
            InitializeComponent();
            orderdb = d;
            this.id = id;
            dataGridView1.Columns.Clear();
            DataGridViewTextBoxColumn firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Индекс";
            firstColumn.Name = "ID";
            dataGridView1.Columns.Add(firstColumn);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Водитель";
            firstColumn.Name = "Driver";
            dataGridView1.Columns.Add(firstColumn);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Грузовик";
            firstColumn.Name = "Track";
            dataGridView1.Columns.Add(firstColumn);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Пункт А";
            firstColumn.Name = "pA";
            dataGridView1.Columns.Add(firstColumn);
            firstColumn =
           new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Пункт Б";
            firstColumn.Name = "pB";
            dataGridView1.Columns.Add(firstColumn);
            firstColumn =
           new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Расстояние";
            //  firstColumn.Name = "Status";
            dataGridView1.Columns.Add(firstColumn);
            firstColumn =
          new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Экспресс";
            //  firstColumn.Name = "Status";
            dataGridView1.Columns.Add(firstColumn);
            firstColumn =
          new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Дата";
            //  firstColumn.Name = "Status";
            dataGridView1.Columns.Add(firstColumn);
          
            firstColumn =
                 new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Стоимость";
            //  firstColumn.Name = "Status";

            dataGridView1.Columns.Add(firstColumn);
            firstColumn =
                new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Оплачено";
            //  firstColumn.Name = "Status";
            dataGridView1.Columns.Add(firstColumn);
            
            showbdOrder();


        }
        void showbdOrder()
        {
            // FOrder f = new FOrder(db);
            // f.ShowDialog();

            int i = 0;
            //lbValues.Items.Clear();
            dataGridView1.Rows.Clear();
            foreach (var v in orderdb.Show(id))
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = v.id_order;
                try
                {
                    dataGridView1.Rows[i].Cells[1].Value = v.Driver.full_name;
                    dataGridView1.Rows[i].Cells[2].Value = v.Car.brand;
                }
                catch (Exception ex)
                {
                    dataGridView1.Rows[i].Cells[1].Value = "не назначен";
                    dataGridView1.Rows[i].Cells[2].Value = "не назначен";
                }
               
                dataGridView1.Rows[i].Cells[3].Value = v.point_of_arrival;
                dataGridView1.Rows[i].Cells[4].Value = v.point_of_departure;
                dataGridView1.Rows[i].Cells[5].Value = v.distance;
                dataGridView1.Rows[i].Cells[6].Value = v.express ? "+" : "-";
                dataGridView1.Rows[i].Cells[7].Value = v.reg_date;
                dataGridView1.Rows[i].Cells[8].Value = v.cost;
                dataGridView1.Rows[i].Cells[9].Value = v.paid;


                i++;



            }


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
