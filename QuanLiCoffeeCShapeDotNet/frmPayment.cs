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
			inHoaDon();
			this.Close();
		}

		private void dongBill()
		{
			try
			{
				int idTable = -1;
				idTable = Convert.ToInt32(frmTrangChuBUS.Instances.BtnClicked.Name);
				frmTrangChuBUS.Instances.deleteBillByIdTable(idTable);
			}catch(Exception)
			{

			}			
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
			string use = AccountDAO.Instance.Usename;
			graphics.DrawString("Ngày: "+date.PadRight(22)+"Thu ngân: "+use,font,new SolidBrush(Color.Black),strartX,strartY+200);
            
            
            graphics.DrawString("".PadRight(15)+frmTrangChuBUS.Instances.BtnClicked.Text.ToString(),new Font("Courier New", 20,FontStyle.Bold), soli,strartX,strartY+225);


            string top = "Mặt hàng".PadRight(20) + "Đơn giá".PadRight(12)+"ĐVT".PadRight(10) + "Số lượng".PadRight(12) + "Thành tiền";
			graphics.DrawString(top,font, new SolidBrush(Color.Black),strartX,strartY+offSet);
			offSet = offSet + (int)FontHeight + 5;

			//graphics.DrawString("", font, new SolidBrush(Color.Black), strartX, strartY + offSet);
			//         offSet = offSet + (int)FontHeight + 5;

			graphics.DrawString("----------------------------------------------------------------", font, soli, strartX, strartY + offSet);
			offSet = offSet + (int)FontHeight + 5;

			int idBill = BillDAO.Instances.getIdBillByIdTable(Convert.ToInt16( frmTrangChuBUS.Instances.BtnClicked.Name.ToString()));
			List<BillInfo> listBillInfo = BillInfoDAO.Instances.loadBillInfoByIdBill(idBill);
			foreach (BillInfo item in listBillInfo)
			{
                

                Food food = FoodDAO.Instances.loadFoodByIdFood(item.IdFood);
				int soLuong = item.BillInfoCount;
				double thanhTien = soLuong * food.Gia;

				string showItem = food.FoodName.PadRight(20) + doiSoSangDonViTienTe(food.Gia).PadRight(12) +food.DonViTinh.PadRight(10)
					+soLuong.ToString().PadRight(12) + doiSoSangDonViTienTe(thanhTien);

				//in 
				graphics.DrawString(showItem, font, new SolidBrush(Color.Black), strartX, strartY + offSet);
				offSet = offSet + (int)FontHeight + 5;
                
            }

			graphics.DrawString("----------------------------------------------------------------", font, new SolidBrush(Color.Black), strartX, strartY + offSet);
			offSet = offSet + (int)FontHeight + 5;

			string tienHang = "".PadRight(35)+"Tiền Hàng: ".PadRight(5) + doiSoSangDonViTienTe(frmTrangChuBUS.Instances.TienHang);
			graphics.DrawString(tienHang, font, new SolidBrush(Color.Black), strartX, strartY + offSet);
			offSet = offSet + (int)FontHeight + 5;

			string phiDichVu = "".PadRight(35)+"Phí Dịch Vụ: ".PadRight(5) + doiSoSangDonViTienTe(frmTrangChuBUS.Instances.PhiDichVu);
			graphics.DrawString(phiDichVu, font, new SolidBrush(Color.Black), strartX, strartY + offSet);
			offSet = offSet + (int)FontHeight + 5;

			string giamGia= "".PadRight(35)+"Giảm giá: ".PadRight(5) + frmTrangChuBUS.Instances.GiamGia.ToString()+" %";
			graphics.DrawString(giamGia, font, new SolidBrush(Color.Black), strartX, strartY + offSet);
            offSet = offSet + (int)FontHeight + 5;
            graphics.DrawString("----------------------------------------------------------------", font, soli, strartX, strartY + offSet);
            offSet = offSet + (int)FontHeight + 5;

            string tongTien=("Tổng Tiền: ".PadRight(30)) + doiSoSangDonViTienTe(frmTrangChuBUS.Instances.TongTien) ;
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
			txtTongTienThanhToan.Text = frmTrangChuBUS.Instances.doiSoSangDonViTienTe(frmThanhToanBUS.Instances.TongTien);
			txtTienKhachDua.Value = Convert.ToInt16(frmThanhToanBUS.Instances.TongTien);
		}

		private void frmPayment_Load(object sender, EventArgs e)
		{
			thanhToan();
		}

		private void txtTienKhachDua_ValueChanged(object sender, EventArgs e)
		{

			try
			{
				if (txtTienKhachDua.Value < Convert.ToInt16(frmThanhToanBUS.Instances.TongTien))
				{
					MessageBox.Show("Tiền khách đưa không thể nhỏ hơn số tiền cần thanh toán !");
					return;
				}

				txtTienThoiLai.Text = frmTrangChuBUS.Instances.doiSoSangDonViTienTe(txtTienKhachDua.Value - Convert.ToInt16(frmThanhToanBUS.Instances.TongTien));
			}
			catch (Exception)
			{

			}
			
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnDongBill_Click(object sender, EventArgs e)
		{
			dongBill();
			this.Close();
		}

		private void btnDongBillAndPrint_Click(object sender, EventArgs e)
		{
			inHoaDon();
			dongBill();
			this.Close();
		}

		private void frmPayment_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Dispose();
		}
	}
}
