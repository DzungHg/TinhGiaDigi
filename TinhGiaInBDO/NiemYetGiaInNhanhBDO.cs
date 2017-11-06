using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInBDO
{
    public class NiemYetGiaInNhanhBDO
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string DienGiai { get; set; }
        public int IdBangGia { get; set; }
        public int IdHangKhachHang { get; set; }        
        public int SoTrangToiDa { get; set; }        
        public int ThuTu { get; set; }
        public bool KhongSuDung { get; set; }
        public string DaySoLuongNiemYet { get; set; }
        public string LoaiBangGia { get; set; }//CONTS
        public bool DuocGomTrang { get; set; }
    }
}
