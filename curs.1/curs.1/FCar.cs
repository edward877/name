using Controller;
using Model;
using System;
using System.Windows.Forms;

namespace View
{
    public partial class FCar : Form
    {

        DBDataContext db;

        int id_car;

        string number;

        string brand;

        decimal carrying_capacity;

        decimal width;

        decimal heigth;

        decimal length;

        bool status = true;

        FRedactCar f_red;

        CarDB cardb;

        public FCar(DBDataContext db)
        {
            InitializeComponent();
            this.db = db;
            cardb = new CarDB(db);
            showbd();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try {

                f_red = new FRedactCar();

                FillFields();

                cardb.Insert(number, brand, carrying_capacity, width, heigth, length, status);

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
                Car car = (listBox1.SelectedItem as Car);

                f_red = new FRedactCar(car);

                FillFields();

                cardb.Update(car.id_car, number, brand, carrying_capacity, width,
                    heigth, length, status);

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
                id_car = (listBox1.SelectedItem as Car).id_car;
                cardb.Delete(id_car);
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
                foreach ( var v in cardb.Show() )
                {
                    listBox1.Items.Add(v);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void  FillFields()
        {
            f_red.ShowDialog();

            number = f_red.textBox1.Text;

            brand = f_red.textBox2.Text;

            carrying_capacity = Convert.ToDecimal(f_red.textBox3.Text);

            width = Convert.ToDecimal(f_red.textBox4.Text);

            heigth = Convert.ToDecimal(f_red.textBox5.Text);

            length = Convert.ToDecimal(f_red.textBox6.Text);

            status = f_red.checkBox1.Checked;

        }

        private void FCar_Load(object sender, EventArgs e)
        {

        }
    }
}
