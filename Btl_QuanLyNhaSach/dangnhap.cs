using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Btl_QuanLyNhaSach
{
    public partial class dangnhap : Form
    {
        ModifyTaiKhoan modify = new ModifyTaiKhoan();

        public dangnhap()
        {
            InitializeComponent();

        }

        // Sử lí sự kiện nút button Đăng nhập
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string sTenTk = txtUsername_dangnhap.Text.Trim();
            string sMatKhau = txtPassword_dangnhap.Text.Trim();

            if (sTenTk.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!");
            }
            else if (sMatKhau.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu tài khoản!");
            }
            else
            {
                string query = "SELECT * FROM tblTaiKhoan WHERE sTenTk = '" + sTenTk + "' and sMatKhau = '" + sMatKhau + "'";
                if (modify.TaiKhoans(query).Count > 0)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    trangchu trangchu = new trangchu(sTenTk, sMatKhau);
                    trangchu.ShowDialog();
                    trangchu = null;
                    this.Show();

                    // Sử lí sự kiện khi chuyển sang màn hình trang chủ thì ô tài khoản sẽ xóa trống
                    txtUsername_dangnhap.Text = "";
                    txtPassword_dangnhap.Text = "";
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }    
            }
        }

        // Đặt điều kiện đầu tiên password hình chấm tròn
        private void dangnhap_Load(object sender, EventArgs e)
        {
            checkBox.Checked = true;
        }

        // Sử lí sự kiện ẩn hiện password
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                // Ẩn mật khẩu
                txtPassword_dangnhap.UseSystemPasswordChar = true;
            }
            else
            {
                // Hiện mật khẩu
                txtPassword_dangnhap.UseSystemPasswordChar = false;
            }
        }

        // Sử lí sự button Quên mật khẩu
        private void txtQuenMatKhau_Click(object sender, EventArgs e)
        {
            this.Hide();
            quenmatkhau quenmatkhau = new quenmatkhau();
            quenmatkhau.ShowDialog();
            quenmatkhau = null;
            this.Show();
        }

        // Sử lí sự kiện khi bấm icon x sẽ tắt cả ứng dụng
        private void dangnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Application.Exit();
            }
        }
    }
}
