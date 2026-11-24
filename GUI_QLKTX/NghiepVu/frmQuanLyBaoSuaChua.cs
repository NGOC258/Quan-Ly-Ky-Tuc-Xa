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
    public partial class frmQuanLyBaoSuaChua : Form
    {
        BUS_BaoSuaChuaNhanVien bus = new BUS_BaoSuaChuaNhanVien();
        private string vaiTro;
        public frmQuanLyBaoSuaChua(string vaiTro)
        {
            InitializeComponent();
            this.vaiTro = vaiTro;
        }

        private void frmQuanLyBaoSuaChua_Load(object sender, EventArgs e)
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Chờ xử lý");
            cboTrangThai.Items.Add("Đang xử lý");
            cboTrangThai.Items.Add("Đã hoàn thành");
            cboTrangThai.Items.Add("Từ chối");

            txtMaBaoSua.ReadOnly = true;
            txtMaSV.ReadOnly = true;
            txtPhong.ReadOnly = true;
            txtGiuong.ReadOnly = true;

            dtpNgayBao.Format = DateTimePickerFormat.Custom;
            dtpNgayBao.CustomFormat = "dd/MM/yyyy";

            if (vaiTro == "Admin")
            {
                btnSua.Visible = true;
                btnXoa.Visible = true;

                txtLoaiSuCo.ReadOnly = false;
                txtMoTa.ReadOnly = false;
                dtpNgayBao.Enabled = true;
            }
            else
            {
                btnSua.Visible = false;
                btnXoa.Visible = false;

                txtLoaiSuCo.ReadOnly = true;
                txtMoTa.ReadOnly = true;
                dtpNgayBao.Enabled = false;
            }

            LoadDanhSachBaoSua();
            LamMoi();

        }
        private void LoadDanhSachBaoSua()
        {
            dgvBaoSuaChua.DataSource = bus.LayDanhSachBaoSua();
            dgvBaoSuaChua.ClearSelection();
        }


        private void dgvBaoSuaChua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvBaoSuaChua.Rows[e.RowIndex];

            txtMaBaoSua.Text = row.Cells["MaBaoSua"].Value.ToString();
            txtMaSV.Text = row.Cells["MaSV"].Value.ToString();
            txtPhong.Text = row.Cells["TenPhong"].Value.ToString();

            if (row.Cells["SoHieuGiuong"].Value != DBNull.Value)
            {
                txtGiuong.Text = row.Cells["SoHieuGiuong"].Value.ToString();
            }
            else
            {
                txtGiuong.Text = "";
            }

            txtLoaiSuCo.Text = row.Cells["LoaiSuCo"].Value.ToString();
            txtMoTa.Text = row.Cells["MoTa"].Value.ToString();

            if (row.Cells["NgayBao"].Value != DBNull.Value)
            {
                dtpNgayBao.Value = Convert.ToDateTime(row.Cells["NgayBao"].Value);
            }

            cboTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string maBaoSua = txtMaBaoSua.Text.Trim();

            if (maBaoSua == "")
            {
                MessageBox.Show("Vui lòng chọn một báo sửa cần cập nhật!");
                return;
            }

            if (cboTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!");
                cboTrangThai.Focus();
                return;
            }

            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc muốn cập nhật trạng thái báo sửa này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua == DialogResult.No)
            {
                return;
            }

            if (bus.CapNhatTrangThai(maBaoSua, cboTrangThai.Text))
            {
                MessageBox.Show("Cập nhật trạng thái thành công!");
                LoadDanhSachBaoSua();
                LamMoi();
            }
            else
            {
                MessageBox.Show("Cập nhật trạng thái thất bại!");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            LoadDanhSachBaoSua();
        }
        private void LamMoi()
        {
            txtMaBaoSua.Clear();
            txtMaSV.Clear();
            txtPhong.Clear();
            txtGiuong.Clear();
            txtLoaiSuCo.Clear();
            txtMoTa.Clear();
            txtTimKiem.Clear();

            dtpNgayBao.Value = DateTime.Now;
            cboTrangThai.SelectedIndex = -1;

            dgvBaoSuaChua.ClearSelection();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (tuKhoa == "")
            {
                LoadDanhSachBaoSua();
                return;
            }

            dgvBaoSuaChua.DataSource = bus.TimKiemBaoSua(tuKhoa);
            dgvBaoSuaChua.ClearSelection();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaBaoSua.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn báo sửa cần sửa!");
                return;
            }

            if (txtLoaiSuCo.Text.Trim() == "")
            {
                MessageBox.Show("Loại sự cố không được để trống!");
                txtLoaiSuCo.Focus();
                return;
            }

            if (cboTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!");
                cboTrangThai.Focus();
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn sửa báo sửa này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.No)
            {
                return;
            }

            bool kq = bus.SuaBaoSua(
                txtMaBaoSua.Text.Trim(),
                txtLoaiSuCo.Text.Trim(),
                txtMoTa.Text.Trim(),
                dtpNgayBao.Value,
                cboTrangThai.Text);

            if (kq)
            {
                MessageBox.Show("Sửa báo sửa thành công!");
                LoadDanhSachBaoSua();
                LamMoi();
            }
            else
            {
                MessageBox.Show("Sửa báo sửa thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maBaoSua = txtMaBaoSua.Text.Trim();

            if (maBaoSua == "")
            {
                MessageBox.Show("Vui lòng chọn báo sửa cần xóa!");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn xóa báo sửa " + maBaoSua + " không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (rs == DialogResult.No)
            {
                return;
            }

            if (bus.XoaBaoSua(maBaoSua))
            {
                MessageBox.Show("Xóa báo sửa thành công!");
                LoadDanhSachBaoSua();
                LamMoi();
            }
            else
            {
                MessageBox.Show("Xóa báo sửa thất bại!");
            }
        }
    }
}
