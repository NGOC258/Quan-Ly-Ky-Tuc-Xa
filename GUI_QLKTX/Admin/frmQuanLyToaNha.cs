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
    public partial class frmQuanLyToaNha : Form
    {
        BUS_ToaNha bus = new BUS_ToaNha();
        public frmQuanLyToaNha()
        {
            InitializeComponent();
        }

        private void frmQuanLyToaNha_Load(object sender, EventArgs e)
        {
            dgvToaNha.DataSource = bus.LayDanhSachToaNha();
            cboGioiTinhKhu.Items.Clear();
            cboGioiTinhKhu.Items.Add("Nam");
            cboGioiTinhKhu.Items.Add("Nữ");
            cboGioiTinhKhu.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaToa.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã tòa nhà!");
                txtMaToa.Focus();
                return;
            }

            if (txtTenToa.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên tòa nhà!");
                txtTenToa.Focus();
                return;
            }

            int soTang;

            if (!int.TryParse(txtSoTang.Text.Trim(), out soTang))
            {
                MessageBox.Show("Số tầng phải là số!");
                txtSoTang.Focus();
                return;
            }

            if (cboGioiTinhKhu.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khu Nam hoặc Nữ!");
                cboGioiTinhKhu.Focus();
                return;
            }

            DTO_ToaNha toaNha = new DTO_ToaNha();

            toaNha.MaToaNha = txtMaToa.Text.Trim();
            toaNha.TenToaNha = txtTenToa.Text.Trim();
            toaNha.SoTang = soTang;
            toaNha.DiaChi = txtDiaChi.Text.Trim();
            toaNha.MoTa = txtMta.Text.Trim();
            toaNha.GioiTinhKhu = cboGioiTinhKhu.Text;

            if (bus.ThemToaNha(toaNha))
            {
                MessageBox.Show("Thêm tòa nhà thành công!");

                dgvToaNha.DataSource = bus.LayDanhSachToaNha();

                txtMaToa.Clear();
                txtTenToa.Clear();
                txtSoTang.Clear();
                txtDiaChi.Clear();
                txtMta.Clear();
                cboGioiTinhKhu.SelectedIndex = 0;

                txtMaToa.Focus();
            }
            else
            {
                MessageBox.Show("Thêm tòa nhà thất bại!");
            }
        }

        private void dgvToaNha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvToaNha.Rows[e.RowIndex];

                txtMaToa.Text = row.Cells["MaToaNha"].Value.ToString();
                txtTenToa.Text = row.Cells["TenToaNha"].Value.ToString();
                txtSoTang.Text = row.Cells["SoTang"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtMta.Text = row.Cells["MoTa"].Value.ToString();
                cboGioiTinhKhu.Text = row.Cells["GioiTinhKhu"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaToa.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn tòa nhà cần sửa!");
                return;
            }

            if (txtTenToa.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên tòa nhà!");
                txtTenToa.Focus();
                return;
            }

            int soTang;

            if (!int.TryParse(txtSoTang.Text.Trim(), out soTang))
            {
                MessageBox.Show("Số tầng phải là số!");
                txtSoTang.Focus();
                return;
            }

            if (cboGioiTinhKhu.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khu Nam hoặc Nữ!");
                cboGioiTinhKhu.Focus();
                return;
            }

            DTO_ToaNha toaNha = new DTO_ToaNha();

            toaNha.MaToaNha = txtMaToa.Text.Trim();
            toaNha.TenToaNha = txtTenToa.Text.Trim();
            toaNha.SoTang = soTang;
            toaNha.DiaChi = txtDiaChi.Text.Trim();
            toaNha.MoTa = txtMta.Text.Trim();
            toaNha.GioiTinhKhu = cboGioiTinhKhu.Text;

            if (bus.SuaToaNha(toaNha))
            {
                MessageBox.Show("Sửa tòa nhà thành công!");
                dgvToaNha.DataSource = bus.LayDanhSachToaNha();
            }
            else
            {
                MessageBox.Show("Sửa tòa nhà thất bại!");
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                "Bạn có muốn thoát khỏi quản lý tòa nhà không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaToa.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn tòa nhà cần xóa!");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn xóa tòa nhà này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                if (bus.XoaToaNha(txtMaToa.Text.Trim()))
                {
                    MessageBox.Show("Xóa tòa nhà thành công!");

                    dgvToaNha.DataSource = bus.LayDanhSachToaNha();

                    txtMaToa.Clear();
                    txtTenToa.Clear();
                    txtSoTang.Clear();
                    txtDiaChi.Clear();
                    txtMta.Clear();
                    cboGioiTinhKhu.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Xóa tòa nhà thất bại!");
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaToa.Clear();
            txtTenToa.Clear();
            txtSoTang.Clear();
            txtDiaChi.Clear();
            txtMta.Clear();

            cboGioiTinhKhu.SelectedIndex = 0;

            txtMaToa.Enabled = true;
            txtMaToa.Focus();

            dgvToaNha.ClearSelection();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtMaToa.Text.Trim();

            if (tuKhoa == "")
            {
                tuKhoa = txtTenToa.Text.Trim();
            }

            if (tuKhoa == "")
            {
                MessageBox.Show("Vui lòng nhập mã tòa hoặc tên tòa cần tìm!");
                return;
            }

            dgvToaNha.DataSource = bus.TimKiemToaNha(tuKhoa);

            if (dgvToaNha.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy tòa nhà!");
            }
        }
    }
}
