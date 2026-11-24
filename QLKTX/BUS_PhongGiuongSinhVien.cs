using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_QLKTX;

namespace BUS_QLKTX
{
    public class BUS_PhongGiuongSinhVien
    {
        DAL_PhongGiuongSinhVien dal =
            new DAL_PhongGiuongSinhVien();

        public DataTable LayDanhSachGiuongTrong()
        {
            return dal.LayDanhSachGiuongTrong();
        }

        public DataTable TimKiem(string tuKhoa)
        {
            return dal.TimKiem(tuKhoa);
        }
        public bool KiemTraPhongTonTai(string tuKhoa)
        {
            return dal.KiemTraPhongTonTai(tuKhoa);
        }
    }
}
