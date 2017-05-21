using Controller;
using iTextSharp.text.pdf;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientBank;

namespace DesignLib
{
    delegate void DelMap(string s);
    public partial class Form1 : Form
    {
       
        List<TextBox> tblistprof;
        List<Label> lbllistprof;
        List<PictureBox> pblistmenu;
        int ves;


        public Form1()
        {
          
            InitializeComponent();
           
            ves = 100;
            printves();
            tblistprof = new List<TextBox>();
            lbllistprof = new List<Label>();
            proflist = new List<Control>();
            pblistmenu = new List<PictureBox>();
            ordlist = new List<Control>();
            ordmanlist = new List<Control>();
            DBDataContext db;

            fillproflbllist();
            fillproftblist();
            fillproflist();
            fillpblistmenu();
            fillordlist();
            fillordmanlist();

            this.Hide();

            LoginF lf = new LoginF();
            lf.ShowDialog();
            if (!iflog)
                Application.Exit();
            try
            {
                this.Show();
            }
            catch { }

            db = lf.db;
            client = Visitor.client;
            user = Visitor.user;
            clientdb = lf.clientdb;
            orderdb = lf.orderdb;

           

            filluserinfo();
            for (int i = 0; i < tblistprof.Count; i++)
                lbllistprof[i].Text = tblistprof[i].Text = userinfo[i];
            hidepans();
            showprofpan();
            dbthr = new Thread(filldatafromdb) { IsBackground = true };
            dbthr.Start();



        }
        Thread dbthr;
        delegate void dbdel();
        void filldatafromdb()
        {
            dbdel d //= filluserinfo;
= fillorderlistonpanel;
            Invoke(d);
        }

        string[] s;
        List<Control> proflist;
        List<Control> ordlist;
        List<Control> ordmanlist;
        void fillproflist()
        {

            proflist.Add(profpanel);
            proflist.Add(label1);
            proflist.Add(app);
            proflist.Add(dec);
        }
        void fillordlist()
        {

            ordlist.Add(papb);
            ordlist.Add(pbpb);
            ordlist.Add(waypb);
            ordlist.Add(wlengthlbl);
            ordlist.Add(wlengthpb);
            ordlist.Add(backbtn);
            ordlist.Add(nextbtn);
            ordlist.Add(orderpan);
            ordlist.Add(orderpan2);
            ordlist.Add(orderpan3);
          
        }
        void fillordmanlist()
        {
            ordmanlist.Add(ordmanpan);
        }
        void fillproftblist()
        {

            tblistprof.Add(famtb);
            tblistprof.Add(imyatb);
            tblistprof.Add(otchtb);
            tblistprof.Add(phonetb);
            tblistprof.Add(mailtb);
            tblistprof.Add(comptb);
            fillvalstbprof();
        }
        void fillpa(string s) {
            adralbl.Text = patb.Text = s.Replace("Unnamed Road;", "");
            distcnt();
        }
        void fillpb(string s)
        {
            adrblbl.Text = pbtb.Text = s.Replace("Unnamed Road;","");
            distcnt();
        }
        void fillpblistmenu()
        {
            pblistmenu.Add(profpb);
            pblistmenu.Add(ordpb);
            pblistmenu.Add(ordmanpb);
            pblistmenu.Add(paypb);
        }

        void fillproflbllist()
        {
            lbllistprof.Add(famlbl);
            lbllistprof.Add(imyalbl);
            lbllistprof.Add(otchlbl);
            lbllistprof.Add(phonelbl);
            lbllistprof.Add(maillbl);
            lbllistprof.Add(complbl);

            lastvalsprof();
        }
        Client client;
        User user;
        ClientDB clientdb;
        OrderDB orderdb;
        public static bool iflog = true;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            widthtb.Text = lengthtb.Text = heighttb.Text = "0";
            adralbl.Text = "Введите адрес";
            adrblbl.Text = "Введите адрес";
            Panel p = new Panel();
            p.Controls.Add(new Label() { Text = "%", ForeColor = Color.Black, Font = new Font("Times new Roman",16,FontStyle.Bold), Location=new Point(-1,2) });
            p.Size = new Size(30,30);
            p.BackColor = Color.Gold;
            profpanel.Controls.Add(p);
            profpanel.Controls[profpanel.Controls.IndexOf(p)].Location=new Point(profpanel.Size.Width-p.Width,0);
            costL = new List<String>();
            costL.Clear();


