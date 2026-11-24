using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_QLKTX;

namespace BUS_QLKTX
{
    public class BUS_SinhVienTrangChu
    {
        DAL_SinhVienTrangChu dal = new DAL_SinhVienTrangChu();

        public DataTable LayThongTinNoiTru(string maSV)
        {
            return dal.LayThongTinNoiTru(maSV);
        }

        public string LayTrangThaiDangKyMoiNhat(string maSV)
        {
            return dal.LayTrangThaiDangKyMoiNhat(maSV);
        }

        public int DemHoaDonChuaThanhToan(string maSV)
        {
            return dal.DemHoaDonChuaThanhToan(maSV);
        }
        public string LayTenSinhVien(string maSV)
        {
            return dal.LayTenSinhVien(maSV);
        }
    }
}