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
    public partial class studentform : Form
    {
        studentform instance;
        private const string connectionString = "Data Source=DESKTOP-SE2MU48;Initial Catalog=Facultydatabase; Integrated security =True";
        public studentform()
        {
            InitializeComponent();
            instance = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to check if the user exists in the faculty table
                    string query = "UPDATE Students SET FirstName=@FirstName, LastName=@LastName,Password = @password, DateOfBirth = @DateOfBirth, Gender = @Gender , Address = @Address , Email = @Email , PhoneNumber = @PhoneNumber  WHERE StudentID = @StudentID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@StudentID", Convert.ToInt32(txtStudent.Text));
                        command.Parameters.AddWithValue("@FirstName", Convert.ToString(txtfirst.Text));
                        command.Parameters.AddWithValue("@LastName", Convert.ToString(txtlast.Text));
                        command.Parameters.AddWithValue("@password", Convert.ToInt32(txtpass.Text));
                        command.Parameters.AddWithValue("@DateOfBirth", txtDOB.Text);
                        command.Parameters.AddWithValue("@Gender", Convert.ToString(txtgender.Text));
                        command.Parameters.AddWithValue("@Address", Convert.ToString(txtaddress.Text));
                        command.Parameters.AddWithValue("@Email", Convert.ToString(txtemail.Text));
                        command.Parameters.AddWithValue("@PhoneNumber", Convert.ToInt32(txtphone.Text));


                        int rf = command.ExecuteNonQuery();

                        if (rf > 0)
                        {
                            MessageBox.Show("record edit");
                            // Add additional actions after successful login if needed
                        }
                        else
                        {
                            MessageBox.Show("update failed.");
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
                    string query = "DELETE FROM Students WHERE StudentID =@StudentID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@StudentID", Convert.ToInt32(txtStudent.Text));
                        /*command.Parameters.AddWithValue("@FirstName", Convert.ToString(txtfirst.Text));
                        command.Parameters.AddWithValue("@LastName", Convert.ToString(txtlast.Text));
                        command.Parameters.AddWithValue("@password", Convert.ToInt32(txtpass.Text));
                        command.Parameters.AddWithValue("@DateOfBirth", txtDOB.Text);
                        command.Parameters.AddWithValue("@Gender", Convert.ToString(txtgender.Text));
                        command.Parameters.AddWithValue("@Address", Convert.ToString(txtaddress.Text));
                        command.Parameters.AddWithValue("@Email", Convert.ToString(txtemail.Text));
                        command.Parameters.AddWithValue("@PhoneNumber", Convert.ToInt32(txtphone.Text));

*/
                        int rf = command.ExecuteNonQuery();

                        if (rf > 0)
                        {
                            MessageBox.Show("record Delete");
                            // Add additional actions after successful login if needed
                        }
                        else
                        {
                            MessageBox.Show("Delet failed.");
                        }

                    }
                }


                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to check if the user exists in the faculty table
                    string query = "Insert into Students(StudentID,FirstName,LastName,password,DateOfBirth,Gender,Address,Email, PhoneNumber) Values(@StudentID,@FirstName,@LastName,@password,@DateOfBirth,@Gender,@Address, @Email,@PhoneNumber)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@StudentID", Convert.ToInt32(txtStudent.Text));
                        command.Parameters.AddWithValue("@FirstName", Convert.ToString(txtfirst.Text));
                        command.Parameters.AddWithValue("@LastName", Convert.ToString(txtlast.Text));
                        command.Parameters.AddWithValue("@password", Convert.ToInt32(txtpass.Text));
                        command.Parameters.AddWithValue("@DateOfBirth", txtDOB.Text);
                        command.Parameters.AddWithValue("@Gender", Convert.ToString(txtgender.Text));
                        command.Parameters.AddWithValue("@Address", Convert.ToString(txtaddress.Text));
                        command.Parameters.AddWithValue("@Email", Convert.ToString(txtemail.Text));
                        command.Parameters.AddWithValue("@PhoneNumber", Convert.ToInt32(txtphone.Text));


                        int rf = command.ExecuteNonQuery();

                        if (rf > 0)
                        {
                            MessageBox.Show("record Add");
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

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'facultydatabaseDataSet1.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter1.Fill(this.facultydatabaseDataSet1.Students);
            // TODO: This line of code loads data into the 'facultydatabaseDataSet.Students' table. You can move, or remove it, as needed.


        }


        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
                try
                {
                    connection.Open();
                    //string query = "Insert into Students(StudentID,FirstName,LastName,password,DateOfBirth,Gender,Address,Email, PhoneNumber) Values(@StudentID,@FirstName,@LastName,@password,@DateOfBirth,@Gender,@Address, @Email,@PhoneNumber)";
                    string QUERY = "select * from Students";
                    SqlDataAdapter sda = new SqlDataAdapter(QUERY,connection);
                    DataSet dt = new DataSet();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Fees fs = new Fees();
            fs.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Marks marks = new Marks();
            marks.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            subjectform sf = new subjectform();
            sf.Show();
        }
    }
}