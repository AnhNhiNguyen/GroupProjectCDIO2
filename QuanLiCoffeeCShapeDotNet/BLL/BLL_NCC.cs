using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCoffeeCShapeDotNet.BLL
{
    class BLL_NCC
    {
        DAL.DA_NhaCungCap ncc;
        frmNhaCungCap formNCC;
        public BLL_NCC(frmNhaCungCap f)
        {
            ncc = new DAL.DA_NhaCungCap();
            formNCC = f;

        }
        public void loadForm()
        {
            formNCC.dataGridView1.DataSource = ncc.layBangNCC();
        }
        public void hienthi()
        {
            formNCC.txt_MaNCC.DataBindings.Clear();
            formNCC.txt_MaNCC.DataBindings.Add("Text", formNCC.dataGridView1.DataSource, "MaNCC");
            formNCC.txt_TenNCC.DataBindings.Clear();
            formNCC.txt_TenNCC.DataBindings.Add("Text", formNCC.dataGridView1.DataSource, "TenNCC");
            formNCC.txt_DiaChi.DataBindings.Clear();
            formNCC.txt_DiaChi.DataBindings.Add("Text", formNCC.dataGridView1.DataSource, "DiaChi");
            formNCC.txt_SoDT.DataBindings.Clear();
            formNCC.txt_SoDT.DataBindings.Add("Text", formNCC.dataGridView1.DataSource, "SoDT");
             formNCC.txt_Email.DataBindings.Clear();
            formNCC.txt_Email.DataBindings.Add("Text", formNCC.dataGridView1.DataSource, "Email");
            formNCC.txt_Fax.DataBindings.Clear();
            formNCC.txt_Fax.DataBindings.Add("Text", formNCC.dataGridView1.DataSource, "Fax");
            formNCC.txt_MST.DataBindings.Clear();
            formNCC.txt_MST.DataBindings.Add("Text", formNCC.dataGridView1.DataSource, "MST");
        }
        public int Them()
        {
            return ncc.Them(formNCC.txt_MaNCC.Text
                , formNCC.txt_TenNCC.Text
                , formNCC.txt_DiaChi.Text
                , formNCC.txt_SoDT.Text
                , formNCC.txt_Email.Text
                , formNCC.txt_Fax.Text
                , formNCC.txt_MST.Text);
        }
        public int Xoa()
        {
            return ncc.Xoa(formNCC.txt_MaNCC.Text);
        }
        public int Sua()
        {
            return ncc.Sua(formNCC.txt_MaNCC.Text
                , formNCC.txt_TenNCC.Text
                 , formNCC.txt_DiaChi.Text
                , formNCC.txt_SoDT.Text
                , formNCC.txt_Email.Text
                , formNCC.txt_Fax.Text
                , formNCC.txt_MST.Text);
        }

    }
}
