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
    public class DAL_LoaiPhong : DBConnect
    {
        public DataTable LayDanhSachLoaiPhong()
        {
            string sql = "SELECT * FROM LoaiPhong";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public bool ThemLoaiPhong(DTO_LoaiPhong loaiPhong)
        {
            string sql = @"INSERT INTO LoaiPhong
                   (MaLoaiPhong, TenLoaiPhong, SoNguoiToiDa, DonGia)
                   VALUES
                   (@MaLoaiPhong, @TenLoaiPhong, @SoNguoiToiDa, @DonGia)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaLoaiPhong", loaiPhong.MaLoaiPhong);
            cmd.Parameters.AddWithValue("@TenLoaiPhong", loaiPhong.TenLoaiPhong);
            cmd.Parameters.AddWithValue("@SoNguoiToiDa", loaiPhong.SoNguoiToiDa);
            cmd.Parameters.AddWithValue("@DonGia", loaiPhong.DonGia);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }

        public bool KiemTraMaLoaiPhong(string maLoaiPhong)
        {
            string sql = @"SELECT COUNT(*)
                   FROM LoaiPhong
                   WHERE MaLoaiPhong = @MaLoaiPhong";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaLoaiPhong", maLoaiPhong);

            conn.Open();

            int soLuong = (int)cmd.ExecuteScalar();

            conn.Close();

            return soLuong > 0;
        }

        public bool SuaLoaiPhong(DTO_LoaiPhong loaiPhong)
        {
            string sql = @"UPDATE LoaiPhong
                   SET TenLoaiPhong = @TenLoaiPhong,
                       SoNguoiToiDa = @SoNguoiToiDa,
                       DonGia = @DonGia
                   WHERE MaLoaiPhong = @MaLoaiPhong";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaLoaiPhong", loaiPhong.MaLoaiPhong);
            cmd.Parameters.AddWithValue("@TenLoaiPhong", loaiPhong.TenLoaiPhong);
            cmd.Parameters.AddWithValue("@SoNguoiToiDa", loaiPhong.SoNguoiToiDa);
            cmd.Parameters.AddWithValue("@DonGia", loaiPhong.DonGia);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }


        public bool XoaLoaiPhong(string maLoaiPhong)
        {
            string sql = @"DELETE FROM LoaiPhong
                   WHERE MaLoaiPhong = @MaLoaiPhong";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaLoaiPhong", maLoaiPhong);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }

        public DataTable TimKiemLoaiPhong(string maLoaiPhong, string tenLoaiPhong)
        {
            string sql = @"SELECT *
                   FROM LoaiPhong
                   WHERE MaLoaiPhong LIKE @MaLoaiPhong
                   AND TenLoaiPhong LIKE @TenLoaiPhong";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            da.SelectCommand.Parameters.AddWithValue(
                "@MaLoaiPhong", "%" + maLoaiPhong + "%");

            da.SelectCommand.Parameters.AddWithValue(
                "@TenLoaiPhong", "%" + tenLoaiPhong + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public string TaoMaLoaiPhongMoi()
        {
            string sql = @"SELECT ISNULL(MAX(CAST(SUBSTRING(MaLoaiPhong, 3, LEN(MaLoaiPhong) - 2) AS INT)), 0) + 1
                   FROM LoaiPhong";

            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            int soMoi = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();

            return "LP" + soMoi.ToString("00");
        }
    }
}

