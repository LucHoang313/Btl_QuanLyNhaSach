using Btl_QuanLyNhaSach.CrystalReport;
using Btl_QuanLyNhaSach.Modify;
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
    public partial class tblNhaXuatBan : Form
    {
        ModifyAll modifyNXB = new ModifyAll();
        public tblNhaXuatBan()
        {
            InitializeComponent();
        }

        private void tblNhaXuatBan_Load(object sender, EventArgs e)
        {
            dataGridView_NXB.DataSource = modifyNXB.Table("Select sMaNXB as 'Mã Nhà Xuất Bản' , sTenNXB as 'Tên Nhà Xuất Bản' , sDiaChi as 'Địa Chỉ' from tblNhaXuatBan");
        }


        private bool CheckText()
        {
            if (txtMaNXB.Text == "" || txtTenNXB.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                return false;
            }

            return true;
        }

        private void btnThemNXB_Click(object sender, EventArgs e)
        {
            if (CheckText())
            {
                SqlConnection conn = Connection.GetSqlConnection();
                string sql = "SELECT sMaNXB FROM  tblNhaXuatBan WHERE sMaNXB = '" + txtMaNXB.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                string sMaNXB = (string)cmd.ExecuteScalar();
                if (sMaNXB != null)
                {
                    MessageBox.Show("Mã Nhà Xuất Bản Đã Tồn Tại!");
                    return;
                }

                string query = "INSERT INTO tblNhaXuatBan values('" + txtMaNXB.Text + "',N'" + txtTenNXB.Text + "',N'" + txtDiaChi.Text + "')";
                modifyNXB.Command(query);
                MessageBox.Show("Bạn đã thêm thành công Nhà Xuất Bản");
                tblNhaXuatBan_Load(sender, e);

            }
        }

        private void dataGridView_NXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNXB.Text = dataGridView_NXB.SelectedRows[0].Cells[0].Value.ToString();
            txtTenNXB.Text = dataGridView_NXB.SelectedRows[0].Cells[1].Value.ToString();
            txtDiaChi.Text = dataGridView_NXB.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void btnUpdateNXB_Click(object sender, EventArgs e)
        {
            if (CheckText())
            {
                string query = "UPDATE tblNhaXuatBan set " + "sMaNXB = '" + txtMaNXB.Text + "', sTenNXB = N'" + txtTenNXB.Text + "' , " + "sDiaChi = N'" + txtDiaChi.Text + "'WHERE sMaNXB = '" + txtMaNXB.Text + "'";
                modifyNXB.Command(query);
                MessageBox.Show("Bạn đã cập nhật thành công nhà xuất bản");
                tblNhaXuatBan_Load(sender, e);

            }
        }

        private void btnXoaNXB_Click(object sender, EventArgs e)
        {
            string query = "DELETE tblNhaXuatBan WHERE sMaNXB = '" + txtMaNXB.Text + "'";
            modifyNXB.Command(query);
            MessageBox.Show("Bạn đã xóa thành công Nhà Xuất Bản!");
            xoaNXB();
            tblNhaXuatBan_Load(sender, e);
        }
        private void xoaNXB()
        {
            txtMaNXB.Text = "";
            txtTenNXB.Text = "";
            txtDiaChi.Text = "";

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = "Select sMaNXB as 'Mã Nhà Xuất Bản' , sTenNXB as 'Tên Nhà Xuất Bản' , sDiaChi as 'Địa Chỉ' from tblNhaXuatBan WHERE 1=1";
            if (!string.IsNullOrEmpty(txtMaNXB.Text))
            {
                query += "AND sMaNXB LIKE '%" +txtMaNXB.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtTenNXB.Text))
            {
                query += "AND sTenNXB LIKE '%" + txtTenNXB.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtDiaChi.Text))
            {
                query += "AND sDiaChi LIKE '%" + txtDiaChi.Text + "%'";
            }
            try
            {
                dataGridView_NXB.DataSource = modifyNXB.Table(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            txtMaNXB.Text = "";
            txtTenNXB.Text = "";
            txtDiaChi.Text = "";

            tblNhaXuatBan_Load(sender, e);        }

        private void btnInNXB_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Connection.GetSqlConnection();
            string sql = "Select * from tblNhaXuatBan ";
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            conn.Open();

            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            ad.Fill(dataTable);

            CrystalReport2 cryKH = new CrystalReport2();
            cryKH.SetDataSource(dataTable);

            indskhachhang inNXB = new indskhachhang();

            inNXB.crystalReportViewer1.ReportSource = cryKH;
            inNXB.ShowDialog();


            conn.Close();
        }
    }
}
