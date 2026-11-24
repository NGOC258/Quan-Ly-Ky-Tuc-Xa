using System;
using System.Data;
using System.Data.SqlClient;
using DTO_QLKTX;

namespace DAL_QLKTX
{
    public class DAL_DangKyOSinhVien : DBConnect
    {
        public DataTable LayThongTinSinhVien(string maSV)
        {
            string sql = @"SELECT MaSV, HoTen
                           FROM SinhVien
                           WHERE MaSV = @MaSV";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaSV", maSV);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable LayDangKyCuaSinhVien(string maSV)
        {
            string sql = @"SELECT dk.MaDangKy,
                                  dk.MaSV,
                                  sv.HoTen,
                                  dk.DoiTuongUuTien,
                                  dk.NgayDangKy,
                                  dk.TrangThaiDangKy
                           FROM DangKyO dk
                           INNER JOIN SinhVien sv ON dk.MaSV = sv.MaSV
                           WHERE dk.MaSV = @MaSV
                           ORDER BY dk.NgayDangKy DESC, dk.MaDangKy DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaSV", maSV);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public string TaoMaDangKyMoi()
        {
            string sql = @"SELECT ISNULL(MAX(CAST(SUBSTRING(MaDangKy, 3, LEN(MaDangKy)) AS INT)), 0)
                           FROM DangKyO
                           WHERE MaDangKy LIKE 'DK%'";

            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            int soMoi = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            conn.Close();

            return "DK" + soMoi.ToString("D3");
        }

        public bool ThemDangKy(DTO_DangKyO dk)
        {
            string sql = @"INSERT INTO DangKyO
                           (MaDangKy, MaSV, MaGiuong, DoiTuongUuTien, NgayDangKy, TrangThaiDangKy)
                           VALUES
                           (@MaDangKy, @MaSV, NULL, @DoiTuongUuTien, @NgayDangKy, N'Chờ duyệt')";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaDangKy", dk.MaDangKy);
            cmd.Parameters.AddWithValue("@MaSV", dk.MaSV);
            cmd.Parameters.AddWithValue("@DoiTuongUuTien", dk.DoiTuongUuTien);
            cmd.Parameters.AddWithValue("@NgayDangKy", dk.NgayDangKy);

            conn.Open();
            int ketQua = cmd.ExecuteNonQuery();
            conn.Close();

            return ketQua > 0;
        }

        public bool CoDangKyChoDuyet(string maSV)
        {
            string sql = @"SELECT COUNT(*)
                           FROM DangKyO
                           WHERE MaSV = @MaSV
                           AND TrangThaiDangKy = N'Chờ duyệt'";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSV", maSV);

            conn.Open();
            int soLuong = (int)cmd.ExecuteScalar();
            conn.Close();

            return soLuong > 0;
        }

        public bool CoDangKyDaDuyet(string maSV)
        {
            string sql = @"SELECT COUNT(*)
                           FROM DangKyO
                           WHERE MaSV = @MaSV
                           AND TrangThaiDangKy = N'Đã duyệt'";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSV", maSV);

            conn.Open();
            int soLuong = (int)cmd.ExecuteScalar();
            conn.Close();

            return soLuong > 0;
        }
    }
}