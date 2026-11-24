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
using DTO_QLKTX.DTO_QLKTX;
namespace GUI_QLKTX

{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
            txtMatKhau.UseSystemPasswordChar = true;
        }
        BUS_TaiKhoan bus = new BUS_TaiKhoan();
  
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnDangNhap;
            this.CancelButton = btnThoat;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DTO_TaiKhoan tk = bus.DangNhap(
                txtTenDangNhap.Text.Trim(),
                txtMatKhau.Text.Trim());

            if (tk == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                return;
            }

            MessageBox.Show(
                "Đăng nhập thành công!\nVai trò: " + tk.VaiTro);

            if (tk.VaiTro == "Admin")
            {
                frmAdmin f = new frmAdmin();
                f.Show();
                this.Hide();
            }
            else if (tk.VaiTro == "NhanVien")
            {
                this.Hide();

                frmNhanVien f = new frmNhanVien();
                f.ShowDialog();

                this.Show();
            }
            else if (tk.VaiTro == "SinhVien")
            {
                this.Hide();

                frmSinhVien f = new frmSinhVien(tk.MaSV);
                f.ShowDialog();

                this.Show();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();

            txtTenDangNhap.Focus();
        }

        private void picEye_Click(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar =
        !txtMatKhau.UseSystemPasswordChar;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                "Bạn có muốn thoát chương trình không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void picUser_Click(object sender, EventArgs e)
        {

        }

    }
}
