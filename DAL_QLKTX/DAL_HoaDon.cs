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
    public class DAL_HoaDon : DBConnect
    {
        public DataTable LayDanhSachHoaDon()
        {
            string sql = @"SELECT MaHoaDon,
                                  MaHopDong,
                                  Thang,
                                  Nam,
                                  TienPhong,
                                  TienDien,
                                  TienNuoc,
                                  PhiDichVu,
                                  TongTien,
                                  NgayLap,
                                  TrangThaiThanhToan
                           FROM HoaDon";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable LayDanhSachHopDong()
        {
            string sql = @"SELECT MaHopDong
                   FROM HopDong
                   WHERE TrangThaiHopDong = N'Đang hiệu lực'
                   ORDER BY MaHopDong";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public bool KiemTraMaHoaDon(string maHoaDon)
        {
            string sql = @"SELECT COUNT(*)
                   FROM HoaDon
                   WHERE MaHoaDon = @MaHoaDon";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

            conn.Open();
            int soLuong = (int)cmd.ExecuteScalar();
            conn.Close();

            return soLuong > 0;
        }

        public bool KiemTraHoaDonTheoThang(string maHopDong, int thang, int nam)
        {
            string sql = @"SELECT COUNT(*)
                   FROM HoaDon
                   WHERE MaHopDong = @MaHopDong
                   AND Thang = @Thang
                   AND Nam = @Nam";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaHopDong", maHopDong);
            cmd.Parameters.AddWithValue("@Thang", thang);
            cmd.Parameters.AddWithValue("@Nam", nam);

            conn.Open();
            int soLuong = (int)cmd.ExecuteScalar();
            conn.Close();

            return soLuong > 0;
        }

        public bool ThemHoaDon(DTO_HoaDon hd)
        {
            string sql = @"INSERT INTO HoaDon
                   (MaHoaDon, MaHopDong, Thang, Nam,
                    TienPhong, TienDien, TienNuoc, PhiDichVu,
                    TongTien, NgayLap, TrangThaiThanhToan)
                   VALUES
                   (@MaHoaDon, @MaHopDong, @Thang, @Nam,
                    @TienPhong, @TienDien, @TienNuoc, @PhiDichVu,
                    @TongTien, @NgayLap, @TrangThaiThanhToan)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaHoaDon", hd.MaHoaDon);
            cmd.Parameters.AddWithValue("@MaHopDong", hd.MaHopDong);
            cmd.Parameters.AddWithValue("@Thang", hd.Thang);
            cmd.Parameters.AddWithValue("@Nam", hd.Nam);

            cmd.Parameters.AddWithValue("@TienPhong", hd.TienPhong);
            cmd.Parameters.AddWithValue("@TienDien", hd.TienDien);
            cmd.Parameters.AddWithValue("@TienNuoc", hd.TienNuoc);
            cmd.Parameters.AddWithValue("@PhiDichVu", hd.PhiDichVu);
            cmd.Parameters.AddWithValue("@TongTien", hd.TongTien);

            cmd.Parameters.AddWithValue("@NgayLap", hd.NgayLap);
            cmd.Parameters.AddWithValue(
                "@TrangThaiThanhToan",
                hd.TrangThaiThanhToan);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }
        public bool SuaHoaDon(DTO_HoaDon hd)
        {
            string sql = @"UPDATE HoaDon
                   SET MaHopDong = @MaHopDong,
                       Thang = @Thang,
                       Nam = @Nam,
                       TienPhong = @TienPhong,
                       TienDien = @TienDien,
                       TienNuoc = @TienNuoc,
                       PhiDichVu = @PhiDichVu,
                       TongTien = @TongTien,
                       NgayLap = @NgayLap,
                       TrangThaiThanhToan = @TrangThaiThanhToan
                   WHERE MaHoaDon = @MaHoaDon";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaHoaDon", hd.MaHoaDon);
            cmd.Parameters.AddWithValue("@MaHopDong", hd.MaHopDong);
            cmd.Parameters.AddWithValue("@Thang", hd.Thang);
            cmd.Parameters.AddWithValue("@Nam", hd.Nam);
            cmd.Parameters.AddWithValue("@TienPhong", hd.TienPhong);
            cmd.Parameters.AddWithValue("@TienDien", hd.TienDien);
            cmd.Parameters.AddWithValue("@TienNuoc", hd.TienNuoc);
            cmd.Parameters.AddWithValue("@PhiDichVu", hd.PhiDichVu);
            cmd.Parameters.AddWithValue("@TongTien", hd.TongTien);
            cmd.Parameters.AddWithValue("@NgayLap", hd.NgayLap);
            cmd.Parameters.AddWithValue(
                "@TrangThaiThanhToan",
                hd.TrangThaiThanhToan);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }
        public DataTable TimKiemHoaDon(string tuKhoa)
        {
            string sql = @"SELECT MaHoaDon,
                          MaHopDong,
                          Thang,
                          Nam,
                          TienPhong,
                          TienDien,
                          TienNuoc,
                          PhiDichVu,
                          TongTien,
                          NgayLap,
                          TrangThaiThanhToan
                   FROM HoaDon
                   WHERE MaHoaDon LIKE @TuKhoa
                      OR MaHopDong LIKE @TuKhoa
                   ORDER BY MaHoaDon";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public bool XoaHoaDon(string maHoaDon)
        {
            string sql = @"DELETE FROM HoaDon
                   WHERE MaHoaDon = @MaHoaDon";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }
        public DataTable LayHopDongKhiSua(string maHopDong)
        {
            string sql = @"SELECT MaHopDong
                   FROM HopDong
                   WHERE TrangThaiHopDong = N'Đang hiệu lực'
                   OR MaHopDong = @MaHopDong
                   ORDER BY MaHopDong";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaHopDong", maHopDong);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public string TaoMaHoaDonMoi()
        {
            string sql = @"
        SELECT ISNULL(MAX(
            CASE
                WHEN MaHoaDon LIKE 'HDB%' AND TRY_CAST(SUBSTRING(MaHoaDon, 4, LEN(MaHoaDon)) AS INT) IS NOT NULL
                THEN TRY_CAST(SUBSTRING(MaHoaDon, 4, LEN(MaHoaDon)) AS INT)
                ELSE 0
            END
        ), 0)
        FROM HoaDon";

            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            int soLonNhat = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();

            return "HDB" + (soLonNhat + 1).ToString("D3");
        }
    }
}
