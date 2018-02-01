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

namespace QuanLiCoffeeCShapeDotNet
{
	public partial class frmTrangChu : Form
	{

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
			loadKhuVuc();
			loadTreeViewFood();
			//loadListViewByIdCategoryFood();
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
						Width = 128,
						Height = 150,

						TextAlign = ContentAlignment.BottomCenter,
						ImageAlign = ContentAlignment.TopCenter,
						TextImageRelation = TextImageRelation.Overlay,

						Location = new Point(btnBegin.Location.X + btnBegin.Width,
						btnBegin.Location.Y),


					};
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
						btnBegin.Location = new Point(0, btnBegin.Location.Y + btnBegin.Height);

					}


				}

				tabControlKhuVuc.Controls.Add(tab);
			}
		}

		private void btnClick(object sender, EventArgs e)
		{
			Button btn = sender as Button;

			//MessageBox.Show(btn.Text);

			txtNameTable.Text = btn.Text.ToString();

			List<Bill> list =BillDAO.Instances.loadBillByIdTable(2);
			//MessageBox.Show(list[0].IdBill.ToString());
			loadLvBillInfoByIdBill(list[0].IdBill);
		}

		public void loadTreeViewFood()
		{
			List<CategoryFood> listCFood = CategoryFoodDAO.Instances.loadCategory();
			//twFood.Nodes.Add("Tất cả");
			for (int i = 0; i < listCFood.Count; i++)
			{
				twFood.Nodes.Add(listCFood[i].CategoryName);
				twFood.Nodes[i].Tag = listCFood[i].IdCategory;

				//List<Food> listFood = FoodDAO.Instances.loadFoodByIdCategoryFood(listCFood[i].IdCategory);
				//for (int j = 0; j <listFood.Count; j++)
				//{
				//	twFood.Nodes[i].Nodes.Add(listFood[j].FoodName);
				//}


			}
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
			loadListViewByIdCategoryFood((int)e.Node.Tag);
		}

		private void loadListView1()
		{
			lvFood.GridLines = true;
			//listView1.View = View.Details;

			lvFood.Columns.Add("Mặt hàng",75);
			lvFood.Columns.Add("Đơn vị tính", 75);
			lvFood.Columns.Add("Đơn giá", 75);

			ListViewItem lv = new ListViewItem("fdsfsdf");
			lv.SubItems.Add("fsdf");
			lv.SubItems.Add("fsdf");
			lv.Tag = "6";

			lvFood.Items.Add(lv);

			ListViewItem lv2 = new ListViewItem("fdsfsdf");
			//lv2.SubItems.Add("fsdf");
			//lv2.SubItems.Add("f");

			lv2.Tag="5";
			lvFood.Items.Add(lv2);
			

		}

		private void loadListViewByIdCategoryFood(int idCategory)
		{
			lvFood.Items.Clear();
			lvFood.GridLines = true;

			List<Food> listFood = FoodDAO.Instances.loadFoodByIdCategoryFood(idCategory);
			for(int i = 0; i < listFood.Count; i++)
			{
				ListViewItem lv = new ListViewItem(listFood[i].FoodName);
				lv.SubItems.Add(listFood[i].DonViTinh);
				lv.SubItems.Add(listFood[i].Gia.ToString());

				lv.Tag = listFood[i].IdFood.ToString();
				lvFood.Items.Add(lv);
			}
		}

		private void loadLvBillInfoByIdBill(int idBill)
		{
			lvBillInfo.Items.Clear();
			List<BillInfo> listBillInfo = BillInfoDAO.Instances.loadBillInfoByIdBill(idBill);
			for(int i = 0; i < listBillInfo.Count; i++)
			{
				List<Food> listFood=FoodDAO.Instances.loadFoodByIdFood(listBillInfo[i].IdFood);
				ListViewItem lv = new ListViewItem(listFood[0].FoodName);
				lv.SubItems.Add(listFood[0].DonViTinh);
				lv.SubItems.Add(listFood[0].Gia.ToString());
				lv.SubItems.Add( listBillInfo[i].BillInfoCount.ToString());
				lv.SubItems.Add("5 triệu");
				lv.Tag = "ni";
				lvBillInfo.Items.Add(lv);
			}
			
		}

		private void listView1_MouseClick(object sender, MouseEventArgs e)
		{
			//MessageBox.Show(listView1.SelectedIndices[0].ToString());
			//MessageBox.Show(lvFood.SelectedItems[0].Tag.ToString());
		}

		private void lvFood_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			MessageBox.Show(lvFood.SelectedItems[0].Tag.ToString());

		}
	}
}
