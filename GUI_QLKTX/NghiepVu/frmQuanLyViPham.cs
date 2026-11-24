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

namespace GUI_QLKTX.NghiepVu
{
    public partial class frmQuanLyViPham : Form
    {
        BUS_ViPham bus = new BUS_ViPham();
        private string vaiTro;

        public frmQuanLyViPham(string vaiTro)
        {
            InitializeComponent();
            this.vaiTro = vaiTro;
        }

        private void frmQuanLyViPham_Load(object sender, EventArgs e)
        {
            txtMaViPham.ReadOnly = true;
            txtHoTen.ReadOnly = true;
            txtLanViPham.ReadOnly = true;
            txtHinhThucXuLy.ReadOnly = true;

            txtHinhThucXuLy.Multiline = true;
            txtGhiChu.Multiline = true;

            dtpNgayViPham.Format = DateTimePickerFormat.Custom;
            dtpNgayViPham.CustomFormat = "dd/MM/yyyy";
            dtpNgayViPham.Value = DateTime.Now;

            LoadLoaiViPham();
            LoadDanhSachViPham();
            LamMoi();

            if (vaiTro == "Admin")
            {
                btnSua.Visible = true;
                btnXoa.Visible = true;
            }
            else
            {
                btnSua.Visible = false;
                btnXoa.Visible = false;
            }
        }
        private void LoadLoaiViPham()
        {
            DataTable dt = bus.LayDanhSachLoaiViPham();

            cboLoaiViPham.DataSource = dt;
            cboLoaiViPham.DisplayMember = "TenViPham";
            cboLoaiViPham.ValueMember = "MaLoaiViPham";
            cboLoaiViPham.SelectedIndex = -1;
        }

        private void LoadDanhSachViPham()
        {
            dgvViPham.DataSource = bus.LayDanhSachViPham();
            dgvViPham.ClearSelection();
        }

        private void btnTimSinhVien_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();

            if (maSV == "")
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!");
                txtMaSV.Focus();
                return;
            }

            DataTable dt = bus.TimSinhVienTheoMa(maSV);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sinh viên!");
                txtHoTen.Clear();
                txtLanViPham.Clear();
                txtHinhThucXuLy.Clear();
                txtMaSV.Focus();
                return;
            }

            txtHoTen.Text = dt.Rows[0]["HoTen"].ToString();

            CapNhatThongTinXuLy();
        }

        private void cboLoaiViPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatThongTinXuLy();
        }
        private void CapNhatThongTinXuLy()
        {
            if (txtMaSV.Text.Trim() == "")
            {
                txtLanViPham.Clear();
                txtHinhThucXuLy.Clear();
                return;
            }

            if (txtHoTen.Text.Trim() == "")
            {
                txtLanViPham.Clear();
                txtHinhThucXuLy.Clear();
                return;
            }

            if (cboLoaiViPham.SelectedIndex == -1 || cboLoaiViPham.SelectedValue == null)
            {
                txtLanViPham.Clear();
                txtHinhThucXuLy.Clear();
                return;
            }

            string maSV = txtMaSV.Text.Trim();
            string maLoaiViPham = cboLoaiViPham.SelectedValue.ToString();

            int lanViPham = bus.LayLanViPhamTiepTheo(maSV, maLoaiViPham);
            string hinhThucXuLy = bus.LayHinhThucXuLy(maLoaiViPham, lanViPham);

            txtLanViPham.Text = lanViPham.ToString();
            txtHinhThucXuLy.Text = hinhThucXuLy;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();

            if (maSV == "")
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!");
                txtMaSV.Focus();
                return;
            }

            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng tìm và xác nhận sinh viên trước!");
                btnTimSinhVien.Focus();
                return;
            }

            if (cboLoaiViPham.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại vi phạm!");
                cboLoaiViPham.Focus();
                return;
            }

            if (txtLanViPham.Text.Trim() == "")
            {
                MessageBox.Show("Chưa xác định được lần vi phạm!");
                return;
            }

            if (txtHinhThucXuLy.Text.Trim() == "")
            {
                MessageBox.Show("Chưa xác định được hình thức xử lý!");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn ghi nhận vi phạm này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.No)
            {
                return;
            }

            DTO_ViPham vp = new DTO_ViPham();

            vp.MaViPham = bus.TaoMaViPhamMoi();
            vp.MaSV = maSV;
            vp.MaLoaiViPham = cboLoaiViPham.SelectedValue.ToString();
            vp.NgayViPham = dtpNgayViPham.Value.Date;
            vp.LanViPham = Convert.ToInt32(txtLanViPham.Text);
            vp.HinhThucXuLy = txtHinhThucXuLy.Text.Trim();
            vp.GhiChu = txtGhiChu.Text.Trim();

            if (bus.ThemViPham(vp))
            {
                MessageBox.Show("Thêm vi phạm thành công! Mã vi phạm: " + vp.MaViPham);
                LoadDanhSachViPham();
                LamMoi();
            }
            else
            {
                MessageBox.Show("Thêm vi phạm thất bại!");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (tuKhoa == "")
            {
                LoadDanhSachViPham();
                return;
            }

            dgvViPham.DataSource = bus.TimKiemViPham(tuKhoa);
            dgvViPham.ClearSelection();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            LoadDanhSachViPham();
        }

        private void LamMoi()
        {
            txtMaViPham.Text = bus.TaoMaViPhamMoi();

            txtMaSV.Clear();
            txtHoTen.Clear();

            cboLoaiViPham.SelectedIndex = -1;

            txtLanViPham.Clear();
            txtHinhThucXuLy.Clear();
            txtGhiChu.Clear();
            txtTimKiem.Clear();

            dtpNgayViPham.Value = DateTime.Now;

            dgvViPham.ClearSelection();

            txtMaSV.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}