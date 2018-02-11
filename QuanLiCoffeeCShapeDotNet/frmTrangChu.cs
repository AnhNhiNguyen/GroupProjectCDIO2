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
			loadKhuVuc();
			//loadTreeViewFood();
			//loadListViewByIdCategoryFood();

			//frmTrangChuBUS.Instances.loadKhuVuc(ref tabControlKhuVuc);
			loadTreeView();
			frmTrangChuBUS.Instances.loadComboboxTable(cbbTableName);
			
		}

		private void loadTreeView()
		{
			twFood.Nodes.Clear();
			frmTrangChuBUS.Instances.loadTreeViewFood(twFood);
		}

		private void loadKhuVuc()
		{
			tabControlKhuVuc.Controls.Clear();
			List<KhuVuc> list = KhuVucDAO.Instances.loadKhuVuc();
			for (int i = 0; i < list.Count; i++)
			{
				TabPage tab = new TabPage
				{
					AutoScroll = true,
				};
				tab.UseVisualStyleBackColor = true;
				tab.Text = list[i].KhuVucName;

				//Add ban vao tab
				List<Table> listTable = TableDAO.Instances.loadTableByIdKhuVuc(list[i].IdKhuVuc);
				Button btnBegin = new Button
				{
					Width = 0,
					Height = 0,
					Location = new Point(0, 0)
				};
				for (int j = 0; j < listTable.Count; j++)
				{
					Button btn = new Button
					{
						//Text = listTable[j].TableName + Environment.NewLine +
						//listTable[j].TableStatus,
						Text = listTable[j].TableName,
						Tag = listTable[j].IdTable,
						Width = 128,
						Height = 150,

						TextAlign = ContentAlignment.BottomCenter,
						ImageAlign = ContentAlignment.TopCenter,
						TextImageRelation = TextImageRelation.Overlay,

						Location = new Point(btnBegin.Location.X + btnBegin.Width + 5,
						btnBegin.Location.Y),
					};
					btn.Cursor = Cursors.Hand;
					btn.FlatStyle = FlatStyle.Popup;
					btn.ImageAlign = ContentAlignment.BottomCenter; 
					btn.Click += btnClick;
					btn.MouseDown += btnClick;
					
					switch (listTable[j].TableStatus)
					{
						case 1:
							{
								btn.Image = global::QuanLiCoffeeCShapeDotNet.Properties.Resources.coffe;
								btn.ContextMenuStrip = btnTableMouseRight;								
								break;
							}
						default:
							{
								btn.Image = global::QuanLiCoffeeCShapeDotNet.Properties.Resources.coffeNull;
								btn.ContextMenuStrip = btnTableNullMouseRight;
								break;
							}
					}

					tab.Controls.Add(btn);

					btnBegin = btn;
					if (j % 3 == 0 && j != 0)
					{
						btnBegin.Location = new Point(5, btnBegin.Location.Y + btnBegin.Height+5);
					}
				}
				tabControlKhuVuc.Controls.Add(tab);
			}
		}

		private void btnClick(object sender, EventArgs e)
		{
			Button btn = sender as Button;

			setInfoTable(btn);
			setInfoBillofTable(btn);
			setCost(btn);
		}

		private void setCost(Button btn)
		{
			Bill bill = BillDAO.Instances.loadBillByIdTable(Convert.ToInt16(btn.Tag.ToString()));
			if (bill == null)//Trường hợp bàn này không có bill
			{
				txtTienHang.Text = 0.ToString();
				txtTongTien.Text = 0.ToString();
				return;
			}
			txtTienHang.Text = frmTrangChuBUS.Instances.getTotalCostBillByidBill(bill.IdBill).ToString();
	
			txtTongTien.Text = txtTienHang.Text;
		}

		private void setInfoTable(Button btn)
		{
			cbbTableName.SelectedValue = Convert.ToInt32(btn.Tag.ToString());
			idTableClicked = Convert.ToInt32(btn.Tag.ToString());
		}

		private void setInfoBillofTable(Button btn)
		{
			Bill bill = BillDAO.Instances.loadBillByIdTable(Convert.ToInt16(btn.Tag.ToString()));
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
			//MessageBox.Show(twFood.Nodes[].ToString());
			//MessageBox.Show(e.ToString());
			//MessageBox.Show(e.Node.Tag.ToString());
			if (e.Node.Tag == null)
				return;

			//DataTable data = FoodDAO.Instances.treeViewClickByIdCategoryFood((int)e.Node.Tag);
			//dgvListFood.DataSource = data;

			//List<Food> listFood = FoodDAO.Instances.loadFoodByIdCategoryFood(listCFood[i].IdCategory);
			frmTrangChuBUS.Instances.loadListViewByIdCategoryFood((int)e.Node.Tag,lvFood);
		}

		private void listView1_MouseClick(object sender, MouseEventArgs e)
		{
			//MessageBox.Show(listView1.SelectedIndices[0].ToString());
			//MessageBox.Show(lvFood.SelectedItems[0].Tag.ToString());
		}

		private void lvFood_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			//MessageBox.Show(lvFood.SelectedItems[0].Tag.ToString());
			if (lvFood.SelectedItems.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn một món cần thêm","Cảnh báo");
				return;
			}
			frmTrangChuBUS.Instances.insertFoodToBIllInfo(Convert.ToInt32(lvFood.SelectedItems[0].Tag.ToString()),
				BillDAO.Instances.getIdBillByIdTable(idTableClicked));
			//loadData();
			//selectTableByidTable(idTableClicked).Select();
			MessageBox.Show(idTableClicked.ToString());
		}

		private void btnOpenTable_Click(object sender, EventArgs e)
		{
			int idTable = -1;
			idTable = Convert.ToInt32(cbbTableName.SelectedValue.ToString());
			frmTrangChuBUS.Instances.insertBillToTableByIdTable(idTable                              );
			loadKhuVuc();
			//dateTimePicker1.Select();dateTimePicker1.Focus();
		}

		private void contextBtnDeleteTable_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Bạn có muốn đóng bàn này ?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{			
				int idTable = -1;
				idTable = Convert.ToInt32(cbbTableName.SelectedValue.ToString());
				frmTrangChuBUS.Instances.deleteBillByIdTable(idTable);
				loadData();
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
	}
}
