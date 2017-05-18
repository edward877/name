using Model;
using Controller;
using System;
using System.Windows.Forms;
using Email;

namespace View
{
    public partial class FMain : Form
    {
       

        DBDataContext db;
        CarDB cardb;
        public FMain()
        {
            
            ConnectDB cdb = new ConnectDB();
            this.db = cdb.DB;

            FEntry fe = new FEntry(db);
            fe.ShowDialog();
            InitializeComponent();
            cardb = new CarDB(db);

        }
        void showbd()
        {
            try
            {
                lbValues.Items.Clear();
                foreach (var v in cardb.Show())
                {
                    lbValues.Items.Add(v);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //FCar fc = new FCar(db);
            //   fc.ShowDialog();
            showbd();
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
            FDriver fd = new FDriver(db);
            fd.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SendEmail send = new SendEmail();
            //  send.SendMessage("eduard.arkhipov2017@yandex.ru", "test", "hehe", "D:\\1.ods");
            send.SendMessage("eduard.arkhipov2017@yandex.ru", "test", "hehe");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FClient fc = new FClient(db);
            fc.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FOrder fd = new FOrder(db);
            fd.ShowDialog();
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
    }
}
