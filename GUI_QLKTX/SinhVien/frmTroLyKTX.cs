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
    public partial class frmTroLyKTX : Form
    {
        private string maSV;
        BUS_TroLyKTX bus = new BUS_TroLyKTX();
        public frmTroLyKTX(string maSV)
        {
            InitializeComponent();
            this.maSV = maSV;
        }
    

        private void frmTroLyKTX_Load(object sender, EventArgs e)
        {
            rtbTroChuyen.ReadOnly = true;

            rtbTroChuyen.Text =
                "Trợ lý KTX:\n" +
                "Xin chào! Tôi có thể hỗ trợ bạn tra cứu thông tin ký túc xá.\n" +
                "Bạn có thể hỏi về phòng, hóa đơn, đăng ký ở, hợp đồng, báo sửa chữa hoặc nội quy.";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            string cauHoi = txtCauHoi.Text.Trim();

            if (cauHoi == "")
            {
                MessageBox.Show("Vui lòng nhập câu hỏi!");
                txtCauHoi.Focus();
                return;
            }

            XuLyCauHoi(cauHoi);
            txtCauHoi.Clear();
            txtCauHoi.Focus();
        }
        private void XuLyCauHoi(string cauHoi)
        {
            ThemHoiThoai("Bạn", cauHoi);

            string noiDung = cauHoi.ToLower();

            if (LaCauHoiNoiQuy(noiDung))
            {
                TraLoiNoiQuy(cauHoi);
            }
            else if (noiDung.Contains("hóa đơn") || noiDung.Contains("thanh toán") || noiDung.Contains("tiền phòng") || noiDung.Contains("tiền điện") || noiDung.Contains("tiền nước"))
            {
                TraLoiHoaDon();
            }
            else if (noiDung.Contains("đăng ký"))
            {
                TraLoiDangKy();
            }
            else if (noiDung.Contains("hợp đồng"))
            {
                TraLoiHopDong();
            }
            else if (noiDung.Contains("sửa chữa") || noiDung.Contains("báo sửa") || noiDung.Contains("sự cố") || noiDung.Contains("hư"))
            {
                TraLoiBaoSua();
            }
            else if (noiDung.Contains("phòng") || noiDung.Contains("giường") || noiDung.Contains("ở đâu"))
            {
                TraLoiPhong();
            }
            else
            {
                ThemHoiThoai("Trợ lý KTX", "Tôi chưa hiểu câu hỏi này. Bạn có thể hỏi về phòng, hóa đơn, đăng ký ở, hợp đồng, báo sửa chữa hoặc nội quy.");
            }
        }
        private bool LaCauHoiNoiQuy(string noiDung)
        {
            string[] tuKhoa =
            {
        "nội quy", "vi phạm", "bị phạt",
        "vũ khí", "chất nổ", "ma túy", "văn hóa phẩm", "truyền đạo",
        "hàng cấm", "hàng lậu", "lấy cắp", "trộm", "ăn cắp",
        "cờ bạc", "cá độ", "đánh bài", "đánh nhau", "đánh lộn",
        "gây ồn", "ồn ào", "mất trật tự", "vô lễ", "bất hợp tác",
        "hút thuốc", "thuốc lá", "rượu", "bia",
        "nấu ăn", "nấu nướng", "dụng cụ nấu", "bếp", "nồi cơm",
        "đổi phòng", "đổi chỗ", "di chuyển chỗ ở",
        "người ngoài", "ở ké", "ngủ ké", "cư trú trái phép",
        "khác giới", "làm hư", "làm hỏng", "cơ sở vật chất",
        "xả rác", "đổ rác", "vẽ bậy", "dán giấy", "khoan", "đục lỗ",
        "bồn cầu", "thoát nước", "mất vệ sinh",
        "vật nuôi", "nuôi chó", "nuôi mèo", "nuôi cá", "thờ cúng", "bát hương",
        "đồ dùng không được phép", "thiết bị không được phép",
        "câu điện", "câu nước", "móc điện", "móc nước",
        "quá giờ", "về trễ", "về khuya", "giờ giới nghiêm",
        "để xe", "đậu xe", "chữa cháy", "báo cháy", "pccc",
        "đun nấu", "thiết bị đun", "wifi", "internet"
    };

            return tuKhoa.Any(tu => noiDung.Contains(tu));
        }
        private void TraLoiPhong()
        {
            DataTable dt = bus.LayChoOHienTai(maSV);

            if (dt.Rows.Count == 0)
            {
                ThemHoiThoai("Trợ lý KTX", "Hiện tại bạn chưa có thông tin phòng và giường đã được duyệt.");
                return;
            }

            DataRow row = dt.Rows[0];

            string traLoi = "Bạn hiện đang ở " +
                            row["TenPhong"].ToString() + ", " +
                            row["SoHieuGiuong"].ToString() + ", " +
                            row["TenToaNha"].ToString() + ".";

            ThemHoiThoai("Trợ lý KTX", traLoi);
        }

        private void TraLoiDangKy()
        {
            DataTable dt = bus.LayDangKyMoiNhat(maSV);

            if (dt.Rows.Count == 0)
            {
                ThemHoiThoai("Trợ lý KTX", "Bạn chưa có đăng ký ở nào.");
                return;
            }

            DataRow row = dt.Rows[0];

            string traLoi = "Đăng ký gần nhất của bạn là " +
                            row["MaDangKy"].ToString() +
                            ", ngày " +
                            Convert.ToDateTime(row["NgayDangKy"]).ToString("dd/MM/yyyy") +
                            ", trạng thái: " +
                            row["TrangThaiDangKy"].ToString() + ".";

            ThemHoiThoai("Trợ lý KTX", traLoi);
        }

        private void TraLoiHopDong()
        {
            DataTable dt = bus.LayHopDongHienTai(maSV);

            if (dt.Rows.Count == 0)
            {
                ThemHoiThoai("Trợ lý KTX", "Bạn chưa có hợp đồng ký túc xá.");
                return;
            }

            DataRow row = dt.Rows[0];

            string traLoi = "Hợp đồng " +
                            row["MaHopDong"].ToString() +
                            " có thời hạn từ " +
                            Convert.ToDateTime(row["NgayBatDau"]).ToString("dd/MM/yyyy") +
                            " đến " +
                            Convert.ToDateTime(row["NgayKetThuc"]).ToString("dd/MM/yyyy") +
                            ", trạng thái: " +
                            row["TrangThaiHopDong"].ToString() + ".";

            ThemHoiThoai("Trợ lý KTX", traLoi);
        }

        private void TraLoiHoaDon()
        {
            DataTable dt = bus.LayHoaDonChuaThanhToan(maSV);

            if (dt.Rows.Count == 0)
            {
                ThemHoiThoai("Trợ lý KTX", "Bạn hiện không có hóa đơn chưa thanh toán.");
                return;
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Bạn có " + dt.Rows.Count + " hóa đơn chưa thanh toán:");

            foreach (DataRow row in dt.Rows)
            {
                decimal tongTien = Convert.ToDecimal(row["TongTien"]);

                sb.AppendLine(
                    "- Tháng " +
                    row["Thang"].ToString() + "/" +
                    row["Nam"].ToString() +
                    ": " +
                    tongTien.ToString("N0") +
                    " đ");
            }

            ThemHoiThoai("Trợ lý KTX", sb.ToString().Trim());
        }

        private void TraLoiBaoSua()
        {
            DataTable dt = bus.LayBaoSuaMoiNhat(maSV);

            if (dt.Rows.Count == 0)
            {
                ThemHoiThoai("Trợ lý KTX", "Bạn chưa gửi yêu cầu báo sửa chữa nào.");
                return;
            }

            DataRow row = dt.Rows[0];

            string traLoi = "Yêu cầu " +
                            row["MaBaoSua"].ToString() +
                            " - " +
                            row["LoaiSuCo"].ToString() +
                            ", ngày báo " +
                            Convert.ToDateTime(row["NgayBao"]).ToString("dd/MM/yyyy") +
                            ", trạng thái: " +
                            row["TrangThai"].ToString() + ".";

            ThemHoiThoai("Trợ lý KTX", traLoi);
        }

        private void TraLoiNoiQuy(string cauHoi)
        {
            string tuKhoa = LayTuKhoaNoiQuy(cauHoi);

            DataTable dt = bus.TimNoiQuy(tuKhoa);

            if (dt.Rows.Count == 0)
            {
                ThemHoiThoai("Trợ lý KTX",
                    "Tôi chưa tìm thấy nội quy phù hợp. Bạn có thể hỏi cụ thể như: gây ồn, đánh nhau, nấu ăn, hút thuốc...");
                return;
            }

            DataRow row = dt.Rows[0];

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(row["TenViPham"].ToString());

            if (row["XuLyLan1"] != DBNull.Value)
            {
                sb.AppendLine("Lần 1: " + row["XuLyLan1"].ToString());
            }

            if (row["XuLyLan2"] != DBNull.Value)
            {
                sb.AppendLine("Lần 2: " + row["XuLyLan2"].ToString());
            }

            if (row["XuLyLan3"] != DBNull.Value)
            {
                sb.AppendLine("Lần 3: " + row["XuLyLan3"].ToString());
            }

            ThemHoiThoai("Trợ lý KTX", sb.ToString().Trim());
        }

        private string LayTuKhoaNoiQuy(string cauHoi)
        {
            string noiDung = cauHoi.ToLower();

            if (noiDung.Contains("vũ khí") || noiDung.Contains("chất nổ") || noiDung.Contains("chất cháy") || noiDung.Contains("hóa chất")) return "Tàng trữ vũ khí";
            if (noiDung.Contains("ma túy")) return "chất ma túy";
            if (noiDung.Contains("văn hóa phẩm") || noiDung.Contains("truyền đạo")) return "văn hóa phẩm";
            if (noiDung.Contains("hàng cấm") || noiDung.Contains("hàng lậu")) return "hàng cấm";
            if (noiDung.Contains("lấy cắp") || noiDung.Contains("trộm") || noiDung.Contains("ăn cắp")) return "Lấy cắp";
            if (noiDung.Contains("cờ bạc") || noiDung.Contains("cá độ") || noiDung.Contains("đánh bài")) return "cờ bạc";
            if (noiDung.Contains("đánh nhau") || noiDung.Contains("đánh lộn")) return "Đánh nhau";
            if (noiDung.Contains("gây ồn") || noiDung.Contains("ồn ào") || noiDung.Contains("mất trật tự")) return "Gây ồn";
            if (noiDung.Contains("vô lễ") || noiDung.Contains("bất hợp tác")) return "vô lễ";
            if (noiDung.Contains("hút thuốc") || noiDung.Contains("thuốc lá") || noiDung.Contains("rượu") || noiDung.Contains("bia")) return "Uống rượu bia";
            if (noiDung.Contains("dụng cụ nấu") || noiDung.Contains("bếp") || noiDung.Contains("nồi cơm")) return "dụng cụ nấu ăn";
            if (noiDung.Contains("nấu ăn") || noiDung.Contains("nấu nướng")) return "Tổ chức nấu ăn";
            if (noiDung.Contains("đổi phòng") || noiDung.Contains("đổi chỗ") || noiDung.Contains("di chuyển chỗ ở")) return "di chuyển chỗ ở";
            if (noiDung.Contains("người ngoài") || noiDung.Contains("đưa bạn vào") || noiDung.Contains("đưa người vào")) return "đưa người ngoài";
            if (noiDung.Contains("ở ké") || noiDung.Contains("ngủ ké") || noiDung.Contains("cư trú trái phép")) return "cư trú trái phép";
            if (noiDung.Contains("khác giới") && (noiDung.Contains("qua") || noiDung.Contains("sang"))) return "Qua khu vực KTX khác giới";
            if (noiDung.Contains("khác giới")) return "Tiếp người khác giới";
            if (noiDung.Contains("làm hư") || noiDung.Contains("làm hỏng") || noiDung.Contains("cơ sở vật chất")) return "Làm hư hỏng cơ sở vật chất";
            if (noiDung.Contains("xả rác") || noiDung.Contains("đổ rác") || noiDung.Contains("vẽ bậy") || noiDung.Contains("dán giấy") || noiDung.Contains("khoan") || noiDung.Contains("đục lỗ")) return "Đổ rác";
            if (noiDung.Contains("bồn cầu") || noiDung.Contains("thoát nước") || noiDung.Contains("mất vệ sinh")) return "Làm tắc nghẽn";
            if (noiDung.Contains("vật nuôi") || noiDung.Contains("nuôi chó") || noiDung.Contains("nuôi mèo") || noiDung.Contains("nuôi cá") || noiDung.Contains("thờ cúng") || noiDung.Contains("bát hương")) return "Đặt bát hương";
            if (noiDung.Contains("đồ dùng không được phép") || noiDung.Contains("thiết bị không được phép") || noiDung.Contains("di chuyển thiết bị")) return "Mang các thiết bị";
            if (noiDung.Contains("câu điện") || noiDung.Contains("câu nước") || noiDung.Contains("móc điện") || noiDung.Contains("móc nước") || noiDung.Contains("điện nước trái phép")) return "Câu, móc";
            if (noiDung.Contains("quá giờ") || noiDung.Contains("về trễ") || noiDung.Contains("về khuya") || noiDung.Contains("giờ giới nghiêm")) return "quá giờ";
            if (noiDung.Contains("để xe") || noiDung.Contains("đậu xe")) return "Để xe";
            if (noiDung.Contains("chữa cháy") || noiDung.Contains("báo cháy") || noiDung.Contains("pccc")) return "chữa cháy";
            if (noiDung.Contains("đun nấu") || noiDung.Contains("thiết bị đun")) return "thiết bị đun nấu";
            if (noiDung.Contains("wifi") || noiDung.Contains("internet") || noiDung.Contains("mạng")) return "Internet";

            return cauHoi.Trim();
        }

        private void ThemHoiThoai(string nguoiGui, string noiDung)
        {
            if (rtbTroChuyen.Text.Trim() != "")
            {
                rtbTroChuyen.AppendText("\n\n");
            }

            rtbTroChuyen.AppendText(nguoiGui + ":\n" + noiDung);
            rtbTroChuyen.SelectionStart = rtbTroChuyen.Text.Length;
            rtbTroChuyen.ScrollToCaret();
        }

        private void btnPhongCuaToi_Click(object sender, EventArgs e)
        {
            XuLyCauHoi("Tôi đang ở phòng nào?");
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            XuLyCauHoi("Tôi có hóa đơn nào chưa thanh toán?");
        }

        private void btnDangKyO_Click(object sender, EventArgs e)
        {
            XuLyCauHoi("Trạng thái đăng ký ở của tôi?");
        }

        private void btnBaoSuaChua_Click(object sender, EventArgs e)
        {
            XuLyCauHoi("Báo sửa chữa của tôi đang xử lý thế nào?");
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            XuLyCauHoi("Hợp đồng của tôi hiện thế nào?");
        }

        private void btnNoiQuy_Click(object sender, EventArgs e)
        {
            ThemHoiThoai("Trợ lý KTX",
                "Bạn có thể hỏi nội quy cụ thể, ví dụ: gây ồn xử lý thế nào, nấu ăn trong phòng bị xử lý ra sao, hút thuốc bị xử lý thế nào...");
        }
    }
}
