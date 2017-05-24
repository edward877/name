using Controller;
using Report;
using System;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace View
{
    public partial class Graph : Form
    {
        string path;
        public Graph(OrderDB db)
        {
            orderdb = db;
            InitializeComponent();
        }
        OrderDB orderdb;
        public void ShowGr(List<decimal> listMoney)
        {
           
            System.Windows.Forms.DataVisualization.Charting.Chart myChart = chart;
            myChart.Dock = DockStyle.Fill;
            ChartArea area = new ChartArea("Report");
            myChart.ChartAreas.Add(area);
            Series mySeriesOfPoint = new Series("выручка");
            mySeriesOfPoint.ChartType = SeriesChartType.Column;
            mySeriesOfPoint.ChartArea = "Report";
            int n = listMoney.Count;
            DateTime date;

            if (n == 7)
            {
                date = DateTime.Now.AddDays(-7);
                for (int i = 1; i <= 7; i++)
                {
                        mySeriesOfPoint.Points.AddXY(date.AddDays(i).DayOfWeek.ToString(), listMoney[i - 1]);                 
                }
            }else if (n == 30)
            {
                date = DateTime.Now.AddDays(-30);
                for (int i = 1; i <= 30; i++)
                {
                    mySeriesOfPoint.Points.AddXY(date.AddDays(i).Day.ToString(), listMoney[i - 1]);
                }
            }else if (n==12)
            {
                date = DateTime.Now.AddMonths(-12);
                for (int i = 1; i <= 12; i++)
                {
                    mySeriesOfPoint.Points.AddXY(date.AddMonths(i).ToString("MMM"), listMoney[i - 1]);
                }
            }
           
            path = @"..\..\..\Report\chart";
            myChart.Series.Add(mySeriesOfPoint);
            myChart.SaveImage(path + ".png", ChartImageFormat.Png);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tr = new Thread(DoWork) { IsBackground = true };
            try
            {
                tr.Start();
            }
            catch { }
        }
        Thread tr;
        FileDialog fd1;
        bool res;
        private void dialogres() {
            res= (fd1.ShowDialog() == DialogResult.OK);
        }
        private void setenablebtn() {
            button1.Enabled = !button1.Enabled;
        }
        private delegate void del();
        private void DoWork()
        {
            del d = setenablebtn;
            Invoke(d);
            d = dialogres;
            fd1 = new SaveFileDialog();
            fd1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

            Invoke(d);
            if (!res)
            {
                d = setenablebtn;

                Invoke(d);
                return;
            }
            ExcelReport excel = new ExcelReport();
            excel.NewReport(path);
           
                excel.Save(fd1.FileName);
            MessageBox.Show("Файл успешно сохранен.");
            d = setenablebtn;
            Invoke(d);

        }

        private void chart_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int day = 0;
           
            switch (comboBox1.SelectedIndex)
            {
                case 0: day = 7; break;
                case 1: day = 30; break;
                case 2: day = 12; break;
            }
            comboBox1.Enabled = false;
            ShowGr(orderdb.getMoney(day));
        }
    }
}
