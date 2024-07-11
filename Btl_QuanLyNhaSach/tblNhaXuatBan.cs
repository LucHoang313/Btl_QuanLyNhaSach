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
            dataGridView_NXB.DataSource = modifyNXB.Table("Select * from tblNhaXuatBan");
        }


        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (keyword == "")
            {
                tblNhaXuatBan_Load(sender, e);
            }
            else
            {
                // Tạo câu truy vấn SQL với điều kiện tìm kiếm theo nhiều trường
                string query = "SELECT * FROM tblNhaXuatBan " +
                               "WHERE sMaNXB LIKE N'%" + keyword + "%' OR " +
                                     "sTenNXB LIKE N'%" + keyword + "%' OR " +
                                     "sDiaChi LIKE N'%" + keyword + "%'";

                // Gọi phương thức để lấy dữ liệu từ câu truy vấn và hiển thị trên dataGridView
                dataGridView_NXB.DataSource = modifyNXB.Table(query);
            }
        }

        private bool CheckText()
        {
            if (txtMaNXB.Text == "" || txtTenNXB.Text == "" || txtDiaChi.Text == "" )
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
                SqlCommand cmd = new SqlCommand(sql,conn);  
                conn.Open();
                string sMaNXB = (string)cmd.ExecuteScalar();
                if(sMaNXB != null)
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
                tblNhaXuatBan_Load(sender,e);

            }
        }

        private void btnXoaNXB_Click(object sender, EventArgs e)
        {
            string query = "DELETE tblNhaXuatBan WHERE sMaNXB = '" + txtMaNXB.Text +"'";
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

       
    }
}
