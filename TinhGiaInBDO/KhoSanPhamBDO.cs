using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInBDO
{
    public class KhoSanPhamBDO
    {
        public int ID{ get; set; }
        public string Ten { get; set; }
        public float KhoCatRong { get; set; }
        public float KhoCatCao { get; set; }
        public string DienGiai { get; set; }
        public int ThuTu { get; set; }      
    }
}
