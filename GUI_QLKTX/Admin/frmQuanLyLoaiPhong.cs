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

using DTO_QLKTX;
namespace GUI_QLKTX
{
    public partial class frmQuanLyLoaiPhong : Form
    {
        BUS_LoaiPhong bus = new BUS_LoaiPhong();
        public frmQuanLyLoaiPhong()
        {
            InitializeComponent();
        }

        private void frmQuanLyLoaiPhong_Load(object sender, EventArgs e)
        {
            dgvLoaiPhong.DataSource = bus.LayDanhSachLoaiPhong();

            txtMaLoaiPhong.ReadOnly = true;
            txtMaLoaiPhong.Text = bus.TaoMaLoaiPhongMoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (txtTenLoaiPhong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên loại phòng!");
                txtTenLoaiPhong.Focus();
                return;
            }

            int soNguoiToiDa;

            if (!int.TryParse(txtSoNguoiToiDa.Text.Trim(), out soNguoiToiDa))
            {
                MessageBox.Show("Số người tối đa phải là số!");
                txtSoNguoiToiDa.Focus();
                return;
            }

            decimal donGia;

            if (!decimal.TryParse(txtDonGia.Text.Trim(), out donGia))
            {
                MessageBox.Show("Đơn giá phải là số!");
                txtDonGia.Focus();
                return;
            }

            DTO_LoaiPhong loaiPhong = new DTO_LoaiPhong();

            loaiPhong.MaLoaiPhong = txtMaLoaiPhong.Text.Trim();
            loaiPhong.TenLoaiPhong = txtTenLoaiPhong.Text.Trim();
            loaiPhong.SoNguoiToiDa = soNguoiToiDa;
            loaiPhong.DonGia = donGia;

            if (bus.ThemLoaiPhong(loaiPhong))
            {
                MessageBox.Show("Thêm loại phòng thành công!");

                dgvLoaiPhong.DataSource = bus.LayDanhSachLoaiPhong();

                txtMaLoaiPhong.Clear();
                txtTenLoaiPhong.Clear();
                txtSoNguoiToiDa.Clear();
                txtDonGia.Clear();

                txtMaLoaiPhong.Focus();
            }
            else
            {
                MessageBox.Show("Thêm loại phòng thất bại!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                "Bạn có muốn thoát khỏi quản lý loại phòng không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvLoaiPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLoaiPhong.Rows[e.RowIndex];

                txtMaLoaiPhong.Text = row.Cells["MaLoaiPhong"].Value.ToString();
                txtTenLoaiPhong.Text = row.Cells["TenLoaiPhong"].Value.ToString();
                txtSoNguoiToiDa.Text = row.Cells["SoNguoiToiDa"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaLoaiPhong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần sửa!");
                return;
            }

            if (txtTenLoaiPhong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên loại phòng!");
                txtTenLoaiPhong.Focus();
                return;
            }

            int soNguoiToiDa;

            if (!int.TryParse(txtSoNguoiToiDa.Text.Trim(), out soNguoiToiDa))
            {
                MessageBox.Show("Số người tối đa phải là số!");
                txtSoNguoiToiDa.Focus();
                return;
            }

            decimal donGia;

            if (!decimal.TryParse(txtDonGia.Text.Trim(), out donGia))
            {
                MessageBox.Show("Đơn giá phải là số!");
                txtDonGia.Focus();
                return;
            }

            DTO_LoaiPhong loaiPhong = new DTO_LoaiPhong();

            loaiPhong.MaLoaiPhong = txtMaLoaiPhong.Text.Trim();
            loaiPhong.TenLoaiPhong = txtTenLoaiPhong.Text.Trim();
            loaiPhong.SoNguoiToiDa = soNguoiToiDa;
            loaiPhong.DonGia = donGia;

            if (bus.SuaLoaiPhong(loaiPhong))
            {
                MessageBox.Show("Sửa loại phòng thành công!");

                dgvLoaiPhong.DataSource = bus.LayDanhSachLoaiPhong();
            }
            else
            {
                MessageBox.Show("Sửa loại phòng thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaLoaiPhong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần xóa!");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn xóa loại phòng này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                if (bus.XoaLoaiPhong(txtMaLoaiPhong.Text.Trim()))
                {
                    MessageBox.Show("Xóa loại phòng thành công!");

                    dgvLoaiPhong.DataSource = bus.LayDanhSachLoaiPhong();

                    txtMaLoaiPhong.Text = bus.TaoMaLoaiPhongMoi();
                    txtTenLoaiPhong.Clear();
                    txtSoNguoiToiDa.Clear();
                    txtDonGia.Clear();

                    txtTenLoaiPhong.Focus();
                }
                else
                {
                    MessageBox.Show("Xóa loại phòng thất bại!");
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaLoaiPhong.Text = bus.TaoMaLoaiPhongMoi();
            txtTenLoaiPhong.Clear();
            txtSoNguoiToiDa.Clear();
            txtDonGia.Clear();

            txtMaLoaiPhong.ReadOnly = true;
            txtTenLoaiPhong.Focus();

            dgvLoaiPhong.DataSource = bus.LayDanhSachLoaiPhong();
            dgvLoaiPhong.ClearSelection();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ma = txtMaLoaiPhong.Text.Trim();
            string ten = txtTenLoaiPhong.Text.Trim();

            if (ma == "" && ten == "")
            {
                MessageBox.Show("Vui lòng nhập mã hoặc tên loại phòng cần tìm!");
                return;
            }

            DataTable dt = bus.TimKiemLoaiPhong(ma, ten);

            dgvLoaiPhong.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy loại phòng!");
            }
        }
    }
}
