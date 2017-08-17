using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInBDO
{
    public class BangGiaInNhanhBDO
    {
        public int ID { get; set; }
        public string TenBangGia { get; set; }
        public string MoTa { get; set; }
        public string DaySoLuong { get; set; }
        public string DayGia { get; set; }
        public string NoiDungBangGia { get; set; }
        public int IdHangKhachHang { get; set; }
        public int SoTrangToiDa { get; set; }
        public string DaySoLuongNiemYet { get; set; }
        public bool GiaTheoKhoang { get; set; }
        public int ThuTu { get; set; }
        public bool KhongSuDung { get; set; }
    }
}
