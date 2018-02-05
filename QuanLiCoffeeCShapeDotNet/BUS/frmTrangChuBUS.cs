using QuanLiCoffeeCShapeDotNet.DAO;
using QuanLiCoffeeCShapeDotNet.DTO;
using System;
using System.Collections.Generic;
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

		public void loadTreeViewFood(ref TreeView twFood)
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

		public void loadKhuVuc(ref TabControl tabControlKhuVuc,ref EventHandler btnClick)
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
						Tag = listTable[j].IdTable,
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

		public void loadListViewByIdCategoryFood(int idCategory,ref ListView lvFood)
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

		public void loadComboboxTable(ref ComboBox cbbTable)
		{
			List<Table> listTable = TableDAO.Instances.loadTable();
			foreach (Table items in listTable)
			{
				cbbTable.Items.Add(items.TableName);
			}
		}

		public void loadLvBillInfoByIdBill(int idBill,ref ListView lvBillInfo)
		{
			lvBillInfo.Items.Clear();
			List<BillInfo> listBillInfo = BillInfoDAO.Instances.loadBillInfoByIdBill(idBill);
			for (int i = 0; i < listBillInfo.Count; i++)
			{
				List<Food> listFood = FoodDAO.Instances.loadFoodByIdFood(listBillInfo[i].IdFood);
				ListViewItem lv = new ListViewItem(listFood[0].FoodName);
				lv.SubItems.Add(listFood[0].DonViTinh);
				lv.SubItems.Add(listFood[0].Gia.ToString());
				lv.SubItems.Add(listBillInfo[i].BillInfoCount.ToString());
				lv.SubItems.Add("5 triệu");
				lv.Tag = "ni";
				lvBillInfo.Items.Add(lv);
			}

		}

		public void insertFoodToBIllInfo(int idFood,int idBill)
		{
			BillInfoDAO.Instances.insertBillinfo(idFood,idBill);
		}

		public void insertBillToTableByIdTable(int idTable)
		{
			BillDAO.Instances.insertBillToTableByIdTable(idTable);
		}

		
	}
}
