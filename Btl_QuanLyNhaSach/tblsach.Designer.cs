namespace Btl_QuanLyNhaSach
{
    partial class tblsach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.sTenNXB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCapNhatSach = new System.Windows.Forms.Button();
            this.btnXoaSach = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView_Sach = new System.Windows.Forms.DataGridView();
            this.sMaSach = new System.Windows.Forms.TextBox();
            this.fGiaSach = new System.Windows.Forms.TextBox();
            this.iSoLuong = new System.Windows.Forms.TextBox();
            this.sTenSach = new System.Windows.Forms.TextBox();
            this.sTheLoai = new System.Windows.Forms.TextBox();
            this.btnThemSach = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnTiepTuc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Sach)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(93, 98);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(177, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // sTenNXB
            // 
            this.sTenNXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sTenNXB.Location = new System.Drawing.Point(93, 142);
            this.sTenNXB.Margin = new System.Windows.Forms.Padding(2);
            this.sTenNXB.Name = "sTenNXB";
            this.sTenNXB.Size = new System.Drawing.Size(177, 23);
            this.sTenNXB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(282, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh Sách Các Loại Sách";
            // 
            // btnCapNhatSach
            // 
            this.btnCapNhatSach.BackColor = System.Drawing.Color.Azure;
            this.btnCapNhatSach.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCapNhatSach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Fuchsia;
            this.btnCapNhatSach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btnCapNhatSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhatSach.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatSach.Location = new System.Drawing.Point(12, 347);
            this.btnCapNhatSach.Margin = new System.Windows.Forms.Padding(2);
            this.btnCapNhatSach.Name = "btnCapNhatSach";
            this.btnCapNhatSach.Size = new System.Drawing.Size(128, 35);
            this.btnCapNhatSach.TabIndex = 18;
            this.btnCapNhatSach.Text = "Cập Nhật Sách";
            this.btnCapNhatSach.UseVisualStyleBackColor = false;
            this.btnCapNhatSach.Click += new System.EventHandler(this.btnCapNhatSach_Click);
            // 
            // btnXoaSach
            // 
            this.btnXoaSach.BackColor = System.Drawing.Color.Azure;
            this.btnXoaSach.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnXoaSach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Fuchsia;
            this.btnXoaSach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btnXoaSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSach.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaSach.Location = new System.Drawing.Point(12, 243);
            this.btnXoaSach.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoaSach.Name = "btnXoaSach";
            this.btnXoaSach.Size = new System.Drawing.Size(128, 35);
            this.btnXoaSach.TabIndex = 17;
            this.btnXoaSach.Text = "Xóa Sách";
            this.btnXoaSach.UseVisualStyleBackColor = false;
            this.btnXoaSach.Click += new System.EventHandler(this.btnXoaSach_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 102);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 15);
            this.label8.TabIndex = 23;
            this.label8.Text = "Mã NXB:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(602, 102);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 22;
            this.label6.Text = "Giá Sách:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 145);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "Tên NXB:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Mã Sách:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(600, 57);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 15);
            this.label7.TabIndex = 26;
            this.label7.Text = "Số Lượng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(299, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "Thể Loại:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(295, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Tên Sách:";
            // 
            // dataGridView_Sach
            // 
            this.dataGridView_Sach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Sach.Location = new System.Drawing.Point(156, 247);
            this.dataGridView_Sach.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_Sach.Name = "dataGridView_Sach";
            this.dataGridView_Sach.RowHeadersWidth = 62;
            this.dataGridView_Sach.RowTemplate.Height = 28;
            this.dataGridView_Sach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Sach.Size = new System.Drawing.Size(893, 206);
            this.dataGridView_Sach.TabIndex = 29;
            this.dataGridView_Sach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Sach_CellClick);
            // 
            // sMaSach
            // 
            this.sMaSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sMaSach.Location = new System.Drawing.Point(93, 58);
            this.sMaSach.Margin = new System.Windows.Forms.Padding(2);
            this.sMaSach.Name = "sMaSach";
            this.sMaSach.Size = new System.Drawing.Size(177, 23);
            this.sMaSach.TabIndex = 30;
            // 
            // fGiaSach
            // 
            this.fGiaSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGiaSach.Location = new System.Drawing.Point(667, 98);
            this.fGiaSach.Margin = new System.Windows.Forms.Padding(2);
            this.fGiaSach.Name = "fGiaSach";
            this.fGiaSach.Size = new System.Drawing.Size(152, 23);
            this.fGiaSach.TabIndex = 31;
            // 
            // iSoLuong
            // 
            this.iSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iSoLuong.Location = new System.Drawing.Point(665, 57);
            this.iSoLuong.Margin = new System.Windows.Forms.Padding(2);
            this.iSoLuong.Name = "iSoLuong";
            this.iSoLuong.Size = new System.Drawing.Size(153, 23);
            this.iSoLuong.TabIndex = 32;
            this.iSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.iSoLuong_KeyPress);
            // 
            // sTenSach
            // 
            this.sTenSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sTenSach.Location = new System.Drawing.Point(361, 57);
            this.sTenSach.Margin = new System.Windows.Forms.Padding(2);
            this.sTenSach.Name = "sTenSach";
            this.sTenSach.Size = new System.Drawing.Size(217, 23);
            this.sTenSach.TabIndex = 33;
            // 
            // sTheLoai
            // 
            this.sTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sTheLoai.Location = new System.Drawing.Point(361, 98);
            this.sTheLoai.Margin = new System.Windows.Forms.Padding(2);
            this.sTheLoai.Name = "sTheLoai";
            this.sTheLoai.Size = new System.Drawing.Size(217, 23);
            this.sTheLoai.TabIndex = 34;
            // 
            // btnThemSach
            // 
            this.btnThemSach.BackColor = System.Drawing.Color.Azure;
            this.btnThemSach.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnThemSach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Fuchsia;
            this.btnThemSach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btnThemSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSach.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSach.Location = new System.Drawing.Point(12, 297);
            this.btnThemSach.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(128, 35);
            this.btnThemSach.TabIndex = 35;
            this.btnThemSach.Text = "Thêm Sách";
            this.btnThemSach.UseVisualStyleBackColor = false;
            this.btnThemSach.Click += new System.EventHandler(this.btnThemSach_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Azure;
            this.btnTimKiem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTimKiem.Location = new System.Drawing.Point(12, 190);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(128, 33);
            this.btnTimKiem.TabIndex = 36;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnTiepTuc
            // 
            this.btnTiepTuc.BackColor = System.Drawing.Color.Azure;
            this.btnTiepTuc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTiepTuc.Location = new System.Drawing.Point(12, 401);
            this.btnTiepTuc.Name = "btnTiepTuc";
            this.btnTiepTuc.Size = new System.Drawing.Size(128, 35);
            this.btnTiepTuc.TabIndex = 37;
            this.btnTiepTuc.Text = "Tiếp tục";
            this.btnTiepTuc.UseVisualStyleBackColor = false;
            this.btnTiepTuc.Click += new System.EventHandler(this.btnTiepTuc_Click);
            // 
            // tblsach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1097, 469);
            this.Controls.Add(this.btnTiepTuc);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnThemSach);
            this.Controls.Add(this.sTheLoai);
            this.Controls.Add(this.sTenSach);
            this.Controls.Add(this.iSoLuong);
            this.Controls.Add(this.fGiaSach);
            this.Controls.Add(this.sMaSach);
            this.Controls.Add(this.dataGridView_Sach);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCapNhatSach);
            this.Controls.Add(this.btnXoaSach);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sTenNXB);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "tblsach";
            this.Text = " ";
            this.Load += new System.EventHandler(this.tblsach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Sach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox sTenNXB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCapNhatSach;
        private System.Windows.Forms.Button btnXoaSach;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView_Sach;
        private System.Windows.Forms.TextBox sMaSach;
        private System.Windows.Forms.TextBox fGiaSach;
        private System.Windows.Forms.TextBox iSoLuong;
        private System.Windows.Forms.TextBox sTenSach;
        private System.Windows.Forms.TextBox sTheLoai;
        private System.Windows.Forms.Button btnThemSach;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnTiepTuc;
    }
}