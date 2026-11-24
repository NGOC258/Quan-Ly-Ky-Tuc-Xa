using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLKTX
{
    public class DAL_HopDongSinhVien : DBConnect
    {
        public DataTable LayHopDongCuaSinhVien(string maSV)
        {
            string sql = @"
                SELECT
                    hd.MaHopDong,
                    hd.MaDangKy,
                    dk.MaSV,
                    dk.MaGiuong,
                    hd.NgayBatDau,
                    hd.NgayKetThuc,
                    hd.TrangThaiHopDong
                FROM HopDong hd
                INNER JOIN DangKyO dk
                    ON hd.MaDangKy = dk.MaDangKy
                WHERE dk.MaSV = @MaSV
                ORDER BY hd.NgayBatDau DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            da.SelectCommand.Parameters.AddWithValue(
                "@MaSV", maSV);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}