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
            string update = "Select * from tblNhanVien where iMaNV=@ma";
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
        public static bool sua_NV(int ma, string name, DateTime ngaySinh, float phucap, float luongcb, string dt, string cccd)
        {
            string connection = @"Data Source=.;Initial Catalog=BTL_QLNS;Integrated Security=True";
            string update = "update tblNhanVien set sHoTen=N'" + name + "',dNgaySinh='" + ngaySinh + "',fPhuCap=" + phucap + ",fLuongCB=" + luongcb + ",sDienThoai='" + dt + "',CCCD='" + cccd + "' where iMaNV=" + ma + " ";
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

        public static bool xoaNV(int ma)
        {
            string connection = @"Data Source=.;Initial Catalog=BTL_QLNS;Integrated Security=True";
            string deletee = "delete from tblNhanVien where iMaNV=" + ma + "";
            using (SqlConnection cnn = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand(deletee, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
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
                using (SqlCommand cmd = new SqlCommand("select * from tblNhanVien", cnn))
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
            int ma;
            ma = int.Parse(txtMaNV.Text);
            if (xoaNV(ma))
            {

                MessageBox.Show("Xoa thanh cong", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataView_load();
            }
            else
            {
                MessageBox.Show("Xoa that bai", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dtG1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
