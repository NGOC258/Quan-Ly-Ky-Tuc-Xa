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
    public class BUS_LoaiPhong
    {
        DAL_LoaiPhong dal = new DAL_LoaiPhong();

        public DataTable LayDanhSachLoaiPhong()
        {
            return dal.LayDanhSachLoaiPhong();
        }

        public bool ThemLoaiPhong(DTO_LoaiPhong loaiPhong)
        {
            return dal.ThemLoaiPhong(loaiPhong);
        }

        public bool KiemTraMaLoaiPhong(string maLoaiPhong)
        {
            return dal.KiemTraMaLoaiPhong(maLoaiPhong);
        }

        public bool SuaLoaiPhong(DTO_LoaiPhong loaiPhong)
        {
            return dal.SuaLoaiPhong(loaiPhong);
        }

        public bool XoaLoaiPhong(string maLoaiPhong)
        {
            return dal.XoaLoaiPhong(maLoaiPhong);
        }

        public DataTable TimKiemLoaiPhong(string maLoaiPhong, string tenLoaiPhong)
        {
            return dal.TimKiemLoaiPhong(maLoaiPhong, tenLoaiPhong);
        }
        public string TaoMaLoaiPhongMoi()
        {
            return dal.TaoMaLoaiPhongMoi();
        }
    }
}