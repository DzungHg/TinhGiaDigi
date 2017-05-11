using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInBDO
{
    public class OffsetGiaCongBDO
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string TenNhaCungCap { get; set; }
        public string TenKhoIn { get; set; }
        public int KhoInRongMax { get; set; }
        public int KhoInDaiMax { get; set; }
        public int KhoInRongMin { get; set; }
        public int KhoInDaiMin { get; set; }
        public bool TuTroNhip { get; set; }
        public int GiaCongIn { get; set; }
        public int SoMatInCoBan { get; set; }
        public int GiaInMoiMatVuotCoBan { get; set; }
        public int SoToChayBuHaoCoBan { get; set; }
        public string ThongTinThoDungMayIn { get; set; }
        public string GhiChu { get; set; }
        public int ThuTu { get; set; }
        public bool KhongDung { get; set; }
    }
}
