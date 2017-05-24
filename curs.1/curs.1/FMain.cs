using Model;
using Controller;
using System;
using System.Windows.Forms;
using Email;
using Report;
using System.Threading;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text.pdf;

namespace View
{
    public delegate void showcardel(List<Car> l);
    public delegate void showorderdel(List<Order> l);
    public delegate void showclientdel(List<Client> l);
    public delegate void showdriverinfodel(List<Driver> l);
    public delegate void showdriverpaydel(List<Profit_driver> l);
    public partial class FMain : Form
    {
       

        DBDataContext db;
        CarDB cardb;
        OrderDB orderdb;
        ClientDB clientdb;
        DriverDB driverdb;
        Profit_driverDB profit_driverdb;
        ReportProfitController report;
       int panel = 0;
        public delegate void d();
        public FMain()
        {
            ratetr = new Thread(startratetr) { IsBackground = true,Priority= ThreadPriority.Lowest };
            tr = new Thread(starttrClient) { IsBackground = true };
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
            FrameOrderF f = new FrameOrderF(orderdb);
            f.ShowDialog();
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
                    dgwValues.Rows[i].Cells[0].Value = v.id_car;
                    dgwValues.Rows[i].Cells[1].Value = v.number;
                    dgwValues.Rows[i].Cells[2].Value = v.brand;
                    dgwValues.Rows[i].Cells[3].Value = v.carrying_capacity;
                    dgwValues.Rows[i].Cells[4].Value = v.length;
                    dgwValues.Rows[i].Cells[5].Value = v.heigth;
                    dgwValues.Rows[i].Cells[6].Value = v.width;
                    dgwValues.Rows[i].Cells[7].Value = v.status ? "+" : "-";
                    i++;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void showdbCar()
        {
            try
            {
                int i = 0;
                //lbValues.Items.Clear();
                dgwValues.Rows.Clear();
                foreach (var v in cardb.Show())
                {
                    dgwValues.Rows.Add();
                    dgwValues.Rows[i].Cells[0].Value = v.id_car;
                    dgwValues.Rows[i].Cells[1].Value = v.number;
                    dgwValues.Rows[i].Cells[2].Value = v.brand;
                    dgwValues.Rows[i].Cells[3].Value = v.carrying_capacity;
                    dgwValues.Rows[i].Cells[4].Value = v.length;
                    dgwValues.Rows[i].Cells[5].Value = v.heigth;
                    dgwValues.Rows[i].Cells[6].Value = v.width;
                    dgwValues.Rows[i].Cells[7].Value = v.status ? "+" : "-";
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
            btnSetReady.Visible = false;
            btnGraph.Visible = false;
            btnMail.Enabled = false;
            panel = 1;
            btnprintsalary.Visible = false;
            btnInsert.Enabled = btnDelete.Enabled = true;
            btnFilter.Enabled = true;
            btnRedact.Enabled = false;
            dgwValues.Columns.Clear();
            btnrating.Visible = false;
            panRateClients.Visible = false;
            btnProfitDriver.Visible = btnDriverInfo.Visible = false;
            bgwtracks.RunWorkerAsync();
            //FCar fc = new FCar(db);
            //   fc.ShowDialog();
        
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

        private void FMain_Load_1(object sender, EventArgs e)
        {
            btnSetReady.Visible = false;
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
                    catch
                    {
                        dgwValues.Rows[i].Cells[1].Value =
                        dgwValues.Rows[i].Cells[2].Value = "Не назначен";
                    }
                    dgwValues.Rows[i].Cells[3].Value = v.Client.full_name;
                    dgwValues.Rows[i].Cells[4].Value = v.point_of_arrival;
                    dgwValues.Rows[i].Cells[5].Value = v.point_of_departure;
                    dgwValues.Rows[i].Cells[6].Value = v.distance;
                    dgwValues.Rows[i].Cells[7].Value = v.express ? "+" : "-";
                    dgwValues.Rows[i].Cells[8].Value = v.reg_date.ToString("dd'/'MM'/'yyyy");
                    dgwValues.Rows[i].Cells[9].Value = v.cost;
                    dgwValues.Rows[i].Cells[10].Value = v.paid;
                    dgwValues.Rows[i].Cells[11].Value = v.status;

                    i++;


                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }
        void showbdOrder()
        {
            try
            {
                int i = 0;
                //lbValues.Items.Clear();
                dgwValues.Rows.Clear();
                foreach (var v in orderdb.Show())
                {
                    dgwValues.Rows.Add();
                    dgwValues.Rows[i].Cells[0].Value = v.id_order;
                    try
                    {
                        dgwValues.Rows[i].Cells[1].Value = v.Driver.full_name;
                        dgwValues.Rows[i].Cells[2].Value = v.Car.brand;
                    }
                    catch
                    {
                        dgwValues.Rows[i].Cells[1].Value =
                        dgwValues.Rows[i].Cells[2].Value = "Не назначен";
                    }
                    dgwValues.Rows[i].Cells[3].Value = v.Client.full_name;
                    dgwValues.Rows[i].Cells[4].Value = v.point_of_arrival;
                    dgwValues.Rows[i].Cells[5].Value = v.point_of_departure;
                    dgwValues.Rows[i].Cells[6].Value = v.distance;
                    dgwValues.Rows[i].Cells[7].Value = v.express ? "+" : "-";
                    dgwValues.Rows[i].Cells[8].Value = v.reg_date.ToString("dd'/'MM'/'yyyy");
                    dgwValues.Rows[i].Cells[9].Value = v.cost;
                    dgwValues.Rows[i].Cells[10].Value = v.paid;
                    dgwValues.Rows[i].Cells[11].Value = v.status;

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
                    dgwValues.Rows[i].Cells[5].Value = v.Order.Count >= 3 ? "+" : "-";
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void clearRows() {
            dgwValues.Rows.Clear();
        }
        void addRows() {
            dgwValues.Rows.Add();
        }
        void showbdClients()
        {
            del d = clearRows;
            try
            {
                int i = 0;
                //lbValues.Items.Clear();
                Invoke(d);
                d = addRows;
                foreach (var v in clientdb.Show())
                {
                    
                    Invoke(d);
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
            btnSetReady.Visible = false;
            btnGraph.Visible = false;
            OfferMailF f = new OfferMailF();
            f.ShowDialog();
            SendEmail send = new SendEmail();
            btnrating.Visible = false;
            panRateClients.Visible = false;
            btnProfitDriver.Visible = btnDriverInfo.Visible = false;
            //  send.SendMessage("eduard.arkhipov2017@yandex.ru", "test", "hehe", "D:\\1.ods");
            int error = 0;
            if (f.send)
            {
                for (int i = 0; i < dgwValues.Rows.Count; i++)
                    try { send.SendMessage(dgwValues.Rows[i].Cells[4].Value + "", "Выгодное предложение", "", "1.bmp"); }
                    catch { error++; }
                if (error > 0)
                    MessageBox.Show("Несколько писем не было отправлено: " + error);
                else
                    MessageBox.Show("Все письма были отправлены.");
            }
        }
        Thread tr;
        private delegate void del();
        DataGridViewTextBoxColumn firstColumn;
        private void starttrClient() {
            del d = filldgw;
            del d1 = showbdClients;
            del d2 = resetgrid;
            Invoke(d2);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Индекс";
            Invoke(d);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "ФИО";
            Invoke(d);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Номер телефона";
            Invoke(d);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Компания";
            Invoke(d);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Эл. почта";
            Invoke(d);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Постоянный клиент";
            Invoke(d);
            Invoke(d1);
        }

        private void resetgrid()
        {
           
            panRateClients.Visible = false;
            // panRateClients.Visible = true;
            btnProfitDriver.Visible = btnDriverInfo.Visible = false;
            dgwValues.Columns.Clear();
        }

        private void filldgw()
        {
            
            dgwValues.Columns.Add(firstColumn);
            

        }

        private void button9_Click(object sender, EventArgs e)
        {
            btnrating.Enabled = true;
            btnSetReady.Visible = false;
            btnprintsalary.Visible = false;
            btnGraph.Visible = false;
            btnMail.Enabled = true;
            btnrating.Visible = true;
            btnFilter.Enabled = true;
            btnRedact.Enabled = btnInsert.Enabled = btnDelete.Enabled = false;
            panel = 4;
            dgwValues.Columns.Clear();
            bgwclient.RunWorkerAsync();
           
          

        }

        private void button10_Click(object sender, EventArgs e)
        {
            btnSetReady.Visible = false;
            btnGraph.Visible = false;
            panel = 2;
            btnMail.Enabled = false;
            btnFilter.Enabled = true;
            btnRedact.Enabled = btnInsert.Enabled = btnDelete.Enabled=btnprintsalary.Visible = true;
           
            btnProfitDriver.Visible = btnDriverInfo.Visible = true;
            btnrating.Visible = false;
            panRateClients.Visible = false;
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
                    dgwValues.Rows[i].Cells[6].Value = v.status ? "+" : "-";
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
            panel = 3;
            btnRedact.Enabled = btnInsert.Enabled = btnDelete.Enabled = false;
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
            firstColumn.HeaderText = "Сумма";
            dgwValues.Columns.Add(firstColumn);
            firstColumn =
                 new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Дата";
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
                    dgwValues.Rows[i].Cells[3].Value = v.date;
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int costsum(int id) {
            int s = 0;
            foreach (var a in orderdb.Show(id))
                s += (int)a.cost;
            return s;
                    }
        Thread ratetr;
        private void startratetr() {
            d del = showrating;
            Invoke(del);
            
        }
        //List<int> l;
        //private double countrating() {
        //    double rating = 0;
        //    l = new List<int>();
        //    foreach (var a in clientdb.Show()) {
        //        rating += (a.Order.Count + costsum(a.id_client))/100;
        //            }
        //    return rating;
        //}
        Label l;
        List<Label> ll;
        private void showrating() {
            int pos = 10;
            List<Client> clientL = new List<Client>();
            ll = new List<Label>();
            clientL.AddRange(clientdb.Show());
            ll.Clear();
            foreach (var a in clientdb.Show())
            {
                Client hr = clientL[0];
                //  Panel c = new Panel() { Region = new System.Drawing.Region(ClientRectangle), BackColor = System.Drawing.Color.White, Size = new System.Drawing.Size(200, 50), Location = new System.Drawing.Point(pos, pos), BorderStyle = BorderStyle.FixedSingle };
                //   c.Controls.Add(new Label() { Text = "" + a.id_client + " - " + a.full_name + "\n" + "Заказов: " + a.Order.Count + "\n" + "На общую сумму: " + costsum(a.id_client) + " руб", AutoSize = true });
                for (int i = 0; i < clientL.Count; i++) {
                    if ((clientL[i].Order.Count + costsum(clientL[i].id_client)) > (hr.Order.Count + costsum(hr.id_client)))
                        hr = clientL[i];
                }
                clientL.Remove(hr);
                l = new Label();


                    l.Text = "" + hr.id_client + " - " + hr.full_name + "\n"
                    + "Заказов: " + hr.Order.Count + "\n" + "На общую сумму: " + costsum(hr.id_client) + " руб";
                l.AutoSize = true;
                l.BorderStyle = BorderStyle.FixedSingle;
                l.Location = new System.Drawing.Point(pos, pos);
                l.BackColor = System.Drawing.Color.White;

                
                l.MouseEnter += L_MouseEnter;
                panRateClients.Controls.Add(l);
                l = new Label();
                l.Name = "" + hr.id_client;
                l.Text = "Посмотреть заказы";
                l.AutoSize = true;
                l.BorderStyle = BorderStyle.FixedSingle;
                l.Location = new System.Drawing.Point(pos + 200, pos);
                l.BackColor = System.Drawing.Color.White;

                l.Visible = l.Enabled = false;
                l.MouseClick += L_MouseClick;
             panRateClients.Controls.Add(l);
                ll.Add(l);
                l = new Label();
                l.Text = "Посмотреть личные данные";
                l.AutoSize = true;
                l.BorderStyle = BorderStyle.FixedSingle;
                l.Location = new System.Drawing.Point(pos + 200, pos+25);
                l.BackColor = System.Drawing.Color.White;

                l.Visible = l.Enabled = false;
                l.MouseClick += L_MouseClick1;
                panRateClients.Controls.Add(l);
                ll.Add(l);
                pos += 60;
            }
            
        }

        private void L_MouseClick1(object sender, MouseEventArgs e)
        {
            ClientInfoF f = new ClientInfoF(clientdb, Convert.ToInt32(panRateClients.Controls[panRateClients.Controls.IndexOf((sender as Label)) -1].Name));
            f.ShowDialog();
        }

        private void L_MouseClick(object sender, MouseEventArgs e)
        {
            ClientOrdF f = new ClientOrdF(orderdb,Convert.ToInt32((sender as Label).Name));
            f.ShowDialog();
        }

        private void hideordlbl() {
            int i = 0;
            foreach (var a in ll) {
                a.Visible = a.Enabled = false; }
                }
        private void L_MouseEnter(object sender, EventArgs e)
        {
            hideordlbl();
            try
            {
                panRateClients.Controls[panRateClients.Controls.IndexOf(sender as Label) + 1].Visible = panRateClients.Controls[panRateClients.Controls.IndexOf(sender as Label) + 1].Enabled = true;
                panRateClients.Controls[panRateClients.Controls.IndexOf(sender as Label) + 2].Visible = panRateClients.Controls[panRateClients.Controls.IndexOf(sender as Label) + 2].Enabled = true;
            }
            catch { }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            panRateClients.Visible = true;
            panRateClients.Enabled = false;
            btnRedact.Enabled = btnInsert.Enabled = btnDelete.Enabled =btnFilter.Enabled=btnrating.Enabled= false;
            bgwrate.RunWorkerAsync();          
            
        }
        List<Client> clientL;
        Client hr;
        private void bgwrate_DoWork(object sender, DoWorkEventArgs e)
        {
            int pos = 10;
           clientL = new List<Client>();
            ll = new List<Label>();
            clientL.AddRange(clientdb.Show());
            ll.Clear();
            foreach (var a in clientdb.Show())
            {
                del d = addcontrol;
                del d1 = addcontroll;
                del d2 = removecontroll;
                hr = clientL[0];
                //  Panel c = new Panel() { Region = new System.Drawing.Region(ClientRectangle), BackColor = System.Drawing.Color.White, Size = new System.Drawing.Size(200, 50), Location = new System.Drawing.Point(pos, pos), BorderStyle = BorderStyle.FixedSingle };
                //   c.Controls.Add(new Label() { Text = "" + a.id_client + " - " + a.full_name + "\n" + "Заказов: " + a.Order.Count + "\n" + "На общую сумму: " + costsum(a.id_client) + " руб", AutoSize = true });
                for (int i = 0; i < clientL.Count; i++)
                {
                    if ((clientL[i].Order.Count + costsum(clientL[i].id_client)) > (hr.Order.Count + costsum(hr.id_client)))
                        hr = clientL[i];
                }
                Invoke(d2);
                l = new Label();


                l.Text = "" + hr.id_client + " - " + hr.full_name + "\n"
                + "Заказов: " + hr.Order.Count + "\n" + "На общую сумму: " + costsum(hr.id_client) + " руб";
                l.AutoSize = true;
                l.BorderStyle = BorderStyle.FixedSingle;
                l.Location = new System.Drawing.Point(pos, pos);
                l.BackColor = System.Drawing.Color.White;


                l.MouseEnter += L_MouseEnter;
                Invoke(d);
                l = new Label();
                l.Name = "" + hr.id_client;
                l.Text = "Посмотреть заказы";
                l.AutoSize = true;
                l.BorderStyle = BorderStyle.FixedSingle;
                l.Location = new System.Drawing.Point(pos + 200, pos);
                l.BackColor = System.Drawing.Color.White;
                l.MouseEnter += L_MouseEnter1;
                l.MouseLeave += L_MouseLeave;
                l.Visible = l.Enabled = false;
                l.MouseClick += L_MouseClick;
                Invoke(d);
                Invoke(d1);
                l = new Label(); //BlanchedAlmond
                l.Text = "Посмотреть личные данные";
                l.AutoSize = true;
                l.BorderStyle = BorderStyle.FixedSingle;
                l.Location = new System.Drawing.Point(pos + 200, pos + 25);
                l.BackColor = System.Drawing.Color.White;
                l.MouseEnter += L_MouseEnter1;
                l.MouseLeave += L_MouseLeave;
                l.Visible = l.Enabled = false;
                l.MouseClick += L_MouseClick1;
                Invoke(d);
                Invoke(d1);
                pos += 60;
            }
        }

        private void L_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).BackColor = System.Drawing.Color.White;
        }

        private void L_MouseEnter1(object sender, EventArgs e)
        {
            (sender as Label).BackColor = System.Drawing.Color.BlanchedAlmond;
        }

        private void removecontroll()
        {
            clientL.Remove(hr);
        }

        private void addcontrol()
        {
            panRateClients.Controls.Add(l);
        }
        private void addcontroll()
        {
            ll.Add(l);
        }

        private void bgwrate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panRateClients.Enabled = true;
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {

        }

        private void bgwclient_DoWork(object sender, DoWorkEventArgs e)
        {
            starttrClient();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FilterF f;
            switch (panel)
            {
                case 1:
                    showcardel cd = showdbCar;
                   f = new FilterF(panel, cd,cardb);
                    f.ShowDialog();
                    break;
                case 2:
                    showdriverinfodel dd = showbdDrivers;
                    f = new FilterF(panel, dd,driverdb);
                    f.ShowDialog();
                   
                    break;
                case 3:

                    showdriverpaydel dpd = showbdProfit;
                    f = new FilterF(panel, dpd,profit_driverdb);
                    f.ShowDialog();
                    break;
                case 4:
                    showclientdel cld = showbdClients;
                    f = new FilterF(panel, cld,clientdb);
                    f.ShowDialog();
                    break;
                case 5:
                    showorderdel od = showbdOrder;
                    f = new FilterF(panel, od,orderdb);
                    f.ShowDialog();
                    break;
            }
          
           
        }

        private void btnOrders_Click_1(object sender, EventArgs e)
        {
            btnSetReady.Visible = false;
            btnprintsalary.Visible = false;
            btnGraph.Visible = true;
            btnMail.Enabled = false;
            btnFilter.Enabled = true;
            panel = 5;
            btnRedact.Enabled = btnInsert.Enabled = false;
            btnDelete.Enabled = true;
            btnrating.Visible = false;
            panRateClients.Visible = false;
            dgwValues.Columns.Clear();
            btnProfitDriver.Visible = btnDriverInfo.Visible = false;
            bgworders.RunWorkerAsync();
          
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Form f;
            switch (panel)
            {
                case 1:
                    f = new FRedactCar(cardb);
                    f.ShowDialog();
                    showdbCar(cardb.Show());
                    break;
                case 2:
                    f = new FRedactDriver(driverdb);
                    f.ShowDialog();
                    showbdDrivers(driverdb.Show());
                    

                    break;
               
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            switch (panel)
            {
                case 1:
                    
                    cardb.Delete(Convert.ToInt32(dgwValues.CurrentRow.Cells[0].Value));
                    showdbCar(cardb.Show());
                    break;
                case 2:
                    driverdb.Delete(Convert.ToInt32(dgwValues.CurrentRow.Cells[0].Value));
                    showbdDrivers(driverdb.Show());

                    break;
                case 5:
            orderdb.Delete(Convert.ToInt32(dgwValues.CurrentRow.Cells[0].Value));
                    showbdOrder(orderdb.Show());
                    break;
            }
           
        }

        private void btnRedact_Click(object sender, EventArgs e)
        {

         FRedactDriver   f = new FRedactDriver(Convert.ToInt32(dgwValues.CurrentRow.Cells[0].Value),driverdb);
            f.ShowDialog();
            showbdDrivers(driverdb.Show());
           
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
 
            ReportProfitController report = new ReportProfitController(db);
            try
            {
            
               
                    iTextSharp.text.Document document = new iTextSharp.text.Document();
                PdfWriter writer = PdfWriter.GetInstance(document,
                 new FileStream("зп.pdf", FileMode.OpenOrCreate)
                     );

                    document.Open();


              

                    iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph(); //System.Diagnostics.Process.Start("путь к файлу");
                    p = new iTextSharp.text.Paragraph();
                    BaseFont bf = BaseFont.CreateFont(@"micross.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

                    p.Alignment = iTextSharp.text.Element.ALIGN_CENTER;

                    p = new iTextSharp.text.Paragraph();
                PdfPTable table = new PdfPTable(1);
               
                    p.Add(new iTextSharp.text.Phrase("Зарплата за месяц", new
        iTextSharp.text.Font(bf, 16)));
                    p.Add(Environment.NewLine);
                    p.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    p.SpacingAfter = 25;
                    document.Add(p);
                foreach (var a in report.Money())
                {

                    p = new iTextSharp.text.Paragraph();
                    try
                    {
                        table.AddCell(new PdfPCell(new iTextSharp.text.Phrase(a.ToString(), new iTextSharp.text.Font(bf, 14))));
                    }
                    catch { }
                   

                }
                p.Add(table);
                document.Add(p);

                document.Close();
                writer.Close();
                System.Diagnostics.Process.Start("зп.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            btnSetReady.Visible = false;
            Graph g = new Graph(orderdb);
            g.Show();
        }

        private void dgwValues_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click_4(object sender, EventArgs e)
        {try
            {
                orderdb.Done(Convert.ToInt32(dgwValues.CurrentRow.Cells[0].Value));
                showbdOrder(orderdb.Show());
            }
            catch { MessageBox.Show("Не удалось завершить операцию."); }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            btnSetReady.Visible = false;
        }

        private void FMain_Click(object sender, EventArgs e)
        {
            btnSetReady.Visible = false;
        }

        private void dgwValues_MouseClick(object sender, MouseEventArgs e)
        {if(panel==5)
            btnSetReady.Visible = true;
        }

        private void bgwdriverpayment_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bgwtracks_DoWork(object sender, DoWorkEventArgs e)
        {
            del d = filldgw;
            del d1 = showdbCar;
            del d2 = resetgrid;
            Invoke(d2);
          firstColumn =
    new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Индекс";

            Invoke(d);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Номер";
            firstColumn.Name = "Num";
            Invoke(d);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Марка";
            firstColumn.Name = "Mark";
            Invoke(d);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Грузоподъемность";
            firstColumn.Name = "Capacity";
            Invoke(d);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Длина";
            firstColumn.Name = "Length";
            Invoke(d);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Высота";
            firstColumn.Name = "Height";
            Invoke(d);
            firstColumn =
           new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Ширина";
            firstColumn.Name = "Width";
            Invoke(d);
            firstColumn =
           new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Свободен";
            firstColumn.Name = "Status";
            Invoke(d);
            //создание столбцов  


            //добавление столбцов  
            //   dgwValues.Columns.Add(firstColumn);
            //     myDataGridView.Columns.Add(secondColumn);
            //     myDataGridView.Columns.Add(thirdColumn);
            Invoke(d1);
        }

        private void bgworders_DoWork(object sender, DoWorkEventArgs e)
        {
            del d = filldgw;
            del d1 = showbdOrder;
            del d2 = resetgrid;
            Invoke(d2);
            firstColumn =
                  new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Индекс";
            firstColumn.Name = "ID";
            Invoke(d);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Водитель";
            firstColumn.Name = "Driver";
            Invoke(d);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Грузовик";
            firstColumn.Name = "Track";
            Invoke(d);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "ФИО клиента";
            firstColumn.Name = "fio";
            Invoke(d);
            firstColumn =
         new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Пункт А";
            firstColumn.Name = "pA";
            Invoke(d);
            firstColumn =
           new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Пункт Б";
            firstColumn.Name = "pB";
            Invoke(d);
            firstColumn =
           new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Расстояние";
            //  firstColumn.Name = "Status";
            Invoke(d);
            firstColumn =
          new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Экспресс";
            //  firstColumn.Name = "Status";
            Invoke(d);
            firstColumn =
          new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Дата";
            //  firstColumn.Name = "Status";
            Invoke(d);
            firstColumn =
                 new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Стоимость";
            //  firstColumn.Name = "Status";

            Invoke(d);
            firstColumn =
                new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Оплачено";
            //  firstColumn.Name = "Status";
            Invoke(d);
            firstColumn =
                new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "Статус";
            //  firstColumn.Name = "Status";
            Invoke(d);
            //создание столбцов  
            Invoke(d1);

            //добавление столбцов  
            //   dgwValues.Columns.Add(firstColumn);
            //     myDataGridView.Columns.Add(secondColumn);
            //     myDataGridView.Columns.Add(thirdColumn);

        }

        private void bgwdrivers_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
