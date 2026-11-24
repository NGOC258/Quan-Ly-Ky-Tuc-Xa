IF DB_ID(N'QLKTX') IS NULL
BEGIN
    CREATE DATABASE QLKTX;
END
GO

USE QLKTX;
GO

SET NOCOUNT ON;
GO

/*==========================================================================
    PHẦN I - TẠO CẤU TRÚC CƠ SỞ DỮ LIỆU 
==========================================================================*/

IF OBJECT_ID(N'dbo.ToaNha', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ToaNha(
        MaToaNha varchar(10) NOT NULL PRIMARY KEY,
        TenToaNha nvarchar(50) NOT NULL,
        SoTang int NOT NULL,
        DiaChi nvarchar(50) NULL,
        MoTa nvarchar(50) NULL
    );
END
GO
ALTER TABLE dbo.ToaNha
ADD GioiTinhKhu nvarchar(10) NULL;
GO
SELECT * FROM dbo.ToaNha;

UPDATE dbo.ToaNha
SET GioiTinhKhu = N'Nam'
WHERE MaToaNha = 'TN01';

UPDATE dbo.ToaNha
SET GioiTinhKhu = N'Nữ'
WHERE MaToaNha = 'TN02';
GO

SELECT MaToaNha, TenToaNha, SoTang, GioiTinhKhu
FROM dbo.ToaNha;

SELECT MaToaNha, TenToaNha, GioiTinhKhu
FROM dbo.ToaNha
WHERE GioiTinhKhu IS NULL
   OR LTRIM(RTRIM(GioiTinhKhu)) = N'';

IF OBJECT_ID(N'dbo.LoaiPhong', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.LoaiPhong(
        MaLoaiPhong varchar(10) NOT NULL PRIMARY KEY,
        TenLoaiPhong nvarchar(50) NOT NULL,
        SoNguoiToiDa int NOT NULL,
        DonGia decimal(18,2) NOT NULL
    );
END
GO

IF OBJECT_ID(N'dbo.Phong', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Phong(
        MaPhong varchar(10) NOT NULL PRIMARY KEY,
        MaToaNha varchar(10) NOT NULL,
        MaLoaiPhong varchar(10) NOT NULL,
        TenPhong nvarchar(50) NOT NULL,
        TrangThaiPhong nvarchar(20) NOT NULL,
        CONSTRAINT FK_Phong_ToaNha FOREIGN KEY(MaToaNha) REFERENCES dbo.ToaNha(MaToaNha),
        CONSTRAINT FK_Phong_LoaiPhong FOREIGN KEY(MaLoaiPhong) REFERENCES dbo.LoaiPhong(MaLoaiPhong),
        CONSTRAINT CK_Phong_TrangThai CHECK (TrangThaiPhong IN (N'Trống',N'Đã đầy',N'Đang sửa'))
    );
END
GO

IF OBJECT_ID(N'dbo.Giuong', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Giuong(
        MaGiuong varchar(10) NOT NULL PRIMARY KEY,
        MaPhong varchar(10) NOT NULL,
        SoHieuGiuong nvarchar(20) NOT NULL,
        TrangThaiGiuong nvarchar(20) NOT NULL,
        CONSTRAINT FK_Giuong_Phong FOREIGN KEY(MaPhong) REFERENCES dbo.Phong(MaPhong),
        CONSTRAINT CK_Giuong_TrangThai CHECK (TrangThaiGiuong IN (N'Trống',N'Đã có người'))
    );
END
GO

IF OBJECT_ID(N'dbo.SinhVien', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.SinhVien(
        MaSV varchar(10) NOT NULL PRIMARY KEY,
        HoTen nvarchar(100) NOT NULL,
        NgaySinh date NOT NULL,
        GioiTinh nvarchar(10) NOT NULL,
        Lop varchar(20) NOT NULL,
        Khoa nvarchar(50) NOT NULL,
        SDT varchar(15) NULL,
        Email varchar(100) NULL,
        DiaChi nvarchar(200) NULL,
        DoiTuongUuTien nvarchar(100) NULL
    );
END
GO

IF OBJECT_ID(N'dbo.NhanVien', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.NhanVien(
        MaNV varchar(10) NOT NULL PRIMARY KEY,
        HoTen nvarchar(100) NOT NULL,
        ChucVu nvarchar(50) NOT NULL,
        SDT varchar(15) NULL,
        Email varchar(100) NULL
    );
END
GO

IF OBJECT_ID(N'dbo.TaiKhoan', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.TaiKhoan(
        MaTaiKhoan varchar(10) NOT NULL PRIMARY KEY,
        TenDangNhap varchar(50) NOT NULL UNIQUE,
        MatKhau varchar(255) NOT NULL,
        VaiTro nvarchar(20) NOT NULL,
        TrangThai nvarchar(20) NOT NULL,
        MaSV varchar(10) NULL,
        MaNV varchar(10) NULL
    );
END
GO

IF OBJECT_ID(N'dbo.DangKyO', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.DangKyO(
        MaDangKy varchar(10) NOT NULL PRIMARY KEY,
        MaSV varchar(10) NOT NULL,
        MaGiuong varchar(10) NULL,
        NgayDangKy date NOT NULL,
        TrangThaiDangKy nvarchar(20) NOT NULL,
        DoiTuongUuTien nvarchar(100) NULL,
        CONSTRAINT FK_DangKyO_SinhVien FOREIGN KEY(MaSV) REFERENCES dbo.SinhVien(MaSV),
        CONSTRAINT FK_DangKyO_Giuong FOREIGN KEY(MaGiuong) REFERENCES dbo.Giuong(MaGiuong),
        CONSTRAINT CK_DangKyO_TrangThai CHECK (TrangThaiDangKy IN (N'Chờ duyệt',N'Đã duyệt',N'Từ chối',N'Đã trả phòng'))
    );
END
GO

IF OBJECT_ID(N'dbo.HopDong', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.HopDong(
        MaHopDong varchar(10) NOT NULL PRIMARY KEY,
        MaDangKy varchar(10) NOT NULL,
        NgayBatDau date NOT NULL,
        NgayKetThuc date NOT NULL,
        TrangThaiHopDong nvarchar(20) NOT NULL,
        CONSTRAINT FK_HopDong_DangKyO FOREIGN KEY(MaDangKy) REFERENCES dbo.DangKyO(MaDangKy),
        CONSTRAINT CK_HopDong_TrangThai CHECK (TrangThaiHopDong IN (N'Đang hiệu lực',N'Hết hạn',N'Đã hủy'))
    );
END
GO

IF OBJECT_ID(N'dbo.HoaDon', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.HoaDon(
        MaHoaDon varchar(10) NOT NULL PRIMARY KEY,
        MaHopDong varchar(10) NOT NULL,
        Thang int NOT NULL,
        Nam int NOT NULL,
        TienPhong decimal(18,2) NOT NULL,
        TienDien decimal(18,2) NOT NULL,
        TienNuoc decimal(18,2) NOT NULL,
        PhiDichVu decimal(18,2) NOT NULL,
        TongTien decimal(18,2) NOT NULL,
        NgayLap date NOT NULL,
        TrangThaiThanhToan nvarchar(30) NOT NULL,
        CONSTRAINT FK_HoaDon_HopDong FOREIGN KEY(MaHopDong) REFERENCES dbo.HopDong(MaHopDong),
        CONSTRAINT CK_HoaDon_TrangThai CHECK (TrangThaiThanhToan IN (N'Đã thanh toán',N'Chưa thanh toán'))
    );
END
GO

IF OBJECT_ID(N'dbo.BaoSuaChua', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.BaoSuaChua(
        MaBaoSua varchar(10) NOT NULL PRIMARY KEY,
        MaSV varchar(10) NOT NULL,
        LoaiSuCo nvarchar(100) NOT NULL,
        MoTa nvarchar(500) NOT NULL,
        NgayBao date NOT NULL,
        TrangThai nvarchar(50) NOT NULL,
        MaPhong varchar(10) NOT NULL,
        MaGiuong varchar(10) NULL,
        CONSTRAINT FK_BaoSuaChua_SinhVien FOREIGN KEY(MaSV) REFERENCES dbo.SinhVien(MaSV),
        CONSTRAINT FK_BaoSuaChua_Phong FOREIGN KEY(MaPhong) REFERENCES dbo.Phong(MaPhong),
        CONSTRAINT FK_BaoSuaChua_Giuong FOREIGN KEY(MaGiuong) REFERENCES dbo.Giuong(MaGiuong)
    );
END
GO

IF OBJECT_ID(N'dbo.LoaiViPham', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.LoaiViPham(
        MaLoaiViPham varchar(10) NOT NULL PRIMARY KEY,
        TenViPham nvarchar(300) NOT NULL,
        XuLyLan1 nvarchar(300) NULL,
        XuLyLan2 nvarchar(300) NULL,
        XuLyLan3 nvarchar(300) NULL,
        GhiChu nvarchar(300) NULL
    );
END
GO

IF OBJECT_ID(N'dbo.ViPham', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ViPham(
        MaViPham varchar(10) NOT NULL PRIMARY KEY,
        MaSV varchar(10) NOT NULL,
        MaLoaiViPham varchar(10) NOT NULL,
        NgayViPham date NOT NULL,
        LanViPham int NOT NULL,
        HinhThucXuLy nvarchar(300) NOT NULL,
        GhiChu nvarchar(500) NULL,
        CONSTRAINT FK_ViPham_SinhVien FOREIGN KEY(MaSV) REFERENCES dbo.SinhVien(MaSV),
        CONSTRAINT FK_ViPham_LoaiViPham FOREIGN KEY(MaLoaiViPham) REFERENCES dbo.LoaiViPham(MaLoaiViPham)
    );
END
GO
/*==========================================================================
    PHẦN II - NẠP DỮ LIỆU
/==========================================================================*/
--TÒA NHÀ 
INSERT INTO dbo.ToaNha (MaToaNha, TenToaNha, SoTang, DiaChi, MoTa)
VALUES
('TN01', N'Tòa I', 13, N'12 Nguyễn Văn Bảo, Phường Hạnh Thông, TP.HCM', N'Tòa nhà ký túc xá IUH'),
('TN02', N'Tòa G', 9, N'12 Nguyễn Văn Bảo, Phường Hạnh Thông, TP.HCM', N'Tòa nhà ký túc xá IUH');
GO

SELECT * FROM dbo.ToaNha;

-- LOẠI PHÒNG
INSERT INTO dbo.LoaiPhong (MaLoaiPhong, TenLoaiPhong, SoNguoiToiDa, DonGia)
VALUES
('LP01', N'Phòng 8 người', 8, 900000),
('LP02', N'Phòng 10 người', 10, 800000),
('LP03', N'Phòng 12 người', 12, 700000);
GO

SELECT * FROM dbo.LoaiPhong;

--PHÒNG
INSERT INTO dbo.Phong (MaPhong, MaToaNha, MaLoaiPhong, TenPhong, TrangThaiPhong)
VALUES
('I101', 'TN01', 'LP01', N'Phòng I-101', N'Trống'),
('G201', 'TN02', 'LP02', N'Phòng G-201', N'Trống'),
('I301', 'TN01', 'LP03', N'Phòng I-301', N'Trống');
GO

INSERT INTO dbo.Phong
(MaPhong, MaToaNha, MaLoaiPhong, TenPhong, TrangThaiPhong)
VALUES
('I201', 'TN01', 'LP03', N'Phòng I-201', N'Trống');
GO

DELETE FROM dbo.Phong
WHERE MaPhong = 'I301';
GO
SELECT * FROM dbo.Phong;

SELECT * FROM dbo.Phong;
SELECT * FROM dbo.Giuong;
-- GIƯỜNG
INSERT INTO dbo.Giuong (MaGiuong, MaPhong, SoHieuGiuong, TrangThaiGiuong)
VALUES
('G001', 'I101', N'Giường 1', N'Trống'),
('G002', 'G201', N'Giường 1', N'Trống'),
('G003', 'I301', N'Giường 1', N'Trống');
GO

UPDATE dbo.Giuong
SET MaPhong = 'I201'
WHERE MaPhong = 'I301';
GO

UPDATE g
SET g.TrangThaiGiuong = N'Đã có người'
FROM Giuong g
INNER JOIN DangKyO dk ON g.MaGiuong = dk.MaGiuong
WHERE dk.TrangThaiDangKy = N'Đã duyệt';

SELECT MaGiuong, MaPhong, SoHieuGiuong, TrangThaiGiuong
FROM Giuong;

-- TÀI KHOẢN ADMIN
INSERT INTO dbo.TaiKhoan
(MaTaiKhoan, TenDangNhap, MatKhau, VaiTro, TrangThai, MaSV, MaNV)
VALUES
('TK001', 'admin', 'admin.iuh@0909', N'Admin', N'Hoạt động', NULL, NULL);
GO

SELECT * FROM dbo.TaiKhoan;


-- SINH VIÊN
INSERT INTO dbo.SinhVien
(MaSV, HoTen, NgaySinh, GioiTinh, Lop, Khoa, SDT, Email, DiaChi, DoiTuongUuTien)
VALUES
('23637151', N'Nguyễn Tuấn Anh', '2005-04-08', N'Nam', 'DHTH19ATT', N'Công nghệ thông tin', '0901007919', 'nguyentuananh@iuh.edu.vn', N'TP.HCM', NULL),

('23630261', N'Huỳnh Bùi Thái Bảo', '2005-07-15', N'Nam', 'DHQT19BTT', N'Quản trị kinh doanh', '0931015838', 'huynhbuithaibao@iuh.edu.vn', N'Đồng Nai', NULL),

('23631981', N'Trần Minh Châu', '2005-10-22', N'Nữ', 'DHKQ19CTT', N'Kế toán - Kiểm toán', '0971023757', 'tranminhchau@iuh.edu.vn', N'Bình Dương', NULL);
GO

SELECT * FROM dbo.SinhVien;
-- TÀI KHOẢN SINH VIÊN 
INSERT INTO dbo.TaiKhoan
(MaTaiKhoan, TenDangNhap, MatKhau, VaiTro, TrangThai, MaSV, MaNV)
VALUES
('TKSV01', '23637151', '123', N'SinhVien', N'Hoạt động', '23637151', NULL);
GO
INSERT INTO dbo.TaiKhoan
(MaTaiKhoan, TenDangNhap, MatKhau, VaiTro, TrangThai, MaSV, MaNV)
VALUES
('TKSV02', '23630261', '123', N'SinhVien', N'Hoạt động', '23630261', NULL),
('TKSV03', '23631981', '123', N'SinhVien', N'Hoạt động', '23631981', NULL),
('TKSV04', '23723261', '123', N'SinhVien', N'Hoạt động', '23723261', NULL),
('TKSV05', '23631251', '123', N'SinhVien', N'Hoạt động', '23631251', NULL),
('TKSV06', '23722681', '123', N'SinhVien', N'Hoạt động', '23722681', NULL);
SELECT MaTaiKhoan, TenDangNhap, VaiTro, TrangThai, MaSV
FROM dbo.TaiKhoan
WHERE MaSV IN ('23630261', '23631981', '23723261', '23631251', '23722681')
ORDER BY MaTaiKhoan;

SELECT * FROM dbo.TaiKhoan;

--NHÂN VIÊN 
INSERT INTO dbo.NhanVien
(MaNV, HoTen, ChucVu, SDT, Email)
VALUES
('NV001', N'Nguyễn Văn Hùng', N'Nhân viên quản lý KTX', '0909123456', 'nguyenvanhung@iuh.edu.vn');
GO

SELECT * FROM dbo.NhanVien;
-- TÀI KHOẢN NHÂN VIÊN 
INSERT INTO dbo.TaiKhoan
(MaTaiKhoan, TenDangNhap, MatKhau, VaiTro, TrangThai, MaSV, MaNV)
VALUES
('TKNV01', 'NV001', '123', N'NhanVien', N'Hoạt động', NULL, 'NV001');
GO
UPDATE dbo.TaiKhoan
SET TenDangNhap = 'nguyenvanhung'
WHERE MaNV = 'NV001';
GO

SELECT NV.MaNV, NV.HoTen, NV.ChucVu,
       TK.MaTaiKhoan, TK.TenDangNhap, TK.VaiTro, TK.TrangThai
FROM dbo.NhanVien NV
JOIN dbo.TaiKhoan TK ON NV.MaNV = TK.MaNV
WHERE NV.MaNV = 'NV001';

--HỢP ĐỒNG
INSERT INTO dbo.HopDong
(MaHopDong, MaDangKy, NgayBatDau, NgayKetThuc, TrangThaiHopDong)
VALUES
('HD001', 'DK001', '2026-09-12', '2027-09-11', N'Đang hiệu lực'),
('HD002', 'DK002', '2026-09-12', '2027-09-11', N'Đang hiệu lực');
SELECT *
FROM dbo.HopDong;
-- HÓA ĐƠN 
INSERT INTO dbo.HoaDon
(MaHoaDon, MaHopDong, Thang, Nam, TienPhong, TienDien, TienNuoc, PhiDichVu, TongTien, NgayLap, TrangThaiThanhToan)
VALUES
('HDB001', 'HD001', 9, 2026, 700000, 120000, 80000, 50000, 950000, '2026-09-12', N'Chưa thanh toán'),
('HDB002', 'HD002', 9, 2026, 800000, 100000, 70000, 50000, 1020000, '2026-09-12', N'Đã thanh toán');
-- BÁO SỮA CHỬA
INSERT INTO dbo.BaoSuaChua
(MaBaoSua, MaSV, LoaiSuCo, MoTa, NgayBao, TrangThai, MaPhong, MaGiuong)
VALUES
('BS001', '23637151', N'Giường', N'Giường bị lỏng, cần kiểm tra và sửa chữa', '2026-09-12', N'Chờ xử lý', 'I201', 'G003'),
('BS002', '23631981', N'Điện', N'Ổ cắm điện trong phòng không hoạt động', '2026-09-12', N'Chờ xử lý', 'G201', 'G004');

-- LOẠI VI PHẠM 
SELECT COUNT(*) AS SoLoaiViPham
FROM dbo.LoaiViPham;

USE [QLKTX]
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP01', N'Tàng trữ vũ khí, chất nổ, chất cháy, hóa chất độc hại', N'Chấm dứt hợp đồng trước thời hạn, buộc ra khỏi KTX. Đề nghị Nhà trường xử lý kỷ luật', NULL, NULL, N'Tùy mức độ có thể giao cho cơ quan chức năng xử lý')
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP02', N'Tàng trữ, mua bán hoặc sử dụng chất ma túy', N'Chấm dứt hợp đồng trước thời hạn, buộc ra khỏi KTX. Đề nghị Nhà trường xử lý kỷ luật', NULL, NULL, N'Tùy mức độ có thể giao cho cơ quan chức năng xử lý')
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP03', N'Tàng trữ, lưu hành văn hóa phẩm độc hại, tài liệu bị Nhà nước cấm lưu hành, truyền đạo trái phép', N'Buộc ra khỏi KTX', NULL, NULL, NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP04', N'Chứa chấp, che giấu hàng cấm, hàng lậu', N'Buộc ra khỏi KTX', NULL, NULL, NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP05', N'Lấy cắp tài sản, chứa chấp tiêu thụ tài sản do người khác lấy cắp', N'Buộc ra khỏi KTX', NULL, NULL, NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP06', N'Tổ chức hoặc tham gia các hoạt động cờ bạc, cá độ dưới mọi hình thức', N'Buộc ra khỏi KTX', NULL, NULL, NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP07', N'Đánh nhau hoặc tổ chức đánh nhau', N'Cảnh cáo toàn KTX', N'Buộc ra khỏi KTX', NULL, NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP08', N'Gây ồn ào, làm mất trật tự khu KTX', N'Nhắc nhở', N'Cảnh cáo toàn KTX', N'Nếu tiếp tục tái phạm, buộc ra khỏi KTX', NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP09', N'Có thái độ vô lễ với thầy cô giáo và viên chức của Trường tại khu KTX; có thái độ bất hợp tác với bộ phận chức năng khi kiểm tra phòng ở', N'Tùy mức độ xử lý từ khiển trách đến buộc ra khỏi KTX', N'Đề nghị xử lý kỷ luật cấp trường', NULL, NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP10', N'Uống rượu bia, hút thuốc lá trong phòng ở; uống rượu bia nơi khác về KTX gây mất trật tự, có hành vi, lời nói không chuẩn mực', N'Cảnh cáo hoặc buộc ra khỏi KTX', N'Đề nghị xử lý kỷ luật cấp trường', NULL, NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP11', N'Tàng trữ các dụng cụ nấu ăn trong phòng', N'Nhắc nhở', N'Cảnh cáo toàn KTX', N'Buộc ra khỏi KTX', NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP12', N'Tổ chức nấu ăn trong phòng', N'Buộc ra khỏi KTX', NULL, NULL, NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP13', N'Tự ý di chuyển chỗ ở, không chấp hành sự bố trí chỗ ở của Phòng QLKTX', N'Cảnh cáo toàn KTX', N'Buộc ra khỏi KTX', NULL, NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP14', N'Tự ý đưa người ngoài vào khu vực KTX, cho người khác mượn và sử dụng Phiếu đăng ký nội trú', N'Nhắc nhở', N'Cảnh cáo toàn KTX', N'Buộc ra khỏi KTX', NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP15', N'Bao che người ngoài cư trú trái phép trong phòng ở', N'Buộc ra khỏi KTX', NULL, NULL, NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP16', N'Qua khu vực KTX khác giới', N'Nhắc nhở', N'Cảnh cáo toàn KTX', N'Buộc ra khỏi KTX', NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP17', N'Tiếp người khác giới trong phòng ở', N'Cảnh cáo toàn KTX', N'Buộc ra khỏi KTX', NULL, NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP18', N'Làm hư hỏng cơ sở vật chất, trang thiết bị của KTX', N'Bồi thường, nhắc nhở', N'Bồi thường, buộc ra khỏi KTX', NULL, NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP19', N'Đổ rác không đúng nơi quy định, xả rác; khoan, đục lỗ; viết, vẽ bậy; dán giấy, tranh ảnh, quảng cáo lên tường, bàn, ghế, hành lang và khuôn viên KTX', N'Nhắc nhở', N'Cảnh cáo toàn KTX', N'Buộc ra khỏi KTX', NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP20', N'Làm tắc nghẽn bồn cầu, hệ thống thoát nước; làm mất vệ sinh phòng ở và khu vực KTX', N'Nhắc nhở', N'Cảnh cáo toàn KTX', N'Buộc ra khỏi KTX', NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP21', N'Đặt bát hương thờ cúng trong phòng; nuôi cá, cất giấu vật nuôi trong KTX', N'Buộc phục hồi nguyên trạng, khiển trách', N'Cảnh cáo toàn KTX', N'Buộc ra khỏi KTX', NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP22', N'Mang các thiết bị, đồ dùng không được phép vào phòng ở; di chuyển các trang thiết bị trong phòng ở ra khỏi vị trí đã được bố trí', N'Nhắc nhở', N'Khiển trách', N'Cảnh cáo toàn KTX', NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP23', N'Câu, móc và sử dụng điện, nước trái phép', N'Truy thu tiền, buộc ra khỏi KTX', NULL, NULL, NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP24', N'Ra vào KTX quá giờ quy định không có lý do chính đáng', N'Nhắc nhở, báo phụ huynh', N'Khiển trách', N'Cảnh cáo toàn KTX', N'Tùy mức độ có thể buộc ra khỏi KTX')
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP25', N'Để xe không đúng nơi quy định', N'Nhắc nhở', N'Cảnh cáo toàn KTX', N'Buộc ra khỏi KTX', NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP26', N'Tự ý sử dụng, làm hỏng các thiết bị chữa cháy hoặc mở khóa báo động khi không có cháy nổ xảy ra trong khu vực', N'Cảnh cáo toàn KTX, bồi thường hư hỏng', N'Buộc ra khỏi KTX', NULL, NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP27', N'Sử dụng thiết bị đun nấu sai quy định KTX', N'Nhắc nhở', N'Buộc ra khỏi KTX', NULL, NULL)
GO
INSERT [dbo].[LoaiViPham] ([MaLoaiViPham], [TenViPham], [XuLyLan1], [XuLyLan2], [XuLyLan3], [GhiChu]) VALUES (N'LVP28', N'Vi phạm quy định về sử dụng Internet của Trường; cố tình can thiệp hoặc phá hỏng các thiết bị WiFi trong phòng ở và khu vực KTX', N'Cảnh cáo toàn KTX, bồi thường hư hỏng', N'Buộc ra khỏi KTX, bồi thường hư hỏng', NULL, NULL)
GO

SELECT COUNT(*) AS TongSoLoaiViPham
FROM dbo.LoaiViPham;

-- VI PHẠM 
SELECT COUNT(*) AS SoViPham
FROM dbo.ViPham;

INSERT INTO dbo.ViPham
(MaViPham, MaSV, MaLoaiViPham, NgayViPham, LanViPham, HinhThucXuLy, GhiChu)
VALUES
('VPH001', '23637151', 'LVP08', '2026-09-12', 1, N'Nhắc nhở', N'Dữ liệu kiểm thử hệ thống');

UPDATE dbo.ViPham
SET GhiChu = N'Gây ồn trong giờ nghỉ'
WHERE MaViPham = 'VPH001';

---KIỂM TRA GIƯỜNG 
SELECT MaGiuong, MaPhong, SoHieuGiuong, TrangThaiGiuong
FROM dbo.Giuong
ORDER BY MaGiuong;

-- KIỂM TRA MÃ SINH VIÊN 
SELECT MaSV, HoTen
FROM dbo.SinhVien
ORDER BY MaSV;

-- THÊM DANH SÁCH SINH VIÊN 
INSERT INTO dbo.SinhVien
(MaSV, HoTen, NgaySinh, GioiTinh, Lop, Khoa, SDT, Email, DiaChi, DoiTuongUuTien)
VALUES
('23723261', N'Nguyễn Thị Khánh Linh', '2006-01-02', N'Nữ', 'DHTC20ATT', N'Tài chính - Ngân hàng', '0981031676', 'nguyenthikhanhlinh@iuh.edu.vn', N'Long An', NULL),
('23631251', N'Văn Chánh Nguyên', '2007-04-09', N'Nam', 'DHCK19BTT', N'Cơ khí', '0321039595', 'vanchanhnguyen@iuh.edu.vn', N'Tiền Giang', NULL),
('23722681', N'Nguyễn Thị Mỹ Oanh', '2003-07-16', N'Nữ', 'DHDI20CTT', N'Điện - Điện tử', '0331047514', 'nguyenthimyoanh@iuh.edu.vn', N'Bến Tre', NULL),
('23723241', N'Lê Thế Thiệu', '2004-10-23', N'Nam', 'DHTM19ATT', N'Thương mại - Du lịch', '0341055433', 'lethethieu@iuh.edu.vn', N'Tây Ninh', NULL),
('23630931', N'Trần Thị Mộng Tuyền', '2005-01-03', N'Nữ', 'DHNN20BTT', N'Ngoại ngữ', '0351063352', 'tranthimongtuyen@iuh.edu.vn', N'Bà Rịa - Vũng Tàu', NULL),
('23724841', N'Đỗ Chiêu Anh', '2006-04-10', N'Nam', 'DHTH19ATT', N'Công nghệ thông tin', '0361071271', 'dochieuanh@iuh.edu.vn', N'TP.HCM', NULL),
('23643841', N'Phạm Mai Gia Bảo', '2007-07-17', N'Nam', 'DHQT19BTT', N'Quản trị kinh doanh', '0371079190', 'phammaigiabao@iuh.edu.vn', N'Đồng Nai', NULL),
('23650531', N'Trần Gia Bảo', '2003-10-24', N'Nam', 'DHKQ19CTT', N'Kế toán - Kiểm toán', '0381087109', 'trangiabao@iuh.edu.vn', N'Bình Dương', NULL),
('23650871', N'Nguyễn Quốc Đạt', '2004-01-04', N'Nam', 'DHTC20ATT', N'Tài chính - Ngân hàng', '0391095028', 'nguyenquocdat@iuh.edu.vn', N'Long An', NULL),
('23649321', N'Võ Quốc Đạt', '2005-04-11', N'Nam', 'DHCK19BTT', N'Cơ khí', '0901102947', 'voquocdat@iuh.edu.vn', N'Tiền Giang', NULL),
('23639971', N'Lâm Ngọc Giang', '2006-07-18', N'Nữ', 'DHDI20CTT', N'Điện - Điện tử', '0931110866', 'lamngocgiang@iuh.edu.vn', N'Bến Tre', NULL),
('23644611', N'Ân Nguyễn Phúc Hậu', '2007-10-25', N'Nam', 'DHTM19ATT', N'Thương mại - Du lịch', '0971118785', 'annguyenphuchau@iuh.edu.vn', N'Tây Ninh', NULL),
('23646531', N'Phạm Thị Thanh Hiền', '2003-01-05', N'Nữ', 'DHNN20BTT', N'Ngoại ngữ', '0981126704', 'phamthithanhhien@iuh.edu.vn', N'Bà Rịa - Vũng Tàu', NULL),
('23639951', N'Đặng Tuấn Khải', '2004-04-12', N'Nam', 'DHTH19ATT', N'Công nghệ thông tin', '0321134623', 'dangtuankhai@iuh.edu.vn', N'TP.HCM', NULL),
('23646731', N'Trần Quốc Khang', '2005-07-19', N'Nam', 'DHQT19BTT', N'Quản trị kinh doanh', '0331142542', 'tranquockhang@iuh.edu.vn', N'Đồng Nai', NULL),
('23644081', N'Lê Tấn Kiệt', '2006-10-26', N'Nam', 'DHKQ19CTT', N'Kế toán - Kiểm toán', '0341150461', 'letankiet@iuh.edu.vn', N'Bình Dương', NULL),
('23648141', N'Trịnh Đăng Lợi', '2007-01-06', N'Nam', 'DHTC20ATT', N'Tài chính - Ngân hàng', '0351158380', 'trinhdangloi@iuh.edu.vn', N'Long An', NULL),
('23645361', N'Vũ Hoàng Long', '2003-04-13', N'Nam', 'DHCK19BTT', N'Cơ khí', '0361166299', 'vuhoanglong@iuh.edu.vn', N'Tiền Giang', NULL),
('23641461', N'Lê Vũ Luân', '2004-07-20', N'Nam', 'DHDI20CTT', N'Điện - Điện tử', '0371174218', 'levuluan@iuh.edu.vn', N'Bến Tre', NULL),
('23651461', N'Đặng Chiến Thắng', '2005-10-27', N'Nam', 'DHTM19ATT', N'Thương mại - Du lịch', '0381182137', 'dangchienthang@iuh.edu.vn', N'Tây Ninh', NULL),
('23641221', N'Lê Văn Thông', '2006-01-07', N'Nam', 'DHNN20BTT', N'Ngoại ngữ', '0391190056', 'levanthong@iuh.edu.vn', N'Bà Rịa - Vũng Tàu', NULL),
('23642781', N'Lý Thị Anh Thư', '2007-04-14', N'Nữ', 'DHTH19ATT', N'Công nghệ thông tin', '0901197975', 'lythianhthu@iuh.edu.vn', N'TP.HCM', NULL),
('23648761', N'Huỳnh Quốc Toàn', '2003-07-21', N'Nam', 'DHQT19BTT', N'Quản trị kinh doanh', '0931205894', 'huynhquoctoan@iuh.edu.vn', N'Đồng Nai', NULL),
('23660541', N'Trần Vũ Quốc An', '2004-10-01', N'Nam', 'DHKQ19CTT', N'Kế toán - Kiểm toán', '0971213813', 'tranvuquocan@iuh.edu.vn', N'Bình Dương', NULL),
('23727321', N'Lê Thanh Bách', '2005-01-08', N'Nam', 'DHTC20ATT', N'Tài chính - Ngân hàng', '0981221732', 'lethanhbach@iuh.edu.vn', N'Long An', NULL),
('23658351', N'Bùi Quốc Bảo', '2006-04-15', N'Nam', 'DHCK19BTT', N'Cơ khí', '0321229651', 'buiquocbao@iuh.edu.vn', N'Tiền Giang', NULL),
('23653931', N'Nguyễn Trung Hiếu', '2007-07-22', N'Nam', 'DHDI20CTT', N'Điện - Điện tử', '0331237570', 'nguyentrunghieu@iuh.edu.vn', N'Bến Tre', NULL),
('23657641', N'Trương Huỳnh Bửu Hưng', '2003-10-02', N'Nam', 'DHTM19ATT', N'Thương mại - Du lịch', '0341245489', 'truonghuynhbuuhung@iuh.edu.vn', N'Tây Ninh', NULL),
('23652591', N'Ngô Thanh Huy', '2004-01-09', N'Nam', 'DHNN20BTT', N'Ngoại ngữ', '0351253408', 'ngothanhhuy@iuh.edu.vn', N'Bà Rịa - Vũng Tàu', NULL),
('23656951', N'Phùng Tấn Thảo My', '2005-04-16', N'Nữ', 'DHTH19ATT', N'Công nghệ thông tin', '0361261327', 'phungtanthaomy@iuh.edu.vn', N'TP.HCM', NULL),
('23660761', N'Nguyễn Ngô Minh Nhựt', '2006-07-23', N'Nam', 'DHQT19BTT', N'Quản trị kinh doanh', '0371269246', 'nguyenngominhnhut@iuh.edu.vn', N'Đồng Nai', NULL),
('23659911', N'Phạm Nguyễn Xuân Thanh', '2007-10-03', N'Nữ', 'DHKQ19CTT', N'Kế toán - Kiểm toán', '0381277165', 'phamnguyenxuanthanh@iuh.edu.vn', N'Bình Dương', NULL),
('23658751', N'Phạm Võ Trường Thịnh', '2003-01-10', N'Nam', 'DHTC20ATT', N'Tài chính - Ngân hàng', '0391285084', 'phamvotruongthinh@iuh.edu.vn', N'Long An', NULL),
('23662271', N'Hồ Minh Trọng', '2004-04-17', N'Nam', 'DHCK19BTT', N'Cơ khí', '0901293003', 'hominhtrong@iuh.edu.vn', N'Tiền Giang', NULL),
('23655891', N'Trần Như Ý', '2005-07-24', N'Nữ', 'DHDI20CTT', N'Điện - Điện tử', '0931300922', 'trannhuy@iuh.edu.vn', N'Bến Tre', NULL),
('23669791', N'Phạm Thị Thùy Duyên', '2006-10-04', N'Nữ', 'DHTM19ATT', N'Thương mại - Du lịch', '0971308841', 'phamthithuyduyen@iuh.edu.vn', N'Tây Ninh', NULL),
('23673071', N'Huỳnh Gia Hân', '2007-01-11', N'Nữ', 'DHNN20BTT', N'Ngoại ngữ', '0981316760', 'huynhgiahan@iuh.edu.vn', N'Bà Rịa - Vũng Tàu', NULL),
('23729531', N'Nguyễn Hoàng Minh Nhật', '2003-04-18', N'Nam', 'DHTH19ATT', N'Công nghệ thông tin', '0321324679', 'nguyenhoangminhnhat@iuh.edu.vn', N'TP.HCM', NULL),
('23664171', N'Nguyễn Quang Phước', '2004-07-25', N'Nam', 'DHQT19BTT', N'Quản trị kinh doanh', '0331332598', 'nguyenquangphuoc@iuh.edu.vn', N'Đồng Nai', NULL),
('23671881', N'Vũ Gia Thịnh', '2005-10-05', N'Nam', 'DHKQ19CTT', N'Kế toán - Kiểm toán', '0341340517', 'vugiathinh@iuh.edu.vn', N'Bình Dương', NULL),
('23737941', N'Huỳnh Công Thuận', '2006-01-12', N'Nam', 'DHTC20ATT', N'Tài chính - Ngân hàng', '0351348436', 'huynhcongthuan@iuh.edu.vn', N'Long An', NULL),
('23673761', N'Nguyễn Ngọc Thủy Tiên', '2007-04-19', N'Nữ', 'DHCK19BTT', N'Cơ khí', '0361356355', 'nguyenngocthuytien@iuh.edu.vn', N'Tiền Giang', NULL),
('23664731', N'Võ Ngọc Huyền Trân', '2003-07-26', N'Nữ', 'DHDI20CTT', N'Điện - Điện tử', '0371364274', 'vongochuyentran@iuh.edu.vn', N'Bến Tre', NULL),
('23665061', N'Trương Thanh Tú', '2004-10-06', N'Nam', 'DHTM19ATT', N'Thương mại - Du lịch', '0381372193', 'truongthanhtu@iuh.edu.vn', N'Tây Ninh', NULL),
('23674171', N'Phùng Võ Việt Tường Vi', '2005-01-13', N'Nữ', 'DHNN20BTT', N'Ngoại ngữ', '0391380112', 'phungvoviettuongvi@iuh.edu.vn', N'Bà Rịa - Vũng Tàu', NULL),
('23670471', N'Trần Đàm Thoại Vi', '2006-04-20', N'Nữ', 'DHTH19ATT', N'Công nghệ thông tin', '0901388031', 'trandamthoaivi@iuh.edu.vn', N'TP.HCM', NULL),
('23673621', N'Lương Nguyễn Thành Vinh', '2007-07-27', N'Nam', 'DHQT19BTT', N'Quản trị kinh doanh', '0931395950', 'luongnguyenthanhvinh@iuh.edu.vn', N'Đồng Nai', NULL);
SELECT COUNT(*) AS TongSinhVien
FROM dbo.SinhVien;

-- TẠO THÊM TÀI KHOẢN CHO SINH VIÊN 
DECLARE @SoLonNhat INT;

SELECT @SoLonNhat = ISNULL(MAX(TRY_CAST(SUBSTRING(MaTaiKhoan, 5, 10) AS INT)), 0)
FROM dbo.TaiKhoan
WHERE MaTaiKhoan LIKE 'TKSV%';

WITH SinhVienChuaCoTaiKhoan AS
(
    SELECT sv.MaSV,
           ROW_NUMBER() OVER (ORDER BY sv.MaSV) AS STT
    FROM dbo.SinhVien sv
    WHERE NOT EXISTS
    (
        SELECT 1
        FROM dbo.TaiKhoan tk
        WHERE tk.MaSV = sv.MaSV
    )
    AND NOT EXISTS
    (
        SELECT 1
        FROM dbo.TaiKhoan tk
        WHERE tk.TenDangNhap = sv.MaSV
    )
)
INSERT INTO dbo.TaiKhoan
(MaTaiKhoan, TenDangNhap, MatKhau, VaiTro, TrangThai, MaSV, MaNV)
SELECT
    'TKSV' + RIGHT('00' + CAST(@SoLonNhat + STT AS VARCHAR(3)), 2),
    MaSV,
    '123',
    N'SinhVien',
    N'Hoạt động',
    MaSV,
    NULL
FROM SinhVienChuaCoTaiKhoan;

SELECT COUNT(*) AS TongTaiKhoanSinhVien
FROM dbo.TaiKhoan
WHERE VaiTro = N'SinhVien';

-- KIỂM TRA MÃ NHÂN VIÊN 
SELECT *
FROM dbo.NhanVien
ORDER BY MaNV;
-- CẬP NHẬT DANH SÁCH NHÂN VIÊN 
UPDATE dbo.NhanVien
SET HoTen = N'Nguyễn Văn Minh',
    ChucVu = N'Quản lý ký túc xá',
    SDT = '0908123456',
    Email = 'nguyenvanminh@iuh.edu.vn'
WHERE MaNV = 'NV001';

INSERT INTO dbo.NhanVien
(MaNV, HoTen, ChucVu, SDT, Email)
VALUES
('NV002', N'Trần Thị Lan', N'Nhân viên quản lý nội trú', '0937251846', 'tranthilan@iuh.edu.vn'),
('NV003', N'Lê Hoàng Nam', N'Nhân viên quản lý nội trú', '0973142865', 'lehoangnam@iuh.edu.vn'),
('NV004', N'Phạm Thị Ngọc An', N'Nhân viên thu phí', '0986412735', 'phamthingocan@iuh.edu.vn'),
('NV005', N'Võ Minh Khang', N'Nhân viên cơ sở vật chất', '0325831746', 'vominhkhang@iuh.edu.vn'),
('NV006', N'Nguyễn Thị Thu Hà', N'Nhân viên quản lý nội trú', '0336142857', 'nguyenthithuha@iuh.edu.vn'),
('NV007', N'Trần Quốc Huy', N'Nhân viên cơ sở vật chất', '0347253968', 'tranquochuy@iuh.edu.vn'),
('NV008', N'Lê Thị Thanh Mai', N'Nhân viên thu phí', '0358364079', 'lethithanhmai@iuh.edu.vn'),
('NV009', N'Phạm Hoàng Phúc', N'Nhân viên quản lý nội trú', '0369475180', 'phamhoangphuc@iuh.edu.vn'),
('NV010', N'Võ Thị Ngọc Hân', N'Nhân viên quản lý nội trú', '0371586291', 'vothingochan@iuh.edu.vn');

SELECT *
FROM dbo.NhanVien
ORDER BY MaNV;
-- KIỂM TRA TÀI KHOẢN NHÂN VIÊN 
SELECT MaTaiKhoan, TenDangNhap, MatKhau, VaiTro, TrangThai, MaNV
FROM dbo.TaiKhoan
WHERE VaiTro = N'NhanVien'
ORDER BY MaTaiKhoan;

UPDATE dbo.TaiKhoan
SET TenDangNhap = 'nguyenvanminh',
    MatKhau = '123',
    VaiTro = N'NhanVien',
    TrangThai = N'Hoạt động',
    MaSV = NULL,
    MaNV = 'NV001'
WHERE MaTaiKhoan = 'TKNV01';

INSERT INTO dbo.TaiKhoan
(MaTaiKhoan, TenDangNhap, MatKhau, VaiTro, TrangThai, MaSV, MaNV)
VALUES
('TKNV02', 'tranthilan', '123', N'NhanVien', N'Hoạt động', NULL, 'NV002'),
('TKNV03', 'lehoangnam', '123', N'NhanVien', N'Hoạt động', NULL, 'NV003'),
('TKNV04', 'phamthingocan', '123', N'NhanVien', N'Hoạt động', NULL, 'NV004'),
('TKNV05', 'vominhkhang', '123', N'NhanVien', N'Hoạt động', NULL, 'NV005'),
('TKNV06', 'nguyenthithuha', '123', N'NhanVien', N'Hoạt động', NULL, 'NV006'),
('TKNV07', 'tranquochuy', '123', N'NhanVien', N'Hoạt động', NULL, 'NV007'),
('TKNV08', 'lethithanhmai', '123', N'NhanVien', N'Hoạt động', NULL, 'NV008'),
('TKNV09', 'phamhoangphuc', '123', N'NhanVien', N'Hoạt động', NULL, 'NV009'),
('TKNV10', 'vothingochan', '123', N'NhanVien', N'Hoạt động', NULL, 'NV010');

SELECT MaTaiKhoan, TenDangNhap, MatKhau, VaiTro, TrangThai, MaNV
FROM dbo.TaiKhoan
WHERE VaiTro = N'NhanVien'
ORDER BY MaTaiKhoan;