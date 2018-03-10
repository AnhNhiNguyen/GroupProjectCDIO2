using QuanLiCoffeeCShapeDotNet.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCoffeeCShapeDotNet
{
	public partial class frmGopBan : Form
	{
		public frmGopBan()
		{
			InitializeComponent();
		}

		private void frmGopBan_Load(object sender, EventArgs e)
		{
			loadTable();
			checkBanNotEmpty();
		}

		public void loadTable()
		{
			frmChuyenBanBUS.Instances.loadKhuVucAndTableFromDatabase(tabGopBan,this);
		}

		public void checkBanNotEmpty()
		{
			foreach (TabPage tabpage in tabGopBan.Controls)
			{
				if (tabpage.Controls.Count > 0)
				{
					return;
				}
				else
				{
					MessageBox.Show("Chưa có bàn nào để gộp");
					return;
				}
			}
		}
	}
}
