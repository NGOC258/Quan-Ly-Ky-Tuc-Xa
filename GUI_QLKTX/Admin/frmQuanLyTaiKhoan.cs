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
using DTO_QLKTX.DTO_QLKTX;
namespace GUI_QLKTX
{
    public partial class frmQuanLyTaiKhoan : Form
    {
        BUS_TaiKhoan bus = new BUS_TaiKhoan();
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            // Load danh sách tài khoản
            dgvTaiKhoan.DataSource = bus.LayDanhSachTaiKhoan();

            // Load danh sách sinh viên
            cboSinhVien.DataSource = bus.LayDanhSachSinhVien();
            cboSinhVien.DisplayMember = "HoTen";
            cboSinhVien.ValueMember = "MaSV";
            cboSinhVien.SelectedIndex = -1;

            // Load danh sách nhân viên
            cboNhanVien.DataSource = bus.LayDanhSachNhanVien();
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.SelectedIndex = -1;

            cboVaiTro.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;
        }

        private void cboVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVaiTro.SelectedIndex == 0) // Admin
            {
                cboSinhVien.Enabled = false;
                cboNhanVien.Enabled = false;

                cboSinhVien.SelectedIndex = -1;
                cboNhanVien.SelectedIndex = -1;
            }
            else if (cboVaiTro.SelectedIndex == 1) // Nhân Viên
            {
                cboSinhVien.Enabled = false;
                cboNhanVien.Enabled = true;

                cboSinhVien.SelectedIndex = -1;
            }
            else if (cboVaiTro.SelectedIndex == 2) // Sinh Viên
            {
                cboSinhVien.Enabled = true;
                cboNhanVien.Enabled = false;

                cboNhanVien.SelectedIndex = -1;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaTaiKhoan.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã tài khoản!");
                txtMaTaiKhoan.Focus();
                return;
            }

            if (txtTenDangNhap.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                txtTenDangNhap.Focus();
                return;
            }

            if (txtMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                txtMatKhau.Focus();
                return;
            }

            if (bus.KiemTraMaTaiKhoan(txtMaTaiKhoan.Text.Trim()))
            {
                MessageBox.Show("Mã tài khoản đã tồn tại!");
                txtMaTaiKhoan.Focus();
                return;
            }

            if (bus.KiemTraTenDangNhap(txtTenDangNhap.Text.Trim()))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!");
                txtTenDangNhap.Focus();
                return;
            }

            DTO_TaiKhoan tk = new DTO_TaiKhoan();

            tk.MaTaiKhoan = txtMaTaiKhoan.Text.Trim();
            tk.TenDangNhap = txtTenDangNhap.Text.Trim();
            tk.MatKhau = txtMatKhau.Text.Trim();
            tk.TrangThai = cboTrangThai.Text;

            // Vai trò
            if (cboVaiTro.SelectedIndex == 0)
            {
                tk.VaiTro = "Admin";
                tk.MaSV = "";
                tk.MaNV = "";
            }
            else if (cboVaiTro.SelectedIndex == 1)
            {
                tk.VaiTro = "NhanVien";
                tk.MaSV = "";

                if (cboNhanVien.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên!");
                    return;
                }

                tk.MaNV = cboNhanVien.SelectedValue.ToString();
            }
            else if (cboVaiTro.SelectedIndex == 2)
            {
                tk.VaiTro = "SinhVien";
                tk.MaNV = "";

                if (cboSinhVien.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn sinh viên!");
                    return;
                }

                tk.MaSV = cboSinhVien.SelectedValue.ToString();
            }

            if (bus.ThemTaiKhoan(tk))
            {
                MessageBox.Show("Thêm tài khoản thành công!");

                dgvTaiKhoan.DataSource = bus.LayDanhSachTaiKhoan();

                txtMaTaiKhoan.Clear();
                txtTenDangNhap.Clear();
                txtMatKhau.Clear();

                cboVaiTro.SelectedIndex = 0;
                cboTrangThai.SelectedIndex = 0;

                cboSinhVien.SelectedIndex = -1;
                cboNhanVien.SelectedIndex = -1;

                txtMaTaiKhoan.Focus();
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                "Bạn có muốn thoát khỏi quản lý tài khoản không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];

                txtMaTaiKhoan.Text = row.Cells["MaTaiKhoan"].Value.ToString();
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();

                string vaiTro = row.Cells["VaiTro"].Value.ToString();

                if (vaiTro == "Admin")
                    cboVaiTro.SelectedIndex = 0;
                else if (vaiTro == "NhanVien")
                    cboVaiTro.SelectedIndex = 1;
                else if (vaiTro == "SinhVien")
                    cboVaiTro.SelectedIndex = 2;

                cboTrangThai.Text = row.Cells["TrangThai"].Value.ToString();

                if (vaiTro == "NhanVien")
                {
                    if (row.Cells["MaNV"].Value != DBNull.Value)
                        cboNhanVien.SelectedValue = row.Cells["MaNV"].Value.ToString();
                }
                else if (vaiTro == "SinhVien")
                {
                    if (row.Cells["MaSV"].Value != DBNull.Value)
                        cboSinhVien.SelectedValue = row.Cells["MaSV"].Value.ToString();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaTaiKhoan.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!");
                return;
            }

            if (txtTenDangNhap.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                txtTenDangNhap.Focus();
                return;
            }
            if (bus.KiemTraTenDangNhapKhiSua(
                 txtMaTaiKhoan.Text.Trim(),
                 txtTenDangNhap.Text.Trim()))
            {
                MessageBox.Show("Tên đăng nhập đã được sử dụng bởi tài khoản khác!");
                txtTenDangNhap.Focus();
                return;
            }

            if (txtMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                txtMatKhau.Focus();
                return;
            }

            DTO_TaiKhoan tk = new DTO_TaiKhoan();

            tk.MaTaiKhoan = txtMaTaiKhoan.Text.Trim();
            tk.TenDangNhap = txtTenDangNhap.Text.Trim();
            tk.MatKhau = txtMatKhau.Text.Trim();
            tk.TrangThai = cboTrangThai.Text;

            if (cboVaiTro.SelectedIndex == 0) // Admin
            {
                tk.VaiTro = "Admin";
                tk.MaSV = "";
                tk.MaNV = "";
            }
            else if (cboVaiTro.SelectedIndex == 1) // Nhân Viên
            {
                if (cboNhanVien.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên!");
                    return;
                }

                tk.VaiTro = "NhanVien";
                tk.MaSV = "";
                tk.MaNV = cboNhanVien.SelectedValue.ToString();
            }
            else if (cboVaiTro.SelectedIndex == 2) // Sinh Viên
            {
                if (cboSinhVien.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn sinh viên!");
                    return;
                }

                tk.VaiTro = "SinhVien";
                tk.MaNV = "";
                tk.MaSV = cboSinhVien.SelectedValue.ToString();
            }

            if (bus.SuaTaiKhoan(tk))
            {
                MessageBox.Show("Sửa tài khoản thành công!");

                dgvTaiKhoan.DataSource = bus.LayDanhSachTaiKhoan();
            }
            else
            {
                MessageBox.Show("Sửa tài khoản thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaTaiKhoan.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn xóa tài khoản này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                if (bus.XoaTaiKhoan(txtMaTaiKhoan.Text.Trim()))
                {
                    MessageBox.Show("Xóa tài khoản thành công!");

                    dgvTaiKhoan.DataSource = bus.LayDanhSachTaiKhoan();

                    txtMaTaiKhoan.Clear();
                    txtTenDangNhap.Clear();
                    txtMatKhau.Clear();

                    cboVaiTro.SelectedIndex = 0;
                    cboTrangThai.SelectedIndex = 0;

                    cboSinhVien.SelectedIndex = -1;
                    cboNhanVien.SelectedIndex = -1;

                    txtMaTaiKhoan.Focus();
                }
                else
                {
                    MessageBox.Show("Xóa tài khoản thất bại!");
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaTaiKhoan.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();

            cboVaiTro.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;

            cboSinhVien.SelectedIndex = -1;
            cboNhanVien.SelectedIndex = -1;

            txtMaTaiKhoan.Enabled = true;
            txtMaTaiKhoan.Focus();

            dgvTaiKhoan.DataSource = bus.LayDanhSachTaiKhoan();
            dgvTaiKhoan.ClearSelection();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ma = txtMaTaiKhoan.Text.Trim();
            string ten = txtTenDangNhap.Text.Trim();

            if (ma == "" && ten == "")
            {
                MessageBox.Show("Vui lòng nhập mã tài khoản hoặc tên đăng nhập cần tìm!");
                return;
            }

            DataTable dt = bus.TimKiemTaiKhoan(ma, ten);

            dgvTaiKhoan.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy tài khoản!");
            }
        }
    }
}
