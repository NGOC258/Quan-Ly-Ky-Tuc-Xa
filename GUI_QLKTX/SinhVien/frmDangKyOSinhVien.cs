using System;
using System.Data;
using System.Windows.Forms;
using BUS_QLKTX;
using DTO_QLKTX;

namespace GUI_QLKTX
{
    public partial class frmDangKyOSinhVien : Form
    {
        private string maSV;

        BUS_DangKyOSinhVien bus = new BUS_DangKyOSinhVien();

        public frmDangKyOSinhVien(string maSV)
        {
            InitializeComponent();
            this.maSV = maSV;
        }

        private void frmDangKyOSinhVien_Load(object sender, EventArgs e)
        {
            LoadThongTinSinhVien();

            cboDoiTuongUuTien.Items.Clear();
            cboDoiTuongUuTien.Items.Add("Không");
            cboDoiTuongUuTien.Items.Add("Hộ nghèo / cận nghèo");
            cboDoiTuongUuTien.Items.Add("Khuyết tật");
            cboDoiTuongUuTien.Items.Add("Dân tộc thiểu số");
            cboDoiTuongUuTien.Items.Add("Con gia đình chính sách");
            cboDoiTuongUuTien.Items.Add("Mồ côi");
            cboDoiTuongUuTien.Items.Add("Đối tượng khác");
            cboDoiTuongUuTien.SelectedIndex = 0;

            dtpNgayDangKy.Format = DateTimePickerFormat.Custom;
            dtpNgayDangKy.CustomFormat = "dd/MM/yyyy";
            dtpNgayDangKy.Value = DateTime.Now;
            dtpNgayDangKy.Enabled = false;

            lblTrangThai.Text = "Chờ duyệt";

            LoadDanhSachDangKy();
        }

        private void LoadThongTinSinhVien()
        {
            DataTable dt = bus.LayThongTinSinhVien(maSV);

            if (dt.Rows.Count > 0)
            {
                lblMaSV.Text = dt.Rows[0]["MaSV"].ToString();
                lblHoTen.Text = dt.Rows[0]["HoTen"].ToString();
            }
            else
            {
                lblMaSV.Text = "Không tìm thấy";
                lblHoTen.Text = "Không tìm thấy";
                btnDangKy.Enabled = false;
            }
        }

        private void LoadDanhSachDangKy()
        {
            dgvDangKyCuaToi.DataSource = bus.LayDangKyCuaSinhVien(maSV);
            dgvDangKyCuaToi.ClearSelection();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (bus.CoDangKyDaDuyet(maSV))
            {
                MessageBox.Show("Bạn đã có đăng ký được duyệt, không thể đăng ký thêm!");
                return;
            }

            if (bus.CoDangKyChoDuyet(maSV))
            {
                MessageBox.Show("Bạn đã có một đăng ký đang chờ duyệt!");
                return;
            }

            if (cboDoiTuongUuTien.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đối tượng ưu tiên!");
                cboDoiTuongUuTien.Focus();
                return;
            }

            DTO_DangKyO dk = new DTO_DangKyO();

            dk.MaDangKy = bus.TaoMaDangKyMoi();
            dk.MaSV = maSV;
            dk.MaGiuong = null;
            dk.DoiTuongUuTien = cboDoiTuongUuTien.Text;
            dk.NgayDangKy = DateTime.Now;
            dk.TrangThaiDangKy = "Chờ duyệt";

            if (bus.ThemDangKy(dk))
            {
                MessageBox.Show("Gửi đăng ký ở thành công! Mã đăng ký của bạn là " + dk.MaDangKy + ". Vui lòng chờ duyệt.");

                LamMoi();
            }
            else
            {
                MessageBox.Show("Gửi đăng ký thất bại!");
            }
        }

        private void LamMoi()
        {
            cboDoiTuongUuTien.SelectedIndex = 0;
            dtpNgayDangKy.Value = DateTime.Now;
            lblTrangThai.Text = "Chờ duyệt";

            LoadThongTinSinhVien();
            LoadDanhSachDangKy();

            cboDoiTuongUuTien.Focus();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboDoiTuongUuTien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}