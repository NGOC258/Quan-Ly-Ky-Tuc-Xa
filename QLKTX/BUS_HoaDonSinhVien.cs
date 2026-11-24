using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_QLKTX;

namespace BUS_QLKTX
{
    public class BUS_HoaDonSinhVien
    {
        DAL_HoaDonSinhVien dal =
            new DAL_HoaDonSinhVien();

        public DataTable LayHoaDonCuaSinhVien(string maSV)
        {
            return dal.LayHoaDonCuaSinhVien(maSV);
        }
    }
}
