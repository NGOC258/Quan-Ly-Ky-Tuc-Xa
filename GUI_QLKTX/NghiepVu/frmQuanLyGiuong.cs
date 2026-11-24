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
    public partial class frmQuanLyGiuong : Form
    {
        BUS_Giuong bus = new BUS_Giuong();
        private string vaiTro;
        //public frmQuanLyGiuong()
        //{
        //    InitializeComponent();
        //}
        public frmQuanLyGiuong(string vaiTro)
        {
            InitializeComponent();
            this.vaiTro = vaiTro;
        }

        private void frmQuanLyGiuong_Load(object sender, EventArgs e)
        {
            dgvGiuong.DataSource = bus.LayDanhSachGiuong();

            cboPhong.DataSource = bus.LayDanhSachPhong();
            cboPhong.DisplayMember = "TenPhong";
            cboPhong.ValueMember = "MaPhong";

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Trống");
            cboTrangThai.Items.Add("Đã có người");

            cboTrangThai.SelectedIndex = 0;
            bool laAdmin = vaiTro == "Admin";

            btnThem.Visible = laAdmin;
            btnSua.Visible = laAdmin;
            btnXoa.Visible = laAdmin;

            txtMaGiuong.ReadOnly = true;
            txtMaGiuong.Text = bus.TaoMaGiuongMoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
          

            if (txtSoHieuGiuong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số hiệu giường!");
                txtSoHieuGiuong.Focus();
                return;
            }

            DTO_Giuong giuong = new DTO_Giuong();

            giuong.MaGiuong = txtMaGiuong.Text.Trim();
            giuong.MaPhong = cboPhong.SelectedValue.ToString();
            giuong.SoHieuGiuong = txtSoHieuGiuong.Text.Trim();
            giuong.TrangThaiGiuong = cboTrangThai.Text;

            if (bus.ThemGiuong(giuong))
            {
                MessageBox.Show("Thêm giường thành công!");

                dgvGiuong.DataSource = bus.LayDanhSachGiuong();

                txtMaGiuong.Text = bus.TaoMaGiuongMoi();
                txtSoHieuGiuong.Clear();

                cboPhong.SelectedIndex = 0;
                cboTrangThai.SelectedIndex = 0;

                txtSoHieuGiuong.Focus();
            }
            else
            {
                MessageBox.Show("Thêm giường thất bại!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                "Bạn có muốn thoát khỏi quản lý giường không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvGiuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvGiuong.Rows[e.RowIndex];

                txtMaGiuong.Text =
                    row.Cells["MaGiuong"].Value.ToString();

                cboPhong.SelectedValue =
                    row.Cells["MaPhong"].Value.ToString();

                txtSoHieuGiuong.Text =
                    row.Cells["SoHieuGiuong"].Value.ToString();

                cboTrangThai.Text =
                    row.Cells["TrangThaiGiuong"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaGiuong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn giường cần sửa!");
                return;
            }

            if (txtSoHieuGiuong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số hiệu giường!");
                txtSoHieuGiuong.Focus();
                return;
            }

            DTO_Giuong giuong = new DTO_Giuong();

            giuong.MaGiuong = txtMaGiuong.Text.Trim();
            giuong.MaPhong = cboPhong.SelectedValue.ToString();
            giuong.SoHieuGiuong = txtSoHieuGiuong.Text.Trim();
            giuong.TrangThaiGiuong = cboTrangThai.Text;

            if (bus.SuaGiuong(giuong))
            {
                MessageBox.Show("Sửa giường thành công!");

                dgvGiuong.DataSource = bus.LayDanhSachGiuong();
            }
            else
            {
                MessageBox.Show("Sửa giường thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaGiuong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn giường cần xóa!");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn xóa giường này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                if (bus.XoaGiuong(txtMaGiuong.Text.Trim()))
                {
                    MessageBox.Show("Xóa giường thành công!");

                    dgvGiuong.DataSource = bus.LayDanhSachGiuong();

                    txtMaGiuong.Text = bus.TaoMaGiuongMoi();
                    txtSoHieuGiuong.Clear();

                    cboPhong.SelectedIndex = 0;
                    cboTrangThai.SelectedIndex = 0;

                    txtMaGiuong.Focus();
                }
                else
                {
                    MessageBox.Show("Xóa giường thất bại!");
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaGiuong.Text = bus.TaoMaGiuongMoi();
            txtSoHieuGiuong.Clear();

            cboPhong.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;

            txtMaGiuong.ReadOnly = true;
            txtSoHieuGiuong.Focus();

            dgvGiuong.DataSource = bus.LayDanhSachGiuong();
            dgvGiuong.ClearSelection();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ma = txtMaGiuong.Text.Trim();
            string soHieu = txtSoHieuGiuong.Text.Trim();

            if (ma == "" && soHieu == "")
            {
                MessageBox.Show("Vui lòng nhập mã giường hoặc số hiệu giường cần tìm!");
                return;
            }

            DataTable dt = bus.TimKiemGiuong(ma, soHieu);

            dgvGiuong.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy giường!");
            }
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
