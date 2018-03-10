using QuanLiCoffeeCShapeDotNet.BUS;
using QuanLiCoffeeCShapeDotNet.DAO;
using QuanLiCoffeeCShapeDotNet.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCoffeeCShapeDotNet
{
    public partial class frmPayment : Form
    {



        public frmPayment()
        {
            InitializeComponent();
        }

		private void btnInBill_Click(object sender, EventArgs e)
		{
			dongBill();
			inHoaDon();
		}

		private void dongBill()
		{
			//Dongs bill o day
		}

		private void inHoaDon()
		{
			try
			{
				PrintDocument printDocument = new PrintDocument();
				printDocument.PrintPage += PrintDocument_PrintPage;
				printDocument.Print();
			}
			catch(Exception)
			{

			}
		}

		private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
		{
			Graphics graphics = e.Graphics;
			Font font = new Font("Courier New",12);
			float FontHeight = font.GetHeight();
			int strartX = 10;
			int strartY = 10;
			int offSet = 100;

			graphics.DrawString("Đồ án quản lí quán coffee",new Font("Courier New", 18),new SolidBrush(Color.Black),strartX,strartY);
			string top = "Mặt hàng".PadRight(12) + "Đơn giá".PadRight(12) + "Số lượng".PadRight(12) + "Thành tiền";
			graphics.DrawString(top,font, new SolidBrush(Color.Black),strartX,strartY+offSet);
			offSet = offSet + (int)FontHeight + 5;

			graphics.DrawString("", font, new SolidBrush(Color.Black), strartX, strartY + offSet);
			offSet = offSet + (int)FontHeight + 5;

			List<BillInfo> listBillInfo = BillInfoDAO.Instances.loadBillInfoByIdBill(207);//Fix cứng
			foreach (BillInfo item in listBillInfo)
			{
				Food food = FoodDAO.Instances.loadFoodByIdFood(item.IdFood);
				int soLuong = item.BillInfoCount;
				double thanhTien = soLuong * food.Gia;

				string showItem = food.FoodName.PadRight(12) + doiSoSangDonViTienTe(food.Gia).PadRight(12) +
					soLuong.ToString().PadRight(12) + doiSoSangDonViTienTe(thanhTien).PadRight(12);

				//in 
				graphics.DrawString(showItem, font, new SolidBrush(Color.Black), strartX, strartY + offSet);
				offSet = offSet + (int)FontHeight + 5;
			}

			graphics.DrawString("----------------------------------------------------------", font, new SolidBrush(Color.Black), strartX, strartY + offSet);
			offSet = offSet + (int)FontHeight + 5;

			string tienHang = "Tiền Hàng: ".PadRight(30) + doiSoSangDonViTienTe(frmTrangChuBUS.Instances.TienHang);
			graphics.DrawString(tienHang, font, new SolidBrush(Color.Black), strartX, strartY + offSet);
			offSet = offSet + (int)FontHeight + 5;

			string phiDichVu = "Phí Dịch Vụ: ".PadRight(30) + doiSoSangDonViTienTe(frmTrangChuBUS.Instances.PhiDichVu);
			graphics.DrawString(phiDichVu, font, new SolidBrush(Color.Black), strartX, strartY + offSet);
			offSet = offSet + (int)FontHeight + 5;

			string giamGia= "Giảm giá: ".PadRight(30) + frmTrangChuBUS.Instances.GiamGia.ToString()+" %";
			graphics.DrawString(giamGia, font, new SolidBrush(Color.Black), strartX, strartY + offSet);
			offSet = offSet + (int)FontHeight + 5;

			string tongTien="Tổng Tiền".PadRight(30) + doiSoSangDonViTienTe(frmTrangChuBUS.Instances.TongTien) ;
			graphics.DrawString(tongTien, font, new SolidBrush(Color.Black), strartX, strartY + offSet);
			offSet = offSet + (int)FontHeight + 5;

		}

		private string doiSoSangDonViTienTe(object oj)
		{
			try
			{
				if (oj.ToString().Trim().Length == 0)
				{
					return " ";
				}
				if (oj.ToString() == "0")
				{
					return "0,000";
				}
				decimal dthanhTien = Convert.ToDecimal(oj);
				string srtThanhTien = string.Format("{0:#,#.}",dthanhTien);
				return srtThanhTien;
			}
			catch(Exception)
			{

			}
			return "0,000";
		}

		private void thanhToan()
		{
			txtTongTienThanhToan.Text = frmThanhToanBUS.Instances.TongTien.ToString();
		}

		private void frmPayment_Load(object sender, EventArgs e)
		{
			thanhToan();
		}

		private void txtTienKhachDua_ValueChanged(object sender, EventArgs e)
		{
			if (txtTienKhachDua.Value < txtTongTienThanhToan.Value)
			{
				MessageBox.Show("Tiền khách đưa không thể nhỏ hơn số tiền cần thanh toán !");
				return;
			}

			txtTienThoiLai.Value = txtTienKhachDua.Value - txtTongTienThanhToan.Value;
		}
	}
}
