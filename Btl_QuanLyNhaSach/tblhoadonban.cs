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
        }

        // Sử lí sự kiện đổ dữ liệu từ sql vào datagridview
        private void tblhoadonban_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView_HDBan.DataSource = modify.Table("SELECT sMaHDBan AS 'Mã HĐ Bán', tblNhanVien.sHoTen AS 'Người lập hóa đơn', tblKhachHang.sTenKH AS 'Tên Khách Hàng', dNgayLap AS 'Ngày Lập' " +
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

        // Sử lí sự kiện xóa hết các kí tự trong các ô
        private void DeleteTextBoxes()
        {
            sMaHDBan.Text = "";
            iMaNV.Text = "";
            dNgayLap.Text = "";
        }

        // Sử lí sự kiện nhập không được để trống
        private bool CheckText()
        {
            if (sMaHDBan.Text == "" || iMaNV.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                return false;
            }

            return true;
        }

        // Sử lí thêm dữ liệu vào đối tượng hóa đơn bán
        private void GetValuesTextBox()
        {
            string smaHDBan = sMaHDBan.Text;
            int imaNV = int.Parse(iMaNV.Text);
            // Lấy giá trị mã khách hàng tương ứng
            string smaKh = comboBox_sTenKH.SelectedValue.ToString();
            DateTime dngayLap = DateTime.Parse(dNgayLap.Text);
            hoadonban = new HoaDonBan(smaHDBan, imaNV, smaKh, dngayLap);
        }

        // Sử lí sự kiện xóa hóa đơn
        private void btnXoaHDBan_Click(object sender, EventArgs e)
        {
            // Check lớn hơn 1 dòng
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

        // Sử lí sự kiện cập nhật hóa đơn
        private void btnCapNhatHDBan_Click(object sender, EventArgs e)
        {
            if (CheckText())
            {
                GetValuesTextBox();
                string query = "UPDATE tblHoaDonBan SET sMaHDBan = '" + hoadonban.SMaHDBan + "', iMaNV = '" + hoadonban.iMaNV + "'," +
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

        // Sử lí sự kiện thêm hóa đơn
        private void btnThemHDBan_Click(object sender, EventArgs e)
        {
            if (CheckText())
            {
                GetValuesTextBox();
                string query = "INSERT INTO tblHoaDonBan values ('" + hoadonban.SMaHDBan + "', '" + hoadonban.iMaNV + "', '" + hoadonban.SMaKH + "'," +
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

        // Sử lí sự click vào item trong datagridview
        private void dataGridView_HDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_HDBan.Rows.Count > 1)
            {
                sMaHDBan.Text = dataGridView_HDBan.SelectedRows[0].Cells[0].Value.ToString();
                iMaNV.Text = dataGridView_HDBan.SelectedRows[0].Cells[1].Value.ToString();
                comboBox_sTenKH.Text = dataGridView_HDBan.SelectedRows[0].Cells[2].Value.ToString();
                dNgayLap.Text = dataGridView_HDBan.SelectedRows[0].Cells[3].Value.ToString();
            }
        }



        // Sử lí sự kiện đổ dữ liệu vào combobox
        public void fillCombobox()
        {
            // Đổ dữ liệu vào combobox
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = "SELECT sMaHDBan AS 'Mã HĐ Bán', tblNhanVien.sHoTen AS 'Người lập hóa đơn', tblKhachHang.sTenKH AS 'Tên Khách Hàng', dNgayLap AS 'Ngày Lập' " +
                   "FROM tblHoaDonBan " +
                   "INNER JOIN tblNhanVien ON tblHoaDonBan.iMaNV = tblNhanVien.iMaNV " +
                   "INNER JOIN tblKhachHang ON tblHoaDonBan.sMaKH = tblKhachHang.sMaKH " +
                   "WHERE 1=1";

            if (!string.IsNullOrEmpty(sMaHDBan.Text))
            {
                query += " AND sMaHDBan LIKE '%" + sMaHDBan.Text + "%'";
            }

            if (!string.IsNullOrEmpty(iMaNV.Text))
            {
                query += " AND iMaNv LIKE N'%" + iMaNV.Text + "%'";
            }

            if (!string.IsNullOrEmpty(comboBox_sTenKH.Text))
            {
                query += " AND sTenKH LIKE '%" + comboBox_sTenKH.Text + "%'";
            }

            if (!string.IsNullOrEmpty(dNgayLap.Text))
            {
                query += " AND dNgayLap LIKE N'%" + dNgayLap.Text + "%'";
            }

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
