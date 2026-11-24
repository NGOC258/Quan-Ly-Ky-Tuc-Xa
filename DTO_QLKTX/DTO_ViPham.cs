using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLKTX
{
    public class DTO_ViPham
    {
        public string MaViPham { get; set; }
        public string MaSV { get; set; }
        public string MaLoaiViPham { get; set; }
        public DateTime NgayViPham { get; set; }
        public int LanViPham { get; set; }
        public string HinhThucXuLy { get; set; }
        public string GhiChu { get; set; }

        public DTO_ViPham() { }

        public DTO_ViPham(string maViPham, string maSV, string maLoaiViPham, DateTime ngayViPham, int lanViPham, string hinhThucXuLy, string ghiChu)
        {
            MaViPham = maViPham;
            MaSV = maSV;
            MaLoaiViPham = maLoaiViPham;
            NgayViPham = ngayViPham;
            LanViPham = lanViPham;
            HinhThucXuLy = hinhThucXuLy;
            GhiChu = ghiChu;
        }
    }
}