using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCoffeeCShapeDotNet.DTO
{
	public class BillInfo
	{
		private int idBillInfo;
		private int billInfoCount;
		private int idBill;
		private int idFood;

		public BillInfo(int idBillInfo, int billInfoCount, int idBill, int idFood)
		{
			this.idBillInfo = idBillInfo;
			this.billInfoCount = billInfoCount;
			this.idBill = idBill;
			this.idFood = idFood;
		}

		public BillInfo(DataRow row)
		{
			this.idBillInfo = (int)row["idBillInfo"];
			this.billInfoCount = (int)row["billInfoCount"];
			this.idBill = (int)row["idBill"];
			this.idFood = (int)row["idFood"];
		}

		public int IdBillInfo
		{
			get
			{
				return idBillInfo;
			}

			set
			{
				idBillInfo = value;
			}
		}

		public int BillInfoCount
		{
			get
			{
				return billInfoCount;
			}

			set
			{
				billInfoCount = value;
			}
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

		public int IdFood
		{
			get
			{
				return idFood;
			}

			set
			{
				idFood = value;
			}
		}
	}
}
