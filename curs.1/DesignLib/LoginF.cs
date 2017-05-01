using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignLib
{
    public partial class LoginF : Form
    {
        

        public Controller.ClientDB clientdb;
        public Controller.Visitor visitordb;
        public Controller.OrderDB orderdb;
        Thread tr1;
        public LoginF()
        {
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form1.iflog = false;
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        bool reg = false;
        List<TextBox> ltb;
        bool canreg = false;
        private void button2_Click(object sender, EventArgs e)
        {
          
            int x1 = button1.Location.X;
            int y1 = button1.Location.Y;
            int x2 = button2.Location.X;
            int y2 = button2.Location.Y;
            if (!reg)
            {
                this.Size = new Size(this.Width, this.Height + 230);
                button2.Location = new Point(x2, y1 + 230);
                button1.Location = new Point(x1, y1 + 230);
                rmailtb.Visible=rlogtb.Visible = rpasstb.Visible = rphonetb.Visible = rfnametb.Visible = rcomptb.Visible = true;
                reg = !reg;
            }
            else
            {
                decolortb();
                canreg = true;
                foreach (TextBox a in ltb)
                {
                    if (a != rcomptb&& a !=logtb&& a !=passtb)
                        if (a.ForeColor == frtb || a.Text == "")
                        {
                            a.BackColor = Color.Pink;
                            label1.Text = "Некорректные данные!";
                            canreg = false;
                        }

                    if (a == rphonetb)
                        try
                        {
                            Convert.ToUInt64(a.Text);
                        }
                        catch {
                            
                            a.BackColor = Color.Pink;
                            label1.Text = "Некорректные данные!";
                            canreg = false;
                        }
                }
                foreach (var a in clientdb.Show())
                    if (a.User.login.Equals(rlogtb.Text)) {
                        canreg = false;
                        s = "Логин занят!"; c = Color.Pink;
                        setmsglbl();
                        break; }
                    if (canreg)
                {
                    tr1 = new Thread(registrationpress) { IsBackground = true };
                    timer3.Start();
                    tr1.Start();
                  
                        this.Size = new Size(this.Width, this.Height - 230);
                        button2.Location = new Point(x2, y2 - 230);
                        button1.Location = new Point(x1, y1 - 230);
                         rmailtb.Visible=rlogtb.Visible = rpasstb.Visible = rphonetb.Visible = rfnametb.Visible = rcomptb.Visible = false;
                        s = "Регистрация прошла успешно"; c = Color.YellowGreen;
                        setmsglbl();
                        canreg = false;
                   
                       
                            setmsglbl();
                    reg = !reg;
                   

                }
            }
        }
        void registration() {
            button2.Text = "";
            clientdb.Insert(rlogtb.Text, rpasstb.Text, rfnametb.Text, rphonetb.Text, rcomptb.Text,rmailtb.Text);
            button2.Text = "Регистрация";
            timer3.Stop();
        }
        void registrationpress() {
            del d = registration;
            Invoke(d);
           
        }
        string s; Color c;
        private void setmsglbl()
        {
            t = t1;
            panel1.Size = new Size(t1, panel1.Height);
            timer1.Start();
            label2.Text = s;
            label2.ForeColor = c;
            timer1.Start();
            button1.Enabled = true;
        }
        private void decolortb() {
            foreach (TextBox a in ltb)
                a.BackColor = Color.White;
        }
        private void rlogtb_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).Text = "";
            (sender as TextBox).ForeColor = Color.Black;
            if ((sender as TextBox) == rpasstb || (sender as TextBox) == passtb)
                (sender as TextBox).PasswordChar = '*';
        }
        Color frtb;
        public Model.DBDataContext db;
        private void LoginF_Load(object sender, EventArgs e)
        {
           
           t1= t = panel1.Width;
            ltb = new List<TextBox>();
            foreach (var a in this.Controls)
                if (a is TextBox)
                ltb.Add(a as TextBox);
            frtb = rlogtb.ForeColor;
            
            Controller.ConnectDB cdb = new Controller.ConnectDB();
            this.db = cdb.DB;
            visitordb = new Controller.Visitor(db);
            orderdb = new Controller.OrderDB(db);
            clientdb = new Controller.ClientDB(db);
          //  GraphicsPath gp = new GraphicsPath();
          //  gp.AddEllipse(0,0, 61,61);
        //    button1.Region = new Region(gp);
        }

        bool b;
         delegate void del();
        
        void logcheck()
        {
            del d1= this.Close;
           del d2 = setmsglbl;
            timer4.Start();
            if (visitordb.Log_in(logtb.Text, passtb.Text))
                Invoke(d1);
            else
            {
                s = "Неверный логин или пароль!";
                c = Color.Pink;
                Invoke(d2);
               
            }
            timer4.Stop();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int x1 = button1.Location.X;
            int y1 = button1.Location.Y;
            int x2 = button2.Location.X;
            int y2 = button2.Location.Y;
            if (reg)
            {
                this.Size = new Size(this.Width, this.Height - 230);
                button2.Location = new Point(x2, y2 - 230);
                button1.Location = new Point(x1, y1 - 230);
                rmailtb.Visible=rlogtb.Visible = rpasstb.Visible = rphonetb.Visible = rfnametb.Visible = rcomptb.Visible = false;
                reg = !reg;
            }
            else
            {
                button1.Enabled = false;
                tr1 = new Thread(logcheck) { IsBackground = true };
                tr1.Start();
                tr1.Priority = ThreadPriority.Lowest;
                //  tr1.Join();


                if (b)
                {
                    tr1.Abort();
                    this.Close();
                }
                else
                {
                }
            }
            //tr1.Abort();
        }
        int t;
        int t1;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (panel1.Width <= 0)
                timer2.Stop();
            panel1.Size = new Size(t,panel1.Size.Height);
          
          
            t -= 15;
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            timer2.Start();
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
            panel1.Capture = false;
            var m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            MV = false;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            (sender as Button).ForeColor = SystemColors.GradientInactiveCaption;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
           (sender as Button).ForeColor = Color.White;
        }

        private void LoginF_MouseEnter(object sender, EventArgs e)
        {

        }

        private void LoginF_MouseLeave(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            (sender as Button).ForeColor= SystemColors.GradientInactiveCaption;
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).ForeColor = SystemColors.ScrollBar;
        }

        private void button10_Click_2(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button9_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int k = 0;
        private void timer3_Tick(object sender, EventArgs e)
           {
            k++;
            if (k > 3)
            {
                k = 0;
                button2.Text = "";
            }
            button2.Text += ".";
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            k++;
            if (k > 3)
            {
                k = 0;
                button1.Text = "";
            }
            button1.Text += ".";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
