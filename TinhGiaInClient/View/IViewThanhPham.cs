using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.View
{
    public interface IViewThanhPham
    {
        int IdBaiIn { get; set; }
        string TenThPhChon { get; set; }
        int LoaiThPh { get; set; }
        int IdHangKhachHang { get; set; }
        string ThongTinHangKH { get; }
        string ThongTinTyLeMarkUp { get; }
        int SoLuong { get; set; }
        string DonViTinh { get; set; }
        decimal ThanhTien { get; }
        string ThongTinHoTro { get; set; }
        int TinhTrangForm { get; set; }
      
       
    }
}
