﻿using System;
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
    public partial class OfferMailF : Form
    {
        List<Image> theme;
        public OfferMailF()
        {
            InitializeComponent();
            send = false;
            theme = new List<Image>();
             theme.Add(Image.FromFile("theme1.png"));
            theme.Add(Image.FromFile("theme2.png"));
            theme.Add(Image.FromFile("theme3.png"));
            theme.Add(Image.FromFile("theme4.png"));
            theme.Add(Image.FromFile("theme5.png"));
            theme.Add(Image.FromFile("theme6.png"));
        }
        System.Drawing.Graphics formGraphics;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            formGraphics =Graphics.FromImage(pictureBox1.BackgroundImage);
            string drawString = rtbText.Text;
            System.Drawing.Font drawFont = new System.Drawing.Font(
                "Times New Roman", (int)nupdScaleText.Value);
            System.Drawing.SolidBrush drawBrush = new
                System.Drawing.SolidBrush(System.Drawing.Color.Black);
            Point p = this.PointToClient(Cursor.Position);
            formGraphics.DrawString(drawString, rtbText.Font, drawBrush,p);
            pictureBox1.Refresh();

            drawFont.Dispose();
            drawBrush.Dispose();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            rtbText.Visible = !rtbText.Visible;
            nupdScaleText.Visible = !nupdScaleText.Visible;
      
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
        int t = 1;
        private void button2_Click(object sender, EventArgs e)
        {if (t < theme.Count-1)
                t++;
            else t = 0;
            pictureBox1.BackgroundImage = theme[t];
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
        }
       public bool send = false;
        private void button3_Click_1(object sender, EventArgs e)
        {try
            {
                send = true;
                pictureBox1.BackgroundImage.Save("1.bmp");
            }
            catch { }
            this.Close();
         //   formGraphics.Save();
        }
        bool bold = false;
        bool italic = false;
        private void button1_Click_1(object sender, EventArgs e)
        {
           
         
        }

        private void nupdScaleText_ValueChanged(object sender, EventArgs e)
        {
          rtbText.Font= new Font(rtbText.Font.FontFamily, (int)nupdScaleText.Value);
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
       
        }
    }
}
