using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1
{
    public partial class Login : Form
    {
        public const string conn = "Data Source = DESKTOP-SE2MU48; Initial Catalog=Facultydatabase; integrated Security = true";

        public Login instance;
        public Login()
        {

            InitializeComponent();
            instance = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registrationfrom rs = new Registrationfrom();
            rs.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Facultyform fs = new Facultyform();
            fs.Show();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    string query = "select count (*) as cnt from Faculty where FirstName=@FirstName and Password=@Password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@FirstName", Convert.ToString(txtfirst.Text));
                        command.Parameters.AddWithValue("@Password", Convert.ToInt32(txtpass.Text));

                        int rf = command.ExecuteNonQuery();

                        if (rf != 0)
                        {
                            MessageBox.Show("Login Success");
                        }
                        else
                        {
                            MessageBox.Show("Login failed");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error:{ex.Message}");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            studentform sf = new studentform();
            sf.Show();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    string query = "select count (*) as cnt from Students where FirstName=@FirstName and password=@password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@FirstName", Convert.ToString(txtfirst.Text));
                        command.Parameters.AddWithValue("@password", Convert.ToInt32(txtpass.Text));

                        int rf = command.ExecuteNonQuery();

                        if (rf != 0)
                        {
                            MessageBox.Show("Login Success");
                        }
                        else
                        {
                            MessageBox.Show("Login failed");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error:{ex.Message}");
                }
            }
        }
    }
}