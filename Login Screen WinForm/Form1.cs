using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Login_Screen_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Password_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter The username");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Enter The password");

            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"Server = LAPTOP-JFIAGS6G\SQLEXPRESS ; Database = LoginForm ; Integrated Security = SSPI ; TrustServerCertificate = True");
                    string sql = "select TRIM( Password) Password ,TRIM(Active) Active from tbl_login where TRIM(upper (Username))= upper (@usename)";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    // conn.Open();
                    cmd.Parameters.AddWithValue("usename", textBox1.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);




                    if (dt.Rows.Count > 0)
                    {
                        string passward_db = dt.Rows[0]["Password"].ToString();

                        string Active_User = dt.Rows[0]["Active"].ToString();

                        if (passward_db == textBox2.Text.Trim())
                        {
                            if (Active_User == "Yes")
                            {
                                MessageBox.Show("Login Successful");
                                return;

                            }
                            else
                            {
                                MessageBox.Show("user is inacteve");
                                return;

                            }


                        }
                        else
                        {
                            MessageBox.Show("invalid Password");
                            return;

                        }



                    }
                    else
                    {
                        MessageBox.Show("user dosnt exist");

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }

            }

        }
    }
}
