using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class ThongTinBanDauChoGiaIn
    {
        public string ThongTinCanThiet { get; set; }
        public int SoLuongToChay { get; set; }
        public int IdHangKhachHang { get; set; }
        public int IdToIn_MayIn { get; set; }
        public int IdBaiIn { get; set; }
        public string ThongTinGiay { get; set; }
        public string KhoToChay { get; set; }
        public FormStateS TinhTrangForm { get; set; }
       
    }
}
