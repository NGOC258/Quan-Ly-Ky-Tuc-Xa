using System;
using System.Data;
using System.Windows.Forms;
using BUS_QLKTX;

namespace GUI_QLKTX
{
    public partial class frmThongTinCaNhanSinhVien : Form
    {
        private string maSV;

        BUS_ThongTinCaNhanSinhVien bus = new BUS_ThongTinCaNhanSinhVien();

        public frmThongTinCaNhanSinhVien(string maSV)
        {
            InitializeComponent();
            this.maSV = maSV;
        }

        private void frmThongTinCaNhanSinhVien_Load(object sender, EventArgs e)
        {
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";

            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");

            txtMaSV.ReadOnly = true;
            txtHoTen.ReadOnly = true;
            dtpNgaySinh.Enabled = false;
            cboGioiTinh.Enabled = false;
            txtLop.ReadOnly = true;
            txtKhoa.ReadOnly = true;
            txtEmail.ReadOnly = true;

            txtSDT.ReadOnly = false;
            txtDiaChi.ReadOnly = false;

            LoadThongTin();
        }

        private void LoadThongTin()
        {
            DataTable dt = bus.LayThongTinSinhVien(maSV);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên!");
                return;
            }

            DataRow row = dt.Rows[0];

            txtMaSV.Text = row["MaSV"].ToString();
            txtHoTen.Text = row["HoTen"].ToString();

            if (row["NgaySinh"] != DBNull.Value)
            {
                dtpNgaySinh.Value = Convert.ToDateTime(row["NgaySinh"]);
            }

            cboGioiTinh.Text = row["GioiTinh"].ToString();
            txtLop.Text = row["Lop"].ToString();
            txtKhoa.Text = row["Khoa"].ToString();
            txtSDT.Text = row["SDT"].ToString();
            txtEmail.Text = row["Email"].ToString();
            txtDiaChi.Text = row["DiaChi"].ToString();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            if (sdt == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!");
                txtSDT.Focus();
                return;
            }

            if (diaChi == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!");
                txtDiaChi.Focus();
                return;
            }

            if (bus.CapNhatThongTin(maSV, sdt, diaChi))
            {
                MessageBox.Show("Cập nhật thông tin thành công!");
                LoadThongTin();
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin thất bại!");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadThongTin();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}