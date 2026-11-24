using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DTO_QLKTX
{
    public class DTO_DangKyO
    {
        public string MaDangKy { get; set; }
        public string MaSV { get; set; }
        public string MaGiuong { get; set; }
        public string DoiTuongUuTien { get; set; }
        public DateTime NgayDangKy { get; set; }
        public string TrangThaiDangKy { get; set; }

        public DTO_DangKyO()
        {
        }

        public DTO_DangKyO(string maDangKy, string maSV, string maGiuong, string doiTuongUuTien, DateTime ngayDangKy, string trangThaiDangKy)
        {
            MaDangKy = maDangKy;
            MaSV = maSV;
            MaGiuong = maGiuong;
            DoiTuongUuTien = doiTuongUuTien;
            NgayDangKy = ngayDangKy;
            TrangThaiDangKy = trangThaiDangKy;
        }
    }
}