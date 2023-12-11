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
    public partial class Marks : Form
    {
        public const string conn = "Data Source = DESKTOP-SE2MU48; Initial Catalog=Facultydatabase; integrated Security = true";
        public Marks()
        {
            InitializeComponent();
        }

        private void Marks_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'facultydatabaseMarks.Marks' table. You can move, or remove it, as needed.
            this.marksTableAdapter.Fill(this.facultydatabaseMarks.Marks);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    string query = "Insert into Marks (MarkID,StudentID,Subject,MarksObtained,Grade) Values (@MarkID,@StudentID,@Subject,@MarksObtained,@Grade)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MarkID", Convert.ToInt32(txtmark.Text));
                        command.Parameters.AddWithValue("@StudentID", Convert.ToInt32(txtstudent.Text));
                        command.Parameters.AddWithValue("@Subject", Convert.ToString(txtsubject.Text));
                        command.Parameters.AddWithValue("@MarksObtained", Convert.ToInt32(txtmarkob.Text));
                        command.Parameters.AddWithValue("@Grade", Convert.ToString(txtgrade.Text));

                        int rf = command.ExecuteNonQuery();
                        if (rf > 0)
                        {
                            MessageBox.Show("record add");
                        }
                        else
                        {
                            MessageBox.Show("add failed");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error:{ex.Message}");
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
                    string query = "UPDATE Marks set StudentID=@StudentID,Subject=@Subject,MarksObtained=@MarksObtained,Grade=@Grade WHERE MarkID=@MarkID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MarkID", Convert.ToInt32(txtmark.Text));
                        command.Parameters.AddWithValue("@StudentID", Convert.ToInt32(txtstudent.Text));
                        command.Parameters.AddWithValue("@Subject", Convert.ToString(txtsubject.Text));
                        command.Parameters.AddWithValue("@MarksObtained", Convert.ToInt32(txtmarkob.Text));
                        command.Parameters.AddWithValue("@Grade", Convert.ToString(txtgrade.Text));

                        int rf = command.ExecuteNonQuery();
                        if (rf > 0)
                        {
                            MessageBox.Show("Record Update");
                        }
                        else
                        {
                            MessageBox.Show("update failed");
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
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM  Marks WHERE MarkID = @MarkID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MarkID", Convert.ToInt32(txtmark.Text));

                        int rf = command.ExecuteNonQuery();
                        if (rf > 0)
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
                        string QUERY = "select * from Marks";
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
