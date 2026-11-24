using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_QLKTX;

namespace BUS_QLKTX
{
    public class BUS_BaoSuaChuaNhanVien
    {
        DAL_BaoSuaChuaNhanVien dal = new DAL_BaoSuaChuaNhanVien();

        public DataTable LayDanhSachBaoSua()
        {
            return dal.LayDanhSachBaoSua();
        }

        public bool CapNhatTrangThai(string maBaoSua, string trangThai)
        {
            return dal.CapNhatTrangThai(maBaoSua, trangThai);
        }

        public DataTable TimKiemBaoSua(string tuKhoa)
        {
            return dal.TimKiemBaoSua(tuKhoa);
        }
        public bool SuaBaoSua(string maBaoSua, string loaiSuCo, string moTa, DateTime ngayBao, string trangThai)
        {
            return dal.SuaBaoSua(maBaoSua, loaiSuCo, moTa, ngayBao, trangThai);
        }

        public bool XoaBaoSua(string maBaoSua)
        {
            return dal.XoaBaoSua(maBaoSua);
        }
    }
}