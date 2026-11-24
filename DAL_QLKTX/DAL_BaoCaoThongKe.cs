using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DAL_QLKTX
{
    public class DAL_BaoCaoThongKe : DBConnect
    {
        // ==================== TỔNG QUAN ====================

        public int TongSinhVien()
        {
            string sql = "SELECT COUNT(*) FROM SinhVien";
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            int kq = (int)cmd.ExecuteScalar();
            conn.Close();

            return kq;
        }

        public int TongPhong()
        {
            string sql = "SELECT COUNT(*) FROM Phong";
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            int kq = (int)cmd.ExecuteScalar();
            conn.Close();

            return kq;
        }

        public int TongGiuongTrong()
        {
            string sql = @"SELECT COUNT(*)
                           FROM Giuong
                           WHERE TrangThaiGiuong = N'Trống'";

            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            int kq = (int)cmd.ExecuteScalar();
            conn.Close();

            return kq;
        }

        public int TongDangKyChoDuyet()
        {
            string sql = @"SELECT COUNT(*)
                           FROM DangKyO
                           WHERE TrangThaiDangKy = N'Chờ duyệt'";

            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            int kq = (int)cmd.ExecuteScalar();
            conn.Close();

            return kq;
        }

        public int TongHoaDonChuaThanhToan()
        {
            string sql = @"SELECT COUNT(*)
                           FROM HoaDon
                           WHERE TrangThaiThanhToan = N'Chưa thanh toán'";

            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            int kq = (int)cmd.ExecuteScalar();
            conn.Close();

            return kq;
        }

        public int TongBaoSuaChoXuLy()
        {
            string sql = @"SELECT COUNT(*)
                           FROM BaoSuaChua
                           WHERE TrangThai = N'Chờ xử lý'";

            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            int kq = (int)cmd.ExecuteScalar();
            conn.Close();

            return kq;
        }

        public int TongViPham()
        {
            string sql = "SELECT COUNT(*) FROM ViPham";
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            int kq = (int)cmd.ExecuteScalar();
            conn.Close();

            return kq;
        }

        // ==================== HÓA ĐƠN ====================

        public DataTable ThongKeHoaDon(int thang, int nam)
        {
            string sql = @"SELECT
                                Thang,
                                Nam,
                                COUNT(*) AS SoHoaDon,
                                SUM(TongTien) AS TongTien,
                                SUM(CASE WHEN TrangThaiThanhToan = N'Đã thanh toán' THEN TongTien ELSE 0 END) AS DaThanhToan,
                                SUM(CASE WHEN TrangThaiThanhToan = N'Chưa thanh toán' THEN TongTien ELSE 0 END) AS ChuaThanhToan
                           FROM HoaDon
                           WHERE Thang = @Thang AND Nam = @Nam
                           GROUP BY Thang, Nam";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@Thang", thang);
            da.SelectCommand.Parameters.AddWithValue("@Nam", nam);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        // ==================== ĐĂNG KÝ Ở ====================

        public DataTable ThongKeDangKyO(int thang, int nam)
        {
            string sql = @"SELECT
                                dk.MaDangKy,
                                dk.MaSV,
                                sv.HoTen,
                                dk.NgayDangKy,
                                dk.TrangThaiDangKy,
                                dk.MaGiuong
                           FROM DangKyO dk
                           INNER JOIN SinhVien sv ON dk.MaSV = sv.MaSV
                           WHERE MONTH(dk.NgayDangKy) = @Thang
                           AND YEAR(dk.NgayDangKy) = @Nam
                           ORDER BY dk.NgayDangKy DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@Thang", thang);
            da.SelectCommand.Parameters.AddWithValue("@Nam", nam);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        // ==================== VI PHẠM ====================

        public DataTable ThongKeViPham(int thang, int nam)
        {
            string sql = @"SELECT
                                vp.MaViPham,
                                vp.MaSV,
                                sv.HoTen,
                                lvp.TenViPham,
                                vp.NgayViPham,
                                vp.LanViPham,
                                vp.HinhThucXuLy,
                                vp.GhiChu
                           FROM ViPham vp
                           INNER JOIN SinhVien sv ON vp.MaSV = sv.MaSV
                           INNER JOIN LoaiViPham lvp ON vp.MaLoaiViPham = lvp.MaLoaiViPham
                           WHERE MONTH(vp.NgayViPham) = @Thang
                           AND YEAR(vp.NgayViPham) = @Nam
                           ORDER BY vp.NgayViPham DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@Thang", thang);
            da.SelectCommand.Parameters.AddWithValue("@Nam", nam);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        // ==================== BÁO SỬA CHỮA ====================

        public DataTable ThongKeBaoSuaChua(int thang, int nam)
        {
            string sql = @"SELECT
                                bs.MaBaoSua,
                                bs.MaSV,
                                sv.HoTen,
                                bs.MaPhong,
                                bs.MaGiuong,
                                bs.LoaiSuCo,
                                bs.NgayBao,
                                bs.TrangThai
                           FROM BaoSuaChua bs
                           INNER JOIN SinhVien sv ON bs.MaSV = sv.MaSV
                           WHERE MONTH(bs.NgayBao) = @Thang
                           AND YEAR(bs.NgayBao) = @Nam
                           ORDER BY bs.NgayBao DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@Thang", thang);
            da.SelectCommand.Parameters.AddWithValue("@Nam", nam);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        // ==================== PHÒNG - GIƯỜNG ====================

        public DataTable ThongKePhongGiuong()
        {
            string sql = @"SELECT
                                p.MaPhong,
                                p.TenPhong,
                                tn.TenToaNha,
                                lp.TenLoaiPhong,
                                COUNT(g.MaGiuong) AS TongGiuong,
                                SUM(CASE WHEN g.TrangThaiGiuong = N'Trống' THEN 1 ELSE 0 END) AS GiuongTrong,
                                SUM(CASE WHEN g.TrangThaiGiuong = N'Đã có người' THEN 1 ELSE 0 END) AS GiuongDaCoNguoi,
                                p.TrangThaiPhong
                           FROM Phong p
                           INNER JOIN ToaNha tn ON p.MaToaNha = tn.MaToaNha
                           INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                           LEFT JOIN Giuong g ON p.MaPhong = g.MaPhong
                           GROUP BY p.MaPhong, p.TenPhong, tn.TenToaNha, lp.TenLoaiPhong, p.TrangThaiPhong
                           ORDER BY tn.TenToaNha, p.TenPhong";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        // ==================== THÔNG BÁO DASHBOARD ====================

        public DataTable LayThongBaoMoiNhat()
        {
            string sql = @"SELECT TOP 5
                                dk.MaDangKy,
                                dk.MaSV,
                                sv.HoTen,
                                dk.MaGiuong,
                                dk.NgayDangKy,
                                dk.TrangThaiDangKy
                           FROM DangKyO dk
                           INNER JOIN SinhVien sv ON dk.MaSV = sv.MaSV
                           WHERE dk.TrangThaiDangKy = N'Chờ duyệt'
                           ORDER BY dk.NgayDangKy DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}