using QuanLiCoffeeCShapeDotNet.DAO;
using QuanLiCoffeeCShapeDotNet.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCoffeeCShapeDotNet.BUS
{
	public class frmTrangChuBUS
	{
		private static frmTrangChuBUS instances;

		public static frmTrangChuBUS Instances
		{
			get
			{
				if (instances == null) instances = new frmTrangChuBUS(); 
				return frmTrangChuBUS.instances;
			}

			set
			{
				frmTrangChuBUS.instances = value;
			}
		}

		public Button BtnClicked
		{
			get
			{
				return btnClicked;
			}

			set
			{
				btnClicked = value;
			}
		}

		private event EventHandler tableClick;
		public event EventHandler TableClick
		{
			add
			{
				tableClick += value;
			}
			remove
			{
				tableClick -= value;
			}
		}

		private Button btnClicked;

		public void loadTreeViewFood(TreeView twFood)
		{
			twFood.Nodes.Clear();
			List<CategoryFood> listCFood = CategoryFoodDAO.Instances.loadCategory();
			for (int i = 0; i < listCFood.Count; i++)
			{
				twFood.Nodes.Add(listCFood[i].CategoryName);
				twFood.Nodes[i].Tag = listCFood[i].IdCategory;

			}
		}

		public void loadKhuVucAndTableFromDatabase(TabControl tabControlKhuVuc)
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
				tab.Name = list[i].IdKhuVuc.ToString();

				//showTableByidKhuVucc(tab, list[i].IdKhuVuc);
				tabControlKhuVuc.Controls.Add(tab);
				loadTableFromDatabase(tabControlKhuVuc, list[i].IdKhuVuc);
			}
		}

		public void loadTableFromDatabase(TabControl tabControl,int idKhuVuc)
		{
			tabControl.TabPages[idKhuVuc.ToString()].Controls.Clear();

			//Add ban vao tab
			List<Table> listTable = TableDAO.Instances.loadTableByIdKhuVuc(idKhuVuc);
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
					Name = listTable[j].IdTable.ToString(),
					//Tag = listTable[j].IdTable,
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
							//btn.ContextMenuStrip = btnTableMouseRight;
							break;
						}
					default:
						{
							btn.Image = global::QuanLiCoffeeCShapeDotNet.Properties.Resources.coffeNull;
							//btn.ContextMenuStrip = btnTableMouseRight2;
							break;
						}
				}

				tabControl.TabPages[idKhuVuc.ToString()].Controls.Add(btn);

				btnBegin = btn;
				if (j % 3 == 0 && j != 0)
				{
					btnBegin.Location = new Point(5, btnBegin.Location.Y + btnBegin.Height + 5);
				}
			}
		}

		private void btnClick(object sender, EventArgs e)
		{
			Button btn = sender as Button;
			btnClicked = sender as Button;
			//Truyền dữ liệu vào event trên form kế
			if (tableClick != null)
				tableClick(sender,e);

		}

		/// <summary>
		/// Hàm chưa được tối ưu
		/// </summary>
		/// <param name="tab"></param>
		/// <param name="idKhuVuc"></param>
		private void showTableByidKhuVucc(TabPage tab, int idKhuVuc)
		{
			//Add ban vao tab
			List<Table> listTable = TableDAO.Instances.loadTableByIdKhuVuc(idKhuVuc);
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

				//switch (listTable[j].TableStatus)
				//{
				//	case 1:
				//		{
				//			btn.Image = global::QuanLiCoffeeCShapeDotNet.Properties.Resources.coffe;
				//			btn.ContextMenuStrip = btnTableMouseRight;
				//			break;
				//		}
				//	default:
				//		{
				//			btn.Image = global::QuanLiCoffeeCShapeDotNet.Properties.Resources.coffeNull;
				//			btn.ContextMenuStrip = btnTableMouseRight2;
				//			break;
				//		}
				//}

				tab.Controls.Add(btn);

				btnBegin = btn;
				if (j % 3 == 0 && j != 0)
				{
					btnBegin.Location = new Point(5, btnBegin.Location.Y + btnBegin.Height + 5);
				}
			}
		}

		public void loadListViewByIdCategoryFood(int idCategory,ListView lvFood)
		{
			lvFood.Items.Clear();
			lvFood.GridLines = true;

			List<Food> listFood = FoodDAO.Instances.loadFoodByIdCategoryFood(idCategory);
			for (int i = 0; i < listFood.Count; i++)
			{
				ListViewItem lv = new ListViewItem(listFood[i].FoodName);
				lv.SubItems.Add(listFood[i].DonViTinh);
				lv.SubItems.Add(listFood[i].Gia.ToString());

				lv.Tag = listFood[i].IdFood.ToString();
				lvFood.Items.Add(lv);
			}
		}

		public void loadComboboxTable(ComboBox cbbTable)
		{
			DataTable data = new DataTable();
			data = TableDAO.Instances.loadTableToCbb();
			cbbTable.DataSource = data;
			cbbTable.DisplayMember = data.Columns[1].ToString();
			cbbTable.ValueMember = data.Columns[0].ToString();
		}

		public void loadLvBillInfoByIdBill(int idBill,ListView lvBillInfo)
		{
			lvBillInfo.Items.Clear();
			List<BillInfo> listBillInfo = BillInfoDAO.Instances.loadBillInfoByIdBill(idBill);
			for (int i = 0; i < listBillInfo.Count; i++)
			{
				Food food = FoodDAO.Instances.loadFoodByIdFood(listBillInfo[i].IdFood);
				ListViewItem lv = new ListViewItem(food.FoodName);
				lv.SubItems.Add(food.DonViTinh);
				lv.SubItems.Add(food.Gia.ToString());

				int soLuong = listBillInfo[i].BillInfoCount;
				lv.SubItems.Add(soLuong.ToString());

				double thanhTien = food.Gia * soLuong;
				lv.SubItems.Add(thanhTien.ToString());
				lv.Tag = listBillInfo[i].IdBillInfo;
				lvBillInfo.Items.Add(lv);
			}

		}

		public double getTotalCostBillByidBill(int idBill)
		{
			double totalCost = 0;

			List<BillInfo> listBill = BillInfoDAO.Instances.loadBillInfoByIdBill(idBill);
			for(int i = 0; i < listBill.Count; i++)
			{
				Food food = FoodDAO.Instances.loadFoodByIdFood(listBill[i].IdFood);
				totalCost = totalCost + listBill[i].BillInfoCount * food.Gia;
			}
			return totalCost;
		}

		public void insertFoodToBIllInfo(int idFood,int idBill)
		{
			BillInfoDAO.Instances.insertBillinfo(idFood,idBill);
		}

		public void insertBillToTableByIdTable(int idTable)
		{
			BillDAO.Instances.insertBillToTableByIdTable(idTable);
		}

		public void deleteBillByIdTable(int idTable)
		{
			BillDAO.Instances.deleteBillByIdTable(idTable);
		}

		public void deleteBillInfoByBillInfo(int idBillInfo)
		{
			BillInfoDAO.Instances.deleteBillinfoByidBillInfo(idBillInfo);
		}
	}
}
