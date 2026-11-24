using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO_QLKTX;
using DTO_QLKTX.DTO_QLKTX;


namespace DAL_QLKTX
{
    public class DAL_TaiKhoan : DBConnect
    {
        public DTO_TaiKhoan DangNhap(string tenDangNhap, string matKhau)
        {
            string sql = @"SELECT *
                           FROM TaiKhoan
                           WHERE TenDangNhap = @TenDangNhap
                           AND MatKhau = @MatKhau";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", matKhau);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                DTO_TaiKhoan tk = new DTO_TaiKhoan();

                tk.MaTaiKhoan = reader["MaTaiKhoan"].ToString();
                tk.TenDangNhap = reader["TenDangNhap"].ToString();
                tk.MatKhau = reader["MatKhau"].ToString();
                tk.VaiTro = reader["VaiTro"].ToString();
                tk.TrangThai = reader["TrangThai"].ToString();

                tk.MaSV = reader["MaSV"] == DBNull.Value
                    ? ""
                    : reader["MaSV"].ToString();

                tk.MaNV = reader["MaNV"] == DBNull.Value
                    ? ""
                    : reader["MaNV"].ToString();

                reader.Close();
                conn.Close();

                return tk;
            }

            reader.Close();
            conn.Close();

            return null;
        }
        public DataTable LayDanhSachTaiKhoan()
        {
            string sql = @"SELECT MaTaiKhoan, TenDangNhap, MatKhau,
                          VaiTro, TrangThai, MaSV, MaNV
                   FROM TaiKhoan";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable LayDanhSachSinhVien()
        {
            string sql = @"SELECT MaSV, HoTen
                   FROM SinhVien";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable LayDanhSachNhanVien()
        {
            string sql = @"SELECT MaNV, HoTen
                   FROM NhanVien";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public bool KiemTraMaTaiKhoan(string maTaiKhoan)
        {
            string sql = @"SELECT COUNT(*)
                   FROM TaiKhoan
                   WHERE MaTaiKhoan = @MaTaiKhoan";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);

            conn.Open();
            int soLuong = (int)cmd.ExecuteScalar();
            conn.Close();

            return soLuong > 0;
        }

        public bool KiemTraTenDangNhap(string tenDangNhap)
        {
            string sql = @"SELECT COUNT(*)
                   FROM TaiKhoan
                   WHERE TenDangNhap = @TenDangNhap";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

            conn.Open();
            int soLuong = (int)cmd.ExecuteScalar();
            conn.Close();

            return soLuong > 0;
        }

        public bool ThemTaiKhoan(DTO_TaiKhoan tk)
        {
            string sql = @"INSERT INTO TaiKhoan
                   (MaTaiKhoan, TenDangNhap, MatKhau, VaiTro, TrangThai, MaSV, MaNV)
                   VALUES
                   (@MaTaiKhoan, @TenDangNhap, @MatKhau, @VaiTro, @TrangThai, @MaSV, @MaNV)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaTaiKhoan", tk.MaTaiKhoan);
            cmd.Parameters.AddWithValue("@TenDangNhap", tk.TenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", tk.MatKhau);
            cmd.Parameters.AddWithValue("@VaiTro", tk.VaiTro);
            cmd.Parameters.AddWithValue("@TrangThai", tk.TrangThai);

            if (string.IsNullOrEmpty(tk.MaSV))
                cmd.Parameters.AddWithValue("@MaSV", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@MaSV", tk.MaSV);

            if (string.IsNullOrEmpty(tk.MaNV))
                cmd.Parameters.AddWithValue("@MaNV", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@MaNV", tk.MaNV);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }
        public bool SuaTaiKhoan(DTO_TaiKhoan tk)
        {
            string sql = @"UPDATE TaiKhoan
                   SET TenDangNhap = @TenDangNhap,
                       MatKhau = @MatKhau,
                       VaiTro = @VaiTro,
                       TrangThai = @TrangThai,
                       MaSV = @MaSV,
                       MaNV = @MaNV
                   WHERE MaTaiKhoan = @MaTaiKhoan";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaTaiKhoan", tk.MaTaiKhoan);
            cmd.Parameters.AddWithValue("@TenDangNhap", tk.TenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", tk.MatKhau);
            cmd.Parameters.AddWithValue("@VaiTro", tk.VaiTro);
            cmd.Parameters.AddWithValue("@TrangThai", tk.TrangThai);

            if (string.IsNullOrEmpty(tk.MaSV))
                cmd.Parameters.AddWithValue("@MaSV", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@MaSV", tk.MaSV);

            if (string.IsNullOrEmpty(tk.MaNV))
                cmd.Parameters.AddWithValue("@MaNV", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@MaNV", tk.MaNV);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }
        public bool KiemTraTenDangNhapKhiSua(string maTaiKhoan, string tenDangNhap)
        {
            string sql = @"SELECT COUNT(*)
                   FROM TaiKhoan
                   WHERE TenDangNhap = @TenDangNhap
                   AND MaTaiKhoan <> @MaTaiKhoan";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
            cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);

            conn.Open();

            int soLuong = (int)cmd.ExecuteScalar();

            conn.Close();

            return soLuong > 0;
        }
        public bool XoaTaiKhoan(string maTaiKhoan)
        {
            string sql = @"DELETE FROM TaiKhoan
                   WHERE MaTaiKhoan = @MaTaiKhoan";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }
        public DataTable TimKiemTaiKhoan(string maTaiKhoan, string tenDangNhap)
        {
            string sql = @"SELECT MaTaiKhoan, TenDangNhap, MatKhau,
                          VaiTro, TrangThai, MaSV, MaNV
                   FROM TaiKhoan
                   WHERE MaTaiKhoan LIKE @MaTaiKhoan
                   AND TenDangNhap LIKE @TenDangNhap";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            da.SelectCommand.Parameters.AddWithValue(
                "@MaTaiKhoan", "%" + maTaiKhoan + "%");

            da.SelectCommand.Parameters.AddWithValue(
                "@TenDangNhap", "%" + tenDangNhap + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public bool KiemTraMatKhauCu(string maSV, string matKhauCu)
        {
            string sql = @"SELECT COUNT(*)
                   FROM TaiKhoan
                   WHERE MaSV = @MaSV
                   AND MatKhau = @MatKhauCu
                   AND VaiTro = N'SinhVien'";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSV", maSV);
            cmd.Parameters.AddWithValue("@MatKhauCu", matKhauCu);

            conn.Open();
            int soLuong = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();

            return soLuong > 0;
        }
        public bool DoiMatKhauSinhVien(string maSV, string matKhauMoi)
        {
            string sql = @"UPDATE TaiKhoan
                   SET MatKhau = @MatKhauMoi
                   WHERE MaSV = @MaSV
                   AND VaiTro = N'SinhVien'";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaSV", maSV);
            cmd.Parameters.AddWithValue("@MatKhauMoi", matKhauMoi);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }
    }
}