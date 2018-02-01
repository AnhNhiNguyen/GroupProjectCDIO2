using QuanLiCoffeeCShapeDotNet.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCoffeeCShapeDotNet.DAO
{
	public class BillInfoDAO
	{
		private static BillInfoDAO instances;

		public static BillInfoDAO Instances
		{
			get
			{
				if (instances == null) instances = new BillInfoDAO();
				return BillInfoDAO.instances;
			}

			set
			{
				BillInfoDAO.instances = value;
			}
		}

		public List<BillInfo> loadBillInfoByIdBill(int idBill)
		{
			List<BillInfo> listBillInfo = new List<BillInfo>();
			DataTable data = Sqlcommands.Instances.getDataTable("SELECT * FROM PDT_BILLINFO WHERE idBill=" +
				idBill);
			foreach (DataRow items in data.Rows)
			{
				BillInfo bill = new BillInfo(items);
				listBillInfo.Add(bill);
			}
			return listBillInfo;
		}

	}
}
