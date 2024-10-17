using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EmployeeManagment
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/mm/yyyy hh:mm:ss";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=NANO-PC;Initial Catalog=employeedb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into emtab values(@empid,@employeename,@dob,@email,@adress,@salary)",con);
            cnn.Parameters.AddWithValue("@EmpId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@EmployeeName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Dob", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@Email", textBox3.Text);
            cnn.Parameters.AddWithValue("@Adress", textBox4.Text);
            cnn.Parameters.AddWithValue("@Salary", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Save Sucessfuly", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=NANO-PC;Initial Catalog=employeedb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from emtab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=NANO-PC;Initial Catalog=employeedb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("update emtab set employeename=@employeename ,dob=@dob,email=@email,adress=@adress,salary=@salary where empid=@empid", con);
            cnn.Parameters.AddWithValue("@EmpId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@EmployeeName", int.Parse(textBox2.Text));
            cnn.Parameters.AddWithValue("@Dob", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@Email", int.Parse(textBox3.Text));
            cnn.Parameters.AddWithValue("@Adress", int.Parse(textBox3.Text));
            cnn.Parameters.AddWithValue("@Salary", int.Parse(textBox4.Text));
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Update Sucessfuly", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=NANO-PC;Initial Catalog=employeedb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("delete emtab where empid=@empid", con);
            cnn.Parameters.AddWithValue("@EmpId", int.Parse(textBox1.Text));
            
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Delete Sucessfuly", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            {
                textBox1.Text = "";
                textBox2.Text = "";

                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=NANO-PC;Initial Catalog=employeedb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from emtab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
