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
    public class BUS_HoaDon
    {
        DAL_HoaDon dal = new DAL_HoaDon();

        public DataTable LayDanhSachHoaDon()
        {
            return dal.LayDanhSachHoaDon();
        }

        public DataTable LayDanhSachHopDong()
        {
            return dal.LayDanhSachHopDong();
        }
        public bool KiemTraMaHoaDon(string maHoaDon)
        {
            return dal.KiemTraMaHoaDon(maHoaDon);
        }

        public bool KiemTraHoaDonTheoThang(string maHopDong, int thang, int nam)
        {
            return dal.KiemTraHoaDonTheoThang(maHopDong, thang, nam);
        }

        public bool ThemHoaDon(DTO_HoaDon hd)
        {
            return dal.ThemHoaDon(hd);
        }
        public bool SuaHoaDon(DTO_HoaDon hd)
        {
            return dal.SuaHoaDon(hd);
        }
        public DataTable TimKiemHoaDon(string tuKhoa)
        {
            return dal.TimKiemHoaDon(tuKhoa);
        }
        public bool XoaHoaDon(string maHoaDon)
        {
            return dal.XoaHoaDon(maHoaDon);
        }
        public DataTable LayHopDongKhiSua(string maHopDong)
        {
            return dal.LayHopDongKhiSua(maHopDong);
        }
        public string TaoMaHoaDonMoi()
        {
            return dal.TaoMaHoaDonMoi();
        }
    }
}
