using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using DTO_QLKTX;
namespace DAL_QLKTX
{
    public class DAL_HopDong : DBConnect
    {
        public DataTable LayDanhSachHopDong()
        {
            string sql = @"SELECT hd.MaHopDong,
                                  hd.MaDangKy,
                                  dk.MaSV,
                                  sv.HoTen,
                                  dk.MaGiuong,
                                  hd.NgayBatDau,
                                  hd.NgayKetThuc,
                                  hd.TrangThaiHopDong
                           FROM HopDong hd
                           INNER JOIN DangKyO dk
                               ON hd.MaDangKy = dk.MaDangKy
                           INNER JOIN SinhVien sv
                               ON dk.MaSV = sv.MaSV";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable LayDanhSachDangKyDaDuyet()
        {
            string sql = @"SELECT dk.MaDangKy,
                          dk.MaSV,
                          sv.HoTen,
                          dk.MaGiuong
                   FROM DangKyO dk
                   INNER JOIN SinhVien sv ON dk.MaSV = sv.MaSV
                   WHERE dk.TrangThaiDangKy = N'Đã duyệt'
                   AND dk.MaGiuong IS NOT NULL
                   AND NOT EXISTS
                   (
                       SELECT 1
                       FROM HopDong hd
                       WHERE hd.MaDangKy = dk.MaDangKy
                   )
                   ORDER BY dk.MaDangKy";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public DataTable LayDangKyDaDuyetKhiSua(string maDangKy)
        {
            string sql = @"SELECT dk.MaDangKy,
                          dk.MaSV,
                          sv.HoTen,
                          dk.MaGiuong
                   FROM DangKyO dk
                   INNER JOIN SinhVien sv ON dk.MaSV = sv.MaSV
                   WHERE dk.TrangThaiDangKy = N'Đã duyệt'
                   AND dk.MaGiuong IS NOT NULL
                   AND
                   (
                       NOT EXISTS
                       (
                           SELECT 1
                           FROM HopDong hd
                           WHERE hd.MaDangKy = dk.MaDangKy
                       )
                       OR dk.MaDangKy = @MaDangKy
                   )
                   ORDER BY dk.MaDangKy";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaDangKy", maDangKy);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public bool KiemTraMaHopDong(string maHopDong)
        {
            string sql = @"SELECT COUNT(*)
                   FROM HopDong
                   WHERE MaHopDong = @MaHopDong";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaHopDong", maHopDong);

            conn.Open();
            int soLuong = (int)cmd.ExecuteScalar();
            conn.Close();

            return soLuong > 0;
        }
        public bool KiemTraDangKyDaCoHopDong(string maDangKy)
        {
            string sql = @"SELECT COUNT(*)
                   FROM HopDong
                   WHERE MaDangKy = @MaDangKy";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaDangKy", maDangKy);

            conn.Open();
            int soLuong = (int)cmd.ExecuteScalar();
            conn.Close();

            return soLuong > 0;
        }
        public bool ThemHopDong(DTO_HopDong hd)
        {
            string sql = @"INSERT INTO HopDong
                   (MaHopDong, MaDangKy, NgayBatDau,
                    NgayKetThuc, TrangThaiHopDong)
                   VALUES
                   (@MaHopDong, @MaDangKy, @NgayBatDau,
                    @NgayKetThuc, @TrangThaiHopDong)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaHopDong", hd.MaHopDong);
            cmd.Parameters.AddWithValue("@MaDangKy", hd.MaDangKy);
            cmd.Parameters.AddWithValue("@NgayBatDau", hd.NgayBatDau);
            cmd.Parameters.AddWithValue("@NgayKetThuc", hd.NgayKetThuc);
            cmd.Parameters.AddWithValue("@TrangThaiHopDong", hd.TrangThaiHopDong);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }
        public bool SuaHopDong(DTO_HopDong hd)
        {
            string sql = @"UPDATE HopDong
                   SET MaDangKy = @MaDangKy,
                       NgayBatDau = @NgayBatDau,
                       NgayKetThuc = @NgayKetThuc,
                       TrangThaiHopDong = @TrangThaiHopDong
                   WHERE MaHopDong = @MaHopDong";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaHopDong", hd.MaHopDong);
            cmd.Parameters.AddWithValue("@MaDangKy", hd.MaDangKy);
            cmd.Parameters.AddWithValue("@NgayBatDau", hd.NgayBatDau);
            cmd.Parameters.AddWithValue("@NgayKetThuc", hd.NgayKetThuc);
            cmd.Parameters.AddWithValue("@TrangThaiHopDong", hd.TrangThaiHopDong);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }
        public bool XoaHopDong(string maHopDong)
        {
            string sql = @"DELETE FROM HopDong
                   WHERE MaHopDong = @MaHopDong";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaHopDong", maHopDong);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }
        public DataTable TimKiemHopDong(string tuKhoa)
        {
            string sql = @"SELECT hd.MaHopDong,
                          hd.MaDangKy,
                          dk.MaSV,
                          sv.HoTen,
                          dk.MaGiuong,
                          hd.NgayBatDau,
                          hd.NgayKetThuc,
                          hd.TrangThaiHopDong
                   FROM HopDong hd
                   INNER JOIN DangKyO dk
                       ON hd.MaDangKy = dk.MaDangKy
                   INNER JOIN SinhVien sv
                       ON dk.MaSV = sv.MaSV
                   WHERE hd.MaHopDong LIKE @TuKhoa
                      OR hd.MaDangKy LIKE @TuKhoa
                      OR sv.HoTen LIKE @TuKhoa
                   ORDER BY hd.MaHopDong";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public string TaoMaHopDongMoi()
        {
            string sql = @"
        SELECT ISNULL(MAX(
            CASE
                WHEN MaHopDong LIKE 'HD%' AND TRY_CAST(SUBSTRING(MaHopDong, 3, LEN(MaHopDong)) AS INT) IS NOT NULL
                THEN TRY_CAST(SUBSTRING(MaHopDong, 3, LEN(MaHopDong)) AS INT)
                ELSE 0
            END
        ), 0)
        FROM HopDong";

            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            int soLonNhat = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();

            return "HD" + (soLonNhat + 1).ToString("D3");
        }
    }
}
