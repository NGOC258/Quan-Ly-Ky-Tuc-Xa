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
using System.Data;
namespace GUI_QLKTX
{
    public partial class frmQuanLyNhanVien : Form
    {
        BUS_NhanVien bus = new BUS_NhanVien();
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = bus.LayDanhSachNhanVien();

            cboChucVu.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!");
                txtMaNV.Focus();
                return;
            }

            if (bus.KiemTraMaNV(txtMaNV.Text.Trim()))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại!");
                txtMaNV.Focus();
                return;
            }

            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên nhân viên!");
                txtHoTen.Focus();
                return;
            }

            DTO_NhanVien nv = new DTO_NhanVien();

            nv.MaNV = txtMaNV.Text.Trim();
            nv.HoTen = txtHoTen.Text.Trim();
            nv.ChucVu = cboChucVu.Text;
            nv.SDT = txtSDT.Text.Trim();
            nv.Email = txtEmail.Text.Trim();

            if (bus.ThemNhanVien(nv))
            {
                MessageBox.Show("Thêm nhân viên thành công!");

                dgvNhanVien.DataSource = bus.LayDanhSachNhanVien();

                txtMaNV.Clear();
                txtHoTen.Clear();
                txtSDT.Clear();
                txtEmail.Clear();

                cboChucVu.SelectedIndex = 0;

                txtMaNV.Focus();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                "Bạn có muốn thoát khỏi quản lý nhân viên không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                cboChucVu.Text = row.Cells["ChucVu"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();

            cboChucVu.SelectedIndex = 0;

            txtMaNV.Enabled = true;
            txtMaNV.Focus();

            dgvNhanVien.DataSource = bus.LayDanhSachNhanVien();
            dgvNhanVien.ClearSelection();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!");
                return;
            }

            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên nhân viên!");
                txtHoTen.Focus();
                return;
            }

            DTO_NhanVien nv = new DTO_NhanVien();

            nv.MaNV = txtMaNV.Text.Trim();
            nv.HoTen = txtHoTen.Text.Trim();
            nv.ChucVu = cboChucVu.Text;
            nv.SDT = txtSDT.Text.Trim();
            nv.Email = txtEmail.Text.Trim();

            if (bus.SuaNhanVien(nv))
            {
                MessageBox.Show("Sửa nhân viên thành công!");

                dgvNhanVien.DataSource = bus.LayDanhSachNhanVien();
            }
            else
            {
                MessageBox.Show("Sửa nhân viên thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn xóa nhân viên này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                if (bus.XoaNhanVien(txtMaNV.Text.Trim()))
                {
                    MessageBox.Show("Xóa nhân viên thành công!");

                    dgvNhanVien.DataSource = bus.LayDanhSachNhanVien();

                    txtMaNV.Clear();
                    txtHoTen.Clear();
                    txtSDT.Clear();
                    txtEmail.Clear();

                    cboChucVu.SelectedIndex = 0;

                    txtMaNV.Focus();
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên thất bại!");
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ma = txtMaNV.Text.Trim();
            string ten = txtHoTen.Text.Trim();

            if (ma == "" && ten == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên hoặc họ tên cần tìm!");
                return;
            }

            DataTable dt = bus.TimKiemNhanVien(ma, ten);

            dgvNhanVien.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên!");
            }
        }
    }
}
