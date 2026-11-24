using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL_QLKTX
{
    public class DBConnect
    {
        protected SqlConnection conn;

        public DBConnect()
        {
            conn = new SqlConnection(
            @"Data Source=DESKTOP-7BJDSV2\NGOC;
            Initial Catalog=QLKTX;
            Integrated Security=True");
        }
        public bool TestConnection()
        {
            try
            {
                conn.Open();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}