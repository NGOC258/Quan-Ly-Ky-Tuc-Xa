using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace DTO_QLKTX
{
    public class DTO_SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string Lop { get; set; }
        public string Khoa { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string DoiTuongUuTien { get; set; }

        public DTO_SinhVien()
        {
        }

        public DTO_SinhVien(string maSV, string hoTen,
                            DateTime ngaySinh, string gioiTinh,
                            string lop, string khoa,
                            string sdt, string email,
                            string diaChi, string doiTuongUuTien)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            Lop = lop;
            Khoa = khoa;
            SDT = sdt;
            Email = email;
            DiaChi = diaChi;
            DoiTuongUuTien = doiTuongUuTien;
        }
    }
}
