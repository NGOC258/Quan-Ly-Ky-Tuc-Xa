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
    public class DAL_Giuong : DBConnect
    {
        public DataTable LayDanhSachGiuong()
        {
            string sql = @"SELECT G.MaGiuong,
                                  G.MaPhong,
                                  P.TenPhong,
                                  G.SoHieuGiuong,
                                  G.TrangThaiGiuong
                           FROM Giuong G
                           JOIN Phong P
                                ON G.MaPhong = P.MaPhong";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable LayDanhSachPhong()
        {
            string sql = @"SELECT MaPhong, TenPhong
                           FROM Phong";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public bool KiemTraMaGiuong(string maGiuong)
        {
            string sql = @"SELECT COUNT(*)
                   FROM Giuong
                   WHERE MaGiuong = @MaGiuong";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaGiuong", maGiuong);

            conn.Open();

            int soLuong = (int)cmd.ExecuteScalar();

            conn.Close();

            return soLuong > 0;
        }

        public bool ThemGiuong(DTO_Giuong giuong)
        {
            string sql = @"INSERT INTO Giuong
                   (MaGiuong, MaPhong, SoHieuGiuong, TrangThaiGiuong)
                   VALUES
                   (@MaGiuong, @MaPhong, @SoHieuGiuong, @TrangThaiGiuong)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaGiuong", giuong.MaGiuong);
            cmd.Parameters.AddWithValue("@MaPhong", giuong.MaPhong);
            cmd.Parameters.AddWithValue("@SoHieuGiuong", giuong.SoHieuGiuong);
            cmd.Parameters.AddWithValue("@TrangThaiGiuong", giuong.TrangThaiGiuong);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }

        public bool SuaGiuong(DTO_Giuong giuong)
        {
            string sql = @"UPDATE Giuong
                   SET MaPhong = @MaPhong,
                       SoHieuGiuong = @SoHieuGiuong,
                       TrangThaiGiuong = @TrangThaiGiuong
                   WHERE MaGiuong = @MaGiuong";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaGiuong", giuong.MaGiuong);
            cmd.Parameters.AddWithValue("@MaPhong", giuong.MaPhong);
            cmd.Parameters.AddWithValue("@SoHieuGiuong", giuong.SoHieuGiuong);
            cmd.Parameters.AddWithValue("@TrangThaiGiuong", giuong.TrangThaiGiuong);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }

        public bool XoaGiuong(string maGiuong)
        {
            string sql = @"DELETE FROM Giuong
                   WHERE MaGiuong = @MaGiuong";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaGiuong", maGiuong);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }

        public DataTable TimKiemGiuong(string maGiuong, string soHieuGiuong)
        {
            string sql = @"SELECT G.MaGiuong,
                          G.MaPhong,
                          P.TenPhong,
                          G.SoHieuGiuong,
                          G.TrangThaiGiuong
                   FROM Giuong G
                   JOIN Phong P
                        ON G.MaPhong = P.MaPhong
                   WHERE G.MaGiuong LIKE @MaGiuong
                   AND G.SoHieuGiuong LIKE @SoHieuGiuong";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            da.SelectCommand.Parameters.AddWithValue(
                "@MaGiuong", "%" + maGiuong + "%");

            da.SelectCommand.Parameters.AddWithValue(
                "@SoHieuGiuong", "%" + soHieuGiuong + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public string TaoMaGiuongMoi()
        {
            string sql = @"SELECT ISNULL(MAX(CAST(SUBSTRING(MaGiuong, 2, LEN(MaGiuong) - 1) AS INT)), 0) + 1
                   FROM Giuong";

            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            int soMoi = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();

            return "G" + soMoi.ToString("000");
        }
    }
}