using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using BUS_QLKTX;
using GUI_QLKTX.NghiepVu;
namespace GUI_QLKTX
{
    public partial class frmNhanVien : Form
    {
        BUS_BaoCaoThongKe busThongKe = new BUS_BaoCaoThongKe();
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void LoadTongQuan()
        {
            lblTongSinhVien.Text = busThongKe.TongSinhVien().ToString();
            lblTongPhong.Text = busThongKe.TongPhong().ToString();
            lblGiuongTrong.Text = busThongKe.TongGiuongTrong().ToString();
            lblChoDuyet.Text = busThongKe.TongDangKyChoDuyet().ToString();
            lblHoaDonChuaThanhToan.Text =busThongKe.TongHoaDonChuaThanhToan().ToString();
            lblBaoSuaChoXuLy.Text = busThongKe.TongBaoSuaChoXuLy().ToString();
            lblTongViPham.Text = busThongKe.TongViPham().ToString();
        }
        private void LoadThongBao()
        {
            dgvThongBao.DataSource = busThongKe.LayThongBaoMoiNhat();
            dgvThongBao.ClearSelection();
        }
        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            frmQuanLySinhVien f = new frmQuanLySinhVien();
            f.ShowDialog();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            lbngay.Text = DateTime.Now.ToString("dd/MM/yyyy");

            LoadTongQuan();
            LoadThongBao();
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            frmQuanLyPhong f = new frmQuanLyPhong("NhanVien");
            f.ShowDialog();
        }

        private void btnGiuong_Click(object sender, EventArgs e)
        {
            frmQuanLyGiuong f = new frmQuanLyGiuong("NhanVien");
            f.ShowDialog();
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

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            frmBaoCaoThongKe f = new frmBaoCaoThongKe();
            f.ShowDialog();

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBaoSuaChua_Click(object sender, EventArgs e)
        {
            frmQuanLyBaoSuaChua f = new frmQuanLyBaoSuaChua("NhanVien");
            f.ShowDialog();
            LoadTongQuan();
        }

        private void btnViPham_Click(object sender, EventArgs e)
        {
            frmQuanLyViPham f = new frmQuanLyViPham("NhanVien");
            f.ShowDialog();
            LoadTongQuan();
        }
    }
}
