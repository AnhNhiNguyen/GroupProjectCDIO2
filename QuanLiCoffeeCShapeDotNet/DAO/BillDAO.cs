using QuanLiCoffeeCShapeDotNet.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCoffeeCShapeDotNet.DAO
{
	public class BillDAO
	{
		private static BillDAO instances;

		public static BillDAO Instances
		{
			get
			{
				if (instances == null) instances = new BillDAO();
				return BillDAO.instances;
			}

			set
			{
				BillDAO.instances = value;
			}
		}

		public List<Bill> loadBillByIdTable(int idTable)
		{
			List < Bill > listBill= new List<Bill>();
			DataTable data = Sqlcommands.Instances.getDataTable("SELECT * FROM PDT_BILL WHERE idTable="+idTable);

			foreach (DataRow items in data.Rows)
			{
				Bill bill= new Bill(items);
				listBill.Add(bill);
			}
			return listBill;
		}

		public void insertBillToTableByIdTable(int idTable)
		{
			Sqlcommands.Instances.executeUpdateScalar("INSERT INTO PDT_BILL(status,billDataCheckIn,billDateCheckOut,idTable) VALUES (-1,GETDATE(),GETDATE(),"+idTable+")");
		}

		public int getIdBillByIdTable(int idTable)
		{
			
			DataTable data = Sqlcommands.Instances.getDataTable("SELECT * FROM PDT_BILL WHERE idTable=" + idTable);
			Bill bill;
			foreach (DataRow items in data.Rows)
			{
				bill = new Bill(items);
				return bill.IdBill;
			}
			return -1;
		}
	}
}
