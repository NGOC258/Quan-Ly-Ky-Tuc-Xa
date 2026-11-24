using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using DAL_QLKTX;
using DTO_QLKTX;
namespace BUS_QLKTX
{
    public class BUS_SinhVien
    {
        DAL_SinhVien dal = new DAL_SinhVien();

        public DataTable LayDanhSachSinhVien()
        {
            return dal.LayDanhSachSinhVien();
        }
        public bool KiemTraMaSV(string maSV)
        {
            return dal.KiemTraMaSV(maSV);
        }

        public bool ThemSinhVien(DTO_SinhVien sv)
        {
            return dal.ThemSinhVien(sv);
        }
        public bool SuaSinhVien(DTO_SinhVien sv)
        {
            return dal.SuaSinhVien(sv);
        }
        public bool XoaSinhVien(string maSV)
        {
            return dal.XoaSinhVien(maSV);
        }
        public DataTable TimKiemSinhVien(string maSV, string hoTen)
        {
            return dal.TimKiemSinhVien(maSV, hoTen);
        }
    }
}