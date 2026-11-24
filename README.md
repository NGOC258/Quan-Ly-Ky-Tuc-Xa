# 🏢 Hệ Thống Quản Lý Ký Túc Xá (QLKTX)

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-512BD4?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp)
![Platform](https://img.shields.io/badge/Platform-Windows%20Forms-0078D4?logo=windows)
![Database](https://img.shields.io/badge/Database-SQL%20Server-CC292B?logo=microsoftsqlserver)
![Architecture](https://img.shields.io/badge/Architecture-3--Tier%20Architecture-brightgreen)

Ứng dụng quản lý ký túc xá hoàn chỉnh dành cho các trường đại học/cao đẳng, được xây dựng trên nền tảng **C# Windows Forms (.NET Framework 4.7.2)** kết hợp với cơ sở dữ liệu **Microsoft SQL Server**, áp dụng mô hình kiến trúc **3 lớp (3-Tier Architecture)** chuẩn mực.

---

## 📑 Mục lục
- [Giới thiệu](#-giới-thiệu)
- [Tính năng nổi bật](#-tính-năng-nổi-bật)
- [Kiến trúc hệ thống](#-kiến-trúc-hệ-thống)
- [Cấu trúc thư mục](#-cấu-trúc-thư-mục)
- [Yêu cầu hệ thống](#-yêu-cầu-hệ-thống)
- [Hướng dẫn cài đặt & Chạy](#-hướng-dẫn-cài-đặt--chạy)
- [Thông tin tác giả](#-thông-tin-tác-giả)

---

## 💡 Giới thiệu
Dự án nhằm số hóa toàn diện quy trình vận hành ký túc xá, từ khâu quản lý cơ sở vật chất, quản lý lưu trú sinh viên, thu chi hóa đơn đến tiếp nhận và xử lý sự cố. Ứng dụng hỗ trợ phân quyền rõ ràng giữa Quản trị viên (Admin), Ban quản lý KTX (Nhân viên) và Sinh viên nội trú.

---

## 🚀 Tính năng nổi bật

### 1. 🛡️ Phân hệ Quản trị viên (Admin)
- **Quản lý Tài khoản & Phân quyền**: Cấp phát, phân loại vai trò (Admin, Nhân viên, Sinh viên), khóa/mở tài khoản.
- **Quản lý Nhân viên**: Quản lý hồ sơ, thông tin liên lạc và chức vụ nhân sự KTX.
- **Quản lý Tòa nhà & Loại phòng**: Thiết lập danh mục tòa nhà, các loại phòng (phòng 4 người, 6 người, 8 người, mức giá tương ứng).
- **Báo cáo & Thống kê**: Báo cáo tổng hợp số lượng sinh viên, tình trạng lấp đầy phòng, doanh thu hóa đơn theo tháng/kỳ.

### 2. 📋 Phân hệ Ban Quản lý (Nhân viên KTX)
- **Quản lý Phòng & Giường**: Theo dõi trực quan trạng thái từng phòng, số giường trống/đã ở theo từng tòa nhà.
- **Quản lý Sinh viên**: Tra cứu, thêm mới, cập nhật hồ sơ sinh viên lưu trú.
- **Quản lý Đăng ký ở**: Xét duyệt hoặc từ chối các đơn đăng ký phòng từ sinh viên.
- **Quản lý Hợp đồng**: Tạo và quản lý hợp đồng thuê phòng KTX theo từng kỳ học hoặc năm học.
- **Quản lý Hóa đơn**: Tính toán và lập hóa đơn tiền phòng, tiền điện, tiền nước định kỳ; theo dõi tình trạng thanh toán.
- **Tiếp nhận & Xử lý báo sửa chữa**: Theo dõi các yêu cầu hỏng hóc cơ sở vật chất gửi từ phòng/sinh viên và phân công xử lý.
- **Quản lý Vi phạm**: Ghi nhận các biên bản vi phạm nội quy KTX (giờ giấc, kỷ luật, an toàn PCCC).

### 3. 🎓 Phân hệ Sinh viên
- **Thông tin cá nhân**: Cập nhật thông tin liên lạc cá nhân, đổi mật khẩu tài khoản.
- **Đăng ký phòng trực tuyến**: Tra cứu phòng trống theo loại phòng/tòa nhà và nộp đơn đăng ký ở.
- **Tra cứu Hợp đồng & Hóa đơn**: Xem chi tiết hợp đồng lưu trú và các khoản phí sinh hoạt hàng tháng.
- **Gửi báo sự cố / Sửa chữa**: Gửi phản ánh khi trang thiết bị trong phòng gặp sự cố (quạt, điện thoại nước, giường,...).
- **Trợ lý KTX**: Mục hướng dẫn và giải đáp các câu hỏi thường gặp dành cho sinh viên nội trú.

---

## 🏗️ Kiến trúc hệ thống

Dự án áp dụng mô hình **3-Tier Architecture**:
```text
┌──────────────────────────────────────────────┐
│        Presentation Layer (GUI_QLKTX)        │
│   Windows Forms, Controls, User Interaction  │
└──────────────────────┬───────────────────────┘
                       │
┌──────────────────────▼───────────────────────┐
│        Business Logic Layer (QLKTX / BUS)    │
│    Business Rules, Validation, Processing    │
└──────────────────────┬───────────────────────┘
                       │
┌──────────────────────▼───────────────────────┐
│         Data Access Layer (DAL_QLKTX)        │
│    ADO.NET, SqlConnection, SqlCommand, SQL   │
└──────────────────────┬───────────────────────┘
                       │
┌──────────────────────▼───────────────────────┐
│               Database Layer                 │
│             Microsoft SQL Server             │
└──────────────────────────────────────────────┘

* Data Transfer Objects (DTO_QLKTX) được dùng xuyên suốt để đóng gói và vận chuyển dữ liệu giữa các tầng.
```

---

## 📂 Cấu trúc thư mục

```text
QLKTX/
├── DAL_QLKTX/            # Tầng truy xuất dữ liệu (Data Access Layer)
│   ├── DBConnect.cs      # Khởi tạo chuỗi kết nối SQL Server
│   ├── DAL_SinhVien.cs   # Truy vấn dữ liệu sinh viên
│   ├── DAL_Phong.cs      # Truy vấn dữ liệu phòng
│   └── ...               # Các lớp DAL khác
├── DTO_QLKTX/            # Tầng truyền dữ liệu (Data Transfer Objects)
│   ├── DTO_SinhVien.cs   # Lớp đối tượng Sinh viên
│   ├── DTO_Phong.cs      # Lớp đối tượng Phòng
│   └── ...               # Các lớp DTO khác
├── QLKTX/                # Tầng nghiệp vụ (Business Logic Layer - BUS)
│   ├── BUS_SinhVien.cs   # Xử lý nghiệp vụ sinh viên
│   ├── BUS_Phong.cs      # Xử lý nghiệp vụ phòng
│   └── ...               # Các lớp BUS khác
├── GUI_QLKTX/            # Tầng giao diện người dùng (Presentation Layer)
│   ├── frmDangNhap.cs    # Giao diện Đăng nhập
│   ├── frmAdmin.cs       # Giao diện Quản trị viên
│   ├── frmNhanVien.cs    # Giao diện Quản lý KTX
│   ├── SinhVien/         # Các form dành riêng cho sinh viên
│   └── ...               # Các form nghiệp vụ khác
├── database/             # Thư mục lưu trữ script khởi tạo CSDL (.sql)
├── .gitignore            # Loại bỏ các file rác khi đẩy lên Git/GitHub
├── QLKTX.sln             # Visual Studio Solution File
└── README.md             # Tài liệu dự án
```

---

## 💻 Yêu cầu hệ thống

- **Hệ điều hành**: Windows 10/11
- **IDE**: [Visual Studio 2019 / 2022](https://visualstudio.microsoft.com/) (đã cài gói *.NET desktop development*)
- **Framework**: [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472) trở lên
- **Hệ quản trị CSDL**: [Microsoft SQL Server](https://www.microsoft.com/sql-server/) (2014 trở lên hoặc SQL Server Express)
- **Công cụ quản lý DB**: [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms)

---

## 🛠️ Hướng dẫn cài đặt & Chạy

### 1. Khởi tạo Cơ sở dữ liệu
1. Mở **SQL Server Management Studio (SSMS)**.
2. Kết nối tới SQL Server của máy bạn.
3. Mở file script khởi tạo CSDL tại [database/QLKTX.sql](database/QLKTX.sql).
4. Nhấn **Execute (F5)** để tự động tạo cơ sở dữ liệu `QLKTX`, các bảng và dữ liệu mẫu khởi tạo.

### 2. Cấu hình chuỗi kết nối
Mở file `DAL_QLKTX/DBConnect.cs` và kiểm tra / sửa lại chuỗi kết nối phù hợp với SQL Server máy bạn:

```csharp
public DBConnect()
{
    conn = new SqlConnection(
        @"Data Source=YOUR_SERVER_NAME;
        Initial Catalog=QLKTX;
        Integrated Security=True");
}
```
*(Thay thế `YOUR_SERVER_NAME` bằng tên Server SQL của bạn, ví dụ `localhost`, `.`, hoặc `DESKTOP-XXXXX\SQLEXPRESS`).*

### 3. Mở và Khởi chạy chương trình
1. Mở file `QLKTX.sln` bằng Visual Studio.
2. Nhấn **Build > Build Solution** (hoặc `Ctrl + Shift + B`) để biên dịch.
3. Nhấn **F5** hoặc nút **Start** để chạy ứng dụng.

---

## 👤 Thông tin tác giả
- **Đề tài**: Đồ án Quản lý Ký túc xá (QLKTX)
- **GitHub**: [@NGOC258](https://github.com/NGOC258)
- **Repository**: [Quan-Ly-Ky-Tuc-Xa](https://github.com/NGOC258/Quan-Ly-Ky-Tuc-Xa)
- **Trường**: Đại học Mở TP. Hồ Chí Minh

---

## 📄 Bản quyền & Giấy phép
Dự án được phát triển phục vụ mục đích học tập và nghiên cứu. Mọi đóng góp xin vui lòng tạo Issue hoặc Pull Request.
