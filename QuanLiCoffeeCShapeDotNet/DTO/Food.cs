using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCoffeeCShapeDotNet.DTO
{
	public class Food
	{
		private int idFood;
		private string foodName;
		private string donViTinh;
		private double gia;
		private string describeFood;
		private int idCategoryFood;

		public Food(int idFood, string foodName, string donViTinh, double gia, string describeFood, int idCategoryFood)
		{
			this.idFood = idFood;
			this.foodName = foodName;
			this.donViTinh = donViTinh;
			this.gia = gia;
			this.describeFood = describeFood;
			this.idCategoryFood = idCategoryFood;
		}

		public Food(DataRow row)
		{
			this.idFood = (int)row["idFood"];
			this.foodName = row["foodName"].ToString();
			this.donViTinh = row["donViTinh"].ToString();
			this.gia = Convert.ToDouble(row["gia"]);
			this.describeFood = row["describeFood"].ToString();
			this.idCategoryFood = (int)row["idCategoryFood"];
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

		public string FoodName
		{
			get
			{
				return foodName;
			}

			set
			{
				foodName = value;
			}
		}

		public string DonViTinh
		{
			get
			{
				return donViTinh;
			}

			set
			{
				donViTinh = value;
			}
		}

		public double Gia
		{
			get
			{
				return gia;
			}

			set
			{
				gia = value;
			}
		}

		public string DescribeFood
		{
			get
			{
				return describeFood;
			}

			set
			{
				describeFood = value;
			}
		}

		public int IdCategoryFood
		{
			get
			{
				return idCategoryFood;
			}

			set
			{
				idCategoryFood = value;
			}
		}
	}
}
