using System.Data;
using DAL_QLKTX;
using DTO_QLKTX;

namespace BUS_QLKTX
{
    public class BUS_DangKyOSinhVien
    {
        DAL_DangKyOSinhVien dal = new DAL_DangKyOSinhVien();

        public DataTable LayThongTinSinhVien(string maSV)
        {
            return dal.LayThongTinSinhVien(maSV);
        }

        public DataTable LayDangKyCuaSinhVien(string maSV)
        {
            return dal.LayDangKyCuaSinhVien(maSV);
        }

        public string TaoMaDangKyMoi()
        {
            return dal.TaoMaDangKyMoi();
        }

        public bool ThemDangKy(DTO_DangKyO dk)
        {
            return dal.ThemDangKy(dk);
        }

        public bool CoDangKyChoDuyet(string maSV)
        {
            return dal.CoDangKyChoDuyet(maSV);
        }

        public bool CoDangKyDaDuyet(string maSV)
        {
            return dal.CoDangKyDaDuyet(maSV);
        }
    }
}