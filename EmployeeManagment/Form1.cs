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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace EmployeeManagment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=NANO-PC;Initial Catalog=employeedb;Integrated Security=True;Encrypt=False");
            con.Open();
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            SqlCommand cnn = new SqlCommand("Select Username, Password from logintab where Username='" + txtUsername.Text + "' and Password='" + txtPassword.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            if (table.Rows.Count > 0)
            {
                Employee em = new Employee();
                em.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
            con.Close();
            //SqlConnection con = new SqlConnection(@"Data Source=NANO-PC;Initial Catalog=employeedb;Integrated Security=True;Encrypt=False");
            //con.Open();
            //string query = "SELECT COUNT(*) FROM logintab WHERE username=@Username AND password=@Password";
            //SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            //cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            //int count = (int)cmd.ExecuteScalar();
            //con.Close();
            //if (count > 0)
            //{
            //    MessageBox.Show("login success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("error in login");
            //}

            ////password show hide:

            ////txtPassword.UseSystemPasswordChar = !Form1.check;

            ////close form:

            //this.Close();
        }
    }
}
