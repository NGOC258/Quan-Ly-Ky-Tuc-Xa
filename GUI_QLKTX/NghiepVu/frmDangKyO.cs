using System;
using System.Data;
using System.Windows.Forms;
using BUS_QLKTX;
using DTO_QLKTX;

namespace GUI_QLKTX
{
    public partial class frmDangKyO : Form
    {
        BUS_DangKyO bus = new BUS_DangKyO();

        private bool dangLoad = false;

        public frmDangKyO()
        {
            InitializeComponent();
        }

        private void frmDangKyO_Load(object sender, EventArgs e)
        {
            dangLoad = true;

            txtMaDangKy.ReadOnly = true;
            txtMaDangKy.Text = bus.TaoMaDangKyMoi();

            dgvDangKyO.DataSource = bus.LayDanhSachDangKyO();
            dgvDangKyO.ClearSelection();

            cboSinhVien.DataSource = bus.LayDanhSachSinhVien();
            cboSinhVien.DisplayMember = "HoTen";
            cboSinhVien.ValueMember = "MaSV";
            cboSinhVien.SelectedIndex = -1;

            cboToaNha.DataSource = null;
            cboLoaiPhong.DataSource = null;
            cboPhong.DataSource = null;
            cboGiuong.DataSource = null;

            cboTrangThai.SelectedIndex = 0;

            dtpNgayDangKy.Value = DateTime.Now;
            dtpNgayDangKy.Format = DateTimePickerFormat.Custom;
            dtpNgayDangKy.CustomFormat = "dd/MM/yyyy";

            dangLoad = false;
        }
        private void cboSinhVien_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (dangLoad) return;

            cboToaNha.DataSource = null;
            cboLoaiPhong.DataSource = null;
            cboPhong.DataSource = null;
            cboGiuong.DataSource = null;

            if (cboSinhVien.SelectedIndex == -1 || cboSinhVien.SelectedValue == null) return;

            string maSV = cboSinhVien.SelectedValue.ToString();
            string gioiTinh = bus.LayGioiTinhSinhVien(maSV);

            if (gioiTinh == "")
            {
                MessageBox.Show("Không tìm thấy giới tính của sinh viên!");
                return;
            }

            cboToaNha.DataSource = bus.LayToaNhaTheoGioiTinh(gioiTinh);
            cboToaNha.DisplayMember = "TenToaNha";
            cboToaNha.ValueMember = "MaToaNha";
            cboToaNha.SelectedIndex = -1;
        }


