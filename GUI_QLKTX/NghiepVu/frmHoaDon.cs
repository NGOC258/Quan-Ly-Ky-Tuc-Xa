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
    public partial class frmHoaDon : Form
    {

        BUS_HoaDon bus = new BUS_HoaDon();
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void txtMaHopDong_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dtpNgayLap_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            txtMaHoaDon.ReadOnly = true;
            txtMaHoaDon.Text = bus.TaoMaHoaDonMoi();

            dgvHoaDon.DataSource = bus.LayDanhSachHoaDon();
            dgvHoaDon.ClearSelection();

            cboHopDong.DataSource = bus.LayDanhSachHopDong();
            cboHopDong.DisplayMember = "MaHopDong";
            cboHopDong.ValueMember = "MaHopDong";
            cboHopDong.SelectedIndex = -1;

            cboThang.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;

            txtNam.Text = DateTime.Now.Year.ToString();

            dtpNgayLap.Value = DateTime.Now;
            dtpNgayLap.Format = DateTimePickerFormat.Custom;
            dtpNgayLap.CustomFormat = "dd/MM/yyyy";

            txtTongTien.ReadOnly = true;
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void TinhTongTien()
        {
            decimal tienPhong = 0;
            decimal tienDien = 0;
            decimal tienNuoc = 0;
            decimal phiDichVu = 0;

            decimal.TryParse(txtTienPhong.Text.Trim(), out tienPhong);
            decimal.TryParse(txtTienDien.Text.Trim(), out tienDien);
            decimal.TryParse(txtTienNuoc.Text.Trim(), out tienNuoc);
            decimal.TryParse(txtPhiDichVu.Text.Trim(), out phiDichVu);

            decimal tongTien =
                tienPhong + tienDien + tienNuoc + phiDichVu;

            txtTongTien.Text = tongTien.ToString();
        }

        private void txtTienPhong_TextChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void txtTienDien_TextChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void txtTienNuoc_TextChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void txtPhiDichVu_TextChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            

            if (cboHopDong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng!");
                return;
            }

            int thang;

            if (!int.TryParse(cboThang.Text, out thang))
            {
                MessageBox.Show("Tháng không hợp lệ!");
                return;
            }

            int nam;

            if (!int.TryParse(txtNam.Text.Trim(), out nam))
            {
                MessageBox.Show("Năm phải là số!");
                txtNam.Focus();
                return;
            }

            decimal tienPhong;
            decimal tienDien;
            decimal tienNuoc;
            decimal phiDichVu;

            if (!decimal.TryParse(txtTienPhong.Text.Trim(), out tienPhong))
            {
                MessageBox.Show("Tiền phòng phải là số!");
                txtTienPhong.Focus();
                return;
            }

            if (!decimal.TryParse(txtTienDien.Text.Trim(), out tienDien))
            {
                MessageBox.Show("Tiền điện phải là số!");
                txtTienDien.Focus();
                return;
            }

            if (!decimal.TryParse(txtTienNuoc.Text.Trim(), out tienNuoc))
            {
                MessageBox.Show("Tiền nước phải là số!");
                txtTienNuoc.Focus();
                return;
            }

            if (!decimal.TryParse(txtPhiDichVu.Text.Trim(), out phiDichVu))
            {
                MessageBox.Show("Phí dịch vụ phải là số!");
                txtPhiDichVu.Focus();
                return;
            }
            if (tienPhong < 0 || tienDien < 0 || tienNuoc < 0 || phiDichVu < 0)
            {
                MessageBox.Show("Các khoản tiền không được nhỏ hơn 0!");
                return;
            }

            string maHopDong = cboHopDong.SelectedValue.ToString();

            if (bus.KiemTraHoaDonTheoThang(maHopDong, thang, nam))
            {
                MessageBox.Show(
                    "Hợp đồng này đã có hóa đơn trong tháng " +
                    thang + "/" + nam + "!");

                return;
            }

            decimal tongTien =
                tienPhong + tienDien + tienNuoc + phiDichVu;

            DTO_HoaDon hd = new DTO_HoaDon();

            hd.MaHoaDon = txtMaHoaDon.Text.Trim();
            hd.MaHopDong = maHopDong;
            hd.Thang = thang;
            hd.Nam = nam;

            hd.TienPhong = tienPhong;
            hd.TienDien = tienDien;
            hd.TienNuoc = tienNuoc;
            hd.PhiDichVu = phiDichVu;
            hd.TongTien = tongTien;

            hd.NgayLap = dtpNgayLap.Value;
            hd.TrangThaiThanhToan = cboTrangThai.Text;

            if (bus.ThemHoaDon(hd))
            {
                MessageBox.Show("Thêm hóa đơn thành công!");

                dgvHoaDon.DataSource = bus.LayDanhSachHoaDon();

                txtMaHoaDon.Text = bus.TaoMaHoaDonMoi();

                cboHopDong.SelectedIndex = -1;
                cboThang.SelectedIndex = 0;

                txtNam.Text = DateTime.Now.Year.ToString();

                txtTienPhong.Clear();
                txtTienDien.Clear();
                txtTienNuoc.Clear();
                txtPhiDichVu.Clear();
                txtTongTien.Clear();

                dtpNgayLap.Value = DateTime.Now;
                cboTrangThai.SelectedIndex = 0;

                
            }
            else
            {
                MessageBox.Show("Thêm hóa đơn thất bại!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                "Bạn có muốn thoát khỏi quản lý hóa đơn không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHoaDon.Text = bus.TaoMaHoaDonMoi();
            txtTimKiem.Clear();

            cboHopDong.Enabled = true;
            cboThang.Enabled = true;
            txtNam.Enabled = true;

            cboHopDong.DataSource = bus.LayDanhSachHopDong();
            cboHopDong.DisplayMember = "MaHopDong";
            cboHopDong.ValueMember = "MaHopDong";
            cboHopDong.SelectedIndex = -1;

            cboThang.SelectedIndex = 0;
            txtNam.Text = DateTime.Now.Year.ToString();

            txtTienPhong.Clear();
            txtTienDien.Clear();
            txtTienNuoc.Clear();
            txtPhiDichVu.Clear();
            txtTongTien.Clear();

            dtpNgayLap.Value = DateTime.Now;
            cboTrangThai.SelectedIndex = 0;

            dgvHoaDon.DataSource = bus.LayDanhSachHoaDon();
            dgvHoaDon.ClearSelection();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];

            txtMaHoaDon.Text = row.Cells["MaHoaDon"].Value.ToString();

            string maHopDong = row.Cells["MaHopDong"].Value.ToString();

            cboHopDong.DataSource = bus.LayHopDongKhiSua(maHopDong);
            cboHopDong.DisplayMember = "MaHopDong";
            cboHopDong.ValueMember = "MaHopDong";
            cboHopDong.SelectedValue = maHopDong;

            cboThang.Text = row.Cells["Thang"].Value.ToString();
            txtNam.Text = row.Cells["Nam"].Value.ToString();

            txtTienPhong.Text = row.Cells["TienPhong"].Value.ToString();
            txtTienDien.Text = row.Cells["TienDien"].Value.ToString();
            txtTienNuoc.Text = row.Cells["TienNuoc"].Value.ToString();
            txtPhiDichVu.Text = row.Cells["PhiDichVu"].Value.ToString();
            txtTongTien.Text = row.Cells["TongTien"].Value.ToString();

            dtpNgayLap.Value = Convert.ToDateTime(row.Cells["NgayLap"].Value);
            cboTrangThai.Text = row.Cells["TrangThaiThanhToan"].Value.ToString();

            cboHopDong.Enabled = false;
            cboThang.Enabled = false;
            txtNam.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần sửa!");
                return;
            }

            if (cboHopDong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng!");
                return;
            }

            int thang;
            int nam;

            if (!int.TryParse(cboThang.Text, out thang))
            {
                MessageBox.Show("Tháng không hợp lệ!");
                return;
            }

            if (!int.TryParse(txtNam.Text.Trim(), out nam))
            {
                MessageBox.Show("Năm phải là số!");
                return;
            }

            decimal tienPhong;
            decimal tienDien;
            decimal tienNuoc;
            decimal phiDichVu;

            if (!decimal.TryParse(txtTienPhong.Text.Trim(), out tienPhong))
            {
                MessageBox.Show("Tiền phòng phải là số!");
                return;
            }

            if (!decimal.TryParse(txtTienDien.Text.Trim(), out tienDien))
            {
                MessageBox.Show("Tiền điện phải là số!");
                return;
            }

            if (!decimal.TryParse(txtTienNuoc.Text.Trim(), out tienNuoc))
            {
                MessageBox.Show("Tiền nước phải là số!");
                return;
            }

            if (!decimal.TryParse(txtPhiDichVu.Text.Trim(), out phiDichVu))
            {
                MessageBox.Show("Phí dịch vụ phải là số!");
                return;
            }

            DTO_HoaDon hd = new DTO_HoaDon();

            hd.MaHoaDon = txtMaHoaDon.Text.Trim();
            hd.MaHopDong = cboHopDong.SelectedValue.ToString();
            hd.Thang = thang;
            hd.Nam = nam;

            hd.TienPhong = tienPhong;
            hd.TienDien = tienDien;
            hd.TienNuoc = tienNuoc;
            hd.PhiDichVu = phiDichVu;

            hd.TongTien =
                tienPhong + tienDien + tienNuoc + phiDichVu;

            hd.NgayLap = dtpNgayLap.Value;
            hd.TrangThaiThanhToan = cboTrangThai.Text;

            if (bus.SuaHoaDon(hd))
            {
                MessageBox.Show("Sửa hóa đơn thành công!");

                btnLamMoi_Click(null, null);
            }
            else
            {
                MessageBox.Show("Sửa hóa đơn thất bại!");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (tuKhoa == "")
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn hoặc mã hợp đồng cần tìm!");
                txtTimKiem.Focus();
                return;
            }

            DataTable dt = bus.TimKiemHoaDon(tuKhoa);
            dgvHoaDon.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn xóa hóa đơn này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                if (bus.XoaHoaDon(txtMaHoaDon.Text.Trim()))
                {
                    MessageBox.Show("Xóa hóa đơn thành công!");
                    btnLamMoi_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Xóa hóa đơn thất bại!");
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
