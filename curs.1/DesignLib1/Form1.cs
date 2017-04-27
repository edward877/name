using Controller;
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
        int ves=0;
        int height=0;
        int width=0;
        int length=0;
        int waylength=0;
        public Form1()
        {
            InitializeComponent();
            tblistprof = new List<TextBox>();
            lbllistprof = new List<Label>();
            proflist = new List<Control>();
            pblistmenu = new List<PictureBox>();
            ordlist = new List<Control>();
        }
        string[] s;
        List<Control> proflist;
        List<Control> ordlist;
        List<Control> ordmanlist;
        List<Control> paylist;
        void fillproflist() {

            proflist.Add(profpanel);
            proflist.Add(label1);
            proflist.Add(app);
            proflist.Add(dec);
        }
        void fillordlist() {
            ordlist.Add(orderpan);
            ordlist.Add(papb);
            ordlist.Add(pbpb);
            ordlist.Add(waypb);
            ordlist.Add(wlengthlbl);
            ordlist.Add(wlengthpb);
            ordlist.Add(app1);
        }
        void fillproftblist() {
            
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
        
        void fillproflbllist() {  
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
        private void Form1_Load(object sender, EventArgs e)
        {
            DBDataContext db;
            
            fillproflbllist();
            fillproftblist();
            fillproflist();
            fillpblistmenu();
            fillordlist();
            this.Hide();

            LoginF lf = new LoginF();
            lf.ShowDialog();
            try
            {
                this.Show();
            }
            catch { }
            db = lf.db;
            client = Visitor.client;
            user = Visitor.user;
            clientdb = lf.clientdb;
            filluserinfo();
            filltextproftblbl();
            for (int i = 0; i < tblistprof.Count; i++)
                lbllistprof[i].Text = tblistprof[i].Text= userinfo[i];
            hidepans();
            showprofpan();
        }
        void hidepans()
        {foreach (Control a in proflist)
                a.Visible = false;
            foreach (Control a in ordlist)
                a.Visible = false;
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
        void showproflbl() {
            foreach (Label a in lbllistprof)
                a.Visible = true;
        }
        void showordpan() {
            foreach (Control a in ordlist)
                a.Visible = true;
        }
        void hideproftb()
        {foreach (TextBox a in tblistprof)
                a.Visible = false;
        }
        string[] userinfo;
        void filluserinfo() {
            string[] fio;
            fio = client.full_name.Split(' ');
            userinfo = new string[10];
            loglbl.Text=userinfo[6] = user.login;
            userinfo[0] =fio[0];
            if(fio.Length>=2)
            userinfo[1] =fio[1];
            if (fio.Length>=3)
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
                lbllistprof[i].Text = tblistprof[i].Text=s[i];
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
            (sender as Control).Size = new Size((sender as Control).Size.Width+5, (sender as Control).Size.Height+5);
            
        }

        private void label3_MouseLeave(object sender, EventArgs e)
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
        void showprofpan() {
            foreach (Control a in proflist)
                if (!(a is TextBox))
                a.Visible = true;
        }
        void hidemenupb() {
            foreach (PictureBox a in pblistmenu)
                a.Visible = false;
        }

        private void ordlbl_Click(object sender, EventArgs e)
        {
            hidemenupb();
            hidepans();
            showordpan();
            ordpb.Visible = true;
            
        }

        private void ordmanlbl_Click(object sender, EventArgs e)
        {
            hidemenupb();
            ordmanpb.Visible = true;
        }

        private void paylbl_Click(object sender, EventArgs e)
        {
            hidemenupb();
            paypb.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            menupan.Visible = !menupan.Visible;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
        }

        private void minbtn_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Control).Size = new Size((sender as Control).Size.Width + 5, (sender as Control).Size.Height + 5);
        }

        private void maxbtn_MouseUp(object sender, MouseEventArgs e)
        {
            (sender as Control).Size = new Size((sender as Control).Size.Width - 5, (sender as Control).Size.Height - 5);
        }
        void printves() {
            veslbl.Text = ""+ves+" кг";
        }
        private void minbtn_Click(object sender, EventArgs e)
        {
            if (ves >= 10)
                ves-=10;
            printves();
        }

        private void maxbtn_Click(object sender, EventArgs e)
        {
            ves += 10;
            printves();
        }
    }
}
