﻿using Controller;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignLib
{
    public partial class Form1 : Form
    {
        List<TextBox> tblistprof;
        List<Label> lbllistprof;
        List<PictureBox> pblistmenu;
        int ves;
        int height = 0;
        int width = 0;
        int length = 0;
        int waylength = 0;
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


            filltextproftblbl();
            for (int i = 0; i < tblistprof.Count; i++)
                lbllistprof[i].Text = tblistprof[i].Text = userinfo[i];
            hidepans();
            showprofpan();


            fillorderlistonpanel();
        }
        string[] s;
        List<Control> proflist;
        List<Control> ordlist;
        List<Control> ordmanlist;
        List<Control> paylist;
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
            adralbl.Text = "ульяновск";
            adrblbl.Text = "подольск";
        }
        void hidepans()
        {
            foreach (Control a in proflist)
                a.Visible = false;
            foreach (Control a in ordlist)
                a.Visible = false;
            ordmanpan.Visible = false;
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
            userinfo[4] = "emptymail@mail.ru";
            userinfo[5] = client.company;

        }
        void filltextproftblbl()
        {
            for (int i = 0; i < tblistprof.Count; i++)
                lbllistprof[i].Text = tblistprof[i].Text;

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
            clientdb.Update(client.id_client, famtb.Text + " " + imyatb.Text + " " + otchtb.Text, phonetb.Text, comptb.Text);
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
            fillvalstbprof();
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
        int i = 0;
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

        double dist = 0;
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
                        wlengthlbl.Text = "" + orderdb.countDistantion(adralbl.Text, adrblbl.Text) + " км";
                    }
                    catch { }
                }
            }
            catch { }
        }
        double cost;
        void printcost()
        {
            costlbl.Text = "" + cost + " руб.";
        }
        delegate void costdel();
        void costcnt()
        {
            costdel cd = printcost;
            cost = 0;
            if (orderdb.countDistantion(adralbl.Text, adrblbl.Text) > 100)
            {
                cost += 200 + orderdb.countDistantion(adralbl.Text, adrblbl.Text) * 15;
            }
            if (orderdb.countDistantion(adralbl.Text, adrblbl.Text) <= 100)
            {
                cost += 400 + orderdb.countDistantion(adralbl.Text, adrblbl.Text) * 20;
            }
            if (ves > 500)
                cost += (ves - 500) * 2;
            if (checkBox1.Checked)
                cost *= 1.5;
            if (orderdb.Show().Count >= 3)
            {
                cost *= 0.85;
            }
            Invoke(cd);


        }
        private void papb_Click(object sender, EventArgs e)
        {
            patb.Visible = !patb.Visible;
            pbtb.Visible = false;
            adralbl.Visible = !adralbl.Visible;
            adrblbl.Visible = true;
            distcnt();
        }

        private void pbpb_Click(object sender, EventArgs e)
        {
            pbtb.Visible = !pbtb.Visible;
            patb.Visible = false;
            adrblbl.Visible = !adrblbl.Visible;
            adralbl.Visible = true;
            distcnt();
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
                        nextbtn.Visible = false;

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
            orderdb.Insert(adralbl.Text, adrblbl.Text, (decimal)ves, Convert.ToDecimal(widthtb.Text), Convert.ToDecimal(heighttb.Text), Convert.ToDecimal(lengthtb.Text), checkBox1.Checked, (decimal)cost, commenttb.Text);
            MessageBox.Show("Заказ на сумму" + cost + " руб. успешно создан!");
        }

        List<Panel> p;
        void fillorderlistonpanel()
        {
            try
            {
                orderdb.Insert("ульяновск", "подольск", 100, 0, 0, 0, true, 1200, "");
                orderdb.Insert("ульяновск", "нефтюганск", 100, 0, 0, 0, true, 1200, "");
                orderdb.Insert("ульяновск", "москва", 100, 0, 0, 0, true, 1200, "");
                orderdb.Insert("ульяновск", "краснодар", 100, 0, 0, 0, true, 1200, "");
                orderdb.Insert("ульяновск", "иваново", 100, 0, 0, 0, true, 1200, "");
                orderdb.Insert("ульяновск", "владивосток", 100, 0, 0, 0, true, 1200, "");
                orderdb.Insert("ульяновск", "киев", 100, 0, 0, 0, true, 1200, "");
            }
            catch { }
            int ordY = 0;
            int i1 = 0;
            Label l;
            PictureBox pb;
            p = new List<Panel>();

            foreach (var a in orderdb.Show())
            {

                p.Add(new Panel());
                p[i1].Name = "" + a.id_order;
                p[i1].BackColor = Color.Transparent;
                p[i1].Location = new Point(0, ordY);
                p[i1].Size = new Size(ordmanpan.Width - 20, ordmanpan.Height / 4 - 2);
                p[i1].BackgroundImage = Image.FromFile("whiteborder4.png");
                p[i1].BackgroundImageLayout = ImageLayout.Stretch;
                l = new Label();
                l.Name = "idlbl";
                l.Visible = false;
                l.Enabled = false;
                l.Text = "" + a.id_order;
                l.Location = new Point(5, 5);
                l.Font = new Font(l.Font.Name, 14, l.Font.Style);
                l.ForeColor = Color.White;
                l.AutoSize = true;
                p[i1].Controls.Add(l);
                l = new Label();
                l.Text = "№ " + (i1 + 1);
                l.Location = new Point(5, 5);
                l.Font = new Font(l.Font.Name, 14, l.Font.Style);
                l.ForeColor = Color.White;
                l.AutoSize = true;
                p[i1].Controls.Add(l);
                l = new Label();
                l.Location = new Point(5, 35);
                l.Font = new Font(l.Font.Name, 22, l.Font.Style);
                l.Text = orderdb.Show()[i1].express ? "Э" : "О";
                l.AutoSize = true;
                l.ForeColor = Color.White;
                p[i1].Controls.Add(l);
                l = new Label();
                l.Location = new Point(55, 5);
                l.Font = new Font(l.Font.Name, 12, l.Font.Style);
                l.Text = "Пункт А:";
                l.AutoSize = true;
                l.ForeColor = Color.White;
                p[i1].Controls.Add(l);
                l = new Label();
                l.Location = new Point(55, 30);
                l.Font = new Font(l.Font.Name, 12, l.Font.Style);
                l.Text = "Пункт B:";
                l.AutoSize = true;
                l.ForeColor = Color.White;
                p[i1].Controls.Add(l);
                l = new Label();
                l.Location = new Point(125, 5);
                l.Font = new Font(l.Font.Name, 12, l.Font.Style);
                l.Text = orderdb.Show()[i1].point_of_departure;
                l.AutoSize = true;
                l.ForeColor = Color.White;
                p[i1].Controls.Add(l);
                l = new Label();
                l.Location = new Point(125, 30);
                l.Font = new Font(l.Font.Name, 12, l.Font.Style);
                l.Text = orderdb.Show()[i1].point_of_arrival;
                l.AutoSize = true;
                l.ForeColor = Color.White;
                p[i1].Controls.Add(l);
                l = new Label();
                l.Location = new Point(55, 55);
                l.Font = new Font(l.Font.Name, 12, l.Font.Style);
                l.Text = "Расстояние:";
                l.AutoSize = true;
                l.ForeColor = Color.White;
                p[i1].Controls.Add(l);
                l = new Label();
                l.Location = new Point(155, 55);
                l.Font = new Font(l.Font.Name, 12, l.Font.Style);
                l.AutoSize = true;
                l.Text = "" + orderdb.countDistantion(orderdb.Show()[i1].point_of_arrival, orderdb.Show()[i1].point_of_departure) + " км";
                l.ForeColor = Color.FromArgb(255, 4, 193, 229);
                p[i1].Controls.Add(l);
                l = new Label();
                l.Location = new Point(360, 35);
                l.Font = new Font(l.Font.Name, 14, l.Font.Style);
                l.AutoSize = true;
                l.Text = "" + orderdb.Show()[i1].cost + " руб.";
                l.ForeColor = Color.FromArgb(0, 202, 33);
                p[i1].Controls.Add(l);
                l = new Label();
                l.Location = new Point(360, 55);
                l.Font = new Font(l.Font.Name, 12, l.Font.Style);
                l.AutoSize = true;
                l.Text = "" + orderdb.Show()[i1].paid + " руб.";
                l.ForeColor = Color.White;
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
                p[i1].Controls.Add(pb);
                ordmanpan.Controls.Add(p[i1]);
                ordY += ordmanpan.Height / 4 - 2;
                i1++;
            }



            //p1.BackColor = Color.Red;
            //  p1.Location = new Point(10, 10);
            //  p1.Size = new Size(100,100);
            // this.Controls.Add(p1);
        }
        private void setloactionorderlist()
        {
            int ordY1 = 0;
            int scrollval = ordmanpan.VerticalScroll.Value;
            ordmanpan.VerticalScroll.Value = 0;

            foreach (var a in ordmanpan.Controls)
            {
                try
                {
                    (a as Control).Location = new Point(0, ordY1);
                    ordY1 += ordmanpan.Size.Height / 4 - 2;
                }
                catch { }
                //
            }
            ordmanpan.VerticalScroll.Value = scrollval;

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
                        }
                        catch { }

                        break;
                    }

                }

            setloactionorderlist();
        }
    }
}
