using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCoffeeCShapeDotNet.DTO
{
	public class Bill
	{
		private int idBill;
		private DateTime? billDataCheckIn;
		private DateTime? billDateCheckOut;
		private string billNameAccount;
		private string status;
		private double billTotal;
		private int idTable;

		public Bill(int idBill, DateTime? billDataCheckIn, DateTime? billDateCheckOut, string billNameAccount, string status, double billTotal, int idTable)
		{
			this.idBill = idBill;
			this.billDataCheckIn = billDataCheckIn;
			this.billDateCheckOut = billDateCheckOut;
			this.billNameAccount = billNameAccount;
			this.status = status;
			this.billTotal = billTotal;
			this.idTable = idTable;
		}

		public Bill(DataRow row)
		{
			this.idBill = (int)row["idBill"];
			this.billDataCheckIn =(DateTime?) row["billDataCheckIn"];
			this.billDateCheckOut = (DateTime?)row["billDateCheckOut"];
			this.billNameAccount = row["billNameAccount"].ToString();
			this.status = row["status"].ToString();
			this.billTotal = Convert.ToDouble(row["billTotal"]);
			this.idTable = (int)row["idTable"];
		}

		public int IdBill
		{
			get
			{
				return idBill;
			}

			set
			{
				idBill = value;
			}
		}

		public DateTime? BillDataCheckIn
		{
			get
			{
				return billDataCheckIn;
			}

			set
			{
				billDataCheckIn = value;
			}
		}

		public DateTime? BillDateCheckOut
		{
			get
			{
				return billDateCheckOut;
			}

			set
			{
				billDateCheckOut = value;
			}
		}

		public string BillNameAccount
		{
			get
			{
				return billNameAccount;
			}

			set
			{
				billNameAccount = value;
			}
		}

		public string Status
		{
			get
			{
				return status;
			}

			set
			{
				status = value;
			}
		}

		public double BillTotal
		{
			get
			{
				return billTotal;
			}

			set
			{
				billTotal = value;
			}
		}

		public int IdTable
		{
			get
			{
				return idTable;
			}

			set
			{
				idTable = value;
			}
		}
	}
}