            //    costL.Add(15);
            //      costL.Add(20);
            //      costL.Add(22);
            //      costL.Add(2);
            //       costL.Add(0.9);
            //       costL.Add(1.5);
            //       costL.Add(1.1);
            //        costL.Add(0.85);
            /*0*/
            costL.Add("Начальная цена составляет 300 рублей");
            /*1*/
            costL.Add("Выбрана экспресс доставка. Цена увеличена на 50%");
            /*2*/
            costL.Add("В зимнее время цена увеличена на 10%");
            /*3*/
            costL.Add("Сегодня 11-е число. Действует скидка 10%");
            /*4*/
            costL.Add("Действует скидка постоянному клиенту 15%");
            /*5*/
            costL.Add("Вес груза>500. За каждый кг сверх 500кг к стоимости добавлено 2 рубля");
            /*6*/
            costL.Add("Длина маршрута более 100км. Цена за километр составляет 15 рублей");
            /*7*/
            costL.Add("Длина маршрута менее 100км. Цена за километр составляет 20 рублей");
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
        void hidepans()
        {
            foreach (Control a in proflist)
                a.Visible = false;
            foreach (Control a in ordlist)
                a.Visible = false;
            ordmanpan.Visible = false;
            btninfo.Visible=false;
            lblinfo.Visible=false;
        }
        private void famlbl_Click(object sender, EventArgs e)
        {
            hideproftb();
            showproflbl();
            famtb.Visible = true;
            (sender as Label).Visible = false;
        }

        private void imyalbl_Click(object sender, EventArgs e)
        {
            hideproftb();
            showproflbl();
            imyatb.Visible = true;
            (sender as Label).Visible = false;
        }

        private void otchlbl_Click(object sender, EventArgs e)
        {
            hideproftb();
            showproflbl();
            otchtb.Visible = true;
            (sender as Label).Visible = false;
        }

        private void phonelbl_Click(object sender, EventArgs e)
        {
            hideproftb();
            showproflbl();
            phonetb.Visible = true;
            (sender as Label).Visible = false;
        }

        private void maillbl_Click(object sender, EventArgs e)
        {
            hideproftb();
            showproflbl();
            mailtb.Visible = true;
            (sender as Label).Visible = false;
        }

        private void complbl_Click(object sender, EventArgs e)
        {
            hideproftb();
            showproflbl();
            comptb.Visible = true;
            (sender as Label).Visible = false;

        }
        void showproflbl()
        {
            foreach (Label a in lbllistprof)
                a.Visible = true;
        }
        void showordpan()
        {
            foreach (Control a in ordlist)
                a.Visible = true;
        }
        void hideproftb()
        {
            foreach (TextBox a in tblistprof)
                a.Visible = false;
        }
        string[] userinfo;
        void filluserinfo()
        {
            string[] fio;

            fio = client.full_name.Split(' ');

            userinfo = new string[10];
            loglbl.Text = userinfo[6] = user.login;
            userinfo[0] = fio[0];
            if (fio.Length >= 2)
                userinfo[1] = fio[1];
            if (fio.Length >= 3)
                userinfo[2] = fio[2];

            userinfo[3] = client.phone_number;
            userinfo[4] = client.e_mail==null?"-":client.e_mail;
            userinfo[5] = client.company;

        }
        void filltextproftblbl()
        {
            for (int i = 0; i < tblistprof.Count; i++)
                lbllistprof[i].Text = tblistprof[i].Text;

        }
        void fillstandartvals()
        {
            for (int i = 0; i < tblistprof.Count; i++)
                 tblistprof[i].Text=lbllistprof[i].Text;

        }
        void fillvalstbprof()
        {
            for (int i = 0; i < tblistprof.Count; i++)
            {
                lbllistprof[i].Text = tblistprof[i].Text = s[i];
            }

        }
        void lastvalsprof()
        {
            s = new string[lbllistprof.Count];

            for (int i = 0; i < s.Length; i++)
            {
                s[i] = lbllistprof[i].Text;
            }

        }
        Thread tprof;
        void updprofinfo()
        {
            clientdb.Update(client.id_client, famtb.Text + " " + imyatb.Text + " " + otchtb.Text, phonetb.Text, comptb.Text, mailtb.Text);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            filltextproftblbl();
            lastvalsprof();
            tprof = new Thread(updprofinfo) { IsBackground = true };
            tprof.Start();
            tprof.Priority = ThreadPriority.Lowest;
        }

