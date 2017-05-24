using Controller;
using Model;
using System;
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
    public partial class FrameOrderF : Form
    { Delegate sd;
        OrderDB orderdb;
        
        public FrameOrderF(OrderDB db)
        {
            InitializeComponent();
            orderdb = db;
        }

        private void FrameOrderF_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Add("Заказ");
            treeView1.Nodes[0].Nodes.Add("Выполненные заказы");
            treeView1.Nodes[0].Nodes.Add("Невыполненные заказы");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("Оплаченные заказы");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("Неоплаченные заказы");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("Оплаченные заказы");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("Неоплаченные заказы");
        }
        private void setCb()
        {
            foreach (Order a in orderdb.Show())
            {
               
                    comboBox1.Items.Add(a.id_order);
            }
        }
        private void setCbPaid() {
            foreach (Order a in orderdb.Show()) {
                if (a.cost <= a.paid)
                    comboBox1.Items.Add(a.id_order);
            }
        }
        private void setCbReady()
        {
            foreach (Order a in orderdb.Show())
            {
                if (a.status != "заказ обрабатывается")
                    comboBox1.Items.Add(a.id_order);
            }
        }
        private void setCbReadyAndNotPaid()
        {
            foreach (Order a in orderdb.Show())
            {
                if (a.status != "заказ обрабатывается" && a.cost > a.paid)
                    comboBox1.Items.Add(a.id_order);
            }
        }
        private void setCbReadyAndPaid()
        {
            foreach (Order a in orderdb.Show())
            {
                if (a.status != "заказ обрабатывается" && a.cost <= a.paid)
                    comboBox1.Items.Add(a.id_order);
            }
        }
        private void setCbNotReady()
        {
            foreach (Order a in orderdb.Show())
            {
                if (a.status == "заказ обрабатывается")
                    comboBox1.Items.Add(a.id_order);
            }
        }
        private void setCbPaidAndNotReady()
        {
            foreach (Order a in orderdb.Show())
            {
                if (a.status == "заказ обрабатывается"&& a.cost <= a.paid)
                    comboBox1.Items.Add(a.id_order);
            }
        }
        private void setCbNotPaidAndReady()
        {
            foreach (Order a in orderdb.Show())
            {
                if (a.status == "заказ обрабатывается" && a.cost > a.paid)
                    comboBox1.Items.Add(a.id_order);
            }
        }
        TreeNode tn;
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tn = treeView1.SelectedNode;
            lblPaid.Text = "";
            lblReady.Text = "";
            lblDist.Text = "";
            lblFio.Text = "";
            lblPA.Text = "";
            lblPB.Text = "";
            comboBox1.Enabled = false;
            comboBox1.Items.Clear();
            if (treeView1.SelectedNode == treeView1.Nodes[0])
                setCb();
            else
            if (treeView1.SelectedNode == treeView1.Nodes[0].Nodes[0])
            {
                lblReady.Text = "Выполнен";
                lblReady.ForeColor = Color.Green;
                setCbReady();

            }
            else
            if (treeView1.SelectedNode == treeView1.Nodes[0].Nodes[0].Nodes[0])
            {
                lblReady.Text = "Выполнен";
                lblReady.ForeColor = Color.Green;
                lblPaid.Text = "Да";
                lblPaid.ForeColor = Color.Green;
                setCbReadyAndPaid();
                comboBox1.Enabled = true;

            }
            else
             if (treeView1.SelectedNode == treeView1.Nodes[0].Nodes[0].Nodes[1])
            {
                lblReady.Text = "Выполнен";
                lblReady.ForeColor = Color.Green;
                lblPaid.Text = "Нет";
                lblPaid.ForeColor = Color.Red;
                setCbReadyAndNotPaid();
                comboBox1.Enabled = true;

            }
            else
            if (treeView1.SelectedNode == treeView1.Nodes[0].Nodes[1])
            {
                lblReady.Text = "Не выполнен";
                lblReady.ForeColor = Color.Red;
                setCbNotReady();
            }
            else
            if (treeView1.SelectedNode == treeView1.Nodes[0].Nodes[1].Nodes[0])
            {
                lblPaid.Text = "Да";
                lblPaid.ForeColor = Color.Green;
                lblReady.Text = "Не выполнен";
                lblReady.ForeColor = Color.Red;
                setCbPaidAndNotReady();
                comboBox1.Enabled = true;

            }
            else
            if (treeView1.SelectedNode == treeView1.Nodes[0].Nodes[1].Nodes[1])
            {
                lblPaid.Text = "Нет";
                lblPaid.ForeColor = Color.Red;
                lblReady.Text = "Не выполнен";
                lblReady.ForeColor = Color.Red;
                setCbNotPaidAndReady();
                comboBox1.Enabled = true;

            }
            else
            {
                try
                {      
                    lblDist.Text = "" + orderdb.Show(Convert.ToInt32(tn.Text.Split(' ')[1]), "")[0].distance;
                    lblFio.Text = "" + orderdb.Show(Convert.ToInt32(tn.Text.Split(' ')[1]), "")[0].Client.full_name;
                    lblPA.Text = "" + orderdb.Show(Convert.ToInt32(tn.Text.Split(' ')[1]), "")[0].point_of_arrival;
                    lblPB.Text = "" + orderdb.Show(Convert.ToInt32(tn.Text.Split(' ')[1]), "")[0].point_of_departure;
                    if ( orderdb.Show(Convert.ToInt32(tn.Text.Split(' ')[1]), "")[0].cost <= orderdb.Show(Convert.ToInt32(tn.Text.Split(' ')[1]), "")[0].paid)
                    {
                        lblPaid.Text = "Да";
                        lblPaid.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblPaid.Text = "Нет";
                        lblPaid.ForeColor = Color.Red;
                    }
                    if (orderdb.Show(Convert.ToInt32(tn.Text.Split(' ')[1]), "")[0].status == "заказ обрабатывается")
                    {
                        lblReady.Text = "Не выполнен";
                        lblReady.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblReady.Text = "Выполнен";
                        lblReady.ForeColor = Color.Green;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool exist = false;
            foreach (TreeNode a in tn.Nodes)
                if (a.Text.Equals("Заказ_№ " + orderdb.Show(Convert.ToInt32(comboBox1.SelectedItem),"")[0].id_order))
                {
                    exist = true;
                    break;
                }
            if (!exist)
            {
                tn.Nodes.Add("Заказ_№ " + orderdb.Show(Convert.ToInt32(comboBox1.SelectedItem), "")[0].id_order);
            }
            lblDist.Text = "" + orderdb.Show(Convert.ToInt32(comboBox1.SelectedItem), "")[0].distance;
            lblFio.Text = "" + orderdb.Show(Convert.ToInt32(comboBox1.SelectedItem), "")[0].Client.full_name;
            lblPA.Text = "" + orderdb.Show(Convert.ToInt32(comboBox1.SelectedItem), "")[0].point_of_arrival;
            lblPB.Text = "" + orderdb.Show(Convert.ToInt32(comboBox1.SelectedItem), "")[0].point_of_departure;
            if (orderdb.Show(Convert.ToInt32(comboBox1.SelectedItem), "")[0].cost <= orderdb.Show(Convert.ToInt32(comboBox1.SelectedItem), "")[0].paid)
            {
                lblPaid.Text = "Да";
                lblPaid.ForeColor = Color.Green;
            }
            else {
                lblPaid.Text = "Нет";
                lblPaid.ForeColor = Color.Red;
            }
            if (orderdb.Show(Convert.ToInt32(comboBox1.SelectedItem), "")[0].status == "заказ обрабатывается")
            {
                lblReady.Text = "Не выполнен";
                lblReady.ForeColor = Color.Red;
            }
            else
            {
                lblReady.Text = "Выполнен";
                lblReady.ForeColor = Color.Green;
            }
        }
    }
}
