using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLKTX
{
    public class DTO_ToaNha
    {
        public string MaToaNha { get; set; }

        public string TenToaNha { get; set; }

        public int SoTang { get; set; }

        public string DiaChi { get; set; }

        public string MoTa { get; set; }

        public string GioiTinhKhu { get; set; }

        public DTO_ToaNha()
        {

        }

        public DTO_ToaNha(string ma, string ten, int tang, string diaChi, string moTa, string gioiTinhKhu)
        {
            MaToaNha = ma;
            TenToaNha = ten;
            SoTang = tang;
            DiaChi = diaChi;
            MoTa = moTa;
            GioiTinhKhu = gioiTinhKhu;
        }
    }
}