        private void dec_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tblistprof.Count; i++)
                lbllistprof[i].Text = tblistprof[i].Text = userinfo[i];
            filltextproftblbl();

        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            // (sender as Control).Size = new Size((sender as Control).Size.Width+5, (sender as Control).Size.Height+5);
            (sender as Control).ForeColor = Color.Gray;

        }
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            (sender as Control).Size = new Size((sender as Control).Size.Width + 5, (sender as Control).Size.Height + 5);
        }
        private void label3_MouseLeave(object sender, EventArgs e)
        {
            (sender as Control).ForeColor = Color.White;
        }
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            (sender as Control).Size = new Size((sender as Control).Size.Width - 5, (sender as Control).Size.Height - 5);
        }
        private void proflbl_Click(object sender, EventArgs e)
        {
            hidepans();
            hidemenupb();
            showprofpan();
            filluserinfo();
            for (int i = 0; i < tblistprof.Count; i++)
                lbllistprof[i].Text = tblistprof[i].Text = userinfo[i];
            filltextproftblbl();
            profpb.Visible = true;
        }
        void showprofpan()
        {
            foreach (Control a in proflist)
                if (!(a is TextBox))
                    a.Visible = true;
        }
        void hidemenupb()
        {
            foreach (PictureBox a in pblistmenu)
                a.Visible = false;
        }

        private void ordlbl_Click(object sender, EventArgs e)
        {
            hidemenupb();
            hidepans();
            showordpan();
            ordpb.Visible = true;
            ordlist[8].Visible = false;
            ordlist[9].Visible = false;
            backbtn.Visible = false;
            ordcnt = 7;

        }

        private void ordmanlbl_Click(object sender, EventArgs e)
        {
            hidemenupb();
            ordmanpb.Visible = true;
            hidepans();

            ordmanpan.Visible = true;

        }

        private void paylbl_Click(object sender, EventArgs e)
        {
            hidemenupb();
            paypb.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            menupan.BackColor = Color.Transparent;
            menupan.Visible = !menupan.Visible;
            menupan.BackColor = Color.Transparent;

        }



        private void minbtn_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Control).Size = new Size((sender as Control).Size.Width + 5, (sender as Control).Size.Height + 5);

        }

        private void maxbtn_MouseUp(object sender, MouseEventArgs e)
        {
            (sender as Control).Size = new Size((sender as Control).Size.Width - 5, (sender as Control).Size.Height - 5);
        }
        void printves()
        {
            veslbl.Text = "" + ves + " кг";
        }
        private void minbtn_Click(object sender, EventArgs e)
        {
            if (ves >= 10)
                ves -= 10;
            printves();
        }

        private void maxbtn_Click(object sender, EventArgs e)
        {
            ves += 10;
            printves();
        }

       
        void distcnt()
        {
            try
            {
                adralbl.Text = patb.Text;
                adrblbl.Text = pbtb.Text;
                if (patb.Text != "" && pbtb.Text != "")
                {
                    try
                    {
                        dist = orderdb.countDistantion(adralbl.Text, adrblbl.Text);
                        wlengthlbl.Text = "" + dist + " км";
                    }
                    catch { }
                }
            }
            catch { }
        }
        double cost;
        double dist = 0;
        void printcost()
        {
            costlbl.Text = "" + cost + " руб.";
            createordbtn.Enabled = true;
            foreach (String a in costL1)
            {
                lblinfo.Text += a + "\n";
            }
        }
        delegate void costdel();
        List<String> costL;
        List<String> costL1;
        public double CountCost(double distance, double weight, bool express, int id)
        {  
            costL1=new List<String>();
            costL1.Clear();
            costL1.Add(costL[0]);


            double cost = 0;
            DateTime curDate = DateTime.Now;
          
            if (distance > 100)
            {
                cost += 300 +distance*15;
                costL[6] += " (" + distance*15 + " руб).";
                costL1.Add(costL[6]);
            }
            else
            {
                cost += 300 + distance*20;
                costL[7] += " (" + distance*20 + " руб).";
                costL1.Add(costL[7]);
            }

            if (weight > 500)
            {
                cost += (weight - 500) * 2;
                costL[5]+=" ("+ (weight - 500) * 2 + " руб).";
                costL1.Add(costL[5]);

            }
            if (express)
            {
                costL[1] += " (" + cost * 0.5 + " руб).";
                cost *= 1.5;
                costL1.Add(costL[1]);
            }

            if (curDate.Date.Day == 11)
            {
                costL[3] += " (" + cost * 0.1 + " руб).";
                cost *= 0.9;
                costL1.Add(costL[3]);
            }
            if (curDate.Date.Month < 4)
            {
                costL[2] += " (" + cost * 0.1 + " руб).";
                cost *= 1.1;
                costL1.Add(costL[2]);
            }
            if (clientdb.IsVIPClient(id))
            {
                costL[4] += " (" + cost * 0.15 + " руб).";
                cost *= 0.85;
                costL1.Add(costL[4]);
            }
            
            return cost;
        }
        void costcnt()
        {
            
            costdel cd = printcost;
           
            cost =  CountCost(dist, ves, checkBox1.Checked, client.id_client);
            Invoke(cd);


        }
        private void papb_Click(object sender, EventArgs e)
        {


            MapF f = new MapF();
            f.addev(fillpa);
            f.Show();
          
        }

        private void pbpb_Click(object sender, EventArgs e)
        {
            MapF f = new MapF();
            f.addev(fillpb);
            f.Show();
           
        }



        private void patb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                adralbl.Text = patb.Text;
                patb.Visible = false;
                adralbl.Visible = true;
                distcnt();


            }
        }

        private void pbtb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                adrblbl.Text = pbtb.Text;
                pbtb.Visible = false;
                adrblbl.Visible = true;
                distcnt();

            }
        }

        private void orderpan_Click(object sender, EventArgs e)
        {
            patb.Visible = false;
            pbtb.Visible = false;
            adralbl.Text = patb.Text;
            adrblbl.Text = pbtb.Text;
            adralbl.Visible = true;
            adrblbl.Visible = true;
            distcnt();
        }
        int ordcnt = 7;
        Thread costtr;
        private void nextbtn_Click(object sender, EventArgs e)
        {
            if (ves != 0 && dist != 0)
            {
                if (ordcnt < 9)
                {
                    ordcnt++;
                    hidepans();
                    nextbtn.Visible = backbtn.Visible = true;
                    ordlist[ordcnt].Visible = true;
                    if (ordcnt == 9)
                    {
                        costtr = new Thread(costcnt) { IsBackground = true };
                        costtr.Start();
                        lblinfo.Text = "";
                       
                        nextbtn.Visible = false;
                        btninfo.Visible = true;
                       

                    }


                }
                backbtn.Visible = true;
            }
            else MessageBox.Show("Заполните обязательные поля");

        }

        private void backbtn_Click(object sender, EventArgs e)
        {

            if (ordcnt > 7)
            {
                ordcnt--;
                hidepans();
                nextbtn.Visible = backbtn.Visible = true;
                ordlist[ordcnt].Visible = true;
                if (ordcnt == 7)
                {
                    showordpan();
                    orderpan2.Visible = false;
                    orderpan3.Visible = false;
                    backbtn.Visible = false;
                }
            }
            nextbtn.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();
            fd.Filter = "Text Files|*.txt";
            if (fd.ShowDialog() != DialogResult.OK) return;
            Bank bank = new Bank(fd.FileName);

            //платим в  клиент-банке
            //try
            //{
            //    bank.WritePaid(client, Convert.ToDouble(textBox1.Text));
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


            //считываем счет клиент-банка
            double paid = 0;
            foreach (Doc1C cb in bank.Parser())
            {
                if (cb.Recieveraccount.Equals(Bank.OURAdress))
                {
                    paid += Convert.ToDouble(cb.Summ);
                }
            }
            //если денег хватает на аванс, то создаем заказ
            if (cost / 10 <= paid)
            {
                orderdb.Insert(adralbl.Text, adrblbl.Text, (decimal)ves, Convert.ToDecimal(widthtb.Text),
                        Convert.ToDecimal(heighttb.Text), Convert.ToDecimal(lengthtb.Text),
                        checkBox1.Checked, commenttb.Text, dist, (decimal)cost, (decimal)paid);
                MessageBox.Show("Заказ на сумму" + cost + " руб. успешно создан!");
            }
            else
            {
                MessageBox.Show("денег не хватает" + (cost / 10 - paid));
            }
            
            createorderpan();

        }

        List<Panel> p;
        void createorderpan() {
            int ordY = 0;
            
            Label l;
            PictureBox pb;
            p.Add(new Panel());
            int i1 =p.Count - 1;
            p[i1].Name = "" + orderdb.Show()[orderdb.Show().Count-1].id_order;
            p[i1].BackColor = Color.Transparent;
            p[i1].Location = new Point(0, ordY);
            p[i1].Size = new Size(ordmanpan.Width - 20, ordmanpan.Height / 4 - 2);
            p[i1].BackgroundImage = Image.FromFile("whiteborder4.png");
            p[i1].BackgroundImageLayout = ImageLayout.Stretch;
            l = new Label();
            l.Text = "" + orderdb.Show()[orderdb.Show().Count - 1].reg_date.Day + "." + orderdb.Show()[orderdb.Show().Count - 1].reg_date.Month + "." + orderdb.Show()[orderdb.Show().Count - 1].reg_date.Year;
            l.Location = new Point(2, 5);
            l.Font = new Font(l.Font.Name, 10, l.Font.Style);
            l.ForeColor = Color.White;
            l.AutoSize = true;
            p[i1].Controls.Add(l);
            l = new Label();
            l.Location = new Point(2, 40);
            l.Font = new Font(l.Font.Name, 18, l.Font.Style);
            l.Text = orderdb.Show()[orderdb.Show().Count - 1].express ? "Э" : "О";
            l.AutoSize = true;
            l.ForeColor = Color.White;
            p[i1].Controls.Add(l);
            l = new Label();
            l.Location = new Point(75, 5);
            l.Font = new Font(l.Font.Name, 11, l.Font.Style);
            l.Text = "Пункт А:";
            l.AutoSize = true;
            l.ForeColor = Color.White;
            p[i1].Controls.Add(l);
            l = new Label();
            l.Location = new Point(75, 30);
            l.Font = new Font(l.Font.Name, 11, l.Font.Style);
            l.Text = "Пункт B:";
            l.AutoSize = true;
            l.ForeColor = Color.White;
            p[i1].Controls.Add(l);
            l = new Label();
            l.Location = new Point(145, 5);
            l.Font = new Font(l.Font.Name, 11, l.Font.Style);
            l.Text = orderdb.Show()[orderdb.Show().Count - 1].point_of_departure;
            l.AutoSize = false;
            l.Size = new Size(220, 20);
            l.ForeColor = Color.White;
            p[i1].Controls.Add(l);
            l = new Label();
            l.Location = new Point(145, 30);
            l.Font = new Font(l.Font.Name, 11, l.Font.Style);
            l.Text = orderdb.Show()[orderdb.Show().Count - 1].point_of_arrival;
            l.AutoSize = false;
            l.Size = new Size(220, 20);
            l.ForeColor = Color.White;
            p[i1].Controls.Add(l);
            l = new Label();
            l.Location = new Point(75, 55);
            l.Font = new Font(l.Font.Name, 11, l.Font.Style);
            l.Text = "Расстояние:";
            l.AutoSize = true;
            l.ForeColor = Color.White;
            p[i1].Controls.Add(l);
            l = new Label();
            l.Location = new Point(175, 55);
            l.Font = new Font(l.Font.Name, 11, l.Font.Style);
            l.AutoSize = true;
            l.Text = "" + orderdb.Show()[orderdb.Show().Count - 1].distance + " км";
            l.ForeColor = Color.Red;
            p[i1].Controls.Add(l);
            l = new Label();
            l.Location = new Point(360, 35);
            l.Font = new Font(l.Font.Name, 14, l.Font.Style);
            l.AutoSize = true;
            l.Text = "" + orderdb.Show()[orderdb.Show().Count - 1].cost + " руб.";
            l.ForeColor = Color.FromArgb(0, 202, 33);
            p[i1].Controls.Add(l);
            l = new Label();
            l.Location = new Point(360, 55);
            l.Font = new System.Drawing.Font(l.Font.Name, 12, l.Font.Style);
            l.AutoSize = true;
            l.Text = "" + orderdb.Show()[orderdb.Show().Count - 1].paid + " руб.";
            l.ForeColor = Color.White;
            p[i1].Controls.Add(l);
            l = new Label();
            l.Location = new Point(p[i1].Size.Width - 15, p[i1].Size.Height - 15);
            l.AutoSize = false;
            l.Size = new Size(15, 15);
            l.BackColor = orderdb.Show()[orderdb.Show().Count - 1].status.Equals("заказ обрабатывается") ? Color.Gold : Color.Green;
            p[i1].Controls.Add(l);
            pb = new PictureBox();
            pb.BackgroundImage = Image.FromFile("removeorder.png");
            pb.BackgroundImageLayout = ImageLayout.Center;
            pb.Size = new Size(20, 20);
            pb.Location = new Point(492, 5);
            pb.MouseEnter += btn_MouseEnter;
            pb.MouseLeave += btn_MouseLeave;
            pb.MouseClick += Pb_MouseClick;
            p[i1].Controls.Add(pb);
            pb = new PictureBox();
            pb.BackgroundImage = Image.FromFile("printorder.png");
            pb.BackgroundImageLayout = ImageLayout.Center;
            pb.Size = new Size(20, 20);
            pb.Location = new Point(468, 5);
            pb.MouseEnter += btn_MouseEnter;
            pb.MouseLeave += btn_MouseLeave;
            pb.MouseClick += Pb_MouseClick1;
            p[i1].Controls.Add(pb);
            ordmanpan.Controls.Add(p[i1]);
           
            setloactionorderlist();

        }

        private void Pb_MouseClick1(object sender, MouseEventArgs e)
        {
            try
            {
                if (p != null)
                    foreach (var a in p)
                    {
                        if (a.Contains(sender as PictureBox))
                        {
                            foreach (var b in orderdb.Show())
                                if (b.id_order == Convert.ToInt32(a.Name))
                                {
                                    iTextSharp.text.Document document = new iTextSharp.text.Document();
                                    PdfWriter writer = PdfWriter.GetInstance(document,
                                     new FileStream("заказ_от_" + b.reg_date.Day + "." + b.reg_date.Month + "." + b.reg_date.Year + ".pdf", FileMode.OpenOrCreate)
                                     );

                                    document.Open();

                                    iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph(); //System.Diagnostics.Process.Start("путь к файлу");
                                    p = new iTextSharp.text.Paragraph();
                                    BaseFont bf = BaseFont.CreateFont(@"micross.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

                                    p.Alignment = iTextSharp.text.Element.ALIGN_CENTER;

                                    p = new iTextSharp.text.Paragraph();
                                    p.Add(new iTextSharp.text.Phrase("Заказ от " + b.reg_date.Day + "." + b.reg_date.Month + "." + b.reg_date.Year, new
                        iTextSharp.text.Font(bf, 16)));
                                    p.Add(Environment.NewLine);
                                    p.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                                    p.SpacingAfter = 25;
                                    document.Add(p);

                                    PdfPTable table = new PdfPTable(5);
                                    p = new iTextSharp.text.Paragraph();

                                    table.AddCell(new PdfPCell(new iTextSharp.text.Phrase("Откуда", new iTextSharp.text.Font(bf, 14))));
                                    table.AddCell(new PdfPCell(new iTextSharp.text.Phrase("Куда", new iTextSharp.text.Font(bf, 14))));
                                    table.AddCell(new PdfPCell(new iTextSharp.text.Phrase("Расстояние", new iTextSharp.text.Font(bf, 14))));
                                    table.AddCell(new PdfPCell(new iTextSharp.text.Phrase("Стоимость", new iTextSharp.text.Font(bf, 14))));
                                    table.AddCell(new PdfPCell(new iTextSharp.text.Phrase("Оплачено", new iTextSharp.text.Font(bf, 14))));

                                    table.AddCell(new PdfPCell(new iTextSharp.text.Phrase("" + b.point_of_departure, new iTextSharp.text.Font(bf, 14))));//b.point_of_arrival)));
                                    table.AddCell(new PdfPCell(new iTextSharp.text.Phrase("" + b.point_of_arrival, new iTextSharp.text.Font(bf, 14))));
                                    table.AddCell(new PdfPCell(new iTextSharp.text.Phrase("" + b.distance + " км", new iTextSharp.text.Font(bf, 14))));
                                    table.AddCell(new PdfPCell(new iTextSharp.text.Phrase("" + b.cost + " руб.", new iTextSharp.text.Font(bf, 14))));
                                    table.AddCell(new PdfPCell(new iTextSharp.text.Phrase("" + b.paid + " руб.", new iTextSharp.text.Font(bf, 14))));

                                    p.Add(table);
                                    document.Add(p);

                                    document.Close();
                                    writer.Close();
                                    System.Diagnostics.Process.Start("заказ_от_" + b.reg_date.Day + "." + b.reg_date.Month + "." + b.reg_date.Year + ".pdf");
                                }

                            break;
                        }
                    }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }


            void fillorderlistonpanel()
        {
           
            int ordY = 0;
            int i1 = 0;
            Label l;
            PictureBox pb;
            p = new List<Panel>();

            foreach (var a in orderdb.Show())
            {
                if (a.id_client == client.id_client)
                    {
                        p.Add(new Panel());
                        p[i1].Name = "" + a.id_order;
                        p[i1].BackColor = Color.Transparent;
                        p[i1].Location = new Point(0, ordY);
                        p[i1].Size = new Size(ordmanpan.Width - 20, ordmanpan.Height / 4 - 2);
                        p[i1].BackgroundImage = Image.FromFile("whiteborder4.png");
                        p[i1].BackgroundImageLayout = ImageLayout.Stretch;
                        l = new Label();
                        l.Text = "" + a.reg_date.Day + "." + a.reg_date.Month + "." + a.reg_date.Year;
                        l.Location = new Point(2, 5);
                        l.Font = new Font(l.Font.Name, 10, l.Font.Style);
                        l.ForeColor = Color.White;
                        l.AutoSize = true;
                        p[i1].Controls.Add(l);
                        l = new Label();
                        l.Location = new Point(2, 40);
                        l.Font = new Font(l.Font.Name, 18, l.Font.Style);
                        l.Text = a.express ? "Э" : "О";
                        l.AutoSize = true;
                        l.ForeColor = Color.White;
                        p[i1].Controls.Add(l);
                        l = new Label();
                        l.Location = new Point(75, 5);
                        l.Font = new Font(l.Font.Name, 11, l.Font.Style);
                        l.Text = "Пункт А:";
                        l.AutoSize = true;
                        l.ForeColor = Color.White;
                        p[i1].Controls.Add(l);
                        l = new Label();
                        l.Location = new Point(75, 30);
                        l.Font = new Font(l.Font.Name, 11, l.Font.Style);
                        l.Text = "Пункт B:";
                        l.AutoSize = true;
                        l.ForeColor = Color.White;
                        p[i1].Controls.Add(l);
                        l = new Label();
                        l.Location = new Point(145, 5);
                        l.Font = new Font(l.Font.Name, 11, l.Font.Style);
                        l.Text = a.point_of_departure;
                    l.AutoSize = false;
                    l.Size = new Size(220, 20);
                    l.ForeColor = Color.White;
                        p[i1].Controls.Add(l);
                        l = new Label();
                        l.Location = new Point(145, 30);
                        l.Font = new Font(l.Font.Name, 11, l.Font.Style);
                        l.Text = a.point_of_arrival;
                    l.AutoSize = false;
                    l.Size = new Size(220, 20);
                    l.ForeColor = Color.White;
                        p[i1].Controls.Add(l);
                        l = new Label();
                        l.Location = new Point(75, 55);
                        l.Font = new Font(l.Font.Name, 11, l.Font.Style);
                        l.Text = "Расстояние:";
                        l.AutoSize = true;
                        l.ForeColor = Color.White;
                        p[i1].Controls.Add(l);
                        l = new Label();
                        l.Location = new Point(175, 55);
                        l.Font = new Font(l.Font.Name, 11, l.Font.Style);
                        // l.AutoSize = true; orderdb.Show()[i1].
                        l.Text = "" +a.distance + " км";
                        l.ForeColor = Color.Red;
                        p[i1].Controls.Add(l);
                        l = new Label();
                        l.Location = new Point(360, 35);
                        l.Font = new Font(l.Font.Name, 14, l.Font.Style);
                        l.AutoSize = true;
                        l.Text = "" + a.cost + " руб.";
                        l.ForeColor = Color.FromArgb(0, 202, 33);
                        p[i1].Controls.Add(l);
                        l = new Label();
                        l.Location = new Point(360, 55);
                        l.Font = new Font(l.Font.Name, 12, l.Font.Style);
                        l.AutoSize = true;
                        l.Text = "" + a.paid + " руб.";
                        l.ForeColor = Color.White;
                        p[i1].Controls.Add(l);
                        l = new Label();
                        l.Location = new Point(p[i1].Size.Width - 15, p[i1].Size.Height - 15);
                        l.AutoSize = false;
                        l.Size = new Size(15, 15);
                        l.BackColor = a.status.Equals("заказ обрабатывается") ? Color.Gold : Color.Green;
                        p[i1].Controls.Add(l);
                        pb = new PictureBox();
                        pb.BackgroundImage = Image.FromFile("removeorder.png");
                        pb.BackgroundImageLayout = ImageLayout.Center;
                        pb.Size = new Size(20, 20);
                        pb.Location = new Point(492, 5);
                        pb.MouseEnter += btn_MouseEnter;
                        pb.MouseLeave += btn_MouseLeave;
                        pb.MouseClick += Pb_MouseClick;
                        p[i1].Controls.Add(pb);
                        pb = new PictureBox();
                        pb.BackgroundImage = Image.FromFile("printorder.png");
                        pb.BackgroundImageLayout = ImageLayout.Center;
                        pb.Size = new Size(20, 20);
                        pb.Location = new Point(468, 5);
                        pb.MouseEnter += btn_MouseEnter;
                        pb.MouseLeave += btn_MouseLeave;
                        pb.MouseClick += Pb_MouseClick1;
                        p[i1].Controls.Add(pb);
                        ordmanpan.Controls.Add(p[i1]);
                        ordY += ordmanpan.Height / 4 - 2;
                        i1++;
                    }
            }
        }

        private void setloactionorderlist()
        {
            int ordY1 = 0;
    
            ordmanpan.VerticalScroll.Value = 0;

            foreach (var a in ordmanpan.Controls)
            {
                try
                {
                    (a as Control).Location = new Point(0, ordY1);
                    ordY1 += ordmanpan.Size.Height / 4 - 2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



        }

        int ypan = -1;
        private void Pb_MouseClick(object sender, MouseEventArgs e)
        {
            // setloactionorderlist();
            if (p != null)
                foreach (var a in p)
                {

                    if (a.Contains(sender as PictureBox))
                    {

                        try
                        {

                            ypan = a.Location.Y;
                            orderdb.Delete(Convert.ToInt32(a.Name));
                            foreach (var a1 in a.Controls)
                                (a1 as Control).Dispose();
                            a.Dispose();
                            p.Remove(a);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }

                }

            setloactionorderlist();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void profpanel_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var a in profpanel.Controls)
            {
                if (a is TextBox)
                    (a as TextBox).Visible = false;
                if (a is Label)
                (a as Label).Visible = true;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void adralbl_MouseClick(object sender, MouseEventArgs e)
        {
            patb.Visible = !patb.Visible;
            pbtb.Visible = false;
            adralbl.Visible = !adralbl.Visible;
            adrblbl.Visible = true;
            distcnt();
        }

        private void adrblbl_MouseClick(object sender, MouseEventArgs e)
        {
            pbtb.Visible = !pbtb.Visible;
            patb.Visible = false;
            adrblbl.Visible = !adrblbl.Visible;
            adralbl.Visible = true;
            distcnt();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            lblinfo.Enabled = true;
            lblinfo.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            lblinfo.Visible = false;
            lblinfo.Enabled = false;
        }
        
    }
}
