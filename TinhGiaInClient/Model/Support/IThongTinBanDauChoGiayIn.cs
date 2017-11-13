using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Model.Support
{
    public interface IThongTinBanDauChoGiayIn
    {
        string ThongTinCanThiet { get; set; }
        int SoLuongSanPham { get; set; }
        KichThuocPhang KichThuocSanPham { get; set; }
        int IdHangKhachHang { get; set; }
        int IdToIn_MayInChon { get; set; }
        PhuongPhapInS PhuongPhapIn { get; set; }
        FormStateS TinhTrangForm { get; set; }
       
    }
}
