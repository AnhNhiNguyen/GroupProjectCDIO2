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
    public partial class frmNhaCungCap : Form
    {
        BLL.BLL_NCC blnhacungcap;
       

        public frmNhaCungCap()
        {
            InitializeComponent();
            blnhacungcap = new BLL.BLL_NCC(this);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
                    }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            blnhacungcap.loadForm();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            blnhacungcap.hienthi();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
           DialogResult dialog = MessageBox.Show("Bạn thật sự muốn thoát hay không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           if (dialog == DialogResult.Yes)
            {
                // Application.Exit();
                closeForm();
            }
        }
        public void closeForm()
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn lưu hay không"
               , "Thông báo"
               , MessageBoxButtons.YesNo
               , MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                blnhacungcap.Them();
                blnhacungcap.loadForm();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            blnhacungcap.Sua();
            blnhacungcap.loadForm();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            blnhacungcap.Xoa();
            blnhacungcap.loadForm();
        }
    }
}
