using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCoffeeCShapeDotNet.BUS
{
	public class frmThanhToanBUS
	{
		private double tongTien = -1;

		private static frmThanhToanBUS instances;
		public static frmThanhToanBUS Instances
		{
			get
			{
				if (instances == null) instances = new frmThanhToanBUS();
				return frmThanhToanBUS.instances;
			}
			set
			{
				frmThanhToanBUS.instances = value;
			}
		}

		public double TongTien
		{
			get
			{
				return tongTien;
			}

			set
			{
				tongTien = value;
			}
		}
	}
}
