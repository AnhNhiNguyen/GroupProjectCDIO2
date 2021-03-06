﻿using QuanLiCoffeeCShapeDotNet.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCoffeeCShapeDotNet.DAO
{
	public class TableDAO
	{
		private static TableDAO instances;

		public static TableDAO Instances
		{
			get
			{
				if (instances == null) instances = new TableDAO();
				return TableDAO.instances;
			}

			set
			{
				TableDAO.instances = value;
			}
		}

		public List<Table> loadTableByIdKhuVuc(int idKhuVuc)
		{
			List<Table> list = new List<Table>();
			DataTable data=	Sqlcommands.Instances.getDataTable("SELECT * FROM PDT_TABLE WHERE idKhuVuc ="+idKhuVuc);

			foreach(DataRow items in data.Rows)
			{
				Table table = new Table(items);
				list.Add(table);
			}

			return list;
		}

		public DataTable loadTableToCbb()
		{
			DataTable data;
			data= Sqlcommands.Instances.getDataTable("SELECT * FROM PDT_TABLE");
			return data;
		}

		public DataTable loadTableTrongToCbb()
		{
			DataTable data;
			data = Sqlcommands.Instances.getDataTable("SELECT * FROM PDT_TABLE WHERE tableStatus=-1");
			return data;
		}

		public int getIdKhuVucByIdTable(int idTable)
		{
			DataTable data = Sqlcommands.Instances.getDataTable("SELECT * FROM PDT_TABLE WHERE idTable=" + idTable);

			foreach (DataRow items in data.Rows)
			{
				Table table = new Table(items);
				return table.IdKhuVuc;
			}
			return -1;
		}

		public void chuyenBan(int idBanCu,int idBanMoi)
		{
			Sqlcommands.Instances.executeNonQueryStoredProcedure(new object[] { "idTableOld" , "idTableNew" },
				new object[] { idBanCu,idBanMoi}, "USP_CHUYENBAN");
		}

		public void gopBan(int idBanCu, int idBanMoi)
		{
			Sqlcommands.Instances.executeNonQueryStoredProcedure(new object[] { "idTableOld", "idTableNew" },
				new object[] { idBanCu, idBanMoi }, "USP_GOPBAN");
		}
	}
}
