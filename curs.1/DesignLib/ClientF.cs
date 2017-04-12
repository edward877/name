using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace DesignLib
{
    public partial class ClientF : Form
    {
        public ClientF()
        {
            InitializeComponent();

            //   clr = button3.BackColor;
          //  this.Select();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        List<PictureBox> pblist;
        List<Button> btnlist;
        private void ClientF_Load(object sender, EventArgs e)
        {
   
pblist = new List<PictureBox>();
            btnlist = new List<Button>();
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(0, 40, 860, 40);
            gp.AddLine(860, 40, 900, 0);
            gp.AddLine(900, 0, 1000, 0);
            gp.AddLine(1000, 0, 1000, 690);
            gp.AddLine(1000, 690, 0, 690);
            gp.AddLine(0, 690, 0, 0);
            

          
            this.Region = new Region(gp);
         //   panel5.Size = new Size(panel5.Width, 5);

           // foreach (Control a in this.Controls)
           // {
          //      if (a is PictureBox)
          //          pblist.Add(a as PictureBox);
          //      if (a is Button)
          //          btnlist.Add(a as Button);
        //    }
            f = textBox1.Text;
            i = textBox2.Text;
            o = textBox3.Text;
          //  ava = pictureBox9.BackgroundImage;
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
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            hidepb();
            pictureBox6.Visible = true;
            pictureBox2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hidepb();
            pictureBox7.Visible = true;
            pictureBox3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hidepb();
            pictureBox8.Visible = true;
            pictureBox4.Visible = false;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {

            pictureBox2.Visible = true;

        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {

            pictureBox3.Visible = true;

        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {

            pictureBox4.Visible = true;

        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Visible = false;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }
        void hidepb()
        {
            pictureBox1.Visible = pictureBox2.Visible = pictureBox3.Visible = pictureBox4.Visible = pictureBox5.Visible = pictureBox6.Visible = pictureBox7.Visible = pictureBox8.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            hidepb();

            pictureBox5.Visible = true;
            pictureBox1.Visible = false;
            panel5.Visible = true;
            timer2.Start();
            button6.Visible = button7.Visible = button8.Visible = true;

        }

        private void button1_Leave(object sender, EventArgs e)
        {

        }
        int pan5h = 5;
        int standarth = 5;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (pan5h >= 460)
            {
                timer2.Stop();
                pan5h = standarth;
            }
            else
            {
                panel5.Size = new Size(panel5.Width, pan5h);
                pan5h += 20;
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                pictureBox9.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
            }
            catch (Exception ex) { MessageBox.Show("Неподходящий файл!"); }
            button12.Visible = button13.Visible = true;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            (sender as Control).Size = new Size((sender as Control).Width + 4, (sender as Control).Height + 4);
            (sender as Control).Location = new Point((sender as Control).Location.X - 2, (sender as Control).Location.Y - 2);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            (sender as Control).Size = new Size((sender as Control).Width - 4, (sender as Control).Height - 4);
            (sender as Control).Location = new Point((sender as Control).Location.X + 2, (sender as Control).Location.Y + 2);
        }
        void deselectbotpan()
        {
            button6.FlatAppearance.BorderSize = button7.FlatAppearance.BorderSize = button8.FlatAppearance.BorderSize = 0;
        }
        void changepan()
        {
        }
        private void button6_Click(object sender, EventArgs e)
        {
            deselectbotpan();
            (sender as Button).FlatAppearance.BorderSize = 1;
            button17.Visible = button14.Visible = button15.Visible = button16.Visible = true;
            pictureBox10.Visible = pictureBox11.Visible = true;
            hidepan();
            if((sender as Button)==button7)
            panel11.Visible = true;
            if ((sender as Button) == button6)
                panel5.Visible = true;
            if ((sender as Button) == button8) { }
              //  panel11.Visible = true;


        }
        void hidepan()
        {
            panel11.Visible = false;
            panel5.Visible = false;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            button12.Visible = button13.Visible = true;
        }
        string f;
        string i;
        string o;
        Image ava;
        private void button12_Click(object sender, EventArgs e)
        {
         
            f = textBox1.Text;
            i = textBox2.Text;
            o = textBox3.Text;
            ava = pictureBox9.BackgroundImage;
            button12.Visible = button13.Visible = false;

        }

        private void button13_Click(object sender, EventArgs e)
        {
            
            textBox1.Text = f;
            textBox2.Text = i;
            textBox3.Text = o;
            pictureBox9.BackgroundImage = ava;
            button12.Visible = button13.Visible = false;

        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
           
            if ((sender as TextBox) == textBox4)
                resizeanim(panel13, pictureBox11, sender as TextBox, false);
            if ((sender as TextBox) == textBox5)
                resizeanim(panel12, pictureBox10, sender as TextBox, false);
            if ((sender as TextBox) == textBox1)
                resizeanim(panel6, label1, sender as TextBox, false);
            if ((sender as TextBox) == textBox2)
                resizeanim(panel7, label2, sender as TextBox, false);
            if ((sender as TextBox) == textBox3)
                resizeanim(panel8, label3, sender as TextBox, false);

        }
        void resizeanim(Panel p, Control pb, TextBox t, bool b)
        {
            int a;
            if (b)
                a = 1;
            else
                a = -1;
            t.Font = new Font("Microsoft Sans Serif", t.Font.Size - 2 * a);
            p.Location = new Point(p.Location.X, p.Location.Y - 3 * a);
            pb.Location = new Point(pb.Location.X + 3 * a, pb.Location.Y);
            pb.Size = new Size(pb.Size.Width - 3 * a, pb.Size.Height - 3 * a);

        }
        private void textBox4_Leave(object sender, EventArgs e)
        {
   
            if ((sender as TextBox) == textBox4)
                resizeanim(panel13, pictureBox11, sender as TextBox, true);
            if ((sender as TextBox) == textBox5)
                resizeanim(panel12, pictureBox10, sender as TextBox, true);
            if ((sender as TextBox) == textBox1)
                resizeanim(panel6, label1, sender as TextBox, true);
            if ((sender as TextBox) == textBox2)
                resizeanim(panel7, label2, sender as TextBox, true);
            if ((sender as TextBox) == textBox3)
                resizeanim(panel8, label3, sender as TextBox, true);
        }
    }
}
