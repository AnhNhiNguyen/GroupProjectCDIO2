using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiCoffeeCShapeDotNet.DTO;
using System.Data;

namespace QuanLiCoffeeCShapeDotNet.DAO
{
	class KhuVucDAO
	{
		private static KhuVucDAO instances;

		public static KhuVucDAO Instances
		{
			get
			{
				if (instances == null) instances = new KhuVucDAO();
				return KhuVucDAO.instances;
			}

			set
			{
				KhuVucDAO.instances = value;
			}
		}

		public List<KhuVuc> loadKhuVuc()
		{
			List<KhuVuc> listKhuVuc = new List<KhuVuc>();

			DataTable data = Sqlcommands.Instances.getDataTable("SELECT * FROM PDT_KHUVUC");

			foreach (DataRow items in data.Rows)
			{
				KhuVuc khuVuc = new KhuVuc(items);
				listKhuVuc.Add(khuVuc);
			}

			return listKhuVuc;
		}
	}
}
