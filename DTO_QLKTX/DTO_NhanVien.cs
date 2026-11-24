using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DTO_QLKTX
{
    public class DTO_NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string ChucVu { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }

        public DTO_NhanVien()
        {
        }

        public DTO_NhanVien(string maNV,
                            string hoTen,
                            string chucVu,
                            string sdt,
                            string email)
        {
            MaNV = maNV;
            HoTen = hoTen;
            ChucVu = chucVu;
            SDT = sdt;
            Email = email;
        }
    }
}