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
    public partial class subjectform : Form
    {
        public const string conn = "Data Source = DESKTOP-SE2MU48; Initial Catalog=Facultydatabase; integrated Security = true";
        public subjectform()
        {
            InitializeComponent();
        }

        private void subjectform_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'facultydatabaseDataSet3.Subjects' table. You can move, or remove it, as needed.
            this.subjectsTableAdapter.Fill(this.facultydatabaseDataSet3.Subjects);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    string query = "Insert into Subjects (SubjectID,SubjectName) Values (@SubjectID,@SubjectName)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SubjectID", Convert.ToInt32(txtSubject.Text));
                        command.Parameters.AddWithValue("@SubjectName", Convert.ToString(txtSubjName.Text));


                        int rf = command.ExecuteNonQuery();
                        if (rf != 0)
                        {
                            MessageBox.Show("record add");
                        }
                        else
                        {
                            MessageBox.Show("invalid add");
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
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();

                    // Query to check if the user exists in the faculty table
                    string query = "UPDATE Subjects SET SubjectName = @SubjectName WHERE SubjectID=@SubjectID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@SubjectID", Convert.ToInt32(txtSubject.Text));
                        command.Parameters.AddWithValue("@SubjectName", Convert.ToString(txtSubjName.Text));



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

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM  Subjects WHERE SubjectID = @SubjectID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SubjectID", Convert.ToInt32(txtSubject.Text));

                        int rf = command.ExecuteNonQuery();
                        if (rf>0)
                        {
                            MessageBox.Show("record Delete");
                        }
                        else
                        {
                            MessageBox.Show("Delete failed");
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error:{ex.Message}");
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                using (SqlConnection connection = new SqlConnection(conn))
                    try
                    {
                        connection.Open();
                        //string query = "Insert into Students(StudentID,FirstName,LastName,password,DateOfBirth,Gender,Address,Email, PhoneNumber) Values(@StudentID,@FirstName,@LastName,@password,@DateOfBirth,@Gender,@Address, @Email,@PhoneNumber)";
                        string QUERY = "select * from Subjects";
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
}
