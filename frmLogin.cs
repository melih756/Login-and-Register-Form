using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Login_And_Register_Form
    
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=(localdb)\\MSSQLLocalDB;Initial Catalog=userdb1;Integrated Security=SSPI");
        SqlCommand cmd;
        SqlDataAdapter da;

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string login = "SELECT * FROM tbl_users WHERE username= '" + txtUsername.Text + "' and password= '" + txtPassword.Text + "'";
            cmd = new SqlCommand(login, con);
            SqlDataReader dr = cmd.ExecuteReader();
            
            if (dr.Read() == true)
            {
                new dashboard().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password, please try again", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();
            }
            con.Close();
        }
            
        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void chckbxPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chckbxPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
              
            }
            else
            {
                txtPassword.PasswordChar = '*';
                
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            new registerForm().Show();
            this.Hide();
        }
    }
}
