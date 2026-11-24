using System;
using System.Data;
using System.Data.SqlClient;
using DTO_QLKTX;

namespace DAL_QLKTX
{
    public class DAL_DangKyO : DBConnect
    {
        // Load danh sách đăng ký ở
        public DataTable LayDanhSachDangKyO()
        {
            string sql = @"
                SELECT dk.MaDangKy,
                       dk.MaSV,
                       sv.HoTen,
                       dk.DoiTuongUuTien,
                       dk.MaGiuong,
                       dk.NgayDangKy,
                       dk.TrangThaiDangKy
                FROM DangKyO dk
                INNER JOIN SinhVien sv
                    ON dk.MaSV = sv.MaSV
                ORDER BY dk.NgayDangKy DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        // Load danh sách sinh viên
        public DataTable LayDanhSachSinhVien()
        {
            string sql = @"
                SELECT MaSV, HoTen
                FROM SinhVien";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        // =========================
        // PHÂN CHỖ Ở
        // =========================

        // Load tòa nhà
        public DataTable LayDanhSachToaNha()
        {
            string sql = @"
                SELECT MaToaNha, TenToaNha
                FROM ToaNha
                ORDER BY TenToaNha";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        // Sau khi chọn tòa -> chỉ lấy loại phòng có trong tòa đó
        public DataTable LayLoaiPhongTheoToa(string maToaNha)
        {
            string sql = @"
                SELECT DISTINCT lp.MaLoaiPhong,
                                lp.TenLoaiPhong
                FROM LoaiPhong lp
                INNER JOIN Phong p
                    ON lp.MaLoaiPhong = p.MaLoaiPhong
                WHERE p.MaToaNha = @MaToaNha
                ORDER BY lp.TenLoaiPhong";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            da.SelectCommand.Parameters.AddWithValue(
                "@MaToaNha", maToaNha);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        // Sau khi chọn tòa + loại phòng -> lấy phòng phù hợp
        public DataTable LayPhongTheoToaVaLoai(
            string maToaNha,
            string maLoaiPhong)
        {
            string sql = @"
                SELECT MaPhong, TenPhong
                FROM Phong
                WHERE MaToaNha = @MaToaNha
                  AND MaLoaiPhong = @MaLoaiPhong
                  AND TrangThaiPhong <> N'Đang sửa'
                ORDER BY TenPhong";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            da.SelectCommand.Parameters.AddWithValue(
                "@MaToaNha", maToaNha);

            da.SelectCommand.Parameters.AddWithValue(
                "@MaLoaiPhong", maLoaiPhong);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        // Sau khi chọn phòng -> chỉ lấy giường còn trống
        public DataTable LayGiuongTrongTheoPhong(string maPhong)
        {
            string sql = @"
                SELECT g.MaGiuong,
                       g.SoHieuGiuong
                FROM Giuong g
                WHERE g.MaPhong = @MaPhong
                  AND g.TrangThaiGiuong = N'Trống'
                  AND NOT EXISTS
                  (
                      SELECT 1
                      FROM DangKyO dk
                      WHERE dk.MaGiuong = g.MaGiuong
                        AND dk.TrangThaiDangKy = N'Đã duyệt'
                  )
                ORDER BY g.SoHieuGiuong";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            da.SelectCommand.Parameters.AddWithValue(
                "@MaPhong", maPhong);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        // Giữ lại nếu chỗ khác trong project còn dùng
        public DataTable LayDanhSachGiuongTrong()
        {
            string sql = @"
                SELECT MaGiuong, SoHieuGiuong
                FROM Giuong
                WHERE TrangThaiGiuong = N'Trống'";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public bool KiemTraMaDangKy(string maDangKy)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM DangKyO
                WHERE MaDangKy = @MaDangKy";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue(
                "@MaDangKy", maDangKy);

            conn.Open();
            int soLuong = (int)cmd.ExecuteScalar();
            conn.Close();

            return soLuong > 0;
        }

        public bool ThemDangKyO(DTO_DangKyO dk)
        {
            string sql = @"
                INSERT INTO DangKyO
                (MaDangKy, MaSV, MaGiuong,
                 NgayDangKy, TrangThaiDangKy)
                VALUES
                (@MaDangKy, @MaSV, @MaGiuong,
                 @NgayDangKy, @TrangThaiDangKy)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue(
                "@MaDangKy", dk.MaDangKy);

            cmd.Parameters.AddWithValue(
                "@MaSV", dk.MaSV);

            if (string.IsNullOrEmpty(dk.MaGiuong))
            {
                cmd.Parameters.AddWithValue(
                    "@MaGiuong", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue(
                    "@MaGiuong", dk.MaGiuong);
            }

            cmd.Parameters.AddWithValue(
                "@NgayDangKy", dk.NgayDangKy);

            cmd.Parameters.AddWithValue(
                "@TrangThaiDangKy", dk.TrangThaiDangKy);

            conn.Open();
            int ketQua = cmd.ExecuteNonQuery();
            conn.Close();

            return ketQua > 0;
        }

        public bool KiemTraGiuongDaDuocDuyet(string maGiuong)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM DangKyO
                WHERE MaGiuong = @MaGiuong
                  AND TrangThaiDangKy = N'Đã duyệt'";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue(
                "@MaGiuong", maGiuong);

            conn.Open();
            int soLuong = (int)cmd.ExecuteScalar();
            conn.Close();

            return soLuong > 0;
        }

        public bool SuaDangKyO(DTO_DangKyO dk)
        {
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                string sqlLayGiuongCu = @"SELECT MaGiuong
                                 FROM DangKyO
                                 WHERE MaDangKy = @MaDangKy";

                SqlCommand cmdLayGiuongCu = new SqlCommand(sqlLayGiuongCu, conn, transaction);
                cmdLayGiuongCu.Parameters.AddWithValue("@MaDangKy", dk.MaDangKy);

                object ketQuaGiuongCu = cmdLayGiuongCu.ExecuteScalar();

                string maGiuongCu = null;

                if (ketQuaGiuongCu != null && ketQuaGiuongCu != DBNull.Value)
                {
                    maGiuongCu = ketQuaGiuongCu.ToString();
                }

                string sql = @"UPDATE DangKyO
                       SET MaSV = @MaSV,
                           MaGiuong = @MaGiuong,
                           NgayDangKy = @NgayDangKy,
                           TrangThaiDangKy = @TrangThaiDangKy
                       WHERE MaDangKy = @MaDangKy";

                SqlCommand cmd = new SqlCommand(sql, conn, transaction);

                cmd.Parameters.AddWithValue("@MaDangKy", dk.MaDangKy);
                cmd.Parameters.AddWithValue("@MaSV", dk.MaSV);

                if (string.IsNullOrEmpty(dk.MaGiuong))
                {
                    cmd.Parameters.AddWithValue("@MaGiuong", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaGiuong", dk.MaGiuong);
                }

                cmd.Parameters.AddWithValue("@NgayDangKy", dk.NgayDangKy);
                cmd.Parameters.AddWithValue("@TrangThaiDangKy", dk.TrangThaiDangKy);

                int ketQua = cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(maGiuongCu) && maGiuongCu != dk.MaGiuong)
                {
                    string sqlTraGiuongCu = @"UPDATE Giuong
                                     SET TrangThaiGiuong = N'Trống'
                                     WHERE MaGiuong = @MaGiuongCu";

                    SqlCommand cmdTraGiuongCu = new SqlCommand(sqlTraGiuongCu, conn, transaction);
                    cmdTraGiuongCu.Parameters.AddWithValue("@MaGiuongCu", maGiuongCu);
                    cmdTraGiuongCu.ExecuteNonQuery();
                }

                if (dk.TrangThaiDangKy == "Đã duyệt" && !string.IsNullOrEmpty(dk.MaGiuong))
                {
                    string sqlCapNhatGiuong = @"UPDATE Giuong
                                       SET TrangThaiGiuong = N'Đã có người'
                                       WHERE MaGiuong = @MaGiuong";

                    SqlCommand cmdCapNhatGiuong = new SqlCommand(sqlCapNhatGiuong, conn, transaction);
                    cmdCapNhatGiuong.Parameters.AddWithValue("@MaGiuong", dk.MaGiuong);
                    cmdCapNhatGiuong.ExecuteNonQuery();
                }
                else if (!string.IsNullOrEmpty(maGiuongCu))
                {
                    string sqlTraGiuong = @"UPDATE Giuong
                                    SET TrangThaiGiuong = N'Trống'
                                    WHERE MaGiuong = @MaGiuong";

                    SqlCommand cmdTraGiuong = new SqlCommand(sqlTraGiuong, conn, transaction);
                    cmdTraGiuong.Parameters.AddWithValue("@MaGiuong", maGiuongCu);
                    cmdTraGiuong.ExecuteNonQuery();
                }

                transaction.Commit();
                conn.Close();

                return ketQua > 0;
            }
            catch
            {
                transaction.Rollback();
                conn.Close();
                throw;
            }
        }
        public bool KiemTraGiuongKhiSua(
            string maGiuong,
            string maDangKy)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM DangKyO
                WHERE MaGiuong = @MaGiuong
                  AND TrangThaiDangKy = N'Đã duyệt'
                  AND MaDangKy <> @MaDangKy";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue(
                "@MaGiuong", maGiuong);

