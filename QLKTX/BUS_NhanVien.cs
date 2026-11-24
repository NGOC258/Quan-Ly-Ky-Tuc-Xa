using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLKTX;
using System.Data;
using DAL_QLKTX;

namespace BUS_QLKTX
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dal = new DAL_NhanVien();

        public DataTable LayDanhSachNhanVien()
        {
            return dal.LayDanhSachNhanVien();
        }
        public bool KiemTraMaNV(string maNV)
        {
            return dal.KiemTraMaNV(maNV);
        }

        public bool ThemNhanVien(DTO_NhanVien nv)
        {
            return dal.ThemNhanVien(nv);
        }
        public bool SuaNhanVien(DTO_NhanVien nv)
        {
            return dal.SuaNhanVien(nv);
        }
        public bool XoaNhanVien(string maNV)
        {
            return dal.XoaNhanVien(maNV);
        }
        public DataTable TimKiemNhanVien(string maNV, string hoTen)
        {
            return dal.TimKiemNhanVien(maNV, hoTen);
        }
    }

}