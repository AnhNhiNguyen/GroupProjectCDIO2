using QuanLiCoffeeCShapeDotNet.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCoffeeCShapeDotNet.DAO
{
	public class FoodDAO
	{
		private static FoodDAO instances;

		public static FoodDAO Instances
		{
			get
			{
				if (instances == null) instances = new FoodDAO();
				return FoodDAO.instances;
			}

			set
			{
				FoodDAO.instances = value;
			}
		}

		public List<Food> loadFood()
		{
			List<Food> list = new List<Food>();
			DataTable data = Sqlcommands.Instances.getDataTable("SELECT * FROM PDT_FOOD");

			foreach(DataRow items in data.Rows)
			{
				Food food = new Food(items);
				list.Add(food);
			}

			return list;
		}

		public List<Food> loadFoodByIdCategoryFood(int idCategoryFood)
		{
			List<Food> list = new List<Food>();
			DataTable data = Sqlcommands.Instances.getDataTable("SELECT * FROM PDT_FOOD WHERE idCategoryFood="+idCategoryFood);

			foreach (DataRow items in data.Rows)
			{
				Food food = new Food(items);
				list.Add(food);
			}

			return list;
		}

		public DataTable treeViewClickByIdCategoryFood(int idCategoryFood)
		{		
			DataTable data = Sqlcommands.Instances.getDataTable("SELECT FoodName,donViTinh,gia FROM PDT_FOOD WHERE idCategoryFood=" + idCategoryFood);

			return data;
		}

		public DataTable buttonClickByIdCategoryFood(int idCategoryFood)
		{
			DataTable data = Sqlcommands.Instances.getDataTable("SELECT FoodName,donViTinh,gia FROM PDT_FOOD WHERE idCategoryFood=" + idCategoryFood);

			return data;
		}

		public Food loadFoodByIdFood(int idFood)
		{
			DataTable data = Sqlcommands.Instances.getDataTable("SELECT * FROM PDT_FOOD WHERE idFood=" + idFood);
			foreach (DataRow items in data.Rows)
			{
				return new Food(items);
			}
			return null;
		}

		public List<Food> loadFoodByNameFood(string name)
		{
			List<Food> food = new List<Food>();

			//DataTable data = Sqlcommands.Instances.getDataTable("SELECT * FROM PDT_FOOD WHERE foodName like '" + name + "%'");
			DataTable data = Sqlcommands.Instances.getDataTableStoredProcedure(new object[] { "FOODNAME" },
				new object[] { name }, "USP_SEARCHFOOD");

			foreach (DataRow items in data.Rows)
			{
				food.Add(new Food(items));
			}
			return food;
		}
	}
}
