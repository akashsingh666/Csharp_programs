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
    public partial class Facultyform : Form
    {
        private const string connectionString = "Data Source=DESKTOP-SE2MU48;Initial Catalog=Facultydatabase; Integrated security =True";
        public Facultyform()
        {
            InitializeComponent();
        }

        private void Facultyform_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'facultydatabaseDataSet.Faculty' table. You can move, or remove it, as needed.
            this.facultyTableAdapter.Fill(this.facultydatabaseDataSet.Faculty);
            // TODO: This line of code loads data into the 'facultydatabaseDataSet.Faculty' table. You can move, or remove it, as needed.


        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to check if the user exists in the faculty table
                    string query = "Insert into Faculty(FacultyID,FirstName,LastName,Password,DateOfBirth,Gender,Address,Email, PhoneNumber,Department) Values (@FacultyID,@FirstName,@LastName,@Password,@DateOfBirth,@Gender,@Address, @Email,@PhoneNumber , @Department)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@FacultyID", Convert.ToInt32(txtfact.Text));
                        command.Parameters.AddWithValue("@FirstName", Convert.ToString(txtfirst.Text));
                        command.Parameters.AddWithValue("@LastName", Convert.ToString(txtlast.Text));
                        command.Parameters.AddWithValue("@Password", Convert.ToInt32(txtpass.Text));
                        command.Parameters.AddWithValue("@DateOfBirth", txtDOB.Text);
                        command.Parameters.AddWithValue("@Gender", Convert.ToString(txtgender.Text));
                        command.Parameters.AddWithValue("@Address", Convert.ToString(txtaddress.Text));
                        command.Parameters.AddWithValue("@Email", Convert.ToString(txtemail.Text));
                        command.Parameters.AddWithValue("@PhoneNumber", Convert.ToInt32(txtphone.Text));
                        command.Parameters.AddWithValue("@Department", Convert.ToString(txtdepart.Text));

                        int rf = command.ExecuteNonQuery();

                        if (rf > 0)
                        {
                            MessageBox.Show("record inserted");
                            // Add additional actions after successful login if needed
                        }
                        else
                        {
                            MessageBox.Show("insertion failed.");
                        }

                    }
                }


                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to check if the user exists in the faculty table
                    string query = " UPADATE Faculty SET FirstName=@FirstName,LastName=@LastName,Password=@Password,DateOfBirth =@DateOfBirth ,Gender= @Gender,Address = @Address ,Email = @Email, PhoneNumber = @PhoneNumber,Department = @Department WHERE FacultyID = @FacultyID ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@FacultyID", Convert.ToInt32(txtfact.Text));
                        command.Parameters.AddWithValue("@FirstName", Convert.ToString(txtfirst.Text));
                        command.Parameters.AddWithValue("@LastName", Convert.ToString(txtlast.Text));
                        command.Parameters.AddWithValue("@Password", Convert.ToInt32(txtpass.Text));
                        command.Parameters.AddWithValue("@DateOfBirth", txtDOB.Text);
                        command.Parameters.AddWithValue("@Gender", Convert.ToString(txtgender.Text));
                        command.Parameters.AddWithValue("@Address", Convert.ToString(txtaddress.Text));
                        command.Parameters.AddWithValue("@Email", Convert.ToString(txtemail.Text));
                        command.Parameters.AddWithValue("@PhoneNumber", Convert.ToInt32(txtphone.Text));
                        command.Parameters.AddWithValue("@Department", Convert.ToString(txtdepart.Text));

                        int rf = command.ExecuteNonQuery();

                        if (rf > 0)
                        {
                            MessageBox.Show("record inserted");
                            // Add additional actions after successful login if needed
                        }
                        else
                        {
                            MessageBox.Show("insertion failed.");
                        }

                    }
                }


                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to check if the user exists in the faculty table
                    string query = "DELETE FROM Faculty WHERE  FacultyID= @FacultyID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@FacultyID", Convert.ToInt32(txtfact.Text));

                        int rf = command.ExecuteNonQuery();

                        if (rf > 0)
                        {
                            MessageBox.Show("record update");
                            // Add additional actions after successful login if needed
                        }
                        else
                        {
                            MessageBox.Show("Edit failed.");
                        }

                    }
                }


                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
                try
                {
                    connection.Open();
                    //string query = "Insert into Students(StudentID,FirstName,LastName,password,DateOfBirth,Gender,Address,Email, PhoneNumber) Values(@StudentID,@FirstName,@LastName,@password,@DateOfBirth,@Gender,@Address, @Email,@PhoneNumber)";
                    string QUERY = "select * from Faculty";
                    SqlDataAdapter sda = new SqlDataAdapter(QUERY, connection);
                    DataSet dt = new DataSet();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
    }
}
