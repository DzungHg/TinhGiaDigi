using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.View
{
    public interface IViewThanhPham
    {
        int ID { get; set; }
        int IdBaiIn { get; set; }
        int IdThanhPhamChon { get; set; }
        string TenThanhPhamChon { get; set; }
        LoaiThanhPhamS LoaiThPh { get; set; }
        int IdHangKhachHang { get; set; }
       
        int SoLuong { get; set; }
        string DonViTinh { get; set; }
        decimal ThanhTien { get; set; }
        string ThongTinHoTro { get; set; }
        FormStateS TinhTrangForm { get; set; }
        MucThanhPham LayMucThanhPham();
      
       
    }
}
