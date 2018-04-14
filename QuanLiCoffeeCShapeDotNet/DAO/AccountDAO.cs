using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLiCoffeeCShapeDotNet.DTO;

namespace QuanLiCoffeeCShapeDotNet.DAO
{
    class AccountDAO
    {
       private string usename = "Chưa đăng nhập";

        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return instance;
            }
            private set { instance = value; }
        }

        public string Usename
        {
            get
            {
                return usename;
            }

            set
            {
                usename = value;
            }
        }

        private AccountDAO() {}
       public bool Login(string user, string pass)
        {
            string query = "SELECT useName,passWork FROM dbo.PDT_ACCOUNT";
            DataTable dataTable = new DataTable();
			dataTable = Sqlcommands.Instances.getDataTable(query);
            bool t = false;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {               
                if (dataTable.Rows[i][0].ToString().Trim() == user && dataTable.Rows[i][1].ToString().Trim() == pass)
                {
                    t = true;
                    break;
                }
                else
                {
                    t = false;
                }
            }
            return t;
        }
        
    }
}
