using Btl_QuanLyNhaSach.Modify;
using Btl_QuanLyNhaSach.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Btl_QuanLyNhaSach
{
    public partial class tblchitiethoadonban : Form
    {
        ModifyAll modify = new ModifyAll();
        ChiTietHoaDonBan chiTietHoaDonBan;

        public tblchitiethoadonban()
        {
            InitializeComponent();
            LoadComboBoxData();

        }

        private void LoadComboBoxData()
        {
            try
            {
                using (SqlConnection con = Connection.GetSqlConnection())
                {
                    con.Open();

                    // Load data for comboBox_iMaNV
                    string sqlNV = "SELECT iMaNV, sHoTen FROM tblNhanVien";
                    SqlCommand cmdNV = new SqlCommand(sqlNV, con);
                    SqlDataReader readerNV = cmdNV.ExecuteReader();
                    DataTable dtNV = new DataTable();
                    dtNV.Load(readerNV);
                    comboBox_iMaNV.DataSource = dtNV;
                    comboBox_iMaNV.DisplayMember = "iMaNV";
                    comboBox_iMaNV.ValueMember = "iMaNV";

                    // Load data for comboBox_sMaKH
                    string sqlKH = "SELECT sMaKH, sTenKH FROM tblKhachHang";
                    SqlCommand cmdKH = new SqlCommand(sqlKH, con);
                    SqlDataReader readerKH = cmdKH.ExecuteReader();
                    DataTable dtKH = new DataTable();
                    dtKH.Load(readerKH);
                    comboBox_sMaKH.DataSource = dtKH;
                    comboBox_sMaKH.DisplayMember = "sTenKH";
                    comboBox_sMaKH.ValueMember = "sMaKH";

                    //Load data for comboBox_sMaHDBan
                    string sqlHDBan = "SELECT sMaHDBan FROM tblHoaDonBan";
                    SqlCommand cmdHDBan = new SqlCommand(sqlHDBan, con);
                    SqlDataReader readerHDBan = cmdHDBan.ExecuteReader();
                    DataTable dtHDBan = new DataTable();
                    dtHDBan.Load(readerHDBan);
                    comboBox_sMaHDBan.DataSource = dtHDBan;
                    comboBox_sMaHDBan.DisplayMember = "sMaHDBan";
                    comboBox_sMaHDBan.ValueMember = "sMaHDBan";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void btnTimKienHoaDon_Click(object sender, EventArgs e)
        {
            // Khởi tạo câu truy vấn SQL cơ bản
            string query = "SELECT c.iID, c.sMaHDBan AS N'Mã HĐ Bán', c.sMaSach AS N'Mã Sách', c.sTenSach AS N'Tên Sách', c.iSoLuongBan AS N'Số Lượng Bán', c.fGiaSach AS N'Giá Sách', c.fThanhTien AS N'Thành Tiền', " +
                           "h.iMaNV AS N'Mã Nhân Viên', nv.sHoTen AS N'Tên Nhân Viên', h.sMaKH AS N'Mã Khách Hàng', kh.sTenKH AS N'Tên Khách Hàng' " +
                           "FROM tblChiTietHoaDonBan c " +
                           "INNER JOIN tblHoaDonBan h ON c.sMaHDBan = h.sMaHDBan " +
                           "INNER JOIN tblNhanVien nv ON h.iMaNV = nv.iMaNV " +
                           "INNER JOIN tblKhachHang kh ON h.sMaKH = kh.sMaKH " +
                           "WHERE 1=1"; // Điều kiện cơ bản để dễ dàng thêm điều kiện khác

            // Thêm điều kiện tìm kiếm theo mã hóa đơn bán nếu có
            if (!string.IsNullOrEmpty(comboBox_sMaHDBan.Text))
            {
                query += " AND c.sMaHDBan = '" + comboBox_sMaHDBan.SelectedValue.ToString() + "'";
            }

            // Thêm điều kiện tìm kiếm theo mã khách hàng nếu có
            if (comboBox_sMaKH.SelectedIndex != -1)
            {
                query += " AND h.sMaKH = '" + comboBox_sMaKH.SelectedValue.ToString() + "'";
            }

            // Thêm điều kiện tìm kiếm theo mã nhân viên nếu có
            if (comboBox_iMaNV.SelectedIndex != -1)
            {
                query += " AND h.iMaNV = " + comboBox_iMaNV.SelectedValue.ToString();
            }

            // Thực hiện truy vấn và gán dữ liệu vào DataGridView
            try
            {
                dataGridView_ChiTietHDBan.DataSource = modify.Table(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        // Sử lí sự kiện xóa hết các kí tự trong các ô
        private void DeleteTextBoxes()
        {
            text_id.Text = "";
            sMaSach.Text = "";
            sTenSach.Text = "";
            fGiaSach.Text = "";
            iSoLuong.Text = "";
            fThanhTien.Text = "";
            comboBox_iMaNV.Text = "";
            comboBox_sMaKH.Text = "";
            comboBox_sMaHDBan.Text = "";
        }

        // Sử lí sự kiện nhập không được để trống
        private bool CheckText()
        {
            if (sMaSach.Text == "" || sTenSach.Text == "" || fGiaSach.Text == "" || iSoLuong.Text == "" || fThanhTien.Text == "" || text_id.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                return false;
            }

            return true;
        }

        // Sử lí thêm dữ liệu vào đối tượng hóa đơn bán
        private void GetValuesTextBox()
        {
            int iiD = int.Parse(text_id.Text);
            string smahdBan = comboBox_sMaHDBan.SelectedValue.ToString();
            string smasach = sMaSach.Text;
            string stenSach = sTenSach.Text;
            int isoLuongBan = int.Parse(iSoLuong.Text);
            float fgiaSach = float.Parse(fGiaSach.Text);
            float fthanhTien = float.Parse(fThanhTien.Text);
            chiTietHoaDonBan = new ChiTietHoaDonBan(iiD, smahdBan, smasach, stenSach, isoLuongBan, fgiaSach, fthanhTien);
        }

        // Sử lí sự kiện nhập vào textbox số lượng chỉ nhận số không nhận kí tự chữ
        private void iSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sử lí sự kiện chỉ được nhập số
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        // Sử lí sự kiện đổ dữ liệu từ sql vào datagridview
        private void tblchitiethoadonban_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView_ChiTietHDBan.DataSource = modify.Table(
                    "SELECT c.iID, c.sMaHDBan AS N'Mã HĐ Bán', c.sMaSach AS N'Mã Sách', c.sTenSach AS N'Tên Sách', c.iSoLuongBan AS N'Số Lượng Bán', c.fGiaSach AS N'Giá Sách', c.fThanhTien AS N'Thành Tiền', " +
                    "h.iMaNV AS N'Mã Nhân Viên', nv.sHoTen AS N'Tên Nhân Viên', h.sMaKH AS N'Mã Khách Hàng', kh.sTenKH AS N'Tên Khách Hàng' " +
                    "FROM tblChiTietHoaDonBan c " +
                    "INNER JOIN tblHoaDonBan h ON c.sMaHDBan = h.sMaHDBan " +
                    "INNER JOIN tblNhanVien nv ON h.iMaNV = nv.iMaNV " +
                    "INNER JOIN tblKhachHang kh ON h.sMaKH = kh.sMaKH");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            DeleteTextBoxes();
            LoadComboBoxData();
            LoadComboBoxData();
        }


        private void LoadData()
        {
            string query = "SELECT * FROM tblChiTietHoaDonBan";
            using (SqlConnection con = Connection.GetSqlConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView_ChiTietHDBan.DataSource = dt;
            }
        }


        // Sử lí sự click vào item trong datagridview
        private void dataGridView_ChiTietHDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_ChiTietHDBan.Rows[e.RowIndex];
                text_id.Text = row.Cells["iID"].Value.ToString();
                comboBox_sMaHDBan.SelectedValue = row.Cells["Mã HĐ Bán"].Value.ToString();
                sMaSach.Text = row.Cells["Mã Sách"].Value.ToString();
                sTenSach.Text = row.Cells["Tên Sách"].Value.ToString();
                iSoLuong.Text = row.Cells["Số Lượng Bán"].Value.ToString();
                fGiaSach.Text = row.Cells["Giá Sách"].Value.ToString();
                fThanhTien.Text = row.Cells["Thành Tiền"].Value.ToString();
                comboBox_iMaNV.SelectedValue = row.Cells["Mã Nhân Viên"].Value.ToString();
                comboBox_sMaKH.SelectedValue = row.Cells["Mã Khách Hàng"].Value.ToString();
            }
        }







        // Sử lí sự kiện khi nhập mã sách thì hiện tên sách
        private void sMaSach_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = Connection.GetSqlConnection();
            string sql = "SELECT * FROM tblSach WHERE sMaSach" +
                "    = '" + sMaSach.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myreader; try
            {
                con.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    sTenSach.Text = myreader.GetString(1);
                    Double a = myreader.GetDouble(2);
                    fGiaSach.Text = a.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Sử lí sự kiện thêm 
        private void btnThemHDBan_Click(object sender, EventArgs e)
        {
            if (comboBox_sMaHDBan.Text == "")
            {
                MessageBox.Show("Mời bạn nhập mã hóa đơn bán!");
                return ;
            }
            else
            {
                if (CheckText())
                {
                    GetValuesTextBox();
                    string query = "INSERT INTO tblChiTietHoaDonBan values ('" + chiTietHoaDonBan.IID + "', N'" + chiTietHoaDonBan.SMaHDBan + "', N'" + chiTietHoaDonBan.SMaSach + "'," +
                        " N'" + chiTietHoaDonBan.STenSach + "', '" + chiTietHoaDonBan.ISoLuongBan + "', '" + chiTietHoaDonBan.FGiaSach + "'," +
                        " '" + chiTietHoaDonBan.FThanhTien + "' ) ";
                    try
                    {
                        if (MessageBox.Show("Bạn có muốn thêm vào không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            modify.Command(query);
                            MessageBox.Show("Bạn đã thêm 1 sản phẩm của hóa đơn " + chiTietHoaDonBan.SMaHDBan + " thành công!");
                            tblchitiethoadonban_Load(sender, e);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi thêm: " + ex.Message);
                    }
                }
            }
        }

        // Sử lí sự kiện ô số lượng
        private void iSoLuong_TextChanged(object sender, EventArgs e)
        {
            int soLuong = 0;
            bool isValidSoLuong = int.TryParse(iSoLuong.Text.Trim(), out soLuong);

            if (isValidSoLuong)
            {
                SqlConnection con = Connection.GetSqlConnection();
                string sql = "SELECT iSoLuong FROM tblSach WHERE sMaSach = @maSach";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@maSach", sMaSach.Text);

                try
                {
                    con.Open();
                    int soLuongTrongKho = (int)cmd.ExecuteScalar();

                    if (soLuong > soLuongTrongKho)
                    {
                        MessageBox.Show("Số lượng sách trong kho không đủ!", "Thông báo");
                        iSoLuong.Clear();
                    }
                    else
                    {
                        fThanhTien.Text = (float.Parse(iSoLuong.Text) *
                        float.Parse(fGiaSach.Text)).ToString();
                    }    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                }
                finally
                {
                    con.Close();
                }
            }
        }

        // Sử lí sự kiện cập nhật dữ liệu
        private void btnCapNhatHDBan_Click(object sender, EventArgs e)
        {
            if (comboBox_sMaHDBan.Text == "")
            {
                MessageBox.Show("Mời bạn nhập mã hóa đơn bán!");
                return;
            }
            else
            {
                if (CheckText())
                {
                    GetValuesTextBox();
                    string query = "UPDATE tblChiTietHoaDonBan SET iID = '" + chiTietHoaDonBan.IID + "', sMaHDBan = '" + chiTietHoaDonBan.SMaHDBan + "'," +
                    " sMaSach = '" + chiTietHoaDonBan.SMaSach + "', sTenSach = N'" + chiTietHoaDonBan.STenSach + "', iSoLuongBan = '" + chiTietHoaDonBan.ISoLuongBan + "'," +
                    " fGiaSach = '" + chiTietHoaDonBan.FGiaSach + "',fThanhTien = '" + chiTietHoaDonBan.FThanhTien + "'";
                    query += "WHERE iID = '" + chiTietHoaDonBan.IID + "'";
                    try
                    {
                        if (MessageBox.Show("Bạn có muốn sửa lại dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            modify.Command(query);
                            MessageBox.Show("Bạn đã sửa thông tin của sản phẩm trong hóa đơn thành công!");
                            tblchitiethoadonban_Load(sender, e);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi sửa: " + ex.Message);
                    }
                }
            }
        }

        // Sử lí sự kiện xóa dữ liệu
        private void btnXoaHDBan_Click(object sender, EventArgs e)
        {
            // Check lớn hơn 1 dòng
            if (dataGridView_ChiTietHDBan.Rows.Count > 1)
            {
                string choose = dataGridView_ChiTietHDBan.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE tblChiTietHoaDonBan ";
                query += " WHERE iID = '" + choose + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modify.Command(query);
                        MessageBox.Show("Bạn đã xóa 1 sản phẩm trong hóa đơn bán thành công!");
                        tblchitiethoadonban_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            tblchitiethoadonban_Load(sender,e);
            DeleteTextBoxes();
        }
    }
}
