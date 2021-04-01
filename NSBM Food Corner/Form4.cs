using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NSBM_Food_Corner
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private static string connetionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\MainDB.mdb";
        private static OleDbConnection cnn;
        private static OleDbCommand cmd;
        private void chromeButton1_Click(object sender, EventArgs e)
        {
            textBox1.Text = EscapeIlligalSQLChars(textBox1.Text);
            textBox2.Text = EscapeIlligalSQLChars(textBox2.Text);

            if (textBox1.Text == "" || textBox2.Text == "") { MessageBox.Show("Enter required details first!"); return; }

            try
            {
                cnn = new OleDbConnection(connetionString);
                cnn.Open();
                cmd = new OleDbCommand("SELECT COUNT(*) FROM tblUsers WHERE [username] = '" + textBox1.Text + "' AND [password] = '" + textBox2.Text + "'", cnn);
                int result = (int)cmd.ExecuteScalar();

                if (result == 0)
                {
                    //wrong
                    MessageBox.Show("Wrong credientials!");
                    textBox2.Text = "";
                    textBox2.Focus();
                }
                else
                {
                    //logged
                    Form5 frm5 = new Form5();
                    cmd = new OleDbCommand("SELECT [fname],[lastlogin] FROM tblUsers WHERE [username] = '" + textBox1.Text + "'", cnn);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            frm5.lblWelcome.Text = "Welcome " + reader["fname"].ToString();
                            frm5.lblLastLogin.Text = "Your last login was on " + reader["lastlogin"].ToString();
                        }
                    }

                    //upadte last login
                    cmd = new OleDbCommand("UPDATE tblUsers SET [lastlogin] = '" + DateTime.Now.ToString() + "'  WHERE [username] = '" + textBox1.Text + "'", cnn);
                    cmd.ExecuteNonQuery();

                    this.Dispose(true);
                    frm5.ShowDialog();
                }

                cnn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }
        }

        private void chromeButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        private string EscapeIlligalSQLChars(String input)
        {
            input = input.Replace("\n", "").Replace(@"\n", "").Replace("\b", "").Replace(@"\b", "").Replace("\r", "").Replace(@"\r", "").Replace("\\", "").Replace(@"\\", "").Replace(@"\%", "").Replace(@"\_", "").Replace("\t", "").Replace(@"\t", "").Replace("\'", "").Replace(@"\'", "").Replace("\"", "");
            return input;
        }
    }
}
