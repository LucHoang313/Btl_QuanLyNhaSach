using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Btl_QuanLyNhaSach
{
    class Connection
    {
        // Đường liên kết tới sql
        private static string stringConnection = @"Data Source=.;Initial Catalog=BTL_QLNS;Integrated Security=True";

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
