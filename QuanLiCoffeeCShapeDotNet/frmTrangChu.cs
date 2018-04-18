using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiCoffeeCShapeDotNet.DAO;
using QuanLiCoffeeCShapeDotNet.DTO;
using QuanLiCoffeeCShapeDotNet.BUS;

namespace QuanLiCoffeeCShapeDotNet
{
	public partial class frmTrangChu : Form
	{
		private int idTableClicked=-1;
		private string useName="Chưa đăng nhập";
		private string dataBaseName="Chưa kết nối";

		private double tienHang=-1;
		private double phiDichVu=0;
		private double giamGia=0;

		Form frmMatHang, 
			frmThanhToan,
			frmChuyenBan,
			frmGopBan,
			frmThongKe;

		public frmTrangChu()
		{
			InitializeComponent();
			infoSoftware();
		}

		private void infoSoftware()
		{
			dataBaseName = Sqlcommands.Instances.getConnection().Database.ToString();
			tLbCSDL.Text = "Csdl: " + dataBaseName;
			useName = AccountDAO.Instance.Usename;
			tLbUse.Text = "Tài khoản:  " + useName;
			//MessageBox.Show(Sqlcommands.Instances.getConnection().Database.ToString());
		}

		public bool CheckForm(string frm)
		{
			foreach (Form f in this.MdiChildren)
			{
				if (f.Name.Equals(frm))
				{
					return true;
				}

			}
			return false;
		}

		private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void tbtnQLBanHang_Click(object sender, EventArgs e)
		{
			frmMatHang = new frmDanhMucMatHang();
			frmMatHang.ShowDialog();
		}

		private void btnThanhToan_Click(object sender, EventArgs e)
		{

			if (frmTrangChuBUS.Instances.BtnClicked == null)
			{
				frmTrangChuBUS.Instances.messageThongBao("Vui lòng cần chọn bàn thanh toán");
				return;
			}

			int idTable = Convert.ToInt16(frmTrangChuBUS.Instances.BtnClicked.Name.ToString());

			if (!frmTrangChuBUS.Instances.checkerHasHoaDon(idTable))
			{
				frmTrangChuBUS.Instances.messageCanhBao("Bàn này chưa có hóa đơn để thanh toán !");
				return;
			}
			if(!frmTrangChuBUS.Instances.checkHasFood(idTable))
			{
				frmTrangChuBUS.Instances.messageCanhBao("Vui lòng thêm ít nhất một món ăn vào hóa đơn! ");
				return;
			}

			frmThanhToanBUS.Instances.TongTien = cacluterCost();
			frmThanhToan = new frmPayment();
			frmThanhToan.ShowDialog();

			if (frmThanhToan.IsDisposed)
			{
				showTableByidKhuVuc(tabControlKhuVuc, TableDAO.Instances.getIdKhuVucByIdTable(Convert.ToInt16(frmTrangChuBUS.Instances.BtnClicked.Name.ToString())));
			}

		}


		private void tBtnThoat_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void frmTrangChu_Load(object sender, EventArgs e)
		{
			connectData();
           
		}

		private void connectData()
		{
			frmTrangChuBUS.Instances.TableClick += tableClick;
			frmTrangChuBUS.Instances.BtnTableMouseRight = btnTableMouseRight;
			frmTrangChuBUS.Instances.BtnTableMouseRight2 = btnTableMouseRight2;

			showKhuVuc();					
			loadTreeView();
			frmTrangChuBUS.Instances.loadComboboxTable(cbbTableName);
		}

		private void loadTreeView()
		{			
			frmTrangChuBUS.Instances.loadTreeViewFood(twFood);
		}

		private void refreshKhuVuc()
		{
			showKhuVuc();
		}

		private void showKhuVuc()
		{
			frmTrangChuBUS.Instances.loadKhuVucAndTableFromDatabase(tabControlKhuVuc);
		}

		private void showTableByidKhuVuc(TabControl tabControl,int idKhuVuc)
		{
			frmTrangChuBUS.Instances.loadTableFromDatabase(tabControl,idKhuVuc);
		}

		private void tableClick(object sender, EventArgs e)
		{
			Button btn = sender as Button;
			
			showInfoTable(btn);
			showInfoBillofTable(btn);
			showCost(btn);
		}

