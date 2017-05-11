using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class ThongTinBanDauChoGiayIn
    {
        public string ThongTinCanThiet { get; set; }
        public int SoLuongSanPham { get; set; }
        public int IdHangKhachHang { get; set; }
        public string KhoMayIn { get; set; }
        public FormStates TinhTrangForm { get; set; }
       
    }
}
