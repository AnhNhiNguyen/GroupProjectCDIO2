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

        private void cácDanhMụcKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

		private void tBtnThoat_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void frmTrangChu_Load(object sender, EventArgs e)
		{
			loadKhuVuc();
		}

		private void loadKhuVuc1()
		{
			DataTable dt=Sqlcommands.Instances.getDataTable("SELECT * FROM PDT_KHUVUC");
			
			foreach (DataRow items in dt.Rows)
			{
				TabPage tabPage = new TabPage(
					Text = items["khuVucName"].ToString()
			
					
					 
					) ;
				tabPage.Tag = (int)items["idKhuVuc"];
				DataTable dtTable = Sqlcommands.Instances.getDataTable("SELECT * FROM PDT_TABLE WHERE idKhuVuc = "+(int)tabPage.Tag);
				foreach (DataRow itemTable in dtTable.Rows)
				{
					Button btnGoc = new Button();
					btnGoc.Location = new Point(0, 0);
					Button btn = new Button {
						Text = itemTable["tableName"].ToString() + Environment.NewLine + itemTable["tableStatus"].ToString(),
						Height=50,
						Width=50,
						

					};
					tabPage.Controls.Add(btn);
					
				}
				
				tabPage.UseVisualStyleBackColor = true;
				tabControlKhuVuc.Controls.Add(tabPage);
			}			
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
						btnBegin.Location.Y)

					};
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

		private void loadTable()
		{
			DataTable dt = Sqlcommands.Instances.getDataTable("SELECT * FROM PDT_TABLE");
			foreach(DataRow items in dt.Rows)
			{
				Button btn = new Button();
				btn.Text = items["tableName"].ToString()+ Environment.NewLine+items["tableStatus"];
				
			}


		}
	}
}
