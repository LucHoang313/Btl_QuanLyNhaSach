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

namespace Btl_QuanLyNhaSach
{
    public partial class formtesst : Form
    {
        ModifyAll modifiKH = new ModifyAll();

        public formtesst()
        {
            InitializeComponent();
        }

        private void formtesst_Load(object sender, EventArgs e)
        {
            dataGridView_KhachHang.DataSource = modifiKH.Table("Select * from tblKhachHang");
        }

        private void dataGridView_KhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sMaKH.Text = dataGridView_KhachHang.SelectedRows[0].Cells[0].Value.ToString();
            sTenKH.Text = dataGridView_KhachHang.SelectedRows[0].Cells[1].Value.ToString();
            sDiaChi.Text = dataGridView_KhachHang.SelectedRows[0].Cells[2].Value.ToString();
            sSDT.Text = dataGridView_KhachHang.SelectedRows[0].Cells[3].Value.ToString();
            sEmail.Text = dataGridView_KhachHang.SelectedRows[0].Cells[4].Value.ToString();
            dNgaySinh.Text = dataGridView_KhachHang.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void textBox_TimKiemKhachHang_TextChanged(object sender, EventArgs e)
        {
            if (textBox_TimKiemKhachHang.Text == "")
            {
                formtesst_Load(sender, e);
            }
            else
            {
                string query = "SELECT * FROM tblKhachHang WHERE sMaKH LIKE N'%" + textBox_TimKiemKhachHang.Text + "%'";
                dataGridView_KhachHang.DataSource = modifiKH.Table(query);
            }
            
        }


        private bool CheckText()
        {
            if (sTenKH.Text == "" || sSDT.Text == "" || sDiaChi.Text == "" || sEmail.Text == ""
                || sMaKH.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                return false;
            }

            return true;
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            if(CheckText())
            {
                SqlConnection conn = Connection.GetSqlConnection();
                string sql = "SELECT sMaKH FROM tblKhachHang WHERE sMaKH = '" + sMaKH.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                string smaKH = (string)cmd.ExecuteScalar();
                if (smaKH != null)
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại");
                    return;
                }


                string query = "INSERT INTO tblKhachHang values ( '" + sMaKH.Text + "', '" + sTenKH.Text + "' , " +
                    "'" + sDiaChi.Text + "', '" + sSDT.Text + "', '" + sEmail.Text + "')";
                modifiKH.Command(query);
                MessageBox.Show("Bạn đã thêm thành công khách hàng");
                formtesst_Load(sender, e);
            }    
        }

        private void btnCapNhatKhachHang_Click(object sender, EventArgs e)
        {
            if(CheckText())
            {
                string query = "UPDATE tblKhachHang set " + "sMaKH = '" + sMaKH.Text + "', sTenKH = N'" + sTenKH.Text + "' , " +
                "sDiaChi = N'" + sDiaChi.Text + "', sSDT = '" + sSDT.Text + "', sEmail = '" + sEmail.Text + "' WHERE sMaKH = '" + sMaKH.Text + "'";
                modifiKH.Command(query);
                MessageBox.Show("Bạn đã cập nhật thành công thành công khách hàng");
                formtesst_Load(sender, e);
            }    
        }

        private void btnXoaKhachHang_Click(object sender, EventArgs e)
        {
            string query = "DELETE tblKhachHang WHERE sMaKH = '" + sMaKH.Text + "'";
            modifiKH.Command(query);
            MessageBox.Show("Bạn đã xóa thành công thành công khách hàng");
            xoa();
            formtesst_Load(sender, e);
        }

        private void xoa()
        {
            sMaKH.Text = "";
            sTenKH.Text = "";
            sDiaChi.Text = "";
            sSDT.Text = "";
            sEmail.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Connection.GetSqlConnection();
            string sql = "Select * from tblKhachHang";
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            conn.Open();

            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            ad.Fill(dataTable);

            CrystalReport1 cryKH = new CrystalReport1();
            cryKH.SetDataSource(dataTable);

            InNXB indskhachhang = new InNXB();
            //indskhachhang.crystalReportViewer1.ReportSource = cryKH;
            
            indskhachhang.ShowDialog();

            conn.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime a = dNgayTruoc.Value;
            DateTime b = dNgaySau.Value;
            string query = "SELECT * FROM tblKhachHang WHERE dNgaySinh >= '" + a + "' AND dNgaySinh <= '" + b + "'";
            dataGridView_KhachHang.DataSource = modifiKH.Table(query);
        }
    }
}
