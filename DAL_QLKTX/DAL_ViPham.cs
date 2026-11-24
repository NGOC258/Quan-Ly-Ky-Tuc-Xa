using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLKTX;

namespace DAL_QLKTX
{
    public class DAL_ViPham : DBConnect
    {
        public DataTable LayDanhSachViPham()
        {
            string sql = @"SELECT vp.MaViPham,
                                  vp.MaSV,
                                  sv.HoTen,
                                  vp.MaLoaiViPham,
                                  lvp.TenViPham,
                                  vp.NgayViPham,
                                  vp.LanViPham,
                                  vp.HinhThucXuLy,
                                  vp.GhiChu
                           FROM ViPham vp
                           INNER JOIN SinhVien sv ON vp.MaSV = sv.MaSV
                           INNER JOIN LoaiViPham lvp ON vp.MaLoaiViPham = lvp.MaLoaiViPham
                           ORDER BY vp.NgayViPham DESC, vp.MaViPham DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable LayDanhSachSinhVien()
        {
            string sql = @"SELECT MaSV, HoTen
                           FROM SinhVien
                           ORDER BY HoTen";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable LayDanhSachLoaiViPham()
        {
            string sql = @"SELECT MaLoaiViPham, TenViPham
                           FROM LoaiViPham
                           ORDER BY MaLoaiViPham";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public string TaoMaViPhamMoi()
        {
            string sql = @"SELECT ISNULL(MAX(CAST(SUBSTRING(MaViPham, 4, LEN(MaViPham)) AS INT)), 0)
                           FROM ViPham
                           WHERE MaViPham LIKE 'VPH%'";

            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            int soMoi = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            conn.Close();

            return "VPH" + soMoi.ToString("D3");
        }

        public int LayLanViPhamTiepTheo(string maSV, string maLoaiViPham)
        {
            string sql = @"SELECT COUNT(*)
                           FROM ViPham
                           WHERE MaSV = @MaSV
                           AND MaLoaiViPham = @MaLoaiViPham";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSV", maSV);
            cmd.Parameters.AddWithValue("@MaLoaiViPham", maLoaiViPham);

            conn.Open();
            int soLan = (int)cmd.ExecuteScalar();
            conn.Close();

            return soLan + 1;
        }

        public string LayHinhThucXuLy(string maLoaiViPham, int lanViPham)
        {
            string cotXuLy;

            if (lanViPham == 1)
            {
                cotXuLy = "XuLyLan1";
            }
            else if (lanViPham == 2)
            {
                cotXuLy = "XuLyLan2";
            }
            else
            {
                cotXuLy = "XuLyLan3";
            }

            string sql = "SELECT " + cotXuLy + " FROM LoaiViPham WHERE MaLoaiViPham = @MaLoaiViPham";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaLoaiViPham", maLoaiViPham);

            conn.Open();
            object ketQua = cmd.ExecuteScalar();
            conn.Close();

            if (ketQua == null || ketQua == DBNull.Value)
            {
                return "Xem xét xử lý theo quy định KTX";
            }

            return ketQua.ToString();
        }

        public bool ThemViPham(DTO_ViPham vp)
        {
            string sql = @"INSERT INTO ViPham
                           (MaViPham, MaSV, MaLoaiViPham, NgayViPham, LanViPham, HinhThucXuLy, GhiChu)
                           VALUES
                           (@MaViPham, @MaSV, @MaLoaiViPham, @NgayViPham, @LanViPham, @HinhThucXuLy, @GhiChu)";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaViPham", vp.MaViPham);
            cmd.Parameters.AddWithValue("@MaSV", vp.MaSV);
            cmd.Parameters.AddWithValue("@MaLoaiViPham", vp.MaLoaiViPham);
            cmd.Parameters.AddWithValue("@NgayViPham", vp.NgayViPham);
            cmd.Parameters.AddWithValue("@LanViPham", vp.LanViPham);
            cmd.Parameters.AddWithValue("@HinhThucXuLy", vp.HinhThucXuLy);

            if (string.IsNullOrWhiteSpace(vp.GhiChu))
            {
                cmd.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@GhiChu", vp.GhiChu);
            }

            conn.Open();
            int ketQua = cmd.ExecuteNonQuery();
            conn.Close();

            return ketQua > 0;
        }

        public DataTable TimKiemViPham(string tuKhoa)
        {
            string sql = @"SELECT vp.MaViPham,
                                  vp.MaSV,
                                  sv.HoTen,
                                  vp.MaLoaiViPham,
                                  lvp.TenViPham,
                                  vp.NgayViPham,
                                  vp.LanViPham,
                                  vp.HinhThucXuLy,
                                  vp.GhiChu
                           FROM ViPham vp
                           INNER JOIN SinhVien sv ON vp.MaSV = sv.MaSV
                           INNER JOIN LoaiViPham lvp ON vp.MaLoaiViPham = lvp.MaLoaiViPham
                           WHERE vp.MaViPham LIKE @TuKhoa
                              OR vp.MaSV LIKE @TuKhoa
                              OR sv.HoTen LIKE @TuKhoa
                              OR lvp.TenViPham LIKE @TuKhoa
                              OR vp.HinhThucXuLy LIKE @TuKhoa
                           ORDER BY vp.NgayViPham DESC, vp.MaViPham DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public DataTable TimSinhVienTheoMa(string maSV)
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
    }
}