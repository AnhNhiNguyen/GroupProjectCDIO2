using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCoffeeCShapeDotNet.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }
        private AccountDAO() { }
        public bool Login(string user, string pass)
        {
            string query = "SELECT useName,passWork FROM dbo.PDT_ACCOUNT";
            DataTable dataTable = new DataTable();
            dataTable = DataProvider.Instance.ExecuteQuery(query);
            bool t = false;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i][1].ToString() == user && dataTable.Rows[i][2].ToString() == pass)
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
