using Model;
using Controller;
using System;
using System.Windows.Forms;
using Email;
using Report;
using System.Collections.Generic;

namespace View
{
    public partial class FMain : Form
    {

        int panel = 0;
        DBDataContext db;
        CarDB cardb;
        OrderDB orderdb;
        ClientDB clientdb;
        DriverDB driverdb;
        Profit_driverDB profit_driverdb;
        ReportProfitController report;
        public FMain()
        {
            
            ConnectDB cdb = new ConnectDB();
            this.db = cdb.DB;
            driverdb = new DriverDB(db);
            FEntry fe = new FEntry(db);
            fe.ShowDialog();
            InitializeComponent();
            cardb = new CarDB(db);
            report = new ReportProfitController(db);
            profit_driverdb = new Profit_driverDB(db);
            orderdb = new OrderDB(db);
            clientdb = new ClientDB(db);
        }
        void showdbCar(List<Car> listCar)
        {
            try
            {
                int i = 0;
                //lbValues.Items.Clear();
                dgwValues.Rows.Clear();
                foreach (var v in listCar)
                {
                    dgwValues.Rows.Add();
                    dgwValues.Rows[i].Cells[0].Value = v.number;
                    dgwValues.Rows[i].Cells[1].Value = v.brand;
                    dgwValues.Rows[i].Cells[2].Value = v.carrying_capacity;
                    dgwValues.Rows[i].Cells[3].Value = v.length;
                    dgwValues.Rows[i].Cells[4].Value = v.heigth;
                    dgwValues.Rows[i].Cells[5].Value = v.width;
                    dgwValues.Rows[i].Cells[6].Value = v.status?"+":"-";
                    i++;
                   
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel = 1;
            groupBoxProfit.Visible = false;
            groupBoxClient.Visible = false;
            groupBoxDriver.Visible = false;
            groupBoxOrder.Visible = false;
            dgwValues.Columns.Clear();
            btnProfitDriver.Visible = btnDriverInfo.Visible = false;
            //FCar fc = new FCar(db);
            //   fc.ShowDialog();
            DataGridViewTextBoxColumn firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Номер";
            firstColumn.Name = "Num";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Марка";
            firstColumn.Name = "Mark";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Грузоподъемность";
            firstColumn.Name = "Capacity";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Длина";
            firstColumn.Name = "Length";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Высота";
            firstColumn.Name = "Height";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
           new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Ширина";
            firstColumn.Name = "Width";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
           new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Свободен";
            firstColumn.Name = "Status";
            dgwValues.Columns.Add(firstColumn);
            //создание столбцов  


            //добавление столбцов  
         //   dgwValues.Columns.Add(firstColumn);
       //     myDataGridView.Columns.Add(secondColumn);
       //     myDataGridView.Columns.Add(thirdColumn);
            showdbCar(cardb.Show());
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
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private Int32 tmpX;
        private Int32 tmpY;
        private bool MV = false;

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (MV)
            {
                this.Left = this.Left + (Cursor.Position.X - tmpX);
                this.Top = this.Top + (Cursor.Position.Y - tmpY);
                tmpX = Cursor.Position.X;
                tmpY = Cursor.Position.Y;
            }
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            tmpX = Cursor.Position.X;
            tmpY = Cursor.Position.Y;
            MV = true;

            var m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            MV = false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            SendEmail send = new SendEmail();
            //  send.SendMessage("eduard.arkhipov2017@yandex.ru", "test", "hehe", "D:\\1.ods");
            send.SendMessage("eduard.arkhipov2017@yandex.ru", "test", "hehe");
        }

        private void button7_MouseClick(object sender, MouseEventArgs e)
        {
            //FOrder f = new FOrder(db);
            //f.ShowDialog();
            
        }
        void showbdOrder(List<Order> orderList)
        {
            try
            {
                int i = 0;
                //lbValues.Items.Clear();
                dgwValues.Rows.Clear();
                foreach (var v in orderList)
                {
                    dgwValues.Rows.Add();
                    dgwValues.Rows[i].Cells[0].Value = v.id_order;
                    try
                    {
                        dgwValues.Rows[i].Cells[1].Value = v.Driver.full_name;
                        dgwValues.Rows[i].Cells[2].Value = v.Car.brand;
                    }
                    catch {
                        dgwValues.Rows[i].Cells[1].Value =
                        dgwValues.Rows[i].Cells[2].Value = "Не назначен";
                    }
                    dgwValues.Rows[i].Cells[3].Value = v.Client.full_name;
                    dgwValues.Rows[i].Cells[4].Value = v.point_of_arrival;
                    dgwValues.Rows[i].Cells[5].Value = v.point_of_departure;
                    dgwValues.Rows[i].Cells[6].Value = v.distance;
                    dgwValues.Rows[i].Cells[7].Value = v.express?"+":"-";
                    dgwValues.Rows[i].Cells[8].Value = v.reg_date.ToString("dd'/'MM'/'yyyy");
                    dgwValues.Rows[i].Cells[9].Value = v.cost;
                    dgwValues.Rows[i].Cells[10].Value = v.paid;
                    

                    i++;


                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }
        void showbdClients(List<Client> clientList)
        {
            try
            {
                int i = 0;
                //lbValues.Items.Clear();
                dgwValues.Rows.Clear();
                foreach (var v in clientList)
                {
                    dgwValues.Rows.Add();
                    dgwValues.Rows[i].Cells[0].Value = v.id_client;
                    dgwValues.Rows[i].Cells[1].Value = v.full_name;
                    dgwValues.Rows[i].Cells[2].Value = v.phone_number;
                    dgwValues.Rows[i].Cells[3].Value = v.company;
                    dgwValues.Rows[i].Cells[4].Value = v.e_mail;
                    dgwValues.Rows[i].Cells[5].Value = v.Order.Count>=3?"+":"-";
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            groupBoxDriver.Visible = false;
            SendEmail send = new SendEmail();
            btnProfitDriver.Visible = btnDriverInfo.Visible = false;
            //  send.SendMessage("eduard.arkhipov2017@yandex.ru", "test", "hehe", "D:\\1.ods");
            send.SendMessage("eduard.arkhipov2017@yandex.ru", "test", "hehe");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel = 4;
            groupBoxProfit.Visible = false;
            groupBoxOrder.Visible = false;
            groupBoxCar.Visible = false;
            groupBoxDriver.Visible = false;
            btnProfitDriver.Visible = btnDriverInfo.Visible = false;
            dgwValues.Columns.Clear();
            DataGridViewTextBoxColumn firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Индекс";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "ФИО";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Номер телефона";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Компания";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Эл. почта";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Постоянный клиент";
            dgwValues.Columns.Add(firstColumn);
            showbdClients(clientdb.Show());

        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel = 2;
            groupBoxProfit.Visible = false;
            groupBoxOrder.Visible = false;
            groupBoxClient.Visible = false;
            groupBoxCar.Visible = false;
            btnProfitDriver.Visible = btnDriverInfo.Visible = true;
            dgwValues.Columns.Clear();
            DataGridViewTextBoxColumn firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Индекс";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "ФИО";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Номер телефона";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Дата рождения";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Паспорт";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Адрес";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
                 new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Свободен";
            dgwValues.Columns.Add(firstColumn);
            showbdDrivers(driverdb.Show());
            btnDriverInfo.Enabled = false;
            btnProfitDriver.Enabled = true;
        }
        void showbdDrivers(List<Driver> listDrivers)
        {
            try
            {
                int i = 0;
                //lbValues.Items.Clear();
                dgwValues.Rows.Clear();
                foreach (var v in listDrivers)
                {
                    dgwValues.Rows.Add();
                    dgwValues.Rows[i].Cells[0].Value = v.id_driver;
                    dgwValues.Rows[i].Cells[1].Value = v.full_name;
                    dgwValues.Rows[i].Cells[2].Value = v.phone_number;
                    dgwValues.Rows[i].Cells[3].Value = v.date_of_birth.ToString("dd'/'MM'/'yyyy");
                    dgwValues.Rows[i].Cells[4].Value = v.passport_number;
                    dgwValues.Rows[i].Cells[5].Value = v.adress;
                    dgwValues.Rows[i].Cells[6].Value = v.status? "+" : "-";
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //FDriver fd = new FDriver(db);
          //  fd.ShowDialog();
            //FProfit_driver fpd = new FProfit_driver(db);
           // fpd.ShowDialog();
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            (sender as Button).ForeColor = System.Drawing.Color.Gray;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).ForeColor = System.Drawing.Color.White ;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = System.Drawing.Color.Gray;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = System.Drawing.Color.Black;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
         this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dgwValues.Columns.Clear();
            groupBoxDriver.Visible = false;
            DataGridViewTextBoxColumn firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Индекс";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "ФИО";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Сумма";
            dgwValues.Columns.Add(firstColumn);

            showbdProfit(profit_driverdb.Show());
            btnDriverInfo.Enabled = true;
            btnProfitDriver.Enabled = false;

        }
        void showbdProfit(List<Profit_driver> profitList)
        {
            try
            {
                int i = 0;
                //lbValues.Items.Clear();
                dgwValues.Rows.Clear();
                foreach (var v in profitList)
                {
                    dgwValues.Rows.Add();
                    dgwValues.Rows[i].Cells[0].Value = v.id_profit_driver;
               //     dgwValues.Rows[i].Cells[1].Value = v.id_driver;
                    dgwValues.Rows[i].Cells[1].Value = v.Order.Driver.full_name;
                    dgwValues.Rows[i].Cells[2].Value = v.value;
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            panel = 5;
            groupBoxProfit.Visible = false;
            groupBoxClient.Visible = false;
            groupBoxCar.Visible = false;
            groupBoxDriver.Visible = false;
            dgwValues.Columns.Clear();
            btnProfitDriver.Visible = btnDriverInfo.Visible = false;
            DataGridViewTextBoxColumn firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Индекс";
            firstColumn.Name = "ID";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Водитель";
            firstColumn.Name = "Driver";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Грузовик";
            firstColumn.Name = "Track";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "ФИО клиента";
            firstColumn.Name = "fio";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Пункт А";
            firstColumn.Name = "pA";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
           new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Пункт Б";
            firstColumn.Name = "pB";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
           new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Расстояние";
            //  firstColumn.Name = "Status";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
          new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Экспресс";
            //  firstColumn.Name = "Status";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
          new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Дата";
            //  firstColumn.Name = "Status";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
                 new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Стоимость";
            //  firstColumn.Name = "Status";

            dgwValues.Columns.Add(firstColumn);
            firstColumn =
                new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Оплачено";
            //  firstColumn.Name = "Status";
            dgwValues.Columns.Add(firstColumn);
            //создание столбцов  


            //добавление столбцов  
            //   dgwValues.Columns.Add(firstColumn);
            //     myDataGridView.Columns.Add(secondColumn);
            //     myDataGridView.Columns.Add(thirdColumn);
            showbdOrder(orderdb.Show());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            switch (panel)
            {
                case 1:
                    groupBoxCar.Visible = !groupBoxCar.Visible;
                    comboBox2.SelectedIndex = 0;
                    break;
                case 2:
                    if (!btnProfitDriver.Enabled)
                    {
                        groupBoxProfit.Visible = !groupBoxProfit.Visible;
                    }else
                    {
                        groupBoxDriver.Visible = !groupBoxDriver.Visible;
                        comboBox1.SelectedIndex = 0;
                    }
                    break;
                case 4:
                    groupBoxClient.Visible = !groupBoxClient.Visible;
                    comboBox3.SelectedIndex = 0;
                    break;
                case 5: groupBoxOrder.Visible = !groupBoxOrder.Visible;
                    break;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedIndex == 0)
            {
                showbdDrivers(driverdb.Query(textBox1.Text, textBox2.Text, textBox4.Text));
            }
            else
            {
                showbdDrivers(driverdb.QueryStatus(textBox1.Text, textBox2.Text, textBox4.Text, (comboBox1.SelectedIndex == 1)));
            }
            
        }

        private void button4_Click_2(object sender, EventArgs e)
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
                    showdbCar(cardb.Query(textBox6.Text, textBox5.Text,cap));
            }
            else
            {
                showdbCar(cardb.QueryStatus(textBox6.Text, textBox5.Text, cap, (comboBox2.SelectedIndex == 1)));
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
           
            if (comboBox3.SelectedIndex == 0)
            {
                showbdClients(clientdb.Query(textBox9.Text, textBox8.Text, textBox7.Text, textBox10.Text));
            }
            else
            {
                showbdClients(clientdb.Query(textBox9.Text, textBox8.Text, textBox7.Text, textBox10.Text, (comboBox3.SelectedIndex == 1)));
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            decimal cost=0;
           decimal paid=0;
            try
            {
                if (textBox11.Text != "")
                {
                    cost = Convert.ToDecimal(textBox11.Text);
                }
               if(textBox15.Text != ""){
                    paid = Convert.ToDecimal(textBox15.Text);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            showbdOrder(orderdb.Query(textBox14.Text, textBox13.Text, textBox12.Text, cost, paid));
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            showbdProfit(profit_driverdb.Query(textBox18.Text));
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            groupBox1.Visible = true;

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            int day = 0;
            switch (comboBox4.SelectedIndex)
            {
                case 0: day = 7; break;
                case 1: day = 30; break;
                case 2: day = 12; break;
            }
            
            Graph g = new Graph();
            g.Show();
            g.ShowGr(orderdb.getMoney(day));
            
           
        }
    }
}
