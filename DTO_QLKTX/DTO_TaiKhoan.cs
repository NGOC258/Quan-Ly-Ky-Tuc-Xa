using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLKTX
{
    namespace DTO_QLKTX
    {
        public class DTO_TaiKhoan
        {
            public string MaTaiKhoan { get; set; }
            public string TenDangNhap { get; set; }
            public string MatKhau { get; set; }
            public string VaiTro { get; set; }
            public string TrangThai { get; set; }
            public string MaSV { get; set; }
            public string MaNV { get; set; }

            public DTO_TaiKhoan()
            {

            }

            public DTO_TaiKhoan(string tenDangNhap, string matKhau)
            {
                TenDangNhap = tenDangNhap;
                MatKhau = matKhau;
            }
        }
    }
}
