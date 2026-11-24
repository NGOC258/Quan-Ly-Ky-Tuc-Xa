using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLKTX
{
    public class DTO_LoaiPhong
    {
        public string MaLoaiPhong { get; set; }
        public string TenLoaiPhong { get; set; }
        public int SoNguoiToiDa { get; set; }
        public decimal DonGia { get; set; }

        public DTO_LoaiPhong()
        {
        }

        public DTO_LoaiPhong(string maLoaiPhong,
                             string tenLoaiPhong,
                             int soNguoiToiDa,
                             decimal donGia)
        {
            MaLoaiPhong = maLoaiPhong;
            TenLoaiPhong = tenLoaiPhong;
            SoNguoiToiDa = soNguoiToiDa;
            DonGia = donGia;
        }
    }
}