		private void showCost(Button btn)
		{
			Bill bill = BillDAO.Instances.loadBillByIdTable(Convert.ToInt16(btn.Name.ToString()));
			if (bill == null)//Trường hợp bàn này không có bill
			{
				txtTienHang.Text = 0.ToString();
				txtTongTien.Text = 0.ToString();
				return;
			}
			tienHang = frmTrangChuBUS.Instances.getTotalCostBillByidBill(bill.IdBill);
			txtGiamGia.Value =0;
			txtPhiDichVu.Value = 0;
			txtTienHang.Text =frmTrangChuBUS.Instances.doiSoSangDonViTienTe(tienHang);
			frmTrangChuBUS.Instances.TienHang = Convert.ToDouble(tienHang.ToString());
			txtTongTien.Text = frmTrangChuBUS.Instances.doiSoSangDonViTienTe(cacluterCost());
			frmTrangChuBUS.Instances.TongTien = Convert.ToDouble(cacluterCost().ToString());
		}

		private double cacluterCost()
		{
			return (tienHang + Convert.ToDouble(txtPhiDichVu.Value.ToString())) -
				((tienHang + Convert.ToDouble(txtPhiDichVu.Value.ToString()))
				* Convert.ToDouble(txtGiamGia.Value.ToString()) / 100);
		}

		private void showInfoTable(Button btn)
		{
			cbbTableName.SelectedValue = Convert.ToInt32(btn.Name.ToString());
			idTableClicked = Convert.ToInt32(btn.Name.ToString());
		}

		private void showInfoBillofTable(Button btn)
		{
			Bill bill = BillDAO.Instances.loadBillByIdTable(Convert.ToInt16(btn.Name.ToString()));
			if (bill==null)//Trường hợp bàn này không có bill
			{
				lvBillInfo.Items.Clear();
				txtTimeOpenTable.Clear();
				return;
			}
			frmTrangChuBUS.Instances.loadLvBillInfoByIdBill(bill.IdBill, lvBillInfo);
			txtTimeOpenTable.Text = bill.BillDataCheckIn.ToString();
		}

