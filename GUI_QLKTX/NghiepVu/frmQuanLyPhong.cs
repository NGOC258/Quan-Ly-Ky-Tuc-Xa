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
    public partial class frmQuanLyPhong : Form
    {
        BUS_Phong bus = new BUS_Phong();
        private string vaiTro;


        public frmQuanLyPhong(string vaiTro)
        {
            InitializeComponent();
            this.vaiTro = vaiTro;
        }

        private void frmQuanLyPhong_Load(object sender, EventArgs e)
        {
            dgvPhong.DataSource = bus.LayDanhSachPhong();

            cboToaNha.DataSource = bus.LayDanhSachToaNha();
            cboToaNha.DisplayMember = "TenToaNha";
            cboToaNha.ValueMember = "MaToaNha";

            cboLoaiPhong.DataSource = bus.LayDanhSachLoaiPhong();
            cboLoaiPhong.DisplayMember = "TenLoaiPhong";
            cboLoaiPhong.ValueMember = "MaLoaiPhong";

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Trống");
            cboTrangThai.Items.Add("Đã đầy");
            cboTrangThai.Items.Add("Đang sửa");
            cboTrangThai.SelectedIndex = 0;

            bool laAdmin = vaiTro == "Admin";

            btnThem.Visible = laAdmin;
            btnSua.Visible = laAdmin;
            btnXoa.Visible = laAdmin;

            txtMaPhong.ReadOnly = true;

            if (cboToaNha.SelectedValue != null)
            {
                txtMaPhong.Text = bus.TaoMaPhongMoi(cboToaNha.SelectedValue.ToString());
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
          

            // Kiểm tra trùng mã
            if (bus.KiemTraMaPhong(txtMaPhong.Text.Trim()))
            {
                MessageBox.Show("Mã phòng đã tồn tại!");
                txtMaPhong.Focus();
                return;
            }

            // Kiểm tra tên phòng
            if (txtTenPhong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên phòng!");
                txtTenPhong.Focus();
                return;
            }

            // Tạo đối tượng phòng
            DTO_Phong phong = new DTO_Phong();

            phong.MaPhong = txtMaPhong.Text.Trim();
            phong.TenPhong = txtTenPhong.Text.Trim();

            phong.MaToaNha = cboToaNha.SelectedValue.ToString();
            phong.MaLoaiPhong = cboLoaiPhong.SelectedValue.ToString();

            phong.TrangThaiPhong = cboTrangThai.Text;

            // Thêm
            if (bus.ThemPhong(phong))
            {
                MessageBox.Show("Thêm phòng thành công!");

                dgvPhong.DataSource = bus.LayDanhSachPhong();

                txtMaPhong.Clear();
                txtMaPhong.Text = bus.TaoMaPhongMoi(cboToaNha.SelectedValue.ToString());

                cboToaNha.SelectedIndex = 0;
                cboLoaiPhong.SelectedIndex = 0;
                cboTrangThai.SelectedIndex = 0;

                txtTenPhong.Focus();
            }
            else
            {
                MessageBox.Show("Thêm phòng thất bại!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                "Bạn có muốn thoát khỏi quản lý phòng không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhong.Rows[e.RowIndex];

                txtMaPhong.Text = row.Cells["MaPhong"].Value.ToString();
                txtTenPhong.Text = row.Cells["TenPhong"].Value.ToString();

                cboToaNha.SelectedValue =
                    row.Cells["MaToaNha"].Value.ToString();

                cboLoaiPhong.SelectedValue =
                    row.Cells["MaLoaiPhong"].Value.ToString();

                cboTrangThai.Text =
                    row.Cells["TrangThaiPhong"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaPhong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa!");
                return;
            }

            if (txtTenPhong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên phòng!");
                txtTenPhong.Focus();
                return;
            }

            DTO_Phong phong = new DTO_Phong();

            phong.MaPhong = txtMaPhong.Text.Trim();
            phong.TenPhong = txtTenPhong.Text.Trim();
            phong.MaToaNha = cboToaNha.SelectedValue.ToString();
            phong.MaLoaiPhong = cboLoaiPhong.SelectedValue.ToString();
            phong.TrangThaiPhong = cboTrangThai.Text;

            if (bus.SuaPhong(phong))
            {
                MessageBox.Show("Sửa phòng thành công!");

                dgvPhong.DataSource = bus.LayDanhSachPhong();
            }
            else
            {
                MessageBox.Show("Sửa phòng thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaPhong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa!");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn xóa phòng này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                if (bus.XoaPhong(txtMaPhong.Text.Trim()))
                {
                    MessageBox.Show("Xóa phòng thành công!");

                    dgvPhong.DataSource = bus.LayDanhSachPhong();

                    txtMaPhong.Clear();
                    txtTenPhong.Clear();

                    cboToaNha.SelectedIndex = 0;
                    cboLoaiPhong.SelectedIndex = 0;
                    cboTrangThai.SelectedIndex = 0;

                    txtMaPhong.Focus();
                }
                else
                {
                    MessageBox.Show("Xóa phòng thất bại!");
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenPhong.Clear();

            cboToaNha.SelectedIndex = 0;
            cboLoaiPhong.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;

            txtMaPhong.ReadOnly = true;

            if (cboToaNha.SelectedValue != null)
            {
                txtMaPhong.Text = bus.TaoMaPhongMoi(cboToaNha.SelectedValue.ToString());
            }

            txtTenPhong.Focus();

            dgvPhong.DataSource = bus.LayDanhSachPhong();
            dgvPhong.ClearSelection();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ma = txtMaPhong.Text.Trim();
            string ten = txtTenPhong.Text.Trim();

            if (ma == "" && ten == "")
            {
                MessageBox.Show("Vui lòng nhập mã hoặc tên phòng cần tìm!");
                return;
            }

            DataTable dt = bus.TimKiemPhong(ma, ten);

            dgvPhong.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phòng!");
            }
        }

        private void cboToaNha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboToaNha.SelectedValue != null && cboToaNha.SelectedValue is string)
            {
                txtMaPhong.Text = bus.TaoMaPhongMoi(cboToaNha.SelectedValue.ToString());
            }
        }
    }
}
