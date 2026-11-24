using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace DTO_QLKTX
{
    public class DTO_HopDong
    {
        public string MaHopDong { get; set; }
        public string MaDangKy { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string TrangThaiHopDong { get; set; }

        public DTO_HopDong()
        {
        }

        public DTO_HopDong(string maHopDong,
                           string maDangKy,
                           DateTime ngayBatDau,
                           DateTime ngayKetThuc,
                           string trangThaiHopDong)
        {
            MaHopDong = maHopDong;
            MaDangKy = maDangKy;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            TrangThaiHopDong = trangThaiHopDong;
        }
    }
}