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
    public class BUS_BaoSuaChuaSinhVien
    {
        DAL_BaoSuaChuaSinhVien dal = new DAL_BaoSuaChuaSinhVien();

        public DataTable LayThongTinChoOHienTai(string maSV)
        {
            return dal.LayThongTinChoOHienTai(maSV);
        }

        public DataTable LayBaoSuaCuaSinhVien(string maSV)
        {
            return dal.LayBaoSuaCuaSinhVien(maSV);
        }

        public string TaoMaBaoSuaMoi()
        {
            return dal.TaoMaBaoSuaMoi();
        }

        public bool ThemBaoSua(DTO_BaoSuaChua bs)
        {
            return dal.ThemBaoSua(bs);
        }
    }
}