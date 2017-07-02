using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInBDO
{
    public class BangGiaTheNhuaBDO
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public string DaySoLuong { get; set; }
        public string DayGia { get; set; }
        public bool InHaiMat { get; set; }
        public int IdHangKhachHang { get; set; }
        public int SoTheToiDa { get; set; }
        public string NoiDungBangGia { get; set; }
        public string VatLieuInBaoGom { get; set; }
        public string KhoToChay { get; set; }
        public int ThuTu { get; set; }
        public bool KhongCon { get; set; }
    }
}
