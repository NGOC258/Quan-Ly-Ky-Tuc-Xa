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
    public class BUS_HopDong
    {
        DAL_HopDong dal = new DAL_HopDong();

        public DataTable LayDanhSachHopDong()
        {
            return dal.LayDanhSachHopDong();
        }

        public DataTable LayDanhSachDangKyDaDuyet()
        {
            return dal.LayDanhSachDangKyDaDuyet();
        }
        public DataTable LayDangKyDaDuyetKhiSua(string maDangKy)
        {
            return dal.LayDangKyDaDuyetKhiSua(maDangKy);
        }
        public bool KiemTraMaHopDong(string maHopDong)
        {
            return dal.KiemTraMaHopDong(maHopDong);
        }

        public bool KiemTraDangKyDaCoHopDong(string maDangKy)
        {
            return dal.KiemTraDangKyDaCoHopDong(maDangKy);
        }

        public bool ThemHopDong(DTO_HopDong hd)
        {
            return dal.ThemHopDong(hd);
        }
        public bool SuaHopDong(DTO_HopDong hd)
        {
            return dal.SuaHopDong(hd);
        }
        public bool XoaHopDong(string maHopDong)
        {
            return dal.XoaHopDong(maHopDong);
        }
        public DataTable TimKiemHopDong(string tuKhoa)
        {
            return dal.TimKiemHopDong(tuKhoa);
        }
        public string TaoMaHopDongMoi()
        {
            return dal.TaoMaHopDongMoi();
        }
    }
}
