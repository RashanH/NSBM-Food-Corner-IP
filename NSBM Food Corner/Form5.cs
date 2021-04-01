using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace NSBM_Food_Corner
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private static string connetionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\MainDB.mdb";
        private static OleDbConnection cnn;
        private static OleDbCommand cmd;
        

        private void Form5_Load(object sender, EventArgs e)
        {
            //cnn = new OleDbConnection(connetionString);
            //cnn.Open();
            //cmd = new OleDbCommand("SELECT [orderID] FROM tblOrders WHERE [status] = 'Open'", cnn);
            //DataSet sDs = new DataSet();
            //OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            //adapter.Fill(sDs, "tblOrders");
            //dataGridView1.DataSource = sDs.Tables["tblOrders"];
            //cnn.Close();
            //dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            radioButton1.Checked = true;
            lblOrderTime.Text = "";
            lblStudentIndex.Text = "";
            lblStudentName.Text = "";
        }

        private void datagridview1_cell_click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                {
                    try
                    {
                        dataGridView2.Columns.Clear();
                        cnn = new OleDbConnection(connetionString);
                        cnn.Open();
                        //cmd = new OleDbCommand("SELECT tblOrderDetails.foodID, tblOrderDetails.qty, tblFoods.foodname, tblFoods.foodprice, tblFoods.ID FROM (tblOrderDetails INNER JOIN tblFoods ON tblOrderDetails.foodID = tblFoods.ID) WHERE tblOrderDetails.orderID = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "", cnn);
                        cmd = new OleDbCommand("SELECT tblFoods.foodname, tblFoods.foodprice, tblOrderDetails.qty FROM (tblOrderDetails INNER JOIN tblFoods ON tblOrderDetails.foodID = tblFoods.ID) WHERE tblOrderDetails.orderID = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "", cnn);
                        //cmd = new OleDbCommand("SELECT tblFoods.foodname, tblFoods.foodprice, tblOrderDetails.qty FROM (tblOrderDetails INNER JOIN tblFoods ON tblOrderDetails.foodID = tblFoods.ID) WHERE tblOrderDetails.orderID = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "", cnn);
                        DataSet sDs = new DataSet();
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        adapter.Fill(sDs, "tblOrders");
                        dataGridView2.DataSource = sDs.Tables[0];

                        //show student details
                        cmd = new OleDbCommand("SELECT tblStudents.StudentID,tblStudents.studentPhone,tblStudents.studentEmail, tblStudents.studentFName, tblStudents.studentLName, tblOrders.ordertime FROM (tblStudents INNER JOIN tblOrders ON tblStudents.StudentID = tblOrders.studentID) WHERE tblOrders.orderID = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "", cnn);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lblStudentIndex.Text = reader["StudentID"].ToString();
                                lblStudentName.Text = reader["StudentFName"].ToString() + " " + reader["StudentLName"].ToString() + " (" + reader["studentPhone"].ToString() + ")";
                                lblOrderTime.Text = reader["ordertime"].ToString();
                            }
                            cnn.Close();

                            //total
                            dataGridView2.Columns.Add("ColumnTot", "Total (LKR)");
                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                row.Cells[3].Value = (Convert.ToInt32(row.Cells[1].Value.ToString()) * Convert.ToInt32(row.Cells[2].Value.ToString())).ToString();
                            }
                            lblTotal.Text = dataGridView2.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[3].Value)).ToString() + " LKR";
                        }

                        //datagrid adjustments
                        dataGridView2.Columns[1].Visible = false;
                        dataGridView2.Columns[3].Width = 130;
                        dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.ClearSelection();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                }

            }
        }
        private string accountSid = "";
        private string authToken = "";
        private string send_from = "";
        private void btnMarkComplete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) { MessageBox.Show("Select an order first!"); return; }

            try
            {
                cnn = new OleDbConnection(connetionString);
                cnn.Open();
                if (radioButton1.Checked)
                {
                    cmd = new OleDbCommand("UPDATE tblOrders SET [status] = 'Closed'  WHERE [orderID] = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "", cnn);
                }
                else
                {
                    cmd = new OleDbCommand("UPDATE tblOrders SET [status] = 'Open'  WHERE [orderID] = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "", cnn);
                }

                //new Thread(() =>
                //{
                    //Send SMS
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    try
                    {
                        TwilioClient.Init(accountSid, authToken);
                        MessageResource.Create(
                            from: new PhoneNumber(send_from),
                            to: new PhoneNumber(lblStudentName.Text.Split('(')[1].Replace(")", "").Replace(" ", "")),
                            body: "Your order is ready." + Environment.NewLine + Environment.NewLine + "- NSBM Food Corner");
                    }
                    catch { }
                //    Thread.CurrentThread.Abort();
                //}).Start();
              

                cmd.ExecuteNonQuery();
                cnn.Close();
                refresh_data();
                lblStudentIndex.Text = "";
                lblStudentName.Text = "";
                lblOrderTime.Text = "";

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }
        }

        private void refresh_data()
        {
            try
            {
                cnn = new OleDbConnection(connetionString);
                cnn.Open();
                if (radioButton1.Checked)
                {
                    cmd = new OleDbCommand("SELECT [orderID] FROM tblOrders WHERE [status] = 'Open'", cnn);
                    btnMarkComplete.Text = "Mark as Completed";
                }
                else
                {
                    cmd = new OleDbCommand("SELECT [orderID] FROM tblOrders WHERE [status] = 'Closed'", cnn);
                    btnMarkComplete.Text = "Mark as Incomplete";
                }
                DataSet sDs = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(sDs, "tblOrders");
                dataGridView1.DataSource = sDs.Tables["tblOrders"];
                cnn.Close();

                dataGridView1.ClearSelection();
                dataGridView2.ClearSelection();
                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }
        }

        private void radioButton1_CheckedChanged(object sender)
        {
            refresh_data();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void chromeButton2_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.ShowDialog();
        }
    }
}
