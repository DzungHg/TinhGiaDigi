using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInBDO
{
    public class GiayBDO
    {
        public int ID { get; set; }
        public string MaGiayNCC { get; set; }
        public string MaGiayTuDat { get; set; }
        public string TenGiay { get; set; }
        public string DienGiai { get; set; }
        public int DinhLuong { get; set; }
        public string KhoGiay { get; set; }
        public float ChieuNgan { get; set; }
        public float ChieuDai { get; set; }
        public string TenGiayMoRong { get; set; }
        public int GiaMua { get; set; }
        public bool KhongCon { get; set; }        
        public int IdDanhMucGiay { get; set; }
        public string TenDanhMucGiay { get; set; }
        public bool TonKho { get; set; }
        public int ThuTu { get; set; }
    }
}
