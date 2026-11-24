using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLKTX
{
    public class DAL_SinhVienTrangChu : DBConnect
    {
        public DataTable LayThongTinNoiTru(string maSV)
        {
            string sql = @"SELECT TOP 1
                          p.TenPhong,
                          g.SoHieuGiuong
                   FROM DangKyO dk
                   INNER JOIN Giuong g ON dk.MaGiuong = g.MaGiuong
                   INNER JOIN Phong p ON g.MaPhong = p.MaPhong
                   WHERE dk.MaSV = @MaSV
                   AND dk.TrangThaiDangKy = N'Đã duyệt'
                   AND dk.MaGiuong IS NOT NULL
                   ORDER BY dk.NgayDangKy DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaSV", maSV);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public string LayTrangThaiDangKyMoiNhat(string maSV)
        {
            string sql = @"SELECT TOP 1 TrangThaiDangKy
                   FROM DangKyO
                   WHERE MaSV = @MaSV
                   ORDER BY NgayDangKy DESC";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSV", maSV);

            conn.Open();
            object ketQua = cmd.ExecuteScalar();
            conn.Close();

            if (ketQua == null || ketQua == DBNull.Value)
            {
                return "Chưa đăng ký";
            }

            return ketQua.ToString();
        }

        public int DemHoaDonChuaThanhToan(string maSV)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM HoaDon hd
                INNER JOIN HopDong h
                    ON hd.MaHopDong = h.MaHopDong
                INNER JOIN DangKyO dk
                    ON h.MaDangKy = dk.MaDangKy
                WHERE dk.MaSV = @MaSV
                AND hd.TrangThaiThanhToan = N'Chưa thanh toán'";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSV", maSV);

            conn.Open();
            int soLuong = (int)cmd.ExecuteScalar();
            conn.Close();

            return soLuong;
        }
        public string LayTenSinhVien(string maSV)
        {
            string sql = @"SELECT HoTen FROM SinhVien WHERE MaSV = @MaSV";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSV", maSV);

            conn.Open();
            object ketQua = cmd.ExecuteScalar();
            conn.Close();

            if (ketQua == null || ketQua == DBNull.Value)
            {
                return "";
            }

            return ketQua.ToString();
        }
    }
}