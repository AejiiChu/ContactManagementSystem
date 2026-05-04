using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManagementSystem
{
    public partial class Form1 : Form
    {

        MySqlConnection con = new MySqlConnection(
            "server=localhost;database=ContactDB;uid=root;pwd=pw072801;"

        );
        public Form1()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM Contacts", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required!");
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required!");
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Phone is required!");
                txtPhone.Focus();
                return false;
            }

            if (!txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Invalid email format!");
                txtEmail.Focus();
                return false;
            }

            if (!txtPhone.Text.All(char.IsDigit))
            {
                MessageBox.Show("Phone must be numbers only!");
                txtPhone.Focus();
                return false;
            }

            return true;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO Contacts(Name, Email, Phone) VALUES(@Name,@Email,@Phone)", con);

            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtPhone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Select a row first!");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            MySqlCommand cmd = new MySqlCommand(
                "UPDATE Contacts SET Name=@Name, Email=@Email, Phone=@Phone WHERE ID=@ID", con);

            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@ID", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Select a row first!");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            MySqlCommand cmd = new MySqlCommand(
                "DELETE FROM Contacts WHERE ID=@ID", con);

            cmd.Parameters.AddWithValue("@ID", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            LoadData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
