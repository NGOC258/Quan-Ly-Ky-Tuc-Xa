using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLKTX
{
    public class DAL_BaoSuaChuaNhanVien : DBConnect
    {
        public DataTable LayDanhSachBaoSua()
        {
            string sql = @"SELECT bs.MaBaoSua,
                                  bs.MaSV,
                                  sv.HoTen,
                                  p.TenPhong,
                                  g.SoHieuGiuong,
                                  bs.LoaiSuCo,
                                  bs.MoTa,
                                  bs.NgayBao,
                                  bs.TrangThai
                           FROM BaoSuaChua bs
                           INNER JOIN SinhVien sv ON bs.MaSV = sv.MaSV
                           INNER JOIN Phong p ON bs.MaPhong = p.MaPhong
                           LEFT JOIN Giuong g ON bs.MaGiuong = g.MaGiuong
                           ORDER BY bs.NgayBao DESC, bs.MaBaoSua DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public bool CapNhatTrangThai(string maBaoSua, string trangThai)
        {
            string sql = @"UPDATE BaoSuaChua
                           SET TrangThai = @TrangThai
                           WHERE MaBaoSua = @MaBaoSua";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaBaoSua", maBaoSua);
            cmd.Parameters.AddWithValue("@TrangThai", trangThai);

            conn.Open();
            int ketQua = cmd.ExecuteNonQuery();
            conn.Close();

            return ketQua > 0;
        }

        public DataTable TimKiemBaoSua(string tuKhoa)
        {
            string sql = @"SELECT bs.MaBaoSua,
                                  bs.MaSV,
                                  sv.HoTen,
                                  p.TenPhong,
                                  g.SoHieuGiuong,
                                  bs.LoaiSuCo,
                                  bs.MoTa,
                                  bs.NgayBao,
                                  bs.TrangThai
                           FROM BaoSuaChua bs
                           INNER JOIN SinhVien sv ON bs.MaSV = sv.MaSV
                           INNER JOIN Phong p ON bs.MaPhong = p.MaPhong
                           LEFT JOIN Giuong g ON bs.MaGiuong = g.MaGiuong
                           WHERE bs.MaBaoSua LIKE @TuKhoa
                              OR bs.MaSV LIKE @TuKhoa
                              OR sv.HoTen LIKE @TuKhoa
                              OR p.TenPhong LIKE @TuKhoa
                              OR bs.LoaiSuCo LIKE @TuKhoa
                              OR bs.TrangThai LIKE @TuKhoa
                           ORDER BY bs.NgayBao DESC, bs.MaBaoSua DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public bool SuaBaoSua(string maBaoSua, string loaiSuCo, string moTa, DateTime ngayBao, string trangThai)
        {
            string sql = @"UPDATE BaoSuaChua
                   SET LoaiSuCo = @LoaiSuCo,
                       MoTa = @MoTa,
                       NgayBao = @NgayBao,
                       TrangThai = @TrangThai
                   WHERE MaBaoSua = @MaBaoSua";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaBaoSua", maBaoSua);
            cmd.Parameters.AddWithValue("@LoaiSuCo", loaiSuCo);
            cmd.Parameters.AddWithValue("@MoTa", moTa);
            cmd.Parameters.AddWithValue("@NgayBao", ngayBao);
            cmd.Parameters.AddWithValue("@TrangThai", trangThai);

            conn.Open();
            int ketQua = cmd.ExecuteNonQuery();
            conn.Close();

            return ketQua > 0;
        }

        public bool XoaBaoSua(string maBaoSua)
        {
            string sql = @"DELETE FROM BaoSuaChua
                   WHERE MaBaoSua = @MaBaoSua";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaBaoSua", maBaoSua);

            conn.Open();
            int ketQua = cmd.ExecuteNonQuery();
            conn.Close();

            return ketQua > 0;
        }
    }
}