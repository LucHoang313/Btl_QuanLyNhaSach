using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Btl_QuanLyNhaSach.Object
{
    class HoaDonBan
    {
        internal string iMaNV;
        private string sMaHDBan;
        private string sMaKH;
        private DateTime dNgayLap;
        private int imaNV;

        public HoaDonBan(string smaHDBan, System.Windows.Forms.TextBox iMaNV)
        {
        }

        public HoaDonBan(string sMaHDBan, string sTenTk, string sMaKH, DateTime dNgayLap)
        {
            this.sMaHDBan = sMaHDBan;
            this.iMaNV = iMaNV;
            this.sMaKH = sMaKH;
            this.dNgayLap = dNgayLap;
        }

        public HoaDonBan(string smaHDBan, TextBox iMaNV, string smaKh, DateTime dngayLap) : this(smaHDBan, iMaNV)
        {
        }

        public HoaDonBan(string smaHDBan, int imaNV, string smaKh, DateTime dngayLap)
        {
            sMaHDBan = smaHDBan;
            this.imaNV = imaNV;
            sMaKH = smaKh;
            dNgayLap = dngayLap;
        }

        public string SMaHDBan { get => sMaHDBan; set => sMaHDBan = value; }
        public string STenTk { get => iMaNV; set => iMaNV = value; }
        public string SMaKH { get => sMaKH; set => sMaKH = value; }
        public DateTime DNgayLap { get => dNgayLap; set => dNgayLap = value; }
    }
}
