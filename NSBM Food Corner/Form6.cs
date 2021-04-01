using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NSBM_Food_Corner
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        private static string connetionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\MainDB.mdb";
        private static OleDbConnection cnn;
        private static OleDbCommand cmd;

        private void refresh_data()
        {
            try{
                lblRemove.Text = "Remove?";
                cnn = new OleDbConnection(connetionString);
                cnn.Open();
                cmd = new OleDbCommand("SELECT [ID], [foodname], [foodcat],[foodprice] FROM tblFoods", cnn);
                DataSet sDs = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(sDs, "tblFoods");
                dataGridView1.DataSource = sDs.Tables["tblFoods"];
                cnn.Close();
                dataGridView1.ClearSelection();

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                textBox3.Clear();
                textBox4.Clear();
                numericUpDown3.Value = numericUpDown3.Minimum;
                numericUpDown4.Value = numericUpDown4.Minimum;
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0; 
            } catch(Exception ex) { MessageBox.Show(ex.Message); return; }

        }
        private void Form6_Load(object sender, EventArgs e)
        {
                refresh_data();
            try { 
                comboBox1.SelectedIndex = 0;
                dataGridView1.ClearSelection();
            }
            catch { }
        }

        private void chromeButton1_Click(object sender, EventArgs e)
        {
            refresh_data();
        }

        private void chromeButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = EscapeIlligalSQLChars(textBox1.Text);
            textBox2.Text = EscapeIlligalSQLChars(textBox2.Text);
            if (textBox1.Text == "" || textBox2.Text == "") { MessageBox.Show("Enter all required details first");return; }

            try
            {
                cnn = new OleDbConnection(connetionString);
                cnn.Open();
                cmd = new OleDbCommand("INSERT INTO tblFoods ([foodname], [foodcat], [foodingredients], [foodcalories], [foodprice]) VALUES ('" + textBox1.Text + "', '" + comboBox1.SelectedItem.ToString() + "', '" + textBox2.Text + "', " + numericUpDown1.Value + "," + numericUpDown2.Value + ")", cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
                refresh_data();
                comboBox1.SelectedIndex = 0;

                textBox1.Clear();
                textBox2.Clear();
                numericUpDown1.Value = numericUpDown1.Minimum;
                numericUpDown2.Value = numericUpDown2.Minimum;
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }
        }

        private void chromeButton3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            numericUpDown1.Value = numericUpDown1.Minimum;
            numericUpDown2.Value = numericUpDown2.Minimum;
            comboBox1.SelectedIndex = 0;
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
                        cmd = new OleDbCommand("SELECT * FROM tblFoods WHERE ID = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "", cnn);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lblUpdateIndex.Text = reader["ID"].ToString();
                                textBox3.Text = reader["foodname"].ToString();
                                comboBox2.SelectedItem = reader["foodcat"].ToString();
                                textBox4.Text = reader["foodingredients"].ToString();
                                numericUpDown3.Value = Convert.ToInt32(reader["foodcalories"].ToString());
                                numericUpDown4.Value = Convert.ToInt32(reader["foodprice"].ToString());
                                lblRemove.Text = "Delete " + reader["foodname"].ToString() + "?";
                            }
                            cnn.Close();
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                }
            }
        }

        private void chromeButton5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) { MessageBox.Show("Select a food item first!"); return; }

            textBox3.Text = EscapeIlligalSQLChars(textBox3.Text);
            textBox4.Text = EscapeIlligalSQLChars(textBox4.Text);
            if (textBox3.Text == "" || textBox4.Text == "") { MessageBox.Show("Enter all required details first"); return; }

            try
            {
                cnn = new OleDbConnection(connetionString);
                cnn.Open();
                cmd = new OleDbCommand("UPDATE tblFoods SET [foodname] = '" + textBox3.Text + "',[foodcat] = '" + comboBox2.SelectedItem.ToString() + "',[foodingredients] = '" + textBox4.Text + "',[foodcalories] = " + numericUpDown3.Value + ",[foodprice]= " + numericUpDown4.Value + " WHERE [ID] = " + lblUpdateIndex.Text + "", cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
                refresh_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }
        }

        private void chromeButton4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) { MessageBox.Show("Select a food item first!"); return; }

            DialogResult dialogResult = MessageBox.Show("Are you sure want to delete this food?\n\nThis will completely remove this food from your system.", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    cnn = new OleDbConnection(connetionString);
                    cnn.Open();
                    cmd = new OleDbCommand("DELETE FROM tblFoods WHERE [ID] = " + lblUpdateIndex.Text + "", cnn);
                    cmd.ExecuteNonQuery();


                    cmd = new OleDbCommand("DELETE FROM tblOrderDetails WHERE [foodID] = " + lblUpdateIndex.Text + "", cnn);
                    cmd.ExecuteNonQuery();



                    cnn.Close();
                    refresh_data();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); return; }
            }
        }

        private string EscapeIlligalSQLChars(String input)
        {
            input = input.Replace("\n", "").Replace(@"\n", "").Replace("\b", "").Replace(@"\b", "").Replace("\r", "").Replace(@"\r", "").Replace("\\", "").Replace(@"\\", "").Replace(@"\%", "").Replace(@"\_", "").Replace("\t", "").Replace(@"\t", "").Replace("\'", "").Replace(@"\'", "").Replace("\"", "");
            return input;
        }
    }
}