        private void cboToaNha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangLoad) return;

            cboLoaiPhong.DataSource = null;
            cboPhong.DataSource = null;
            cboGiuong.DataSource = null;

            if (cboToaNha.SelectedIndex == -1 || cboToaNha.SelectedValue == null) return;

            string maToaNha = cboToaNha.SelectedValue.ToString();

            cboLoaiPhong.DataSource = bus.LayLoaiPhongTheoToa(maToaNha);
            cboLoaiPhong.DisplayMember = "TenLoaiPhong";
            cboLoaiPhong.ValueMember = "MaLoaiPhong";
            cboLoaiPhong.SelectedIndex = -1;
        }

        private void cboLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangLoad) return;

            cboPhong.DataSource = null;
            cboGiuong.DataSource = null;

            if (cboToaNha.SelectedValue == null || cboLoaiPhong.SelectedValue == null) return;

            string maToaNha = cboToaNha.SelectedValue.ToString();
            string maLoaiPhong = cboLoaiPhong.SelectedValue.ToString();

            cboPhong.DataSource = bus.LayPhongTheoToaVaLoai(maToaNha, maLoaiPhong);
            cboPhong.DisplayMember = "TenPhong";
            cboPhong.ValueMember = "MaPhong";
            cboPhong.SelectedIndex = -1;
        }

        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangLoad) return;

            cboGiuong.DataSource = null;

            if (cboPhong.SelectedIndex == -1 || cboPhong.SelectedValue == null) return;

            string maPhong = cboPhong.SelectedValue.ToString();

            cboGiuong.DataSource = bus.LayGiuongTrongTheoPhong(maPhong);
            cboGiuong.DisplayMember = "SoHieuGiuong";
            cboGiuong.ValueMember = "MaGiuong";
            cboGiuong.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (cboSinhVien.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sinh viên!");
                return;
            }

            if (cboTrangThai.Text == "")
            {
                MessageBox.Show("Vui lòng chọn trạng thái!");
                return;
            }

            string maSV = cboSinhVien.SelectedValue.ToString();

            if (bus.SinhVienCoDangKyDangHoatDong(maSV))
            {
                MessageBox.Show("Sinh viên này đang có đăng ký chờ duyệt hoặc đã có chỗ ở, không thể đăng ký thêm!");
                return;
            }

            string maGiuong = null;

            if (cboTrangThai.Text == "Đã duyệt")
            {
                if (cboToaNha.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn tòa nhà!");
                    return;
                }

                string maToaNha = cboToaNha.SelectedValue.ToString();

                if (!bus.KiemTraToaPhuHopGioiTinh(maSV, maToaNha))
                {
                    MessageBox.Show("Không thể phân sinh viên vào tòa nhà không phù hợp với giới tính!");
                    return;
                }

                if (cboLoaiPhong.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn loại phòng!");
                    return;
                }

                if (cboPhong.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn phòng!");
                    return;
                }

                if (cboGiuong.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn giường!");
                    return;
                }

                maGiuong = cboGiuong.SelectedValue.ToString();

                if (bus.KiemTraGiuongDaDuocDuyet(maGiuong))
                {
                    MessageBox.Show("Giường này đã có sinh viên ở!");
                    return;
                }
            
             }

            DTO_DangKyO dk = new DTO_DangKyO();

            dk.MaDangKy = txtMaDangKy.Text.Trim();
            dk.MaSV = maSV;
            dk.MaGiuong = maGiuong;
            dk.NgayDangKy = dtpNgayDangKy.Value;
            dk.TrangThaiDangKy = cboTrangThai.Text;

            if (bus.ThemDangKyO(dk))
            {
                MessageBox.Show("Thêm đăng ký ở thành công!");
                LamMoiForm();
            }
            else
            {
                MessageBox.Show("Thêm đăng ký ở thất bại!");
            }
        }

        private void dgvDangKyO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            dangLoad = true;

            DataGridViewRow row = dgvDangKyO.Rows[e.RowIndex];

            txtMaDangKy.Text = row.Cells["MaDangKy"].Value.ToString();
            cboSinhVien.SelectedValue = row.Cells["MaSV"].Value.ToString();
            object ngayDangKy = row.Cells["NgayDangKy"].Value;

            if (ngayDangKy != null && ngayDangKy != DBNull.Value)
            {
                dtpNgayDangKy.Value = Convert.ToDateTime(ngayDangKy);
            }
            else
            {
                dtpNgayDangKy.Value = DateTime.Now;
            }
            cboTrangThai.Text = row.Cells["TrangThaiDangKy"].Value.ToString();

            object giaTriGiuong = row.Cells["MaGiuong"].Value;

            if (giaTriGiuong == null || giaTriGiuong == DBNull.Value || giaTriGiuong.ToString() == "")
            {
                string maSV = row.Cells["MaSV"].Value.ToString();
                string gioiTinh = bus.LayGioiTinhSinhVien(maSV);

                cboToaNha.DataSource = bus.LayToaNhaTheoGioiTinh(gioiTinh);
                cboToaNha.DisplayMember = "TenToaNha";
                cboToaNha.ValueMember = "MaToaNha";
                cboToaNha.SelectedIndex = -1;

                cboLoaiPhong.DataSource = null;
                cboPhong.DataSource = null;
                cboGiuong.DataSource = null;

                dangLoad = false;
                return;
            }

            string maGiuong = giaTriGiuong.ToString();

            DataTable dt = bus.LayThongTinChoOTheoGiuong(maGiuong);

            if (dt.Rows.Count > 0)
            {
                string maToaNha = dt.Rows[0]["MaToaNha"].ToString();
                string maLoaiPhong = dt.Rows[0]["MaLoaiPhong"].ToString();
                string maPhong = dt.Rows[0]["MaPhong"].ToString();

                string maSV = row.Cells["MaSV"].Value.ToString();
                string gioiTinh = bus.LayGioiTinhSinhVien(maSV);

                cboToaNha.DataSource = bus.LayToaNhaTheoGioiTinh(gioiTinh);
                cboToaNha.DisplayMember = "TenToaNha";
                cboToaNha.ValueMember = "MaToaNha";
                cboToaNha.SelectedValue = maToaNha;

                cboLoaiPhong.DataSource = bus.LayLoaiPhongTheoToa(maToaNha);
                cboLoaiPhong.DisplayMember = "TenLoaiPhong";
                cboLoaiPhong.ValueMember = "MaLoaiPhong";
                cboLoaiPhong.SelectedValue = maLoaiPhong;

                cboPhong.DataSource = bus.LayPhongTheoToaVaLoai(maToaNha, maLoaiPhong);
                cboPhong.DisplayMember = "TenPhong";
                cboPhong.ValueMember = "MaPhong";
                cboPhong.SelectedValue = maPhong;

                cboGiuong.DataSource = bus.LayGiuongKhiSua(maPhong, txtMaDangKy.Text.Trim());
                cboGiuong.DisplayMember = "SoHieuGiuong";
                cboGiuong.ValueMember = "MaGiuong";
                cboGiuong.SelectedValue = maGiuong;
            }

            dangLoad = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaDangKy.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn đăng ký cần sửa!");
                return;
            }

            if (cboSinhVien.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sinh viên!");
                return;
            }

            if (cboTrangThai.Text == "")
            {
                MessageBox.Show("Vui lòng chọn trạng thái!");
                return;
            }

            string maSV = cboSinhVien.SelectedValue.ToString();

            if (cboTrangThai.Text == "Đã duyệt" && bus.SinhVienDaCoChoOKhiSua(maSV, txtMaDangKy.Text.Trim()))
            {
                MessageBox.Show("Sinh viên này đã có chỗ ở được duyệt, không thể duyệt thêm đăng ký khác!");
                return;
            }

            string maGiuong = null;

            if (cboTrangThai.Text == "Đã duyệt")
            {
                if (cboToaNha.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn tòa nhà!");
                    return;
                }

                string maToaNha = cboToaNha.SelectedValue.ToString();

                if (!bus.KiemTraToaPhuHopGioiTinh(maSV, maToaNha))
                {
                    MessageBox.Show("Không thể phân sinh viên vào tòa nhà không phù hợp với giới tính!");
                    return;
                }

                if (cboLoaiPhong.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn loại phòng!");
                    return;
                }

                if (cboPhong.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn phòng!");
                    return;
                }

                if (cboGiuong.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn giường!");
                    return;
                }

                maGiuong = cboGiuong.SelectedValue.ToString();

                if (bus.KiemTraGiuongKhiSua(maGiuong, txtMaDangKy.Text.Trim()))
                {
                    MessageBox.Show("Giường này đã có sinh viên ở!");
                    return;
                }
            }
        

            DTO_DangKyO dk = new DTO_DangKyO();

            dk.MaDangKy = txtMaDangKy.Text.Trim();
            dk.MaSV = maSV;
            dk.MaGiuong = maGiuong;
            dk.NgayDangKy = dtpNgayDangKy.Value;
            dk.TrangThaiDangKy = cboTrangThai.Text;

            if (bus.SuaDangKyO(dk))
            {
                MessageBox.Show("Cập nhật đăng ký ở thành công!");
                LamMoiForm();
            }
            else
            {
                MessageBox.Show("Cập nhật đăng ký ở thất bại!");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDangKy.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn đăng ký cần xóa!");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn xóa đăng ký ở này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                if (bus.XoaDangKyO(txtMaDangKy.Text.Trim()))
                {
                    MessageBox.Show("Xóa đăng ký ở thành công!");
                    LamMoiForm();
                }
                else
                {
                    MessageBox.Show("Xóa đăng ký ở thất bại!");
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void LamMoiForm()
        {
            dangLoad = true;

            txtMaDangKy.Text = bus.TaoMaDangKyMoi();

            cboSinhVien.SelectedIndex = -1;
            cboToaNha.DataSource = null;

            cboLoaiPhong.DataSource = null;
            cboPhong.DataSource = null;
            cboGiuong.DataSource = null;

            cboTrangThai.SelectedIndex = 0;

            dtpNgayDangKy.Value = DateTime.Now;

            dgvDangKyO.DataSource = bus.LayDanhSachDangKyO();
            dgvDangKyO.ClearSelection();

            dangLoad = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maDangKy = txtMaDangKy.Text.Trim();
            string maSV = "";

            if (cboSinhVien.SelectedIndex != -1 && cboSinhVien.SelectedValue != null)
            {
                maSV = cboSinhVien.SelectedValue.ToString();
            }

            if (maDangKy == "" && maSV == "")
            {
                MessageBox.Show("Vui lòng nhập mã đăng ký hoặc chọn sinh viên cần tìm!");
                return;
            }

            DataTable dt = bus.TimKiemDangKyO(maDangKy, maSV);

            dgvDangKyO.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy đăng ký ở!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                "Bạn có muốn thoát khỏi quản lý đăng ký ở không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

       
    }
}