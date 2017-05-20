using Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace View
{
    public partial class Graph : Form
    {
        string path;
        public Graph()
        {
            InitializeComponent();
        }

        public void ShowGr(List<decimal> listMoney)
        {
            System.Windows.Forms.DataVisualization.Charting.Chart myChart = chart;
            myChart.Dock = DockStyle.Fill;
            ChartArea area = new ChartArea("Report");
            myChart.ChartAreas.Add(area);
           // area.AxisX.Minimum = 0;
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
            FileDialog fd = new SaveFileDialog();
            fd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (fd.ShowDialog() != DialogResult.OK) return;
            ExcelReport excel = new ExcelReport();
            excel.NewReport(path);
            excel.Save(fd.FileName);
        }
    }
}
