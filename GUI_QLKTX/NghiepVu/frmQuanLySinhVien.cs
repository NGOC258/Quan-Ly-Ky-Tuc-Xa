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
    public partial class frmQuanLySinhVien : Form
    {
        BUS_SinhVien bus = new BUS_SinhVien();
        public frmQuanLySinhVien()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frmQuanLySinhVien_Load(object sender, EventArgs e)
        {
            dgvSinhVien.DataSource = bus.LayDanhSachSinhVien();
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";

            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.Items.Add("Khác");

            cboGioiTinh.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!");
                txtMaSV.Focus();
                return;
            }

            if (bus.KiemTraMaSV(txtMaSV.Text.Trim()))
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!");
                txtMaSV.Focus();
                return;
            }

            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên sinh viên!");
                txtHoTen.Focus();
                return;
            }

            DTO_SinhVien sv = new DTO_SinhVien();

            sv.MaSV = txtMaSV.Text.Trim();
            sv.HoTen = txtHoTen.Text.Trim();
            sv.NgaySinh = dtpNgaySinh.Value;
            sv.GioiTinh = cboGioiTinh.Text;
            sv.Lop = txtLop.Text.Trim();
            sv.Khoa = txtKhoa.Text.Trim();
            sv.SDT = txtSDT.Text.Trim();
            sv.Email = txtEmail.Text.Trim();
            sv.DiaChi = txtDiaChi.Text.Trim();
            sv.DoiTuongUuTien = txtDoiTuongUuTien.Text.Trim();

            if (bus.ThemSinhVien(sv))
            {
                MessageBox.Show("Thêm sinh viên thành công!");

                dgvSinhVien.DataSource = bus.LayDanhSachSinhVien();

                txtMaSV.Clear();
                txtHoTen.Clear();
                txtLop.Clear();
                txtKhoa.Clear();
                txtSDT.Clear();
                txtEmail.Clear();
                txtDiaChi.Clear();
                txtDoiTuongUuTien.Clear();

                cboGioiTinh.SelectedIndex = 0;
                dtpNgaySinh.Value = DateTime.Now;

                txtMaSV.Focus();
            }
            else
            {
                MessageBox.Show("Thêm sinh viên thất bại!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                "Bạn có muốn thoát khỏi quản lý sinh viên không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];

                txtMaSV.Text = row.Cells["MaSV"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();

                dtpNgaySinh.Value =
                    Convert.ToDateTime(row.Cells["NgaySinh"].Value);

                cboGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();

                txtLop.Text = row.Cells["Lop"].Value.ToString();
                txtKhoa.Text = row.Cells["Khoa"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtDoiTuongUuTien.Text =
                    row.Cells["DoiTuongUuTien"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!");
                return;
            }

            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên sinh viên!");
                txtHoTen.Focus();
                return;
            }

            DTO_SinhVien sv = new DTO_SinhVien();

            sv.MaSV = txtMaSV.Text.Trim();
            sv.HoTen = txtHoTen.Text.Trim();
            sv.NgaySinh = dtpNgaySinh.Value;
            sv.GioiTinh = cboGioiTinh.Text;
            sv.Lop = txtLop.Text.Trim();
            sv.Khoa = txtKhoa.Text.Trim();
            sv.SDT = txtSDT.Text.Trim();
            sv.Email = txtEmail.Text.Trim();
            sv.DiaChi = txtDiaChi.Text.Trim();
            sv.DoiTuongUuTien = txtDoiTuongUuTien.Text.Trim();

            if (bus.SuaSinhVien(sv))
            {
                MessageBox.Show("Sửa sinh viên thành công!");

                dgvSinhVien.DataSource = bus.LayDanhSachSinhVien();
            }
            else
            {
                MessageBox.Show("Sửa sinh viên thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn xóa sinh viên này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                if (bus.XoaSinhVien(txtMaSV.Text.Trim()))
                {
                    MessageBox.Show("Xóa sinh viên thành công!");

                    dgvSinhVien.DataSource = bus.LayDanhSachSinhVien();

                    txtMaSV.Clear();
                    txtHoTen.Clear();
                    txtLop.Clear();
                    txtKhoa.Clear();
                    txtSDT.Clear();
                    txtEmail.Clear();
                    txtDiaChi.Clear();
                    txtDoiTuongUuTien.Clear();

                    cboGioiTinh.SelectedIndex = 0;
                    dtpNgaySinh.Value = DateTime.Now;

                    txtMaSV.Focus();
                }
                else
                {
                    MessageBox.Show("Xóa sinh viên thất bại!");
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtLop.Clear();
            txtKhoa.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtDoiTuongUuTien.Clear();

            cboGioiTinh.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Now;

            txtMaSV.Enabled = true;
            txtMaSV.Focus();

            dgvSinhVien.DataSource = bus.LayDanhSachSinhVien();
            dgvSinhVien.ClearSelection();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ma = txtMaSV.Text.Trim();
            string ten = txtHoTen.Text.Trim();

            if (ma == "" && ten == "")
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên hoặc họ tên cần tìm!");
                return;
            }

            DataTable dt = bus.TimKiemSinhVien(ma, ten);

            dgvSinhVien.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sinh viên!");
            }
        }
    }
}
