using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLKTX
{
    public class DTO_Phong
    {
        public string MaPhong { get; set; }
        public string MaToaNha { get; set; }
        public string MaLoaiPhong { get; set; }
        public string TenPhong { get; set; }
        public string TrangThaiPhong { get; set; }

        public DTO_Phong()
        {
        }

        public DTO_Phong(string maPhong,
                         string maToaNha,
                         string maLoaiPhong,
                         string tenPhong,
                         string trangThaiPhong)
        {
            MaPhong = maPhong;
            MaToaNha = maToaNha;
            MaLoaiPhong = maLoaiPhong;
            TenPhong = tenPhong;
            TrangThaiPhong = trangThaiPhong;
        }
    }
}
