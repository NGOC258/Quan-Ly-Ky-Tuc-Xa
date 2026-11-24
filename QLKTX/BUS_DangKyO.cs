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
    public class BUS_DangKyO
    {
        DAL_DangKyO dal = new DAL_DangKyO();

        public DataTable LayDanhSachDangKyO()
        {
            return dal.LayDanhSachDangKyO();
        }

        public DataTable LayDanhSachSinhVien()
        {
            return dal.LayDanhSachSinhVien();
        }

        public DataTable LayDanhSachGiuongTrong()
        {
            return dal.LayDanhSachGiuongTrong();
        }
        public bool KiemTraMaDangKy(string maDangKy)
        {
            return dal.KiemTraMaDangKy(maDangKy);
        }

        public bool ThemDangKyO(DTO_DangKyO dk)
        {
            return dal.ThemDangKyO(dk);
        }
        public bool KiemTraGiuongDaDuocDuyet(string maGiuong)
        {
            return dal.KiemTraGiuongDaDuocDuyet(maGiuong);
        }
        public bool SuaDangKyO(DTO_DangKyO dk)
        {
            return dal.SuaDangKyO(dk);
        }
        public bool KiemTraGiuongKhiSua(string maGiuong, string maDangKy)
        {
            return dal.KiemTraGiuongKhiSua(maGiuong, maDangKy);
        }
        public bool XoaDangKyO(string maDangKy)
        {
            return dal.XoaDangKyO(maDangKy);
        }
        public DataTable TimKiemDangKyO(string maDangKy, string maSV)
        {
            return dal.TimKiemDangKyO(maDangKy, maSV);
        }
        public DataTable LayDanhSachToaNha()
        {
            return dal.LayDanhSachToaNha();
        }

        public DataTable LayLoaiPhongTheoToa(string maToaNha)
        {
            return dal.LayLoaiPhongTheoToa(maToaNha);
        }

        public DataTable LayPhongTheoToaVaLoai(
            string maToaNha,
            string maLoaiPhong)
        {
            return dal.LayPhongTheoToaVaLoai(
                maToaNha,
                maLoaiPhong);
        }

        public DataTable LayGiuongTrongTheoPhong(string maPhong)
        {
            return dal.LayGiuongTrongTheoPhong(maPhong);
        }
        public DataTable LayThongTinChoOTheoGiuong(string maGiuong)
        {
            return dal.LayThongTinChoOTheoGiuong(maGiuong);
        }
        public bool SinhVienDaCoChoOKhiSua(string maSV, string maDangKy)
        {
            return dal.SinhVienDaCoChoOKhiSua(maSV, maDangKy);
        }
        public bool SinhVienCoDangKyDangHoatDong(string maSV)
        {
            return dal.SinhVienCoDangKyDangHoatDong(maSV);
        }
        public string TaoMaDangKyMoi()
        {
            return dal.TaoMaDangKyMoi();
        }
        public DataTable LayGiuongKhiSua(string maPhong, string maDangKy)
        {
            return dal.LayGiuongKhiSua(maPhong, maDangKy);
        }
        public string LayGioiTinhSinhVien(string maSV)
        {
            return dal.LayGioiTinhSinhVien(maSV);
        }

        public DataTable LayToaNhaTheoGioiTinh(string gioiTinh)
        {
            return dal.LayToaNhaTheoGioiTinh(gioiTinh);
        }
        public bool KiemTraToaPhuHopGioiTinh(string maSV, string maToaNha)
        {
            return dal.KiemTraToaPhuHopGioiTinh(maSV, maToaNha);
        }
    }
}