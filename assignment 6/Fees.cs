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
    public partial class Fees : Form
    {
        private const string connectionString = "Data Source=DESKTOP-SE2MU48;Initial Catalog=Facultydatabase; Integrated security =True";
        public Fees()
        {
            InitializeComponent();
        }

        private void Fees_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'facultydatabaseDataSet2.Fees' table. You can move, or remove it, as needed.
            this.feesTableAdapter.Fill(this.facultydatabaseDataSet2.Fees);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to check if the user exists in the faculty table
                    string query = "Insert into Fees(FeeID,StudentID,FeeType,Amount,PaymentDate) Values(@FeeID,@StudentID,@FeeType,@Amount,@PaymentDate)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@FeeID", Convert.ToInt32(txtFeel.Text));
                        command.Parameters.AddWithValue("@StudentID", Convert.ToInt32(txtstudent.Text));
                        command.Parameters.AddWithValue("@FeeType", Convert.ToString(txtfee.Text));
                        command.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text));
                        command.Parameters.AddWithValue("@PaymentDate", txtpayment.Text);
                        

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

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to check if the user exists in the faculty table
                    string query = "UPDATE Fees SET StudentID=@StudentID,FeeType=@FeeType,Amount=@Amount,PaymentDate=@PaymentDate WHERE FeeID=@FeeID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@FeeID", Convert.ToInt32(txtFeel.Text));
                        command.Parameters.AddWithValue("@StudentID", Convert.ToInt32(txtstudent.Text));
                        command.Parameters.AddWithValue("@FeeType", Convert.ToString(txtfee.Text));
                        command.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text));
                        command.Parameters.AddWithValue("@PaymentDate", txtpayment.Text);


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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to check if the user exists in the faculty table
                    string query = "DELETE FROM Fees WHERE  FeeID= @FeeID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@FeeID", Convert.ToInt32(txtFeel.Text));
                       // command.Parameters.AddWithValue("@StudentID", Convert.ToInt32(txtstudent.Text));
                        //command.Parameters.AddWithValue("@FeeType", Convert.ToString(txtfee.Text));
                        //command.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text));
                        //command.Parameters.AddWithValue("@PaymentDate", txtpayment.Text);


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
                    string QUERY = "select * from Fees";
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
