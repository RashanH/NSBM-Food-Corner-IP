using MailKit;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO.Ports;
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
    public partial class Form2 : Form
    {
        private Form1 mainForm = null;
        public Form2(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }
        private static string connetionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\MainDB.mdb";
        private static OleDbConnection cnn;
        private static OleDbCommand cmd;

        string str = "Data Source=.;Initial Catalog=AMS;Integrated Security=True";
        private SerialPort RFID;
        private string DispString;
        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();

            //RFID
            RFID = new SerialPort();
            RFID.PortName = "COM5";
            RFID.BaudRate = 9600;
            RFID.DataBits = 8;
            RFID.Parity = Parity.None;
            RFID.StopBits = StopBits.One;
            //RFID.Open();
            RFID.ReadTimeout = 200;
            if (RFID.IsOpen)
            {
                txtIndexNo.Text = "";
                txtPassword.Text = "";
            }
            else
            {
                RFID.Close();
            }
            RFID.DataReceived += new SerialDataReceivedEventHandler(RFID_DataReceived);
        }
        private void RFID_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DispString = RFID.ReadExisting();
            perform_order(DispString.Split('|')[0], DispString.Split('|')[1]);
        }

  
        private void btnOrder_Click(object sender, EventArgs e)
        {
            perform_order(txtIndexNo.Text, txtPassword.Text);
        }

        private void perform_order(string index_no, string password)
        {
            index_no = EscapeIlligalSQLChars(index_no);
            password = EscapeIlligalSQLChars(password);
            if (index_no == "" || password == "") { MessageBox.Show("Enter all required details first"); return; }

            //check login
            try
            {
                cnn = new OleDbConnection(connetionString);
                cnn.Open();
                cmd = new OleDbCommand("SELECT COUNT(*) FROM tblStudents WHERE [studentID] = " + index_no + " AND [studentPassword] = '" + password + "'", cnn);
                int result = (int)cmd.ExecuteScalar();

                if (result == 0)
                {
                    //wrong
                    MessageBox.Show("Wrong credientials! Try again.");
                    txtPassword.Text = "";
                    txtPassword.Focus();
                }
                else
                {
                    //success
                    //add to db
                    cmd = new OleDbCommand("INSERT INTO tblOrders ([studentID], [ordertime], [status]) VALUES ('" + index_no + "', '" + DateTime.Now.ToString() + "', 'Open')", cnn);
                    cmd.ExecuteNonQuery();
                    cmd = new OleDbCommand("SELECT COUNT(*) FROM tblOrders", cnn);
                    int order_id = (int)cmd.ExecuteScalar();

                    //add order details
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        cmd = new OleDbCommand("INSERT INTO tblOrderDetails ([orderID], [foodID], [qty]) VALUES (" + order_id + ", " + row.Cells[0].Value.ToString() + ", " + row.Cells[3].Value.ToString() + ")", cnn);
                        cmd.ExecuteNonQuery();
                    }

                    Form3 frm3 = new Form3();
                    cmd = new OleDbCommand("SELECT [studentFName], [studentPhone], [studentEmail] FROM tblStudents WHERE [studentID] = " + index_no + "", cnn);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            frm3.lblEstimation.Text = "Estimated delivery in: 15 minutes";
                            frm3.lblTotal.Text = lblTotal.Text;
                            frm3.lblThanks.Text = "Thanks for your order " + reader["studentFName"].ToString() + "!";
                            frm3.lblNotify.Text = "We will notify you via SMS to " + reader["studentPhone"].ToString() + ".";
                            frm3.lblOrderID.Text = "Your order number is: " + order_id.ToString();

                            string email = reader["studentEmail"].ToString();
                            string email_body = "Thanks for your order." + Environment.NewLine + Environment.NewLine + "Item\tQty.\tTotal" + Environment.NewLine;
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                email_body += Environment.NewLine + row.Cells[0].Value.ToString() + "\t" + row.Cells[1].Value.ToString() + "\t" + row.Cells[2].Value.ToString() + "LKR";
                            }
                            email_body += Environment.NewLine + Environment.NewLine + "Total: " + lblTotal.Text + Environment.NewLine + Environment.NewLine + "- NSBM Food Corner";
                            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                            string student_phone = reader["studentPhone"].ToString();
                            string studentName = reader["studentFName"].ToString();
                            new Thread(() =>
                            {
                                //Send SMS
                                
                                try
                                {
                                    TwilioClient.Init(accountSid, authToken);
                                    MessageResource.Create(
                                        from: new PhoneNumber(send_from),
                                        to: new PhoneNumber(student_phone),
                                        body: Environment.NewLine + Environment.NewLine + "Thanks for your order " + studentName +
                                    Environment.NewLine + "Your order number is: " + order_id.ToString() +
                                    Environment.NewLine + "Estimated delivery in: 15 minutes" +
                                     Environment.NewLine + "Please prepare your payment of " + lblTotal.Text +
                                      Environment.NewLine + Environment.NewLine + "- NSBM Food Corner");
                                }
                                catch { }

                                //Send Email Notification
                                
                                send_email(email,
                                    "NSBM Food Corner Payment Receipt #" + order_id.ToString(),
                                    email_body
                                );
                                Thread.CurrentThread.Abort();
                            }).Start();

                        }
                    }


                    frm3.ShowDialog();
                    this.Dispose(true);
                    mainForm.switch_to_default_data();
                    mainForm.clear_all_rows();
                    refresh_bill();
                }
                cnn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }

        }

        private string accountSid = "";
        private string authToken = "";
        private string send_from = "";
        private string smtp_email = "";
        private string smtp_host = "smtp.gmail.com";
        private int smtp_port = 587;
        private string smtp_user = "";
        private string smtp_password = "";
        private void send_email(string email_add, string subj, string email_body, bool testing = false)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(smtp_email));

                var builder = new BodyBuilder();

                if (testing)
                {
                    message.To.Add(new MailboxAddress(smtp_email));
                    message.Subject = "Test Mail";
                    builder.TextBody = "Congratz. Your SMTP details are working.";
                }
                else
                {
                    //production
                    message.To.Add(new MailboxAddress(email_add));
                    message.From.Add(new MailboxAddress("NSBM Food Corner Postman", smtp_email));
                    message.Subject = subj;
                    builder.TextBody = email_body;
                }

                message.Body = builder.ToMessageBody();

                using (var client = new MailKit.Net.Smtp.SmtpClient(new ProtocolLogger("smtp.log")))
                {
                    client.Connect(smtp_host, smtp_port, SecureSocketOptions.StartTls);

                    client.Authenticate(smtp_user, smtp_password);

                    client.Send(message);

                    client.Disconnect(true);
                }

                if (testing) { MessageBox.Show("Email sent! Check your inbox."); }


            }
            catch (Exception ex)
            {
                if (testing) { MessageBox.Show(ex.Message + "\nIf you are using Gmail, make sure to enable less-secure apps access. (https://myaccount.google.com/lesssecureapps)"); }
            }
        }

        private void txtIndexNo_TextChanged(object sender, EventArgs e)
        {
            txtIndexNo.Text = GetNumbers(txtIndexNo.Text);
            if (txtIndexNo.Text.Length >= 5 && txtPassword.Text.Length >= 1) { btnOrder.Enabled = true; } else { btnOrder.Enabled = false; }
        }
        private static string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtIndexNo.Text.Length >= 5 && txtPassword.Text.Length >= 1) { btnOrder.Enabled = true; } else { btnOrder.Enabled = false; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }
        public void refresh_bill()
        {
            lblTotal.Text = dataGridView1.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[4].Value)).ToString() + " LKR";
        }

        private string EscapeIlligalSQLChars(String input)
        {
            input = input.Replace("\n", "").Replace(@"\n", "").Replace("\b", "").Replace(@"\b", "").Replace("\r", "").Replace(@"\r", "").Replace("\\", "").Replace(@"\\", "").Replace(@"\%", "").Replace(@"\_", "").Replace("\t", "").Replace(@"\t", "").Replace("\'", "").Replace(@"\'", "").Replace("\"", "");
            return input;
        }

        private void form1_keydown(object sender, KeyEventArgs e)
        {
            //Mock
            if (e.Control && e.KeyCode == Keys.D1)
            {
                //rashan
                perform_order("10707044", "123456");
            }
            else if (e.Control && e.KeyCode == Keys.D2)
            {
                //shashika
                perform_order("10707350", "123456");
            }
            else if (e.Control && e.KeyCode == Keys.D3)
            {
                //dilshan
                perform_order("10707182", "123456");
            }
            else if (e.Control && e.KeyCode == Keys.D4)
            {
                //avishka
                perform_order("10707137", "123456");
            }
        }
    }
}
