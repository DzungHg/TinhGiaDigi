using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInBDO
{
    public class BangGiaBDO
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string DienGiai { get; set; }
        public string DaySoLuong { get; set; }
        public string DayGia { get; set; }
       
        public string DonViTinh { get; set; }
        public int ThuTu { get; set; }
        public bool KhongCon { get; set; }
        public string LoaiBangGia { get; set; }
    }
}
