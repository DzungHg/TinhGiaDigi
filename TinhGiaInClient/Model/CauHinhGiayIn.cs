using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class CauHinhGiayIn //Dùng cho giấy in danh thiếp
    {
        public Giay GiayChon { get; set; }
        public bool GiayKhachDua { get; set; }
        public string DienGiaiGiayKhach { get; set; }
        public string KhoToChay { get; set; }
        public int SoLuongSanPham { get; set; }
        public int SoConTrenToChay { get; set; }
        public int SoLuongToChayLyThuyet { get; set; }
        public int SoLuongToChayBuHao { get; set; }
        public int TongSoToChay { get; set; }
        public int SoToChayTrenToLon { get; set; }
        public int SoToGiayLon { get; set; }
        public decimal TienGiay { get; set; }

    }
}
