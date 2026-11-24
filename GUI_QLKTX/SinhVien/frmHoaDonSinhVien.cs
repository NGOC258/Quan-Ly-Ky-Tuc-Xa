using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLKTX;

namespace GUI_QLKTX
{
    public partial class frmHoaDonSinhVien : Form
    {
        private string maSV;

        BUS_HoaDonSinhVien bus = new BUS_HoaDonSinhVien();

        public frmHoaDonSinhVien(string maSV)
        {
            InitializeComponent();
            this.maSV = maSV;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmHoaDonSinhVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            DataTable dt =
                bus.LayHoaDonCuaSinhVien(maSV);

            dgvHoaDonCuaToi.DataSource = dt;
            dgvHoaDonCuaToi.ClearSelection();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Bạn chưa có hóa đơn!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
