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
    public class DAL_SinhVien : DBConnect
    {
        public DataTable LayDanhSachSinhVien()
        {
            string sql = @"SELECT MaSV, HoTen, NgaySinh, GioiTinh,
                                  Lop, Khoa, SDT, Email, DiaChi, DoiTuongUuTien
                           FROM SinhVien";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public bool KiemTraMaSV(string maSV)
        {
            string sql = @"SELECT COUNT(*)
                   FROM SinhVien
                   WHERE MaSV = @MaSV";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSV", maSV);

            conn.Open();

            int soLuong = (int)cmd.ExecuteScalar();

            conn.Close();

            return soLuong > 0;
        }

        public bool ThemSinhVien(DTO_SinhVien sv)
        {
            string sql = @"INSERT INTO SinhVien
                   (MaSV, HoTen, NgaySinh, GioiTinh, Lop, Khoa,
                    SDT, Email, DiaChi, DoiTuongUuTien)
                   VALUES
                   (@MaSV, @HoTen, @NgaySinh, @GioiTinh, @Lop, @Khoa,
                    @SDT, @Email, @DiaChi, @DoiTuongUuTien)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaSV", sv.MaSV);
            cmd.Parameters.AddWithValue("@HoTen", sv.HoTen);
            cmd.Parameters.AddWithValue("@NgaySinh", sv.NgaySinh);
            cmd.Parameters.AddWithValue("@GioiTinh", sv.GioiTinh);
            cmd.Parameters.AddWithValue("@Lop", sv.Lop);
            cmd.Parameters.AddWithValue("@Khoa", sv.Khoa);
            cmd.Parameters.AddWithValue("@SDT", sv.SDT);
            cmd.Parameters.AddWithValue("@Email", sv.Email);
            cmd.Parameters.AddWithValue("@DiaChi", sv.DiaChi);
            cmd.Parameters.AddWithValue("@DoiTuongUuTien", sv.DoiTuongUuTien);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }

        public bool SuaSinhVien(DTO_SinhVien sv)
        {
            string sql = @"UPDATE SinhVien
                   SET HoTen = @HoTen,
                       NgaySinh = @NgaySinh,
                       GioiTinh = @GioiTinh,
                       Lop = @Lop,
                       Khoa = @Khoa,
                       SDT = @SDT,
                       Email = @Email,
                       DiaChi = @DiaChi,
                       DoiTuongUuTien = @DoiTuongUuTien
                   WHERE MaSV = @MaSV";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaSV", sv.MaSV);
            cmd.Parameters.AddWithValue("@HoTen", sv.HoTen);
            cmd.Parameters.AddWithValue("@NgaySinh", sv.NgaySinh);
            cmd.Parameters.AddWithValue("@GioiTinh", sv.GioiTinh);
            cmd.Parameters.AddWithValue("@Lop", sv.Lop);
            cmd.Parameters.AddWithValue("@Khoa", sv.Khoa);
            cmd.Parameters.AddWithValue("@SDT", sv.SDT);
            cmd.Parameters.AddWithValue("@Email", sv.Email);
            cmd.Parameters.AddWithValue("@DiaChi", sv.DiaChi);
            cmd.Parameters.AddWithValue("@DoiTuongUuTien", sv.DoiTuongUuTien);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }
        public bool XoaSinhVien(string maSV)
        {
            string sql = @"DELETE FROM SinhVien
                   WHERE MaSV = @MaSV";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaSV", maSV);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }
        public DataTable TimKiemSinhVien(string maSV, string hoTen)
        {
            string sql = @"SELECT MaSV, HoTen, NgaySinh, GioiTinh,
                          Lop, Khoa, SDT, Email, DiaChi, DoiTuongUuTien
                   FROM SinhVien
                   WHERE MaSV LIKE @MaSV
                   AND HoTen LIKE @HoTen";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            da.SelectCommand.Parameters.AddWithValue(
                "@MaSV", "%" + maSV + "%");

            da.SelectCommand.Parameters.AddWithValue(
                "@HoTen", "%" + hoTen + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}