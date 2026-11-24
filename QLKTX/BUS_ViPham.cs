using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLKTX;
using DTO_QLKTX;

namespace BUS_QLKTX
{
    public class BUS_ViPham
    {
        DAL_ViPham dal = new DAL_ViPham();

        public DataTable LayDanhSachViPham()
        {
            return dal.LayDanhSachViPham();
        }

        public DataTable LayDanhSachSinhVien()
        {
            return dal.LayDanhSachSinhVien();
        }

        public DataTable LayDanhSachLoaiViPham()
        {
            return dal.LayDanhSachLoaiViPham();
        }

        public string TaoMaViPhamMoi()
        {
            return dal.TaoMaViPhamMoi();
        }

        public int LayLanViPhamTiepTheo(string maSV, string maLoaiViPham)
        {
            return dal.LayLanViPhamTiepTheo(maSV, maLoaiViPham);
        }

        public string LayHinhThucXuLy(string maLoaiViPham, int lanViPham)
        {
            return dal.LayHinhThucXuLy(maLoaiViPham, lanViPham);
        }

        public bool ThemViPham(DTO_ViPham vp)
        {
            return dal.ThemViPham(vp);
        }

        public DataTable TimKiemViPham(string tuKhoa)
        {
            return dal.TimKiemViPham(tuKhoa);
        }
        public DataTable TimSinhVienTheoMa(string maSV)
        {
            return dal.TimSinhVienTheoMa(maSV);
        }
    }
}
