using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLiCoffeeCShapeDotNet.DAL
{
    public class LOPDUNGCHUNG
    {
        SqlConnection conn;
        public LOPDUNGCHUNG()
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source =DESKTOP-HHQC8A8\KHANHLY; Initial Catalog = QL_COFFEE_CS414BIS_PDT; Integrated Security = True";
        }
        public void Open()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }
        public void Closed()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }
        public int ExcuNonQuery(string sql)
        {
            Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            int ketqua = comm.ExecuteNonQuery();
            Closed();
            return ketqua;
        }
        public DataTable Laydulieubang(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
