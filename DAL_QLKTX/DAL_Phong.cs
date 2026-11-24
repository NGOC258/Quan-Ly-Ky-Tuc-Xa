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
    public class DAL_Phong : DBConnect
    {
        public DataTable LayDanhSachPhong()
        {
            string sql = @"SELECT P.MaPhong,
                                  P.MaToaNha,
                                  T.TenToaNha,
                                  P.MaLoaiPhong,
                                  L.TenLoaiPhong,
                                  P.TenPhong,
                                  P.TrangThaiPhong
                           FROM Phong P
                           JOIN ToaNha T 
                                ON P.MaToaNha = T.MaToaNha
                           JOIN LoaiPhong L
                                ON P.MaLoaiPhong = L.MaLoaiPhong";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable LayDanhSachToaNha()
        {
            string sql = @"SELECT MaToaNha, TenToaNha
                           FROM ToaNha";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable LayDanhSachLoaiPhong()
        {
            string sql = @"SELECT MaLoaiPhong, TenLoaiPhong
                           FROM LoaiPhong";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public bool KiemTraMaPhong(string maPhong)
        {
            string sql = @"SELECT COUNT(*) 
                   FROM Phong 
                   WHERE MaPhong = @MaPhong";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaPhong", maPhong);

            conn.Open();
            int soLuong = (int)cmd.ExecuteScalar();
            conn.Close();

            return soLuong > 0;
        }

        public bool ThemPhong(DTO_Phong phong)
        {
            string sql = @"INSERT INTO Phong
                   (MaPhong, MaToaNha, MaLoaiPhong, TenPhong, TrangThaiPhong)
                   VALUES
                   (@MaPhong, @MaToaNha, @MaLoaiPhong, @TenPhong, @TrangThaiPhong)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaPhong", phong.MaPhong);
            cmd.Parameters.AddWithValue("@MaToaNha", phong.MaToaNha);
            cmd.Parameters.AddWithValue("@MaLoaiPhong", phong.MaLoaiPhong);
            cmd.Parameters.AddWithValue("@TenPhong", phong.TenPhong);
            cmd.Parameters.AddWithValue("@TrangThaiPhong", phong.TrangThaiPhong);

            conn.Open();
            int ketQua = cmd.ExecuteNonQuery();
            conn.Close();

            return ketQua > 0;
        }

        public bool SuaPhong(DTO_Phong phong)
        {
            string sql = @"UPDATE Phong
                   SET MaToaNha = @MaToaNha,
                       MaLoaiPhong = @MaLoaiPhong,
                       TenPhong = @TenPhong,
                       TrangThaiPhong = @TrangThaiPhong
                   WHERE MaPhong = @MaPhong";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaPhong", phong.MaPhong);
            cmd.Parameters.AddWithValue("@MaToaNha", phong.MaToaNha);
            cmd.Parameters.AddWithValue("@MaLoaiPhong", phong.MaLoaiPhong);
            cmd.Parameters.AddWithValue("@TenPhong", phong.TenPhong);
            cmd.Parameters.AddWithValue("@TrangThaiPhong", phong.TrangThaiPhong);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }

        public bool XoaPhong(string maPhong)
        {
            string sql = @"DELETE FROM Phong
                   WHERE MaPhong = @MaPhong";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaPhong", maPhong);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }

        public DataTable TimKiemPhong(string maPhong, string tenPhong)
        {
            string sql = @"SELECT P.MaPhong,
                          P.MaToaNha,
                          T.TenToaNha,
                          P.MaLoaiPhong,
                          L.TenLoaiPhong,
                          P.TenPhong,
                          P.TrangThaiPhong
                   FROM Phong P
                   JOIN ToaNha T
                        ON P.MaToaNha = T.MaToaNha
                   JOIN LoaiPhong L
                        ON P.MaLoaiPhong = L.MaLoaiPhong
                   WHERE P.MaPhong LIKE @MaPhong
                   AND P.TenPhong LIKE @TenPhong";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            da.SelectCommand.Parameters.AddWithValue(
                "@MaPhong", "%" + maPhong + "%");

            da.SelectCommand.Parameters.AddWithValue(
                "@TenPhong", "%" + tenPhong + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public string TaoMaPhongMoi(string maToaNha)
        {
            string kyTuToa = "";
            int soBatDau = 0;

            if (maToaNha == "TN01")
            {
                kyTuToa = "I";
                soBatDau = 101;
            }
            else if (maToaNha == "TN02")
            {
                kyTuToa = "G";
                soBatDau = 201;
            }

            string sql = @"SELECT ISNULL(MAX(CAST(SUBSTRING(MaPhong, 2, LEN(MaPhong) - 1) AS INT)), @SoBatDau - 1) + 1
                   FROM Phong
                   WHERE MaToaNha = @MaToaNha";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaToaNha", maToaNha);
            cmd.Parameters.AddWithValue("@SoBatDau", soBatDau);

            conn.Open();
            int soMoi = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();

            return kyTuToa + soMoi;
        }
    }
}