using Btl_QuanLyNhaSach.Modify;
using System;
using System.Data;
using System.Windows.Forms;

namespace Btl_QuanLyNhaSach
{
    public partial class tbldanhsachhoadonnhap : Form
    {
        ModifyAll modify = new ModifyAll();

        public tbldanhsachhoadonnhap()
        {
            InitializeComponent();
        }

        // Xử lí sự kiện click 1 hóa đơn trong datagridview thì dữ liệu sẽ đổ sang form chi tiết hóa đơn đó
        private void dataGridView_DanhSachHDNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_DanhSachHDNhap.Rows.Count > 1)
            {
                string smahdnhap = dataGridView_DanhSachHDNhap.SelectedRows[0].Cells[0].Value.ToString();
                string stennguoilaphd = dataGridView_DanhSachHDNhap.SelectedRows[0].Cells[1].Value.ToString();
                DateTime dngaylaphd = DateTime.Parse(dataGridView_DanhSachHDNhap.SelectedRows[0].Cells[2].Value.ToString());
                string fthanhtien = dataGridView_DanhSachHDNhap.SelectedRows[0].Cells[4].Value.ToString();
                tbltunghoadonnhap thd = new tbltunghoadonnhap(smahdnhap, fthanhtien, stennguoilaphd, dngaylaphd);
                thd.ShowDialog();
            }
        }

        // Hiện dữ liệu ra bảng 
        private void tbldanhsachhoadonnhap_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT tblHoaDonNhap.sMaHDNhap AS 'Mã HĐ Nhập', tblNhanVien.sHoTen AS 'Người Lập HĐ', dNgayNhap AS 'Ngày Nhập', " +
                               "COUNT(tblChiTietHoaDonNhap.iSoLuongNhap) AS 'Tổng Số Lượng Sách Nhập', SUM(tblChiTietHoaDonNhap.fThanhTien) AS 'Tổng Tiền' " +
                               "FROM tblChiTietHoaDonNhap " +
                               "INNER JOIN tblHoaDonNhap ON tblHoaDonNhap.sMaHDNhap = tblChiTietHoaDonNhap.sMaHDNhap " +
                               "INNER JOIN tblNhanVien ON tblHoaDonNhap.iMaNV = tblNhanVien.iMaNV " +
                               "GROUP BY tblHoaDonNhap.sMaHDNhap, tblNhanVien.sHoTen, dNgayNhap";

                DataTable dataTable = modify.Table(query);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    dataGridView_DanhSachHDNhap.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            DeleteTextBoxes();
        }

        private void DeleteTextBoxes()
        {
            sMaHDBan.Text = "";
            iMaNV.Text = "";
            date_BatDau.Text = "";
            date_KetThuc.Text = "";
        }

        // Xử lí sự kiện tìm kiếm theo mã hóa đơn bán
        private void sMaHDBan_TextChanged(object sender, EventArgs e)
        {
            string name = sMaHDBan.Text;
            if (name == "")
            {
                tbldanhsachhoadonnhap_Load(sender, e);
            }
            else
            {
                try
                {
                    string query = "select tblHoaDonNhap.sMaHDNhap AS N'Mã Hóa Đơn', tblNhanVien.sHoTen AS N'Tên Người Lập HĐ', dNgayNhap AS N'Ngày Nhập HĐ', COUNT(tblChiTietHoaDonNhap.iSoLuongNhap) AS N'Tổng Số Lượng Sách Nhập', SUM(tblChiTietHoaDonNhap.fThanhTien) AS N'Tổng Tiền' " +
                    "FROM tblChiTietHoaDonNhap inner join tblHoaDonNhap on tblHoaDonNhap.sMaHDNhap = tblChiTietHoaDonNhap.sMaHDNhap " +
                    "inner join tblNhanVien on tblHoaDonNhap.iMaNV = tblNhanVien.iMaNV " +
                    "WHERE tblHoaDonNhap.sMaHDNhap LIKE N'%" + name + "%' group by tblHoaDonNhap.sMaHDNhap, tblNhanVien.sHoTen, dNgayNhap";
                    DataTable dataTable = modify.Table(query);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        dataGridView_DanhSachHDNhap.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn nào với mã: " + name);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        // Xử lí sự kiện tìm kiếm theo tên người lập hóa đơn
        private void iMaNV_TextChanged(object sender, EventArgs e)
        {
            string name = iMaNV.Text;
            if (name == "")
            {
                tbldanhsachhoadonnhap_Load(sender, e);
            }
            else
            {
                try
                {
                    string query = "select tblHoaDonNhap.sMaHDNhap AS N'Mã Hóa Đơn', tblNhanVien.sHoTen AS N'Tên Người Lập HĐ', dNgayNhap AS N'Ngày Nhập HĐ', COUNT(tblChiTietHoaDonNhap.iSoLuongNhap) AS N'Tổng Số Lượng Sách Nhập', SUM(tblChiTietHoaDonNhap.fThanhTien) AS N'Tổng Tiền' " +
                    "FROM tblChiTietHoaDonNhap inner join tblHoaDonNhap on tblHoaDonNhap.sMaHDNhap = tblChiTietHoaDonNhap.sMaHDNhap " +
                    "inner join tblNhanVien on tblHoaDonNhap.iMaNV = tblNhanVien.iMaNV " +
                    "WHERE tblNhanVien.sHoTen LIKE N'%" + name + "%' group by tblHoaDonNhap.sMaHDNhap, tblNhanVien.sHoTen, dNgayNhap";
                    DataTable dataTable = modify.Table(query);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        dataGridView_DanhSachHDNhap.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn nào với tên: " + name);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        // Xử lí sự kiện tìm kiếm theo khoảng thời gian
        private void btnTimKienHoaDon_Click(object sender, EventArgs e)
        {
            DateTime dateTimebatdau = date_BatDau.Value;
            DateTime dateTimeketthuc = date_KetThuc.Value;
            try
            {
                string query = "select tblHoaDonNhap.sMaHDNhap AS N'Mã Hóa Đơn', tblNhanVien.sHoTen AS N'Tên Người Lập HĐ', dNgayNhap AS N'Ngày Nhập HĐ', COUNT(tblChiTietHoaDonNhap.iSoLuongNhap) AS N'Tổng Số Lượng Sách Nhập', SUM(tblChiTietHoaDonNhap.fThanhTien) AS N'Tổng Tiền' " +
                    "FROM tblChiTietHoaDonNhap inner join tblHoaDonNhap on tblHoaDonNhap.sMaHDNhap = tblChiTietHoaDonNhap.sMaHDNhap " +
                    "inner join tblNhanVien on tblHoaDonNhap.iMaNV = tblNhanVien.iMaNV " +
                    "WHERE dNgayNhap >= '" + dateTimebatdau + "' AND dNgayNhap <= '" + dateTimeketthuc + "' group by tblHoaDonNhap.sMaHDNhap, tblNhanVien.sHoTen, dNgayNhap";
                DataTable dataTable = modify.Table(query);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    dataGridView_DanhSachHDNhap.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn nào trong khoảng thời gian đã chọn.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
