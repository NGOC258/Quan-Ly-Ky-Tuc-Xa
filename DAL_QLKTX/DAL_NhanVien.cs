using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLKTX;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLKTX
{
    public class DAL_NhanVien : DBConnect
    {
        public DataTable LayDanhSachNhanVien()
        {
            string sql = @"SELECT MaNV, HoTen, ChucVu, SDT, Email
                           FROM NhanVien";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public bool KiemTraMaNV(string maNV)
        {
            string sql = @"SELECT COUNT(*)
                   FROM NhanVien
                   WHERE MaNV = @MaNV";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);

            conn.Open();

            int soLuong = (int)cmd.ExecuteScalar();

            conn.Close();

            return soLuong > 0;
        }

        public bool ThemNhanVien(DTO_NhanVien nv)
        {
            string sql = @"INSERT INTO NhanVien
                   (MaNV, HoTen, ChucVu, SDT, Email)
                   VALUES
                   (@MaNV, @HoTen, @ChucVu, @SDT, @Email)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
            cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
            cmd.Parameters.AddWithValue("@ChucVu", nv.ChucVu);
            cmd.Parameters.AddWithValue("@SDT", nv.SDT);
            cmd.Parameters.AddWithValue("@Email", nv.Email);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }
        public bool SuaNhanVien(DTO_NhanVien nv)
        {
            string sql = @"UPDATE NhanVien
                   SET HoTen = @HoTen,
                       ChucVu = @ChucVu,
                       SDT = @SDT,
                       Email = @Email
                   WHERE MaNV = @MaNV";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
            cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
            cmd.Parameters.AddWithValue("@ChucVu", nv.ChucVu);
            cmd.Parameters.AddWithValue("@SDT", nv.SDT);
            cmd.Parameters.AddWithValue("@Email", nv.Email);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }
        public bool XoaNhanVien(string maNV)
        {
            string sql = @"DELETE FROM NhanVien
                   WHERE MaNV = @MaNV";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaNV", maNV);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }
        public DataTable TimKiemNhanVien(string maNV, string hoTen)
        {
            string sql = @"SELECT MaNV, HoTen, ChucVu, SDT, Email
                   FROM NhanVien
                   WHERE MaNV LIKE @MaNV
                   AND HoTen LIKE @HoTen";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            da.SelectCommand.Parameters.AddWithValue(
                "@MaNV", "%" + maNV + "%");

            da.SelectCommand.Parameters.AddWithValue(
                "@HoTen", "%" + hoTen + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}