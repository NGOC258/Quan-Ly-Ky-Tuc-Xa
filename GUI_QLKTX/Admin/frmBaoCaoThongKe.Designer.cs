namespace GUI_QLKTX
{
    partial class frmBaoCaoThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.GroupBox grbDanhSach;
            this.txtNam = new System.Windows.Forms.Label();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.lblKetQuaTong = new System.Windows.Forms.Label();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlSinhVien = new System.Windows.Forms.Panel();
            this.lblTongSinhVien = new System.Windows.Forms.Label();
            this.lblTieuDeSinhVien = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTongPhong = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblGiuongTrong = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblChoDuyet = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblHoaDonChuaThanhToan = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblTongViPham = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblBaoSuaChoXuLy = new System.Windows.Forms.Label();
            this.lblTieuDeBaoSua = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboLoaiThongKe = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            grbDanhSach = new System.Windows.Forms.GroupBox();
            grbDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.pnlSinhVien.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDanhSach
            // 
            grbDanhSach.BackColor = System.Drawing.Color.Linen;
            grbDanhSach.Controls.Add(this.txtNam);
            grbDanhSach.Controls.Add(this.cboThang);
            grbDanhSach.Controls.Add(this.lblTongDoanhThu);
            grbDanhSach.Controls.Add(this.lblKetQuaTong);
            grbDanhSach.Controls.Add(this.btnThongKe);
            grbDanhSach.Controls.Add(this.label4);
            grbDanhSach.Controls.Add(this.label5);
            grbDanhSach.Controls.Add(this.dgvThongKe);
            grbDanhSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            grbDanhSach.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            grbDanhSach.Location = new System.Drawing.Point(18, 529);
            grbDanhSach.Name = "grbDanhSach";
            grbDanhSach.Size = new System.Drawing.Size(1268, 410);
            grbDanhSach.TabIndex = 35;
            grbDanhSach.TabStop = false;
            grbDanhSach.Text = "Kết quả thống kê ";
            grbDanhSach.Enter += new System.EventHandler(this.grbDanhSach_Enter);
            // 
            // txtNam
            // 
            this.txtNam.AutoSize = true;
            this.txtNam.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNam.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtNam.Location = new System.Drawing.Point(576, 65);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(61, 30);
            this.txtNam.TabIndex = 13;
            this.txtNam.Text = "2026";
            this.txtNam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboThang
            // 
            this.cboThang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThang.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThang.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboThang.Location = new System.Drawing.Point(261, 59);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(104, 38);
            this.cboThang.TabIndex = 12;
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.Red;
            this.lblTongDoanhThu.Location = new System.Drawing.Point(700, 352);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(210, 50);
            this.lblTongDoanhThu.TabIndex = 11;
            this.lblTongDoanhThu.Text = "2.500.000 đ";
            this.lblTongDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKetQuaTong
            // 
            this.lblKetQuaTong.AutoSize = true;
            this.lblKetQuaTong.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKetQuaTong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblKetQuaTong.Location = new System.Drawing.Point(364, 354);
            this.lblKetQuaTong.Name = "lblKetQuaTong";
            this.lblKetQuaTong.Size = new System.Drawing.Size(280, 47);
            this.lblKetQuaTong.TabIndex = 10;
            this.lblKetQuaTong.Text = "Tổng doanh thu:";
            this.lblKetQuaTong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.Transparent;
            this.btnThongKe.FlatAppearance.BorderSize = 0;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnThongKe.Location = new System.Drawing.Point(698, 54);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(295, 51);
            this.btnThongKe.TabIndex = 9;
            this.btnThongKe.Text = "🔍 Thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(491, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 30);
            this.label4.TabIndex = 8;
            this.label4.Text = "Năm: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(177, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 30);
            this.label5.TabIndex = 7;
            this.label5.Text = "Tháng: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Location = new System.Drawing.Point(6, 118);
            this.dgvThongKe.MultiSelect = false;
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.RowTemplate.Height = 24;
            this.dgvThongKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongKe.Size = new System.Drawing.Size(1262, 213);
            this.dgvThongKe.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(512, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 38);
            this.label1.TabIndex = 28;
            this.label1.Text = "BÁO CÁO - THỐNG KÊ ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 29;
            // 
            // pnlSinhVien
            // 
            this.pnlSinhVien.BackColor = System.Drawing.Color.LightGray;
            this.pnlSinhVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSinhVien.Controls.Add(this.lblTongSinhVien);
            this.pnlSinhVien.Controls.Add(this.lblTieuDeSinhVien);
            this.pnlSinhVien.Location = new System.Drawing.Point(126, 56);
            this.pnlSinhVien.Name = "pnlSinhVien";
            this.pnlSinhVien.Size = new System.Drawing.Size(165, 111);
            this.pnlSinhVien.TabIndex = 30;
            // 
            // lblTongSinhVien
            // 
            this.lblTongSinhVien.AutoSize = true;
            this.lblTongSinhVien.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongSinhVien.Location = new System.Drawing.Point(65, 64);
            this.lblTongSinhVien.Name = "lblTongSinhVien";
            this.lblTongSinhVien.Size = new System.Drawing.Size(27, 31);
            this.lblTongSinhVien.TabIndex = 1;
            this.lblTongSinhVien.Text = "0";
            this.lblTongSinhVien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTieuDeSinhVien
            // 
            this.lblTieuDeSinhVien.AutoSize = true;
            this.lblTieuDeSinhVien.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeSinhVien.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTieuDeSinhVien.Location = new System.Drawing.Point(15, 21);
            this.lblTieuDeSinhVien.Name = "lblTieuDeSinhVien";
            this.lblTieuDeSinhVien.Size = new System.Drawing.Size(128, 31);
            this.lblTieuDeSinhVien.TabIndex = 0;
            this.lblTieuDeSinhVien.Text = "SINH VIÊN";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTongPhong);
            this.panel1.Controls.Add(this.label);
            this.panel1.Location = new System.Drawing.Point(337, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 111);
            this.panel1.TabIndex = 31;
            // 
            // lblTongPhong
            // 
            this.lblTongPhong.AutoSize = true;
            this.lblTongPhong.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongPhong.Location = new System.Drawing.Point(65, 64);
            this.lblTongPhong.Name = "lblTongPhong";
            this.lblTongPhong.Size = new System.Drawing.Size(27, 31);
            this.lblTongPhong.TabIndex = 1;
            this.lblTongPhong.Text = "0";
            this.lblTongPhong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label.Location = new System.Drawing.Point(28, 21);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(97, 31);
            this.label.TabIndex = 0;
            this.label.Text = "PHÒNG";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblGiuongTrong);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(569, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 111);
            this.panel2.TabIndex = 31;
            // 
            // lblGiuongTrong
            // 
            this.lblGiuongTrong.AutoSize = true;
            this.lblGiuongTrong.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiuongTrong.Location = new System.Drawing.Point(100, 64);
            this.lblGiuongTrong.Name = "lblGiuongTrong";
            this.lblGiuongTrong.Size = new System.Drawing.Size(27, 31);
            this.lblGiuongTrong.TabIndex = 1;
            this.lblGiuongTrong.Text = "0";
            this.lblGiuongTrong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(13, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 31);
            this.label6.TabIndex = 0;
            this.label6.Text = "GIƯỜNG TRỐNG";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblChoDuyet);
            this.panel3.Controls.Add(this.name);
            this.panel3.Location = new System.Drawing.Point(123, 202);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(165, 111);
            this.panel3.TabIndex = 31;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // lblChoDuyet
            // 
            this.lblChoDuyet.AutoSize = true;
            this.lblChoDuyet.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoDuyet.Location = new System.Drawing.Point(65, 64);
            this.lblChoDuyet.Name = "lblChoDuyet";
            this.lblChoDuyet.Size = new System.Drawing.Size(27, 31);
            this.lblChoDuyet.TabIndex = 1;
            this.lblChoDuyet.Text = "0";
            this.lblChoDuyet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.name.Location = new System.Drawing.Point(3, 21);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(149, 31);
            this.name.TabIndex = 0;
            this.name.Text = "CHỜ DUYỆT ";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblHoaDonChuaThanhToan);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Location = new System.Drawing.Point(337, 203);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(411, 111);
            this.panel4.TabIndex = 31;
            // 
            // lblHoaDonChuaThanhToan
            // 
            this.lblHoaDonChuaThanhToan.AutoSize = true;
            this.lblHoaDonChuaThanhToan.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoaDonChuaThanhToan.Location = new System.Drawing.Point(139, 64);
            this.lblHoaDonChuaThanhToan.Name = "lblHoaDonChuaThanhToan";
            this.lblHoaDonChuaThanhToan.Size = new System.Drawing.Size(27, 31);
            this.lblHoaDonChuaThanhToan.TabIndex = 1;
            this.lblHoaDonChuaThanhToan.Text = "0";
            this.lblHoaDonChuaThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(3, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(354, 31);
            this.label10.TabIndex = 0;
            this.label10.Text = "HÓA ĐƠN CHƯA THANH TOÁN";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Transparent;
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnLamMoi.Location = new System.Drawing.Point(898, 443);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(173, 60);
            this.btnLamMoi.TabIndex = 36;
            this.btnLamMoi.Text = "↻ Làm mới ";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Transparent;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Crimson;
            this.btnThoat.Location = new System.Drawing.Point(1097, 443);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(148, 61);
            this.btnThoat.TabIndex = 37;
            this.btnThoat.Text = "Thoát ↪";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel7);
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.pnlSinhVien);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(42, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1209, 350);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "THÔNG TIN TỔNG QUAN ";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.LightGray;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lblTongViPham);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Location = new System.Drawing.Point(868, 203);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(177, 112);
            this.panel7.TabIndex = 39;
            // 
            // lblTongViPham
            // 
            this.lblTongViPham.AutoSize = true;
            this.lblTongViPham.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongViPham.Location = new System.Drawing.Point(76, 56);
            this.lblTongViPham.Name = "lblTongViPham";
            this.lblTongViPham.Size = new System.Drawing.Size(27, 31);
            this.lblTongViPham.TabIndex = 1;
            this.lblTongViPham.Text = "0";
            this.lblTongViPham.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(33, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "VI PHẠM ";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightGray;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.lblBaoSuaChoXuLy);
            this.panel6.Controls.Add(this.lblTieuDeBaoSua);
            this.panel6.Location = new System.Drawing.Point(868, 56);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(309, 112);
            this.panel6.TabIndex = 38;
            // 
            // lblBaoSuaChoXuLy
            // 
            this.lblBaoSuaChoXuLy.AutoSize = true;
            this.lblBaoSuaChoXuLy.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaoSuaChoXuLy.Location = new System.Drawing.Point(137, 51);
            this.lblBaoSuaChoXuLy.Name = "lblBaoSuaChoXuLy";
            this.lblBaoSuaChoXuLy.Size = new System.Drawing.Size(27, 31);
            this.lblBaoSuaChoXuLy.TabIndex = 1;
            this.lblBaoSuaChoXuLy.Text = "0";
            this.lblBaoSuaChoXuLy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTieuDeBaoSua
            // 
            this.lblTieuDeBaoSua.AutoSize = true;
            this.lblTieuDeBaoSua.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeBaoSua.ForeColor = System.Drawing.Color.Teal;
            this.lblTieuDeBaoSua.Location = new System.Drawing.Point(14, 12);
            this.lblTieuDeBaoSua.Name = "lblTieuDeBaoSua";
            this.lblTieuDeBaoSua.Size = new System.Drawing.Size(259, 31);
            this.lblTieuDeBaoSua.TabIndex = 0;
            this.lblTieuDeBaoSua.Text = "CHỜ XỬ LÝ SỬA CHỮA";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(38, 216);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 25);
            this.label13.TabIndex = 6;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLoaiThongKe
            // 
            this.cboLoaiThongKe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiThongKe.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiThongKe.FormattingEnabled = true;
            this.cboLoaiThongKe.Location = new System.Drawing.Point(297, 456);
            this.cboLoaiThongKe.Name = "cboLoaiThongKe";
            this.cboLoaiThongKe.Size = new System.Drawing.Size(517, 33);
            this.cboLoaiThongKe.TabIndex = 10;
            this.cboLoaiThongKe.SelectedIndexChanged += new System.EventHandler(this.cboLoaiThongKe_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(132, 464);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = " Loại thống kê:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBaoCaoThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 1055);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.cboLoaiThongKe);
            this.Controls.Add(grbDanhSach);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Name = "frmBaoCaoThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý ký túc xá- Báo cáo thống kê ";
            this.Load += new System.EventHandler(this.frmBaoCaoThongKe_Load);
            grbDanhSach.ResumeLayout(false);
            grbDanhSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.pnlSinhVien.ResumeLayout(false);
            this.pnlSinhVien.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlSinhVien;
        private System.Windows.Forms.Label lblTongSinhVien;
        private System.Windows.Forms.Label lblTieuDeSinhVien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTongPhong;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblGiuongTrong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblChoDuyet;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblHoaDonChuaThanhToan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Label lblKetQuaTong;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.Label txtNam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboLoaiThongKe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblTongViPham;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblBaoSuaChoXuLy;
        private System.Windows.Forms.Label lblTieuDeBaoSua;
    }
}