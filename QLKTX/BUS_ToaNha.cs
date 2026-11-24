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
    public class BUS_ToaNha
    {
        DAL_ToaNha dal = new DAL_ToaNha();

        public DataTable LayDanhSachToaNha()
        {
            return dal.LayDanhSachToaNha();
        }
        public bool ThemToaNha(DTO_ToaNha toaNha)
        {
            return dal.ThemToaNha(toaNha);
        }
        public bool SuaToaNha(DTO_ToaNha toaNha)
        {
            return dal.SuaToaNha(toaNha);
        }
        public bool XoaToaNha(string maToaNha)
        {
            return dal.XoaToaNha(maToaNha);
        }
        public DataTable TimKiemToaNha(string tuKhoa)
        {
            return dal.TimKiemToaNha(tuKhoa);
        }
    }
}