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
    public partial class frmHopDong : Form
    {
        BUS_HopDong bus = new BUS_HopDong();
        public frmHopDong()
        {
            InitializeComponent();
        }

     
       private void frmHopDong_Load(object sender, EventArgs e)
        {
            txtMaHopDong.ReadOnly = true;
            txtMaHopDong.Text = bus.TaoMaHopDongMoi();

            dgvHopDong.DataSource = bus.LayDanhSachHopDong();
            dgvHopDong.ClearSelection();

            cboDangKyO.DataSource = bus.LayDanhSachDangKyDaDuyet();
            cboDangKyO.DisplayMember = "MaDangKy";
            cboDangKyO.ValueMember = "MaDangKy";
            cboDangKyO.SelectedIndex = -1;

            cboTrangThai.SelectedIndex = 0;

            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayBatDau.Format = DateTimePickerFormat.Custom;
            dtpNgayBatDau.CustomFormat = "dd/MM/yyyy";

            dtpNgayKetThuc.Value = DateTime.Now.AddYears(1);
            dtpNgayKetThuc.Format = DateTimePickerFormat.Custom;
            dtpNgayKetThuc.CustomFormat = "dd/MM/yyyy";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboDangKyO.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đăng ký ở đã được duyệt!");
                return;
            }

            if (cboTrangThai.Text == "")
            {
                MessageBox.Show("Vui lòng chọn trạng thái hợp đồng!");
                return;
            }

            string maDangKy = cboDangKyO.SelectedValue.ToString();

            if (bus.KiemTraDangKyDaCoHopDong(maDangKy))
            {
                MessageBox.Show("Đăng ký này đã có hợp đồng!");
                return;
            }

            if (dtpNgayKetThuc.Value.Date <= dtpNgayBatDau.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu!");
                dtpNgayKetThuc.Focus();
                return;
            }

            DTO_HopDong hd = new DTO_HopDong();

            hd.MaHopDong = txtMaHopDong.Text.Trim();
            hd.MaDangKy = maDangKy;
            hd.NgayBatDau = dtpNgayBatDau.Value;
            hd.NgayKetThuc = dtpNgayKetThuc.Value;
            hd.TrangThaiHopDong = cboTrangThai.Text;

            if (bus.ThemHopDong(hd))
            {
                MessageBox.Show("Thêm hợp đồng thành công!");

                dgvHopDong.DataSource = bus.LayDanhSachHopDong();
                dgvHopDong.ClearSelection();

                cboDangKyO.DataSource = bus.LayDanhSachDangKyDaDuyet();
                cboDangKyO.DisplayMember = "MaDangKy";
                cboDangKyO.ValueMember = "MaDangKy";
                cboDangKyO.SelectedIndex = -1;

                txtMaHopDong.Text = bus.TaoMaHopDongMoi();
                dtpNgayBatDau.Value = DateTime.Now;
                dtpNgayKetThuc.Value = DateTime.Now.AddYears(1);
                cboTrangThai.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Thêm hợp đồng thất bại!");
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHopDong.Text = bus.TaoMaHopDongMoi();
            txtTimKiem.Clear();

            cboDangKyO.Enabled = true;
            cboDangKyO.DataSource = bus.LayDanhSachDangKyDaDuyet();
            cboDangKyO.DisplayMember = "MaDangKy";
            cboDangKyO.ValueMember = "MaDangKy";
            cboDangKyO.SelectedIndex = -1;

            cboTrangThai.SelectedIndex = 0;

            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now.AddYears(1);

            dgvHopDong.DataSource = bus.LayDanhSachHopDong();
            dgvHopDong.ClearSelection();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                "Bạn có muốn thoát khỏi quản lý hợp đồng không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvHopDong.Rows[e.RowIndex];

            txtMaHopDong.Text = row.Cells["MaHopDong"].Value.ToString();

            string maDangKy = row.Cells["MaDangKy"].Value.ToString();

            cboDangKyO.DataSource = bus.LayDangKyDaDuyetKhiSua(maDangKy);
            cboDangKyO.DisplayMember = "MaDangKy";
            cboDangKyO.ValueMember = "MaDangKy";
            cboDangKyO.SelectedValue = maDangKy;

            dtpNgayBatDau.Value = Convert.ToDateTime(row.Cells["NgayBatDau"].Value);
            dtpNgayKetThuc.Value = Convert.ToDateTime(row.Cells["NgayKetThuc"].Value);
            cboTrangThai.Text = row.Cells["TrangThaiHopDong"].Value.ToString();

            cboDangKyO.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaHopDong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần sửa!");
                return;
            }

            if (cboDangKyO.SelectedIndex == -1)
            {
                MessageBox.Show("Không xác định được đăng ký ở của hợp đồng!");
                return;
            }

            if (cboTrangThai.Text == "")
            {
                MessageBox.Show("Vui lòng chọn trạng thái hợp đồng!");
                return;
            }

            if (dtpNgayKetThuc.Value.Date <= dtpNgayBatDau.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu!");
                return;
            }

            DTO_HopDong hd = new DTO_HopDong();

            hd.MaHopDong = txtMaHopDong.Text.Trim();
            hd.MaDangKy = cboDangKyO.SelectedValue.ToString();
            hd.NgayBatDau = dtpNgayBatDau.Value;
            hd.NgayKetThuc = dtpNgayKetThuc.Value;
            hd.TrangThaiHopDong = cboTrangThai.Text;

            if (bus.SuaHopDong(hd))
            {
                MessageBox.Show("Sửa hợp đồng thành công!");
                btnLamMoi_Click(null, null);
            }
            else
            {
                MessageBox.Show("Sửa hợp đồng thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHopDong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần xóa!");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn xóa hợp đồng này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                if (bus.XoaHopDong(txtMaHopDong.Text.Trim()))
                {
                    MessageBox.Show("Xóa hợp đồng thành công!");

                    txtMaHopDong.Text = bus.TaoMaHopDongMoi();

                    cboDangKyO.Enabled = true;
                    cboDangKyO.DataSource = bus.LayDanhSachDangKyDaDuyet();
                    cboDangKyO.DisplayMember = "MaDangKy";
                    cboDangKyO.ValueMember = "MaDangKy";
                    cboDangKyO.SelectedIndex = -1;

                    cboTrangThai.SelectedIndex = 0;

                    dtpNgayBatDau.Value = DateTime.Now;
                    dtpNgayKetThuc.Value = DateTime.Now.AddYears(1);

                    dgvHopDong.DataSource = bus.LayDanhSachHopDong();
                    dgvHopDong.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Xóa hợp đồng thất bại!");
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (tuKhoa == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm!");
                txtTimKiem.Focus();
                return;
            }

            DataTable dt = bus.TimKiemHopDong(tuKhoa);

            dgvHopDong.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hợp đồng!");
            }
        }
    }
}
