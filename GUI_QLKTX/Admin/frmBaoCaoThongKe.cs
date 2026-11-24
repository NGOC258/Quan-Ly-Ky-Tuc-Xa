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
    public partial class frmBaoCaoThongKe : Form
    {
        BUS_BaoCaoThongKe bus = new BUS_BaoCaoThongKe();
        public frmBaoCaoThongKe()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void LoadTongQuan()
        {
            lblTongSinhVien.Text = bus.TongSinhVien().ToString();
            lblTongPhong.Text = bus.TongPhong().ToString();
            lblGiuongTrong.Text = bus.TongGiuongTrong().ToString();
            lblChoDuyet.Text = bus.TongDangKyChoDuyet().ToString();
            lblHoaDonChuaThanhToan.Text = bus.TongHoaDonChuaThanhToan().ToString();
            lblBaoSuaChoXuLy.Text = bus.TongBaoSuaChoXuLy().ToString();
            lblTongViPham.Text = bus.TongViPham().ToString();
        }
        private void LoadLoaiThongKe()
        {
            cboLoaiThongKe.Items.Clear();
            cboLoaiThongKe.Items.Add("Hóa đơn");
            cboLoaiThongKe.Items.Add("Đăng ký ở");
            cboLoaiThongKe.Items.Add("Vi phạm");
            cboLoaiThongKe.Items.Add("Báo sửa chữa");
            cboLoaiThongKe.Items.Add("Phòng - Giường");
            cboLoaiThongKe.SelectedIndex = 0;
        }
        private void LoadThang()
        {
            cboThang.Items.Clear();

            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add(i);
            }

            cboThang.SelectedItem = DateTime.Now.Month;
        }
        private void frmBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            LoadTongQuan();
            LoadLoaiThongKe();
            LoadThang();

            txtNam.Text = DateTime.Now.Year.ToString();

            lblKetQuaTong.Text = "Tổng doanh thu:";
            lblTongDoanhThu.Text = "0 đ";

            dgvThongKe.DataSource = null; ;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (cboLoaiThongKe.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại thống kê!");
                return;
            }

            string loai = cboLoaiThongKe.Text;

            if (loai == "Phòng - Giường")
            {
                ThongKePhongGiuong();
                return;
            }

            int thang;
            int nam;

            if (!int.TryParse(cboThang.Text, out thang))
            {
                MessageBox.Show("Vui lòng chọn tháng!");
                return;
            }

            if (!int.TryParse(txtNam.Text.Trim(), out nam))
            {
                MessageBox.Show("Năm không hợp lệ!");
                txtNam.Focus();
                return;
            }

            if (loai == "Hóa đơn")
            {
                ThongKeHoaDon(thang, nam);
            }
            else if (loai == "Đăng ký ở")
            {
                ThongKeDangKyO(thang, nam);
            }
            else if (loai == "Vi phạm")
            {
                ThongKeViPham(thang, nam);
            }
            else if (loai == "Báo sửa chữa")
            {
                ThongKeBaoSuaChua(thang, nam);
            }
        }
        private void ThongKeHoaDon(int thang, int nam)
        {
            DataTable dt = bus.ThongKeHoaDon(thang, nam);
            dgvThongKe.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                decimal tongDoanhThu = Convert.ToDecimal(dt.Rows[0]["TongTien"]);
                lblTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " đ";
            }
            else
            {
                lblTongDoanhThu.Text = "0 đ";
                MessageBox.Show("Không có hóa đơn trong tháng " + thang + "/" + nam + "!");
            }
        }

        private void ThongKeDangKyO(int thang, int nam)
        {
            DataTable dt = bus.ThongKeDangKyO(thang, nam);
            dgvThongKe.DataSource = dt;
            lblTongDoanhThu.Text = dt.Rows.Count.ToString();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có đăng ký ở trong tháng " + thang + "/" + nam + "!");
            }
        }

        private void ThongKeViPham(int thang, int nam)
        {
            DataTable dt = bus.ThongKeViPham(thang, nam);
            dgvThongKe.DataSource = dt;
            lblTongDoanhThu.Text = dt.Rows.Count.ToString();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có vi phạm trong tháng " + thang + "/" + nam + "!");
            }
        }

        private void ThongKeBaoSuaChua(int thang, int nam)
        {
            DataTable dt = bus.ThongKeBaoSuaChua(thang, nam);
            dgvThongKe.DataSource = dt;
            lblTongDoanhThu.Text = dt.Rows.Count.ToString();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có yêu cầu sửa chữa trong tháng " + thang + "/" + nam + "!");
            }
        }

        private void ThongKePhongGiuong()
        {
            DataTable dt = bus.ThongKePhongGiuong();
            dgvThongKe.DataSource = dt;

            int tongGiuong = 0;

            foreach (DataRow row in dt.Rows)
            {
                tongGiuong += Convert.ToInt32(row["TongGiuong"]);
            }

            lblTongDoanhThu.Text = tongGiuong.ToString();
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadTongQuan();

            cboLoaiThongKe.SelectedIndex = 0;
            cboThang.SelectedItem = DateTime.Now.Month;
            txtNam.Text = DateTime.Now.Year.ToString();

            dgvThongKe.DataSource = null;

            lblKetQuaTong.Text = "Tổng doanh thu:";
            lblTongDoanhThu.Text = "0 đ";

            cboThang.Enabled = true;
            txtNam.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
               "Bạn có muốn thoát khỏi báo cáo thống kê không?",
               "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void grbDanhSach_Enter(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboLoaiThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvThongKe.DataSource = null;

            string loai = cboLoaiThongKe.Text;

            if (loai == "Phòng - Giường")
            {
                cboThang.Enabled = false;
                txtNam.Enabled = false;

                lblKetQuaTong.Text = "Tổng số giường:";
                lblTongDoanhThu.Text = "0";
            }
            else
            {
                cboThang.Enabled = true;
                txtNam.Enabled = true;

                if (loai == "Hóa đơn")
                {
                    lblKetQuaTong.Text = "Tổng doanh thu:";
                    lblTongDoanhThu.Text = "0 đ";
                }
                else if (loai == "Đăng ký ở")
                {
                    lblKetQuaTong.Text = "Tổng đăng ký:";
                    lblTongDoanhThu.Text = "0";
                }
                else if (loai == "Vi phạm")
                {
                    lblKetQuaTong.Text = "Tổng lượt vi phạm:";
                    lblTongDoanhThu.Text = "0";
                }
                else if (loai == "Báo sửa chữa")
                {
                    lblKetQuaTong.Text = "Tổng yêu cầu sửa chữa:";
                    lblTongDoanhThu.Text = "0";
                }
            }
        }
    }
}
