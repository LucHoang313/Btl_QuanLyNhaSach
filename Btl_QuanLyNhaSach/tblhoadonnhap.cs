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
    public partial class tblhoadonnhap : Form
    {
        ModifyAll modify = new ModifyAll();
        HoaDonNhap hoadonnhap;
        private string iMaNV;

        public tblhoadonnhap()
        {
            InitializeComponent();
            fillcombobox();
        }

        // Sử lí sự kiện xóa hết các kí tự trong các ô
        private void DeleteTextBoxes()
        {
            sMaHDNhap.Text = "";
            comboBox_iMaNV.Text = "";
            dNgayNhap.Text = "";
        }

        // Sử lí sự kiện nhập không được để trống
        private bool CheckText()
        {
            if (sMaHDNhap.Text == "" || comboBox_iMaNV.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                return false;
            }

            return true;
        }

        // Sử lí thêm dữ liệu vào đối tượng hóa đơn bán
        private void GetValuesTextBox()
        {
            string smaHDNhap = sMaHDNhap.Text;
            int imaNV = int.Parse(comboBox_iMaNV.SelectedValue.ToString());
            DateTime dngayNhap = DateTime.Parse(dNgayNhap.Text);
            hoadonnhap = new HoaDonNhap(smaHDNhap, iMaNV, dngayNhap);
        }

        // Sử lị sự kiện cập nhật hóa đơn nhập
        private void btnCapNhatHDNhap_Click(object sender, EventArgs e)
        {
            if (CheckText())
            {
                GetValuesTextBox();
                string query = "UPDATE tblHoaDonNhap SET iMaNV = @iMaNV, dNgayNhap = @dNgayNhap WHERE sMaHDNhap = @sMaHDNhap";
                try
                {
                    if (MessageBox.Show("Bạn có muốn sửa lại dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        SqlConnection connection = Connection.GetSqlConnection();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@sMaHDNhap", hoadonnhap.SMaHDNhap);
                        command.Parameters.AddWithValue("@iMaNV", hoadonnhap.IMaNV);
                        command.Parameters.AddWithValue("@dNgayNhap", hoadonnhap.DNgayNhap);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Bạn đã sửa thông tin của hóa đơn thành công!");
                        tblhoadonnhap_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sửa: " + ex.Message);
                }
            }
        }

        // Sử lí sự kiện thêm hóa đơn
        private void btnThemHDNhap_Click(object sender, EventArgs e)
        {
            if (CheckText())
            {
                GetValuesTextBox();
                string query = "INSERT INTO tblHoaDonNhap (sMaHDNhap, iMaNV, dNgayNhap) VALUES (@sMaHDNhap, @iMaNV, @dNgayNhap)";
                try
                {
                    if (MessageBox.Show("Bạn có muốn thêm vào không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        SqlConnection connection = Connection.GetSqlConnection();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@sMaHDNhap", hoadonnhap.SMaHDNhap);
                        command.Parameters.AddWithValue("@iMaNV", hoadonnhap.IMaNV);
                        command.Parameters.AddWithValue("@dNgayNhap", hoadonnhap.DNgayNhap);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Bạn đã thêm 1 hóa đơn thành công!");
                        tblhoadonnhap_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm: " + ex.Message);
                }
            }
        }

        // Sử lí sự kiện xóa hóa đơn
        private void btnXoaHDNhap_Click(object sender, EventArgs e)
        {
            // Check lớn hơn 1 dòng
            if (dataGridView_HDNhap.Rows.Count > 1)
            {
                string choose = dataGridView_HDNhap.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE tblHoaDonNhap ";
                query += " WHERE sMaHDNhap = '" + choose + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modify.Command(query);
                        MessageBox.Show("Bạn đã xóa 1 hóa đơn thành công!");
                        tblhoadonnhap_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        // Sử lí sự click vào item trong datagridview
        // Sử lí sự click vào item trong datagridview
        private void dataGridView_HDNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView_HDNhap.Rows.Count - 1)
            {
                sMaHDNhap.Text = dataGridView_HDNhap.Rows[e.RowIndex].Cells[0].Value.ToString();
                comboBox_iMaNV.SelectedValue = dataGridView_HDNhap.Rows[e.RowIndex].Cells[1].Value.ToString(); // Sửa lại để hiển thị mã nhân viên
                dNgayNhap.Text = dataGridView_HDNhap.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }


        // Sử lí sự kiện đổ dữ liệu từ sql vào datagridview
        private void tblhoadonnhap_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT sMaHDNhap AS 'Mã HĐ Nhập', tblHoaDonNhap.iMaNV AS 'Mã Nhân Viên', tblNhanVien.sHoTen AS 'Người Lập HĐ', dNgayNhap AS 'Ngày Nhập' " +
                               "FROM tblHoaDonNhap " +
                               "INNER JOIN tblNhanVien ON tblHoaDonNhap.iMaNV = tblNhanVien.iMaNV";

                dataGridView_HDNhap.DataSource = modify.Table(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            DeleteTextBoxes();
        }

        // Xử lý sự kiện đổ dữ liệu vào combobox
        public void fillcombobox()
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
            string query = "SELECT sMaHDNhap AS 'Mã HĐ Nhập', tblHoaDonNhap.iMaNV AS 'Mã Nhân Viên', tblNhanVien.sHoTen AS 'Người Lập HĐ', dNgayNhap AS 'Ngày Nhập' " +
                           "FROM tblHoaDonNhap " +
                           "INNER JOIN tblNhanVien ON tblHoaDonNhap.iMaNV = tblNhanVien.iMaNV " +
                           "WHERE 1=1";

            if (!string.IsNullOrEmpty(sMaHDNhap.Text))
            {
                query += " AND sMaHDNhap LIKE '%" + sMaHDNhap.Text + "%'";
            }

            if (comboBox_iMaNV.SelectedIndex != -1)
            {
                query += " AND tblHoaDonNhap.iMaNV = " + comboBox_iMaNV.SelectedValue;
            }

            // Uncomment and modify this block if you need to filter by date
            // if (!string.IsNullOrEmpty(dNgayNhap.Text))
            // {
            //     DateTime selectedDate = DateTime.Parse(dNgayNhap.Text);
            //     string formattedDate = selectedDate.ToString("yyyy-MM-dd");
            //     query += " AND CONVERT(date, dNgayNhap) = '" + formattedDate + "'";
            // }

            try
            {
                dataGridView_HDNhap.DataSource = modify.Table(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }


        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            ClearTextBoxesAndComboBox(this);

            tblhoadonnhap_Load(sender, e);
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
