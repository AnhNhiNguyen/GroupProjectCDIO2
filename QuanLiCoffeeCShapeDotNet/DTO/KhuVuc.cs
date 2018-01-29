using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCoffeeCShapeDotNet.DTO
{
	public class KhuVuc
	{

		public KhuVuc(DataRow row)
		{
			this.idKhuVuc = (int)row["idKhuVuc"];
			this.khuVucName = row["khuVucName"].ToString();
			this.describeKhuVuc = row["describeKhuVuc"].ToString();
		}

		private int idKhuVuc;
		private string khuVucName;
		private string describeKhuVuc;

		public KhuVuc(int idKhuVuc, string khuVucName, string describeKhuVuc)
		{
			this.idKhuVuc = idKhuVuc;
			this.khuVucName = khuVucName;
			this.describeKhuVuc = describeKhuVuc;
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

		public string KhuVucName
		{
			get
			{
				return khuVucName;
			}

			set
			{
				khuVucName = value;
			}
		}

		public string DescribeKhuVuc
		{
			get
			{
				return describeKhuVuc;
			}

			set
			{
				describeKhuVuc = value;
			}
		}
	}
}
