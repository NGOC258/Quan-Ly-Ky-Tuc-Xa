using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLKTX;
using DTO_QLKTX;
using DTO_QLKTX.DTO_QLKTX;
using System.Data;
namespace BUS_QLKTX
{
    public class BUS_TaiKhoan
    {
        DAL_TaiKhoan dal = new DAL_TaiKhoan();

        public DTO_TaiKhoan DangNhap(string tenDangNhap, string matKhau)
        {
            return dal.DangNhap(tenDangNhap, matKhau);
        }
        public DataTable LayDanhSachTaiKhoan()
        {
            return dal.LayDanhSachTaiKhoan();
        }

        public DataTable LayDanhSachSinhVien()
        {
            return dal.LayDanhSachSinhVien();
        }

        public DataTable LayDanhSachNhanVien()
        {
            return dal.LayDanhSachNhanVien();
        }
        public bool KiemTraMaTaiKhoan(string maTaiKhoan)
        {
            return dal.KiemTraMaTaiKhoan(maTaiKhoan);
        }

        public bool KiemTraTenDangNhap(string tenDangNhap)
        {
            return dal.KiemTraTenDangNhap(tenDangNhap);
        }

        public bool ThemTaiKhoan(DTO_TaiKhoan tk)
        {
            return dal.ThemTaiKhoan(tk);
        }
        public bool SuaTaiKhoan(DTO_TaiKhoan tk)
        {
            return dal.SuaTaiKhoan(tk);
        }
        public bool KiemTraTenDangNhapKhiSua(string maTaiKhoan, string tenDangNhap)
        {
            return dal.KiemTraTenDangNhapKhiSua(maTaiKhoan, tenDangNhap);
        }
        public bool XoaTaiKhoan(string maTaiKhoan)
        {
            return dal.XoaTaiKhoan(maTaiKhoan);
        }
        public DataTable TimKiemTaiKhoan(string maTaiKhoan, string tenDangNhap)
        {
            return dal.TimKiemTaiKhoan(maTaiKhoan, tenDangNhap);
        }
        public bool KiemTraMatKhauCu(string maSV, string matKhauCu)
        {
            return dal.KiemTraMatKhauCu(maSV, matKhauCu);
        }

        public bool DoiMatKhauSinhVien(string maSV, string matKhauMoi)
        {
            return dal.DoiMatKhauSinhVien(maSV, matKhauMoi);
        }
    }
}