		private void twFood_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.Tag == null)
				return;
			frmTrangChuBUS.Instances.loadListViewByIdCategoryFood((int)e.Node.Tag,lvFood);
		}

		private void lvFood_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			them1Item();
		}

		private void them1Item()
		{
			Button btn = frmTrangChuBUS.Instances.BtnClicked;



			if (!checkTableClickIsNull(frmTrangChuBUS.Instances.BtnClicked))
			{
				MessageBox.Show("Vui lòng chọn bàn cần thêm món ");
				return;
			}

			int idTable = Convert.ToInt16(frmTrangChuBUS.Instances.BtnClicked.Name.ToString());

			if (!frmTrangChuBUS.Instances.checkerHasHoaDon(idTable))
			{
				//frmTrangChuBUS.Instances.messageCanhBao("Bàn chưa mở vui lòng mở bàn !");
				try
				{
					if (MessageBox.Show("Bàn này chưa mở bạn có muốn mở bàn này và tiếp tục thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						frmTrangChuBUS.Instances.insertBillToTableByIdTable(idTable);
						//showKhuVuc();//Hiển thị không đẹp mắt khi dùng hàm này vì phải load cả khu vực và table
						showTableByidKhuVuc(tabControlKhuVuc, TableDAO.Instances.getIdKhuVucByIdTable(idTable));//Hiển thị đẹp mắt khi dùng hàm này vì dữ liệu chỉ phải load mỗi table

						//dateTimePicker1.Select();dateTimePicker1.Focus();
					}
					
				}
				catch (Exception)
				{
					return;
				}
				//return;
			}
			//if (!frmTrangChuBUS.Instances.checkHasFood(idTable))
			//{
			//	frmTrangChuBUS.Instances.messageCanhBao("Vui lòng thêm ít nhất một món ăn vào hóa đơn! ");
			//	return;
			//}

			if (lvFood.SelectedItems.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn một món cần thêm", "Cảnh báo");
				return;
			}
			frmTrangChuBUS.Instances.insertFoodToBIllInfo(Convert.ToInt32(lvFood.SelectedItems[0].Tag.ToString()),
				BillDAO.Instances.getIdBillByIdTable(Convert.ToInt16(btn.Name.ToString())));
			showInfoBillofTable(btn);
			showCost(btn);
		}

		private void themItemBySoLuong(int soLuong)
		{
			Button btn = frmTrangChuBUS.Instances.BtnClicked;

			if (!checkTableClickIsNull(frmTrangChuBUS.Instances.BtnClicked))
			{
				MessageBox.Show("Vui lòng chọn bàn cần thêm món ");
				return;
			}

			if (lvFood.SelectedItems.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn một món cần thêm", "Cảnh báo");
				return;
			}
			frmTrangChuBUS.Instances.insertFoodToBillInfoBySoluong(Convert.ToInt32(lvFood.SelectedItems[0].Tag.ToString()),
				BillDAO.Instances.getIdBillByIdTable(Convert.ToInt16(btn.Name.ToString())),soLuong);
			showInfoBillofTable(btn);
			showCost(btn);
		}

		private void xoaItemBySoLuong(int soLuong)
		{
			Button btn = frmTrangChuBUS.Instances.BtnClicked;

			if (!checkTableClickIsNull(frmTrangChuBUS.Instances.BtnClicked))
			{
				frmTrangChuBUS.Instances.messageThongBao("Vui lòng chon một bàn ");
				return;
			}

			if (lvBillInfo.SelectedItems.Count == 0)
			{
				frmTrangChuBUS.Instances.messageThongBao("Vui lòng chọn món trên hóa đơn cần xóa");
				return;
			}
			frmTrangChuBUS.Instances.insertFoodToBillInfoBySoluong(Convert.ToInt32(lvBillInfo.SelectedItems[0].Name.ToString()),
				BillDAO.Instances.getIdBillByIdTable(Convert.ToInt16(btn.Name.ToString())), soLuong);
			showInfoBillofTable(btn);
			showCost(btn);
		}

		private bool checkTableClickIsNull(Button btnClicker)
		{
			if (btnClicker != null)
			{
				return true;
			}

			return false;
		}

		private void btnOpenTable_Click(object sender, EventArgs e)
		{
			try
			{
				int idTable = -1;
				idTable = Convert.ToInt32(cbbTableName.SelectedValue.ToString());
				frmTrangChuBUS.Instances.insertBillToTableByIdTable(idTable);
				//showKhuVuc();//Hiển thị không đẹp mắt khi dùng hàm này vì phải load cả khu vực và table
				showTableByidKhuVuc(tabControlKhuVuc, TableDAO.Instances.getIdKhuVucByIdTable(idTable));//Hiển thị đẹp mắt khi dùng hàm này vì dữ liệu chỉ phải load mỗi table

				//dateTimePicker1.Select();dateTimePicker1.Focus();
			}
			catch (Exception)
			{

			}
			
		}

		private void contextBtnDeleteTable_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Bạn có muốn đóng bàn này ?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{			
				int idTable = -1;
				idTable = Convert.ToInt32(cbbTableName.SelectedValue.ToString());
				frmTrangChuBUS.Instances.deleteBillByIdTable(idTable);
				//loadData();//tương tự như hàm mở bàn
				showTableByidKhuVuc(tabControlKhuVuc, TableDAO.Instances.getIdKhuVucByIdTable(idTable));//Hiển thị đẹp mắt khi dùng hàm này vì dữ liệu chỉ phải load mỗi table
			}
		}

		private void btnDeleteFood_Click(object sender, EventArgs e)
		{
			if (lvBillInfo.SelectedItems.Count==0)
			{
				MessageBox.Show("Vui lòng chọn một item trên hóa đơn ","Cảnh báo");
				return;
			}

			if (MessageBox.Show("Bạn có muốn xóa món này ra khỏi hóa đơn ? ","Cảnh báo",MessageBoxButtons.YesNo)==DialogResult.Yes)
			{
				int idBillInfo = -1;				
				idBillInfo= Convert.ToInt32(lvBillInfo.SelectedItems[0].Tag.ToString());				
				frmTrangChuBUS.Instances.deleteBillInfoByBillInfo(idBillInfo);
				showInfoBillofTable(frmTrangChuBUS.Instances.BtnClicked);//Hiển thị đẹp mắt khi dùng hàm này vì dữ liệu chỉ phải load mỗi table
				showCost(frmTrangChuBUS.Instances.BtnClicked);
			}
		}

		private void btnThongKe_Click(object sender, EventArgs e)
		{
			//MessageBox.Show(frmTrangChuBUS.Instances.BtnClicked.Name);
			
		}

		private void txtPhiDichVu_ValueChanged(object sender, EventArgs e)
		{
			frmTrangChuBUS.Instances.PhiDichVu = Convert.ToDouble(txtPhiDichVu.Value);
			txtTongTien.Text = frmTrangChuBUS.Instances.doiSoSangDonViTienTe(cacluterCost());
			frmTrangChuBUS.Instances.TongTien =Convert.ToDouble(cacluterCost().ToString());
		}

		private void txtGiamGia_ValueChanged(object sender, EventArgs e)
		{
			frmTrangChuBUS.Instances.GiamGia = Convert.ToDouble(txtGiamGia.Value);
			txtTongTien.Text =frmTrangChuBUS.Instances.doiSoSangDonViTienTe(cacluterCost());
			frmTrangChuBUS.Instances.TongTien = Convert.ToDouble(cacluterCost().ToString());
		}

		private void btnGopBan_Click(object sender, EventArgs e)
		{
			if (frmTrangChuBUS.Instances.BtnClicked == null)
			{
				MessageBox.Show("Vui long chon ban can chuyen !");
				return;
			}

			int idTable = Convert.ToInt16(frmTrangChuBUS.Instances.BtnClicked.Name.ToString());

			if (!frmTrangChuBUS.Instances.checkerHasHoaDon(idTable))
			{
				frmTrangChuBUS.Instances.messageCanhBao("Bàn này chưa có hóa đơn để thanh toán !");
				return;
			}
			if (!frmTrangChuBUS.Instances.checkHasFood(idTable))
			{
				frmTrangChuBUS.Instances.messageCanhBao("Vui lòng thêm ít nhất một món ăn vào hóa đơn! ");
				return;
			}


			frmGopBan = new frmGopBan();
			frmGopBan.ShowDialog();

			if (frmGopBan.IsDisposed)
			{
				showTableByidKhuVuc(tabControlKhuVuc, TableDAO.Instances.getIdKhuVucByIdTable(Convert.ToInt16(frmTrangChuBUS.Instances.BtnClicked.Name.ToString())));
			}
		}

		private void showTableEmpty()
		{
			
		}

		private void txtSearchFood_TextChanged(object sender, EventArgs e)
		{
			frmTrangChuBUS.Instances.showFoodSearch(txtSearchFood.Text.ToString(),lvFood);
		}

        private void lvBillInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

		private void btnChuyenBan_Click(object sender, EventArgs e)
		{
			if (frmTrangChuBUS.Instances.BtnClicked == null)
			{
				MessageBox.Show("Vui long chon ban can chuyen !");
				return;
			}

			int idTable = Convert.ToInt16(frmTrangChuBUS.Instances.BtnClicked.Name.ToString());

			if (!frmTrangChuBUS.Instances.checkerHasHoaDon(idTable))
			{
				frmTrangChuBUS.Instances.messageCanhBao("Bàn này chưa có hóa đơn nào !");
				return;
			}
			if (!frmTrangChuBUS.Instances.checkHasFood(idTable))
			{
				frmTrangChuBUS.Instances.messageCanhBao("Vui lòng thêm ít nhất một món ăn vào hóa đơn! ");
				return;
			}

			
			frmChuyenBan = new frmChuyenBan();
			frmChuyenBan.ShowDialog();

			if (frmChuyenBan.IsDisposed)
			{
				showTableByidKhuVuc(tabControlKhuVuc,TableDAO.Instances.getIdKhuVucByIdTable(Convert.ToInt16(frmTrangChuBUS.Instances.BtnClicked.Name.ToString())));
			}
		}

		private void btnThem1Item_Click(object sender, EventArgs e)
		{
			them1Item();
		}

		private void btnGiam1Item_Click(object sender, EventArgs e)
		{
			xoaItemBySoLuong(-1);
		}

		private void btnThem1Item_Click_1(object sender, EventArgs e)
		{
			try
			{
				themItemBySoLuong(Convert.ToInt16(cbbSoLuong.SelectedItem.ToString()));
			}
			catch (Exception)
			{
				frmTrangChuBUS.Instances.messageCanhBao("Chọn số lượng cần thay đổi !");
			}
		}

		private void btnGiam1Item_Click_1(object sender, EventArgs e)
		{
			try
			{
				xoaItemBySoLuong(-Convert.ToInt16(cbbSoLuong.SelectedItem.ToString()));
			}catch(Exception)
			{
				frmTrangChuBUS.Instances.messageCanhBao("Chọn số lượng cần thay đổi !");
			}
		}

		private void frmTrangChu_FormClosed_1(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

        private void tabControlKhuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void danhMụcNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    if(!CheckForm("frmNhaCungCap"))
            //    {
            //        frmNhaCungCap nhacungcap = new frmNhaCungCap();
            //        nhacungcap.MdiParent = this;
            //       nhacungcap.Show();
            //   }
            frmNhaCungCap nhacungcap = new frmNhaCungCap();
            nhacungcap.ShowDialog();
        }

        private void khoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

		private void txtTimeOpenTable_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmTrangChu_FormClosed(object sender, FormClosedEventArgs e)
        {

            Account.ActiveForm.Show();
        }

		private void tBatnThongKeDoAnUong_Click(object sender, EventArgs e)
		{
			frmThongKe = new frmThongKeMatHang();
			frmThongKe.ShowDialog();
		}
	}
}