            cmd.Parameters.AddWithValue(
                "@MaDangKy", maDangKy);

            conn.Open();
            int soLuong = (int)cmd.ExecuteScalar();
            conn.Close();

            return soLuong > 0;
        }

        public bool XoaDangKyO(string maDangKy)
        {
            string sql = @"
                DELETE FROM DangKyO
                WHERE MaDangKy = @MaDangKy";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue(
                "@MaDangKy", maDangKy);

            conn.Open();
            int ketQua = cmd.ExecuteNonQuery();
            conn.Close();

            return ketQua > 0;
        }

        public DataTable TimKiemDangKyO(
            string maDangKy,
            string maSV)
        {
            string sql = @"
                SELECT dk.MaDangKy,
                       dk.MaSV,
                       sv.HoTen,
                       dk.MaGiuong,
                       dk.NgayDangKy,
                       dk.TrangThaiDangKy
                FROM DangKyO dk
                INNER JOIN SinhVien sv
                    ON dk.MaSV = sv.MaSV
                WHERE dk.MaDangKy LIKE @MaDangKy
                  AND dk.MaSV LIKE @MaSV";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            da.SelectCommand.Parameters.AddWithValue(
                "@MaDangKy", "%" + maDangKy + "%");

            da.SelectCommand.Parameters.AddWithValue(
                "@MaSV", "%" + maSV + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public DataTable LayThongTinChoOTheoGiuong(string maGiuong)
        {
            string sql = @"
        SELECT tn.MaToaNha,
               lp.MaLoaiPhong,
               p.MaPhong,
               g.MaGiuong
        FROM Giuong g
        INNER JOIN Phong p ON g.MaPhong = p.MaPhong
        INNER JOIN ToaNha tn ON p.MaToaNha = tn.MaToaNha
        INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
        WHERE g.MaGiuong = @MaGiuong";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaGiuong", maGiuong);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public bool SinhVienDaCoChoOKhiSua(string maSV, string maDangKy)
        {
            string sql = @"
        SELECT COUNT(*)
        FROM DangKyO
        WHERE MaSV = @MaSV
          AND TrangThaiDangKy = N'Đã duyệt'
          AND MaDangKy <> @MaDangKy";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSV", maSV);
            cmd.Parameters.AddWithValue("@MaDangKy", maDangKy);

            conn.Open();
            int soLuong = (int)cmd.ExecuteScalar();
            conn.Close();

            return soLuong > 0;
        }
        public bool SinhVienCoDangKyDangHoatDong(string maSV)
        {
            string sql = @"SELECT COUNT(*) FROM DangKyO WHERE MaSV = @MaSV AND TrangThaiDangKy IN (N'Chờ duyệt', N'Đã duyệt')";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSV", maSV);

            conn.Open();
            int soLuong = (int)cmd.ExecuteScalar();
            conn.Close();

            return soLuong > 0;
        }
        public string TaoMaDangKyMoi()
        {
            string sql = @"
        SELECT ISNULL(MAX(
            CASE
                WHEN MaDangKy LIKE 'DK%' AND TRY_CAST(SUBSTRING(MaDangKy, 3, LEN(MaDangKy)) AS INT) IS NOT NULL
                THEN TRY_CAST(SUBSTRING(MaDangKy, 3, LEN(MaDangKy)) AS INT)
                ELSE 0
            END
        ), 0)
        FROM DangKyO";

            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            int soLonNhat = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();

            return "DK" + (soLonNhat + 1).ToString("D3");
        }
        public DataTable LayGiuongKhiSua(string maPhong, string maDangKy)
        {
            string sql = @"SELECT g.MaGiuong,
                          g.SoHieuGiuong
                   FROM Giuong g
                   WHERE g.MaPhong = @MaPhong
                   AND
                   (
                       g.TrangThaiGiuong = N'Trống'
                       OR g.MaGiuong = (
                           SELECT MaGiuong
                           FROM DangKyO
                           WHERE MaDangKy = @MaDangKy
                       )
                   )
                   ORDER BY g.SoHieuGiuong";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaPhong", maPhong);
            da.SelectCommand.Parameters.AddWithValue("@MaDangKy", maDangKy);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public string LayGioiTinhSinhVien(string maSV)
        {
            string sql = @"SELECT GioiTinh
                   FROM SinhVien
                   WHERE MaSV = @MaSV";

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

        public DataTable LayToaNhaTheoGioiTinh(string gioiTinh)
        {
            string sql = @"SELECT MaToaNha, TenToaNha
                   FROM ToaNha
                   WHERE GioiTinhKhu = @GioiTinh
                   ORDER BY TenToaNha";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@GioiTinh", gioiTinh);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public bool KiemTraToaPhuHopGioiTinh(string maSV, string maToaNha)
        {
            string sql = @"SELECT COUNT(*)
                   FROM SinhVien sv
                   INNER JOIN ToaNha tn ON sv.GioiTinh = tn.GioiTinhKhu
                   WHERE sv.MaSV = @MaSV
                   AND tn.MaToaNha = @MaToaNha";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSV", maSV);
            cmd.Parameters.AddWithValue("@MaToaNha", maToaNha);

            conn.Open();
            int soLuong = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();

            return soLuong > 0;
        }
    }
}