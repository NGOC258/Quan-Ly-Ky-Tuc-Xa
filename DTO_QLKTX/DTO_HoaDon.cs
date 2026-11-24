using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace DTO_QLKTX
{
    public class DTO_HoaDon
    {
        public string MaHoaDon { get; set; }
        public string MaHopDong { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }

        public decimal TienPhong { get; set; }
        public decimal TienDien { get; set; }
        public decimal TienNuoc { get; set; }
        public decimal PhiDichVu { get; set; }
        public decimal TongTien { get; set; }

        public DateTime NgayLap { get; set; }
        public string TrangThaiThanhToan { get; set; }

        public DTO_HoaDon()
        {
        }

        public DTO_HoaDon(
            string maHoaDon,
            string maHopDong,
            int thang,
            int nam,
            decimal tienPhong,
            decimal tienDien,
            decimal tienNuoc,
            decimal phiDichVu,
            decimal tongTien,
            DateTime ngayLap,
            string trangThaiThanhToan)
        {
            MaHoaDon = maHoaDon;
            MaHopDong = maHopDong;
            Thang = thang;
            Nam = nam;
            TienPhong = tienPhong;
            TienDien = tienDien;
            TienNuoc = tienNuoc;
            PhiDichVu = phiDichVu;
            TongTien = tongTien;
            NgayLap = ngayLap;
            TrangThaiThanhToan = trangThaiThanhToan;
        }
    }
}