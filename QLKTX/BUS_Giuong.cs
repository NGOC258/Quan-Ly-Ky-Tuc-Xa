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
    public class BUS_Giuong
    {
        DAL_Giuong dal = new DAL_Giuong();

        public DataTable LayDanhSachGiuong()
        {
            return dal.LayDanhSachGiuong();
        }

        public DataTable LayDanhSachPhong()
        {
            return dal.LayDanhSachPhong();
        }
        public bool KiemTraMaGiuong(string maGiuong)
        {
            return dal.KiemTraMaGiuong(maGiuong);
        }

        public bool ThemGiuong(DTO_Giuong giuong)
        {
            return dal.ThemGiuong(giuong);
        }
        public bool SuaGiuong(DTO_Giuong giuong)
        {
            return dal.SuaGiuong(giuong);
        }
        public bool XoaGiuong(string maGiuong)
        {
            return dal.XoaGiuong(maGiuong);
        }
        public DataTable TimKiemGiuong(string maGiuong, string soHieuGiuong)
        {
            return dal.TimKiemGiuong(maGiuong, soHieuGiuong);
        }
        public string TaoMaGiuongMoi()
        {
            return dal.TaoMaGiuongMoi();
        }
    }
}