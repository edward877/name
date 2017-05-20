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
            area.AxisX.Minimum = 1;
            Series mySeriesOfPoint = new Series("выручка");
            mySeriesOfPoint.ChartType = SeriesChartType.Column;
            mySeriesOfPoint.ChartArea = "Report";
            List<string> day = new List<string>();
            for (int i = 1; i <= listMoney.Count; i++)
            {
                mySeriesOfPoint.Points.AddXY(i, listMoney[i - 1]);
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
