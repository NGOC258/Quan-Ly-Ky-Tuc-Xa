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
using GUI_QLKTX.NghiepVu;

namespace GUI_QLKTX
{
    public partial class frmAdmin : Form
    {
        BUS_BaoCaoThongKe busThongKe = new BUS_BaoCaoThongKe();
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                "Bạn có muốn đăng xuất không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                frmDangNhap f = new frmDangNhap();
                f.Show();
                this.Close();
            }
        }

        private void btnToaNha_Click(object sender, EventArgs e)
        {
            frmQuanLyToaNha f = new frmQuanLyToaNha();
            f.ShowDialog();
        }

        private void btnLoaiPhong_Click(object sender, EventArgs e)
        {
            frmQuanLyLoaiPhong f = new frmQuanLyLoaiPhong();
            f.ShowDialog();
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            frmQuanLyPhong f = new frmQuanLyPhong("Admin");
            f.ShowDialog();
        }

        private void btnGiuong_Click(object sender, EventArgs e)
        {
            frmQuanLyGiuong f = new frmQuanLyGiuong("Admin");
            f.ShowDialog();
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            frmQuanLySinhVien f = new frmQuanLySinhVien();
            f.ShowDialog();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            frmQuanLyNhanVien f = new frmQuanLyNhanVien();
            f.ShowDialog();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            frmQuanLyTaiKhoan f = new frmQuanLyTaiKhoan();
            f.ShowDialog();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
         
        }

        private void btnDangKyO_Click(object sender, EventArgs e)
        {
            frmDangKyO f = new frmDangKyO();
            f.ShowDialog();
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            frmHopDong f = new frmHopDong();    
            f.ShowDialog();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDon f = new frmHoaDon();
            f.ShowDialog();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            frmBaoCaoThongKe f  = new frmBaoCaoThongKe();   
            f.ShowDialog();
        }

        private void lblNgay_Click(object sender, EventArgs e)
        {
            lblNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void LoadTongQuan()
        {
            lblTongSinhVien.Text = busThongKe.TongSinhVien().ToString();
            lblTongPhong.Text = busThongKe.TongPhong().ToString();
            lblGiuongTrong.Text = busThongKe.TongGiuongTrong().ToString();
            lblChoDuyet.Text = busThongKe.TongDangKyChoDuyet().ToString();
            lblHoaDonChuaThanhToan.Text = busThongKe.TongHoaDonChuaThanhToan().ToString();
            lblBaoSuaChoXuLy.Text = busThongKe.TongBaoSuaChoXuLy().ToString();
            lblTongViPham.Text = busThongKe.TongViPham().ToString();
        }
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            lblNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");

            LoadTongQuan();
            LoadThongBao();
        }
        private void LoadThongBao()
        {
            dgvThongBao.DataSource = busThongKe.LayThongBaoMoiNhat();

            dgvThongBao.ClearSelection();
        }

        private void btnViPham_Click(object sender, EventArgs e)
        {
            frmQuanLyViPham f = new frmQuanLyViPham("Admin");
            f.ShowDialog();
            LoadTongQuan();
        }

        private void btnBaoSuaChua_Click(object sender, EventArgs e)
        {
            frmQuanLyBaoSuaChua f = new frmQuanLyBaoSuaChua("Admin");
            f.ShowDialog();
            LoadTongQuan();
        }
    }
}
