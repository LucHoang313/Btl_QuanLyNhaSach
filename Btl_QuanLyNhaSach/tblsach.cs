﻿using Btl_QuanLyNhaSach.CrystalReport;
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

namespace Btl_QuanLyNhaSach
{
    public partial class tblsach : Form
    {
        // Khởi tạo 
        ModifyAll modifySach = new ModifyAll();
        Sach sach;

        public tblsach()
        {
            InitializeComponent();
            fillCombobox();
        }

        // Sử lí sự kiện click vào item trong combobox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = Connection.GetSqlConnection();
            string sql = "SELECT * FROM tblNhaXuatBan WHERE sMaNXB" +
                " = '" + comboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myreader; try
            {
                con.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string sMaNXB = myreader.GetString(1);
                    this.sTenNXB.Text = sMaNXB;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Sử lí sự kiện đổ dữ từ sql vào combobox
        public void fillCombobox()
        {
            SqlConnection con = Connection.GetSqlConnection();
            string sql = "SELECT * FROM tblNhaXuatBan";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myreader; try
            {
                con.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string sMaNXB = myreader.GetString(0);
                    comboBox1.Items.Add(sMaNXB);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Sử lí sự kiện đổ dữ liệu từ sql vào datagridview
        private void tblsach_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView_Sach.DataSource = modifySach.Table("SELECT sMaSach AS 'Mã Sách', sTenSach AS 'Tên Sách', fGiaSach AS 'Giá Sách', iSoLuong AS 'Số Lượng Trong Kho', sMaNXB AS 'Mã NXB', sTheLoai AS 'Thể Loại' FROM tblSach");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            DeleteTextBoxes();
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

        // Sử lí sự kiện xóa hết các kí tự trong các ô
        private void DeleteTextBoxes()
        {
            sTenNXB.Text = "";
            sMaSach.Text = "";
            fGiaSach.Text = "";
            iSoLuong.Text = "";
            sTenSach.Text = "";
            sTheLoai.Text = "";
        }

        // Sử lí sự kiện nhập không được để trống
        private bool CheckText()
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Mời bạn chọn Mã NXB!");
                return false;
            }
            if (sTenNXB.Text == "" || sMaSach.Text == "" || fGiaSach.Text == "" || iSoLuong.Text == ""
                || sTenSach.Text == "" || sTheLoai.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                return false;
            }

            return true;

        }

        // Chuyền dữ liệu nhập vào trong đối tượng Sach
        private void GetValuesTextBox()
        {
            string smaSach = sMaSach.Text;
            string stenSach = sTenSach.Text;
            float fgiaSach = float.Parse(fGiaSach.Text);
            int isoLuong = int.Parse(iSoLuong.Text);
            string smaNXB = comboBox1.Text;
            string stheLoai = sTheLoai.Text;
            sach = new Sach(smaSach, stenSach, fgiaSach, isoLuong, smaNXB, stheLoai);
        }

        // Sử lí sự kiện cập nhật dữ liệu
        private void btnCapNhatSach_Click(object sender, EventArgs e)
        {
            if (CheckText())
            {
                GetValuesTextBox();
                string query = "UPDATE tblSach SET sMaSach = '" + sach.SMaSach + "', sTenSach = N'" + sach.STenSach + "'," +
                " fGiaSach = '" + sach.FGiaSach + "', iSoLuong = '" + sach.ISoLuong + "'" +
                ", sMaNXB = '" + sach.SMaNXB + "', sTheLoai = N'" + sach.STheLoai + "' ";
                query += "WHERE sMaSach = '" + sach.SMaSach + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn sửa lại dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modifySach.Command(query);
                        MessageBox.Show("Bạn đã sửa 1 sách thành công!");
                        tblsach_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sửa: " + ex.Message);
                }
            }
        }

        // Sử lí sự kiện khi click vào 1 sách trong datagridview
        private void dataGridView_Sach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_Sach.Rows.Count > 1)
            {
                sMaSach.Text = dataGridView_Sach.SelectedRows[0].Cells[0].Value.ToString();
                sTenSach.Text = dataGridView_Sach.SelectedRows[0].Cells[1].Value.ToString();
                fGiaSach.Text = dataGridView_Sach.SelectedRows[0].Cells[2].Value.ToString();
                iSoLuong.Text = dataGridView_Sach.SelectedRows[0].Cells[3].Value.ToString();
                comboBox1.SelectedItem = dataGridView_Sach.SelectedRows[0].Cells[4].Value.ToString();
                sTheLoai.Text = dataGridView_Sach.SelectedRows[0].Cells[5].Value.ToString();
            }
        }

        // Sử lí sự kiện xóa dữ liệu
        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            // Check lớn hơn 1 dòng
            if (dataGridView_Sach.Rows.Count > 1)
            {
                string choose = dataGridView_Sach.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE tblSach ";
                query += " WHERE sMaSach = '" + choose + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modifySach.Command(query);
                        MessageBox.Show("Bạn đã xóa 1 sách thành công!");
                        tblsach_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }



        // Sử lí sự kiện thêm dữ liệu
        private void btnThemSach_Click(object sender, EventArgs e)
        {
            if (CheckText())
            {
                GetValuesTextBox();
                string query = "INSERT INTO tblSach values ('" + sach.SMaSach + "', N'" + sach.STenSach + "', '" + sach.FGiaSach + "'," +
                " '" + sach.ISoLuong + "' , '" + sach.SMaNXB + "', N'" + sach.STheLoai + "' ) ";
                try
                {
                    if (MessageBox.Show("Bạn có muốn thêm vào không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modifySach.Command(query);
                        MessageBox.Show("Bạn đã thêm 1 sách thành công!");
                        tblsach_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm: " + ex.Message);
                }
            }
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = "SELECT sMaSach AS 'Mã Sách', sTenSach AS 'Tên Sách', fGiaSach AS 'Giá Sách', iSoLuong AS 'Số Lượng Trong Kho', sMaNXB AS 'Mã NXB', sTheLoai AS 'Thể Loại' FROM tblSach WHERE 1=1";

            if (!string.IsNullOrEmpty(sMaSach.Text))
            {
                query += " AND sMaSach LIKE '%" + sMaSach.Text + "%'";
            }

            if (!string.IsNullOrEmpty(sTenSach.Text))
            {
                query += " AND sTenSach LIKE N'%" + sTenSach.Text + "%'";
            }

            if (!string.IsNullOrEmpty(fGiaSach.Text))
            {
                query += " AND fGiaSach LIKE '%" + fGiaSach.Text + "%'";
            }

            if (!string.IsNullOrEmpty(iSoLuong.Text))
            {
                query += " AND iSoLuong LIKE '%" + iSoLuong.Text + "%'";
            }

            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                query += " AND sMaNXB LIKE '%" + comboBox1.Text + "%'";
            }

            if (!string.IsNullOrEmpty(sTheLoai.Text))
            {
                query += " AND sTheLoai LIKE N'%" + sTheLoai.Text + "%'";
            }

            try
            {
                dataGridView_Sach.DataSource = modifySach.Table(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        // Sử lí sự kiện tiếp tục
        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            ClearTextBoxesAndComboBox(this);
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
