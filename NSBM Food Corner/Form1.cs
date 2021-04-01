using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace NSBM_Food_Corner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void chromeButton1_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private static string connetionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\MainDB.mdb";
        private static OleDbConnection cnn;
        private static OleDbCommand cmd;
        public void switch_to_default_data()
        {
            lblFoodID.Text = "-1";
            lblFoodname.Text = "";
            lblFoodIng.Text = "";
            lblFoodCal.Text = "";
            lblFoodPrice.Text = "";
            numFoodqty.Value = 1;
            dataGridView1.ClearSelection();

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            numFoodqty.Visible = false;
            chromeButton2.Visible = false;

            lblFoodPrice.Text = "";
        }

        private void datagrid_resize()
        {
            dataGridView1.Columns[0].Width = 340;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        public void clear_all_rows()
        {
            dataGridView2.Rows.Clear();

        }
        private void refresh_bill()
        {
            lblTotal.Text = "Total: " + dataGridView2.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[4].Value)).ToString() + " LKR";
        }
      

        private void datagridview1_cell_click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                {
                    try
                    {
                        cnn = new OleDbConnection(connetionString);
                        cnn.Open();
                        cmd = new OleDbCommand("SELECT [id], [foodname], [foodingredients], [foodcalories], [foodprice] FROM tblFoods WHERE [foodname] = '" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'", cnn);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lblFoodID.Text = reader["id"].ToString();
                                lblFoodname.Text = reader["foodname"].ToString();
                                lblFoodIng.Text = reader["foodingredients"].ToString();
                                lblFoodCal.Text = reader["foodcalories"].ToString();
                                lblFoodPriceInv.Text = reader["foodprice"].ToString();
                                lblFoodPrice.Text = reader["foodprice"].ToString() + " LKR";
                                //Console.WriteLine("{0} {1}", reader["Name"].ToString(), reader["Address"].ToString());
                            }
                        }
                        cnn.Close();
                        label1.Visible = true;
                        label2.Visible = true;
                        label3.Visible = true;
                        numFoodqty.Visible = true;
                        chromeButton2.Visible = true;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                }
            }
            else
            {
                switch_to_default_data();
            }
        }

        private void chromeButton2_Click(object sender, EventArgs e)
        {
            if (lblFoodID.Text == "-1") { MessageBox.Show("Select a food category first!"); return; }

            dataGridView2.Rows.Add(lblFoodID.Text, lblFoodname.Text, lblFoodPriceInv.Text, numFoodqty.Value.ToString(), (Convert.ToInt32(lblFoodPriceInv.Text) * Convert.ToDouble(numFoodqty.Value)).ToString(), "Remove");
            refresh_bill();
        }

        private void datagridview2_cell_click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null && e.ColumnIndex == 5)
                {
                    dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                    refresh_bill();
                }
            }
        }

        private void chromeButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0) { MessageBox.Show("No food item(s) selected"); return; }

            Form2 frm2 = new Form2(this);
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                frm2.dataGridView1.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value);
            }
            frm2.refresh_bill();
            frm2.dataGridView1.ClearSelection();
            frm2.ShowDialog();
        }

        private void chromeButton4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0) { MessageBox.Show("No food item(s) selected"); return; }
            DialogResult dialogResult = MessageBox.Show("Are you sure want to clear everything?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                switch_to_default_data();
                dataGridView2.Rows.Clear();
                refresh_bill();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            switch_to_default_data();
            button1.PerformClick();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void numFoodqty_ValueChanged(object sender, EventArgs e)
        {
            lblFoodPrice.Text = (Convert.ToInt32(lblFoodPriceInv.Text) * Convert.ToInt32(numFoodqty.Value)).ToString() + " LKR";
        }

        private void chromeButton1_Click_1(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cnn = new OleDbConnection(connetionString);
                cnn.Open();
                cmd = new OleDbCommand("SELECT [foodname], [foodprice] FROM tblFoods WHERE [foodcat] = 'Rice'", cnn);
                DataSet sDs = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(sDs, "tblFoods");
                dataGridView1.DataSource = sDs.Tables["tblFoods"];
                cnn.Close();
                switch_to_default_data();
                datagrid_resize();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cnn = new OleDbConnection(connetionString);
                cnn.Open();
                cmd = new OleDbCommand("SELECT [foodname], [foodprice] FROM tblFoods WHERE [foodcat] = 'Kottu'", cnn);
                DataSet sDs = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(sDs, "tblFoods");
                dataGridView1.DataSource = sDs.Tables["tblFoods"];
                cnn.Close();
                switch_to_default_data();
                datagrid_resize();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cnn = new OleDbConnection(connetionString);
                cnn.Open();
                cmd = new OleDbCommand("SELECT [foodname], [foodprice] FROM tblFoods WHERE [foodcat] = 'Pizza'", cnn);
                DataSet sDs = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(sDs, "tblFoods");
                dataGridView1.DataSource = sDs.Tables["tblFoods"];
                cnn.Close();
                switch_to_default_data();
                datagrid_resize();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                cnn = new OleDbConnection(connetionString);
                cnn.Open();
                cmd = new OleDbCommand("SELECT [foodname], [foodprice] FROM tblFoods WHERE [foodcat] = 'Pastries'", cnn);
                DataSet sDs = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(sDs, "tblFoods");
                dataGridView1.DataSource = sDs.Tables["tblFoods"];
                cnn.Close();
                switch_to_default_data();
                datagrid_resize();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                cnn = new OleDbConnection(connetionString);
                cnn.Open();
                cmd = new OleDbCommand("SELECT [foodname], [foodprice] FROM tblFoods WHERE [foodcat] = 'Hot Drinks'", cnn);
                DataSet sDs = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(sDs, "tblFoods");
                dataGridView1.DataSource = sDs.Tables["tblFoods"];
                cnn.Close();
                switch_to_default_data();
                datagrid_resize();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cnn = new OleDbConnection(connetionString);
                cnn.Open();
                cmd = new OleDbCommand("SELECT [foodname], [foodprice] FROM tblFoods WHERE [foodcat] = 'Cool Drinks'", cnn);
                DataSet sDs = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(sDs, "tblFoods");
                dataGridView1.DataSource = sDs.Tables["tblFoods"];
                cnn.Close();
                switch_to_default_data();
                datagrid_resize();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }
        }

        private void chromeButton5_Click(object sender, EventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.ShowDialog();
        }

        private void chromeButton6_Click(object sender, EventArgs e)
        {
            Form8 frm8 = new Form8();
            frm8.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
          
        }
    }
}
