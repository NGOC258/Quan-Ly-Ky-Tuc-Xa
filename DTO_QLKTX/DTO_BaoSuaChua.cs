using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DTO_QLKTX
{
    public class DTO_BaoSuaChua
    {
        public string MaBaoSua { get; set; }
        public string MaSV { get; set; }
        public string MaPhong { get; set; }
        public string MaGiuong { get; set; }
        public string LoaiSuCo { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayBao { get; set; }
        public string TrangThai { get; set; }

        public DTO_BaoSuaChua()
        {
        }

        public DTO_BaoSuaChua(string maBaoSua, string maSV, string maPhong, string maGiuong, string loaiSuCo, string moTa, DateTime ngayBao, string trangThai)
        {
            MaBaoSua = maBaoSua;
            MaSV = maSV;
            MaPhong = maPhong;
            MaGiuong = maGiuong;
            LoaiSuCo = loaiSuCo;
            MoTa = moTa;
            NgayBao = ngayBao;
            TrangThai = trangThai;
        }
    }
}