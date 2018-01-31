using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCoffeeCShapeDotNet.DTO
{
	public class CategoryFood
	{

		private int idCategory;
		private string categoryName;
		private string describeCategoryFood;

		public CategoryFood(int idCategory, string categoryName, string describeCategoryFood)
		{
			this.idCategory = idCategory;
			this.categoryName = categoryName;
			this.describeCategoryFood = describeCategoryFood;
		}

		public CategoryFood(DataRow row)
		{
			this.idCategory = (int)row["idCategory"];
			this.categoryName = row["categoryName"].ToString();
			this.describeCategoryFood = row["describeCategoryFood"].ToString();
		}

		public int IdCategory
		{
			get
			{
				return idCategory;
			}

			set
			{
				idCategory = value;
			}
		}

		public string CategoryName
		{
			get
			{
				return categoryName;
			}

			set
			{
				categoryName = value;
			}
		}

		public string DescribeCategoryFood
		{
			get
			{
				return describeCategoryFood;
			}

			set
			{
				describeCategoryFood = value;
			}
		}
	}
}
