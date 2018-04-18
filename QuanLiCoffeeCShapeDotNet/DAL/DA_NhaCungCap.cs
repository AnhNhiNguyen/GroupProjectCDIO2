using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLiCoffeeCShapeDotNet.DTO;

namespace QuanLiCoffeeCShapeDotNet.DAL
{
    class DA_NhaCungCap
    {
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();
        public DataTable layBangNCC()
        {
            string sql = "select * from PDT_NCC";
            //return lopchung.Laydulieubang(sql);
            return Sqlcommands.Instances.getDataTable(sql);
        }
        public int Them(string mancc
          , string tenncc
          , string diachi
          , string sdt
          , string email
          , string fax
          , string mst)
        {
            string sql = "Insert into PDT_NCC(MaNCC,TenNCC,DiaChi,SoDT,Email,Fax,MST) values('" + mancc + "','"
                + tenncc + "', '"
                + diachi + "', '"
                + sdt + "', '"
                + email + "', '"
                + fax + "', '"
                + mst + "')";

            return lopchung.ExcuNonQuery(sql);
        }
        public int Sua(string mancc
            , string tenncc
            , string diachi
            , string sdt
            , string email
            , string fax
            , string mst)
        {
            string sql = "Update PDT_NCC set TenNCC = '" + tenncc + "', DiaChi = '" + diachi + "',SoDT = '" + sdt + "', Email= '" + email + "', Fax= '" + fax + "', MST = '" + mst + "' where MaNCC = '" + mancc + "'";
            return lopchung.ExcuNonQuery(sql);
        }
        public int Xoa(string mancc)
        {
            string sql = "Delete PDT_NCC  where MaNCC = '" + mancc + "'";
            return lopchung.ExcuNonQuery(sql);
        }

    }
}
