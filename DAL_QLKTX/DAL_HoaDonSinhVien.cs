using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLKTX
{
    public class DAL_HoaDonSinhVien : DBConnect
    {
        public DataTable LayHoaDonCuaSinhVien(string maSV)
        {
            string sql = @"
                SELECT
                    hd.MaHoaDon,
                    hd.MaHopDong,
                    hd.Thang,
                    hd.Nam,
                    hd.TienPhong,
                    hd.TienDien,
                    hd.TienNuoc,
                    hd.PhiDichVu,
                    hd.TongTien,
                    hd.TrangThaiThanhToan
                FROM HoaDon hd
                INNER JOIN HopDong h
                    ON hd.MaHopDong = h.MaHopDong
                INNER JOIN DangKyO dk
                    ON h.MaDangKy = dk.MaDangKy
                WHERE dk.MaSV = @MaSV
                ORDER BY hd.Nam DESC, hd.Thang DESC";

            SqlDataAdapter da =
                new SqlDataAdapter(sql, conn);

            da.SelectCommand.Parameters.AddWithValue(
                "@MaSV", maSV);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}