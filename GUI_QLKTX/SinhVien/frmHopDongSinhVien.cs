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
    public partial class frmHopDongSinhVien : Form
    {
        private string maSV;

        BUS_HopDongSinhVien bus =
            new BUS_HopDongSinhVien();

        public frmHopDongSinhVien(string maSV)
        {
            InitializeComponent();
            this.maSV = maSV;
        }

        private void frmHopDongSinhVien_Load(
            object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = bus.LayHopDongCuaSinhVien(maSV);

            dgvHopDongCuaToi.DataSource = dt;
            dgvHopDongCuaToi.ClearSelection();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Bạn chưa có hợp đồng!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvHopDongCuaToi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
