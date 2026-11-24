using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLKTX
{
    public class DAL_PhongGiuongSinhVien : DBConnect
    {
        public DataTable LayDanhSachGiuongTrong()
        {
            string sql = @"
                SELECT 
                    p.MaPhong,
                    p.TenPhong,
                    tn.TenToaNha,
                    lp.TenLoaiPhong,
                    g.MaGiuong,
                    g.SoHieuGiuong,
                    g.TrangThaiGiuong
                FROM Giuong g
                INNER JOIN Phong p 
                    ON g.MaPhong = p.MaPhong
                INNER JOIN ToaNha tn 
                    ON p.MaToaNha = tn.MaToaNha
                INNER JOIN LoaiPhong lp 
                    ON p.MaLoaiPhong = lp.MaLoaiPhong
                WHERE g.TrangThaiGiuong = N'Trống'";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable TimKiem(string tuKhoa)
        {
            string sql = @"
                SELECT 
                    p.MaPhong,
                    p.TenPhong,
                    tn.TenToaNha,
                    lp.TenLoaiPhong,
                    g.MaGiuong,
                    g.SoHieuGiuong,
                    g.TrangThaiGiuong
                FROM Giuong g
                INNER JOIN Phong p 
                    ON g.MaPhong = p.MaPhong
                INNER JOIN ToaNha tn 
                    ON p.MaToaNha = tn.MaToaNha
                INNER JOIN LoaiPhong lp 
                    ON p.MaLoaiPhong = lp.MaLoaiPhong
                WHERE g.TrangThaiGiuong = N'Trống'
                AND (
                    p.MaPhong LIKE @TuKhoa
                    OR p.TenPhong LIKE @TuKhoa
                    OR g.MaGiuong LIKE @TuKhoa
                    OR g.SoHieuGiuong LIKE @TuKhoa
                )";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            da.SelectCommand.Parameters.AddWithValue(
                "@TuKhoa", "%" + tuKhoa + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public bool KiemTraPhongTonTai(string tuKhoa)
        {
            string sql = @"
        SELECT COUNT(*)
        FROM Phong
        WHERE MaPhong LIKE @TuKhoa
        OR TenPhong LIKE @TuKhoa";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue(
                "@TuKhoa", "%" + tuKhoa + "%");

            conn.Open();

            int soLuong = (int)cmd.ExecuteScalar();

            conn.Close();

            return soLuong > 0;
        }
    }
}
