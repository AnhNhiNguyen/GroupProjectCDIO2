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
			int offSet = 290;
            SolidBrush soli = new SolidBrush(Color.Black);

			graphics.DrawString("Đồ án quản lí quán coffee",new Font("Courier New", 18),new SolidBrush(Color.Black),strartX,strartY);     
            graphics.DrawString("\tCOFFEE HOUSE", new Font("Courier New", 20,FontStyle.Bold), new SolidBrush(Color.Black), strartX, strartY+55);
            graphics.DrawString("  254 Nguyễn Văn Linh - Tp.Đà Nẵng", new Font("Courier", 18), new SolidBrush(Color.Black), strartX, strartY + 80);
            graphics.DrawString("\tĐiện Thoại:0969696969 ", new Font("Courier", 18), new SolidBrush(Color.Black), strartX, strartY + 110);
            graphics.DrawString("\tPHIẾU TẠM TÍNH", new Font("/tCorier", 18), new SolidBrush(Color.Black), strartX, strartY + 170);
            string date  = DateTime.Now.ToString().Trim();
            date = date.Substring(0, 10);
            graphics.DrawString("Ngày: "+date,font,new SolidBrush(Color.Black),strartX,strartY+200);
            
            string use = AccountDAO.Instance.Usename;
            graphics.DrawString("Thu Ngân: "+use,font,soli,strartX,strartY+225);


            string top = "Mặt hàng".PadRight(12) + "Đơn giá".PadRight(12)+"ĐVT".PadRight(12) + "Số lượng".PadRight(12) + "Thành tiền";
			graphics.DrawString(top,font, new SolidBrush(Color.Black),strartX,strartY+offSet);
			offSet = offSet + (int)FontHeight + 5;

			//graphics.DrawString("", font, new SolidBrush(Color.Black), strartX, strartY + offSet);
   //         offSet = offSet + (int)FontHeight + 5;

            int idBill = BillDAO.Instances.getIdBillByIdTable(Convert.ToInt16( frmTrangChuBUS.Instances.BtnClicked.Name.ToString()));
			List<BillInfo> listBillInfo = BillInfoDAO.Instances.loadBillInfoByIdBill(idBill);//Fix cứng
			foreach (BillInfo item in listBillInfo)
			{
                graphics.DrawString("----------------------------------------------------------", font, soli, strartX, strartY+offSet);
                offSet = offSet + (int)FontHeight + 5;

                Food food = FoodDAO.Instances.loadFoodByIdFood(item.IdFood);
				int soLuong = item.BillInfoCount;
				double thanhTien = soLuong * food.Gia;

				string showItem = food.FoodName.PadRight(12) + doiSoSangDonViTienTe(food.Gia).PadRight(12) +food.DonViTinh.PadRight(12)
					+soLuong.ToString().PadRight(12) + doiSoSangDonViTienTe(thanhTien).PadRight(12);

				//in 
				graphics.DrawString(showItem, font, new SolidBrush(Color.Black), strartX, strartY + offSet);
				offSet = offSet + (int)FontHeight + 5;
                
            }

			graphics.DrawString("----------------------------------------------------------", font, new SolidBrush(Color.Black), strartX, strartY + offSet);
			offSet = offSet + (int)FontHeight + 5;

			string tienHang = "Tiền Hàng: ".PadRight(49) + doiSoSangDonViTienTe(frmTrangChuBUS.Instances.TienHang);
			graphics.DrawString(tienHang, font, new SolidBrush(Color.Black), strartX, strartY + offSet);
			offSet = offSet + (int)FontHeight + 5;

			string phiDichVu = "Phí Dịch Vụ: ".PadRight(49) + doiSoSangDonViTienTe(frmTrangChuBUS.Instances.PhiDichVu);
			graphics.DrawString(phiDichVu, font, new SolidBrush(Color.Black), strartX, strartY + offSet);
			offSet = offSet + (int)FontHeight + 5;

			string giamGia= "Giảm giá: ".PadRight(49) + frmTrangChuBUS.Instances.GiamGia.ToString()+" %";
			graphics.DrawString(giamGia, font, new SolidBrush(Color.Black), strartX, strartY + offSet);
            offSet = offSet + (int)FontHeight + 5;
            graphics.DrawString("----------------------------------------------------------", font, soli, strartX, strartY + offSet);
            offSet = offSet + (int)FontHeight + 5;

            string tongTien=("Tổng Tiền".PadRight(30)) + doiSoSangDonViTienTe(frmTrangChuBUS.Instances.TongTien) ;
			graphics.DrawString(tongTien,new Font("Courier New",18,FontStyle.Bold), new SolidBrush(Color.Black), strartX, strartY + offSet);
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
