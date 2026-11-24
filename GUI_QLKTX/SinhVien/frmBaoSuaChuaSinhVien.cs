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
    public partial class frmBaoSuaChuaSinhVien : Form
    {
        private string maSV;
        private string maPhong;
        private string maGiuong;

        BUS_BaoSuaChuaSinhVien bus = new BUS_BaoSuaChuaSinhVien();
        public frmBaoSuaChuaSinhVien(string maSV)
        {
            InitializeComponent();
            this.maSV = maSV;
        }

        private void frmBaoSuaChuaSinhVien_Load(object sender, EventArgs e)
        {
            cboLoaiSuCo.Items.Clear();
            cboLoaiSuCo.Items.Add("Điện");
            cboLoaiSuCo.Items.Add("Nước");
            cboLoaiSuCo.Items.Add("Đèn");
            cboLoaiSuCo.Items.Add("Quạt");
            cboLoaiSuCo.Items.Add("Cửa");
            cboLoaiSuCo.Items.Add("Giường");
            cboLoaiSuCo.Items.Add("Nhà vệ sinh");
            cboLoaiSuCo.Items.Add("Thiết bị khác");
            cboLoaiSuCo.SelectedIndex = 0;

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Chờ xử lý");
            cboTrangThai.SelectedIndex = 0;
            cboTrangThai.Enabled = false;

            dtpNgayBao.Format = DateTimePickerFormat.Custom;
            dtpNgayBao.CustomFormat = "dd/MM/yyyy";
            dtpNgayBao.Value = DateTime.Now;
            dtpNgayBao.Enabled = false;

            LoadThongTinChoO();
            LoadDanhSachBaoSua();
        }

        private void LoadThongTinChoO()
        {
            DataTable dt = bus.LayThongTinChoOHienTai(maSV);

            if (dt.Rows.Count > 0)
            {
                maPhong = dt.Rows[0]["MaPhong"].ToString();
                maGiuong = dt.Rows[0]["MaGiuong"].ToString();

                lblPhongHienTai.Text = dt.Rows[0]["TenPhong"].ToString();
                lblGiuongHienTai.Text = dt.Rows[0]["SoHieuGiuong"].ToString();

                btnGuiBaoSua.Enabled = true;
            }
            else
            {
                maPhong = null;
                maGiuong = null;

                lblPhongHienTai.Text = "Chưa có";
                lblGiuongHienTai.Text = "Chưa có";

                btnGuiBaoSua.Enabled = false;
            }
        }

        private void LoadDanhSachBaoSua()
        {
            dgvBaoSuaCuaToi.DataSource = bus.LayBaoSuaCuaSinhVien(maSV);
            dgvBaoSuaCuaToi.ClearSelection();
        }

        private void btnGuiBaoSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maPhong) || string.IsNullOrEmpty(maGiuong))
            {
                MessageBox.Show("Không tìm thấy thông tin phòng/giường hiện tại. Vui lòng liên hệ nhân viên KTX!");
                return;
            }

            if (cboLoaiSuCo.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại sự cố!");
                cboLoaiSuCo.Focus();
                return;
            }

            if (txtMoTa.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mô tả sự cố!");
                txtMoTa.Focus();
                return;
            }

            DTO_BaoSuaChua bs = new DTO_BaoSuaChua();

            bs.MaBaoSua = bus.TaoMaBaoSuaMoi();
            bs.MaSV = maSV;
            bs.MaPhong = maPhong;
            bs.MaGiuong = maGiuong;
            bs.LoaiSuCo = cboLoaiSuCo.Text;
            bs.MoTa = txtMoTa.Text.Trim();
            bs.NgayBao = DateTime.Now;
            bs.TrangThai = "Chờ xử lý";

            if (bus.ThemBaoSua(bs))
            {
                MessageBox.Show("Gửi báo sửa chữa thành công!");

                LoadDanhSachBaoSua();
                LamMoi();
            }
            else
            {
                MessageBox.Show("Gửi báo sửa chữa thất bại!");
            }
        }

        private void LamMoi()
        {
            if (cboLoaiSuCo.Items.Count > 0)
            {
                cboLoaiSuCo.SelectedIndex = 0;
            }

            txtMoTa.Clear();
            dtpNgayBao.Value = DateTime.Now;
            cboTrangThai.SelectedIndex = 0;

            LoadThongTinChoO();
            LoadDanhSachBaoSua();

            cboLoaiSuCo.Focus();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
