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
    public class DAL_BaoSuaChuaSinhVien : DBConnect
    {
        public DataTable LayThongTinChoOHienTai(string maSV)
        {
            string sql = @"SELECT TOP 1
                                  p.MaPhong,
                                  p.TenPhong,
                                  g.MaGiuong,
                                  g.SoHieuGiuong
                           FROM DangKyO dk
                           INNER JOIN Giuong g ON dk.MaGiuong = g.MaGiuong
                           INNER JOIN Phong p ON g.MaPhong = p.MaPhong
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

        public DataTable LayBaoSuaCuaSinhVien(string maSV)
        {
            string sql = @"SELECT bs.MaBaoSua,
                                  p.TenPhong,
                                  g.SoHieuGiuong,
                                  bs.LoaiSuCo,
                                  bs.MoTa,
                                  bs.NgayBao,
                                  bs.TrangThai
                           FROM BaoSuaChua bs
                           INNER JOIN Phong p ON bs.MaPhong = p.MaPhong
                           LEFT JOIN Giuong g ON bs.MaGiuong = g.MaGiuong
                           WHERE bs.MaSV = @MaSV
                           ORDER BY bs.NgayBao DESC, bs.MaBaoSua DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaSV", maSV);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public string TaoMaBaoSuaMoi()
        {
            string sql = @"SELECT ISNULL(MAX(CAST(SUBSTRING(MaBaoSua, 3, LEN(MaBaoSua)) AS INT)), 0)
                           FROM BaoSuaChua
                           WHERE MaBaoSua LIKE 'BS%'";

            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            int soMoi = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            conn.Close();

            return "BS" + soMoi.ToString("D3");
        }

        public bool ThemBaoSua(DTO_BaoSuaChua bs)
        {
            string sql = @"INSERT INTO BaoSuaChua
                           (MaBaoSua, MaSV, MaPhong, MaGiuong, LoaiSuCo, MoTa, NgayBao, TrangThai)
                           VALUES
                           (@MaBaoSua, @MaSV, @MaPhong, @MaGiuong, @LoaiSuCo, @MoTa, @NgayBao, N'Chờ xử lý')";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaBaoSua", bs.MaBaoSua);
            cmd.Parameters.AddWithValue("@MaSV", bs.MaSV);
            cmd.Parameters.AddWithValue("@MaPhong", bs.MaPhong);
            cmd.Parameters.AddWithValue("@MaGiuong", bs.MaGiuong);
            cmd.Parameters.AddWithValue("@LoaiSuCo", bs.LoaiSuCo);
            cmd.Parameters.AddWithValue("@MoTa", bs.MoTa);
            cmd.Parameters.AddWithValue("@NgayBao", bs.NgayBao);

            conn.Open();
            int ketQua = cmd.ExecuteNonQuery();
            conn.Close();

            return ketQua > 0;
        }
    }
}
