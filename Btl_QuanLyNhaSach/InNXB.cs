using Btl_QuanLyNhaSach.CrystalReport;
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
    public partial class InNXB : Form
    {
        public InNXB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Connection.GetSqlConnection();
            string sql = "Select * from tblChiTietHoaDonNhap";
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            conn.Open();

            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            ad.Fill(dataTable);

            CrystalReport3 cryKH = new CrystalReport3();
            cryKH.SetDataSource(dataTable);

            InNXB inNXB = new InNXB();
            
            inNXB.crystalReportViewer1.ReportSource = cryKH;



            conn.Close();
        }
    }
}
