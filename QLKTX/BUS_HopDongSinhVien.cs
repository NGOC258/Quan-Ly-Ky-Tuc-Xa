using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_QLKTX;

namespace BUS_QLKTX
{
    public class BUS_HopDongSinhVien
    {
        DAL_HopDongSinhVien dal =
            new DAL_HopDongSinhVien();

        public DataTable LayHopDongCuaSinhVien(string maSV)
        {
            return dal.LayHopDongCuaSinhVien(maSV);
        }
    }
}
