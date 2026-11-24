using System.Data;
using System.Data.SqlClient;

namespace DAL_QLKTX
{
    public class DAL_ThongTinCaNhanSinhVien : DBConnect
    {
        public DataTable LayThongTinSinhVien(string maSV)
        {
            string sql = @"
                SELECT MaSV,
                       HoTen,
                       NgaySinh,
                       GioiTinh,
                       Lop,
                       Khoa,
                       SDT,
                       Email,
                       DiaChi
                FROM SinhVien
                WHERE MaSV = @MaSV";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaSV", maSV);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public bool CapNhatThongTin(string maSV, string sdt, string diaChi)
        {
            string sql = @"
                UPDATE SinhVien
                SET SDT = @SDT,
                    DiaChi = @DiaChi
                WHERE MaSV = @MaSV";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaSV", maSV);
            cmd.Parameters.AddWithValue("@SDT", sdt);
            cmd.Parameters.AddWithValue("@DiaChi", diaChi);

            conn.Open();

            int ketQua = cmd.ExecuteNonQuery();

            conn.Close();

            return ketQua > 0;
        }
    }
}