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
    public partial class frmDoiMatKhau : Form
    {
        BUS_TaiKhoan bus = new BUS_TaiKhoan();
        private string maSV;
        public frmDoiMatKhau(string maSV)
        {
            InitializeComponent();
            this.maSV = maSV;
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string matKhauCu = txtMatKhauCu.Text.Trim();
            string matKhauMoi = txtMatKhauMoi.Text.Trim();
            string xacNhanMatKhau = txtXacNhanMatKhau.Text.Trim();

            if (matKhauCu == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại!");
                txtMatKhauCu.Focus();
                return;
            }

            if (matKhauMoi == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!");
                txtMatKhauMoi.Focus();
                return;
            }

            if (xacNhanMatKhau == "")
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu mới!");
                txtXacNhanMatKhau.Focus();
                return;
            }

            if (!bus.KiemTraMatKhauCu(maSV, matKhauCu))
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng!");
                txtMatKhauCu.Focus();
                return;
            }

            if (matKhauMoi != xacNhanMatKhau)
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp!");
                txtXacNhanMatKhau.Focus();
                return;
            }

            if (matKhauMoi == matKhauCu)
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu hiện tại!");
                txtMatKhauMoi.Focus();
                return;
            }

            if (bus.DoiMatKhauSinhVien(maSV, matKhauMoi))
            {
                MessageBox.Show("Đổi mật khẩu thành công!");

                txtMatKhauCu.Clear();
                txtMatKhauMoi.Clear();
                txtXacNhanMatKhau.Clear();

                txtMatKhauCu.Focus();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}