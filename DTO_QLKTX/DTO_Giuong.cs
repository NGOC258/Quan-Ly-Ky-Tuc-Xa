using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLKTX
{
    public class DTO_Giuong
    {
        public string MaGiuong { get; set; }
        public string MaPhong { get; set; }
        public string SoHieuGiuong { get; set; }
        public string TrangThaiGiuong { get; set; }

        public DTO_Giuong()
        {
        }

        public DTO_Giuong(string maGiuong,
                          string maPhong,
                          string soHieuGiuong,
                          string trangThaiGiuong)
        {
            MaGiuong = maGiuong;
            MaPhong = maPhong;
            SoHieuGiuong = soHieuGiuong;
            TrangThaiGiuong = trangThaiGiuong;
        }
    }
}