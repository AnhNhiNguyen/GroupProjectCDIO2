using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCoffeeCShapeDotNet.DTO
{
	public class Table
	{

		public Table(int idTable, string tableName, string tableStatus, string describeTable, int idKhuVuc)
		{
			this.idTable = idTable;
			this.tableName = tableName;
			this.tableStatus = tableStatus;
			this.describeTable = describeTable;
			this.idKhuVuc = idKhuVuc;
		}

		public Table(DataRow row)
		{
			this.idTable = (int)row["idTable"];
			this.tableName = row["tableName"].ToString();
			this.tableStatus = row["tableStatus"].ToString();
			this.describeTable = row["describeTable"].ToString() ;
			this.idKhuVuc = (int)row["idKhuVuc"];
		}

		private int idTable;
		private string tableName;
		private string tableStatus;
		private string describeTable;
		private int idKhuVuc;

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

		public string TableName
		{
			get
			{
				return tableName;
			}

			set
			{
				tableName = value;
			}
		}

		public string TableStatus
		{
			get
			{
				return tableStatus;
			}

			set
			{
				tableStatus = value;
			}
		}

		public string DescribeTable
		{
			get
			{
				return describeTable;
			}

			set
			{
				describeTable = value;
			}
		}

		public int IdKhuVuc
		{
			get
			{
				return idKhuVuc;
			}

			set
			{
				idKhuVuc = value;
			}
		}
	}
}
