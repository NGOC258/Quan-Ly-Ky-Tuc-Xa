using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLKTX
{
    public class DAL_TroLyKTX : DBConnect
    {
        public DataTable LayChoOHienTai(string maSV)
        {
            string sql = @"SELECT TOP 1
                                sv.MaSV,
                                sv.HoTen,
                                tn.TenToaNha,
                                p.TenPhong,
                                g.SoHieuGiuong
                           FROM DangKyO dk
                           INNER JOIN SinhVien sv ON dk.MaSV = sv.MaSV
                           INNER JOIN Giuong g ON dk.MaGiuong = g.MaGiuong
                           INNER JOIN Phong p ON g.MaPhong = p.MaPhong
                           INNER JOIN ToaNha tn ON p.MaToaNha = tn.MaToaNha
                           WHERE dk.MaSV = @MaSV
                           AND dk.TrangThaiDangKy = N'Đã duyệt'
                           AND dk.MaGiuong IS NOT NULL
                           ORDER BY dk.NgayDangKy DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaSV", maSV);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable LayDangKyMoiNhat(string maSV)
        {
            string sql = @"SELECT TOP 1
                                dk.MaDangKy,
                                dk.NgayDangKy,
                                dk.TrangThaiDangKy,
                                dk.DoiTuongUuTien,
                                dk.MaGiuong
                           FROM DangKyO dk
                           WHERE dk.MaSV = @MaSV
                           ORDER BY dk.NgayDangKy DESC, dk.MaDangKy DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaSV", maSV);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable LayHopDongHienTai(string maSV)
        {
            string sql = @"SELECT TOP 1
                                hd.MaHopDong,
                                hd.NgayBatDau,
                                hd.NgayKetThuc,
                                hd.TrangThaiHopDong
                           FROM HopDong hd
                           INNER JOIN DangKyO dk ON hd.MaDangKy = dk.MaDangKy
                           WHERE dk.MaSV = @MaSV
                           ORDER BY hd.NgayBatDau DESC, hd.MaHopDong DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaSV", maSV);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable LayHoaDonChuaThanhToan(string maSV)
        {
            string sql = @"SELECT
                                hd.MaHoaDon,
                                hd.Thang,
                                hd.Nam,
                                hd.TongTien,
                                hd.TrangThaiThanhToan
                           FROM HoaDon hd
                           INNER JOIN HopDong hdo ON hd.MaHopDong = hdo.MaHopDong
                           INNER JOIN DangKyO dk ON hdo.MaDangKy = dk.MaDangKy
                           WHERE dk.MaSV = @MaSV
                           AND hd.TrangThaiThanhToan = N'Chưa thanh toán'
                           ORDER BY hd.Nam DESC, hd.Thang DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaSV", maSV);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable LayBaoSuaMoiNhat(string maSV)
        {
            string sql = @"SELECT TOP 1
                                MaBaoSua,
                                LoaiSuCo,
                                MoTa,
                                NgayBao,
                                TrangThai
                           FROM BaoSuaChua
                           WHERE MaSV = @MaSV
                           ORDER BY NgayBao DESC, MaBaoSua DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaSV", maSV);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable TimNoiQuy(string tuKhoa)
        {
            string sql = @"SELECT
                                MaLoaiViPham,
                                TenViPham,
                                XuLyLan1,
                                XuLyLan2,
                                XuLyLan3,
                                GhiChu
                           FROM LoaiViPham
                           WHERE TenViPham LIKE @TuKhoa
                           ORDER BY MaLoaiViPham";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable LayLichSuViPham(string maSV)
        {
            string sql = @"SELECT
                                vp.MaViPham,
                                lvp.TenViPham,
                                vp.NgayViPham,
                                vp.LanViPham,
                                vp.HinhThucXuLy,
                                vp.GhiChu
                           FROM ViPham vp
                           INNER JOIN LoaiViPham lvp ON vp.MaLoaiViPham = lvp.MaLoaiViPham
                           WHERE vp.MaSV = @MaSV
                           ORDER BY vp.NgayViPham DESC, vp.MaViPham DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaSV", maSV);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}