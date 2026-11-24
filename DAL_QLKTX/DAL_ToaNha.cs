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
    public class DAL_ToaNha : DBConnect
    {
        public DataTable LayDanhSachToaNha()
        {
            string sql = @"SELECT MaToaNha, TenToaNha, SoTang, DiaChi, MoTa, GioiTinhKhu
                           FROM ToaNha";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public bool ThemToaNha(DTO_ToaNha toaNha)
        {
            string sql = @"INSERT INTO ToaNha
                           (MaToaNha, TenToaNha, SoTang, DiaChi, MoTa, GioiTinhKhu)
                           VALUES
                           (@MaToaNha, @TenToaNha, @SoTang, @DiaChi, @MoTa, @GioiTinhKhu)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaToaNha", toaNha.MaToaNha);
            cmd.Parameters.AddWithValue("@TenToaNha", toaNha.TenToaNha);
            cmd.Parameters.AddWithValue("@SoTang", toaNha.SoTang);
            cmd.Parameters.AddWithValue("@DiaChi", toaNha.DiaChi);
            cmd.Parameters.AddWithValue("@MoTa", toaNha.MoTa);
            cmd.Parameters.AddWithValue("@GioiTinhKhu", toaNha.GioiTinhKhu);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }

        public bool SuaToaNha(DTO_ToaNha toaNha)
        {
            string sql = @"UPDATE ToaNha
                           SET TenToaNha = @TenToaNha,
                               SoTang = @SoTang,
                               DiaChi = @DiaChi,
                               MoTa = @MoTa,
                               GioiTinhKhu = @GioiTinhKhu
                           WHERE MaToaNha = @MaToaNha";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaToaNha", toaNha.MaToaNha);
            cmd.Parameters.AddWithValue("@TenToaNha", toaNha.TenToaNha);
            cmd.Parameters.AddWithValue("@SoTang", toaNha.SoTang);
            cmd.Parameters.AddWithValue("@DiaChi", toaNha.DiaChi);
            cmd.Parameters.AddWithValue("@MoTa", toaNha.MoTa);
            cmd.Parameters.AddWithValue("@GioiTinhKhu", toaNha.GioiTinhKhu);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }

        public bool XoaToaNha(string maToaNha)
        {
            string sql = "DELETE FROM ToaNha WHERE MaToaNha = @MaToaNha";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaToaNha", maToaNha);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }

        public DataTable TimKiemToaNha(string tuKhoa)
        {
            string sql = @"SELECT MaToaNha, TenToaNha, SoTang, DiaChi, MoTa, GioiTinhKhu
                           FROM ToaNha
                           WHERE MaToaNha LIKE @TuKhoa
                           OR TenToaNha LIKE @TuKhoa
                           OR GioiTinhKhu LIKE @TuKhoa";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            da.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}