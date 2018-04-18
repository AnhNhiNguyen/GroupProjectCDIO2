using QuanLiCoffeeCShapeDotNet.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCoffeeCShapeDotNet.DAO
{
	public class CategoryFoodDAO
	{
		private static CategoryFoodDAO instances;

		public static CategoryFoodDAO Instances
		{
			get
			{
				if (instances == null) instances = new CategoryFoodDAO();
				return CategoryFoodDAO.instances;
			}

			set
			{
				CategoryFoodDAO.instances = value;
			}
		}

		public List<CategoryFood> loadCategory()
		{
			List<CategoryFood> list = new List<CategoryFood>();
			DataTable data = Sqlcommands.Instances.getDataTable("SELECT * FROM PDT_CATEGORYFOOD");

			foreach(DataRow items in data.Rows)
			{
				CategoryFood cFood = new CategoryFood(items);
				list.Add(cFood);
			}
			return list;
		}


	}
}
