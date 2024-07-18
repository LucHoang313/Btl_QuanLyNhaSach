using Btl_QuanLyNhaSach.Modify;
using Btl_QuanLyNhaSach.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Btl_QuanLyNhaSach
{
    public partial class tblhoadonban : Form
    {
        ModifyAll modify = new ModifyAll();
        HoaDonBan hoadonban;

        public tblhoadonban()
        {
            InitializeComponent();
            fillCombobox();
            fillComboBoxNhanVien();
        }

        private void tblhoadonban_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView_HDBan.DataSource = modify.Table("SELECT sMaHDBan AS 'Mã HĐ Bán', tblHoaDonBan.iMaNV, tblNhanVien.sHoTen AS 'Người lập hóa đơn', tblKhachHang.sTenKH AS 'Tên Khách Hàng', dNgayLap AS 'Ngày Lập' " +
                    "FROM tblHoaDonBan " +
                    "INNER JOIN tblNhanVien ON tblHoaDonBan.iMaNV = tblNhanVien.iMaNV " +
                    "INNER JOIN tblKhachHang ON tblHoaDonBan.sMaKH = tblKhachHang.sMaKH");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            DeleteTextBoxes();
        }

        private void dataGridView_HDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_HDBan.Rows.Count > 1)
            {
                sMaHDBan.Text = dataGridView_HDBan.SelectedRows[0].Cells[0].Value.ToString();
                comboBox_iMaNV.SelectedValue = dataGridView_HDBan.SelectedRows[0].Cells[1].Value.ToString(); // Sửa lại để hiển thị mã nhân viên
                comboBox_sTenKH.Text = dataGridView_HDBan.SelectedRows[0].Cells[3].Value.ToString();
                dNgayLap.Text = dataGridView_HDBan.SelectedRows[0].Cells[4].Value.ToString();
            }
        }

        private void DeleteTextBoxes()
        {
            sMaHDBan.Text = "";
            comboBox_iMaNV.SelectedIndex = -1;
            dNgayLap.Text = "";
        }

        private bool CheckText()
        {
            if (sMaHDBan.Text == "" || comboBox_iMaNV.SelectedIndex == -1)
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                return false;
            }

            return true;
        }

        private void GetValuesTextBox()
        {
            string smaHDBan = sMaHDBan.Text;
            int imaNV = int.Parse(comboBox_iMaNV.SelectedValue.ToString());
            string smaKh = comboBox_sTenKH.SelectedValue.ToString();
            DateTime dngayLap = DateTime.Parse(dNgayLap.Text);
            hoadonban = new HoaDonBan(smaHDBan, imaNV, smaKh, dngayLap);
        }

        private void btnXoaHDBan_Click(object sender, EventArgs e)
        {
            if (dataGridView_HDBan.Rows.Count > 1)
            {
                string choose = dataGridView_HDBan.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE tblHoaDonBan ";
                query += " WHERE sMaHDBan = '" + choose + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modify.Command(query);
                        MessageBox.Show("Bạn đã xóa 1 hóa đơn thành công!");
                        tblhoadonban_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        private void btnCapNhatHDBan_Click(object sender, EventArgs e)
        {
            if (CheckText())
            {
                GetValuesTextBox();
                string query = "UPDATE tblHoaDonBan SET sMaHDBan = '" + hoadonban.SMaHDBan + "', iMaNV = '" + hoadonban.imaNV + "'," +
                " sMaKH = '" + hoadonban.SMaKH + "', " +
                " dNgayLap = '" + hoadonban.DNgayLap + "' ";
                query += "WHERE sMaHDBan = '" + hoadonban.SMaHDBan + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn sửa lại dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modify.Command(query);
                        MessageBox.Show("Bạn đã sửa thông tin của hóa đơn thành công!");
                        tblhoadonban_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sửa: " + ex.Message);
                }
            }
        }

        private void btnThemHDBan_Click(object sender, EventArgs e)
        {
            if (CheckText())
            {
                GetValuesTextBox();
                string query = "INSERT INTO tblHoaDonBan values ('" + hoadonban.SMaHDBan + "', '" + hoadonban.imaNV + "', '" + hoadonban.SMaKH + "'," +
                " '" + hoadonban.DNgayLap + "' ) ";
                try
                {
                    if (MessageBox.Show("Bạn có muốn thêm vào không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modify.Command(query);
                        MessageBox.Show("Bạn đã thêm 1 hóa đơn thành công!");
                        tblhoadonban_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm: " + ex.Message);
                }
            }
        }

        public void fillCombobox()
        {
            string query = "SELECT * FROM tblKhachHang";
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = sqlCommand;
            DataTable table = new DataTable();
            adapter.Fill(table);
            comboBox_sTenKH.DataSource = table;
            comboBox_sTenKH.DisplayMember = "sTenKH";
            comboBox_sTenKH.ValueMember = "sMaKH";
            sqlConnection.Close();
        }

        public void fillComboBoxNhanVien()
        {
            string query = "SELECT iMaNV FROM tblNhanVien";
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = sqlCommand;
            DataTable table = new DataTable();
            adapter.Fill(table);
            comboBox_iMaNV.DataSource = table;
            comboBox_iMaNV.DisplayMember = "iMaNV";
            comboBox_iMaNV.ValueMember = "iMaNV";
            sqlConnection.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = "SELECT sMaHDBan AS 'Mã HĐ Bán', tblHoaDonBan.iMaNV, tblNhanVien.sHoTen AS 'Người lập hóa đơn', tblKhachHang.sTenKH AS 'Tên Khách Hàng', dNgayLap AS 'Ngày Lập' " +
                           "FROM tblHoaDonBan " +
                           "INNER JOIN tblNhanVien ON tblHoaDonBan.iMaNV = tblNhanVien.iMaNV " +
                           "INNER JOIN tblKhachHang ON tblHoaDonBan.sMaKH = tblKhachHang.sMaKH " +
                           "WHERE 1=1";

            if (!string.IsNullOrEmpty(sMaHDBan.Text))
            {
                query += " AND sMaHDBan LIKE '%" + sMaHDBan.Text + "%'";
            }

            if (comboBox_iMaNV.SelectedIndex != -1)
            {
                query += " AND tblHoaDonBan.iMaNV = " + comboBox_iMaNV.SelectedValue;
            }

            if (!string.IsNullOrEmpty(comboBox_sTenKH.Text))
            {
                query += " AND tblKhachHang.sTenKH LIKE N'%" + comboBox_sTenKH.Text + "%'";
            }

            // Kiểm tra và thêm điều kiện tìm kiếm theo Ngày Lập
         //   if (!string.IsNullOrEmpty(dNgayLap.Text))
         //   {
                // Convert ngày tháng từ DateTimePicker thành định dạng phù hợp với SQL Server
         //       string formattedDate = dNgayLap.Value.ToString("yyyy-MM-dd");

                // Thêm điều kiện vào câu truy vấn
         //       query += " AND CONVERT(date, dNgayLap) = '" + formattedDate + "'";
         //   }

            try
            {
                dataGridView_HDBan.DataSource = modify.Table(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }



        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            ClearTextBoxesAndComboBox(this);

            tblhoadonban_Load(sender, e);
        }

        private void ClearTextBoxesAndComboBox(Control container)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Clear();
                }
                else if (ctrl is ComboBox)
                {
                    ((ComboBox)ctrl).SelectedIndex = -1;
                    ((ComboBox)ctrl).Text = string.Empty;
                }

                // If the container has nested controls, call the method recursively
                if (ctrl.HasChildren)
                {
                    ClearTextBoxesAndComboBox(ctrl);
                }
            }
        }


    }
}