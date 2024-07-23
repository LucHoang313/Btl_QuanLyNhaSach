using Btl_QuanLyNhaSach.Modify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Btl_QuanLyNhaSach
{
    public partial class tbldanhsachhoadonban : Form
    {
        ModifyAll modify = new ModifyAll();

        public tbldanhsachhoadonban()
        {
            InitializeComponent();
        }

        // Sử lí sự kiện tìm kiếm danh sách hóa đơn theo tên
        private void iMaNV_TextChanged(object sender, EventArgs e)
        {
            string name = iMaNV.Text;
            if (name == "")
            {
                danhsachhoadonban_Load(sender, e);
            }
            else
            {
                string query = "SELECT tblHoaDonBan.sMaHDBan AS N'Mã Hóa Đơn', tblHoaDonBan.iMaNV AS N'Mã Nhân Viên', tblNhanVien.sHoTen AS N'Người lập hóa đơn', tblKhachHang.sTenKH AS N'Tên Khách Hàng', dNgayLap AS N'Ngày Lập', COUNT(tblChiTietHoaDonBan.iSoLuongBan) AS N'Tổng Số Lượng Sách Bán', SUM(tblChiTietHoaDonBan.fThanhTien) AS N'Tổng Tiền' " +
                               "FROM tblChiTietHoaDonBan " +
                               "INNER JOIN tblHoaDonBan ON tblHoaDonBan.sMaHDBan = tblChiTietHoaDonBan.sMaHDBan " +
                               "INNER JOIN tblKhachHang ON tblHoaDonBan.sMaKH = tblKhachHang.sMaKH " +
                               "INNER JOIN tblNhanVien ON tblHoaDonBan.iMaNV = tblNhanVien.iMaNV " +
                               "WHERE tblHoaDonBan.iMaNV LIKE N'%" + name + "%' " +
                               "GROUP BY tblHoaDonBan.sMaHDBan, tblHoaDonBan.iMaNV, tblNhanVien.sHoTen, tblKhachHang.sTenKH, dNgayLap";
                dataGridView_DanhSachHDBan.DataSource = modify.Table(query);
            }
        }

        // Sử lí sự kiện click danh sách ra datagridview
        private void dataGridView_DanhSachHDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_DanhSachHDBan.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_DanhSachHDBan.SelectedRows[0];
                string smahdban = selectedRow.Cells["Mã Hóa Đơn"].Value.ToString();
                string stenkh = selectedRow.Cells["Tên Khách Hàng"].Value.ToString();
                string stennguoilaphd = selectedRow.Cells["Người lập hóa đơn"].Value.ToString();
                DateTime dngaylaphd = DateTime.Parse(selectedRow.Cells["Ngày Lập"].Value.ToString());
                string fthanhtien = selectedRow.Cells["Tổng Tiền"].Value.ToString();

                tbltunghoadonban thd = new tbltunghoadonban(smahdban, stenkh, fthanhtien, stennguoilaphd, dngaylaphd);
                thd.ShowDialog();
            }
        }

        // Sử lí sự kiện tìm kiếm theo mã hóa đơn bán
        private void sMaHDBan_TextChanged(object sender, EventArgs e)
        {
            string name = sMaHDBan.Text;
            if (name == "")
            {
                danhsachhoadonban_Load(sender, e);
            }
            else
            {
                string query = "SELECT tblHoaDonBan.sMaHDBan AS N'Mã Hóa Đơn', tblHoaDonBan.iMaNV AS N'Mã Nhân Viên', tblNhanVien.sHoTen AS N'Người lập hóa đơn', tblKhachHang.sTenKH AS N'Tên Khách Hàng', dNgayLap AS N'Ngày Lập', COUNT(tblChiTietHoaDonBan.iSoLuongBan) AS N'Tổng Số Lượng Sách Bán', SUM(tblChiTietHoaDonBan.fThanhTien) AS N'Tổng Tiền' " +
                               "FROM tblChiTietHoaDonBan " +
                               "INNER JOIN tblHoaDonBan ON tblHoaDonBan.sMaHDBan = tblChiTietHoaDonBan.sMaHDBan " +
                               "INNER JOIN tblKhachHang ON tblHoaDonBan.sMaKH = tblKhachHang.sMaKH " +
                               "INNER JOIN tblNhanVien ON tblHoaDonBan.iMaNV = tblNhanVien.iMaNV " +
                               "WHERE tblHoaDonBan.sMaHDBan LIKE N'%" + name + "%' " +
                               "GROUP BY tblHoaDonBan.sMaHDBan, tblHoaDonBan.iMaNV, tblNhanVien.sHoTen, tblKhachHang.sTenKH, dNgayLap";
                dataGridView_DanhSachHDBan.DataSource = modify.Table(query);
            }
        }

        private void DeleteTextBoxes()
        {
            sMaHDBan.Text = "";
            iMaNV.Text = "";
            date_BatDau.Text = "";
            date_KetThuc.Text = "";
        }

        // Sử lí sự kiện đổ danh sách ra datagridview
        private void danhsachhoadonban_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT tblHoaDonBan.sMaHDBan AS 'Mã Hóa Đơn', " +
                               "tblHoaDonBan.iMaNV AS 'Mã Nhân Viên', " +
                               "tblNhanVien.sHoTen AS 'Người lập hóa đơn', " +
                               "tblKhachHang.sTenKH AS 'Tên Khách Hàng', " +
                               "dNgayLap AS 'Ngày Lập', " +
                               "COUNT(tblChiTietHoaDonBan.iSoLuongBan) AS 'Tổng Số Lượng Sách Bán', " +
                               "SUM(tblChiTietHoaDonBan.fThanhTien) AS 'Tổng Tiền' " +
                               "FROM tblChiTietHoaDonBan " +
                               "INNER JOIN tblHoaDonBan ON tblHoaDonBan.sMaHDBan = tblChiTietHoaDonBan.sMaHDBan " +
                               "INNER JOIN tblKhachHang ON tblHoaDonBan.sMaKH = tblKhachHang.sMaKH " +
                               "INNER JOIN tblNhanVien ON tblHoaDonBan.iMaNV = tblNhanVien.iMaNV " +
                               "GROUP BY tblHoaDonBan.sMaHDBan, tblHoaDonBan.iMaNV, tblNhanVien.sHoTen, tblKhachHang.sTenKH, dNgayLap";

                dataGridView_DanhSachHDBan.DataSource = modify.Table(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            DeleteTextBoxes();
        }

        // Sử lí sự kiện theo ngày
        private void btnTimKienHoaDon_Click(object sender, EventArgs e)
        {
            DateTime dateTimebatdau = date_BatDau.Value;
            DateTime dateTimeketthuc = date_KetThuc.Value;
            string query = "SELECT tblHoaDonBan.sMaHDBan AS N'Mã Hóa Đơn', tblHoaDonBan.iMaNV AS N'Mã Nhân Viên', tblNhanVien.sHoTen AS N'Người lập hóa đơn', tblKhachHang.sTenKH AS N'Tên Khách Hàng', dNgayLap AS N'Ngày Lập', COUNT(tblChiTietHoaDonBan.iSoLuongBan) AS N'Tổng Số Lượng Sách Bán', SUM(tblChiTietHoaDonBan.fThanhTien) AS N'Tổng Tiền' " +
                           "FROM tblChiTietHoaDonBan " +
                           "INNER JOIN tblHoaDonBan ON tblHoaDonBan.sMaHDBan = tblChiTietHoaDonBan.sMaHDBan " +
                           "INNER JOIN tblKhachHang ON tblHoaDonBan.sMaKH = tblKhachHang.sMaKH " +
                           "INNER JOIN tblNhanVien ON tblHoaDonBan.iMaNV = tblNhanVien.iMaNV " +
                           "WHERE dNgayLap >= '" + dateTimebatdau + "' AND dNgayLap <= '" + dateTimeketthuc + "' " +
                           "GROUP BY tblHoaDonBan.sMaHDBan, tblHoaDonBan.iMaNV, tblNhanVien.sHoTen, tblKhachHang.sTenKH, dNgayLap";
            dataGridView_DanhSachHDBan.DataSource = modify.Table(query);
        }
    }
}
