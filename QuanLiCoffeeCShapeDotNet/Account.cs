using QuanLiCoffeeCShapeDotNet.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCoffeeCShapeDotNet
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals("useName") || txtPassword.Text.Equals("passWord"))
            {
                MessageBox.Show( "Do not enter account or password!");
            }
            else
            {
                if (txtUsername.Text.Trim() != " " && txtPassword.Text.Trim() != " ")
                {
                    if (AccountDAO.Instance.Login(txtUsername.Text, txtPassword.Text) == true)
                    {
                        this.Hide();
                        frmLoading loading = new frmLoading();
                        loading.Show();
                    }
                    else MessageBox.Show( "Username or Password no value!");
                }
            }

        }

  
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txtPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = true;
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupbox1_Enter(object sender, EventArgs e)
        {

        }
    }
    
}
