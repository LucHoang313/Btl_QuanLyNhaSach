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
    public partial class tblnhanvien : Form
    {
        public tblnhanvien()
        {
            InitializeComponent();
        }
        public static bool themNV(int ma, string name, DateTime ngaySinh, float phucap, float luongcb, string dt, string cccd)
        {
            string connection = @"Data Source=.;Initial Catalog=BTL_QLNS;Integrated Security=True";
            string sqlInsert = "insert into tblNhanVien(iMaNV,sHoTen,dNgaySinh,fPhuCap,fLuongCB,sDienThoai,CCCD)" +
                "values(" + ma + ",N'" + name + "','" + ngaySinh + "'," + phucap + "," + luongcb + ",'" + dt + "','" + cccd + "')";
            using (SqlConnection cnn = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand(sqlInsert, cnn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }

        }
        public static bool checkPk(int ma, string name, DateTime ngaySinh, float phucap, float luongcb, string dt, string cccd)
        {
            string connection = @"Data Source=.;Initial Catalog=BTL_QLNS;Integrated Security=True";

            using (SqlConnection cnn = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from tblNhanVien where iMaNV=" + ma + "", cnn))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable tb = new DataTable("tblNV"))
                        {
                            ad.Fill(tb);
                            if (tb.Rows.Count == 0)
                            {
                                bool i = themNV(ma, name, ngaySinh, phucap, luongcb, dt, cccd);
                                return true;
                            }
                            else
                                return false;
                            Console.Read();
                        }
                    }
                }
            }
        }

        public static bool timKiem(int ma)
        {
            string connection = @"Data Source=.;Initial Catalog=BTL_QLNS;Integrated Security=True";
            string query = "SELECT * FROM tblNhanVien WHERE iMaNV = @ma";

            try
            {
                using (SqlConnection cnn = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@ma", ma);
                        cnn.Open();
                        int rowsCount = (int)cmd.ExecuteScalar();
                        cnn.Close();
                        return rowsCount > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle exception (e.g., log it)
                MessageBox.Show("Lỗi khi tìm kiếm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool sua_NV(int ma, string name, DateTime ngaySinh, float phucap, float luongcb, string dt, string cccd)
        {
            string connection = @"Data Source=.;Initial Catalog=BTL_QLNS;Integrated Security=True";
            string update = "update tblNhanVien set sHoTen=N'" + name + "', dNgaySinh='" + ngaySinh.ToString("yyyy-MM-dd") + "', fPhuCap=" + phucap + ", fLuongCB=" + luongcb + ", sDienThoai='" + dt + "', CCCD='" + cccd + "' where iMaNV=" + ma;

            try
            {
                using (SqlConnection cnn = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand(update, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cnn.Open();
                        int i = cmd.ExecuteNonQuery();
                        cnn.Close();
                        return i > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle exception (e.g., log it)
                MessageBox.Show("Lỗi khi sửa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public static bool xoaNV(int ma)
        {
            string connection = @"Data Source=.;Initial Catalog=BTL_QLNS;Integrated Security=True";

            // Check if there are related records in tblHoaDonBan
            string checkRelatedHoaDonBan = "SELECT COUNT(*) FROM tblHoaDonBan WHERE iMaNV = @ma";

            try
            {
                using (SqlConnection cnn = new SqlConnection(connection))
                {
                    // Check if there are related records in tblHoaDonBan
                    using (SqlCommand cmdCheckHoaDonBan = new SqlCommand(checkRelatedHoaDonBan, cnn))
                    {
                        cmdCheckHoaDonBan.Parameters.AddWithValue("@ma", ma);
                        cnn.Open();
                        int countHoaDonBan = (int)cmdCheckHoaDonBan.ExecuteScalar();

                        // If there are related records, handle them accordingly
                        if (countHoaDonBan > 0)
                        {
                            // Optionally, you can inform the user or handle the related records
                            // before proceeding with deletion
                            MessageBox.Show("Không thể xóa nhân viên vì có các hóa đơn bán liên quan.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    // Proceed with deleting from tblNhanVien if no related records found in tblHoaDonBan
                    string deleteQuery = "DELETE FROM tblNhanVien WHERE iMaNV = @ma";
                    using (SqlCommand cmdDelete = new SqlCommand(deleteQuery, cnn))
                    {
                        cmdDelete.Parameters.AddWithValue("@ma", ma);
                        int rowsAffected = cmdDelete.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle exception (e.g., log it)
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }




        private void btnShow_Click(object sender, EventArgs e)
        {
            int ma;
            string name, dt, cccd;
            float phucap, Luongcb;
            DateTime ns;
            ma = int.Parse(txtMaNV.Text);
            name = txtName.Text;
            dt = txtDienThoai.Text;
            phucap = float.Parse(txtPhuCap.Text);
            Luongcb = float.Parse(txtLuongCB.Text);
            cccd = txtCD.Text;
            ns = txtNgaySinh.Value;
            bool b = checkPk(ma, name, ns, phucap, Luongcb, dt, cccd);
            if (b)
            {

                MessageBox.Show("Them thanh cong", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataView_load();
            }
            else
            {
                MessageBox.Show("Them that bai", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public void dataView_load()
        {
            string connection = @"Data Source=.;Initial Catalog=BTL_QLNS;Integrated Security=True";
            using (SqlConnection cnn = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("select iMaNV as 'Mã Nhân Viên', sHoten as 'Họ Tên', dNgaySinh as 'Ngày Sinh' , fPhuCap as 'Phụ Cấp' , fLuongCb as 'Lương Cơ Bản' , sDienThoai as 'Số Điện Thoại' , CCCD as 'CCCD' from tblNhanVien", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable("NV");
                        ad.Fill(tb);
                        dtG1.DataSource = tb;
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            int ma;
            string name, dt, cccd;
            float phucap, Luongcb;
            DateTime ns;
            ma = int.Parse(txtMaNV.Text);
            name = txtName.Text;
            dt = txtDienThoai.Text;
            phucap = float.Parse(txtPhuCap.Text);
            Luongcb = float.Parse(txtLuongCB.Text);
            ns = txtNgaySinh.Value;
            cccd = 
                txtCD.Text;
            if (sua_NV(ma, name, ns, phucap, Luongcb, dt, cccd))
            {

                MessageBox.Show("Them thanh cong", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataView_load();
            }
            else
            {
                MessageBox.Show("Them that bai", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ma;
            if (int.TryParse(txtMaNV.Text, out ma))
            {
                if (xoaNV(ma))
                {
                    MessageBox.Show("Xóa thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataView_load();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mã nhân viên không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            dataView_load();
        }

        private void txtPhuCap_Validating(object sender, CancelEventArgs e)
        {
            float phuCap;
            if (!float.TryParse(txtPhuCap.Text, out phuCap) || phuCap <= 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhuCap, "Vui Lòng Nhập Một Số Dương");
            }
            else
            {
                errorProvider1.SetError(txtPhuCap, "");
            }
        }

        private void txtLuongCB_Validating(object sender, CancelEventArgs e)
        {
            float luongCB;
            if (!float.TryParse(txtLuongCB.Text, out luongCB) || luongCB <= 0)
            {
                e.Cancel = true;
                errorProvider2.SetError(txtLuongCB, "Vui Lòng Nhập Một Số Dương");
            }
            else
            {
                errorProvider2.SetError(txtLuongCB, "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "")
            {
                string RowFilter = string.Format("CONVERT({0}, System.String) like '%{1}%'",
              "iMaNV", txtMaNV.Text.Trim());
                (dtG1.DataSource as DataTable).DefaultView.RowFilter = RowFilter;
            }
            else
            {
                MessageBox.Show("ma nhan vien dang trong");
            }
        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            // Xóa nội dung trên các control nhập liệu
            txtMaNV.Text = "";
            txtName.Text = "";
            txtNgaySinh.Value = DateTime.Now; // Đặt lại ngày sinh về ngày hiện tại hoặc giá trị mặc định
            txtPhuCap.Text = "";
            txtLuongCB.Text = "";
            txtDienThoai.Text = "";
            txtCD.Text = "";

            // Xóa lọc dữ liệu trên DataGridView (nếu có)
            (dtG1.DataSource as DataTable).DefaultView.RowFilter = "";

            NhanVien_Load(sender, e);
        }



        private void dtG1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtG1.Rows[e.RowIndex];

                // Hiển thị dữ liệu từ DataGridView lên các control tương ứng
                txtMaNV.Text = row.Cells["Mã Nhân Viên"].Value.ToString();
                txtName.Text = row.Cells["Họ Tên"].Value.ToString();
                txtNgaySinh.Value = Convert.ToDateTime(row.Cells["Ngày Sinh"].Value);
                txtPhuCap.Text = row.Cells["Phụ Cấp"].Value.ToString();
                txtLuongCB.Text = row.Cells["Lương Cơ Bản"].Value.ToString();
                txtDienThoai.Text = row.Cells["Số Điện Thoại"].Value.ToString();
                txtCD.Text = row.Cells["CCCD"].Value.ToString();
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string tenNV = txtName.Text.Trim();
            string dienThoai = txtDienThoai.Text.Trim();
            string cccd = txtCD.Text.Trim();

            string connection = @"Data Source=.;Initial Catalog=BTL_QLNS;Integrated Security=True";
            string query = "SELECT * FROM tblNhanVien WHERE " +
                           "iMaNV LIKE '%" + maNV + "%' AND " +
                           "sHoTen LIKE N'%" + tenNV + "%' AND " +
                           "sDienThoai LIKE '%" + dienThoai + "%' AND " +
                           "CCCD LIKE '%" + cccd + "%'";

            using (SqlConnection cnn = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable("NV");
                        ad.Fill(tb);
                        dtG1.DataSource = tb;
                    }
                }
            }
        }

    }
}
