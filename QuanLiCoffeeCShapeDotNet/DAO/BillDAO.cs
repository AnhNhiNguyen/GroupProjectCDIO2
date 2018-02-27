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

		public Bill loadBillByIdTable(int idTable)
		{
			DataTable data = Sqlcommands.Instances.getDataTable("SELECT * FROM PDT_BILL WHERE idTable="+idTable);
			foreach(DataRow item in data.Rows)
			{
				return new Bill(item);
			}			
			return null;
		}

		public void insertBillToTableByIdTable(int idTable)
		{
			//Sqlcommands.Instances.executeUpdateScalar("INSERT INTO PDT_BILL(billStatus,billDataCheckIn,billDateCheckOut,idTable) VALUES (-1,GETDATE(),GETDATE()," + idTable+")");
			Sqlcommands.Instances.executeNonQueryStoredProcedure(new object[]
				{"idTable","billStatus","billTotal","billNameAccount"},
				new object[] {idTable,-1,0,"..."},
				"USP_INSERTBILL");
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

		public void deleteBillByIdTable(int idTable)
		{
			//Sqlcommands.Instances.executeUpdateScalar("DELETE PDT_BILL WHERE idTable=" + idTable);
			Sqlcommands.Instances.executeNonQueryStoredProcedure(
				new object[] { "idTable" }
				, new object[] { idTable }
				, "USP_DELETEBILL");
		}
	}
}
