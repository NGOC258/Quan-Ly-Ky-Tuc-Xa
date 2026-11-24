using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLKTX;
using System.Data;
namespace BUS_QLKTX
{
    public class BUS_BaoCaoThongKe
    {
        DAL_BaoCaoThongKe dal = new DAL_BaoCaoThongKe();

        public int TongSinhVien()
        {
            return dal.TongSinhVien();
        }

        public int TongPhong()
        {
            return dal.TongPhong();
        }

        public int TongGiuongTrong()
        {
            return dal.TongGiuongTrong();
        }

        public int TongDangKyChoDuyet()
        {
            return dal.TongDangKyChoDuyet();
        }

        public int TongHoaDonChuaThanhToan()
        {
            return dal.TongHoaDonChuaThanhToan();
        }

        public int TongBaoSuaChoXuLy()
        {
            return dal.TongBaoSuaChoXuLy();
        }

        public int TongViPham()
        {
            return dal.TongViPham();
        }

        public DataTable ThongKeHoaDon(int thang, int nam)
        {
            return dal.ThongKeHoaDon(thang, nam);
        }

        public DataTable ThongKeDangKyO(int thang, int nam)
        {
            return dal.ThongKeDangKyO(thang, nam);
        }

        public DataTable ThongKeViPham(int thang, int nam)
        {
            return dal.ThongKeViPham(thang, nam);
        }

        public DataTable ThongKeBaoSuaChua(int thang, int nam)
        {
            return dal.ThongKeBaoSuaChua(thang, nam);
        }

        public DataTable ThongKePhongGiuong()
        {
            return dal.ThongKePhongGiuong();
        }

        public DataTable LayThongBaoMoiNhat()
        {
            return dal.LayThongBaoMoiNhat();
        }
    }
}