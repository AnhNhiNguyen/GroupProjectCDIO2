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

		private double tienHang=0;
		private double tongTien=0;

		Form frmMatHang;
		Form frmThanhToan;

		public frmTrangChu()
		{
			InitializeComponent();
			infoSoftware();
		}

		private void infoSoftware()
		{
			dataBaseName = Sqlcommands.Instances.getConnection().Database.ToString();
			tLbCSDL.Text = "Csdl: " + dataBaseName;
			tLbUse.Text = "Tài khoản:  " + useName;
			//MessageBox.Show(Sqlcommands.Instances.getConnection().Database.ToString());
		}

		public Boolean CheckForm(string frm)
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
			frmThanhToan = new frmPayment();
			frmThanhToan.ShowDialog();
		}

		private void tBtnThoat_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void frmTrangChu_Load(object sender, EventArgs e)
		{
			loadData();
			
		}

		private void loadData()
		{
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


		private void btnClick(object sender, EventArgs e)
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
			txtGiamGia.Value = 0;
			txtPhiDichVu.Value = 0;
			txtTienHang.Text = tienHang.ToString();	
			txtTongTien.Text = cacluterCost().ToString();
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
			if (lvFood.SelectedItems.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn một món cần thêm","Cảnh báo");
				return;
			}
			frmTrangChuBUS.Instances.insertFoodToBIllInfo(Convert.ToInt32(lvFood.SelectedItems[0].Tag.ToString()),
				BillDAO.Instances.getIdBillByIdTable(idTableClicked));
			MessageBox.Show(idTableClicked.ToString());
		}

		

		private void btnOpenTable_Click(object sender, EventArgs e)
		{
			int idTable = -1;
			idTable = Convert.ToInt32(cbbTableName.SelectedValue.ToString());
			frmTrangChuBUS.Instances.insertBillToTableByIdTable(idTable);
			//showKhuVuc();//Hiển thị không đẹp mắt khi dùng hàm này vì phải load cả khu vực và table
			showTableByidKhuVuc(tabControlKhuVuc,TableDAO.Instances.getIdKhuVucByIdTable(idTable));//Hiển thị đẹp mắt khi dùng hàm này vì dữ liệu chỉ phải load mỗi table
			

			//dateTimePicker1.Select();dateTimePicker1.Focus();
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
			}
		}

		private void btnThongKe_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Click roi");
		}

		private void txtPhiDichVu_ValueChanged(object sender, EventArgs e)
		{
			txtTongTien.Text = cacluterCost().ToString();
		}

		private void txtGiamGia_ValueChanged(object sender, EventArgs e)
		{
			txtTongTien.Text = cacluterCost().ToString();
		}

		private void btnChuyenBan_Click(object sender, EventArgs e)
		{
			
		}
	}
}
