using System.Data;
using DAL_QLKTX;

namespace BUS_QLKTX
{
    public class BUS_ThongTinCaNhanSinhVien
    {
        DAL_ThongTinCaNhanSinhVien dal = new DAL_ThongTinCaNhanSinhVien();

        public DataTable LayThongTinSinhVien(string maSV)
        {
            return dal.LayThongTinSinhVien(maSV);
        }

        public bool CapNhatThongTin(string maSV, string sdt, string diaChi)
        {
            return dal.CapNhatThongTin(maSV, sdt, diaChi);
        }
    }
}