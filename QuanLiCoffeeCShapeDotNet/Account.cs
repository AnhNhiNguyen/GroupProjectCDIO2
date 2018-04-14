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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals("useName") || txtPassword.Text.Equals("passWord"))
            {
                txtError.Text=  "Do not enter account or password!";
            }
            else
            {
                if (txtUsername.Text.Trim() != " " && txtPassword.Text.Trim() != " ")
                {
                    if (AccountDAO.Instance.Login(txtUsername.Text, txtPassword.Text) == true)
                    {
                        AccountDAO.Instance.Usename = txtUsername.Text;
                        this.Hide();
                        frmLoading loading = new frmLoading();
                        loading.Show();        
                    }
                    else txtError.Text= "Username or Password no value!";
                }
            }

        }

        private void Account_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            
        }
    }
    
}
