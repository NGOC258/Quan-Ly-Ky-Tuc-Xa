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
    public class BUS_Phong
    {
        DAL_Phong dal = new DAL_Phong();

        public DataTable LayDanhSachPhong()
        {
            return dal.LayDanhSachPhong();
        }

        public DataTable LayDanhSachToaNha()
        {
            return dal.LayDanhSachToaNha();
        }

        public DataTable LayDanhSachLoaiPhong()
        {
            return dal.LayDanhSachLoaiPhong();
        }
        public string TaoMaPhongMoi(string maToaNha)
        {
            return dal.TaoMaPhongMoi(maToaNha);
        }
        public bool KiemTraMaPhong(string maPhong)
        {
            return dal.KiemTraMaPhong(maPhong);
        }

        public bool ThemPhong(DTO_Phong phong)
        {
            return dal.ThemPhong(phong);
        }

        public bool SuaPhong(DTO_Phong phong)
        {
            return dal.SuaPhong(phong);
        }

        public bool XoaPhong(string maPhong)
        {
            return dal.XoaPhong(maPhong);
        }

        public DataTable TimKiemPhong(string maPhong, string tenPhong)
        {
            return dal.TimKiemPhong(maPhong, tenPhong);
        }
    }
}