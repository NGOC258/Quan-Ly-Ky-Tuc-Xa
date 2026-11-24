using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_QLKTX;

namespace BUS_QLKTX
{
    public class BUS_TroLyKTX
    {
        DAL_TroLyKTX dal = new DAL_TroLyKTX();

        public DataTable LayChoOHienTai(string maSV)
        {
            return dal.LayChoOHienTai(maSV);
        }

        public DataTable LayDangKyMoiNhat(string maSV)
        {
            return dal.LayDangKyMoiNhat(maSV);
        }

        public DataTable LayHopDongHienTai(string maSV)
        {
            return dal.LayHopDongHienTai(maSV);
        }

        public DataTable LayHoaDonChuaThanhToan(string maSV)
        {
            return dal.LayHoaDonChuaThanhToan(maSV);
        }

        public DataTable LayBaoSuaMoiNhat(string maSV)
        {
            return dal.LayBaoSuaMoiNhat(maSV);
        }

        public DataTable LayLichSuViPham(string maSV)
        {
            return dal.LayLichSuViPham(maSV);
        }

        public DataTable TimNoiQuy(string tuKhoa)
        {
            return dal.TimNoiQuy(tuKhoa);
        }
    }
}