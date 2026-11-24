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
using GUI_QLKTX;


namespace GUI_QLKTX
{
    public partial class frmSinhVien : Form
    {
        private string maSV;
        BUS_SinhVienTrangChu bus = new BUS_SinhVienTrangChu();
        public frmSinhVien(string maSV)
        {
            InitializeComponent();
            this.maSV = maSV;
        }

        private void lblGiuongTrong_Click(object sender, EventArgs e)
        {

        }
        private void LoadThongTinSinhVien()
        {
            lblXinChao.Text = "Xin chào, " + bus.LayTenSinhVien(maSV) + "! 👋";

            DataTable dt = bus.LayThongTinNoiTru(maSV);

            if (dt.Rows.Count > 0)
            {
                lblPhongHienTai.Text = dt.Rows[0]["TenPhong"].ToString();
                lblGiuongHienTai.Text = dt.Rows[0]["SoHieuGiuong"].ToString();
            }
            else
            {
                lblPhongHienTai.Text = "Chưa có";
                lblGiuongHienTai.Text = "Chưa có";
            }

            lblTrangThaiDangKy.Text = bus.LayTrangThaiDangKyMoiNhat(maSV);
            lblHoaDonChuaThanhToan.Text = bus.DemHoaDonChuaThanhToan(maSV).ToString();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            LoadThongTinSinhVien();
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

        private void btnDangKyO_Click(object sender, EventArgs e)
        {
            frmDangKyOSinhVien f =
                new frmDangKyOSinhVien(maSV);

            f.ShowDialog();

            LoadThongTinSinhVien();
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            frmHopDongSinhVien f =
                new frmHopDongSinhVien(maSV);

            f.ShowDialog();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDonSinhVien f =new frmHoaDonSinhVien(maSV);

            f.ShowDialog();

            LoadThongTinSinhVien();
        }

        private void btnThongTinCaNhan_Click( object sender, EventArgs e)
        {
            frmThongTinCaNhanSinhVien f= new frmThongTinCaNhanSinhVien(maSV);

            f.ShowDialog();
        }

        private void btnBaoSuaChua_Click(object sender, EventArgs e)
        {
            frmBaoSuaChuaSinhVien f = new frmBaoSuaChuaSinhVien(maSV);
            f.ShowDialog();
        }

        private void btnTroLyKTX_Click(object sender, EventArgs e)
        {
            frmTroLyKTX f = new frmTroLyKTX(maSV);
            f.ShowDialog();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau(maSV);
            frm.ShowDialog();
        }
    }
}
