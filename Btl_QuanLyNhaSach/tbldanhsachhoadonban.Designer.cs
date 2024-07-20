namespace Btl_QuanLyNhaSach
{
    partial class tbldanhsachhoadonban
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sMaHDBan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.date_KetThuc = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.date_BatDau = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView_DanhSachHDBan = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTimKienHoaDon = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.iMaNV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DanhSachHDBan)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sMaHDBan);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(16, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(380, 80);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm hóa đơn theo mã hóa đơn ";
            // 
            // sMaHDBan
            // 
            this.sMaHDBan.Location = new System.Drawing.Point(148, 31);
            this.sMaHDBan.Margin = new System.Windows.Forms.Padding(2);
            this.sMaHDBan.Name = "sMaHDBan";
            this.sMaHDBan.Size = new System.Drawing.Size(194, 20);
            this.sMaHDBan.TabIndex = 3;
            this.sMaHDBan.TextChanged += new System.EventHandler(this.sMaHDBan_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Mã Hóa Đơn Bán:  ";
            // 
            // date_KetThuc
            // 
            this.date_KetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_KetThuc.Location = new System.Drawing.Point(206, 51);
            this.date_KetThuc.Margin = new System.Windows.Forms.Padding(2);
            this.date_KetThuc.Name = "date_KetThuc";
            this.date_KetThuc.Size = new System.Drawing.Size(225, 20);
            this.date_KetThuc.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đến Ngày: ";
            // 
            // date_BatDau
            // 
            this.date_BatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_BatDau.Location = new System.Drawing.Point(206, 24);
            this.date_BatDau.Margin = new System.Windows.Forms.Padding(2);
            this.date_BatDau.Name = "date_BatDau";
            this.date_BatDau.Size = new System.Drawing.Size(225, 20);
            this.date_BatDau.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Từ Ngày: ";
            // 
            // dataGridView_DanhSachHDBan
            // 
            this.dataGridView_DanhSachHDBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DanhSachHDBan.Location = new System.Drawing.Point(64, 241);
            this.dataGridView_DanhSachHDBan.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_DanhSachHDBan.Name = "dataGridView_DanhSachHDBan";
            this.dataGridView_DanhSachHDBan.RowHeadersWidth = 62;
            this.dataGridView_DanhSachHDBan.RowTemplate.Height = 28;
            this.dataGridView_DanhSachHDBan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_DanhSachHDBan.Size = new System.Drawing.Size(669, 223);
            this.dataGridView_DanhSachHDBan.TabIndex = 77;
            this.dataGridView_DanhSachHDBan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_DanhSachHDBan_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(283, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 24);
            this.label1.TabIndex = 74;
            this.label1.Text = "Danh Sách Hóa Đơn Bán Sách";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTimKienHoaDon);
            this.groupBox2.Controls.Add(this.date_KetThuc);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.date_BatDau);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(16, 125);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(783, 78);
            this.groupBox2.TabIndex = 79;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm hóa đơn theo thời gian";
            // 
            // btnTimKienHoaDon
            // 
            this.btnTimKienHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKienHoaDon.Location = new System.Drawing.Point(525, 27);
            this.btnTimKienHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKienHoaDon.Name = "btnTimKienHoaDon";
            this.btnTimKienHoaDon.Size = new System.Drawing.Size(111, 33);
            this.btnTimKienHoaDon.TabIndex = 67;
            this.btnTimKienHoaDon.Text = "Tìm Kiếm";
            this.btnTimKienHoaDon.UseVisualStyleBackColor = true;
            this.btnTimKienHoaDon.Click += new System.EventHandler(this.btnTimKienHoaDon_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.iMaNV);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(416, 41);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(380, 80);
            this.groupBox3.TabIndex = 79;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm kiếm hóa đơn theo tên người lập";
            // 
            // iMaNV
            // 
            this.iMaNV.Location = new System.Drawing.Point(147, 31);
            this.iMaNV.Margin = new System.Windows.Forms.Padding(2);
            this.iMaNV.Name = "iMaNV";
            this.iMaNV.Size = new System.Drawing.Size(194, 20);
            this.iMaNV.TabIndex = 1;
            this.iMaNV.TextChanged += new System.EventHandler(this.iMaNV_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tên Người Lập HĐ: ";
            // 
            // tbldanhsachhoadonban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(832, 474);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView_DanhSachHDBan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "tbldanhsachhoadonban";
            this.Text = "Danh Sách Hóa Đơn Bán";
            this.Load += new System.EventHandler(this.danhsachhoadonban_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DanhSachHDBan)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker date_BatDau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView_DanhSachHDBan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker date_KetThuc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sMaHDBan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox iMaNV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTimKienHoaDon;
    }
}