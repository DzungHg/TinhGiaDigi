using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Model.Support
{
    public struct ThongTinBanDauChoGiayInDanhThiep: IThongTinBanDauChoGiayIn
    {
        //Implement 
        public string ThongTinCanThiet { get; set; }
        public int SoLuongSanPham { get; set; }
        public KichThuocPhang KichThuocSanPham { get; set; }

        public int IdHangKhachHang { get; set; }
        public int IdToIn_MayInChon { get; set; }
        public PhuongPhapInS PhuongPhapIn { get; set; }
        public FormStateS TinhTrangForm { get; set; }
        //Thêm vô của 
        public int SoDanhThiepTrenHop { get; set; }
       
    }
}
