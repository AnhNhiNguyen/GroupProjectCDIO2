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
	public partial class frmChuyenBan : Form
	{
		public frmChuyenBan()
		{
			InitializeComponent();
		}

		private void frmChuyenBan_Load(object sender, EventArgs e)
		{
			loadKhuVuc();
			checkHasTableEmpty();
		}

		private void checkHasTableEmpty()
		{
			foreach (TabPage tabpage in tabEmptyTable.Controls)
			{
				if (tabpage.Controls.Count > 0)
				{
					return;
				}
				else
				{
					MessageBox.Show("Không còn bàn trống để chuyển");
					return;
				}
			}
		}

		private void loadKhuVuc()
		{
			frmChuyenBanBUS.Instances.loadKhuVucAndTableFromDatabase(tabEmptyTable,this);
		}

		private void frmChuyenBan_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Dispose();
		}
	}
}
