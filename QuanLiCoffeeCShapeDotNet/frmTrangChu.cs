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
		Form frmMatHang;
		Form frmThanhToan;
		public frmTrangChu()
		{
			InitializeComponent();
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
			frmTrangChuBUS.Instances.loadTreeViewFood(ref twFood);
			//frmTrangChuBUS.Instances.loadComboboxTable(ref cbbTableName);
			Sqlcommands.Instances.load_comboBox("SELECT * FROM PDT_TABLE",cbbTableName);
		}

		private void loadKhuVuc()
		{
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
						Tag=listTable[j].IdTable,
						Width = 128,
						Height = 150,

						TextAlign = ContentAlignment.BottomCenter,
						ImageAlign = ContentAlignment.TopCenter,
						TextImageRelation = TextImageRelation.Overlay,

						Location = new Point(btnBegin.Location.X + btnBegin.Width+5,
						btnBegin.Location.Y),
						


					};
					btn.ImageAlign = ContentAlignment.BottomCenter; 
					btn.Click += btnClick;
					switch (listTable[j].TableStatus)
					{
						case 1:
							{
								btn.Image = global::QuanLiCoffeeCShapeDotNet.Properties.Resources.coffe;
								break;
							}
						default:
							{
								btn.Image = global::QuanLiCoffeeCShapeDotNet.Properties.Resources.coffeNull;
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

			//MessageBox.Show(btn.Text);

			cbbTableName.Text = btn.Text.ToString();
			

			//List<Bill> list =BillDAO.Instances.loadBillByIdTable(2);
			List<Bill> list = BillDAO.Instances.loadBillByIdTable(Convert.ToInt16(btn.Tag.ToString()));
			//Đang có lỗi chỗ này
			//MessageBox.Show(list[0].IdBill.ToString());
			if (list.Count == 0)
			{
				lvBillInfo.Items.Clear();
				txtTimeOpenTable.Clear();
				return;
			}
			frmTrangChuBUS.Instances.loadLvBillInfoByIdBill(list[0].IdBill,ref lvBillInfo);
			//MessageBox.Show(btn.Tag.ToString());
			idTableClicked =Convert.ToInt32(btn.Tag.ToString());
			txtTimeOpenTable.Text = list[0].BillDataCheckIn.ToString();
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
			frmTrangChuBUS.Instances.loadListViewByIdCategoryFood((int)e.Node.Tag,ref lvFood);
		}

		private void listView1_MouseClick(object sender, MouseEventArgs e)
		{
			//MessageBox.Show(listView1.SelectedIndices[0].ToString());
			//MessageBox.Show(lvFood.SelectedItems[0].Tag.ToString());
		}

		private void lvFood_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			//MessageBox.Show(lvFood.SelectedItems[0].Tag.ToString());

			frmTrangChuBUS.Instances.insertFoodToBIllInfo(Convert.ToInt32(lvFood.SelectedItems[0].Tag.ToString()),
				BillDAO.Instances.getIdBillByIdTable(idTableClicked));
			loadData();
			//selectTableByidTable(idTableClicked).Select();
		}

		private void btnOpenTable_Click(object sender, EventArgs e)
		{
			frmTrangChuBUS.Instances.insertBillToTableByIdTable(2);

		}

		private Button selectTableByidTable(int idTable)
		{
			foreach (Button items in tabControlKhuVuc.Controls)
			{
				if (Convert.ToInt32(items.Tag.ToString()) == idTable)
					return items;
			}
			return null;
		}
	}
}
