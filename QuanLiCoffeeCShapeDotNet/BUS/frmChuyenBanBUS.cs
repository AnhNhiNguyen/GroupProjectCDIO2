using QuanLiCoffeeCShapeDotNet.BUS;
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
	public class frmChuyenBanBUS
	{
		private static frmChuyenBanBUS instances;

		public static frmChuyenBanBUS Instances
		{
			get
			{
				if (instances == null) instances = new frmChuyenBanBUS();
				return frmChuyenBanBUS.instances;
			}
			set
			{
				frmChuyenBanBUS.instances = value;
			}
		}

		public void loadKhuVucAndTableFromDatabase(TabControl tabControlKhuVuc,Form frm)
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
				if (frm.Name == "frmChuyenBan")
					loadTableEmpty(tabControlKhuVuc, list[i].IdKhuVuc);
				if (frm.Name == "frmGopBan")
					loadTableNotEmpty(tabControlKhuVuc, list[i].IdKhuVuc);				
			}
		}

		public void loadTableEmpty(TabControl tabControl, int idKhuVuc)
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
					Width = frmTrangChuBUS.WeightTable,
					Height = frmTrangChuBUS.HightTable,

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
							break;
						}
					default:
						{
							btn.Image = global::QuanLiCoffeeCShapeDotNet.Properties.Resources.coffeNull;
							tabControl.TabPages[idKhuVuc.ToString()].Controls.Add(btn);
							break;
						}
				}

				btnBegin = btn;
				if (j % 3 == 0 && j != 0)
				{
					btnBegin.Location = new Point(5, btnBegin.Location.Y + btnBegin.Height + 5);
				}
			}
		}

		public void loadTableNotEmpty(TabControl tabControl, int idKhuVuc)
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
					Width = frmTrangChuBUS.WeightTable,
					Height = frmTrangChuBUS.HightTable,

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
							tabControl.TabPages[idKhuVuc.ToString()].Controls.Add(btn);
							break;
						}
					default:
						{
							btn.Image = global::QuanLiCoffeeCShapeDotNet.Properties.Resources.coffeNull;
							break;
						}
				}

				btnBegin = btn;
				if (j % 3 == 0 && j != 0)
				{
					btnBegin.Location = new Point(5, btnBegin.Location.Y + btnBegin.Height + 5);
				}
			}
		}

		private void btnClick(object sender, EventArgs e)
		{
			
		}
	}
}
