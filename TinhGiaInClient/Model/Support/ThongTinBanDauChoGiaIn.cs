using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Model.Support
{
    public struct ThongTinBanDauChoGiaIn
    {
        public string ThongTinCanThiet { get; set; }
        public string TieuDeForm { get; set; }
        public int SoToChay { get; set; }
        public int IdHangKhachHang { get; set; }
        public int IdToIn_MayIn { get; set; }
        public int IdBaiIn { get; set; }
        public string ThongTinGiay { get; set; }
        public string KhoToChay { get; set; }
        public FormStateS TinhTrangForm { get; set; }
       
    }
}
